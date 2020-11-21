using ASP.NETSaturdayProject.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ASP.NETSaturdayProject.Controllers
{
    public class FoodController : Controller
    {

        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\rohan\Documents\DBFoodManager.mdf;Integrated Security=True;Connect Timeout=30");

        public List<Food> GetFoodData()
        {
            SqlCommand cmd = new SqlCommand("Select * from TBLFoods", con);

            List<Food> foods = new List<Food>();

            con.Open();

            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Food temp = new Food();
                temp.id = reader.GetInt32(0);
                temp.name = reader.GetString(1);
                temp.cuisine = reader.GetString(2);
                temp.price = reader.GetDecimal(3);
                temp.Quantity = reader.GetInt32(4);

                foods.Add(temp);
            }

            con.Close();

            return foods;
        }

        public ActionResult GetFoods()
        {
            return View("FoodsList", GetFoodData());
        }

        public ActionResult GotoInsert()
        {
            return View("InsertFood");
        }

        public ActionResult InsertFood(Food f)
        {
            if (ModelState.IsValid)
            {
                SqlCommand cmd = new SqlCommand("insert into TBLFoods values ('" + f.name + "','" + f.cuisine + "'," + f.price + "," + f.Quantity + ")", con);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();

                return RedirectToAction("GetFoods");
            }
            else
            {
                return View("InsertFood");
            }
        }

        public ActionResult GotoVDA()
        {
            return View("VDAView", GetFoodData());
        }

        public ActionResult DeleteClickedVDA(Food f)
        {
            SqlCommand cmd = new SqlCommand("DELETE from TBLFoods where id="+f.id, con);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            return View("VDAView", GetFoodData());
        }

        public ActionResult InsertFoodVDA(Food f)
        {
            SqlCommand cmd = new SqlCommand("insert into TBLFoods values ('" + f.name + "','" + f.cuisine + "'," + f.price + "," + f.Quantity + ")", con);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();

            return View("VDAView", GetFoodData());
        }

        public ActionResult Sorting(sorting s)
        {
            List<Food> foods = GetFoodData();

            for (int i = 0; i < foods.Count; ++i)
            {
                for (int j = i + 1; j < foods.Count; ++j)
                {
                    if(s.SortName == "ID")
                    {
                        if(s.dsort)
                        {
                            List<Food> SortedList = foods.OrderByDescending(o => o.id).ToList();
                            foods = SortedList;
                        }
                        else
                        {
                            List<Food> SortedList = foods.OrderBy(o => o.id).ToList();
                            foods = SortedList;
                        }
                    }
                    if (s.SortName == "NAME")
                    {
                        if (s.dsort)
                        {
                            List<Food> SortedList = foods.OrderByDescending(o => o.name).ToList();
                            foods = SortedList;
                        }
                        else
                        {
                            List<Food> SortedList = foods.OrderBy(o => o.name).ToList();
                            foods = SortedList;
                        }
                    }
                    if (s.SortName == "CUISINE")
                    {
                        if (s.dsort)
                        {
                            List<Food> SortedList = foods.OrderByDescending(o => o.cuisine).ToList();
                            foods = SortedList;
                        }
                        else
                        {
                            List<Food> SortedList = foods.OrderBy(o => o.cuisine).ToList();
                            foods = SortedList;
                        }
                    }
                    if (s.SortName == "PRICE")
                    {
                        if (s.dsort)
                        {
                            List<Food> SortedList = foods.OrderByDescending(o => o.price).ToList();
                            foods = SortedList;
                        }
                        else
                        {
                            List<Food> SortedList = foods.OrderBy(o => o.price).ToList();
                            foods = SortedList;
                        }
                    }
                    if (s.SortName == "QUANTITY")
                    {
                        if (s.dsort)
                        {
                            List<Food> SortedList = foods.OrderByDescending(o => o.Quantity).ToList();
                            foods = SortedList;
                        }
                        else
                        {
                            List<Food> SortedList = foods.OrderBy(o => o.Quantity).ToList();
                            foods = SortedList;
                        }
                    }
                }
            }

            return View("VDAView", foods);
        }
    }
}