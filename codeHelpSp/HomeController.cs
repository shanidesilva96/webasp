using CustomerManageSystemAFC.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CustomerManageSystemAFC.Controllers
{
    public class HomeController : Controller
    {
        DataAccessLayer.Database dbLayer = new DataAccessLayer.Database();

        //Get All
        public ActionResult getAll()
        {
            DataSet ds = dbLayer.getAll();
            ViewBag.Customer = ds.Tables[0];
            return View();
        }


        public JsonResult GetByNIC(string NIC)
        {
            CustomerAPIController obj = new CustomerAPIController();
            DataSet ds = dbLayer.getAll();
            var o =obj.GetByNIC(NIC);
            //ViewBag.Customer = ds.Tables[0];
            return Json(o,JsonRequestBehavior.AllowGet
                );
        }

        //Add New Customer
        public ActionResult addNewCustomer(Customer model)
        {
            model.Birthday = DateTime.Now;
            return View(model);
        }

        //Load For Edit
        public ActionResult Edit(int CustomerID)
        {
            Customer model = new Customer();

            DataSet ds = dbLayer.getById(CustomerID);
            ViewBag.Customer = ds.Tables[0];

            foreach (System.Data.DataRow dr in ViewBag.Customer.Rows)
            {
                model.customerID = Convert.ToInt32(dr["CustomerID"]);
                model.FName = dr["FName"].ToString();
                model.LName = dr["LName"].ToString();
                model.NIC = dr["NIC"].ToString();
                model.MobileNo = Convert.ToInt32(dr["MobileNo"]);
                model.Email = dr["Email"].ToString();
                model.Birthday = Convert.ToDateTime(dr["Birthday"]);
                model.Address = dr["Address"].ToString();
            }
            return RedirectToAction("addNewCustomer", model);
        }

        //Update New Customer
        public ActionResult addOrUpdateCustomer(Customer model)
        {
            if (model.customerID == null)
            {
                dbLayer.addCustomer(model);
            }
            else
            {
                dbLayer.updateCustomer(model);
            }

            return RedirectToAction("getAll");
        }

    }
}