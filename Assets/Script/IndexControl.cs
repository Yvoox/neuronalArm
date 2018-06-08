using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IndexControl : Finger
{

    GameObject Index1;
    GameObject Index2;
    GameObject Index3;


    // Use this for initialization
    void Start()
    {
        degree = 0;
        mask = 0x08;
        Index1 = GameObject.FindGameObjectWithTag("Index1");
        Index2 = GameObject.FindGameObjectWithTag("Index2");
        Index3 = GameObject.FindGameObjectWithTag("Index3");

    }

    // Update is called once per frame
    void Update()
    {

    }

    public override void CloseFinger()
    {
        if (degree < 90)
        {
            Index1.transform.Rotate(Vector3.up, ManualControl.time/2);
           if (degree < 15) Index1.transform.Rotate(Vector3.right, ManualControl.time/2);
            degree += ManualControl.time/2;
        }
        if (degree >= 90 && degree < 150)
        {
            Index2.transform.Rotate(Vector3.up, ManualControl.time/2);
            degree += ManualControl.time/2;
        }
        if (degree >= 150 && degree < 210)
        {
            Index3.transform.Rotate(Vector3.up, ManualControl.time/2);
            degree += ManualControl.time/2;
        }

    }

    public override void OpenFinger()
    {
        if (degree > 0 && degree <= 90)
        {
            Index1.transform.Rotate(Vector3.down, ManualControl.time/2);
            if (degree < 15) Index1.transform.Rotate(Vector3.left, ManualControl.time/2);
            degree -= ManualControl.time/2;
        }
        if (degree > 90 && degree <= 150)
        {
            Index2.transform.Rotate(Vector3.down, ManualControl.time/2);
            degree -= ManualControl.time/2;
        }
        if (degree > 150)
        {
            Index3.transform.Rotate(Vector3.down, ManualControl.time/2);
            degree -= ManualControl.time/2;
        }

    }
}