﻿using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Data.Entity;
using System.Dynamic;
using System.IO.MemoryMappedFiles;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Microsoft.Ajax.Utilities;
using EmitMapper;


namespace WebApplication1.Controllers
{
    public static class ExtensionClass
    {
        public static ExpandoObject ToExpando(this object anonymousObject)
        {
            IDictionary<string, object> anonymousDictionary = HtmlHelper.AnonymousObjectToHtmlAttributes(anonymousObject);

            IDictionary<string, object> expando = new ExpandoObject();

            foreach (var item in anonymousDictionary)
            {
                expando.Add(item);
            }
            return (ExpandoObject)expando;
        }
    }
    public class AdminController : Controller
    {
        // GET: Admin
        public ActionResult Orders()
        {
            return View();
        }

        public ActionResult Login()
        {  
            return View();
        }
        public async Task<ActionResult> Dishes()                                          //C# Homework Async/Await by R.Kuzmenko
        {                                                                                 //
            var context = new SushiTest1Entities1();                                      //
            var productWeightDetails =  await context.ProductWeightDetails.ToListAsync(); //
            List<AllDishes_Result> addDishes = context.AllDishes().ToList();
            return View(addDishes);
        }

        public async Task<ActionResult> Category()                      //C# Homework Async/Await by R.Kuzmenko
        {      
           
            var context = new SushiTest1Entities1();                    //
            var Product = await context.Products.ToListAsync();       //  
            var Category = await context.Categories.ToListAsync();      //
            var addCategories = context.ShowAllCategories().ToList();
            return View(addCategories);
        }

        [HttpPost]
        public ActionResult AddCategory(Category category)
        {
            if (ModelState.IsValid)
            {
                using (var context = new SushiTest1Entities1())
                {
                   
                    context.Categories.Add(category);
                    context.SaveChanges();
                    return RedirectToAction("Category", "Admin");
                }
            }
            return RedirectToAction("Category", "Admin");
        }

        public ActionResult AddNewDish()
        {
            var context = new SushiTest1Entities1();                    
            var Category = context.Categories.ToList();




            ViewBag.Categories = Category;


            return View();
        }

        public ActionResult AddNewOrder()
        {
            return View();
        }


        [HttpPost]
        public ActionResult FindDishes(Product product)
        {
            List<AllDishes_Result> allD = new List<AllDishes_Result>();

            if (ModelState.IsValid)
            {
                using (var context = new SushiTest1Entities1())
                {
                    List<FindDishes_Result> c = context.FindDishes(product.NameRus).ToList();
                    for (int i = 0; i < c.Count; i++)
                    {
                        allD.Add(new AllDishes_Result());
                    }
                    for (int i = 0; i < c.Count; i++)
                    {
                        allD[i].ProductId = c[i].ProductId;
                        allD[i].NameRus = c[i].NameRus;
                        allD[i].Priority = c[i].Priority;
                        allD[i].Category = c[i].Category;
                        allD[i].Weight = c[i].Weight;
                        allD[i].NameOfWeight = c[i].NameRus;
                        allD[i].Price = c[i].Price;
                        allD[i].TotalDishes = c[i].TotalDishes;
                    }
                }
            }
            return View("~/Views/Admin/Dishes.cshtml", allD);
        }
        [HttpPost]
        public ActionResult FindCategory(Category category)
        {
            List<ShowAllCategories_Result> addCategories = new List<ShowAllCategories_Result>();
            if (ModelState.IsValid)
            {
                using (var context = new SushiTest1Entities1())
                {
                    List<FindCategory_Result> findCategory = context.FindCategory(category.NameRus).ToList();
                    for (int i = 0; i < findCategory.Count; i++)
                    {
                        addCategories.Add(new ShowAllCategories_Result());
                    }
                    for (int i = 0; i < findCategory.Count; i++)
                    {
                        addCategories[i].TotalCategories = findCategory[i].TotalCategories;
                        addCategories[i].NameRus = findCategory[i].NameRus;
                        addCategories[i].CategoryId = findCategory[i].CategoryId;
                        addCategories[i].Priority = findCategory[i].Priority;
                        addCategories[i].TotalDishes = findCategory[i].TotalDishes;
                    }
                }

            }
             return View("~/Views/Admin/Category.cshtml", addCategories);
        }
        [HttpPost]
        public ActionResult ModifyCategoryModal(Category category)
        {
            if (ModelState.IsValid)
            {
                using (var context = new SushiTest1Entities1())
                {
                    var d = context.Categories.First(i => i.NameRus == category.NameRus);
                    d.Priority = category.Priority;
                    context.SaveChanges();
                  
                }
            }
            return RedirectToAction("Category", "Admin");
           // return View();
        }

        public  ActionResult Index()
        {
            var context = new SushiTest1Entities1();
            var showUnprocessedOrders = context.ShowUnprocessedOrders().ToList();
            
            var Products = context.Products.ToList();
            ViewBag.List1 = showUnprocessedOrders;

            var mostPopularDishes =
                (from _Product in Products
                 where
                     _Product.CategoryId == 1
                 orderby
                     _Product.NumberOfOrders descending
                 select new
                 {
                     _Product.NumberOfOrders,
                     _Product.ProductId,
                     _Product.NameRus,
                     _Product.Price
                 }.ToExpando()).Take(5);
            object T2 = mostPopularDishes.ToList();
            ViewBag.MostPopularDishes = T2;

            return View();

           
        }

    }
}