using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using NurseWorkstationDemo.DAO;
using NurseWorkstationDemo.SERVICE;
namespace NurseWorkstationDemo
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
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

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1900, 1000);
            this.Text = "NurseWorkStationDemo";
            
            //initialize;
            this.mainMenu=new MainMenu();
            this.menuItem1=new MenuItem();
            this.menuItem2=new MenuItem();
            this.menuItem3=new MenuItem();
            this.menuItem1.Text="打开";
            this.menuItem1.Shortcut=Shortcut.CtrlO;
            this.menuItem2.Text="保存";
            this.menuItem2.Shortcut=Shortcut.CtrlS;
            this.menuItem3.Text="打印";
            this.menuItem3.Shortcut=Shortcut.CtrlP;
            this.mainMenu.MenuItems.Add(this.menuItem1);
            this.mainMenu.MenuItems.Add(this.menuItem2);
            this.mainMenu.MenuItems.Add(this.menuItem3);
            Menu=this.mainMenu;
        //
            this.toolBar=new ToolBar();
            this.toolBar.Dock=DockStyle.Top;
            this.toolBar.Size=new Size(400,30);
            this.toolBar.Appearance=ToolBarAppearance.Flat;
            this.toolBar.BorderStyle=BorderStyle.None;
            this.toolBar.ButtonSize=new Size(35,27);
            this.toolBar.Divider=false;
            //this.toolBar.AllowDrop=true;
            this.toolBar.BackColor=Color.Blue;
            //this.toolBar.Location=new Point(100,10);
            this.toolBarButton1=new ToolBarButton();
            this.toolBarButton2=new ToolBarButton();
            this.toolBarButton3=new ToolBarButton();
            this.toolBarButton4=new ToolBarButton();
            this.toolBarButton1.Text="显示";
            this.toolBarButton2.Text="刷新";
            this.toolBarButton3.Text="上一步";
            this.toolBarButton4.Text="下一步";
            ToolBarButton[] b1=new ToolBarButton[]{this.toolBarButton1,this.toolBarButton2
            ,this.toolBarButton3,this.toolBarButton4};
            this.toolBar.Buttons.AddRange(b1);
            this.toolBar.ButtonClick+=
            new ToolBarButtonClickEventHandler(toolBar1_ButtonClick);
            this.Controls.Add(this.toolBar);
            this.SuspendLayout();

            this.tabControl=new TabControl();
            this.tabControl.Visible=true;
            this.tabControl.ItemSize=new Size(50,100);
            this.tabControl.Alignment=TabAlignment.Left;
            this.tabControl.Size=new Size(1800,900);
            this.tabControl.Dock=DockStyle.Left;
            this.tabControl.Location=new Point(0,40);
            this.tabControl.DrawMode=TabDrawMode.OwnerDrawFixed;
           // this.tabControl.Appearance=TabAppearance.FlatButtons;
            this.tabControl.DrawItem+=new DrawItemEventHandler(tabControl1_DrawItem);
            this.tabPage1=new TabPage();
            this.tabPage1.Text="患者录入";
            
            this.Patient_lab=new Label();
            this.delete_lab=new Label();
            this.Patient_lab.Size=new Size(200,60);
            this.delete_lab.Size=new Size(200,60);
            this.Patient_lab.BackColor=Color.Pink;
            this.Patient_lab.ForeColor=Color.Blue;
            this.delete_lab.BackColor=Color.RosyBrown;
            this.delete_lab.ForeColor=Color.White;
            this.Patient_lab.Text="请输入要查\n"+"找患者的姓名";
            this.delete_lab.Text="请输入删除\n"+"患者的姓名";
            this.Patient_lab.Location=new Point(1400,335);
            this.delete_lab.Location=new Point(1400,170);
            this.tabPage1.Controls.AddRange(new Control[]{this.Patient_lab,this.delete_lab});
            //new button of page1
            this.pbtn_delete=new Button();
            this.pbtn_insert=new Button();
            this.pbtn_update=new Button();
            this.pbtn_find=new Button();
            this.pbtn_delete.Size=new Size(80,34);
            this.pbtn_find.Size=new Size(80,34);
            this.pbtn_update.Size=new Size(80,34);
            this.pbtn_insert.Size=new Size(80,34);
            this.pbtn_insert.Location=new Point(1400,70);
            this.pbtn_update.Location=new Point(1400,120);
            this.pbtn_delete.Location=new Point(1400,285);
            this.pbtn_find.Location=new Point(1400,455);
            this.pbtn_delete.Text="删除";
            this.pbtn_find.Text="查找";
            this.pbtn_insert.Text="保存";
            this.pbtn_update.Text="更改";
            this.pbtn_insert.Click+=new EventHandler(btn_Save);
            this.pbtn_update.Click+=new  EventHandler(btn_Update);
            this.pbtn_delete.Click+=new EventHandler(btn_Delete);
            this.pbtn_find.Click+=new EventHandler(btn_Find);
            Control[] cpbtn=new Control[]{this.pbtn_delete,this.pbtn_find,this.pbtn_insert
            ,this.pbtn_update};
            this.tabPage1.Controls.AddRange(cpbtn);
            this.search_Name=new TextBox();
            this.delete_Name=new TextBox();
            this.search_Name.Size=new Size(101,34);
            this.delete_Name.Size=new Size(101,34);
            this.search_Name.Location=new Point(1400,405);
            this.delete_Name.Location=new Point(1400,235);
            this.tabPage1.Controls.AddRange(new Control[]{this.search_Name,this.delete_Name});
            this.SuspendLayout();

            this.richTextBox=new RichTextBox();
            this.richTextBox.Dock=DockStyle.Bottom;
            this.richTextBox.Size=new Size(1000,100);
            this.tabPage1.Controls.Add(this.richTextBox);
            this.dGV1=new DataGridView();
            this.dGV1.Size=new Size(1700,800);
            this.dGV1.ColumnCount=9;
            this.dGV1.RowCount=2;
            this.dGV1.ColumnHeadersHeight=100;
            //this.dGV1.AllowUserToAddRows=true;
            //this.dGV1.AllowDrop=true;
            this.dGV1.AllowUserToDeleteRows=true;
            //this.dGV1.AllowUserToOrderColumns=true;
            this.dGV1.AutoGenerateColumns=true;
            this.dGV1.AutoSizeColumnsMode=DataGridViewAutoSizeColumnsMode.AllCells;
            this.dGV1.Enabled=true;
        // Set the column header style.
        DataGridViewCellStyle columnHeaderStyle =
            new DataGridViewCellStyle();
        columnHeaderStyle.BackColor = Color.AntiqueWhite;
        columnHeaderStyle.Font =
            new Font("微软雅黑", 10, FontStyle.Bold);
        this.dGV1.ColumnHeadersDefaultCellStyle =
            columnHeaderStyle;
        //SETTING page1 datagridview name and property
        // Set the column header names.
        dGV1.Columns[0].Name="患者姓名";
        dGV1.Columns[1].Name="年龄";
        
       // dGV1.Columns[2].Name="性别";
        
        this.column=new DataGridViewComboBoxColumn();
{       column.HeaderText="性别";
        column.Name="性别";
        column.Items.AddRange("男","女");
        column.Width = 40;
        column.MaxDropDownItems = 2;
        column.FlatStyle = FlatStyle.Flat;
        column.DataPropertyName="性别";
        column.ValueMember="性别";
     
        }
        dGV1.Columns.Insert(2,column);
        dGV1.Columns[3].Name="身份证号";
        dGV1.Columns[4].Name="住院号";
        dGV1.Columns[5].Name="主管医师";
        dGV1.Columns[6].Name="主要症状";
        dGV1.Columns[7].Name="电话号码";
        dGV1.Columns[8].Name="入院日期";
        DataGridViewTextBoxColumn column1=new DataGridViewTextBoxColumn();
            //column1.AutoSizeMode =
           // DataGridViewAutoSizeColumnMode.AllCells;
            column1.CellTemplate.Style.BackColor=Color.Blue;
            this.dGV1.Columns.Contains(column1);
            this.dGV1.ScrollBars=ScrollBars.Both;

            this.tabPage1.Controls.Add(this.dGV1);
            this.tabPage1.ImageIndex=1;
            this.tabPage1.AllowDrop=true;
            this.tabPage1.AutoScroll=true;
            this.tabPage1.UseVisualStyleBackColor=true;
            this.tabPage2=new TabPage();
            this.tabPage2.ImageIndex=2;
            this.tabPage2.Text="床位分配";
            this.tabPage2.BackColor=Color.GreenYellow;
            this.tabPage2.UseVisualStyleBackColor=true;
            this.tabPage2.AllowDrop=true;
            this.tabPage2.AutoScroll=true;

            this.cardView=new CardView();
            this.cardView.Size=new System.Drawing.Size(1500,900);
            this.cardView.txt_patientName.Location=new Point(1510,110);
            this.cardView.listbedNum.Location=new Point(1510,210);
            this.tabPage2.Controls.Add(this.cardView);
            this.tabPage2.Controls.Add(this.cardView.txt_patientName);
            this.tabPage2.Controls.Add(this.cardView.listbedNum);
            this.bed_distribute=new Button();
            this.bed_distribute.Location=new Point(1520,260);
            this.bed_distribute.BackColor=Color.Azure;
            this.bed_distribute.Size=new Size(153,41);
            this.bed_distribute.Text="分配床位";
            this.bed_distribute.Click+=new EventHandler(this.cardView.btn_Distribute);
            this.beddis_notice=new Label();
            this.bednum_notice=new Label();
            this.beddis_notice.Size=new Size(200,68);
            this.bednum_notice.Size=new Size(200,34);
            this.beddis_notice.Text="请输入要分配的\n"+"    患者姓名";
            this.bednum_notice.Text="请输入分配的床号";
            this.beddis_notice.Location=new Point(1510,30);
            this.bednum_notice.Location=new Point(1510,160);
            this.tabPage2.Controls.AddRange(new Control[]{this.bed_distribute,this.beddis_notice,
            this.bednum_notice});

            this.tabPage3=new TabPage();
            this.tabPage3.UseVisualStyleBackColor=true;
            this.tabPage3.Text="公共物品\n"+"   "+"安排"+" ";
            this.notice=new Label();
            this.notice.Size=new Size(300,200);
            this.notice.Text="此模块尚未开发，敬请期待！";
            this.notice.Dock=DockStyle.Fill;
            this.groupBox=new GroupBox();
            this.groupBox.Size=new Size(500,400);
            this.groupBox.BackColor=Color.LightBlue;
            this.groupBox.Margin=new Padding(10);
            this.groupBox.Controls.Add(this.notice); 
            this.tabPage3.Controls.Add(this.groupBox);
            this.tabPage4=new TabPage();
            this.tabPage4.UseVisualStyleBackColor=true;
            this.tabPage4.Text="护理流程\n"+"   安排";
            TabPage[] c0=new TabPage[]{this.tabPage1,this.tabPage2,
            this.tabPage3,this.tabPage4};
            

           // this.flowLayoutPanel1=new FlowLayoutPanel();
            //this.flowLayoutPanel1.Controls.Add(this.tabPage1);

            this.tabControl.TabPages.AddRange(c0);
            this.Controls.Add(this.tabControl);
        }

        #endregion
        private Button pbtn_find;
        private Button pbtn_insert;
        private Button pbtn_delete;
        private Button pbtn_update;
        //private FlowLayoutPanel flowLayoutPanel1;
        private MainMenu mainMenu;
        private MenuItem menuItem1;
        private MenuItem menuItem2;private MenuItem menuItem3;
        private TabControl tabControl;
        private TabPage tabPage1;
        private TabPage tabPage2;
        private TabPage tabPage3;
        private TabPage tabPage4;
        private DataGridView dGV1;
        private DataGridViewComboBoxColumn column;
        private Label Patient_lab;
        private Label delete_lab;

        private GroupBox groupBox;
        
        //private TabItemState tabItemState=TabItemState.Selected;
        //private Rectangle rectangle;
       // private ToolStripContainer toolStripContainer;
        //private ToolStrip toolStrip;
        
        private TextBox search_Name;
        private TextBox delete_Name;
        //private ListBox listBox;
        //private ImageList imageList;

       // private ComboBox comboBox;
        private ToolBar toolBar;
        private ToolBarButton toolBarButton1;
        private ToolBarButton toolBarButton2;
        
        private ToolBarButton toolBarButton3;
        
        private ToolBarButton toolBarButton4;
        private RichTextBox richTextBox;
        private CardView cardView;

        private Button bed_distribute;
        private Label beddis_notice;
        private Label bednum_notice;

        private Label notice;
    }
}