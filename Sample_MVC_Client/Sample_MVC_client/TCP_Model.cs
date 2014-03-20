using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net.Sockets;
using System.Threading;
using System.Net;
using System.IO;

namespace Sample_MVC
{
    class TCP_Model
    {
        Socket TCPsocket; //socket used to send/receive TCP messages
        IPAddress ServerIPAddr = null;
        IPAddress ClientIPAddr = null;
        int TCP_PORT;


        public TCP_Model(string IP, int port)
        {
            //Establish a TCP connection with the server to exchange TCP messages
            //------------------
            TCPsocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            // Creating Endpoint 
            ServerIPAddr = IPAddress.Parse(IP);
            TCP_PORT = port;
            IPEndPoint TCP_serverEndPoint = new IPEndPoint(ServerIPAddr, TCP_PORT);

            // try to connect
            try
            {
                TCPsocket.Connect(TCP_serverEndPoint);
            }
            catch (Exception ex)
            {
                throw new Exception("Exception caught: " + ex);
            }

            ClientIPAddr = ((IPEndPoint)TCPsocket.LocalEndPoint).Address;

        }

        public void Send_to_TCP_server(String data)
        {
            try
            {
                byte[] byteData = Encoding.ASCII.GetBytes(data);
                TCPsocket.Send(byteData, 0, byteData.Length, SocketFlags.None);
            }
            catch (Exception e)
            {
                //throw new Exception("TCPsocket.Send : " + e.Message);
            }
        }

        public String Get_From_TCP_server()
        {
            try
            {
                byte[] buffer = new byte[2048];
                byte[] output;

                int byteRecv = TCPsocket.Receive(buffer, 0, buffer.Length, SocketFlags.None);

                byte[] receivedData = new byte[byteRecv];
                Array.Copy(buffer, receivedData, byteRecv);
                output = receivedData;

                return Encoding.ASCII.GetString(output);
            }
            catch (Exception e)
            {
                return null;
            }

        }

        public void shutdown()
        {
            TCPsocket.Close();
        }
    }
}
