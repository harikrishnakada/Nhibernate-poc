using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NHibernate;
using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;
using Nhibernate_poc.Model;

namespace Nhibernate_poc.Maping
{
    public class BadgesMap : ClassMapping<Badge>
    {
        public BadgesMap()
        {
            Id(x => x.Id, x =>
            {
                x.Generator(Generators.GuidComb);
                x.Type(NHibernateUtil.Guid);
                //x.UnsavedValue(null);
            });
            this.Property(x => x.BadgeName);
            this.Property(x => x.Category);
            this.Property(x => x.Score);

            Table("Badges");
        }
    }
}