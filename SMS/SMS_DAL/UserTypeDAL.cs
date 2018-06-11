using SMS_Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SMS_Common;
using System.Data;
using System.Data.SqlClient;

namespace SMS_DAL
{
    public class UserTypeDAL
    {
        DataTable dt = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter();

        public List<UserTypeEntity> GetUserTypes(int start, int length, string sortColumn, string sortDir, string searchTerm, out int totalRecords)
        {
            totalRecords = 0;
            List<UserTypeEntity> userTypes = new List<UserTypeEntity>();
            try
            {
                using (SqlConnection con = new SqlConnection(Connection.dbConnection))
                {
                    con.Open();
                    using (SqlCommand cmd = new SqlCommand("usp_GetUserTypes", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@start", start);
                        cmd.Parameters.AddWithValue("@length", length);
                        cmd.Parameters.AddWithValue("@sortColumn", sortColumn);
                        cmd.Parameters.AddWithValue("@sortDir", sortDir);
                        cmd.Parameters.AddWithValue("@searchTerm", searchTerm);
                        cmd.Parameters.Add("@totalRecord", SqlDbType.Int);
                        cmd.Parameters["@totalRecord"].Direction = ParameterDirection.Output;
                        da.SelectCommand = cmd;
                        da.Fill(dt);

                        totalRecords = Convert.ToInt32(cmd.Parameters["@totalRecord"].Value);
                    }
                }

                userTypes = dt.AsEnumerable().Select(item => new UserTypeEntity()
                {
                    SrNo = Convert.ToInt32(item["Srno"]),
                    UserTypeID = Convert.ToInt32(item["UserTypeID"]),
                    UserTypeName = Convert.ToString(item["UserTypeName"]),
                    UserTypeDesc = Convert.ToString(item["userTypeDesc"])
                }).ToList();
                return userTypes;
            }
            catch (Exception)
            {
                return new List<UserTypeEntity>();
            }
            finally
            {
                userTypes = null;
                dt = null;
            }
        }

        public UserTypeEntity GetUserTypeByID(int userTypeID)
        {
            UserTypeEntity userType = new UserTypeEntity();
            string strQry = "Select UserTypeID, UserTypeName, UserTypeDesc From tblUserType Where UserTypeID = @UserTypeID";
            try
            {
                using (SqlConnection con = new SqlConnection(Connection.dbConnection))
                {
                    con.Open();
                    using (SqlCommand cmd = new SqlCommand(strQry, con))
                    {
                        cmd.Parameters.AddWithValue("@UserTypeID", userTypeID);
                        da.SelectCommand = cmd;
                        da.Fill(dt);
                    }
                }

                userType = dt.AsEnumerable().Select(item => new UserTypeEntity()
                {
                    UserTypeID = Convert.ToInt32(item["UserTypeID"]),
                    UserTypeName = Convert.ToString(item["UserTypeName"]),
                    UserTypeDesc = Convert.ToString(item["userTypeDesc"])
                }).FirstOrDefault();

                return userType;
            }
            catch (Exception)
            {
                return new UserTypeEntity();
            }
            finally
            {
                dt = null;
                userType = null;
                strQry = "";
            }
        }

        public bool InsertUserType(UserTypeEntity userTypeEntity)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(Connection.dbConnection))
                {
                    con.Open();
                    using (SqlCommand cmd = new SqlCommand("usp_InsertUserType", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@UserTypeName", userTypeEntity.UserTypeName);
                        cmd.Parameters.AddWithValue("@UserTypeDesc", userTypeEntity.UserTypeDesc == null ? "" : userTypeEntity.UserTypeDesc);
                        cmd.Parameters.AddWithValue("@CreatedBy", userTypeEntity.CreatedBy);
                        cmd.Parameters.AddWithValue("@CreatedOn", userTypeEntity.CreatedOn);
                        cmd.Parameters.AddWithValue("@IsDeleted", userTypeEntity.IsDeleted);
                        cmd.Parameters.Add("@UserTypeID", SqlDbType.Int);
                        cmd.Parameters["@UserTypeID"].Direction = ParameterDirection.Output;
                        cmd.ExecuteNonQuery();

                        int userTypeID = Convert.ToInt32(cmd.Parameters["@UserTypeID"].Value);
                        if (userTypeID > 0)
                            return true;
                        else
                            return false;

                    }
                }
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool IsUserTypeExist(string userType, int userTypeID)
        {
            string strQry = "";
            if (userTypeID > 0)
                strQry = "Select * From tblUserType Where IsDeleted = 0 And UserTypeName = @UserTypeName And UserTypeID <> @UserTypeID";
            else
                strQry = "Select * From tblUserType Where IsDeleted = 0 And UserTypeName = @UserTypeName";
            try
            {
                using (SqlConnection con = new SqlConnection(Connection.dbConnection))
                {
                    con.Open();
                    using (SqlCommand cmd = new SqlCommand(strQry, con))
                    {
                        cmd.Parameters.AddWithValue("@UserTypeName", userType);
                        cmd.Parameters.AddWithValue("@UserTypeID", userTypeID);
                        int cnt = Convert.ToInt32(cmd.ExecuteScalar());
                        if (cnt > 0)
                            return true;
                        else
                            return false;
                    }
                }
            }
            catch (Exception)
            {
                return false;
            }
            finally
            {
                strQry = "";
            }
        }

        public bool DeleteUserType(int userType)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(Connection.dbConnection))
                {
                    con.Open();
                    using (SqlCommand cmd = new SqlCommand("usp_DeleteUserType", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@userTypeID", Convert.ToString(userType));
                        int cnt = cmd.ExecuteNonQuery();
                        if (cnt > 0)
                            return true;
                        else
                            return false;
                    }
                }
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool UpdateUserType(UserTypeEntity userTypeEntity)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(Connection.dbConnection))
                {
                    con.Open();
                    using (SqlCommand cmd = new SqlCommand("usp_UpdateUserType", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@UserTypeID", userTypeEntity.UserTypeID);
                        cmd.Parameters.AddWithValue("@UserTypeName", userTypeEntity.UserTypeName);
                        cmd.Parameters.AddWithValue("@UserTypeDesc", userTypeEntity.UserTypeDesc == null ? "" : userTypeEntity.UserTypeDesc);
                        cmd.Parameters.AddWithValue("@ModifiedBy", userTypeEntity.ModifiedBy);
                        cmd.Parameters.AddWithValue("@ModifiedOn", userTypeEntity.ModifiedOn);
                        int cnt = cmd.ExecuteNonQuery();

                        if (cnt > 0)
                            return true;
                        else
                            return false;
                    }
                }
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
