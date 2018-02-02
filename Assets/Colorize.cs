using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Colorize : MonoBehaviour {

    public float bsize = 1f;
   
	// Use this for initialization
	void Start () {
        GenerateColor();
	}

    public void GenerateColor() {
        GetComponent<Renderer>().sharedMaterial.color = Random.ColorHSV();
    }

    public void ResetColor() {
        GetComponent<Renderer>().sharedMaterial.color = Color.white;
    }

    
	
	
}
