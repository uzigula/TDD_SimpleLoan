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
        private QuotaEngine loan;
        [SetUp]
        public void Setup()
        {
            loan = new QuotaEngine();
        }

        [Test]
        [TestCase(1000, 1, 10, 100,1,101)]
        [TestCase(600, 1, 10, 60,0.6,60.6)]
        [TestCase(5000, 10, 10, 500,50,550)]
        public void GetQuota_When_Capital_5000_Rate_10_Term_10_Return_Quota_Capital_500_Rate_50(double capital, double rate, int term,
                                                                      double quotaCapital, double quotaRateAmmount, double quotaExpected)
        {
            var quota = loan.GetQuota(capital,rate/100,term);
            quota.Capital.Should().Be(quotaCapital);
            quota.RateAmount.Should().Be(quotaRateAmmount);
            quota.Total.Should().Be(quotaExpected);
        }


    }
}