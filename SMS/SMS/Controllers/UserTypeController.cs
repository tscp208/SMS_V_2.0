using SMS.Models.UserType;
using SMS_BAL;
using SMS_Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace SMS.Controllers
{
    public class UserTypeController : Controller
    {
        public UserTypeBAL userTypeBAL = new UserTypeBAL();
        // GET: UserType
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult UserTypeGrid()
        {
            return PartialView("_UserTypeGrid", GetUserTypes());
        }

        public List<UserTypeViewModel> GetUserTypes()
        {
            List<UserTypeViewModel> userTypes = new List<UserTypeViewModel>();
            List<UserTypeEntity> userTypeEntities = new List<UserTypeEntity>();

            userTypeEntities = userTypeBAL.GetUserTypes();

            userTypes = userTypeEntities.Select(item => new UserTypeViewModel()
                        {
                            UserTypeID = item.UserTypeID,
                            SrNo = item.SrNo,
                            UserTypeName = item.UserTypeName,
                            UserTypeDesc = item.UserTypeDesc
                        }).ToList();

            return userTypes;
        }

        [HttpGet]
        public ActionResult AddUserType(int userTypeID = 0)
        {
            if(userTypeID > 0)
            {
                UserTypeEntity userTypeEntity = new UserTypeEntity();
                userTypeEntity = userTypeBAL.GetUserTypeByID(userTypeID);

                UserTypeModel userTypeModel = new UserTypeModel();
                userTypeModel.UserTypeID = userTypeEntity.UserTypeID;
                userTypeModel.UserTypeName = userTypeEntity.UserTypeName;
                userTypeModel.UserTypeDesc = userTypeEntity.UserTypeDesc;                
                
                return PartialView("_AddUserType", userTypeModel);
            }
            else
            {
                return PartialView("_AddUserType", new UserTypeModel());
            }
        }

        [HttpPost]
        public JsonResult AddUserType(UserTypeModel userTypeModel)
        {
            UserTypeEntity userTypeEntity = new UserTypeEntity();
            userTypeEntity.UserTypeID = userTypeModel.UserTypeID;
            userTypeEntity.UserTypeName = userTypeModel.UserTypeName;
            userTypeEntity.UserTypeDesc = userTypeModel.UserTypeDesc;
            userTypeEntity.CreatedBy = 1;
            userTypeEntity.CreatedOn = DateTime.Now.ToString();
            userTypeEntity.ModifiedBy = 1;
            userTypeEntity.ModifiedOn = DateTime.Now.ToString();
            userTypeEntity.IsDeleted = false;

            bool status = userTypeBAL.UpdateUserType(userTypeEntity);

            if (status)
            {
                if(userTypeModel.UserTypeID > 0)
                    return Json(new { Message = "User Type Updated Successfully..!", Status = status}, JsonRequestBehavior.AllowGet);
                else
                    return Json(new { Message = "User Type Added Successfully..!", Status = status }, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(new { Message = "Operation Failed..!", Status = status}, JsonRequestBehavior.AllowGet );
            }
        }

        public JsonResult IsUserTypeExist(string userTypeName, int userTypeID)
        {
            bool isExist = userTypeBAL.IsUserTypeExist(userTypeName,userTypeID);

            return Json(!isExist, JsonRequestBehavior.AllowGet);
        }

        public JsonResult DeleteUserType(int userTypeID)
        {
            bool status = userTypeBAL.DeleteUserType(userTypeID);

            if(status)
                return Json(new { Message = "User type Deleted Successfully..!", Status = true }, JsonRequestBehavior.AllowGet);
            else
                return Json(new { Message = "Operation Failed..!", Status = true }, JsonRequestBehavior.AllowGet);
        }
        
    }
}