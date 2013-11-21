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
        private double _defaultPay;
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

        public double DefaultBalance
        {
            get { return _defaultPay; }
        }

        public void PayBack(double pay, DateTime datePay)
        {
            if (Expire < datePay)
            {
                pay = pay - GetDefaultPay(datePay);
            }

            var currentPay = GetPayAmmountFrom(RateAmountBalance, pay);
            pay = pay - currentPay;
            _payRateAmount = _payRateAmount + currentPay;
            if (pay > 0)
            {
                _payCapital = _payCapital + GetPayAmmountFrom(CapitalBalance, pay);
            }

            Cancelled = ((CapitalBalance + RateAmountBalance) <= 0);
        }

        private double GetDefaultPay(DateTime datePay)
        {
            var daysDefault = (datePay - Expire).TotalDays;
            var defaultToPay = (daysDefault * 1);
            _defaultPay += defaultToPay;
            return defaultToPay;
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