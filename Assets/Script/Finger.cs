using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Finger : MonoBehaviour {

    public float degree { get; protected set; }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public abstract void CloseFinger();
    public abstract void OpenFinger();
}
