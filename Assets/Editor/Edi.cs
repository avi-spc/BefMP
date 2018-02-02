using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(Colorize))]
[CanEditMultipleObjects]
public class Edi : Editor {
    
    public override void OnInspectorGUI()
    {
        //base.OnInspectorGUI();

        Colorize co = (Colorize)target;

        GUILayout.BeginHorizontal();

        if (GUILayout.Button("Generate Color")) {
            foreach (GameObject obj in Selection.gameObjects) {
                co.GenerateColor();
            }
            
        }

        if (GUILayout.Button("Reset")) {
            co.ResetColor();
        }

        GUILayout.EndHorizontal();

        co.bsize = EditorGUILayout.Slider("Size", co.bsize, 1, 4);
        
        foreach (GameObject obj in Selection.gameObjects)
        {
            co.transform.localScale = Vector3.one * co.bsize;
        }
    }
}
