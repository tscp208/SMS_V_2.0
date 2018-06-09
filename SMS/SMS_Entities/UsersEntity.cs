using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMS_Entities
{

    public class UsersEntity
    {
        public int UserID { get; set; }
        public int SrNo { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; }
        public string Address { get; set; }
        public string State { get; set; }
        public string City { get; set; }
        public string ContactNo { get; set; }
        public string EmailAddress { get; set; }
        public string DOB { get; set; }
        public int UserTypeID { get; set; }
        public string UserTypeName { get; set; }
    }
}
