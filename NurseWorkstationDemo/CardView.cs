using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NurseWorkstationDemo.DAO;
using NurseWorkstationDemo.PO;
namespace NurseWorkstationDemo
{
    public class CardView:UserControl
    {
        private IContainer components=null;

        private string[] bed_Num=new string[20];
        private string[] sex=new string[20];
        private string[] patient_Name=new string[20];
        private string[] age=new string[20];
        private string[] payType=new string[20];
        private string[] inHospital_Num=new string[20];
        private string[] into_Date=new string[20];
        private string[] administratorOffice=new string[20];

        private Dictionary<int,Label> l_pName=new Dictionary<int, Label>();
        private Dictionary<int,Label> l_bNum=new Dictionary<int,Label>();
        private Dictionary<int,Label> l_sex=new Dictionary<int,Label>();
        private Dictionary<int,Label> l_age=new Dictionary<int,Label>();
        private Dictionary<int,Label> l_payType=new Dictionary<int,Label>();
        private Dictionary<int,Label> l_hNum=new Dictionary<int,Label>();
        private Dictionary<int,Label> l_inDate=new Dictionary<int,Label>();
        private Dictionary<int,PictureBox> pic=new Dictionary<int,PictureBox>();
        private Dictionary<int,ImageList> imageLists=new Dictionary<int,ImageList>();
        private Dictionary<int,Panel> panels=new Dictionary<int, Panel>();
        private Graphics[] graphics=new Graphics[20];
        private  int Panel_X=0;
        private const int X_Add=20;
        //70
        private  int Panel_Y=0;
        private const int Y_Add=25;
        //85
        private int count=0;
        private int column=1;
        private int row=1;
        private int sumNum=0;
        private int againsumNum=0;
//distribute controls others
        public TextBox txt_patientName;//input
        public ComboBox comboBox_Paytype;//input
        public ListBox listbedNum;
        
        private int tempKey;

        public CardView(){
            InitializeComponentCardView();
           InvokeSetInitTxt();
        for(int i=0;i<this.sumNum;i++){
           newCardView();
        }
       InitializeInputControls();
      
        }
        private void InitializeComponentCardView(){
            this.components = new System.ComponentModel.Container();
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            }
        public void InitializeInputControls(){
            this.txt_patientName=new TextBox();
            this.txt_patientName.Size=new Size(200,34);
            
            this.listbedNum=new ListBox();
            this.listbedNum.Size=new Size(200,34);
            
            for(int i=0;i<this.sumNum;i++){       
                if(this.bed_Num[i]!=null){
            this.listbedNum.Items.Add(this.bed_Num[i]);
            }else{break;}                      }            
            this.listbedNum.AllowDrop=true;
            this.listbedNum.Sorted=true;
            this.listbedNum.SelectionMode=SelectionMode.One;

        }
        private void newCardView(){
            PictureBox picturebox1=new PictureBox();
            Label[] labels=new Label[]{new Label(),new Label(),new Label(),new Label(),new Label()
            ,new Label()};
            
            ImageList imageList=new ImageList(this.components); 
            Panel panel=new Panel();
            panel.TabIndex=0;
            if(count<20){
            pic.Add(this.count,picturebox1);
            imageLists.Add(this.count,imageList);
            panels.Add(this.count,panel);

            l_pName.Add(this.count,labels[0]);
            l_bNum.Add(this.count,labels[1]);
            l_sex.Add(this.count,labels[2]);
            l_payType.Add(this.count,labels[3]);
            l_hNum.Add(this.count,labels[4]);
            l_inDate.Add(this.count,labels[5]);

            labels[0].Text=this.bed_Num[count];
            labels[0].BackColor=Color.Transparent;
            labels[0].ForeColor=Color.White;
            labels[0].Font=new Font("微软雅黑",20F,FontStyle.Regular,GraphicsUnit.Pixel);
            
           // patient_Name[count]="";
            labels[1].Text=patient_Name[count];
            labels[1].ForeColor=Color.White;
            labels[1].BackColor=Color.Transparent;
            labels[1].Font=new Font("微软雅黑",20F,FontStyle.Regular,GraphicsUnit.Pixel);
            
           // age[count]="";
            labels[2].Text=age[count];
            labels[2].BackColor=Color.Transparent;
            labels[2].ForeColor=Color.White;
            labels[2].Font=new Font("微软雅黑",14F,FontStyle.Regular,GraphicsUnit.Pixel);
            this.administratorOffice[count]=Enum.GetName(typeof(AdministratorOffice),0);
            
            this.payType[count]=PayType.BYSELF;
            labels[3].Text=payType[count];
            labels[3].BackColor=Color.Transparent;
            labels[3].ForeColor=Color.Wheat;
            labels[3].Font=new Font("微软雅黑",14F,FontStyle.Regular,GraphicsUnit.Pixel);
            
           // inHospital_Num[count]="";
            labels[4].Text=inHospital_Num[count];
            labels[4].BackColor=Color.Transparent;
            labels[4].ForeColor=Color.Wheat;
            labels[4].Font=new Font("微软雅黑",16F,FontStyle.Regular,GraphicsUnit.Pixel);
            
          //  into_Date[count]="";
            labels[5].Text=into_Date[count];
            labels[5].BackColor=Color.Transparent;
            labels[5].ForeColor=Color.Wheat;
            labels[5].Font=new Font("微软雅黑",16F,FontStyle.Regular,GraphicsUnit.Pixel);

            imageList.ColorDepth=ColorDepth.Depth8Bit;
            if(sex[count]=="男"){      
            imageList.Images.Add(Image.FromFile("E:\\c#\\NurseWorkstationDemo\\Resource\\man.png"));
            //please use your own path of resource
            }
            else{
            imageList.Images.Add(Image.FromFile("E:\\c#\\NurseWorkstationDemo\\Resource\\woman.png"));
            }
            graphics[this.count]=Graphics.FromHwnd(panel.Handle);
            labels[0].Dock=DockStyle.Top;
            labels[0].Size=new Size(14,30); 

            labels[1].Size=new Size(160,30);
            labels[1].Location=new Point(100,30);
            //,((byte)))
            labels[2].Size=new Size(50,30);
            labels[2].Location=new Point(100,60);

            labels[3].Size=new Size(100,20);
            labels[3].Location=new Point(25,135);
            
            labels[4].Size=new Size(100,30);
            labels[4].Location=new Point(10,170);
            
            labels[5].Size=new Size(100,30);
            labels[5].Location=new Point(160,175);
            imageList.ImageSize=new Size(256, 200);
            picturebox1.Size=new Size(256, 200);
            
            
            picturebox1.Image=imageList.Images[0];
            picturebox1.Controls.AddRange(labels);
            panel.Controls.Add(picturebox1);
            panel.Size=new Size(256, 200);
            
            setOffset();
            }
        }

        public void setOffset(){
            if(this.l_pName.Count==1){
                Panel_X=X_Add;
                Panel_Y=Y_Add;
                imageLists[0].Draw(graphics[0],new Point(Panel_X,Panel_Y),0);
                panels[0].Location=new Point(Panel_X,Panel_Y);
                this.Controls.Add(panels[0]);
                count++;
            }else{
                if(this.column%4==0){
                    Panel_Y+=Y_Add;
                    Panel_Y+=200;
                    Panel_X=X_Add;
                    imageLists[count].Draw(graphics[count],new Point(Panel_X,Panel_Y),0);
                panels[count].Location=new Point(Panel_X,Panel_Y);
                this.Controls.Add(panels[count]);
                this.column-=3;
                this.row++;
                count++;
                }else{
                    Panel_X+=X_Add;
                    Panel_X+=256;
                imageLists[count].Draw(graphics[count],new Point(Panel_X,Panel_Y),0);
                panels[count].Location=new Point(Panel_X,Panel_Y);
                this.Controls.Add(panels[count]); 
                this.column++;
                count++;
                }}
                }
        
        
        //public delegate void Distribute_Invoke();
        private void InvokeSetInitTxt(){
            //设置初始化的卡片文本，主要是床位号，科室，和床位状态
            DataTable dt1=RoomManager.GetNullBedNum();
            this.sumNum=Convert.ToInt32(dt1.Rows[0][0].ToString());

            DataTable dt2=RoomManager.GetDataTableInfoOfNullBednum();
            
            for(int i=0;i<this.sumNum;i++){
            this.bed_Num[i]="";
            this.bed_Num[i]+=dt2.Rows[i][0].ToString()+" "+dt2.Rows[i][1].ToString();
            }
            System.Threading.Thread.Sleep(1000);

        }
        private void InvokeSetInitTxtAgain(){
            //设置初始化的卡片文本，主要是床位号，科室，和床位状态
            DataTable dt1=RoomManager.GetAllBedNum();
            this.againsumNum=Convert.ToInt32(dt1.Rows[0][0].ToString());
             MessageBox.Show(this.againsumNum.ToString());    
            DataTable dt2=RoomManager.GetDataTableInfo();
            DataTable dt3=PatientManager.GetPatientInfoExistRoom();
            int pcount=againsumNum-sumNum;
            for(int i=0;i<this.againsumNum;i++){
            this.bed_Num[i]="";
            this.sex[i]="";
            this.patient_Name[i]=dt2.Rows[i][2].ToString();
            this.bed_Num[i]+=dt2.Rows[i][0].ToString()+" "+dt2.Rows[i][1].ToString();
            this.sex[i]=dt2.Rows[i][3].ToString();
           /* if((this.patient_Name[i]!=null)&&(pcount==i)){
            this.age[i]="";
            this.inHospital_Num[i]="";
            this.into_Date[i]="";
            this.age[i]+=dt3.Rows[i][0].ToString();
            this.inHospital_Num[i]+=dt3.Rows[i][1].ToString();
            this.into_Date[i]+=dt3.Rows[i][2].ToString();
            MessageBox.Show(this.into_Date[i].ToString());
            MessageBox.Show("final step executed successfully");
            }else{
                break;
            }*/
            //bug 
         /*  --! if you have ideas of this project ,please send e-mail to me ,my e-mail is
         '1654220201@qq.com',having a joy in holiday!  --*/
            }      
        System.Threading.Thread.Sleep(1000);
         MessageBox.Show("sixth step executed succcessfully");
        }
         private void Distribute(){
           if(this.txt_patientName.Text!=null ){
            Patient patient=new Patient();
            patient.PatientName=this.txt_patientName.Text.ToString();
            DataTable dt=PatientManager.GetPatientInfo_FromPatientName(patient);
            if(dt.Rows[0][0]!=null)
            {
                //retrieve the patientname key
                try{
                this.tempKey=this.listbedNum.SelectedIndex;}
                catch(Exception ex){
                        MessageBox.Show(ex.StackTrace.ToString()+"请拣选合适的床位号，然后输入患者的姓名！");
                }
                patient_Name[this.tempKey]=dt.Rows[0][0].ToString();
                MessageBox.Show(patient_Name[this.tempKey]);
                this.age[tempKey]=dt.Rows[0][1].ToString();
                this.sex[tempKey]=dt.Rows[0][2].ToString();                    
                this.inHospital_Num[tempKey]=dt.Rows[0][4].ToString();
                this.into_Date[tempKey]=dt.Rows[0][8].ToString();
                Room room=new Room();
                room.PatientName=patient_Name[this.tempKey];
                room.Sex=this.sex[this.tempKey];
                room.Status_R="占用";
                 char[] ch=this.listbedNum.SelectedItem.ToString().ToCharArray(0,3);
                string tempstrring="";
                foreach( char c in ch){
                    tempstrring+=c.ToString();
                }
                room.Room_Num=tempstrring;
                int middleposition=this.listbedNum.SelectedItem.ToString().IndexOf(" ");
                room.Bed_Num=Convert.ToString(this.listbedNum.SelectedItem.ToString().Substring(middleposition+1));
         
                RoomManager.UpdateRoom(room);
                //RenewCarView();
                this.Refresh();
                this.panels.Clear();
                this.pic.Clear();
                this.imageLists.Clear();
                this.l_age.Clear();
                this.l_bNum.Clear();
                this.l_hNum.Clear();
                this.l_inDate.Clear();
                this.l_payType.Clear();
                this.l_pName.Clear();
                this.l_sex.Clear();
                this.Refresh();
                MessageBox.Show("再次唤醒执行前");
                 // this.Dispose();
                
        
                MessageBox.Show("fifth step executed successfully");
            }else{
                MessageBox.Show("您检索的的患者不存在！");
            }
           }else{
               MessageBox.Show("请输入要分配患者的姓名！");
           }
       }//不需要重写
       
         /*  private void RenewCarView(){
           //cleaning all dictionary
           pic.Remove(this.tempKey);
           imageLists.Remove(tempKey);
           panels.Remove(tempKey);
           graphics[tempKey].Dispose();
           l_age.Remove(tempKey);
           l_pName.Remove(tempKey);
           l_bNum.Remove(tempKey);
           l_hNum.Remove(tempKey);
           l_inDate.Remove(tempKey);
           l_payType.Remove(tempKey);
           l_sex.Remove(tempKey);
            this.Refresh();
           //re-initialize
            PictureBox picturebox1=new PictureBox();
            Label[] labels=new Label[]{new Label(),new Label(),new Label(),new Label(),new Label()
            ,new Label()};
            
            ImageList imageList=new ImageList(this.components); 
            Panel panel=new Panel();
            panel.TabIndex=1;
            if(count<20){
            pic.Add(this.tempKey,picturebox1);
            imageLists.Add(this.tempKey,imageList);
            panels.Add(this.tempKey,panel);

            l_pName.Add(this.tempKey,labels[0]);
            l_bNum.Add(this.tempKey,labels[1]);
            l_sex.Add(this.tempKey,labels[2]);
            l_payType.Add(this.tempKey,labels[3]);
            l_hNum.Add(this.tempKey,labels[4]);
            l_inDate.Add(this.tempKey,labels[5]);

            labels[0].Text=this.bed_Num[this.tempKey];
            labels[0].BackColor=Color.Transparent;
            labels[0].ForeColor=Color.White;
            labels[0].Font=new Font("微软雅黑",20F,FontStyle.Regular,GraphicsUnit.Pixel);
            
           // patient_Name[count]="";
            labels[1].Text=patient_Name[this.tempKey];
            labels[1].ForeColor=Color.White;
            labels[1].BackColor=Color.Transparent;
            labels[1].Font=new Font("微软雅黑",20F,FontStyle.Regular,GraphicsUnit.Pixel);
            
           // age[count]="";
            labels[2].Text=age[this.tempKey];
            labels[2].BackColor=Color.Transparent;
            labels[2].ForeColor=Color.White;
            labels[2].Font=new Font("微软雅黑",14F,FontStyle.Regular,GraphicsUnit.Pixel);
            
            this.payType[this.tempKey]=PayType.BYSELF;
            labels[3].Text=payType[this.tempKey];
            labels[3].BackColor=Color.Transparent;
            labels[3].ForeColor=Color.Wheat;
            labels[3].Font=new Font("微软雅黑",14F,FontStyle.Regular,GraphicsUnit.Pixel);
            
           // inHospital_Num[count]="";
            labels[4].Text=inHospital_Num[this.tempKey];
            labels[4].BackColor=Color.Transparent;
            labels[4].ForeColor=Color.Wheat;
            labels[4].Font=new Font("微软雅黑",16F,FontStyle.Regular,GraphicsUnit.Pixel);
            
          //  into_Date[count]="";
            labels[5].Text=into_Date[this.tempKey];
            labels[5].BackColor=Color.Transparent;
            labels[5].ForeColor=Color.Wheat;
            labels[5].Font=new Font("微软雅黑",16F,FontStyle.Regular,GraphicsUnit.Pixel);

            imageList.ColorDepth=ColorDepth.Depth8Bit;
            if(sex[this.tempKey]=="男"){      
            imageList.Images.Add(Image.FromFile("man.png"));
            
            }
            else{
            imageList.Images.Add(Image.FromFile("woman.png"));
            }
            graphics[this.tempKey]=Graphics.FromHwnd(panel.Handle);
            labels[0].Dock=DockStyle.Top;
            labels[0].Size=new Size(14,30); 

            labels[1].Size=new Size(160,30);
            labels[1].Location=new Point(100,30);
            //,((byte)))
            labels[2].Size=new Size(50,30);
            labels[2].Location=new Point(100,60);

            labels[3].Size=new Size(100,20);
            labels[3].Location=new Point(25,135);
            
            labels[4].Size=new Size(100,30);
            labels[4].Location=new Point(10,170);
            
            labels[5].Size=new Size(100,30);
            labels[5].Location=new Point(160,175);
            imageList.ImageSize=new Size(256, 200);
            picturebox1.Size=new Size(256, 200);
            //this.pictureBox1.Location=new Point(32,27);
            
            picturebox1.Image=imageList.Images[0];
            picturebox1.Controls.AddRange(labels);
            panel.Controls.Add(picturebox1);
           // panel.BackColor=Color.Chocolate;
            panel.Size=new Size(256, 200);
            
            if(this.tempKey==0){
                Panel_X=X_Add;
                Panel_Y=Y_Add;
                imageLists[0].Draw(graphics[0],new Point(Panel_X,Panel_Y),0);
                panels[0].Location=new Point(Panel_X,Panel_Y);
                this.Controls.Add(panels[0]);
      
            }else{if(tempKey%4==0){
                int d=tempKey/4;
                Panel_Y=Y_Add*(d+1)+200*d;
                Panel_X=X_Add;
                imageLists[tempKey].Draw(graphics[tempKey],new Point(Panel_X,Panel_Y),0);
                panels[tempKey].Location=new Point(Panel_X,Panel_Y);
                this.Controls.Add(panels[tempKey]);

            }else{
                int p=tempKey%4;
                int re=(tempKey-p)/4;
        
                if(re>1){
                    Panel_X=(p+1)*X_Add+256*p;
                    Panel_Y=Y_Add*(re+1)+200*re;
                }else{
                    Panel_X=(p+1)*X_Add+256*p;
                    Panel_Y=Y_Add;
                }
                imageLists[tempKey].Draw(graphics[tempKey],new Point(Panel_X,Panel_Y),0);
                panels[tempKey].Location=new Point(Panel_X,Panel_Y);
                this.Controls.Add(panels[tempKey]);
            }
                }
                }
            }*/
       public void btn_Distribute(object sender,EventArgs e){
            Distribute();
        //    RenewCarView();
            this.SuspendLayout();
        }
        public CardView(int input){
            this.panels.Clear();
                this.pic.Clear();
                this.imageLists.Clear();
                this.l_age.Clear();
                this.l_bNum.Clear();
                this.l_hNum.Clear();
                this.l_inDate.Clear();
                this.l_payType.Clear();
                this.l_pName.Clear();
                this.l_sex.Clear();
                //foreach(Graphics g in graphics){
                  //  g.Clear(Color.Transparent);
                //}
            InitializeComponentCardView();
                InvokeSetInitTxtAgain();
                //计数器重新初始化
                this.count=0;
                for(int i=0;i<this.againsumNum;i++){
           newCardView();}
        }
        public enum AdministratorOffice{
            INTERNAL,
            SURGERY,
            GYNECOLOGY,//妇科
            PEDIATRY,//儿科
            PSYCHOLOGY,//心理科
            EMERGENCY//急诊
        }
        
}
     
      public struct PayType{
        public static string  BYSELF=>"自费";
        public static string CITY_INHABITANT=>"城镇居民保险";
        public static string  CITY_EMPLOYEE=>"城镇职工保险";
        public static string  NEW_RURALCOLLABORATION=>"新农合";
        public static string  AUTHORITY_ALL=>"全公费医疗报销";
    } 
}