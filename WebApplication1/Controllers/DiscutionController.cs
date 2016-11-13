using Domain.entity;
using GUI.Models;
using WebApplication1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Pidev.Services;
using Domain;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Data;

namespace WebApplication1.Controllers
{
    public class DiscutionController : Controller
    {
        GroupColloServices G = new GroupColloServices();
        CollocationGroup g1;
        ApplicationDbContext context;
        DiscutionServices D = null;
        
        public DiscutionController()
        {
            context = new ApplicationDbContext();
            D = new DiscutionServices();
        }
        public ActionResult Index(int id)
        {
            // x = id;
           g1 = G.GetById(id);
            ViewBag.titre = g1.Title;
            ViewBag.id = g1.CollocationGroupId;
            int? x = Session["xx"] as int?;
            x = id;
            Session["xx"] = x;
            IEnumerable<DiscutionGroup> lstd = new List<DiscutionGroup>();
            lstd = D.GetAll();
            var   lstd2 = lstd.Where(s=> s.CollocationGroupId == id );
           
            return View(lstd2);


        }
        [HttpPost]
        public ActionResult Index(String textarea )
        {
            ICollection<DiscutionGroup> lstd = new List<DiscutionGroup>();
            // lstd = G.GetById(id).DiscutionGroupList;
            int? x = Session["xx"] as int?;

            if (!String.IsNullOrEmpty(textarea))
            {

                DiscutionGroup d = new DiscutionGroup()
                { UserIden = getCurrentUser().Id,
                    //collocationGroup = g1,
                    CollocationGroupId = (int)x,
                    Text = textarea
                };

                D.Add(d);

              
                D.Commit();

                //lstd.Add(d);
            }

            return RedirectToAction("Index/" + x);

        }
        public ActionResult search(string text)
        {
          var s=  D.search(text);

            return View (s);
        }
        public User getCurrentUser()
        {
            var UserManager = new UserManager<User>(new UserStore<User>(context));
            var user = UserManager.FindById(User.Identity.GetUserId());
            return user;
        }

        // GET: Discution/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Discution/Create
        public ActionResult Create( )
        {
            return View();
        }

        // POST: Discution/Create
        [HttpPost]
        public ActionResult Create(DiscutionModel dm)
        {
            //DiscutionGroup d = new DiscutionGroup()
            //{
            //    CollocationGroupId = g1.CollocationGroupId,
            //    Text = dm.Text
            //};
           
            
            //D.Add(d);
            //D.Commit();

            return RedirectToAction("Index");
          
        }

        // GET: Discution/Edit/5
        public ActionResult Edit(int  id )
        {
           
            DiscutionGroup d1;
            d1 = D.GetById(id);
           
            // return RedirectToAction("Index/" + d1.CollocationGroupId);
            return View( d1);
        }

        // POST: Discution/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, string text)
        {

            DiscutionGroup d1;
            d1 = D.GetById(id);
            d1.Text = text;
            D.Update(d1);
            D.Commit();
            return RedirectToAction("Index/" + d1.CollocationGroupId);
           // return View();
        }

        // GET: Discution/Delete/5
        public ActionResult Delete(int id)
        {
            int? x = Session["xx"] as int?;
            D.Delete(D.GetById(id));
            D.Commit();
            return RedirectToAction("Index/" + (int)x);
        }
        public ActionResult Drag_and_drop()
        {


            return (View());
        }

        // POST: Discution/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
