using Newtonsoft.Json;
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
            int totalRecords = 0;
            return PartialView("_UserTypeGrid", GetUserTypes(1, 5, "Srno", "asc",out totalRecords));
        }

        public List<UserTypeViewModel> GetUserTypes(int start, int length, string sortColumn, string sortDir, out int totalRecords)
        {
            List<UserTypeViewModel> userTypes = new List<UserTypeViewModel>();
            List<UserTypeEntity> userTypeEntities = new List<UserTypeEntity>();
            try
            {
                userTypeEntities = userTypeBAL.GetUserTypes(start, length, sortColumn, sortDir,out totalRecords);
                userTypes = AutoMapper.Mapper.Map<List<UserTypeEntity>, List<UserTypeViewModel>>(userTypeEntities);

                return userTypes;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                userTypes = null;
                userTypeEntities = null;
            }
        }

        [HttpGet]
        public ActionResult AddUserType(int userTypeID = 0)
        {
            UserTypeEntity userTypeEntity = new UserTypeEntity();
            UserTypeModel userTypeModel = new UserTypeModel();
            try
            {
                if (userTypeID > 0)
                {
                    userTypeEntity = userTypeBAL.GetUserTypeByID(userTypeID);
                    userTypeModel = AutoMapper.Mapper.Map<UserTypeEntity, UserTypeModel>(userTypeEntity);

                    return PartialView("_AddUserType", userTypeModel);
                }
                else
                {
                    return PartialView("_AddUserType", new UserTypeModel());
                }
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                userTypeEntity = null;
                userTypeModel = null;
            }
        }

        [HttpPost]
        public JsonResult AddUserType(UserTypeModel userTypeModel)
        {
            UserTypeEntity userTypeEntity = new UserTypeEntity();
            userTypeEntity = AutoMapper.Mapper.Map<UserTypeModel, UserTypeEntity>(userTypeModel);

            bool status = userTypeBAL.UpdateUserType(userTypeEntity);

            if (status)
            {
                if (userTypeModel.UserTypeID > 0)
                    return Json(new { Message = "User Type Updated Successfully..!", Status = status }, JsonRequestBehavior.AllowGet);
                else
                    return Json(new { Message = "User Type Added Successfully..!", Status = status }, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(new { Message = "Operation Failed..!", Status = status }, JsonRequestBehavior.AllowGet);
            }
        }

        public JsonResult IsUserTypeExist(string userTypeName, int userTypeID)
        {
            bool isExist = userTypeBAL.IsUserTypeExist(userTypeName, userTypeID);

            return Json(!isExist, JsonRequestBehavior.AllowGet);
        }

        public JsonResult DeleteUserType(int userTypeID)
        {
            bool status = userTypeBAL.DeleteUserType(userTypeID);

            if (status)
                return Json(new { Message = "User type Deleted Successfully..!", Status = true }, JsonRequestBehavior.AllowGet);
            else
                return Json(new { Message = "Operation Failed..!", Status = true }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult GetUserTypeData()
        {
            int totalRecords;
            int draw = Convert.ToInt32(Request.Form.GetValues("draw").FirstOrDefault());
            int start = Convert.ToInt32(Request.Form.GetValues("start").FirstOrDefault());
            int length = Convert.ToInt32(Request.Form.GetValues("length").FirstOrDefault());
            string sortColumn = Request.Form.GetValues("columns[" + Request.Form.GetValues("order[0][column]").FirstOrDefault() + "][name]").FirstOrDefault().ToString();
            string sortDir = Request.Form.GetValues("order[0][dir]").FirstOrDefault().ToString();
            List<UserTypeViewModel> userTypes = new List<UserTypeViewModel>();
            try
            {   
                userTypes = GetUserTypes(start, length, sortColumn, sortDir, out totalRecords);

                //string search = Request.QueryString["search[value]"];
                //int sortColumn = -1;
                //string sortDirection = "asc";
                //if (length == -1)
                //{
                //    length = TOTAL_ROWS;
                //}

                //// note: we only sort one column at a time
                //if (Request.QueryString["order[0][column]"] != null)
                //{
                //    sortColumn = int.Parse(Request.QueryString["order[0][column]"]);
                //}
                //if (Request.QueryString["order[0][dir]"] != null)
                //{
                //    sortDirection = Request.QueryString["order[0][dir]"];
                //}

                //DataTableData dataTableData = new DataTableData();
                //dataTableData.draw = draw;
                //dataTableData.recordsTotal = TOTAL_ROWS;
                //int recordsFiltered = 0;
                //dataTableData.data = FilterData(ref recordsFiltered, start, length, search, sortColumn, sortDirection);
                //dataTableData.recordsFiltered = recordsFiltered;

                return Json(new { draw = draw, recordsTotal = totalRecords, recordsFiltered = totalRecords, data = userTypes }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                
                throw;
            }
            finally
            {   
                userTypes = null;

            }
        }
    }
}