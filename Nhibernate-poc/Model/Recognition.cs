using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nhibernate_poc.Model
{
    public class Recognition
    {
        public virtual Badge Badge { get; set; }

        public virtual Guid BadgeId { get; set; }

        public virtual Employee Employee { get; set; }

        public virtual Guid EmployeeId { get; set; }

        public virtual Guid Id { get; set; }
    }
}