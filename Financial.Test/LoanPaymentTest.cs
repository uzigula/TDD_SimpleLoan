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
            loanPayment.PerformPay(550, DateTime.Now.AddDays(15));
            schedule.Quotas[0].Cancelled.Should().Be(true);
        }

        [Test]
        public void PerformPay_Given_Loan_Capital_5000_Rate_10_Term_10_When_Pay_300_Then_CapitalRemain_is_250_And_RateAmountRemain_is_0_and_first_Quota_Not_Cancelled()
        {
            var loan = new QuotaEngine(5000, 0.1, 10, DateTime.Now);
            var schedule = loan.GetPaymentCalendar();
            var loanPayment = new LoanPayment(schedule);
            loanPayment.PerformPay(300, DateTime.Now.AddDays(20));
            schedule.Quotas[0].Cancelled.Should().Be(false);
            schedule.Quotas[0].QuotaBalance.Should().Be(250, "Quota Balance it's wrong");
            schedule.Quotas[0].CapitalBalance.Should().Be(250, "Capital Balance it's wrong");
            schedule.Quotas[0].RateAmountBalance.Should().Be(0, "Rate Balance it's wrong");
        }

        [Test]
        public void PerformPay_Given_Loan_With_30_Day_Default_Capital_5000_Rate_10_Term_10_When_Pay_300_Then_CapitalRemain_is_253_And_RateAmountRemain_is_0_and_first_Quota_Not_Cancelled()
        {
            var loan = new QuotaEngine(5000, 0.1, 10, DateTime.Now.AddDays(-30));
            var schedule = loan.GetPaymentCalendar();
            var loanPayment = new LoanPayment(schedule);
            loanPayment.PerformPay(300, DateTime.Now.AddDays(30));
            schedule.Quotas[0].Cancelled.Should().Be(false);
            schedule.Quotas[0].QuotaBalance.Should().Be(280, "Quota Balance it's wrong");
            schedule.Quotas[0].CapitalBalance.Should().Be(280, "Capital Balance it's wrong");
            schedule.Quotas[0].RateAmountBalance.Should().Be(0, "Rate Balance it's wrong");
        }


    }
}
