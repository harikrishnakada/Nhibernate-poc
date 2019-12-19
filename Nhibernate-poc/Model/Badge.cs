using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nhibernate_poc.Model
{
    public class Badge
    {
        public virtual string BadgeName { get; set; }

        public virtual string Category { get; set; }

        public virtual Guid Id { get; set; }

        public virtual int Score { get; set; }
    }
}