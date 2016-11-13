using Data;
using Data.Infrastructure;
using Data.Repositories;
using Domain.entity;
using Pidev.ServicePattern;
using ServicePattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pidev.Services
{
    public class GroupColloServices : Service<CollocationGroup>
    {
        private static IDatabaseFactory dbf = new DatabaseFactory();
        private static IUnitOfWork ut = new UnitOfWork(dbf);

        public GroupColloServices()
           : base(ut)
        {
        }
        public IEnumerable<CollocationGroup> index1(string searchString)
        {
            var titlelist = new List<String>();

            ApplicationDbContext db = new ApplicationDbContext();



            var titlelists = from d in db.CollocationGroups
                             orderby d.Title
                             select d.Title;

            titlelist.AddRange(titlelists.Distinct());


            var list = from m in db.CollocationGroups
                       select m;

            if (!String.IsNullOrEmpty(searchString))
            {
                list = list.Where(s => s.Title.Contains(searchString));
            }

            return (list);
        }
        public int AddWithGetingId(CollocationGroup t)
        {
            return ut.getRepository<CollocationGroup>().AddWithGetingId(t);
        }
        public void AssignMemberToGroup(string idMem, int idGroup)
        {
            ut.getRepository<CollocationGroup>().AssignMemberToGroup(idMem, idGroup);
        }

        public void UnassignEmployeeToTraining(string idMem, int idTraining)
        {
            ut.getRepository<CollocationGroup>().UnassignMemberFromGroup(idMem, idTraining);
        }
       
    }
}