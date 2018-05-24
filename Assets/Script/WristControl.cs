using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WristControl : MonoBehaviour {

    GameObject wrist;
    private double degree_rotate;
    private double degree_up;


	// Use this for initialization
	void Start () {
        wrist = GameObject.FindGameObjectWithTag("Wrist");
        degree_rotate = 0;
        degree_up = 0;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void RightWrist(){
        if(degree_rotate < 90)
        {
            wrist.transform.Rotate(Vector3.right, Time.deltaTime * 10);
            degree_rotate += Time.deltaTime * 10;
        }

    }

    public void LeftWrist(){
        if(degree_rotate > 0)
        {
            wrist.transform.Rotate(Vector3.left, Time.deltaTime * 10);
            degree_rotate -= Time.deltaTime * 10;
        }

    }

    public void UpWrist(){
        if(degree_up > 0)
        {
            wrist.transform.Rotate(Vector3.up, Time.deltaTime * 10);
            degree_up -= Time.deltaTime * 10;
        }
 
    }

    public void DownWrist(){
        if(degree_up < 45)
        {
            wrist.transform.Rotate(Vector3.down, Time.deltaTime * 10);
            degree_up += Time.deltaTime * 10;
        }

    }

}
