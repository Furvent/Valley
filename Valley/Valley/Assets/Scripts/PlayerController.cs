using UnityEngine;
using System.Collections.Generic;

public class PlayerController : MonoBehaviour
{

    public Unit selectedUnit;

    void Awake()
    {

    }

    // Use this for initialization
    void Start ()
    {
        GameManager.Player = this;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

}
