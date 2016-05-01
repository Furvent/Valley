using UnityEngine;
using System.Collections.Generic;

public class Hexa : MonoBehaviour {

    #region Constantes

    public static int NEIGHBORS_LENGTH = 6;

    #endregion

    #region Fields
    //basic hexagon mesh making
    public Material mat;

    public bool iWasAlreadyGenerateByEditor = false; // Use to flag generation when pfb is put in the scene.

    [SerializeField]
    private float _hexRadius;

    [Header("Geometric Data")]
    public Vector3 hexExt;
    public Vector3 hexSize;
    public Vector2C position;

    [Header("Characteristic")]
    public float MvmtCoast;
    public bool isWalkable;

    [Header("Neighbors")] // Neighbors is used by game engine.
    public Transform NorthEast;
    public Transform NorthWest, West, SouthWest, SouthEast, East;
    //[HideInInspector]
    public Transform[] neighbors;
    public Node node; // Class used to handle pathfinding.
    #endregion

    #region SetUp

    void Awake()
    {
        ListMeInHexaList();
        CalculateGeometry();
        position = new Vector2C(transform.position.x, transform.position.z);
        node = new Node(transform.position.x, transform.position.z);
        AttributeIndexNeighbours();
    }

    void Start()
    {
        //CalculateGeometry();
        //node = new Node(transform.position.x, transform.position.z);
        //Debug.Log("I'm " + gameObject.name + " and i was generated !");
    }

    public void NameGOByPos()
    {
        string _oldName_ = gameObject.name;
        string _name_ = "Hexa " + transform.position.x + ":" + transform.position.z;
        gameObject.name = _name_;
        Debug.Log(_oldName_ + " renamed " + _name_);
    }

    public void ListMeInHexaList()
    {
        //if (!GameManager.Map.hexaList.Contains(this))
        //{
        //    GameManager.Map.hexaList.Add(this);
        //    //Debug.Log(name + " was listed in hexaList");
        //}

        if (!GameManager.Map.hexaList.ContainsValue(this))
        {
            GameManager.Map.hexaList.Add(new Vector2C(transform.position.x, transform.position.z), this);
            Debug.Log(name + " was listed in hexaList");
        }
    }
    #endregion

    #region Neighbors

    /// <summary>
    /// Attribute index, use to have a visual in inspector. Use before neighbour's attribution --> best time is at Awake().
    /// </summary>
    private void AttributeIndexNeighbours()
    {
        NorthEast = NorthWest = West = SouthWest = SouthEast = East = null;
        neighbors = new Transform[NEIGHBORS_LENGTH];
        neighbors[(int)Neighbors.NorthEast] = NorthEast;
        neighbors[(int)Neighbors.NorthWest] = NorthWest;
        neighbors[(int)Neighbors.West] = West;
        neighbors[(int)Neighbors.SouthWest] = SouthWest;
        neighbors[(int)Neighbors.SouthEast] = SouthEast;
        neighbors[(int)Neighbors.East] = East;
    }

    /// <summary>
    /// Take all Transform neighbors and list them in a array. Index is the same to all Hexa.
    /// </summary>
    public void ListNeighbours()
    {
        foreach (Hexa hex in GameManager.Map.hexaList.Values)
        {
            if (hex == this) // Don't need to check with itself ^^.
            {
                continue;
            }

            float _x_ = Rounded(hex.transform.position.x); // Used as ref.
            float _z_ = hex.transform.position.z; // Used as ref.

            if (Mathf.Abs((hex.transform.position.x) - (transform.position.x)) > (hexSize.x + 0.5)
                || Mathf.Abs((_z_) - (transform.position.z)) > (hexSize.z + 0.5)) // Dont need to check Hexa far away // TODO r�gler probleme algo
            {
                continue;
            }

            // Debug.Log("i'm " + hex.gameObject.name + " and i pass the firewall, i have xFire=" + (hex.transform.position.x - transform.position.x) + ">" + (hexSize.x + 0.5) + "And zFire = " + (_z_ - transform.position.z) + ">" + (hexSize.z + 0.5));

            GameManager.Manager.iteration++; // Use to see how many iterations.

            /*West*/
            if (Rounded(_x_) == Rounded(transform.position.x - hexSize.x)
                && _z_ == transform.position.z)
            {
                West = hex.transform;
                neighbors[(int)Neighbors.West] = hex.transform;
                //string str = "I'm " + gameObject.name + " and i choose " + hex.gameObject.name + " for West neighbor";
                //Debug.Log(str);
            }

            /*SouthWest*/
            else if (Rounded(_x_) == Rounded(transform.position.x - hexExt.x)
                && _z_ == transform.position.z - (hexSize.z * 0.75f))
            {
                SouthWest = hex.transform;
                neighbors[(int)Neighbors.SouthWest] = hex.transform;
                //string str = "I'm " + gameObject.name + " and i choose " + hex.gameObject.name + " for SouthWest neighbor";
                //Debug.Log(str);
            }

            /*SouthEast*/
            else if (Rounded(_x_) == Rounded(transform.position.x + hexExt.x)
                && _z_ == transform.position.z - (hexSize.z * 0.75f))
            {
                SouthEast = hex.transform;
                neighbors[(int)Neighbors.SouthEast] = hex.transform;
                //string str = "I'm " + gameObject.name + " and i choose " + hex.gameObject.name + " for SouthEast neighbor";
                //Debug.Log(str);
            }

            /*East*/
            else if (Rounded(_x_) == Rounded(transform.position.x + hexSize.x)
                && _z_ == transform.position.z)
            {
                East = hex.transform;
                neighbors[(int)Neighbors.East] = hex.transform;
                //string str = "I'm " + gameObject.name + " and i choose " + hex.gameObject.name + " for East neighbor";
                //Debug.Log(str);
            }

            /*NorthEast*/
            else if (Rounded(_x_) == Rounded(transform.position.x + hexExt.x)
                && _z_ == transform.position.z + (hexSize.z * 0.75f))
            {
                NorthEast = hex.transform;
                neighbors[(int)Neighbors.NorthEast] = hex.transform;
                //string str = "I'm " + gameObject.name + " and i choose " + hex.gameObject.name + " for NorthEast neighbor";
                //Debug.Log(str);
            }

            /*NorthWest*/
            else if (Rounded(_x_) == Rounded(transform.position.x - hexExt.x)
                && _z_ == transform.position.z + (hexSize.z * 0.75))
            {
                NorthWest = hex.transform;
                neighbors[(int)Neighbors.NorthWest] = hex.transform;
                //string str = "I'm " + gameObject.name + " and i choose " + hex.gameObject.name + " for NorthWest neighbor";
                //Debug.Log(str);
            }
        }
    }

    /// <summary>
    /// List all nodes to pathfinding.
    /// VERY IMPORTANT to call it AFTER ListNeighbors, because if ListNeighbors is refresh, it's important to clean node.neighbours.
    /// </summary>
    public void ListNeighboursNodes()
    {
        if (node.neighbours != null)
        {
            node.neighbours.Clear(); 
        }
        if (neighbors.Length == NEIGHBORS_LENGTH)
        {
            foreach(Transform ngh in neighbors)
            {
                if (ngh != null) node.neighbours.Add(ngh.GetComponent<Hexa>().node);
            }
        }
        

    }

    /// <summary>
    /// Use in ListNeighbors to facility the opposition of neighbours.
    /// </summary>
    /// <param name="ngb"> Voisin dont on veut trouver l'oppos� </param>
    /// <returns> the opposite Neighbours</returns>
    private Neighbors ReverseNeigboursDirection(Neighbors ngb)
    {
        Neighbors opNgb;

        if (ngb == Neighbors.East)
            opNgb = Neighbors.West;
        else if (ngb == Neighbors.NorthEast)
            opNgb = Neighbors.SouthWest;
        else if (ngb == Neighbors.NorthWest)
            opNgb = Neighbors.SouthEast;
        else if (ngb == Neighbors.SouthEast)
            opNgb = Neighbors.NorthWest;
        else if (ngb == Neighbors.SouthWest)
            opNgb = Neighbors.NorthEast;
        else if (ngb == Neighbors.West)
            opNgb = Neighbors.East;
        else
            return ngb; // Oblig� de mettre �a, sinon pas de compile...

        return opNgb;
    }

    private float Rounded(float r)
    {
        return Mathf.Ceil(Mathf.Round(r * 10) / 10);
    }

    #endregion

    #region Collide
    void OnMouseOver()
    {
        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            GameManager.Player.selectedUnit.Move(position);
        }
    }
    #endregion

    #region MeshSetup
    /// <summary>
    /// Draw the Hexagon with a custom radius. Radius is used by vertices.
    /// </summary>
    public void MeshSetup()
    {
        //if (gameObject.GetComponent<MeshFilter>()) // Check if hexa is already generate, in this case --> return.
        //{
        //    Debug.Log("Hexa : " + gameObject.name + " already generate !");
        //    return;
        //}

        if (!gameObject.GetComponent<MeshFilter>())
        {
            gameObject.AddComponent<MeshFilter>();
        }

        if (!gameObject.GetComponent<MeshRenderer>())
        {
            gameObject.AddComponent<MeshRenderer>();
        }

        if (!gameObject.GetComponent<MeshCollider>())
        {
            // Use to generate dimension like size and extends.
            gameObject.AddComponent<MeshCollider>();
        }

        // Classic mesh setup.
        //gameObject.AddComponent<MeshFilter>();
        //gameObject.AddComponent<MeshRenderer>();

        // Use to generate dimension like size and extends.
        //gameObject.AddComponent<MeshCollider>();

        // Generate vertices, triangles and uv.
        #region verts

        float floorLevel = 0;
        //positions vertices of the hexagon to make a normal hexagon
        Vector3[] vertices = new Vector3[]
            {
                /*0*/new Vector3((_hexRadius * Mathf.Cos((float)(2*Mathf.PI*(3+0.5)/6))), floorLevel, (_hexRadius * Mathf.Sin((float)(2*Mathf.PI*(3+0.5)/6)))),
                /*1*/new Vector3((_hexRadius * Mathf.Cos((float)(2*Mathf.PI*(2+0.5)/6))), floorLevel, (_hexRadius * Mathf.Sin((float)(2*Mathf.PI*(2+0.5)/6)))),
                /*2*/new Vector3((_hexRadius * Mathf.Cos((float)(2*Mathf.PI*(1+0.5)/6))), floorLevel, (_hexRadius * Mathf.Sin((float)(2*Mathf.PI*(1+0.5)/6)))),
                /*3*/new Vector3((_hexRadius * Mathf.Cos((float)(2*Mathf.PI*(0+0.5)/6))), floorLevel, (_hexRadius * Mathf.Sin((float)(2*Mathf.PI*(0+0.5)/6)))),
                /*4*/new Vector3((_hexRadius * Mathf.Cos((float)(2*Mathf.PI*(5+0.5)/6))), floorLevel, (_hexRadius * Mathf.Sin((float)(2*Mathf.PI*(5+0.5)/6)))),
                /*5*/new Vector3((_hexRadius * Mathf.Cos((float)(2*Mathf.PI*(4+0.5)/6))), floorLevel, (_hexRadius * Mathf.Sin((float)(2*Mathf.PI*(4+0.5)/6))))
            };
        #endregion

        #region triangles

        //triangles connecting the verts
        int[] triangles = new int[]
        {
            1,5,0,
            1,4,5,
            1,2,4,
            2,3,4
        };

        #endregion

        #region uv
        //uv mappping
        Vector2[] uv = new Vector2[]
            {
                new Vector2(0,0.25f),
                new Vector2(0,0.75f),
                new Vector2(0.5f,1),
                new Vector2(1,0.75f),
                new Vector2(1,0.25f),
                new Vector2(0.5f,0),
            };
        #endregion

        #region Make Mesh
        /* Now we can make our mesh ! */

        Mesh mesh = new Mesh();
        mesh.vertices = vertices;
        mesh.triangles = triangles;
        mesh.uv = uv;

        gameObject.GetComponent<MeshFilter>().mesh = mesh;
        gameObject.GetComponent<MeshFilter>().mesh.RecalculateNormals(); // Really necessary ? In tuto, used to play lightning, but how ?
        gameObject.GetComponent<MeshCollider>().sharedMesh = mesh;

        // Calculate geometry.
        CalculateGeometry();

        GetComponent<MeshRenderer>().sharedMaterial = mat;
        #endregion
    }

    public void CalculateGeometry()
    {
        hexExt = gameObject.GetComponent<Collider>().bounds.extents;
        hexSize = gameObject.GetComponent<Collider>().bounds.size;
        
    }
    #endregion
}

public enum Neighbors
{
    NorthEast = 0, NorthWest = 1, West = 2, SouthWest = 3, SouthEast = 4, East = 5
}
