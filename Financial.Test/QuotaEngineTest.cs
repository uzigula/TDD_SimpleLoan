using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using Financial;
using FluentAssertions;

namespace Financial.Test
{
    [TestFixture]
    public class QuotaEngineTest
    {
 
        [Test]
        [TestCase(1000, 1, 10, 100, 1, 101)]
        [TestCase(600, 1, 10, 60, 0.6, 60.6)]
        [TestCase(5000, 10, 10, 500, 50, 550)]
        public void GetQuota_When_Capital_5000_Rate_10_Term_10_Return_Quota_Capital_500_Rate_50(double capital, double rate, int term,
                                                                      double quotaCapital, double quotaRateAmmount, double quotaExpected)
        {
            var loan = new QuotaEngine(capital, rate/100, term);
            var quota = loan.GetQuota();
            quota.Capital.Should().Be(quotaCapital);
            quota.RateAmount.Should().Be(quotaRateAmmount);
            quota.Total.Should().Be(quotaExpected);
        }

        [Test]

        public void GetCalendar_When_Capital_5000_Rate_10_Term_10_Return_Calendar_With_Ten_Quotas()
        {
            var loan = new QuotaEngine(5000, 0.1, 10);
            var calendar = loan.GetPaymentCalendar();
            calendar.Should().BeOfType<PaymentCalendar>();
            calendar.Quotas.Count.Should().Be(10);
        }

        [Test]
        public void GetCalendar_When_Capital_5000_Rate_10_Term_10_Return_Calendar_TotalRate_500()
        {
            var loan = new QuotaEngine(5000, 0.1, 10);
            var calendar = loan.GetPaymentCalendar();
            calendar.Should().BeOfType<PaymentCalendar>();
            calendar.Quotas.Should().BeOfType<List<Quota>>();
            calendar.Quotas.Count.Should().Be(10);
            calendar.TotalRate.Should().Be(500);

        }

        [Test]
        public void GetCalendar_When_Capital_3000_Rate_20_Term_12_Return_Calendar_TotalRate_600_TotalCapital_3000()
        {
            var loan = new QuotaEngine(3000, 0.2, 12);
            var calendar = loan.GetPaymentCalendar();
            calendar.Should().BeOfType<PaymentCalendar>();
            calendar.Quotas.Should().BeOfType<List<Quota>>();
            calendar.Quotas.Count.Should().Be(12);
            calendar.TotalRate.Should().Be(600);
            calendar.TotalCapital.Should().Be(3000);

        }
    }
}