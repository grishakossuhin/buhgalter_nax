using BuhUchetApi.Models;
using System;
using System.Threading.Tasks;

namespace BuhUchetApi.Services.Amortization
{
    public class AmortizationService
    {
        public async Task<AmortizationResponseVm> GetAmortization(DateTime startDate, int years, double fullprice, double amort)
        {
            var ostatStoimost = fullprice - amort;
            var koefIznosa = amort / fullprice * 100;
            var amortMonth = fullprice / years / 12;
            var date = startDate.AddYears(years);

            var response = new AmortizationResponseVm()
            {
                Date = date,
                Summ = amortMonth,
                AccruedDepreciation = koefIznosa,
                ResidualValue = ostatStoimost
            };

            return response;
        }
    }
}
