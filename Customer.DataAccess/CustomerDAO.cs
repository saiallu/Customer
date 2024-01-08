using Customer.BusinessObjects;
using Microsoft.Extensions.Options;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Runtime.InteropServices.Marshalling;

namespace Customer.DataAccess
{
    public class CustomerDAO : ICustomerDAO
    {
        ConnectionStrings connectionStrings;

        public CustomerDAO(IOptions<ConnectionStrings> connectionStrings)
        {
            this.connectionStrings = connectionStrings.Value;
        }

        public int DeleteCustomer(int id)
        {
            using(SqlConnection conn = new SqlConnection(this.connectionStrings.CustomerConnection))
            {
                using(SqlCommand cmd = conn.CreateCommand())
                {
                    conn.Open();
                    cmd.CommandText = Constants.SpCustomerDelete;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Connection = conn;
                    cmd.Parameters.Add(new SqlParameter() { ParameterName = "@Id", DbType = DbType.Int64 });

                    SqlParameter parms = new SqlParameter();
                    parms.Direction = ParameterDirection.ReturnValue;
                    cmd.Parameters.Add(parms);

                    cmd.ExecuteNonQuery();

                    int returnValue = (int)parms.Value;

                    return returnValue;
                }
            }
        }

        public CustomerBO GetCustomerById(int id)
        {
            CustomerBO customerBO = new CustomerBO();

            using (SqlConnection conn = new SqlConnection(this.connectionStrings.CustomerConnection))
            {
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    conn.Open();
                    cmd.CommandText = Constants.SpCustomerGetById;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Connection = conn;
                    cmd.Parameters.Add(new SqlParameter() { ParameterName = "@Id", DbType = DbType.Int64 });                    
                    SqlDataReader dataReader = cmd.ExecuteReader();

                    if (dataReader != null)
                    {
                        while(dataReader.Read())
                        {
                            customerBO.CreatedBy = Convert.ToString(dataReader["CreatedBy"]);
                            customerBO.CreatedDateTime = dataReader["CreatedDateTime"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(dataReader["CreatedDateTime"]);
                            customerBO.Email = Convert.ToString(dataReader["email"]);
                            customerBO.FirstName = Convert.ToString(dataReader["FirstName"]);
                            customerBO.Id = Convert.ToInt32(dataReader["Id"]);
                            customerBO.LastName = Convert.ToString(dataReader["LastName"]);
                            customerBO.Status = Convert.ToInt32(dataReader["Status"]);
                            customerBO.StatusDescription = Convert.ToString(dataReader["StatusDescription"]);
                            customerBO.UpdatedBy = Convert.ToString(dataReader["UpdatedBy"]);
                            customerBO.UpdatedDateTime = dataReader["UpdatedDateTime"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(dataReader["UpdatedDateTime"]);
                        }
                    }

                    return customerBO;
                }
            }
        }

        public List<CustomerBO> GetCustomerList()
        {
            List<CustomerBO> customerList = new List<CustomerBO>();
            
            using (SqlConnection conn = new SqlConnection(this.connectionStrings.CustomerConnection))
            {
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    conn.Open();
                    cmd.CommandText = Constants.SpCustomerGet;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Connection = conn;

                    SqlDataReader dataReader = cmd.ExecuteReader();

                    if (dataReader != null)
                    {
                        while (dataReader.Read())
                        {
                            CustomerBO customerBO = new CustomerBO();
                            customerBO.CreatedBy = Convert.ToString(dataReader["CreatedBy"]);
                            customerBO.CreatedDateTime = dataReader["CreatedDateTime"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(dataReader["CreatedDateTime"]);
                            customerBO.Email = Convert.ToString(dataReader["email"]);
                            customerBO.FirstName = Convert.ToString(dataReader["FirstName"]);
                            customerBO.Id = Convert.ToInt32(dataReader["Id"]);
                            customerBO.LastName = Convert.ToString(dataReader["LastName"]);
                            customerBO.Status = Convert.ToInt32(dataReader["Status"]);
                            customerBO.StatusDescription = Convert.ToString(dataReader["StatusDescription"]);
                            customerBO.UpdatedBy = Convert.ToString(dataReader["UpdatedBy"]);
                            customerBO.UpdatedDateTime = dataReader["UpdatedDateTime"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(dataReader["UpdatedDateTime"]);
                            customerList.Add(customerBO);
                        }
                    }

                    return customerList;
                }
            }
        }

        public int InsertCustomer(CustomerBO customer)
        {
            using (SqlConnection conn = new SqlConnection(this.connectionStrings.CustomerConnection))
            {
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    conn.Open();
                    cmd.CommandText = Constants.SpCustomerInsert;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Connection = conn;
                    cmd.Parameters.Add(new SqlParameter() { ParameterName = "@FirstName", DbType = DbType.String, Value = customer.FirstName });
                    cmd.Parameters.Add(new SqlParameter() { ParameterName = "@LastName", DbType = DbType.String, Value = customer.LastName });
                    cmd.Parameters.Add(new SqlParameter() { ParameterName = "@Email", DbType = DbType.String, Value = customer.Email });
                    cmd.Parameters.Add(new SqlParameter() { ParameterName = "@CreatedBy", DbType = DbType.String, Value = customer.CreatedBy });

                    SqlParameter parms = new SqlParameter();
                    parms.Direction = ParameterDirection.ReturnValue;
                    cmd.Parameters.Add(parms);

                    cmd.ExecuteNonQuery();

                    int returnValue = (int)parms.Value;

                    return returnValue;
                }
            }
        }

        public int UpdateCustomer(CustomerBO customer)
        {
            using (SqlConnection conn = new SqlConnection(this.connectionStrings.CustomerConnection))
            {
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    conn.Open();
                    cmd.CommandText = Constants.SpCustomerUpdate;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Connection = conn;
                    cmd.Parameters.Add(new SqlParameter() { ParameterName = "@Id", DbType = DbType.String, Value = customer.Id });
                    cmd.Parameters.Add(new SqlParameter() { ParameterName = "@FirstName", DbType = DbType.String, Value = customer.FirstName });
                    cmd.Parameters.Add(new SqlParameter() { ParameterName = "@LastName", DbType = DbType.String, Value = customer.LastName });
                    cmd.Parameters.Add(new SqlParameter() { ParameterName = "@Email", DbType = DbType.String, Value = customer.Email });
                    cmd.Parameters.Add(new SqlParameter() { ParameterName = "@Status", DbType = DbType.Int32, Value = customer.Status });
                    cmd.Parameters.Add(new SqlParameter() { ParameterName = "@UpdatedBy", DbType = DbType.String, Value = customer.UpdatedBy });

                    SqlParameter parms = new SqlParameter();
                    parms.Direction = ParameterDirection.ReturnValue;
                    cmd.Parameters.Add(parms);

                    cmd.ExecuteNonQuery();

                    int returnValue = (int)parms.Value;

                    return returnValue;
                }
            }
        }
    }
}
