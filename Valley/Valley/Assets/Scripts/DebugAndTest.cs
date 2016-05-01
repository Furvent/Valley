using UnityEngine;
using System.Collections;

public class DebugAndTest : MonoBehaviour {

    public Transform HexeToTest;

#if UNITY_EDITOR
    [ContextMenu("Give Me Size and Extents")]
    void GiveMeSizeAndExtents()
    {
        Debug.Log("I'm in Debug and Test");
        float x = HexeToTest.GetComponent<Collider>().bounds.size.x;
        float y = HexeToTest.GetComponent<Collider>().bounds.size.y;
        float z = HexeToTest.GetComponent<Collider>().bounds.size.z;
        Debug.Log("Bounds size x=" + x + ", y=" + y + ", z=" + z);
        x = HexeToTest.GetComponent<Collider>().bounds.extents.x;
        y = HexeToTest.GetComponent<Collider>().bounds.extents.y;
        z = HexeToTest.GetComponent<Collider>().bounds.extents.z;
        Debug.Log("Extents size x=" + x + ", y=" + y + ", z=" + z);
    }

    [ContextMenu("Mathf Test")]
    void TestMathf()
    {
        float i = Mathf.Ceil(7.1f);
        float y = Mathf.Ceil(7.8f);
        Debug.Log("i=" + i + " ; y=" + y);
    }
#endif


}
