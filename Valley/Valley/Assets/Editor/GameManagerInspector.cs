//using UnityEngine;
//using UnityEditor;
//using System.Collections;

//[CustomEditor(typeof(GameManager))]
//public class GameManagerInspector : Editor
//{

//    public override void OnInspectorGUI()
//    {
//        base.OnInspectorGUI();
//        GameManager gm = (GameManager)target;
//        //DrawDefaultInspector();
//        if (GUILayout.Button("Call All FindNeighbors"))
//        {
//            gm.CallAllHexaListNeighbors();
//            gm.CallAllHexaListNeighborsNodes();
//        }

//        if (GUILayout.Button("Call All ListMeInHexaList"))
//        {
//            gm.CallAllListMeInHexaList();
//        }

//        //if (GUILayout.Button("Call All NameGOByPos"))
//        //{
//        //    Hexa hexa = (Hexa)target;
//        //    hexa.NameGOByPos();
//        //}
//    }
//}
