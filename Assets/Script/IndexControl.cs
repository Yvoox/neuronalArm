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
            Index1.transform.Rotate(Vector3.up, ManualControl.time);
           if (degree < 15) Index1.transform.Rotate(Vector3.right, ManualControl.time);
            degree += ManualControl.time;
        }
        if (degree >= 90 && degree < 150)
        {
            Index2.transform.Rotate(Vector3.up, ManualControl.time);
            degree += ManualControl.time;
        }
        if (degree >= 150 && degree < 210)
        {
            Index3.transform.Rotate(Vector3.up, ManualControl.time);
            degree += ManualControl.time;
        }

    }

    public override void OpenFinger()
    {
        if (degree > 0 && degree <= 90)
        {
            Index1.transform.Rotate(Vector3.down, ManualControl.time);
            if (degree < 15) Index1.transform.Rotate(Vector3.left, ManualControl.time);
            degree -= ManualControl.time;
        }
        if (degree > 90 && degree <= 150)
        {
            Index2.transform.Rotate(Vector3.down, ManualControl.time);
            degree -= ManualControl.time;
        }
        if (degree > 150)
        {
            Index3.transform.Rotate(Vector3.down, ManualControl.time);
            degree -= ManualControl.time;
        }

    }
}