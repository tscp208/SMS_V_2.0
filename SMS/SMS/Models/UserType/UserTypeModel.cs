using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SMS.Models.UserType
{
    public class UserTypeModel
    {
        public UserTypeModel()
        {
            CreatedBy = 1;
            CreatedOn = DateTime.Now.ToString();
            ModifiedBy = 1;
            ModifiedOn = DateTime.Now.ToString();
        }

        public int UserTypeID { get; set; }

        [Required(ErrorMessage = "User Type Required.!")]
        [Display(Name = "User Type")]
        [Remote("IsUserTypeExist", "UserType", AdditionalFields = "UserTypeID", ErrorMessage = "User Type already Exist..!")]
        public string UserTypeName { get; set; }

        [Display(Name = "Description")]
        public string UserTypeDesc { get; set; }

        public int CreatedBy { get; set; }

        public string CreatedOn { get; set; }

        public int ModifiedBy { get; set; }

        public string ModifiedOn { get; set; }

        public bool IsDeleted { get; set; }
    }

    public class UserTypeViewModel
    {
        public int UserTypeID { get; set; }

        [Display(Name = "Sr. No")]
        public int SrNo { get; set; }

        [Display(Name = "User Type")]
        public string UserTypeName { get; set; }

        [Display(Name = "Description")]
        public string UserTypeDesc { get; set; }
    }
}