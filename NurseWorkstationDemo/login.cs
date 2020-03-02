using System;
using System.Windows.Forms;
using System.Drawing;
namespace NurseWorkstationDemo
{
    public class login:Form
    {
        public login(){
            InitializeComponent();
        
        }
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        private void InitializeComponent(){
            this.components = new System.ComponentModel.Container();
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Text = "登录";

            this.label1=new Label();      this.label2=new Label();
            this.button1=new Button();      this.button2=new Button();
            this.textBox1=new TextBox();    this.textBox2=new TextBox();
            this.label1.AutoSize = true;
            this.label1.Text="password: ";

            this.label1.Location=new Point(30,100);
            this.label1.Size=new Size(180,200);
            this.label1.Margin=new Padding(0);
            this.Controls.Add(this.label1);

            this.label2.Text="username: ";
            this.label2.AutoSize = true;
            this.label2.Location=new Point(30,40);
            this.label2.Size=new Size(180,200);
            this.label2.Margin=new Padding(0);
            this.Controls.Add(this.label2);

            this.button1.Text="Login";
            this.button1.Anchor=(AnchorStyles.Bottom | AnchorStyles.Right);
            this.button1.Location=new Point(400,180);
            this.button1.Size=new Size(150,50);
            this.button1.Click+=new EventHandler(btnLogin_Click);
            this.Controls.Add(this.button1);

            this.button2.Text="Reset";
            this.button2.Anchor=(AnchorStyles.Bottom | AnchorStyles.Right);
            this.button2.Location=new Point(400,100);
            this.button2.Size=new Size(150,40);
            this.button2.Click+=new EventHandler(btnReset_Click);
            this.Controls.Add(this.button2);

            this.textBox1.Text="";
            this.textBox1.Location=new Point(200,40);
            this.textBox1.Size=new Size(150,32);
            this.Controls.Add(this.textBox1);

            this.textBox2.Text="";
            this.textBox2.UseSystemPasswordChar=true;
            this.textBox2.Location=new Point(200,100);
            this.textBox2.Size=new Size(150,32);
            this.Controls.Add(this.textBox2);
           
        }
        protected void btnLogin_Click(object sender,EventArgs e){
            if(textBox1.Text=="user" && textBox2.Text=="123"){
                Form1 form1=new Form1();
                form1.Show();
                System.Threading.Thread.Sleep(1000);
            }else{
                MessageBox.Show("error!");
                }
        }
        protected void btnReset_Click(object sender,EventArgs e){
            foreach(Control item in this.Controls){
                if(item is TextBox){
                    item.Text="";
                }
            }
        }
      
        private Label label1;
        private Label label2;
        protected TextBox textBox1;
        protected TextBox textBox2;
        private Button button1;
        private Button button2; 
    }
}