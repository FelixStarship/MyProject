using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestMigration.Domain.core
{
   public class Order:Entity
    {

        public Order()
        {
            this.Employee = new HashSet<Employee>();
        }
        public int OrderId { get; set; }
        public string OrderTitle { get; set; }

        public string Customer { get; set; }

        public DateTime TransactionDate { get; set; }

        public virtual ICollection<Employee> Employee { get; set; }
    }
}
