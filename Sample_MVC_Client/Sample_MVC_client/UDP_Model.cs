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
    class UDP_Model
    {

        Socket UDPsocket; //UDP socket to be used to send and receive UDP packets

        public UDP_Model(IPAddress IP, int port)
        {
            //Create UDP socket  
            UDPsocket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
            // Creating client Endpoint and bound to UDP socket 
            UDPsocket.Bind(new IPEndPoint(IP, port));
        }

        /// Returns a UDP datagram that was sent by a remote host.
        public byte[] Receive(EndPoint EP)
        {
            byte[] data_in = new byte[200000];

            UDPsocket.ReceiveTimeout = 1000;
            try
            {
                //try to receive message
                UDPsocket.ReceiveFrom(data_in, ref EP);
            }
            catch 
            {
                data_in = null;
            }
            return data_in;
        }


        public void close()
        {
            try
            {
                UDPsocket.Close();
            }
            catch (Exception e)
            {
                //  throw new Exception(e.Message);
            }

        }

    }
}
