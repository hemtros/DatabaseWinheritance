using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DatabasewInheritance
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Student s=new Student();
           // s.SN = Convert.ToInt32(SnTextbox.Text);
            s.Name = NameTextbox.Text;
            s.Roll = Convert.ToInt32(RollTextbox.Text);
            s.Age = Convert.ToInt32(AgeTextbox.Text);
            StudentDb sdb=new StudentDb();
            int result=sdb.Insert(s);
            
            if(result==-1)
            {
                MessageBox.Show("couldn't be inserted");
            }

            else
            {
                MessageBox.Show(result+" Row inserted");
            }

            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Student s=new Student();
            s.SN = Convert.ToInt32(SnTextbox.Text);
            s.Age = Convert.ToInt32(AgeTextbox.Text);
            s.Roll = Convert.ToInt32(RollTextbox.Text);
            s.Name = NameTextbox.Text;
            StudentDb sdb=new StudentDb();
            int result=sdb.Update(s);

            if(result==-1)
            {
                MessageBox.Show("couldn't be updated");
            }

            else
            {
                MessageBox.Show(result+"row updated");
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            LoadListView();
        }

        public void LoadListView()
        {
            listView1.Items.Clear();
            StudentDb stdb = new StudentDb();
            List<Student> list = stdb.StdSelectAll();

            foreach (Student s in list)
            {
                ListViewItem row = new ListViewItem();    //row is created every time the loop runs
                row.Text = s.SN.ToString();
                row.SubItems.Add(s.Name);
                row.SubItems.Add(s.Age.ToString());
                row.SubItems.Add(s.Roll.ToString());
                listView1.Items.Add(row);  //at end of these statements row is added and the variable is destroyed and collected by garbage collector

            }
        }
    }
}
