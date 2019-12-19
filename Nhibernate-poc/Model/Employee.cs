using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nhibernate_poc.Model
{
    public class Employee
    {
        public virtual string Designation { get; set; }

        public virtual Guid Id { get; set; }

        public virtual string Identifier { get; set; }

        public virtual string Name { get; set; }

        public virtual string Surname { get; set; }
    }
}