using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data;
namespace Ado.netcrudopertion.Models
{
    public class EmployeeDataAccess
    {
        DbConnection DbConnection;
        public EmployeeDataAccess()
        {
            DbConnection = new DbConnection();
        }
        public List<Employee> employees()
        {
            string sp = "sp_employeec";
            SqlCommand sql = new SqlCommand(sp, DbConnection.Connection);
            sql.Parameters.AddWithValue("@action, select_join")
            if(DbConnection.Connection.State=ConnectionState.Closed)
            {
                DbConnection.Connection.Open();
            }
            List<Employee> employees = new List<Employee>();
            SqlDataReader dr = sql.ExecuteReader();
            while(dr.Read())
            {
                Employee Emp = new Employee();
                Emp.id=(int)dr["id"];
                Emp.Email=dr["name"].ToString();
                Emp.Mobile = dr["Mobile"].ToString();
                Emp.Gender = dr["gender"].ToString();
                Emp.Dname = dr["department"].ToString();
                employees.Add(Emp);
            }
            DbConnection.Connection.Close();
            return employees;
        }
    }
}
