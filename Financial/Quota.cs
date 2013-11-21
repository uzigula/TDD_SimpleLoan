using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Financial
{
    public class Quota
    {
        private double _payRateAmount;
        private double _payCapital;
        public Double Capital { get; set; }
        public Double RateAmount { get; set; }
        public Double Total { get { return Capital + RateAmount; } }
        public DateTime Expire { get; set; }

        public bool Cancelled { get; set; }

        public double PayRateAmount { get { return _payRateAmount; } }

        public double PayCapital { get { return _payCapital; } }

        public double QuotaBalance
        {
            get { return (Capital - PayCapital) + (RateAmount - PayRateAmount); }
        }

        public double CapitalBalance
        {
            get { return (Capital - PayCapital); }
        }

        public double RateAmountBalance
        {
            get { return (RateAmount - PayRateAmount); }
        }


        public void PayBack(double pay)
        {

            var currentPay = GetPayAmmountFrom(RateAmountBalance, pay);
            pay = pay - currentPay;
            _payRateAmount = _payRateAmount + currentPay;
            if (pay > 0)
            {
                _payCapital = _payCapital + GetPayAmmountFrom(CapitalBalance, pay);
            }

            Cancelled = ((CapitalBalance + RateAmountBalance) <= 0);
        }

  

        private double GetPayAmmountFrom(double balance, double pay)
        {
            if (pay >= balance)
            {
                return balance;
            }
            else
            {
                return pay;
            }
        }
    }
}
