using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net.Sockets;
using System.Threading;
using System.Net;

namespace Sample_MVC
{
    class Controller
    {
        private static View _view;
        private TCP_Model my_model;

        string[] items = new string[4];

        string ServerIP = null;
        int ServerPort = 0;

        public void Connect_btn_Click(object sender, EventArgs e)
        {
            try
            {
                // Deterime which view to control
                _view = (View)((Button)sender).FindForm();

                // Create a model to connect to the server
                ServerIP = _view.GetServerIP();
                ServerPort = _view.GetServerPort();
                my_model = new TCP_Model(ServerIP, ServerPort);
                _view.LoginVisable();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Make sure the server is up and listening\r\n and the server IP address and port number are correct\n\n" + ex.Message);
            }
        }

        //public void Send_btn_Click(object sender, EventArgs e)
        //{
        //    _view = (View)((Button)sender).FindForm();
        //    my_model.Send_to_TCP_server(_view.GetMsg());
        //    //_view.SetInfoBox(my_model.Get_From_TCP_server());
        //}

        public void SendLogin(string username, object sender)
        {
            // Deterime which view to control
            _view = (View)((Button)sender).FindForm();

            my_model.Send_to_TCP_server("OAP JOIN: ID=\"" + username + "\"");
            items[0] = my_model.Get_From_TCP_server();
            items[1] = my_model.Get_From_TCP_server();
            items[2] = my_model.Get_From_TCP_server();
            items[3] = my_model.Get_From_TCP_server();
            _view.CreateItems(items);
        }


        public void ShutDown(object sender, EventArgs e)
        {
            if (my_model != null)
            my_model.shutdown();
        }

        public string Bid(int item, decimal bid, string username)
        {
            string message;
            my_model.Send_to_TCP_server("OAP BID:Item=" + item + "User=" + username + "Bid=" + bid);
            message = my_model.Get_From_TCP_server();
            return message;
        }
    }
}
