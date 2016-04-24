using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour
{

    [Header("Map Settings")]
    [SerializeField]
    private int _mapRadius;

    public static MapData mapData;

    // Use this for initialization
    void Start ()
    {
        mapData = new MapData(_mapRadius);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
