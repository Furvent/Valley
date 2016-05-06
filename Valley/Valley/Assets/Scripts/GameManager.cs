using UnityEngine;
using System.Collections.Generic;

/// <summary>
/// It's a object put in the scene.
/// </summary>
public class GameManager : MonoBehaviour
{
    public static GameManager Manager { get; private set; }

    private PlayerController _player;
    private Map _map;

    /*Iteration and Time*/
    [HideInInspector]
    public int iteration; // Use to see how many iterations.
    [HideInInspector]
    public float time;

    //[Header("Lobby")]
    //public string mapToLoad;

    #region singleton
    public static PlayerController Player
    {
        get { return Manager._player; }
        set { Manager._player = value; }
    }

    public static Map Map
    {
        get { return Manager._map; }
        set { Manager._map = value; }
    }
    #endregion

    void Awake()
    {
        if (Manager == null)
        {
            DontDestroyOnLoad(transform.root.gameObject);
            Manager = this;
        }
        else if(Manager !=this)
        {
            Destroy(gameObject);
        }
    }
    // Use this for initialization
    void Start ()
    {
        /*Iteration and time*/
        //iteration = 0;
        //time = Time.realtimeSinceStartup;

        //CallAllHexaListNeighbors(); Used here before Map script's creation (01-05-2016).
        //CallAllHexaListNeighborsNodes(); Used here before Map script's creation (29-04-2016).

        /*Iteration and time*/
        //Debug.Log("Time past during iterations to find neighbours : " + (Time.realtimeSinceStartup - time));
        //Debug.Log("Time past since play button : " + Time.realtimeSinceStartup);
        //Debug.Log("Iterations : " + iteration + ". This is bad Doc ?");
    }
	
	// Update is called once per frame
	void Update ()
    {
	
	}

    #region DataStored

    /// <summary>
    /// Iterate in the List that stored all Hexa, and call the named fuction.
    /// </summary>
    //public void CallAllHexaListNeighbors()
    //{
    //    foreach(Hexa hexa in _map.hexaList )
    //    {
    //        Debug.Log("CallAllHexaListNeighbors for - " + hexa.name);
    //        hexa.ListNeighbors();
    //    }

    //    Debug.Log("I'm the GameManager, and i call all the functions --ListNeighbors()-- in Hexa script");
    //}


    /// <summary>
    /// Iterate in the List that stored all Hexa, and call the named fuction.
    /// </summary>
    //public void CallAllHexaListNeighborsNodes()
    //{
    //    foreach (Hexa hexa in _map.hexaList)
    //    {
    //        Debug.Log("CallAllHexaListNeighborsNodes for - " + hexa.name);
    //        hexa.ListNeighborsNodes();
    //    }

    //    Debug.Log("I'm the GameManager, and i call all the functions --CallAllHexaListNeighborsNodes()-- in Hexa script");
    //}
    #endregion
}
