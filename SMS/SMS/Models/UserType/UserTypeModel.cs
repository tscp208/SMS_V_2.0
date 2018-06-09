<<<<<<< HEAD
﻿using System;
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

        //[Display(Name = "Sr. No")]
        public int SrNo { get; set; }

        //[Display(Name = "User Type")]
        public string UserTypeName { get; set; }

        //[Display(Name = "Description")]
        public string UserTypeDesc { get; set; }
    }

    public class JQueryDataTableParams
    {
        /// <summary>
        /// Request sequence number sent by DataTable,
        /// same value must be returned in response
        /// </summary>       
        public string sEcho { get; set; }

        /// <summary>
        /// Text used for filtering
        /// </summary>
        public string sSearch { get; set; }

        /// <summary>
        /// Number of records that should be shown in table
        /// </summary>
        public int iDisplayLength { get; set; }

        /// <summary>
        /// First record that should be shown(used for paging)
        /// </summary>
        public int iDisplayStart { get; set; }

        /// <summary>
        /// Number of columns in table
        /// </summary>
        public int iColumns { get; set; }

        /// <summary>
        /// Number of columns that are used in sorting
        /// </summary>
        public int iSortingCols { get; set; }

        /// <summary>
        /// Comma separated list of column names
        /// </summary>
        public string sColumns { get; set; }

        /// <summary>
        /// Order no of the column that is used to do sorting
        /// </summary>
        public int iSortCol_0 { get; set; }

        /// <summary>
        /// Sort direction
        /// </summary>
        public string sSortDir_0 { get; set; }
    }
=======
﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SMS.Models.UserType
{
    public class UserTypeModel
    {
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
>>>>>>> harsh_branch
}