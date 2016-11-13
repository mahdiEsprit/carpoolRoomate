using Data.Infrastructure;
using Domain;
using Domain.entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories
{
    public static class GroupRepository
    {
        public static void AssignMemberToGroup(this IRepositoryBaseAsync<CollocationGroup> repo, string idMem, int idGroup)
        {
            DatabaseFactory dbf = new DatabaseFactory();
            User emp = dbf.DataContext.Users.FirstOrDefault(x => x.Id == idMem);
            dbf.DataContext.CollocationGroups.Include("users").FirstOrDefault(x => x.CollocationGroupId == idGroup).users.Add(emp);
            dbf.DataContext.SaveChanges();
        }

        public static void UnassignMemberFromGroup(this IRepositoryBaseAsync<CollocationGroup> repo, string idMem, int idGroup)
        {
            DatabaseFactory dbf = new DatabaseFactory();
            User emp = dbf.DataContext.Users.FirstOrDefault(x => x.Id == idMem);
            dbf.DataContext.CollocationGroups.Include("users").FirstOrDefault(x => x.CollocationGroupId == idGroup).users.Remove(emp);
            dbf.DataContext.SaveChanges();
        }

        public static int AddWithGetingId(this IRepositoryBaseAsync<CollocationGroup> repo, CollocationGroup t)
        {
            DatabaseFactory dbf = new DatabaseFactory();
            dbf.DataContext.CollocationGroups.Add(t);
            dbf.DataContext.SaveChanges();
            int id = t.CollocationGroupId;
            return id;
        }

        public static void AssignOfferToGroup(this IRepositoryBaseAsync<CollocationGroup> repo, string idMem, int idGroup)
        {
            DatabaseFactory dbf = new DatabaseFactory();
            User emp = dbf.DataContext.Users.FirstOrDefault(x => x.Id == idMem);
            dbf.DataContext.CollocationGroups.Include("User").FirstOrDefault(x => x.CollocationGroupId == idGroup).users.Add(emp);
            dbf.DataContext.SaveChanges();
        }

        public static void UnassignOfferFromGroup(this IRepositoryBaseAsync<CollocationGroup> repo, string idMem, int idGroup)
        {
            DatabaseFactory dbf = new DatabaseFactory();
            User emp = dbf.DataContext.Users.FirstOrDefault(x => x.Id == idMem);
            dbf.DataContext.CollocationGroups.Include("User").FirstOrDefault(x => x.CollocationGroupId == idGroup).users.Remove(emp);
            dbf.DataContext.SaveChanges();
        }

        public static int AddOfferWithGetingId(this IRepositoryBaseAsync<CollocationGroup> repo, CollocationGroup t)
        {
            DatabaseFactory dbf = new DatabaseFactory();
            dbf.DataContext.CollocationGroups.Add(t);
            dbf.DataContext.SaveChanges();
            int id = t.CollocationGroupId;
            return id;
        }

    }
}
