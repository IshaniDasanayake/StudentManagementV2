using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace StudentManagement.Models
{
    public class DBHandler
    {
        private SqlConnection con;
        private void connection()
        {
            string constring = ConfigurationManager.ConnectionStrings["connectionstring"].ToString();
            con = new SqlConnection(constring);
        }

        //-------Add student---------------------
        public bool AddStudent(Student student)
        {
            connection();
            SqlCommand cmd = new SqlCommand("AddStudent", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@name", student.name);
            cmd.Parameters.AddWithValue("@dob", student.dob);
            cmd.Parameters.AddWithValue("@reg_date", student.reg_date);
            cmd.Parameters.AddWithValue("@AL_stream", student.AL_stream);

            con.Open();
            int i = cmd.ExecuteNonQuery();
            con.Close();

            if (i >= 1)
                return true;
            else
                return false;
        }

        //-----------view all student------
        public List<Student> GetStudent()
        {
            connection();
            List<Student> studentlist = new List<Student>();

            SqlCommand cmd = new SqlCommand("GetAllStudent", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter sd = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            con.Open();
            sd.Fill(dt);
            con.Close();

            foreach (DataRow dr in dt.Rows)
            {
                studentlist.Add(
                    new Student
                    {
                        id = Convert.ToInt32(dr["id"]),
                        name = Convert.ToString(dr["name"]),
                        dob = Convert.ToDateTime(dr["dob"]),
                        reg_date = Convert.ToDateTime(dr["reg_date"]),
                        AL_stream = Convert.ToString(dr["AL_stream"]),
                    });
            }
            return studentlist;
        }

        //----------update student-----------
        public bool UpdateStudent(Student student)
        {
            connection();
            SqlCommand cmd = new SqlCommand("UpdateStudent", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@id", student.id);
            cmd.Parameters.AddWithValue("@name", student.name);
            cmd.Parameters.AddWithValue("@dob", student.dob);
            cmd.Parameters.AddWithValue("@reg_date", student.reg_date);
            cmd.Parameters.AddWithValue("@AL_stream", student.AL_stream);

            con.Open();
            int i = cmd.ExecuteNonQuery();
            con.Close();

            if (i >= 1)
                return true;
            else
                return false;
        }

        //---------delete student----------------
        public bool DeteleStudent(int id)
        {
            connection();
            SqlCommand cmd = new SqlCommand("DeleteStudent", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@id", id);

            con.Open();
            int i = cmd.ExecuteNonQuery();
            con.Close();

            if (i >= 1)
                return true;
            else
                return false;
        }

        //------------get Student by id--------------
        public Student GetStudentById(int id)
        {
            connection();
            SqlCommand cmd = new SqlCommand("GetStudentById", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@id", id);
            Student student = new Student();
            SqlDataAdapter sd = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            con.Open();
            sd.Fill(dt);
            con.Close();

            if (dt.Rows.Count == 1)
            {
                student.id = Convert.ToInt32(dt.Rows[0]["id"].ToString());
                student.name = Convert.ToString(dt.Rows[0]["name"].ToString());
                student.dob = Convert.ToDateTime(dt.Rows[0]["dob"].ToString());
                student.reg_date = Convert.ToDateTime(dt.Rows[0]["reg_date"].ToString());
                student.AL_stream = Convert.ToString(dt.Rows[0]["AL_stream"].ToString());
            }
            return student;
        }

        //---------------user login---------------
        public bool UserLogin(string name, string password)
        {
            connection();
            SqlCommand cmd = new SqlCommand("UserLogin", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@name", name);
            cmd.Parameters.AddWithValue("@password", password);
            AppUser user = new AppUser();
            SqlDataAdapter sd = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            con.Open();
            sd.Fill(dt);
            con.Close();

            if (dt.Rows.Count == 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        //--------------------search name------------
        public List<Student> SearchByName(string str)
        {
            connection();
            List<Student> studentlist = new List<Student>();

            SqlCommand cmd = new SqlCommand("SearchName", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@str", str);

            SqlDataAdapter sd = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            con.Open();
            sd.Fill(dt);
            con.Close();

            foreach (DataRow dr in dt.Rows)
            {
                studentlist.Add(
                    new Student
                    {
                        id = Convert.ToInt32(dr["id"]),
                        name = Convert.ToString(dr["name"]),
                        dob = Convert.ToDateTime(dr["dob"]),
                        reg_date = Convert.ToDateTime(dr["reg_date"]),
                        AL_stream = Convert.ToString(dr["AL_stream"]),
                    });
            }
            return studentlist;
        }
    }


}