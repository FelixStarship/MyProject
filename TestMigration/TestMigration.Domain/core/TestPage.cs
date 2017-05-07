using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestMigration.Domain.core
{
   public class TestPage
    {
        public int ID { get; set; }
        public string OrderNo { get; set; }
        public decimal WayFee { get; set; }
        public string EMS { get; set; }
    }
}
