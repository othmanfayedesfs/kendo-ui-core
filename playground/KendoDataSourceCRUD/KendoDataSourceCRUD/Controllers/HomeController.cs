﻿using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using KendoDataSourceCRUD.Models;

namespace KendoDataSourceCRUD.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Batch()
        {
            return View();
        }

        public IEnumerable<Product> Products()
        {
            var products = (IEnumerable<Product>)Session["products"];

            if (products == null)
            {
                Session["products"] = products = new[] {
                    new Product
                    {
                        ID = 0,
                        Name = "Chai"
                    },
                    new Product
                    {
                        ID = 1,
                        Name = "Coffee"
                    }
                };
            }

            return products;
        }
				 
        public ActionResult Read()
        {
            return Json(Products(), JsonRequestBehavior.AllowGet);
        }

        public ActionResult UpdateProducts(IEnumerable<Product> products)
        {
            return Json(products);
        }

        public ActionResult Update(Product model)
        {
            return Json(model);
        }
    }
}