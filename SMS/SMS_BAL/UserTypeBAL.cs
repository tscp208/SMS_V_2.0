using SMS_DAL;
using SMS_Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMS_BAL
{
    public class UserTypeBAL
    {
        public UserTypeDAL userTypeDAL = new UserTypeDAL();

        public List<UserTypeEntity> GetUserTypes(int start, int length, string sortColumn, string sortDir, out int totalRecords)
        {
            return userTypeDAL.GetUserTypes(start, length, sortColumn, sortDir,out totalRecords);
        }

        public UserTypeEntity GetUserTypeByID(int userTypeID)
        {
            return userTypeDAL.GetUserTypeByID(userTypeID);
        }

        public bool UpdateUserType(UserTypeEntity userType)
        {
            if(userType.UserTypeID > 0)
            {
                //Update
                return userTypeDAL.UpdateUserType(userType);
            }
            else
            {
                //Insert
                return userTypeDAL.InsertUserType(userType);
            }
        }

        public bool IsUserTypeExist(string userType, int userTypeID)
        {
            return userTypeDAL.IsUserTypeExist(userType, userTypeID);
        }

        public bool DeleteUserType(int userType)
        {
            return userTypeDAL.DeleteUserType(userType);
        }
    }
}
