using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestMigration.Domain.Interface
{
   public interface IPageOfList
    {
        long CurrentStart { get; }
        int PageIndex { get; set; }
        int PageSize { get; set; }
        int PageTotal { get; }
        long RecordTotal { get; set; }
    }
}
