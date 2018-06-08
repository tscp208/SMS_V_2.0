using SMS_Common;
using SMS_Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMS_DAL
{
    public class UsersDAL
    {
        DataTable dt;

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<UsersEntity> GetUsers()
        {
            dt = new DataTable();
            List<UsersEntity> lstUsers = new List<UsersEntity>();
            try
            {
                using (SqlConnection con = new SqlConnection(Connection.dbConnection))
                {
                    con.Open();
                    using (SqlCommand cmd = new SqlCommand("usp_GetUsers", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                        {
                            da.Fill(dt);
                        }
                    }
                }
                lstUsers = dt.AsEnumerable().Select(item => new UsersEntity()
                {
                    SrNo = Convert.ToInt32(item["Srno"]),
                    UserID = Convert.ToInt32(item["UserID"]),
                    UserName = Convert.ToString(item["UserName"]),
                    FirstName = Convert.ToString(item["FirstName"]),
                    LastName = Convert.ToString(item["LastName"]),
                    Gender = Convert.ToString(item["Gender"]),
                    Address = Convert.ToString(item["Address"]),
                    State = Convert.ToString(item["State"]),
                    City = Convert.ToString(item["City"]),
                    ContactNo = Convert.ToString(item["ContactNo"]),
                    EmailAddress = Convert.ToString(item["EmailAdd"]),
                    DOB = Convert.ToString(item["DOB"]),
                    UserTypeID = Convert.ToInt32(item["UserTypeID"]),
                    UserTypeName = Convert.ToString(item["UserTypeName"])
                }
                    ).ToList();

                return lstUsers;
            }
            catch (Exception ex)
            {
                return new List<UsersEntity>();

            }
            finally
            {
                dt = null;
            }
        }

        public UsersEntity GetUsersByID(int UsersID)
        {
            dt = new DataTable();
            UsersEntity UsersEntity = new UsersEntity();
            try
            {
                using (SqlConnection con = new SqlConnection(Connection.dbConnection))
                {
                    con.Open();
                    using (SqlCommand cmd = new SqlCommand("usp_GetUsersByID", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@UserID", UsersID);
                        using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                        {
                            da.Fill(dt);
                        }
                    }
                }
                UsersEntity = dt.AsEnumerable().Select(item => new UsersEntity()
                {
                    SrNo = Convert.ToInt32(item["Srno"]),
                    UserID = Convert.ToInt32(item["UserID"]),
                    UserName = Convert.ToString(item["UserName"]),
                    FirstName = Convert.ToString(item["FirstName"]),
                    LastName = Convert.ToString(item["LastName"]),
                    Gender = Convert.ToString(item["Gender"]),
                    Address = Convert.ToString(item["Address"]),
                    State = Convert.ToString(item["State"]),
                    City = Convert.ToString(item["City"]),
                    ContactNo = Convert.ToString(item["ContactNo"]),
                    EmailAddress = Convert.ToString(item["EmailAdd"]),
                    DOB = Convert.ToString(item["DOB"]),
                    UserTypeID = Convert.ToInt32(item["UserTypeID"]),
                    UserTypeName = Convert.ToString(item["UserTypeName"])
                }
                    ).FirstOrDefault();

                return UsersEntity;
            }
            catch (Exception ex)
            {
                return new UsersEntity();

            }
            finally
            {
                dt = null;
            }
        }

        public bool InsertUsers(UsersEntity userentity)
        {

            try
            {
                using (SqlConnection con = new SqlConnection(Connection.dbConnection))
                {
                    string SpName = string.Empty;
                    if (userentity.UserID != 0)
                        SpName = "usp_UsersUpdate";
                    else
                        SpName = "usp_UsersInsert";
                    con.Open();
                    using (SqlCommand cmd = new SqlCommand(SpName, con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        if (userentity.UserID != 0)
                        { cmd.Parameters.AddWithValue("@UserID", userentity.UserID); }
                        cmd.Parameters.AddWithValue("@UserName", userentity.UserName);
                        //cmd.Parameters.AddWithValue("@Password", userentity.Password);
                        cmd.Parameters.AddWithValue("@FirstName", userentity.FirstName);
                        cmd.Parameters.AddWithValue("@LastName", userentity.LastName);
                        cmd.Parameters.AddWithValue("@Gender", userentity.Gender);
                        cmd.Parameters.AddWithValue("@Address", userentity.Address);
                        cmd.Parameters.AddWithValue("@State", userentity.State);
                        cmd.Parameters.AddWithValue("@City", userentity.City);
                        cmd.Parameters.AddWithValue("@ContactNo", userentity.ContactNo);
                        cmd.Parameters.AddWithValue("@EmailAdd", userentity.EmailAddress);
                        //cmd.Parameters.AddWithValue("@DOB", userentity.DOB);
                        int rows = cmd.ExecuteNonQuery();
                        if (rows > 0)
                        {
                            return true;
                        }
                        else
                        {
                            return false;
                        }

                    }
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool DeleteUser(int UserID)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(Connection.dbConnection))
                {
                    con.Open();
                    using (SqlCommand cmd = new SqlCommand("usp_UsersDelete", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@UserID", UserID);
                        int cnt = cmd.ExecuteNonQuery();
                        if (cnt > 0)
                            return true;
                        else
                            return false;
                    }
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }

    }

}
