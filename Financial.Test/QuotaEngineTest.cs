﻿using System;
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
        public void GetQuota_When_Capital_1000_and_Interes_1_Term_10_Return_101()
        {
            var quota = loan.GetQuota(1000, 0.01, 10);
            quota.Should().Be(101);

        }
        [Test]
        public void GetQuota_When_Capital_600_and_Interes_1_Term_10_Return_101()
        {
            var quota = loan.GetQuota(600, 0.01, 10);
            quota.Should().Be(60.6);
        }

        [Test]
        public void GetQuota_When_Capital_5000_and_Interes_10_Term_10_Return_101()
        {
            var quota = loan.GetQuota(5000, 0.1, 10);
            quota.Should().Be(550);
        }

        [Test]
        [TestCase(1000,1,10,101)]
        public void GetQuota_Given_Capital_Rate_And_Term_Return_Quota(double capital, double rate, int term,
                                                                      double quotaExpected)
        {
            var quota = loan.GetQuota(capital, rate/100, term);
            quota.Should().Be(quotaExpected);
        }
    }
}