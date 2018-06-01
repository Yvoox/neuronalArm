using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AuriculaireControl : Finger {

    GameObject Auriculaire1;
    GameObject Auriculaire2;
    GameObject Auriculaire3;
    GameObject Auriculaire4;


    // Use this for initialization
    void Start()
    {
        degree = 0;
        Auriculaire1 = GameObject.FindGameObjectWithTag("Auriculaire1");
        Auriculaire2 = GameObject.FindGameObjectWithTag("Auriculaire2");
        Auriculaire3 = GameObject.FindGameObjectWithTag("Auriculaire3");
        Auriculaire4 = GameObject.FindGameObjectWithTag("Auriculaire4");

    }

    // Update is called once per frame
    void Update()
    {

    }

    public override void CloseFinger(){
        if (degree < 15){
            Auriculaire1.transform.Rotate(Vector3.up, ManualControl.time);
            if (degree < 5)  Auriculaire1.transform.Rotate(Vector3.right, ManualControl.time);
            degree += ManualControl.time;
        }
        if (degree >= 15 && degree < 100) 
        {
            Auriculaire2.transform.Rotate(Vector3.up, ManualControl.time);
            if (degree < 20) Auriculaire2.transform.Rotate(Vector3.right, ManualControl.time);
            degree += ManualControl.time;
        }
        if (degree >= 100 && degree < 160)
        {
            Auriculaire3.transform.Rotate(Vector3.up, ManualControl.time);
            if (degree < 80) Auriculaire3.transform.Rotate(Vector3.right, ManualControl.time);
            degree += ManualControl.time;
        }
        if (degree >= 160 && degree < 220)
        {
            Auriculaire4.transform.Rotate(Vector3.up, ManualControl.time);
            if (degree < 125) Auriculaire4.transform.Rotate(Vector3.right, ManualControl.time);
            degree += ManualControl.time;
        }
    }

    public override void OpenFinger(){
        if (degree >0 && degree <= 15)
        {
            Auriculaire1.transform.Rotate(Vector3.down, ManualControl.time);
            if (degree < 5) Auriculaire1.transform.Rotate(Vector3.left, ManualControl.time);
            degree -= ManualControl.time;
        }
        if (degree > 15 && degree <= 100)
        {
            Auriculaire2.transform.Rotate(Vector3.down, ManualControl.time);
            if (degree < 20) Auriculaire2.transform.Rotate(Vector3.left, ManualControl.time);
            degree -= ManualControl.time;
        }
        if (degree > 100 && degree <= 160)
        {
            Auriculaire3.transform.Rotate(Vector3.down, ManualControl.time);
            if (degree < 80) Auriculaire3.transform.Rotate(Vector3.left, ManualControl.time);
            degree -= ManualControl.time;
        }
        if (degree > 160)
        {
            Auriculaire4.transform.Rotate(Vector3.down, ManualControl.time);
            if (degree < 125) Auriculaire4.transform.Rotate(Vector3.left, ManualControl.time);
            degree -= ManualControl.time;
        }
    }
}
