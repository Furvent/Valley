using UnityEngine;
using System.Collections.Generic;

public class Map : MonoBehaviour
{

    #region Fields
    [Header("Map Settings")]
    public Dictionary<Vector2C, Hexa> hexaList;

    //private Dictionary<Vector2C, Node> graph;
    #endregion

    void Awake()
    {
        GameManager.Map = this;
        hexaList = new Dictionary<Vector2C, Hexa>();
    }

    // Use this for initialization
    void Start ()
    {
        /*Iteration and time*/
        GameManager.Manager.iteration = 0;
        GameManager.Manager.time = Time.realtimeSinceStartup;

        GenerateHexaNeighbours();
        GeneratePathfindingGraph();

        Debug.Log("Time past during iterations to find neighbours : " + (Time.realtimeSinceStartup - GameManager.Manager.time));
        Debug.Log("Time past since play button : " + Time.realtimeSinceStartup);
        Debug.Log("Iterations : " + GameManager.Manager.iteration + ". This is bad Doc ?");
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    #region Setup
    /// <summary>
    /// Call HexaListNeighbours() in all Hexa component, to get their reciprocal neighbours.
    /// </summary>
    private void GenerateHexaNeighbours()
    {
        foreach (Hexa hexa in hexaList.Values)
        {
            Debug.Log("CallAllHexaListNeighbors for - " + hexa.name);
            hexa.ListNeighbours();
        }

        Debug.Log("I'm the Map, in GenerateHexaNeighbours(), and i call all the functions --ListNeighbours()-- in Hexa script");
    }

    /// <summary>
    /// Generate a graph : create a nod in all hexa and ask them to find their neighbours.
    /// </summary>
    private void GeneratePathfindingGraph()
    {
        //graph = new Dictionary<Vector2C, Node>();

        // Initialize a node for each hexagon, and ref all neighbours
        foreach (Hexa hex in hexaList.Values)
        {
            //Vector2C vec = new Vector2C(hex.transform.position.x, hex.transform.position.z);
            //Node node = hex.node;
            //graph.Add(vec, node);
            hex.ListNeighboursNodes();
            Debug.Log("CallAllHexaListNeighborsNodes for - " + hex.name);
        }

        Debug.Log("I'm the Map, in GeneratePathfindingGraph(), and i call all the functions --ListNeighborsNodes()-- in Hexa script");
    }
    #endregion

    #region PathFinding
    /// <summary>
    /// 
    /// </summary>
    /// <param name="x"></param>
    /// <param name="z"></param>
    /// <returns></returns>
    public void GeneratePathTo(Vector2C originPos, Vector2C arrivalPos, out List<Node> path)
    {
        Debug.Log("I'm at the beginning of pathfinding");
        // Clear out our unit's old path.
        path = null;

        if (UnitCantEnterHexa(arrivalPos) == false)
        {
            // We probably clicked on a mountain or something, so just quit out.
            return;
        }

        Dictionary<Node, float> _dist_ = new Dictionary<Node, float>();
        Dictionary<Node, Node> _prev_ = new Dictionary<Node, Node>();

        //Setup the "Q", the list of nodes we haven't checked yet.
        List<Node> _unvisited_ = new List<Node>();

        Node _source_ = hexaList[originPos].node;
        Node _target_ = hexaList[arrivalPos].node;

        _dist_[_source_] = 0;
        _prev_[_source_] = null;

        foreach (Hexa v in hexaList.Values)
        {
            if (v.node != _source_)
            {
                _dist_[v.node] = Mathf.Infinity;
                _prev_[v.node] = null;
                Debug.Log("JE passe l�");
            }

            _unvisited_.Add(v.node);
        }

        while (_unvisited_.Count > 0)
        {
            Debug.Log("Je suis rtentr� dans while");
            // This is not fast ! But it's short ! Consider having "unvisited"  be a priority queue or some other self-sorting, optimized data structure.
            //Node u = unvisited.OrderBy(n => dist[n]).First();

            // "u" is going to be the unvisited node with the smallest distance.
            Node _u_ = null;

            foreach (Node possibleU in _unvisited_)
            {
                if (_u_ == null || _dist_[possibleU] < _dist_[_u_])
                {
                    _u_ = possibleU;
                    Debug.Log("JE passe aussi ici");
                }
            }

            if (_u_ == _target_)
            {
                Debug.Log("Found the target node");
                break; // Exit the while loop !
            }

            _unvisited_.Remove(_u_);

        foreach ( Node v in _u_.neighbours)
            {
                float _alt_ = _dist_[_u_] + CostToEnterTile(_u_.ConvertToVector2C(), v.ConvertToVector2C());

                if (_alt_ < _dist_[v])
                {
                    _dist_[v] = _alt_;
                    _prev_[v] = _u_;
                }
            }
        }

        // If we get there, the either we found the shortest route to our target, or there is no route at ALL to our target.
        if (_prev_[_target_] == null)
        {
            // No route between our target and the source.
            Debug.Log("No route between our target and the source.");
            return;
        }

        List<Node> _currentPath_ = new List<Node>();
        Node _curr_ = _target_;

        // Step through the "prev" chain and add it to our path.
        while (_curr_ != null)
        {
            _currentPath_.Add(_curr_);
            _curr_ = _prev_[_curr_];
        }

        // Right now, currentPath describes a route from our target to our source, so we need to invert it.
        _currentPath_.Reverse();
        // Give back the path to the unit.
        path = _currentPath_;
    }

    private bool UnitCantEnterHexa(Vector2C pos)
    {
        return hexaList[pos].isWalkable;
    }

    private float CostToEnterTile( Vector2C source, Vector2C target)
    {
        if (UnitCantEnterHexa(target) == false)
            return Mathf.Infinity;

        return hexaList[target].MvmtCoast;
    }
    #endregion

}

/// <summary>
/// Light vector custom with x and z use as key to iterate in dictionnary.
/// </summary>
[System.Serializable]
public struct Vector2C
{
    public float x;
    public float z;

    public Vector2C(float newX, float newZ)
    {
        x = newX;
        z = newZ;
    }
}
