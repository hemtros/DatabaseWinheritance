using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace DatabasewInheritance
{
    public class Database
    {
        
        protected SqlConnection con;
        protected SqlCommand cmd;
        protected SqlDataReader reader;

        public Database(string constr)
        {
            
            con = new SqlConnection();
            con.ConnectionString = constr;

            cmd = new SqlCommand();
            cmd.Connection = con;
            reader = null;
        }

        public virtual void Connect()
        {
            try
            {
                if (con.State == ConnectionState.Closed)
                    con.Open();
            }
            catch (SqlException se)
            {
                MessageBox.Show("Server Path error");
            }

        }


        public void Disconnect()
        {

            if (con.State == ConnectionState.Open)
                con.Close();



        }

        

        public int InsertUpdateDelete(String query)
        {
            int res = -1;

            cmd.CommandText = query;

            Connect();

            try
            {
                res = cmd.ExecuteNonQuery();

            }
            catch (SqlException se)
            {
                Console.WriteLine(se.Message);
                res = -1;
            }

            this.Disconnect();

            return res;


        }

        public SqlDataReader SelectAll(string tble_name)
        {
            

            cmd.CommandText = "select * from "+tble_name;

            this.Connect();

            try
            {
                reader = cmd.ExecuteReader();
            }

            catch (SqlException se)
            {
                Console.WriteLine(se.Message);
            }

            return reader;
        }


    }
}
