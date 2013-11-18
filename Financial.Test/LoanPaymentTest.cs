using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using FluentAssertions;
using Financial;

namespace Financial.Test
{
    public class LoanPaymentTest
    {
        [Test]
        public void PerformPay_Given_Loan_Capital_5000_Rate_10_Term_10_When_Pay_550_Then_Have_first_Quota_cancelled()
        {
            var loan = new QuotaEngine(5000, 10 / 100, 10, DateTime.Now);
            var schedule = loan.GetPaymentCalendar();
            var loanPayment = new LoanPayment(schedule);
            loanPayment.PerformPay(550);
            schedule.Quotas[0].Cancelled.Should().Be(true);
        }
    }
}
