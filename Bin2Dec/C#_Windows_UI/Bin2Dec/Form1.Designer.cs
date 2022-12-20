
namespace Bin2Dec
{
    partial class Form1
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
            this.components = new System.ComponentModel.Container();
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Text = "Form1";
            System.Windows.Forms.Label binLabel = new System.Windows.Forms.Label();
            binLabel.Text = "Binary Representation";
            binLabel.Location = new System.Drawing.Point(Top, Left);
            binLabel.Size = new System.Drawing.Size(100, 50);
            System.Windows.Forms.Label decLabel = new System.Windows.Forms.Label();
            decLabel.Location = new System.Drawing.Point(0, 60);
            decLabel.Size = new System.Drawing.Size(100, 50);
            decLabel.Text = "Decimal Representation";
            this.Controls.Add(binLabel);
            this.Controls.Add(decLabel);
            System.Windows.Forms.TextBox tboxBin = new System.Windows.Forms.TextBox();
            tboxBin.Name = "tboxBin";
            tboxBin.Location = new System.Drawing.Point(110, 0);
            tboxBin.Size = new System.Drawing.Size(500, 100);
            this.Controls.Add(tboxBin);
            System.Windows.Forms.TextBox tboxDec = new System.Windows.Forms.TextBox();
            tboxDec.Name = "tboxDec";
            tboxDec.Location = new System.Drawing.Point(110, 60);
            tboxDec.Size = new System.Drawing.Size(500, 100);
            this.Controls.Add(tboxDec);
            System.Windows.Forms.Button button = new System.Windows.Forms.Button();
            button.Text = "Convert";
            button.Location = new System.Drawing.Point(110, 110);
            button.Size = new System.Drawing.Size(100, 30);
            button.Click += Button_Click;
            this.Controls.Add(button);
            System.Windows.Forms.Button button1 = new System.Windows.Forms.Button();
            button1.Text = "Clear";
            button1.Location = new System.Drawing.Point(210, 110);
            button1.Size = new System.Drawing.Size(100, 30);
            button1.Click += Button1_Click;
            this.Controls.Add(button1);
        }

        private void Button1_Click(object sender, System.EventArgs e)
        {
            System.Windows.Forms.TextBox tb1 = (System.Windows.Forms.TextBox)this.Controls.Find("tboxBin", true)[0];
            System.Windows.Forms.TextBox tb2 = (System.Windows.Forms.TextBox)this.Controls.Find("tboxDec", true)[0];
            tb1.Text = "";
            tb2.Text = "";
        }

        private void Button_Click(object sender, System.EventArgs e)
        {
            //this.Hide();
            System.Windows.Forms.TextBox tb1 = (System.Windows.Forms.TextBox)this.Controls.Find("tboxBin", true)[0];
            System.Windows.Forms.TextBox tb2 = (System.Windows.Forms.TextBox)this.Controls.Find("tboxDec", true)[0];
            if(tb1.Text == "")
            {
                int dec;
                var parsed = int.TryParse(tb2.Text, out dec);
                string tempRet = "";
                while (dec != 0)
                {
                    tempRet += (char)((dec & 0x01) + '0');
                    dec = dec >> 1;
                }
                string ret = "";
                for(int i = tempRet.Length - 1; i >= 0; i--)
                {
                    ret += tempRet[i];
                }
                tb1.Text = ret;
            }else if(tb2.Text == "")
            {
                int ret = 0;
                string input = tb1.Text;
                if(input.Length > 32)
                {
                    tb1.Text = "Invalid";
                    tb2.Text = "Invalid";
                }
                else
                {
                    for (int i = 0; i < input.Length; i++)
                    {
                        ret = (ret * 2) + (input[i] - '0');
                    }
                    tb2.Text = ret.ToString();
                }
            }else
            {
                tb1.Text = "Invalid";
                tb2.Text = "Invalid";
            }
        }

        #endregion
    }
}

