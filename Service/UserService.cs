using Data.Infrastructure;
using Domain;
using Pidev.ServicePattern;
using ServicePattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Users
{
    public class UserService : Service<User>
    {

        static IDatabaseFactory factory = new DatabaseFactory();
        static IUnitOfWork uow = new UnitOfWork(factory);
        public UserService():base(uow)
        {

        }
    }
}
