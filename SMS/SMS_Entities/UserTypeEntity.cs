using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMS_Entities
{
    public class UserTypeEntity
    {
        public int UserTypeID { get; set; }

        public int SrNo { get; set; }

        public string UserTypeName { get; set; }

        public string UserTypeDesc { get; set; }

        public int CreatedBy { get; set; }

        public string CreatedOn { get; set; }

        public int ModifiedBy { get; set; }

        public string ModifiedOn { get; set; }

        public bool IsDeleted { get; set; }
    }
}
