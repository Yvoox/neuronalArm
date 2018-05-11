using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WristControl : MonoBehaviour {

    GameObject wrist;


	// Use this for initialization
	void Start () {
        wrist = GameObject.FindGameObjectWithTag("Wrist");
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void RightWrist(){
        wrist.transform.Rotate(Vector3.right, Time.deltaTime * 10);
    }

    public void LeftWrist(){
        wrist.transform.Rotate(Vector3.left, Time.deltaTime * 10);
    }

    public void UpWrist(){
        wrist.transform.Rotate(Vector3.up, Time.deltaTime * 10);
    }

    public void DownWrist(){
        wrist.transform.Rotate(Vector3.down, Time.deltaTime * 10);
    }

}
