using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using spnavwrapper;

public class ManualControl : MonoBehaviour {
    GameObject arm;

    WristControl wrist;
    AuriculaireControl auriculaire;
    RingControl ringFinger;
    MiddleControl middleFinger;
    IndexControl index;
    ThumbControl thumb;
    ArduinoConnector connector;

    int tempFingerDegree;

    List<Finger> fingers;

    public static float time;

    private void Awake()
    {
        SpaceNav.Instance.Sensitivity = 0.05;
        SpaceNav.Instance.Threshold = 5;
    }

    private void OnApplicationQuit()
    {
        SpaceNav.Instance.CloseDevice();
        StopCoroutine("DoWaitEvent");
        StopCoroutine("ArduinoEvent");
        // Reset position of robotic arm
        fingers.Clear();
        fingers.Add(auriculaire);
        fingers.Add(ringFinger);
        fingers.Add(middleFinger);
        fingers.Add(index);
        fingers.Add(thumb);

    /*    foreach(var finger in fingers)
        {
            connector.MoveFinger(finger.Key, 120);
        }*/

        byte fingersMask = 0;
        foreach (var finger in fingers)
        {
            fingersMask |= finger.mask;
            //connector.MoveFinger(finger.Key, (int)finger.Value.degree);
        }

        connector.MoveFinger(fingersMask, 120);
        connector.Close();

    }

    // Use this for initialization
    void Start () {
        arm = GetComponent<GameObject>();

        wrist = GameObject.FindObjectOfType(typeof(WristControl)) as WristControl;
        auriculaire = GameObject.FindObjectOfType(typeof(AuriculaireControl)) as AuriculaireControl;
        ringFinger = GameObject.FindObjectOfType(typeof(RingControl)) as RingControl;
        middleFinger = GameObject.FindObjectOfType(typeof(MiddleControl)) as MiddleControl;
        index = GameObject.FindObjectOfType(typeof(IndexControl)) as IndexControl;
        thumb = GameObject.FindObjectOfType(typeof(ThumbControl)) as ThumbControl;

        fingers = new List<Finger>();
        fingers.Add(auriculaire);
        fingers.Add(ringFinger);
        fingers.Add(middleFinger);
        fingers.Add(index);
        fingers.Add(thumb);

        tempFingerDegree = 255;

        connector = new ArduinoConnector();
        Debug.Log(connector.port);
		connector.Open();


        connector.MoveFinger(31, 90);
        StartCoroutine(ArduinoEvent());
    }

	// Update is called once per frame
    void Update () {

        time = Time.deltaTime * 50;
        if (Input.GetKey(KeyCode.Z))
            wrist.UpWrist();
        if (Input.GetKey(KeyCode.S))
            wrist.DownWrist();
        if (Input.GetKey(KeyCode.Q))
            wrist.LeftWrist();
        if (Input.GetKey(KeyCode.D))
            wrist.RightWrist();
        if (Input.GetKey(KeyCode.DownArrow)){
            //closeHand();
            foreach(var finger in fingers){
                finger.CloseFinger();
            }
        }
        if (Input.GetKey(KeyCode.UpArrow)){
            //openHand();
            foreach (var finger in fingers)
            {
                finger.OpenFinger();
            }
        }

        if (Input.GetKey(KeyCode.Keypad1))
        {
            fingers.Clear();
            fingers.Add(thumb);
        }
        if (Input.GetKey(KeyCode.Keypad2))
        {
            fingers.Clear();
            fingers.Add(index);
        }
        if (Input.GetKey(KeyCode.Keypad3))
        {
            fingers.Clear();
            fingers.Add(middleFinger);
        }
        if (Input.GetKey(KeyCode.Keypad4))
        {
            fingers.Clear();
            fingers.Add(ringFinger);
        }
        if (Input.GetKey(KeyCode.Keypad5))
        {
            fingers.Clear();
            fingers.Add(auriculaire);
        }
        if (Input.GetKey(KeyCode.Keypad6))
        {
            fingers.Clear();
            fingers.Add(thumb);
            fingers.Add(index);
            fingers.Add(middleFinger);
            fingers.Add(ringFinger);
            fingers.Add(auriculaire);
        }




        StartCoroutine(DoWaitEvent((ev => {
            if (ev != null)
            {
                if (ev is SpaceNavMotionEvent)
                {
                    var e = (SpaceNavMotionEvent)ev;
                    Debug.Log(e.Axis);
                    switch (e.Axis)
                    {
                        case SpaceNavAxis.X:
                            if (e.Direction == SpaceNavDirection.POSITIVE)
                            {
                                wrist.RightWrist();
                            }
                            else
                            {
                                wrist.LeftWrist();
                            }
                            break;
                        case SpaceNavAxis.Y:
                            break;
                        case SpaceNavAxis.Z:
                            break;
                        case SpaceNavAxis.RX:
                            if (e.Direction == SpaceNavDirection.POSITIVE)
                            {
                                closeHand();
                            }
                            else
                            {
                                openHand();
                            }
                            break;
                        case SpaceNavAxis.RY:
                            break;
                        case SpaceNavAxis.RZ:
                            if (e.Direction == SpaceNavDirection.POSITIVE)
                            {
                                wrist.UpWrist();
                            }
                            else
                            {
                                wrist.DownWrist();
                            }
                            break;
                    }
                }
                else if (ev is SpaceNavButtonEvent)
                {
                    InitialPosition();
                }
            }
        })));

        /*  int angle = (int) ringFinger.degree;
          byte[] buff = new byte[1];
          buff[0] = (byte) angle;
          connector.WriteToArduino(buff,0,1);
          Debug.Log(buff[0]);*/




    }

    public void closeHand()
    {
        auriculaire.CloseFinger();
        ringFinger.CloseFinger();
        middleFinger.CloseFinger();
        index.CloseFinger();
        thumb.CloseFinger();
    }

    public void openHand()
    {
        auriculaire.OpenFinger();
        ringFinger.OpenFinger();
        middleFinger.OpenFinger();
        index.OpenFinger();
        thumb.OpenFinger();
    }

    public void rotateWrist()
    {
        wrist.RightWrist();
    }

    public void upWrist()
    {
        wrist.UpWrist();
    }

    public void centerWrist()
    {
        wrist.LeftWrist();
    }

    IEnumerator DoWaitEvent(System.Action<SpaceNavEvent> callback)
    {
        var ev = SpaceNav.Instance.WaitEvent(10);
        yield return null; // wait until next frame
        if (ev != null) callback(ev);
    }

    IEnumerator ArduinoEvent()
    {
        while (true)
        {
            byte fingersMask = 0;
            foreach (var finger in fingers)
            {
                fingersMask |= finger.mask;
                //connector.MoveFinger(finger.Key, (int)finger.Value.degree);
            }


            //  Debug.Log(fingersMask);
            //  Debug.Log((int)fingers[0].degree);
            if ((int)fingers[0].degree != tempFingerDegree)
            {
                connector.MoveFinger(fingersMask, (int)fingers[0].degree);
            }

            tempFingerDegree = (int)fingers[0].degree;

            yield return new WaitForSeconds(0.2f);
            // wait until next frame
        }
    }

    public void InitialPosition()
    {
        Application.LoadLevel(Application.loadedLevel);
    }
}


