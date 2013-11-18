using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Financial
{
    public class Quota
    {
        public Double Capital { get; set; }
        public Double RateAmount { get; set; }
        public Double Total { get { return Capital + RateAmount; } }
    }
}
