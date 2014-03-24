namespace Sample_MVC
{
    partial class View
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.Connect_btn = new System.Windows.Forms.Button();
            this.Send_btn = new System.Windows.Forms.Button();
            this.Send_Box = new System.Windows.Forms.TextBox();
            this.Msg = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.ServerIP = new System.Windows.Forms.TextBox();
            this.ServerPort = new System.Windows.Forms.TextBox();
            this.label32 = new System.Windows.Forms.Label();
            this.PortLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // Connect_btn
            // 
            this.Connect_btn.Location = new System.Drawing.Point(215, 37);
            this.Connect_btn.Name = "Connect_btn";
            this.Connect_btn.Size = new System.Drawing.Size(77, 29);
            this.Connect_btn.TabIndex = 0;
            this.Connect_btn.Text = "Connect";
            this.Connect_btn.UseVisualStyleBackColor = true;
            // 
            // Send_btn
            // 
            this.Send_btn.Location = new System.Drawing.Point(44, 158);
            this.Send_btn.Name = "Send_btn";
            this.Send_btn.Size = new System.Drawing.Size(90, 28);
            this.Send_btn.TabIndex = 1;
            this.Send_btn.Text = "Send";
            this.Send_btn.UseVisualStyleBackColor = true;
            // 
            // Send_Box
            // 
            this.Send_Box.Location = new System.Drawing.Point(44, 113);
            this.Send_Box.Name = "Send_Box";
            this.Send_Box.Size = new System.Drawing.Size(214, 20);
            this.Send_Box.TabIndex = 2;
            // 
            // Msg
            // 
            this.Msg.AutoSize = true;
            this.Msg.Location = new System.Drawing.Point(40, 218);
            this.Msg.Name = "Msg";
            this.Msg.Size = new System.Drawing.Size(54, 13);
            this.Msg.TabIndex = 4;
            this.Msg.Text = "Lable Box";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(40, 97);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Text Box";
            // 
            // ServerIP
            // 
            this.ServerIP.Location = new System.Drawing.Point(125, 42);
            this.ServerIP.Name = "ServerIP";
            this.ServerIP.Size = new System.Drawing.Size(69, 20);
            this.ServerIP.TabIndex = 14;
            this.ServerIP.Text = "127.0.0.1";
            // 
            // ServerPort
            // 
            this.ServerPort.AcceptsReturn = true;
            this.ServerPort.Location = new System.Drawing.Point(125, 15);
            this.ServerPort.Name = "ServerPort";
            this.ServerPort.Size = new System.Drawing.Size(40, 20);
            this.ServerPort.TabIndex = 15;
            this.ServerPort.Text = "3000";
            // 
            // label32
            // 
            this.label32.AutoSize = true;
            this.label32.BackColor = System.Drawing.Color.Transparent;
            this.label32.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label32.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label32.Location = new System.Drawing.Point(10, 45);
            this.label32.Name = "label32";
            this.label32.Size = new System.Drawing.Size(114, 16);
            this.label32.TabIndex = 12;
            this.label32.Text = "Server IP address:";
            // 
            // PortLabel
            // 
            this.PortLabel.AutoSize = true;
            this.PortLabel.BackColor = System.Drawing.Color.Transparent;
            this.PortLabel.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PortLabel.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.PortLabel.Location = new System.Drawing.Point(10, 15);
            this.PortLabel.Name = "PortLabel";
            this.PortLabel.Size = new System.Drawing.Size(103, 16);
            this.PortLabel.TabIndex = 13;
            this.PortLabel.Text = "Connect to Port:";
            // 
            // View
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(302, 351);
            this.Controls.Add(this.ServerIP);
            this.Controls.Add(this.ServerPort);
            this.Controls.Add(this.label32);
            this.Controls.Add(this.PortLabel);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Msg);
            this.Controls.Add(this.Send_Box);
            this.Controls.Add(this.Send_btn);
            this.Controls.Add(this.Connect_btn);
            this.Name = "View";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Connect_btn;
        private System.Windows.Forms.Button Send_btn;
        private System.Windows.Forms.TextBox Send_Box;
        private System.Windows.Forms.Label Msg;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox ServerIP;
        private System.Windows.Forms.TextBox ServerPort;
        private System.Windows.Forms.Label label32;
        private System.Windows.Forms.Label PortLabel;
    }
}

