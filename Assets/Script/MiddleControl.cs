using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiddleControl : Finger
{

    GameObject MiddleFinger1;
    GameObject MiddleFinger2;
    GameObject MiddleFinger3;


    // Use this for initialization
    void Start()
    {
        degree = 0;
        mask = 0x04;
        MiddleFinger1 = GameObject.FindGameObjectWithTag("MiddleFinger1");
        MiddleFinger2 = GameObject.FindGameObjectWithTag("MiddleFinger2");
        MiddleFinger3 = GameObject.FindGameObjectWithTag("MiddleFinger3");

    }

    // Update is called once per frame
    void Update()
    {

    }

    public override void CloseFinger()
    {
        if (degree < 115)
        {
            MiddleFinger1.transform.Rotate(Vector3.up, ManualControl.time/2);
            if(degree < 15) MiddleFinger1.transform.Rotate(Vector3.right, ManualControl.time/2);
            degree += ManualControl.time/2;
        }
        if (degree >= 115 && degree < 175)
        {
            MiddleFinger2.transform.Rotate(Vector3.up, ManualControl.time/2);
            degree += ManualControl.time/2;
        }
        if (degree >= 175 && degree < 220)
        {
            MiddleFinger3.transform.Rotate(Vector3.up, ManualControl.time/2);
            degree += ManualControl.time/2;
        }

    }

    public override void OpenFinger()
    {
        if (degree > 0 && degree <= 115)
        {
            MiddleFinger1.transform.Rotate(Vector3.down, ManualControl.time/2);
            if (degree < 15) MiddleFinger1.transform.Rotate(Vector3.left, ManualControl.time/2);
            degree -= ManualControl.time/2;
        }
        if (degree > 115 && degree <= 175)
        {
            MiddleFinger2.transform.Rotate(Vector3.down, ManualControl.time/2);
            degree -= ManualControl.time/2;
        }
        if (degree > 175)
        {
            MiddleFinger3.transform.Rotate(Vector3.down, ManualControl.time/2);
            degree -= ManualControl.time/2;
        }

    }
}