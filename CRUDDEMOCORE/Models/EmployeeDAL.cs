using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace CRUDDEMOCORE.Models
{
    public class EmployeeDAL
    {
        string connectionstring = "Server=SUYCOKHWDSK223;Database=Core;Trusted_Connection=True;MultipleActiveResultSets=True;";
        
        public IEnumerable<Employee> GetAllEmployee()
        {
            List<Employee> empList = new List<Employee>();
            using (SqlConnection con =new SqlConnection(connectionstring))
            {
                SqlCommand cmd = new SqlCommand("SP_GetAllEmployee", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    Employee emp = new Employee();
                    emp.Id = Convert.ToInt32(dr["ID"].ToString());
                    emp.Name = (dr["Name"].ToString());
                    emp.Gender = (dr["Gender"].ToString());
                    emp.Department = (dr["Department"].ToString());
                    emp.Company = (dr["Company"].ToString());
                    empList.Add(emp);

                }
                con.Close();


            }
            return empList;
        }
        public void Cretae(Employee emp)
        {
            using (SqlConnection con = new SqlConnection(connectionstring))
            {
                SqlCommand cmd = new SqlCommand("SP_InsertEmployee", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Name", emp.Name);
                cmd.Parameters.AddWithValue("@Gender", emp.Gender);
                cmd.Parameters.AddWithValue("@Department", emp.Department);
                cmd.Parameters.AddWithValue("@Company", emp.Company);
                
                con.Open();
                cmd.ExecuteNonQuery();
               
                con.Close();

            }
        }
        public void UpadteEmployee(Employee emp)
        {
            using (SqlConnection con = new SqlConnection(connectionstring))
            {
                SqlCommand cmd = new SqlCommand("SP_UpdateEmployee", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@EmpId", emp.Id);
                cmd.Parameters.AddWithValue("@Name", emp.Name);
                cmd.Parameters.AddWithValue("@Gender", emp.Gender);
                cmd.Parameters.AddWithValue("@Department", emp.Department);
                cmd.Parameters.AddWithValue("@Company", emp.Company);

                con.Open();
                cmd.ExecuteNonQuery();

                con.Close();

            }

        }
        public void DeleteEmployee(int? empId)
        {
            using (SqlConnection con = new SqlConnection(connectionstring))
            {
                SqlCommand cmd = new SqlCommand("SP_DeleteEmployee", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@EmpId",empId);
              

                con.Open();
                cmd.ExecuteNonQuery();

                con.Close();

            }

        }
        public  Employee EmployeeBtId(int EmpId)
        {
           
            Employee emp = new Employee();
            using (SqlConnection con = new SqlConnection(connectionstring))
            {
                SqlCommand cmd = new SqlCommand("SP_GetEmployeeById", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@EmpId",EmpId);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    
                    emp.Id = Convert.ToInt32(dr["ID"].ToString());
                    emp.Name = (dr["Name"].ToString());
                    emp.Gender = (dr["Gender"].ToString());
                    emp.Department = (dr["Department"].ToString());
                    emp.Company = (dr["Company"].ToString());
                 

                }
                con.Close();


            }

            return emp;
        }
        

    }
 
}
