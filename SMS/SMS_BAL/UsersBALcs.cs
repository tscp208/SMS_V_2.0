﻿using SMS_DAL;
using SMS_Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMS_BAL
{
    public class UsersBAL
    {
        public UsersDAL userdal = new UsersDAL();

        public List<UsersEntity> GetUsers()
        {
            return userdal.GetUsers();
        }

        public bool UsersUpdateInsert(UsersEntity userentity)
        {
            if (userentity.UserID > 0)
            {
                return true;
            }
            else
            {
                return userdal.InsertUsers(userentity);
            }
        }

    }
}