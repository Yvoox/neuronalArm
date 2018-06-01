using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThumbControl : Finger
{

    GameObject Thumb1;
    GameObject Thumb2;
    GameObject Thumb3;



    // Use this for initialization
    void Start()
    {
        degree = 0;
        Thumb1 = GameObject.FindGameObjectWithTag("Thumb1");
        Thumb2 = GameObject.FindGameObjectWithTag("Thumb2");
        Thumb3 = GameObject.FindGameObjectWithTag("Thumb3");

    }

    // Update is called once per frame
    void Update()
    {

    }

    public override void CloseFinger()
    {
        if (degree < 15)
        {
            Thumb1.transform.Rotate(Vector3.up, ManualControl.time);
            Thumb1.transform.Rotate(Vector3.right, ManualControl.time);
            degree += ManualControl.time;
        }
        if (degree >= 15 && degree < 110)
        {
            Thumb2.transform.Rotate(Vector3.up, ManualControl.time);
            degree += ManualControl.time;
        }
        if (degree >= 110 && degree < 190)
        {
            Thumb3.transform.Rotate(Vector3.up, ManualControl.time);
            degree += ManualControl.time;
        }

    }

    public override void OpenFinger()
    {
        if (degree > 0 && degree <= 15)
        {
            Thumb1.transform.Rotate(Vector3.down, ManualControl.time);
            Thumb1.transform.Rotate(Vector3.left, ManualControl.time);
            degree -= ManualControl.time;
        }
        if (degree > 15 && degree <= 110)
        {
            Thumb2.transform.Rotate(Vector3.down, ManualControl.time);
            degree -= ManualControl.time;
        }
        if (degree > 110)
        {
            Thumb3.transform.Rotate(Vector3.down, ManualControl.time);
            degree -= ManualControl.time;
        }
    }

}
