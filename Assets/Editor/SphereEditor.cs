using UnityEngine;
using Unity.EditorCoroutines.Editor;
using System.Collections;
using UnityEditor;

[CustomEditor(typeof(Sphere))]
public class SphereEditor : Editor
{
    bool animEnabled = false;

    public override void OnInspectorGUI()
    {
        //base.OnInspectorGUI();
        GUILayout.Label("Oscilates around a base size");
        Sphere sphere = (Sphere)target;
        sphere.baseSize = EditorGUILayout.Slider("Size", sphere.baseSize, 0.1f, 2f);
        sphere.transform.localScale = Vector3.one * sphere.baseSize;
        if (!animEnabled)
        {
            if (GUILayout.Button("Simulate Animation"))
            {
                Debug.Log("We pressed 'Simulate Animation'");
                animEnabled = true;
                EditorCoroutineUtility.StartCoroutine(SimAnimate(sphere), sphere);
            }
        } else
        {
            if (GUILayout.Button("Stop Simulation"))
            {
                Debug.Log("We pressed 'Stop Simulation'");
                animEnabled = false;
            }
        }
        if (GUILayout.Button("Reset Size"))
        {
            Debug.Log("We pressed 'Reset Size'");
            sphere.transform.localScale = Vector3.one * sphere.baseSize;
        }
    }

    IEnumerator SimAnimate(Sphere sphere)
    {
        Debug.Log("We started animation");
        while (animEnabled)
        {
            Debug.Log("sim looped");
            float animation = sphere.baseSize + Mathf.Sin(Time.time * 8f) * sphere.baseSize / 7f;
            sphere.transform.localScale = Vector3.one * animation;
            yield return new WaitForSeconds(Time.deltaTime);
        }

    }

}
