using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Financial
{
    public class QuotaEngine
    {
        public Quota GetQuota(double capital, double rate, int term)
        {
            var total = ((capital * (1 + rate)) / term);
            var quota = new Quota();
            quota.Capital = capital/term;
            quota.RateAmount = quota.Capital*rate;
            return quota;
        }
    }
}
