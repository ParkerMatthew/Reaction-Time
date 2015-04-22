using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.IO.Ports;
using System.IO;
//using System.Windows.Forms; //for debug windows

namespace Arduino_Project
{
    public class ArduinoController {
	private SerialPort currentPort;
    public SerialPort comPort;
	public bool portFound;
	public string[] SetComPort()
	{
	try
	{
		string[] ports = SerialPort.GetPortNames();
		foreach (string port in ports)
		{
		    currentPort = new SerialPort(port, 9600);
            portFound = DetectArduino();
		}
        return ports;
	}
	catch (Exception e)
	{
        return null;
    }
        
	}
    public int ArduinoStart()
    {
        return WriteToPort(16, 127, 0, 1, 4);
    }
    public int ArduinoStop()
    {
        return WriteToPort(16, 127, 1, 1, 4);
    }
    public int ArduinoSetTimeMin(uint n)
    {
        return WriteToPort(16, 127, 201, n, 4);
    }
    public int ArduinoSetTimeMax(uint n)
    {
        return WriteToPort(16, 127, 202, n, 4);
    }
    public int ArduinoSetTestCount(uint n)
    {
        return WriteToPort(16, 127, 200, n, 4);
    }
    public int WriteToPort(uint b0, uint b1, uint b2, uint b3, uint b4)
    {
        if (portFound && b0==16 && b4==4)
            currentPort = comPort;
        else
            return -1;
        byte[] buffer = new byte[5];
        buffer[0] = Convert.ToByte(b0);
        buffer[1] = Convert.ToByte(b1);
        buffer[2] = Convert.ToByte(b2);
        buffer[3] = Convert.ToByte(b3);
        buffer[4] = Convert.ToByte(b4);

        int intReturnASCII = 0;
        char charReturnValue = (Char)intReturnASCII;
        currentPort.Write(buffer, 0, 5);
        Thread.Sleep(1000);
        return intReturnASCII;
    }
	private bool DetectArduino()
	{
	    try
	    {
		//The below setting are for the Hello handshake
        byte[] buffer = new byte[5];
        buffer[0] = Convert.ToByte(16);
        buffer[1] = Convert.ToByte(128);
        buffer[2] = Convert.ToByte(0);
        buffer[3] = Convert.ToByte(0);
        buffer[4] = Convert.ToByte(4);

        int intReturnASCII = 0;
        char charReturnValue = (Char)intReturnASCII;

        currentPort.Open();
        currentPort.Write(buffer, 0, 5);
        Thread.Sleep(1000);
		int count = currentPort.BytesToRead;
		string returnMessage = "";
		while (count > 0)
		{
		    intReturnASCII = currentPort.ReadByte();
		    returnMessage = returnMessage + Convert.ToChar(intReturnASCII);
		    count--;
		}
		currentPort.Close();
        if (returnMessage.Contains("ARDUINO_IDENTIFY"))
		{
            comPort = currentPort;
		    return true;
		}
		else
		{
            comPort = null;
		    return false;
		}
	    }
	    catch (Exception e)
	    {
		return false;
	    }
      }

} 
}
