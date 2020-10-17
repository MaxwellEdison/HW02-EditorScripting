using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(Cube))]
public class CubeEditor : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        Cube cube = (Cube)target;

        GUILayout.BeginHorizontal();

            if(GUILayout.Button("Generate Color"))
            {
                Debug.Log("We pressed 'Generate Color'");
                cube.GenerateColor();
            }
            if(GUILayout.Button("Reset Color"))
            {
                Debug.Log("We pressed 'Reset Color'");
                cube.Reset();
            }
        GUILayout.EndHorizontal();
    }



}
