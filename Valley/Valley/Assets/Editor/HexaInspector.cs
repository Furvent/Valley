//using UnityEngine;
//using UnityEditor;
//using System.Collections;

//[CustomEditor(typeof(Hexa))]
//public class HexaInspector : Editor {

//    public override void OnInspectorGUI()
//    {
//        base.OnInspectorGUI();
//        Hexa hexa = (Hexa)target;

//        //DrawDefaultInspector();
//        if (GUILayout.Button("Regenerate"))
//        {
//            hexa.MeshSetup();
//        }

//        if (GUILayout.Button("Give me a name bitch !"))
//        {
//            hexa.NameGOByPos();
//        }

//        if (GUILayout.Button("List neighbors"))
//        {
//            hexa.ListNeighbors();
//            hexa.ListNeighborsNodes();
//        }

//        if (GUILayout.Button("Give me geometric Data Bro !"))
//        {
//            serializedObject.Update();
//            Collider c = hexa.GetComponent<Collider>();
//            Vector3 v1 = c.bounds.extents;
//            Vector3 v2 = c.bounds.size;

//            serializedObject.FindProperty("hexExt").vector3Value = v1;
//            serializedObject.FindProperty("hexSize").vector3Value = v2;
//            //hexa.CalculateGeometry();
//        }
//    }
//}
