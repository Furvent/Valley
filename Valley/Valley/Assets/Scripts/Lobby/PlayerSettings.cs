using UnityEngine;
using System.Collections;

public class PlayerSettings : MonoBehaviour
{

    public Faction factionChoose;
    public int test = 0;

    // Use this for initialization
    void Start () {
	
	}

    public void ChooseFaction(int index)
    {
        Debug.Log("Index of choosen faction : " + index);
        test = index;
        factionChoose = (Faction)index;
    }
}

public enum Faction
{
    Faction1 = 0, Faction2, Faction3, Faction4, Faction5, Faction6
}
