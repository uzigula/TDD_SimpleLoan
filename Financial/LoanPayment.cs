using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Financial
{
    public class LoanPayment
    {
        private PaymentCalendar _paymentCalendar;
        public LoanPayment(PaymentCalendar paymentCalendar)
        {
            _paymentCalendar = paymentCalendar;
        }
        public void PerformPay(double pay)
        {
            _paymentCalendar.Quotas[0].PayBack(pay);

        }
    }
}
