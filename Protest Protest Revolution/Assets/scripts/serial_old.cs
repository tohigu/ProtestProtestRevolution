using UnityEngine;
using System.Collections;
using System.IO;
using System.IO.Ports;
using System.Threading;
using System.Collections.Generic;

public class serial : MonoBehaviour
{
	public bool umbrella = false;

	//public string portName = "/dev/cu.usbserial-A603H3P3";
	public SerialPort serialPort = new SerialPort("/dev/cu.usbserial-A603H3P3", 9600, Parity.None, 8, StopBits.One);
	public static string strIn;
	
	void Start()
	{
		GetPortNames();
		OpenConnection();
	}
	
	void Update()
	{
		// debug: turn on/off icons
		if (umbrella) {
			GameObject.Find ("umbrella").GetComponent<Renderer>().enabled = true;
		} else {
			GameObject.Find ("umbrella").GetComponent<Renderer>().enabled = false;
		}

		try {
			string data = serialPort.ReadLine();
			if(data.Contains("Umbrella opened")) {
				umbrella = true;
			} else {
			}
			Debug.Log(data);
		} catch {

		}
	}
	
	void GetPortNames()
	{
		int p = (int)System.Environment.OSVersion.Platform;
		List<string> serial_ports = new List<string>();
		
		if(p == 4 || p == 128 || p == 6)
		{
			string[] ttys = Directory.GetFiles("/dev/", "tty.*");
			foreach(string dev in ttys)
			{
				if (dev.StartsWith("/dev/tty.*"))
					serial_ports.Add(dev);
				Debug.Log (System.String.Format(dev));
			}
		}
	}
	
	public void OpenConnection()
	{
		if(serialPort != null)
		{
			if(serialPort.IsOpen)
			{
				serialPort.Close();
				Debug.Log("Closing port, because it was already open!");
			}
			else
			{
				serialPort.Open();
				serialPort.ReadTimeout = 10;
				Debug.Log("Port Opened!");
			}
		}
		else
		{
			if(serialPort.IsOpen)
			{
				print("Port is already open");
			}
			else
			{
				print("Port == null");
			}
		}
	}
	
	void OnApplicationQuit()
	{
		serialPort.Close();
		Debug.Log("Port closed!");
	}
	
}