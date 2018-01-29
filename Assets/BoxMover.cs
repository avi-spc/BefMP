using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class BoxMover : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKey(KeyCode.UpArrow)) {
            GetComponent<Rigidbody>().transform.Translate(new Vector3(0, 0, 1) * 6 * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.DownArrow)) {
            GetComponent<Rigidbody>().transform.Translate(new Vector3(0, 0, -1) * 6 * Time.deltaTime);
        }
	}

    
}
