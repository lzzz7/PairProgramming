﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using DaoLayer;
using Entity;
using System.Threading;

namespace WinformControlUse
{
    public partial class Form1 : System.Windows.Forms.Form
    {
        List<Student> stuList;

        public Form1()
        {
            InitializeComponent();
        }

        void iniControl()
        {
            btnStart.Visible = false;
            btnStop.Visible = false;
            btnLoadStu.Enabled = true;            
        }

        void setControlVisible()
        {
            btnStart.Visible = true;
            btnStop.Visible = true;
            btnLoadStu.Visible = false;           
        }

        private void btnLoadStu_Click(object sender, EventArgs e)
        {          

            //获取学生数据源
            StudentDAO stuDao = new StudentDAO();
            stuList=stuDao.getAllStudents();

            //进度条设置
            int stuCounts = stuList.Count;//及时学生人数
            progressName.Maximum = stuCounts;
        

            //构造数据源
            DataTable dt = new DataTable();          
            dt.Columns.Add("stuID", Type.GetType("System.String"));
            dt.Columns.Add("stuName", Type.GetType("System.String"));
            
            //数据加载以进度条方式展现
            foreach (Student stu in stuList)
            {
                dt.Rows.Add(stu.Id,stu.Name);
                progressName.Value += 1;//一个学生，进度条加1；
                Thread.Sleep(5);                
            }            
            
            dgvStuList.DataSource = dt;

            setControlVisible();

        }

        private void FrmStudent_Load(object sender, EventArgs e)
        {
            iniControl();
        }

        private void timerCallName_Tick(object sender, EventArgs e)
        {
            Random ra = new Random();
            int i = ra.Next(stuList.Count);
            lblName.Text = stuList[i].Name;
            label3.Text = stuList[i].Id;

        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            timerCallName.Start();
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            timerCallName.Stop();
        }

        private void dgvStuList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void progressName_Click(object sender, EventArgs e)
        {

        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {
            Console.WriteLine();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
