using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IndexControl : MonoBehaviour
{

    GameObject Index1;
    GameObject Index2;
    GameObject Index3;
    float degree;


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

    public void CloseFinger()
    {
        if (degree < 90)
        {
            Index1.transform.Rotate(Vector3.up, Time.deltaTime * 10);
           if (degree < 15) Index1.transform.Rotate(Vector3.right, Time.deltaTime * 10);
            degree += Time.deltaTime * 10;
        }
        if (degree >= 90 && degree < 150)
        {
            Index2.transform.Rotate(Vector3.up, Time.deltaTime * 10);
            degree += Time.deltaTime * 10;
        }
        if (degree >= 150 && degree < 210)
        {
            Index3.transform.Rotate(Vector3.up, Time.deltaTime * 10);
            degree += Time.deltaTime * 10;
        }

    }

    public void OpenFinger()
    {
        if (degree > 0 && degree <= 90)
        {
            Index1.transform.Rotate(Vector3.down, Time.deltaTime * 10);
            if (degree < 15) Index1.transform.Rotate(Vector3.left, Time.deltaTime * 10);
            degree -= Time.deltaTime * 10;
        }
        if (degree > 90 && degree <= 150)
        {
            Index2.transform.Rotate(Vector3.down, Time.deltaTime * 10);
            degree -= Time.deltaTime * 10;
        }
        if (degree > 150)
        {
            Index3.transform.Rotate(Vector3.down, Time.deltaTime * 10);
            degree -= Time.deltaTime * 10;
        }

    }
}