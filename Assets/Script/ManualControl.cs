using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManualControl : MonoBehaviour {
    GameObject arm;

    WristControl wrist;
    AuriculaireControl auriculaire;
    RingControl ringFinger;
    MiddleControl middleFinger;
    IndexControl index;
    ThumbControl thumb;

	// Use this for initialization
	void Start () {
        arm = GetComponent<GameObject>();
        wrist = GameObject.FindObjectOfType(typeof(WristControl)) as WristControl;
        auriculaire = GameObject.FindObjectOfType(typeof(AuriculaireControl)) as AuriculaireControl;
        ringFinger = GameObject.FindObjectOfType(typeof(RingControl)) as RingControl;
        middleFinger = GameObject.FindObjectOfType(typeof(MiddleControl)) as MiddleControl;
        index = GameObject.FindObjectOfType(typeof(IndexControl)) as IndexControl;
        thumb = GameObject.FindObjectOfType(typeof(ThumbControl)) as ThumbControl;
	}
	
	// Update is called once per frame
    void Update () {
        if (Input.GetKey(KeyCode.Z))
            wrist.UpWrist();
        if (Input.GetKey(KeyCode.S))
            wrist.DownWrist();
        if (Input.GetKey(KeyCode.Q))
            wrist.LeftWrist();
        if (Input.GetKey(KeyCode.D))
            wrist.RightWrist();
        if (Input.GetKey(KeyCode.DownArrow)){
            closeHand();
        }
            
        if (Input.GetKey(KeyCode.UpArrow)){
            openHand();
        }
            
        
    }

    public void closeHand()
    {
        auriculaire.CloseFinger();
        ringFinger.CloseFinger();
        middleFinger.CloseFinger();
        index.CloseFinger();
        thumb.CloseFinger();
    }

    public void openHand()
    {
        auriculaire.OpenFinger();
        ringFinger.OpenFinger();
        middleFinger.OpenFinger();
        index.OpenFinger();
        thumb.OpenFinger();
    }
}
