using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RingControl : MonoBehaviour {

    GameObject RingFinger1;
    GameObject RingFinger2;
    GameObject RingFinger3;
    GameObject RingFinger4;
    float degree;


    // Use this for initialization
    void Start()
    {
        degree = 0;
        RingFinger1 = GameObject.FindGameObjectWithTag("RingFinger1");
        RingFinger2 = GameObject.FindGameObjectWithTag("RingFinger2");
        RingFinger3 = GameObject.FindGameObjectWithTag("RingFinger3");
        RingFinger4 = GameObject.FindGameObjectWithTag("RingFinger4");

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void CloseFinger()
    {
        if (degree < 15)
        {
            RingFinger1.transform.Rotate(Vector3.up, Time.deltaTime * 10);
            if (degree < 5) RingFinger1.transform.Rotate(Vector3.right, Time.deltaTime * 10);
            degree += Time.deltaTime * 10;
        }
        if (degree >= 15 && degree < 120)
        {
            RingFinger2.transform.Rotate(Vector3.up, Time.deltaTime * 10);
            if (degree < 20) RingFinger2.transform.Rotate(Vector3.right, Time.deltaTime * 10);
            degree += Time.deltaTime * 10;
        }
        if (degree >= 120 && degree < 180)
        {
            RingFinger3.transform.Rotate(Vector3.up, Time.deltaTime * 10);
            if (degree < 80) RingFinger3.transform.Rotate(Vector3.right, Time.deltaTime * 10);
            degree += Time.deltaTime * 10;
        }
        if (degree >= 180 && degree < 240)
        {
            RingFinger4.transform.Rotate(Vector3.up, Time.deltaTime * 10);
            if (degree < 125) RingFinger4.transform.Rotate(Vector3.right, Time.deltaTime * 10);
            degree += Time.deltaTime * 10;
        }
    }

    public void OpenFinger()
    {
        if (degree > 0 && degree <= 15)
        {
            RingFinger1.transform.Rotate(Vector3.down, Time.deltaTime * 10);
            if (degree < 5) RingFinger1.transform.Rotate(Vector3.left, Time.deltaTime * 10);
            degree -= Time.deltaTime * 10;
        }
        if (degree > 15 && degree <= 120)
        {
            RingFinger2.transform.Rotate(Vector3.down, Time.deltaTime * 10);
            if (degree < 20) RingFinger2.transform.Rotate(Vector3.left, Time.deltaTime * 10);
            degree -= Time.deltaTime * 10;
        }
        if (degree > 120 && degree <= 180)
        {
            RingFinger3.transform.Rotate(Vector3.down, Time.deltaTime * 10);
            if (degree < 80) RingFinger3.transform.Rotate(Vector3.left, Time.deltaTime * 10);
            degree -= Time.deltaTime * 10;
        }
        if (degree > 180)
        {
            RingFinger4.transform.Rotate(Vector3.down, Time.deltaTime * 10);
            if (degree < 125) RingFinger4.transform.Rotate(Vector3.left, Time.deltaTime * 10);
            degree -= Time.deltaTime * 10;
        }
    }
}
