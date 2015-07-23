using UnityEngine;
using System.Collections;
using System.IO;
using System.IO.Ports;
using System.Threading;
using System.Collections.Generic;

public class serialThread : MonoBehaviour
{
	//[SerializeField] private int comNumber = 2;
	public string portName = "/dev/cu.usbserial-A603H3P3";
	[SerializeField] private int baudRate = 9600;
	
	// In this example, we will just read a 0/1 from the Arduino serial stream
	private bool activated;
	
	// Here we can access the data we read from the Arduino in a threadsafe manner
	public bool Activated
	{
		get
		{
			lock (this)
			{
				return activated;
			}
		}
	}
	
	private SerialPort stream;
	private Thread thread;
	
	private void Awake()
	{
		//Debug.Log(SerialPort.GetPortNames().ToOneLineString());
		
		// Connect to the serial stream of your arduino
		stream = new SerialPort(portName, baudRate);
		
		// Create the thread so we can read data continuously
		thread = new Thread(ReadDataThread);
	}
	
	private void OnEnable()
	{
		// Object starts? Open stream, start thread
		stream.Open();
		thread.Start();
	}
	
	private void OnDisable()
	{
		// Object is deactivated/destroyed? Close stream, abort thread
		stream.Close();
		thread.Abort();
	}
	
	private void ReadDataThread()
	{
		// Repeat until aborting the thread
		while (true)
		{
			// Locking so that data will not be changed while we read it (see above)
			// This is more important when we have more than one field to read
			lock (this)
			{
				// Get the next line
				string line = stream.ReadLine();

				if(line.Contains("Photo taken")) {
					Debug.Log("!");
				}
				if(line.Contains("Umbrella opened")) {
					Debug.Log("!");
				}
				if(line.Contains("Pot banged")) {
					Debug.Log("!");
				}
				if(line.Contains("Paint sprayed")) {
					Debug.Log("!");
				}

				Debug.Log(line);
			}
		}
	}
}