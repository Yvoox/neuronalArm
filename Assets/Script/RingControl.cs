using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RingControl : MonoBehaviour {

    GameObject RingFinger1;
    GameObject RingFinger2;
    GameObject RingFinger3;
    float degree;


    // Use this for initialization
    void Start()
    {
        degree = 0;
        RingFinger1 = GameObject.FindGameObjectWithTag("RingFinger1");
        RingFinger2 = GameObject.FindGameObjectWithTag("RingFinger2");
        RingFinger3 = GameObject.FindGameObjectWithTag("RingFinger3");

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void CloseFinger()
    {
        if (degree < 55)
        {
            RingFinger1.transform.Rotate(Vector3.up, Time.deltaTime * 10);
            degree += Time.deltaTime * 10;
        }
        if (degree >= 55 && degree < 110)
        {
            RingFinger2.transform.Rotate(Vector3.up, Time.deltaTime * 10);
            degree += Time.deltaTime * 10;
        }
        if (degree >= 110 && degree < 165)
        {
            RingFinger3.transform.Rotate(Vector3.up, Time.deltaTime * 10);
            degree += Time.deltaTime * 10;
        }

    }

    public void OpenFinger()
    {
        if (degree > 0 && degree <= 55)
        {
            RingFinger1.transform.Rotate(Vector3.down, Time.deltaTime * 10);
            degree -= Time.deltaTime * 10;
        }
        if (degree > 55 && degree <= 110)
        {
            RingFinger2.transform.Rotate(Vector3.down, Time.deltaTime * 10);
            degree -= Time.deltaTime * 10;
        }
        if (degree > 110)
        {
            RingFinger3.transform.Rotate(Vector3.down, Time.deltaTime * 10);
            degree -= Time.deltaTime * 10;
        }

    }
}
