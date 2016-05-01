using UnityEngine;
using System.Collections.Generic;

[System.Serializable]
public class Node
{
    [System.NonSerialized]
    public List<Node> neighbours;

    public float _x;
    public float _z;

    //public Vector2C pos;

    #region Constructor
    /// <summary>
    /// Default constructor.
    /// </summary>
    public Node()
    {
        neighbours = new List<Node>();
        _x = 0f;
        _z = 0f;
        //pos = new Vector2C(0f, 0f);
    }

    public Node(float x, float z)
    {
        neighbours = new List<Node>();
        _x = x;
        _z = z;
        //pos = new Vector2C(x, z);
    }
    #endregion

    /// <summary>
    /// Used in the first version of pathfinding algo.
    /// </summary>
    /// <param name="n"></param>
    /// <returns></returns>
    public float DistanceTo(Node n)
    {
        if (n == null)
        {
            Debug.Log("WTF ?!");
        }

        return Vector2.Distance(new Vector2(_x, _z), new Vector2(n._x, n._z));
    }

    public Vector2C ConvertToVector2C()
    {
        return new Vector2C(_x, _z);
    }

    public Vector3 ConvertToVector3()
    {
        return new Vector3(_x, 0, _z);
    }
}
