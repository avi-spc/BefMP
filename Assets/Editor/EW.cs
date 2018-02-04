using System;
using UnityEditor;
using UnityEngine;

public class EW : EditorWindow
{
    Color color;
    int numberofCopies;
    public float s = 1;
    string tagName = "", nameName = "";
    [MenuItem("Window/Colorize")]
    public static void ShowWin()
    {
        EditorWindow.GetWindow<EW>("Colorize");
    }

    void OnGUI()
    {
        
        numberofCopies = EditorGUILayout.DelayedIntField("Copies", numberofCopies);
        color = EditorGUILayout.ColorField("Color", color);
        if (GUILayout.Button("Colorize"))
        {
            Colorized();
        }

        if(GUILayout.Button("Reset Position"))
        {
            ResetPos();
        }

        if (GUILayout.Button("Clone")) {
            Cloning();
        }

        tagName = EditorGUILayout.TextField("Tag", tagName);

        if (GUILayout.Button("Select with tag")) {
            SelectGameObjectWithTag();
        }
        nameName = EditorGUILayout.TextField("GameObject_name", nameName);
        if (GUILayout.Button("Select with name")) {
            SelectGameObjectWithName();
        }

        s = EditorGUILayout.Slider("fdf", s, 1, 10);
        foreach (GameObject obj in Selection.gameObjects) {
            obj.transform.localScale = Vector3.one * s;
        }
    }
    void Colorized()
    {
        foreach (GameObject obj in Selection.gameObjects)
        {
            obj.GetComponent<Renderer>().sharedMaterial.color = color;
            //obj.AddComponent<Rigidbody>();
        }
    }

    void ResetPos() {
        foreach(GameObject obj in Selection.gameObjects){
            obj.transform.position = Vector3.zero;
            obj.transform.rotation = Quaternion.identity;
           
        }
    }

    void Cloning(){
        for (int i = 1; i <= numberofCopies; i++ ) { 
            foreach (GameObject obj in Selection.gameObjects) {                
                GameObject newobj = Instantiate(obj, obj.transform.position, obj.transform.rotation);
                newobj.name = obj.name + "_" + i;
            }
        }
    }

    void SelectGameObjectWithTag() {
        try
        {
            GameObject[] tagObj = GameObject.FindGameObjectsWithTag(tagName);
            Selection.objects = tagObj;
        }

        catch (Exception e) {
            //Debug.Log("Tag does not exist");
            EditorUtility.DisplayDialog("Undefined Tag?", "Tag you entered is not defined.", "OK");
        }
     }

    void SelectGameObjectWithName() {
        try
        {
            GameObject nameObj = GameObject.Find(nameName);
            Selection.activeGameObject = nameObj;
        }

        catch (Exception e)
        {
            //Debug.Log("Tag does not exist");
            EditorUtility.DisplayDialog("Not Found?", "GameObjct with such a name doesn't exist.", "OK");
        }
    }
}
