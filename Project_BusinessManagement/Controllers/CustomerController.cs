﻿using Bll_Business;
using BO_BusinessManagement;
using IBusiness.Management;
using Project_BusinessManagement.Filters;
using System;
using System.Collections.Generic;
using System.Web.Mvc;
using IBusiness.Common;

namespace Project_BusinessManagement.Controllers
{
    [Authorize(Roles = "Administrador, Cajero")]
    [ConfigurationApp( pParameter:"IsCustomer")]
    public class CustomerController : Controller
    {
        #region Variables and Constants
        public ICustomer LCustomerFacade =
        FacadeProvider.Resolver<BllCustomer>();

        public static ITypeIdentification LiTypeIdentification =
        FacadeProvider.Resolver<BllTypeIdentification>();
        
        #endregion
        // GET: Customer
        public ActionResult Index()
        {
            List<Bo_Customer> oBListCustomer = new List<Bo_Customer>();
            oBListCustomer = this.LCustomerFacade.bll_GetAllCustomer();

            return View(Models.MCustomer.MListCustomer(oBListCustomer));
        }

        // GET: Customer/Details/5
        public ActionResult Details(int id)
        {
            var oBCustomer = this.LCustomerFacade.bll_GetCustomerById(id);
            return View(Models.MCustomer.MCustomerById(oBCustomer));
        }

        [ConfigurationApp(pParameter: "CreateCustomer")]
        // GET: Customer/Create
        public ActionResult Create()
        {
            var oBCustomer= new Bo_Customer();
            return View(Models.MCustomer.MCustomerEmpty(oBCustomer));
        }

        // POST: Customer/Create
        [HttpPost]
        public ActionResult Create(Models.MCustomer pMCustomer)
        {
            try
            {
                if (this.ModelState.IsValid)
                {
                    string lMessage = this.LCustomerFacade.bll_InsertCustomer(Request.Form["LNameCustomer"].ToString(), Request.Form["LLastNameCustomer"].ToString(), Request.Form["LNoIdentification"].ToString(), Convert.ToInt32(Request.Form["LTypeIdentification.LIdTypeIdentification"].ToString()), Convert.ToInt32(Request.Form["LObject.LIdObject"].ToString()), Request.Form["LStatus.LIdStatus"].ToString());
                    if (lMessage == null)
                    {
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        pMCustomer.LMessageException = lMessage;
                        ListEmptyCustomer(pMCustomer);
                        return View(pMCustomer);
                    }

                }
                else
                {
                    ListEmptyCustomer(pMCustomer);
                    return View(pMCustomer);
                }

            }
            catch (Exception e)
            {
                pMCustomer.LMessageException = e.Message;
                ListEmptyCustomer(pMCustomer);
                return View(pMCustomer);
            }
        }

        [ConfigurationApp(pParameter: "EditCustomer")]
        // GET: Customer/Edit/5
        public ActionResult Edit(int id)
        {
            var oBCustomer = this.LCustomerFacade.bll_GetCustomerById(id);
            return View(Models.MCustomer.MCustomerById(oBCustomer));
        }

        // POST: Customer/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Models.MCustomer pMCustomer)
        {
            try
            {
                if (this.ModelState.IsValid)
                {
                    var lMessage = this.LCustomerFacade.bll_UpdateCustomer(id, this.Request.Form["LNameCustomer"].ToString(), Request.Form["LLastNameCustomer"].ToString(), this.Request.Form["LNoIdentification"].ToString(), Convert.ToInt32(this.Request.Form["LTypeIdentification.LIdTypeIdentification"].ToString()), Convert.ToInt32(this.Request.Form["LObject.LIdObject"].ToString()), this.Request.Form["LStatus.LIdStatus"].ToString());
                    if (lMessage == null)
                    {
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        pMCustomer.LMessageException = lMessage;
                        ListEmptyCustomer(pMCustomer);
                        return View(pMCustomer);
                    }
                }
                else
                {
                    ListEmptyCustomer(pMCustomer);
                    return View(pMCustomer);
                }

            }
            catch (Exception e)
            {
                pMCustomer.LMessageException = e.Message;
                ListEmptyCustomer(pMCustomer);
                return View(pMCustomer);
            }
        }

        private static void ListEmptyCustomer(Models.MCustomer pMCustomer)
        {
            pMCustomer.LListTypeIdentification = new List<SelectListItem>();
            pMCustomer.LListTypeIdentification = Models.MTypeIdentification.MListAllTypeIdentification(LiTypeIdentification.bll_getListTypeIdentification());
            pMCustomer.LListStatus = new List<SelectListItem>();
        }



        [ConfigurationApp(pParameter: "DeleteCustomer")]
        // GET: Customer/Delete/5
        public ActionResult Delete(int id)
        {
            var oBCustomer = this.LCustomerFacade.bll_GetCustomerById(id);
            return View(Models.MCustomer.MCustomerById(oBCustomer));
        }

        // POST: Customer/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, Models.MCustomer pMCustomer)
        {
            try
            {
                var lMessage = this.LCustomerFacade.bll_DeleteCustomer(id);
                if (lMessage == null)
                {                   
                    return RedirectToAction("Index");
                }
                else
                {
                    pMCustomer.LMessageException = lMessage;
                    return View(pMCustomer);
                }

            }
            catch (Exception e)
            {
                pMCustomer.LMessageException = e.Message;
                return View(pMCustomer);
            }
        }
    }
}
