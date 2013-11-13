using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Financial
{
    public class QuotaEngine
    {
        public double GetQuota(double capital, double rate, int term)
        {
            return ((capital*(1+rate))/term);
        }
    }
}
