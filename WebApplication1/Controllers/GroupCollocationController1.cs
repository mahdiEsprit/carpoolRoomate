
//using Data;
//using Domain.entity;
//using GUI.Models;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Web;
//using System.Web.Mvc;

//using System.Net;
//using Pidev.Services;

//namespace GUI.Controllers
//{
//    public class GroupCollocationController : Controller
//    {
//        GroupColloServices G = null;

//        public GroupCollocationController()
//        {
//            G = new GroupColloServices();
//        }

//        // GET: GroupCollocation
//        public ActionResult Index()
//        {

//            return View();
//        }

//        // GET: GroupCollocation/Details/5
//        public ActionResult Details(int id)
//        {
//            if (id == null)
//            {
//                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
//            }
//            CollocationGroup g = G.GetById(id);
//            if (g == null)
//            {
//                return HttpNotFound();
//            }
//            return View(g);
//        }

//        // GET: GroupCollocation/Create
//        public ActionResult Create()
//        {
//            return View();
//        }

//        // POST: GroupCollocation/Create
//        [HttpPost]
//        public ActionResult Create(GoupColloModel gr)
//        {
//            CollocationGroup cg = new CollocationGroup()
//            {
//                DateCreation = gr.DateCreation,
//               // Title = gr.Title

//            };
//            G.Add(cg);
//            G.Commit();
//            cg = G.GetAll().Last();
//            GoupColloModel g1 = new GoupColloModel();
//            GoupColloModel gcm= Session["gcm"] as GoupColloModel;
//            gr.DateCreation = cg.DateCreation;
//            gr.CollocationOffreList = cg.CollocationOffreList;
//            gr.DiscutionGroupList = cg.DiscutionGroupList;
//           // gr.Title = cg.Title;

//            DiscutionGroup d = new DiscutionGroup()
//            {
//                //collocationGroup=cg,
//                Text = " ",
//            };
//            //DiscutionServices D = new DiscutionServices();
//            //DiscutionServices d2 = new DiscutionServices();
//            //D.Add(d);
//            //D.Commit();
//            //d2 = D.GetAll().Last();
//           // gr.DiscutionGroupList.Add(d);
//            Session["gcm"] = gr;
//            return RedirectToAction("../Discution/Index/"+cg.CollocationGroupId);
           
//        }

//        // GET: GroupCollocation/Edit/5
//        public ActionResult Edit(int id)
//        {
//            return View();
//        }

//        // POST: GroupCollocation/Edit/5
//        [HttpPost]
//        public ActionResult Edit(int id, FormCollection collection)
//        {
//            try
//            {
//                // TODO: Add update logic here

//                return RedirectToAction("Index");
//            }
//            catch
//            {
//                return View();
//            }
//        }

//        // GET: GroupCollocation/Delete/5
//        public ActionResult Delete(int id)
//        {
//            return View();
//        }

//        // POST: GroupCollocation/Delete/5
//        [HttpPost]
//        public ActionResult Delete(int id, FormCollection collection)
//        {
//            try
//            {
//                // TODO: Add delete logic here

//                return RedirectToAction("Index");
//            }
//            catch
//            {
//                return View();
//            }
//        }
//    }
//}
