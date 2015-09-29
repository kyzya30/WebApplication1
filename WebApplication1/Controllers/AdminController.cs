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
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
   
    public class AdminController : Controller
    {
        public ActionResult Login()
        {
            return View();
        }

        public ActionResult Dishes() //Show all dishes on Dishes view                                         
        {
            using (var context = new SushiTest1Entities1())
            {
               List<AllDishes_Result> allDishesModel = context.AllDishes().ToList();
               return View(allDishesModel);
            }
        }

        public ActionResult DishesInBlock()                                      
        {
            using (var context = new SushiTest1Entities1())
            {
                List<AllDishes_Result> allDishesModel = context.AllDishes().ToList();
                return View(allDishesModel);
            }
        }

        public ActionResult Category() //Show all categories on Category view                   
        {
            using (var context = new SushiTest1Entities1())
            {
                List<ShowAllCategories_Result> allCategoriesModel = context.ShowAllCategories().ToList();
                return View(allCategoriesModel);
            }
        }

        [HttpGet]
        public ActionResult EditDish(int productId)
        {
           
            
            return View();
        }

        [HttpPost]
        public ActionResult AddCategory(Category newCategory) //Action from modal window AddCategory.cshtml, to add category to database
        {
            if (ModelState.IsValid)
            {
                using (var context = new SushiTest1Entities1())
                {
                    context.Categories.Add(newCategory);
                    context.SaveChanges();
                }
            }

            return RedirectToAction("Category", "Admin");
        }

        [HttpGet]
        public ActionResult AddNewDish()
        {
            var context = new SushiTest1Entities1();
            var category = context.Categories.ToList();
            ViewBag.Categories = category;
            return View();
        }

        [HttpPost]
        public ActionResult AddNewDish(string NameRus, string NameUkr, string isHided, int? dishCategory, byte? prod, int? Priority, decimal? Price, double? Weight, string Energy, 
            int? Count, string ingredientsTxtRus, string ingredientsTxtUkr, HttpPostedFileBase uploadPhoto)
        {
            var context = new SushiTest1Entities1();
            var products = context.Products.ToList();

            bool isHidedProduct = (isHided != null) ? false : true;

            if (Weight == null)
                Weight = 0;
            if (Count == null)
                Count = 0;

            context.AddProduct(dishCategory, NameRus, NameUkr, 0, Count, Energy, 0, Price, false, isHidedProduct, ingredientsTxtRus, ingredientsTxtUkr);
            context.SaveChanges();

            int fileName = context.Products.ToList().Last().ProductId;

            uploadPhoto.SaveAs(Server.MapPath("~/Content/Images/Products/" + fileName + ".jpeg"));
            return RedirectToAction("Dishes");
        }

        public ActionResult AddNewOrder()
        {

            return View();
        }

        public ActionResult Orders()
        {
            using (var context = new SushiTest1Entities1())
            {
                List<ShowAllOrders_Result> showAllOrdersModel = context.ShowAllOrders().ToList();
                return View(showAllOrdersModel);
            }
        }

        [HttpPost]
        public ActionResult FindDishes(Product product) //Find dishes on Dishes view
        {
            List<AllDishes_Result> allDishesModel = new List<AllDishes_Result>();
            if(ModelState.IsValid)
            {
                using (var context = new SushiTest1Entities1())
                {
                    List<FindDishes_Result> findDishesModel = context.FindDishes(product.NameRus).ToList();
                    for (int i = 0; i < findDishesModel.Count; i++) //Adding count for first model to be equal another model 
                    {
                        allDishesModel.Add(new AllDishes_Result());
                    }
                    for (int i = 0; i < findDishesModel.Count; i++) //Mapping findDishesModel to allDishesModel
                    {
                        allDishesModel[i].ProductId = findDishesModel[i].ProductId;
                        allDishesModel[i].NameRus = findDishesModel[i].NameRus;
                        allDishesModel[i].Priority = findDishesModel[i].Priority;
                        allDishesModel[i].Category = findDishesModel[i].Category;
                        allDishesModel[i].Weight = findDishesModel[i].Weight;
                        allDishesModel[i].NameOfWeight = findDishesModel[i].NameOfWeight;
                        allDishesModel[i].Price = findDishesModel[i].Price;
                        allDishesModel[i].TotalDishes = findDishesModel[i].TotalDishes;
                    }
                }
            }

            return View("~/Views/Admin/Dishes.cshtml", allDishesModel);
        }
        [HttpPost]
        public ActionResult FindCategory(Category category) //Find Categories on Category view
        {
            List<ShowAllCategories_Result> addCategoriesModel = new List<ShowAllCategories_Result>();
            if (ModelState.IsValid)
            {
                using (var context = new SushiTest1Entities1())
                {
                    List<FindCategory_Result> findCategoryModel = context.FindCategory(category.NameRus).ToList();
                    for (int i = 0; i < findCategoryModel.Count; i++) //Adding count for first model to be equal another model 
                    {
                        addCategoriesModel.Add(new ShowAllCategories_Result());
                    }
                    for (int i = 0; i < findCategoryModel.Count; i++) //Mapping findCategoryModel to AddCategoriesModel
                    {
                        addCategoriesModel[i].TotalCategories = findCategoryModel[i].TotalCategories;
                        addCategoriesModel[i].NameRus = findCategoryModel[i].NameRus;
                        addCategoriesModel[i].CategoryId = findCategoryModel[i].CategoryId;
                        addCategoriesModel[i].Priority = findCategoryModel[i].Priority;
                        addCategoriesModel[i].TotalDishes = findCategoryModel[i].TotalDishes;
                        addCategoriesModel[i].NameUkr = findCategoryModel[i].NameUkr;
                    }
                }
            }
            return View("~/Views/Admin/Category.cshtml", addCategoriesModel);
        }

        [HttpPost]
        public ActionResult FindOrders(Order order) //Find Orders on Orders view
        {
            List<ShowAllOrders_Result> allOrdersModel = new List<ShowAllOrders_Result>();
            if (ModelState.IsValid)
            {
                using (var contex = new SushiTest1Entities1())
                {
                    string orderId = order.OrderId.ToString(); //Value to find
                    List<FindOrders_Result> findOrdersModel = contex.FindOrders(orderId).ToList();
                    for (int i = 0; i < findOrdersModel.Count; i++) //Adding count for first model to be equal another model 
                    {
                        allOrdersModel.Add(new ShowAllOrders_Result());
                    }
                    for (int i = 0; i < findOrdersModel.Count; i++) //Mapping findOrdersModel to allOrdersModel
                    {
                        allOrdersModel[i].OrderId = findOrdersModel[i].OrderId;
                        allOrdersModel[i].Street = findOrdersModel[i].Street;
                        allOrdersModel[i].House = findOrdersModel[i].Street;
                        allOrdersModel[i].Room = findOrdersModel[i].Room;
                        allOrdersModel[i].MaxStatusTime = findOrdersModel[i].MaxStatusTime;
                        allOrdersModel[i].TotalPrice = findOrdersModel[i].TotalPrice;
                        allOrdersModel[i].StatusNameRus = findOrdersModel[i].StatusNameRus;
                    }
                }
            }

            return View("~/Views/Admin/Orders.cshtml", allOrdersModel);
        }

        [HttpPost]
        public ActionResult DeleteCategoryItem(int[] idSelected) //Action from modal window DeleteCategoryItem.cshtml, to del category from database
        {
            using (var context = new SushiTest1Entities1())
            {
                if (idSelected != null)// Check idSelected
                {
                    for(int i = 0; i < idSelected.Length; i++) // Find item to delete
                    {
                        int selectedIdItem = idSelected[i];
                       //var removedCategory = context.Categories.First(category => category.CategoryId == selectedIdItem);
                        context.DeleteCategory(selectedIdItem);
                    
                       // context.Categories.Remove(removedCategory);
                      //  context.SaveChanges();
                    }
                }
               //context.SaveChanges(); 
            }

            return RedirectToAction("Category", "Admin");
        }

        [HttpPost]
        public JsonResult HideDishModal(int[] idSelected) //Action from modal window HideDishModal, to hide dish from main page
        {
            if (ModelState.IsValid)
            {
                using (var context = new SushiTest1Entities1())
                {
                    for(int i = 0; i < idSelected.Length; i++) // Find item to hide
                    {
                        int selectedIdItem = idSelected[i];
                        //var hidedProduct = context.Products.First(product => product.ProductId == selectedIdItem);
                        context.HideDish(selectedIdItem);
                        //hidedProduct.IsHided = true;
                    }
                    //context.SaveChanges();
                }
            }

            return Json(new { Success = true, Url = Url.Action("Dishes", "Admin") });
        }

        [HttpPost]
        public JsonResult DeleteDishModal(int[] idSelected) //Action from modal window DeleteDishModal, to del dish
        {
            if (ModelState.IsValid)
            {
                using (var context = new SushiTest1Entities1())
                {
                    for(int i = 0; i < idSelected.Length; i++)//Delete related item from ProductWeightDetails
                    {
                        int selectedIdItem = idSelected[i];
                        context.DeleteProductWeightDetails(selectedIdItem);
                        //var removedItemFromProductWeightDetails = context.ProductWeightDetails.First(productWeightDetail => productWeightDetail.ProductId == selectedIdItem);
                       // context.ProductWeightDetails.Remove(removedItemFromProductWeightDetails);
                       // context.SaveChanges();
                    }
                    for(int i = 0; i < idSelected.Length; i++)// Del dish from table
                    {
                        int selectedIdItem = idSelected[i];
                        context.DeleteDish(selectedIdItem);
                        //var delProduct = context.Products.First(product => product.ProductId == selectedIdItem);
                       // context.Products.Remove(delProduct);
                        //context.SaveChanges();
                    }
                }
            }

            return Json(new { Success = true, Url = Url.Action("Dishes", "Admin") });
        }

        [HttpPost]
        public ActionResult ModifyCategoryModal(int CategoryId, string NameRus, string NameUkr, int Priority) //Action from modal window ModifyCategoryModal, to change category values
        {
            if (ModelState.IsValid)
            {
                using (var context = new SushiTest1Entities1())
                {
                    var updateSelectedCategoryValues = context.UpdateCategory(CategoryId, NameRus, NameUkr, Priority);
                    context.SaveChanges();
                }
            }
     
            return RedirectToAction("Category", "Admin");
        }

        [HttpPost]
        public ActionResult ChangeOrderStatus(int[] idSelected, int drpdwnVal) //Action from modal window CahngeOrderStatus to update ord.status
        {
            using (var context = new SushiTest1Entities1())
            {
                if (idSelected != null)
                {
                    for(int i = 0; i < idSelected.Length; i++)
                    {
                        context.InsertValOrdTimeCh(idSelected[i], drpdwnVal);
                    }
                }
            }
            return View();
        }

        [HttpPost]
        public ActionResult MostPopularDishesChangeValues(int? categoryId, int topCategoryVal)//Update Index view, selected val from partial view MostPopularDishes
        {
            using (var context = new SushiTest1Entities1())
            {
                var category = context.Categories.ToList();
                ViewBag.Categories = category;//Show all category on drpdwn partialView
                StatisticModel newStatisticModel = new StatisticModel //Create new model for Index view
                {
                    mostPopularDishes = context.MostPopularDishes(topCategoryVal, categoryId).ToList(),
                    showUnprocessedOrders = context.ShowUnprocessedOrders().ToList()
                };
                return View("~/Views/Admin/Index.cshtml", newStatisticModel);
            }

        }

        [HttpPost]
        public ActionResult DeleteOrderModal(int[] idSelected) //Action from this Modal to Del order
        {
            if (ModelState.IsValid)
            {
                using (var context = new SushiTest1Entities1())
                {
                    for(int i = 0; i < idSelected.Length; i++) //Del related item from table OrderDetails
                    {
                        string selectedItem = idSelected[i].ToString();
                        context.DelOrdersDetailsId(selectedItem);
                    }
                    for(int i = 0; i < idSelected.Length; i++) //Del related item from table OrderTimeChanged
                    {
                        string selectedItem = idSelected[i].ToString();
                        context.DelOrdersTimeChanged(selectedItem);
                    }
                    for(int i = 0; i < idSelected.Length; i++) //Del order
                    {
                        int selectedItem = idSelected[i];
                        context.DeleteOrder(selectedItem);
                        // var delOrder = context.Orders.First(order => order.OrderId == selectedItem);
                        //context.Orders.Remove(delOrder);
                        //context.SaveChanges();
                    }
                }
            }

            return View();
        }

        public ActionResult Index() //Show statistic in Index view
        {
            using (var context = new SushiTest1Entities1())
            {
                var category = context.Categories.ToList();
                ViewBag.Categories = category; //Show all categories on drpdwn Index view
                StatisticModel statisticModel = new StatisticModel 
                {
                    mostPopularDishes = context.MostPopularDishes(5, category[0].CategoryId).ToList(),
                    showUnprocessedOrders = context.ShowUnprocessedOrders().ToList()
                };

                return View(statisticModel);
            }
        }
    }
}