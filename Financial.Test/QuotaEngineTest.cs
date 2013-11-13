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
        [TestCase(1000,1,10,101)]
        [TestCase(600, 1, 10, 60.6)]
        [TestCase(5000, 10, 10, 550)]
        public void GetQuota_Given_Capital_Rate_And_Term_Return_Quota(double capital, double rate, int term,
                                                                      double quotaExpected)
        {
            var quota = loan.GetQuota(capital, rate/100, term);
            quota.Should().Be(quotaExpected);
        }
    }
}