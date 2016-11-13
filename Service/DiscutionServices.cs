using Data;
using Data.Infrastructure;
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
    public class DiscutionServices : Service <DiscutionGroup>
    {
        private static IDatabaseFactory dbf = new DatabaseFactory();
        private static IUnitOfWork ut = new UnitOfWork(dbf);

        public DiscutionServices()
           : base(ut)
        {
        }

        public IEnumerable<DiscutionGroup> MesDiscution( string idUser)
        {
            return ut.getRepository<DiscutionGroup>().GetMany(u => u.UserIden == idUser);

        }
        public IEnumerable<DiscutionGroup> search(string text)
        {
            var listText = new List<String>();
            ApplicationDbContext db = new ApplicationDbContext();



            var GenreQry = from d in db.DiscutionGroups
                           orderby d.Text
                           select d.Text;

            listText.AddRange(GenreQry.Distinct());

            var discutions = from m in db.DiscutionGroups
                            select m;

            if (!String.IsNullOrEmpty(text))
            {
                discutions = discutions.Where(s => s.Text.Contains(text));
            }
            //if (price >= 0)
            //{
            //    movies = movies.Where(s => s.Price <= price);
            //}
            //if (nbr_de_binom >= 0)
            //{
            //    movies = movies.Where(s => s.nbr_de_binom < nbr_de_binom);
            //}
            //if (!string.IsNullOrEmpty(movieGenre))
            //{
            //    movies = movies.Where(x => x.Region == movieGenre);
            //}

            return (discutions);
        }
        public IEnumerable<DiscutionGroup> getAllDiscution(int i)
        {

            var use = from DiscutionGroup d in ut.getRepository<DiscutionGroup>().GetMany()
                      where d.CollocationGroupId.Equals(i)
                      select d;
            return use;
        }
    }
}