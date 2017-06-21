﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BO_BusinessManagement;
using Bll_Business;

namespace Project_BusinessManagement.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        public ActionResult Index()
        {
            List<Bo_Product> oBListProduct = new List<Bo_Product>();
            oBListProduct = Bll_Product.bll_GetAllProduct();
            return View(Models.MProduct.MListSupplier(oBListProduct));
        }

        // GET: Product/Details/5
        public ActionResult Details(int id)
        {
            Bo_Product oBProduct = new Bo_Product();
            oBProduct = Bll_Product.bll_GetProductById(id);
            return View(Models.MProduct.MProductById(oBProduct));
        }

        // GET: Product/Create
        public ActionResult Create()
        {
            Bo_Product oBProduct = new Bo_Product();
            return View(Models.MProduct.MProductEmpty(oBProduct));
        }

        // POST: Product/Create
        [HttpPost]
        public ActionResult Create(Models.MProduct pMProduct)
        {
            try
            {
                ModelState.Remove("LSupplier.LNameSupplier");
                ModelState.Remove("LSupplier.LNoIdentification");
                if (ModelState.IsValid)
                {
                    string lMessage = Bll_Product.bll_InsertProduct(Request.Form["LNameProduct"].ToString(), Convert.ToDecimal(Request.Form["LValue"]), Convert.ToDecimal(Request.Form["LValueSupplier"]), Convert.ToInt32(Request.Form["LUnit.LIdUnit"].ToString()), Convert.ToInt32(Request.Form["LSupplier.LIdSupplier"].ToString()), Convert.ToInt32(Request.Form["LObject.LIdObject"].ToString()), Request.Form["LStatus.LIdStatus"].ToString());
                    if (lMessage == null)
                    {
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        ListEmptyProduct(pMProduct);
                        pMProduct.LMessageException = lMessage;
                        return View(pMProduct);
                    }

                }
                else
                {
                    ListEmptyProduct(pMProduct);
                    return View(pMProduct);
                }

            }
            catch (Exception e)
            {
                ListEmptyProduct(pMProduct);
                pMProduct.LMessageException = e.Message;
                return View(pMProduct);
            }
        }

        // GET: Product/Edit/5
        public ActionResult Edit(int id)
        {
            Bo_Product oBProduct = new Bo_Product();
            oBProduct = Bll_Product.bll_GetProductById(id);
            return View(Models.MProduct.MProductById(oBProduct));
        }

        // POST: Product/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Models.MProduct pMProduct)
        {
            try
            {
                Bo_Product oBProduct = new Bo_Product();
                oBProduct = Bll_Product.bll_GetProductById(id);
                ModelState.Remove("LSupplier.LNameSupplier");
                ModelState.Remove("LSupplier.LNoIdentification");
                if (ModelState.IsValid)
                {
                    string lMessage = Bll_Product.bll_UpdateProduct(id, Request.Form["LNameProduct"].ToString(), Convert.ToDecimal(Request.Form["LValue"]), Convert.ToDecimal(Request.Form["LValueSupplier"]), Convert.ToInt32(Request.Form["LUnit.LIdUnit"].ToString()), Convert.ToInt32(Request.Form["LSupplier.LIdSupplier"].ToString()), Convert.ToInt32(Request.Form["LObject.LIdObject"].ToString()), Request.Form["LStatus.LIdStatus"].ToString());
                    if (lMessage == null)
                    {
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        pMProduct.LMessageException = lMessage;
                        return View(Models.MProduct.MProductById(oBProduct));
                    }

                }
                else
                {
                    return View(Models.MProduct.MProductById(oBProduct));
                }
            }
            catch(Exception e)
            {
                Bo_Product oBProduct = new Bo_Product();
                oBProduct = Bll_Product.bll_GetProductById(id);
                Models.MProduct lMProduct = new Models.MProduct();
                lMProduct = Models.MProduct.MProductById(oBProduct);
                lMProduct.LNameProduct = pMProduct.LNameProduct;
                lMProduct.LValue = pMProduct.LValue;
                lMProduct.LValueSupplier = pMProduct.LValueSupplier;
                lMProduct.LSupplier.LIdSupplier = pMProduct.LSupplier.LIdSupplier;
                lMProduct.LMessageException = e.Message;
                return View(lMProduct);
            }
        }

        // GET: Product/Delete/5
        public ActionResult Delete(int id)
        {
            Bo_Product oBProduct = new Bo_Product();
            oBProduct = Bll_Product.bll_GetProductById(id);
            return View(Models.MProduct.MProductById(oBProduct));
        }

        // POST: Product/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, Models.MProduct pMProduct)
        {
            try
            {
                string lMessage = Bll_Product.bll_DeleteProduct(id);
                if(lMessage == null)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    pMProduct.LMessageException = lMessage;
                    return View(pMProduct);
                }
                
            }
            catch(Exception e)
            {
                pMProduct.LMessageException = e.Message;
                return View(pMProduct);
            }
        }

        private static void ListEmptyProduct(Models.MProduct pMProduct)
        {
            pMProduct.LListSupplier = new List<SelectListItem>();
            pMProduct.LListSupplier = Models.MSupplier.MListAllSupplierWithSelect(Bll_Supplier.bll_GetAllSupplier());
            pMProduct.LListUnit = new List<SelectListItem>();
            pMProduct.LListUnit = Models.MUnit.MListAllUnitWithSelect(Bll_UtilsLib.bll_GetAllUnit());
            pMProduct.LListStatus = new List<SelectListItem>();
            pMProduct.LListStatus = Models.MStatus.MListAllStatus(Bll_Status.Bll_getListStatusByIdObject(pMProduct.LObject.LIdObject));
        }
    }
}
