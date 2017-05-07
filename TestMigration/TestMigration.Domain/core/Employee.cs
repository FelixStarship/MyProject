using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestMigration.Domain.core
{
   public class Employee:Entity
    {
        public Employee()
        {
            this.Order = new HashSet<Order>();
        }
        public int EmployeeId { get; set; }

        public string EmployeeName { get; set; }

        public virtual ICollection<Order> Order { get; set; }
    }
}
