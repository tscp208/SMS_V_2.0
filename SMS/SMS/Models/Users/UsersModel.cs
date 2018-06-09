using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SMS.Models.Users
{
    public class UsersModel
    {
        public int UserID { get; set; }

        [Required]
        [Display(Name = "User Name")]
        public string UserName { get; set; }

        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Display(Name = "Address")]
        public string Address { get; set; }

        public string Gender { get; set; }

        public string State { get; set; }

        public string City { get; set; }

        [Display(Name = "Contact No.")]
        public string ContactNo { get; set; }


        public string Email { get; set; }

    }

    public class UsersViewModel
    {
        public int UserID { get; set; }

        [Display(Name = "Sr. No")]
        public int SrNo { get; set; }

        [Display(Name = "User Name")]
        public string UserName { get; set; }

        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Display(Name = "Address")]
        public string Address { get; set; }

        public string Gender { get; set; }

        public string State { get; set; }

        public string City { get; set; }

        [Display(Name = "Contact No.")]
        public string ContactNo { get; set; }

        public string Email { get; set; }
    }
}