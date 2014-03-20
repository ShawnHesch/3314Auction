using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Sample_MVC
{
    public partial class View : Form
    {
        Controller my_controller = null;

        // This delegate enables asynchronous calls for setting
        // the text property on a Msg control from extrnal thread.
        delegate void SetInfoCallback(string info);


        public View()
        {
            InitializeComponent();

            my_controller = new Controller();
            this.Connect_btn.Click += new System.EventHandler(my_controller.Connect_btn_Click);
            this.Send_btn.Click += new System.EventHandler(my_controller.Send_btn_Click);
            this.Closed += new System.EventHandler(my_controller.ShutDown);
        }


        public String GetMsg()
        {
            return this.Send_Box.Text.ToString();
        }


        // we will use our delegate to create a refrence to this method  
        public void add_text(String _msg)
        {
            this.Msg.Text = "Server said --> " + _msg;
        }

        public void SetInfoBox(String _msg)
        {
            string text = _msg;
            SetInfoCallback d = new SetInfoCallback(add_text);
            this.Invoke(d, new object[] { text });
        }

        public String GetServerIP()
        {
            return this.ServerIP.Text.ToString();
        }

        public int GetServerPort()
        {
            return Int32.Parse(this.ServerPort.Text);
        }
    }
}
