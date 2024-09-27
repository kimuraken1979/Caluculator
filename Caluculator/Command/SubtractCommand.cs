using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator.Command
{
    public class SubtractCommand : ICommand
    {
        private double _a, _b;

        public SubtractCommand(double a, double b)
        {
            _a = a;
            _b = b;
        }

        public double Execute()
        {
            return Math.Round(_a - _b, 5);  // 小数点5桁までに丸める
        }
    }
}
