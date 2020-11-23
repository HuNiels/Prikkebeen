using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Acupunctuur.Models
{
    public class BlockOverviewViewModel : PageViewModel
    {
        public IList<BlockedPeriod> BlockedPeriods { get; set; }
    }
}
