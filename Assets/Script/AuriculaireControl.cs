using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AuriculaireControl : MonoBehaviour {

    GameObject Auriculaire1;
    GameObject Auriculaire2;
    GameObject Auriculaire3;
    GameObject Auriculaire4;
    float degree;


    // Use this for initialization
    void Start()
    {
        degree = 0;
        Auriculaire1 = GameObject.FindGameObjectWithTag("Auriculaire1");
        Auriculaire2 = GameObject.FindGameObjectWithTag("Auriculaire2");
        Auriculaire3 = GameObject.FindGameObjectWithTag("Auriculaire3");
        Auriculaire4 = GameObject.FindGameObjectWithTag("Auriculaire4");

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void CloseFinger(){
        if (degree < 15){
            Auriculaire1.transform.Rotate(Vector3.up, Time.deltaTime * 10);
            if (degree < 5)  Auriculaire1.transform.Rotate(Vector3.right, Time.deltaTime * 10);
            degree += Time.deltaTime * 10;
        }
        if (degree >= 15 && degree < 100) 
        {
            Auriculaire2.transform.Rotate(Vector3.up, Time.deltaTime * 10);
            if (degree < 20) Auriculaire2.transform.Rotate(Vector3.right, Time.deltaTime * 10);
            degree += Time.deltaTime * 10;
        }
        if (degree >= 100 && degree < 160)
        {
            Auriculaire3.transform.Rotate(Vector3.up, Time.deltaTime * 10);
            if (degree < 80) Auriculaire3.transform.Rotate(Vector3.right, Time.deltaTime * 10);
            degree += Time.deltaTime * 10;
        }
        if (degree >= 160 && degree < 220)
        {
            Auriculaire4.transform.Rotate(Vector3.up, Time.deltaTime * 10);
            if (degree < 125) Auriculaire4.transform.Rotate(Vector3.right, Time.deltaTime * 10);
            degree += Time.deltaTime * 10;
        }
    }

    public void OpenFinger(){
        if (degree >0 && degree <= 15)
        {
            Auriculaire1.transform.Rotate(Vector3.down, Time.deltaTime * 10);
            if (degree < 5) Auriculaire1.transform.Rotate(Vector3.left, Time.deltaTime * 10);
            degree -= Time.deltaTime * 10;
        }
        if (degree > 15 && degree <= 100)
        {
            Auriculaire2.transform.Rotate(Vector3.down, Time.deltaTime * 10);
            if (degree < 20) Auriculaire2.transform.Rotate(Vector3.left, Time.deltaTime * 10);
            degree -= Time.deltaTime * 10;
        }
        if (degree > 100 && degree <= 160)
        {
            Auriculaire3.transform.Rotate(Vector3.down, Time.deltaTime * 10);
            if (degree < 80) Auriculaire3.transform.Rotate(Vector3.left, Time.deltaTime * 10);
            degree -= Time.deltaTime * 10;
        }
        if (degree > 160)
        {
            Auriculaire4.transform.Rotate(Vector3.down, Time.deltaTime * 10);
            if (degree < 125) Auriculaire4.transform.Rotate(Vector3.left, Time.deltaTime * 10);
            degree -= Time.deltaTime * 10;
        }
    }
}
