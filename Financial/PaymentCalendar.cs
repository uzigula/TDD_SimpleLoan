using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Financial
{
    public class PaymentCalendar
    {
        public List<Quota> Quotas { get; set; }
        public double TotalRate { get { return Quotas.Sum(x => x.RateAmount); } }
    }
}
