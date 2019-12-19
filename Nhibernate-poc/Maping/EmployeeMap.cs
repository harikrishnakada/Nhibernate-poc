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
    public class EmployeeMap : ClassMapping<Employee>
    {
        public EmployeeMap()
        {
            Id(x => x.Id, x =>
            {
                x.Generator(Generators.GuidComb);
                x.Type(NHibernateUtil.Guid);
                //x.UnsavedValue(null);
            });

            this.Property(x => x.Designation);
            this.Property(x => x.Identifier);
            this.Property(x => x.Name);
            this.Property(x => x.Surname);

            //Property(b => b.Name, x =>
            //{
            //    x.Length(100);
            //    x.Type(NHibernateUtil.StringClob);
            //    x.NotNullable(false);
            //});
            //Property(b => b.Surname, x =>
            //{
            //    x.Length(100);
            //    x.Type(NHibernateUtil.StringClob);
            //    x.NotNullable(false);
            //});
            //Property(b => b.Identifier, x =>
            //{
            //    x.Length(10);
            //    x.Type(NHibernateUtil.StringClob);
            //    x.NotNullable(true);
            //});
            //Property(b => b.Designation, x =>
            //{
            //    x.Length(100);
            //    x.Type(NHibernateUtil.StringClob);
            //    x.NotNullable(false);
            //});

            Table("Employees");
        }
    }
}