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

    Dictionary<int,Finger> fingers;

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
        // Reset position of robotic arm
        byte[] buff = new byte[]{66};
    	connector.WriteToArduino(buff, 0, 1);
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

        fingers = new Dictionary<int,Finger>();
        fingers.Add(5,auriculaire);
        fingers.Add(4,ringFinger);
        fingers.Add(3,middleFinger);
        fingers.Add(2,index);
        fingers.Add(1,thumb);

        connector = new ArduinoConnector();
        Debug.Log(connector.port);
		connector.Open();
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
            foreach(var finger in fingers.Values){
                finger.CloseFinger();
            }
        }
        if (Input.GetKey(KeyCode.UpArrow)){
            //openHand();
            foreach (var finger in fingers.Values)
            {
                finger.OpenFinger();
            }
        }

        if (Input.GetKey(KeyCode.Keypad1))
        {
            fingers.Clear();
            fingers.Add(1,thumb);
        }
        if (Input.GetKey(KeyCode.Keypad2))
        {
            fingers.Clear();
            fingers.Add(2,index);
        }
        if (Input.GetKey(KeyCode.Keypad3))
        {
            fingers.Clear();
            fingers.Add(3,middleFinger);
        }
        if (Input.GetKey(KeyCode.Keypad4))
        {
            fingers.Clear();
            fingers.Add(4,ringFinger);
        }
        if (Input.GetKey(KeyCode.Keypad5))
        {
            fingers.Clear();
            fingers.Add(5,auriculaire);
        }
        if (Input.GetKey(KeyCode.Keypad6))
        {
            fingers.Clear();
            fingers.Add(1,thumb);
            fingers.Add(2,index);
            fingers.Add(3,middleFinger);
            fingers.Add(4,ringFinger);
            fingers.Add(5,auriculaire);
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

        foreach(var finger in fingers)
        {
            connector.MoveFinger(finger.Key, (int) finger.Value.degree);
        }
        
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

    public void InitialPosition()
    {
        Application.LoadLevel(Application.loadedLevel);
    }
}


