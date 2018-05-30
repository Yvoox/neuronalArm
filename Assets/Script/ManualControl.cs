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

        

        connector = new ArduinoConnector();
        Debug.Log(connector.port);
		connector.Open();
	}

	// Update is called once per frame
    void Update () {
        if (Input.GetKey(KeyCode.Z))
            wrist.UpWrist();
        if (Input.GetKey(KeyCode.S))
            wrist.DownWrist();
        if (Input.GetKey(KeyCode.Q))
            wrist.LeftWrist();
        if (Input.GetKey(KeyCode.D))
            wrist.RightWrist();
        if (Input.GetKey(KeyCode.DownArrow)){
            closeHand();
        }
        if (Input.GetKey(KeyCode.UpArrow)){
            openHand();
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

        int angle = (int) ringFinger.degree;
        byte[] buff = new byte[1];
        buff[0] = (byte) angle;
        connector.WriteToArduino(buff,0,1);
        Debug.Log(buff[0]);
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
        wrist.DownWrist();
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
