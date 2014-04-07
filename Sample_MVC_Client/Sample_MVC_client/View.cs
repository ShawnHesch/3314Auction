using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
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

        string[] item1, item2, item3, item4;
        DateTime end1, end2, end3, end4;
        decimal item1bid, item2bid, item3bid, item4bid;

        public View()
        {
            InitializeComponent();

            my_controller = new Controller();
            this.Connect_btn.Click += new System.EventHandler(my_controller.Connect_btn_Click);
            //this.Send_btn.Click += new System.EventHandler(my_controller.Send_btn_Click);
            this.Closed += new System.EventHandler(my_controller.ShutDown);

        }


        //public String GetMsg()
        //{
        //    return this.Send_Box.Text.ToString();
        //}


        // we will use our delegate to create a refrence to this method  
        //public void add_text(String _msg)
        //{
        //    this.Msg.Text = "Server said --> " + _msg;
        //}

        //public void SetInfoBox(String _msg)
        //{
        //    string text = _msg;
        //    SetInfoCallback d = new SetInfoCallback(add_text);
        //    this.Invoke(d, new object[] { text });
        //}

        public String GetServerIP()
        {
            return this.ServerIP.Text.ToString();
        }

        public void LoginVisable()
        {
            this.lgnbtn.Visible = true;
            this.lgntxt.Visible = true;
            this.usernamelbl.Visible = true;
            this.Connect_btn.Enabled = false;
        }

        public int GetServerPort()
        {
            return Int32.Parse(this.ServerPort.Text);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            this.label4.Text = DateTime.Now.ToString();
            if (end1!= new DateTime())
            {
                if (DateTime.Compare(DateTime.Now, end1) > 0)//auction one is done
                {
                    this.bidbtn1.Enabled = false;
                    this.message1.Text = "The auction has ended!";
                }
                if (DateTime.Compare(DateTime.Now, end2) > 0)//auction one is done
                {
                    this.bidbtn2.Enabled = false;
                    this.message2.Text = "The auction has ended!";
                }
                if (DateTime.Compare(DateTime.Now, end3) > 0)//auction one is done
                {
                    this.bidbtn3.Enabled = false;
                    this.message3.Text = "The auction has ended!";
                }
                if (DateTime.Compare(DateTime.Now, end4) > 0)//auction one is done
                {
                    this.bidbtn4.Enabled = false;
                    this.message4.Text = "The auction has ended!";
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            my_controller.ShutDown(sender, e);
            this.Close();
        }

        private void lgnbtn_Click(object sender, EventArgs e)
        {
            this.lgnbtn.Enabled = false;
            my_controller.SendLogin(this.lgntxt.Text, sender);
        }

        public void CreateItems(string[] items){
            this.panel1.Visible = true;
            this.panel2.Visible = true;
            this.panel3.Visible = true;
            this.panel4.Visible = true;
            //populate first panel
            item1 = items[0].Split('~');
            item2 = items[1].Split('~');
            item3 = items[2].Split('~');
            item4 = items[3].Split('~');

            this.desc1.Text = item1[3];//find desc in string
            end1 = DateTime.Parse(item1[2], new CultureInfo("en-US"));
            this.close1.Text = "Closing Time: " + end1.ToString();
            item1bid = Convert.ToDecimal(item1[1]);
            this.current1.Text = "Current Bid: " + item1bid.ToString();
            this.message1.Text = "Enter a higher value and press enter";

            this.desc2.Text = item2[3];//find desc in string
            end2 = DateTime.Parse(item2[2], new CultureInfo("en-US"));
            this.close2.Text = "Closing Time: " + end2.ToString();
            item2bid = Convert.ToDecimal(item2[1]);
            this.current2.Text = "Current Bid: " + item2bid.ToString();
            this.message2.Text = "Enter a higher value and press enter";

            this.desc3.Text = item3[3];//find desc in string
            end3 = DateTime.Parse(item3[2], new CultureInfo("en-US"));
            this.close3.Text = "Closing Time: " + end3.ToString();
            item3bid = Convert.ToDecimal(item3[1]);
            this.current3.Text = "Current Bid: " + item3bid.ToString();
            this.message3.Text = "Enter a higher value and press enter";

            this.desc4.Text = item4[3];//find desc in string
            end4 = DateTime.Parse(item4[2], new CultureInfo("en-US"));
            this.close4.Text = "Closing Time: " + end4.ToString();
            item4bid = Convert.ToDecimal(item4[1]);
            this.current4.Text = "Current Bid: " + item4bid.ToString();
            this.message4.Text = "Enter a higher value and press enter";
        }

        private void bidbtn1_Click(object sender, EventArgs e)
        {
            decimal bid;
            if (bid1.TextLength < 1 || !decimal.TryParse(bid1.Text, out bid))
            {
                message1.Text = "Please enter a valid bid!";
            }
            else
            {
                bid = Math.Round(bid, 2);
                string message = my_controller.Bid(1, bid, lgntxt.Text);
                if (message.Equals("LEAD"))
                {
                    message1.Text = "You are the current leader!";
                    current1.Text = "Current Bid: " + bid1.Text;
                }
                else
                {
                    message1.Text = "Your bid was not high enough!";
                    current1.Text = "Current Bid: " + message.Substring(5);
                }
            }
        }

        private void bidbtn2_Click(object sender, EventArgs e)
        {
            decimal bid;
            if (bid2.TextLength < 1 || decimal.TryParse(bid2.Text, out bid))
            {
                message2.Text = "Please enter a valid bid!";
            }
            else
            {
                bid = Math.Round(bid, 2);
                string message = my_controller.Bid(2, bid, lgntxt.Text);
                if (message.Equals("LEAD"))
                {
                    message2.Text = "You are the current leader!";
                    current2.Text = "Current Bid: " + bid2.Text;
                }
                else
                {
                    message2.Text = "Your bid was not high enough!";
                    current2.Text = "Current Bid: " + message.Substring(5);
                }
            }
        }

        private void bidbtn3_Click(object sender, EventArgs e)
        {
            decimal bid;
            if (bid3.TextLength < 1 || decimal.TryParse(bid3.Text, out bid))
            {
                message3.Text = "Please enter a valid bid!";
            }
            else
            {
                bid = Math.Round(bid, 2);
                string message = my_controller.Bid(3, bid, lgntxt.Text);
                if (message.Equals("LEAD"))
                {
                    message3.Text = "You are the current leader!";
                    current3.Text = "Current Bid: " + bid3.Text;
                }
                else
                {
                    message3.Text = "Your bid was not high enough!";
                    current3.Text = "Current Bid: " + message.Substring(5);
                }
            }
        }

        private void bidbtn4_Click(object sender, EventArgs e)
        {
            decimal bid;
            if (bid4.TextLength < 1 || decimal.TryParse(bid4.Text, out bid))
            {
                message4.Text = "Please enter a valid bid!";
            }
            else
            {
                bid = Math.Round(bid, 2);
                string message = my_controller.Bid(4, bid, lgntxt.Text);
                if (message.Equals("LEAD"))
                {
                    message4.Text = "You are the current leader!";
                    current4.Text = "Current Bid: " + bid4.Text;
                }
                else
                {
                    message4.Text = "Your bid was not high enough!";
                    current4.Text = "Current Bid: " + message.Substring(5);
                }
            }
        }
    }
}
