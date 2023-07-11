using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalNovelist_Windows.Services
{

    public interface ICalculationService
    {
        double TipAmount(double subTotal, int generosity);
    }
    public class CalculationService : ICalculationService
    {
        public double TipAmount(double subTotal, int generosity)
        {
            return subTotal * ((double)generosity) / 100.0;
        }
    }
}
