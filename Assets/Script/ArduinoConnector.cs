﻿/* ArduinoConnector by Alan Zucconi
 * http://www.alanzucconi.com/?p=2979
 */
using UnityEngine;
using System;
using System.Collections;
using System.IO.Ports;

public class ArduinoConnector {

    /* The serial port where the Arduino is connected. */
    [Tooltip("The serial port where the Arduino is connected")]
    public string port = SerialPort.GetPortNames()[0];
    /* The baudrate of the serial port. */
    [Tooltip("The baudrate of the serial port")]
	public int baudrate = 115200;

    private SerialPort stream;

    public void Open () {
        // Opens the serial port
        stream = new SerialPort(port, baudrate);
        stream.ReadTimeout = 50;
        stream.Open();
        //this.stream.DataReceived += new SerialDataReceivedEventHandler(DataReceivedHandler);
    }

	public void WriteToArduino(byte[] buffer, int offset, int count)
    {
		// Send the request
		stream.Write(buffer, offset, count);
        stream.BaseStream.Flush();
    }

    /*
     * Fingers Binding :
     * 8 : Thumb
     * 2 : Index
     * 3 : MiddleFinger
     * 4 : RingFinger
     * 5 : Auriculaire
     */

    public void MoveFinger(byte fingerMask, int degree)
    {

  
        byte[] buffer = new byte[4];
        buffer[0] = 254;
        buffer[1] = fingerMask;
        buffer[2] = (byte) degree;
        buffer[3] = 255;

        Debug.Log("Message : /n Start:" + buffer[0] + "/n Mask:" + buffer[1] + "/n Degree:" + buffer[2] + "/n End:" + buffer[3]);
        stream.Write(buffer, 0, buffer.Length);
        //stream.BaseStream.Flush();
    }

    public string ReadFromArduino(int timeout = 0)
    {
        stream.ReadTimeout = timeout;
        try
        {
            return stream.ReadLine();
        }
        catch (TimeoutException)
        {
            return null;
        }
    }


    public IEnumerator AsynchronousReadFromArduino(Action<string> callback, Action fail = null, float timeout = float.PositiveInfinity)
    {
        DateTime initialTime = DateTime.Now;
        DateTime nowTime;
        TimeSpan diff = default(TimeSpan);

        string dataString = null;

        do
        {
            // A single read attempt
            try
            {
                dataString = stream.ReadLine();
            }
            catch (TimeoutException)
            {
                dataString = null;
            }

            if (dataString != null)
            {
                callback(dataString);
                yield return null;
            } else
                yield return new WaitForSeconds(0.05f);

            nowTime = DateTime.Now;
            diff = nowTime - initialTime;

        } while (diff.Milliseconds < timeout);

        if (fail != null)
            fail();
        yield return null;
    }

    public void Close()
    {
        stream.Close();
    }
}
