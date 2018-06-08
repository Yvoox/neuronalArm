using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RingControl : Finger {

    GameObject RingFinger1;
    GameObject RingFinger2;
    GameObject RingFinger3;
    GameObject RingFinger4;


    // Use this for initialization
    void Start()
    {
        degree = 0;
        mask = 0x02;
        RingFinger1 = GameObject.FindGameObjectWithTag("RingFinger1");
        RingFinger2 = GameObject.FindGameObjectWithTag("RingFinger2");
        RingFinger3 = GameObject.FindGameObjectWithTag("RingFinger3");
        RingFinger4 = GameObject.FindGameObjectWithTag("RingFinger4");

    }

    // Update is called once per frame
    void Update()
    {

    }

    public override void CloseFinger()
    {
        if (degree < 15)
        {
            RingFinger1.transform.Rotate(Vector3.up, ManualControl.time/2);
            if (degree < 5) RingFinger1.transform.Rotate(Vector3.right, ManualControl.time/2);
            degree += ManualControl.time/2;
        }
        if (degree >= 15 && degree < 120)
        {
            RingFinger2.transform.Rotate(Vector3.up, ManualControl.time/2);
            if (degree < 20) RingFinger2.transform.Rotate(Vector3.right, ManualControl.time/2);
            degree += ManualControl.time/2;
        }
        if (degree >= 120 && degree < 180)
        {
            RingFinger3.transform.Rotate(Vector3.up, ManualControl.time/2);
            if (degree < 80) RingFinger3.transform.Rotate(Vector3.right, ManualControl.time/2);
            degree += ManualControl.time/2;
        }
        if (degree >= 180 && degree < 240)
        {
            RingFinger4.transform.Rotate(Vector3.up, ManualControl.time/2);
            if (degree < 125) RingFinger4.transform.Rotate(Vector3.right, ManualControl.time/2);
            degree += ManualControl.time/2;
        }
    }

    public override void OpenFinger()
    {
        if (degree > 0 && degree <= 15)
        {
            RingFinger1.transform.Rotate(Vector3.down, ManualControl.time/2);
            if (degree < 5) RingFinger1.transform.Rotate(Vector3.left, ManualControl.time/2);
            degree -= ManualControl.time/2;
        }
        if (degree > 15 && degree <= 120)
        {
            RingFinger2.transform.Rotate(Vector3.down, ManualControl.time/2);
            if (degree < 20) RingFinger2.transform.Rotate(Vector3.left, ManualControl.time/2);
            degree -= ManualControl.time/2;
        }
        if (degree > 120 && degree <= 180)
        {
            RingFinger3.transform.Rotate(Vector3.down, ManualControl.time/2);
            if (degree < 80) RingFinger3.transform.Rotate(Vector3.left, ManualControl.time/2);
            degree -= ManualControl.time/2;
        }
        if (degree > 180)
        {
            RingFinger4.transform.Rotate(Vector3.down, ManualControl.time/2);
            if (degree < 125) RingFinger4.transform.Rotate(Vector3.left, ManualControl.time/2);
            degree -= ManualControl.time/2;
        }
    }
}
