using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiddleControl : MonoBehaviour
{

    GameObject MiddleFinger1;
    GameObject MiddleFinger2;
    GameObject MiddleFinger3;
    float degree;


    // Use this for initialization
    void Start()
    {
        degree = 0;
        MiddleFinger1 = GameObject.FindGameObjectWithTag("MiddleFinger1");
        MiddleFinger2 = GameObject.FindGameObjectWithTag("MiddleFinger2");
        MiddleFinger3 = GameObject.FindGameObjectWithTag("MiddleFinger3");

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void CloseFinger()
    {
        if (degree < 115)
        {
            MiddleFinger1.transform.Rotate(Vector3.up, Time.deltaTime * 10);
            if(degree < 15) MiddleFinger1.transform.Rotate(Vector3.right, Time.deltaTime * 10);
            degree += Time.deltaTime * 10;
        }
        if (degree >= 115 && degree < 175)
        {
            MiddleFinger2.transform.Rotate(Vector3.up, Time.deltaTime * 10);
            degree += Time.deltaTime * 10;
        }
        if (degree >= 175 && degree < 220)
        {
            MiddleFinger3.transform.Rotate(Vector3.up, Time.deltaTime * 10);
            degree += Time.deltaTime * 10;
        }

    }

    public void OpenFinger()
    {
        if (degree > 0 && degree <= 115)
        {
            MiddleFinger1.transform.Rotate(Vector3.down, Time.deltaTime * 10);
            if (degree < 15) MiddleFinger1.transform.Rotate(Vector3.left, Time.deltaTime * 10);
            degree -= Time.deltaTime * 10;
        }
        if (degree > 115 && degree <= 175)
        {
            MiddleFinger2.transform.Rotate(Vector3.down, Time.deltaTime * 10);
            degree -= Time.deltaTime * 10;
        }
        if (degree > 175)
        {
            MiddleFinger3.transform.Rotate(Vector3.down, Time.deltaTime * 10);
            degree -= Time.deltaTime * 10;
        }

    }
}