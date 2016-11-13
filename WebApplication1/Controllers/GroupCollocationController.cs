
using Data;
using Domain.entity;
using GUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using System.Net;
using GUI.Helpers;
using Pidev.Services;
using Services.Users;
using Domain;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace GUI.Controllers
{
    public class GroupCollocationController : Controller
    {
        GroupColloServices G ;
        static  CollocationGroup controllercroupcollocation;
        ApplicationDbContext context;
        UserService us ;
        DiscutionServices D;

        public GroupCollocationController()
        {
            D = new DiscutionServices();
            G = new GroupColloServices();
            context = new ApplicationDbContext();
            us = new UserService();
        }
        public User getCurrentUser()
        {
            var UserManager = new UserManager<User>(new UserStore<User>(context));
            var user = UserManager.FindById(User.Identity.GetUserId());
            return user;
        }
        public ActionResult GetMember(int id)
        {
            List<User> members = us.GetMany(p =>p.collocationGroups.Where(t => t.CollocationGroupId == id).Count() == 0).ToList();
            ViewBag.Members = members;
            ViewBag.Id = id;
            return View();
        }
        public ActionResult postMember(int id)
        {


            
                G.AssignMemberToGroup(getCurrentUser().Id , id);
            
            return RedirectToAction("../ Discution / Index / "+id);
        }

        // GET: GroupCollocation
        public ActionResult Index()
        {
            ICollection<GoupColloModel> listGroupCollModel = new List<GoupColloModel>(); 

            var listegroup = G.GetAll();
            foreach (var item in listegroup)
            {
                GoupColloModel groupColloModel = new GoupColloModel() {

                    CollocationGroupId = item.CollocationGroupId,
                    DateCreation = item.DateCreation,
                    Title=item.Title,
                    GroupeType = item.GroupeType,
                    NombreDeMebre=item.NombreDeMebre
                };
                listGroupCollModel.Add(groupColloModel);

            }
            return View(listGroupCollModel);
        }

        // GET: GroupCollocation/Details/5
        public ActionResult Details(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CollocationGroup g = G.GetById(id);
            if (g == null)
            {
                return HttpNotFound();
            }

            IEnumerable<DiscutionGroup> discutions = D.getAllDiscution(id);

            ViewBag.discutions = discutions;
            ViewBag.Id = id;
            
            return View(g);
        }

        // GET: GroupCollocation/Create
        public ActionResult Create()
        {

            var groupcoll = new GoupColloModel();
            List<string> type = new List<string> { "Roomate", "Carpool" };



            groupcoll.GroupeTypes = type.ToSelectListItemsTypeGroup();


            return View(groupcoll);
        }

        // POST: GroupCollocation/Create
        [HttpPost]
        public ActionResult Create(GoupColloModel gr)
        {
            CollocationGroup cg = new CollocationGroup()
            {
                DateCreation = DateTime.Now,
                Title = gr.Title,
                GroupeType = gr.GroupeType,
                NombreDeMebre=1

            };
            controllercroupcollocation = cg;
            G.Add(cg);
            G.Commit();
            cg = G.GetAll().Last();
            DiscutionGroup d = new DiscutionGroup()
            {
                CollocationGroupId = cg.CollocationGroupId
            };
            DiscutionServices D = new DiscutionServices();
            
            //D.Add(d);
            //D.Commit();
            int id = G.AddWithGetingId(cg);
            //return RedirectToAction("../Discution/Index/"+cg.CollocationGroupId);
            return RedirectToAction("GetMember" , new { id = id });

        }

        // GET: GroupCollocation/Edit/5
        public ActionResult Edit(int id)
        {


            
            var groupModeleColl = G.GetById(id);
            List<string> type = new List<string> { "Roomate", "Carpool" };



            GoupColloModel groupColloModel = new GoupColloModel()
            {

                CollocationGroupId = groupModeleColl.CollocationGroupId,
                DateCreation = groupModeleColl.DateCreation,
                Title = groupModeleColl.Title,
                GroupeType = groupModeleColl.GroupeType,
                NombreDeMebre = groupModeleColl.NombreDeMebre
            };

            groupColloModel.GroupeTypes = type.ToSelectListItemsTypeGroup();

            int? x = Session["xx"] as int?;
            Session["xx"] = id;

            return View(groupColloModel);
        }

        // POST: GroupCollocation/Edit/5
        [HttpPost]
        public ActionResult Edit(GoupColloModel gr)
        {
            int? x = Session["xx"] as int?;
            var g1 = G.GetById((int)x);


            g1.Title = gr.Title;
            g1.GroupeType = gr.GroupeType;

                
                G.Update(g1);
                G.Commit();
                return RedirectToAction("Index");
           
        }

        // GET: GroupCollocation/Delete/5
        //public ActionResult Delete()
        //{
        //    return View();
        //}

        // POST: GroupCollocation/Delete/5
        [HttpGet]
        public ActionResult Delete(int id)
        {
            try
            {
               CollocationGroup c = G.GetById(id);
                G.Delete(G.GetById(id));
                G.Commit();

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }

        }

        public ActionResult searchindex()
        {

            //    //var a = G.index1(searchString);
            //    //List<GoupColloModel> listGroupCollModel = Session["listGroupCollModels"] as List<GoupColloModel>;
            //    //if (listGroupCollModel == null)

            //    //{

            //    //    listGroupCollModel = new List<GoupColloModel>();

            //    //}
            //    //var listegroup = G.GetAll();

            //    //foreach (var item in listegroup)
            //    //{
            //    //    GoupColloModel groupColloModel = new GoupColloModel()
            //    //    {

            //    //        CollocationGroupId = item.CollocationGroupId,
            //    //        DateCreation = item.DateCreation,
            //    //        Title = item.Title,
            //    //        GroupeType = item.GroupeType,
            //    //        NombreDeMebre = item.NombreDeMebre
            //    //    };
            //    //    listGroupCollModel.Add(groupColloModel);

            //    //}
            //    //Session["listGroupCollModels"] = listGroupCollModel;
            //    //return View(listGroupCollModel);
            ViewBag.k = 1;
                return View(G.GetAll());
        }

    [HttpPost]
        public ActionResult searchindex(string searchString)
        {
            //List<Goupcoiol> listGroupCollModel = Session["listGroupCollModels"] as List<GoupColloModel>;
            var a = G.index1(searchString);

            //if (!String.IsNullOrEmpty(searchString))

            //{

            //    listGroupCollModel = listGroupCollModel.Where(m => m.Title.Contains(searchString)).ToList();

            //}
            ViewBag.k = 2;
            return View(a);

        }


    }
}
