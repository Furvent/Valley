using UnityEngine;
using UnityEditor;
using System.Collections;

public class HexaEditor : Editor
{

    [DrawGizmo(GizmoType.Selected | GizmoType.NonSelected)]
    static void GiveNameToBitches(Hexa hex, GizmoType type)
    {
        if (EditorApplication.isPlaying)
        {
            return;
        }
        string _name_ = "Hexa " + hex.transform.position.x + ":" + hex.transform.position.z;
        hex.gameObject.name = _name_;
    }

    [DrawGizmo(GizmoType.Selected | GizmoType.NonSelected)]
    static void GenerateHexa(Hexa hex, GizmoType type)
    {
        if (EditorApplication.isPlaying)
        {
            return;
        }

        if (!hex.iWasAlreadyGenerateByEditor)
        {
            Debug.Log("i'm entering in HexaEditor.GenerateHexa with flag iWasAlreadyGenerateByEditor in false");
            hex.MeshSetup();
            //hex.CalculateGeometry();
            //hex.ListMeInHexaList();

            hex.iWasAlreadyGenerateByEditor = true;
        }
    }

}
