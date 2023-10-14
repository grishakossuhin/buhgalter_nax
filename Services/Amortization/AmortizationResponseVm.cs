using System;

namespace BuhUchetApi.Services.Amortization
{
    public class AmortizationResponseVm
    {
        public double AccruedDepreciation { get; set; }
        public double ResidualValue { get; set; }
        public DateTime Date { get; set; }
        public double Summ { get; set; }
    }
}
