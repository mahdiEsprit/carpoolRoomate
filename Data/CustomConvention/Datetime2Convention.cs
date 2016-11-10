using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.CustomConventions
{
    public class Datetime2Convention : Convention
    {
        public Datetime2Convention()
        {
            Properties<DateTime>().Configure(d => d.HasColumnType("datetime2"));
        }



    }
}
