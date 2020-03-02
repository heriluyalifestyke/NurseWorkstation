using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Threading;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NurseWorkstationDemo.DAO;
using NurseWorkstationDemo.PO;
using System.Resources;
namespace NurseWorkstationDemo
{
    public partial class Form1 : Form
    {
        private List<Patient> lPatient=new List<Patient>();
        private List<CommonGood> lComGood=new List<CommonGood>();
        private List<Room> lRoom=new List<Room>();
        public Form1()
        {
             InitializeComponent();
        }
        private void tabControl1_DrawItem(object sender, DrawItemEventArgs e)
        {
            Rectangle tabArea = this.tabControl.GetTabRect(e.Index);//主要是做个转换来获得TAB项的RECTANGELF
            RectangleF tabTextArea = (RectangleF)(this.tabControl.GetTabRect(e.Index));
            Graphics g = e.Graphics;
            StringFormat sf = new StringFormat();//封装文本布局信息
                sf.LineAlignment = StringAlignment.Center;
            sf.Alignment = StringAlignment.Near;
            Font font = this.tabControl.Font;
            SolidBrush brush = new SolidBrush(Color.Black);//绘制边框的画笔
                g.DrawString(((TabControl)(sender)).TabPages[e.Index].Text,
                 font, brush, tabTextArea, sf);
        }

        private void toolBar1_ButtonClick (Object sender,ToolBarButtonClickEventArgs e){
            switch(toolBar.Buttons.IndexOf(e.Button)){
                case 1:{System.Threading.Thread.Sleep(100);
                    this.tabPage2.Controls.Remove(this.cardView);
                CardView c=new CardView(0);
                    c.AutoSize=true;
                    this.tabPage2.Controls.Add(c);
                    this.Refresh();
                };
                break;}
        }
        private void btn_Save(object sender,EventArgs e){
            string s=RoomManager.ObejctStatus.INSERT.ToString();
            lPatient.Clear();
            if(this.dGV1.SelectedRows.Count!=0){
                foreach(DataGridViewRow row in this.dGV1.Rows){
                    Patient patient=new Patient();
                    patient.PatientName=Convert.ToString(row.Cells["患者姓名"].
                    Value.ToString());
                    patient.Age=Convert.ToUInt16(row.Cells["年龄"].
                    Value.ToString());
                   // if(column.Selected==true){
                    if(row.Cells[2].Selected==true&&row.Cells[2].Value.ToString()=="男"){
                    patient.Sex="男";
                    }
                    else    if(column.Selected!=true){patient.Sex="女";}
                    else{
                    this.components.Dispose();
                    break;}
                    patient.IdCard_Num=Convert.ToString(row.Cells["身份证号"].Value.ToString());
                    patient.In_HospitalNum=Convert.ToString(row.Cells["住院号"].Value.ToString());
                    patient.Major_Doctor=Convert.ToString(row.Cells["主管医师"].Value.ToString());
                    patient.Main_Symptom=Convert.ToString(row.Cells["主要症状"].Value.ToString());
                    patient.Phone_Num=Convert.ToString(row.Cells["电话号码"].Value.ToString());
                    patient.In_Date=Convert.ToDateTime(row.Cells["入院日期"].Value.ToString());
                    if(PatientManager.InsertIntoPatient(patient)==true){
                        MessageBox.Show("保存成功！");
                    }
                    lPatient.Append(patient);
                    
                }
            }

        }
        private void btn_Find(object sender,EventArgs e){
                if(this.search_Name.Text!=null){
                string s_name=this.search_Name.Text.ToString();
                Patient patient=new Patient();
                patient.PatientName=s_name;
                DataTable dt=PatientManager.GetPatientInfo_FromPatientName(patient);
                if(dt.Rows[0] is null){
                    MessageBox.Show("检索失败，请重试");
                }else{
                    for (int i=0;i<dt.Columns.Count;i++){
                    this.richTextBox.Text+=dt.Rows[0][i].ToString()+"  ";}
                    this.richTextBox.Text+="\n";
                }

                }else{
                    MessageBox.Show("查找病人姓名为空！");
                }

        }
        private void btn_Delete(object sender,EventArgs e){
            if(this.delete_Name.Text!=null){
                    string d_name=delete_Name.Text.ToString();
                    Patient p=new Patient();
                    p.PatientName=d_name;
                    if(PatientManager.DeletePatient(p)){
                        MessageBox.Show("患者  "+d_name+"已删除");
                    }else{
                        MessageBox.Show("操作失败");
                    }
            }else{
                MessageBox.Show("删除姓名为空！");
            }
        }
        private void btn_Update(object sender,EventArgs e){
        }
  /*      private void Panel_AddControl(object sender,ControlEventArgs e){
             this.panel.VerticalScroll.Enabled = true;
            this.panel.VerticalScroll.Visible = true;
            this.panel.VerticalScroll.Maximum=1300;
            this.panel.VerticalScroll.SmallChange=400;
            this.panel.Scroll+= new ScrollEventHandler(Panel_Scroll);
        }
        private void Panel_Scroll(object sender,ScrollEventArgs e){
            this.panel.VerticalScroll.Value=(e.NewValue+100);
            this.panel.Invalidate();
            this.panel.ResumeLayout(true);
        }*/
    }
}