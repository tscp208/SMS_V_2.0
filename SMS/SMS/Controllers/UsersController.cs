using SMS.Models.Users;
using SMS_BAL;
using SMS_Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SMS.Controllers
{
    public class UsersController : Controller
    {
        public UsersBAL userBAL = new UsersBAL();

        // GET: Users
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetUsers()
        {
            List<UsersViewModel> users = new List<UsersViewModel>();
            List<UsersEntity> userentity = new List<UsersEntity>();

            userentity = userBAL.GetUsers();
            users = userentity.Select(item => new UsersViewModel
            {
                UserID = item.UserID,
                SrNo = item.SrNo,
                UserName = item.UserName,
                FirstName = item.FirstName,
                LastName = item.LastName,
                Address = item.Address,
                Gender = item.Gender,
                State = item.State,
                City = item.City,
                ContactNo = item.ContactNo,
                Email = item.EmailAddress
            }
                                 ).ToList();
            return PartialView("_GetUsers", users);

        }

        [HttpGet]
        public ActionResult InsertUser(int UserID = 0)
        {
            if (UserID > 0)
            {
                UsersEntity userEntity = new UsersEntity();
                userEntity = userBAL.GetUsersByID(UserID);

                UsersModel umodel = new UsersModel();
                umodel.UserID = userEntity.UserID;
                umodel.UserName = userEntity.UserName;
                umodel.FirstName = userEntity.FirstName;
                umodel.LastName = userEntity.LastName;
                umodel.Address = userEntity.Address;
                umodel.Gender = userEntity.Gender;
                umodel.State = userEntity.State;
                umodel.City = userEntity.City;
                umodel.ContactNo = userEntity.ContactNo;
                umodel.Email = userEntity.EmailAddress;

                return PartialView("_InsertUser", umodel);
            }
            else
            {
                return PartialView("_InsertUser", new UsersModel());
            }
        }

        [HttpPost]
        public JsonResult InsertUser(UsersModel userModel)
        {
            UsersEntity userEntity = new UsersEntity();
            userEntity.UserID = userModel.UserID;
            userEntity.UserName = userModel.UserName;
            userEntity.FirstName = userModel.FirstName;
            userEntity.LastName = userModel.LastName;
            userEntity.State = userModel.State;
            userEntity.City = userModel.City;
            userEntity.Address = userModel.Address;
            userEntity.ContactNo = userModel.ContactNo;
            userEntity.EmailAddress = userModel.Email;
            userEntity.Gender = userModel.Gender;

            bool status = userBAL.UsersUpdateInsert(userEntity);
            if (status)
            {
                if (userModel.UserID > 0)
                    return Json(new { Message = "User updated successfully." }, JsonRequestBehavior.AllowGet);
                else
                    return Json(new { Message = "User created successfully." }, JsonRequestBehavior.AllowGet);

            }
            else
            {
                return Json(new { Message = "Operation Failed..!", Status = status }, JsonRequestBehavior.AllowGet);
            }
        }

        public JsonResult DeleteUser(int UserID)
        {
            bool status = userBAL.UsersDelete(UserID);

            if (status)
                return Json(new { Message = "User deleted successfully." }, JsonRequestBehavior.AllowGet);
            else
                return Json(new { Message = "Operation failed." }, JsonRequestBehavior.AllowGet);

        }
    }
}