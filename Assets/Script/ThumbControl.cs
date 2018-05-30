using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThumbControl : MonoBehaviour
{

    GameObject Thumb1;
    GameObject Thumb2;
    GameObject Thumb3;
    float degree;



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

    public void CloseFinger()
    {
        if (degree < 15)
        {
            Thumb1.transform.Rotate(Vector3.up, Time.deltaTime * 10);
            Thumb1.transform.Rotate(Vector3.right, Time.deltaTime * 10);
            degree += Time.deltaTime * 10;
        }
        if (degree >= 15 && degree < 110)
        {
            Thumb2.transform.Rotate(Vector3.up, Time.deltaTime * 10);
            degree += Time.deltaTime * 10;
        }
        if (degree >= 110 && degree < 190)
        {
            Thumb3.transform.Rotate(Vector3.up, Time.deltaTime * 10);
            degree += Time.deltaTime * 10;
        }

    }

    public void OpenFinger()
    {
        if (degree > 0 && degree <= 15)
        {
            Thumb1.transform.Rotate(Vector3.down, Time.deltaTime * 10);
            Thumb1.transform.Rotate(Vector3.left, Time.deltaTime * 10);
            degree -= Time.deltaTime * 10;
        }
        if (degree > 15 && degree <= 110)
        {
            Thumb2.transform.Rotate(Vector3.down, Time.deltaTime * 10);
            degree -= Time.deltaTime * 10;
        }
        if (degree > 110)
        {
            Thumb3.transform.Rotate(Vector3.down, Time.deltaTime * 10);
            degree -= Time.deltaTime * 10;
        }
    }

}
