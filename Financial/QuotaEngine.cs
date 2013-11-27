using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Financial
{
    public class QuotaEngine
    {
        private double _capital;
        private double _rate;
        private int _term;
        private DateTime _outlay;

        public QuotaEngine(double capital, double rate, int term, DateTime outlay)
        {
            this._capital = capital;
            this._rate = rate;
            this._term = term;
            this._outlay = outlay;
        }

        public Quota GetQuota()
        {
            var total = ((_capital * (10 + _rate)) / _term);
            var quota = new Quota();
            quota.Capital = _capital/_term;
            quota.RateAmount = quota.Capital * _rate;
            return quota;
        }

        public PaymentCalendar GetPaymentCalendar()
        {
            var calendar = new PaymentCalendar();
            var quotas = new List<Quota>();
            for (int i = 0; i < _term; i++)
            {
                quotas.Add(new Quota { Capital = _capital / _term, RateAmount = (_capital / _term) * _rate, Expire = _outlay.AddDays(30 * (i + 1)) });
            }
            calendar.Quotas = quotas;
            return calendar;
        }
    }
}
