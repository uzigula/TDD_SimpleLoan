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
        [Test]
        public void GetQuota_When_Capital_1000_and_Interes_1_Term_10_Return_101()
        {
            var loan = new QuotaEngine();
            var quota = loan.GetQuota(1000, 0.01, 10);
            quota.Should().Be(101);

        }
        [Test]
        public void GetQuota_When_Capital_600_and_Interes_1_Term_10_Return_101()
        {
            var loan = new QuotaEngine();
            var quota = loan.GetQuota(600, 0.01, 10);
            quota.Should().Be(60.6);
        }
    }
}