using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;


namespace DatabasewInheritance
{
    public class StudentDb:Database
    {
        public StudentDb() : base(ConfigurationManager.AppSettings["constr"])
        {
            
        }

        public override void Connect()
        {
            base.Connect();

        }

        public int Insert(Student s)
        {
            string query = "Insert into Student (Name,Age,Roll) values('" + s.Name + "'," + s.Age + "," + s.Roll + ")";
            int res = base.InsertUpdateDelete(query);

            return res;

        }

        public int Update(Student s)
        {
            string query = "Update Student set Name='" + s.Name + "',Age=" + s.Age +",Roll=" + s.Roll;
            int res = base.InsertUpdateDelete(query);
            return res;
        }

        public int Delete(int sn)
        {
            string query = "Delete from Student where SN=" + sn;
            int res = base.InsertUpdateDelete(query);
            return res;
        }

        public List<Student> StdSelectAll()
        {
            reader = base.SelectAll("Student");
            List<Student> list=new List<Student>();
            while (reader.Read())
            {
                Student temp = new Student();
                temp.SN = Convert.ToInt32(reader["SN"]);
                temp.Name = Convert.ToString(reader["Name"]);
                temp.Age = Convert.ToInt32(reader["Age"]);
                temp.Roll = Convert.ToInt32(reader["Roll"]);
                list.Add(temp);
                
            }

            return list;
        }
    
    }
}

