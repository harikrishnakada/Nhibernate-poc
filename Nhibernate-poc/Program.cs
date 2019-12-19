using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NHibernate;
using Nhibernate_poc.Model;

namespace Nhibernate_poc
{
    public static class Program
    {
        public static void GetRecognition(ISession session)
        {
            //var rec = session.Get<Recognition>(Guid.Parse("8F1B75E7-1496-4F29-B2CA-AB28005D3B98"));

            var recognition = session.QueryOver<Recognition>()
                .Fetch(x => x.Employee).Eager
                .Fetch(x => x.Badge).Eager
                .Where(x => x.EmployeeId == Guid.Parse("001B3C3A-8D5D-44A6-B66C-AB28005259FA"))
                .List();
        }

        public static void UpsertBadge(ISession session)
        {
            var badge = new Badge()
            {
                BadgeName = "SoloRanger",
                Score = 100,
                Category = "Palt"
            };

            session.SaveOrUpdate(badge);
            session.Flush();
        }

        public static void UpsertEmployee(ISession session)
        {
            var emp = new Employee();
            emp.Identifier = "T005";
            emp.Name = "Kirtee";
            emp.Surname = "Kirtee";
            emp.Designation = "Dev";

            session.SaveOrUpdate(emp);
            session.Flush();
        }

        public static void UpsertRecognition(ISession session)
        {
            var emp = session.Get<Employee>(Guid.Parse("001B3C3A-8D5D-44A6-B66C-AB28005259FA"));
            var badge = session.Get<Badge>(Guid.Parse("BC126528-804F-413D-93CE-AB27013EAB45"));

            var rec = new Recognition()
            {
                Badge = badge,
                Employee = emp
            };

            session.SaveOrUpdate(rec);
            session.Flush();
        }

        private static void Main(string[] args)
        {
            var cs = ConfigurationManager.ConnectionStrings["Gratification"].ConnectionString;
            NhibernateExtensions.AddNHibernate(cs);

            using (var session = NhibernateExtensions.sessionFactory.OpenSession())
            {
                //UpsertBadge(session);
                //UpsertEmployee(session);
                //UpsertRecognition(session);
                GetRecognition(session);
            }
        }
    }
}