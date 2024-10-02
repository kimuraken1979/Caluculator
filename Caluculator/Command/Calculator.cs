using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator.Command
{
    public class Calculator
    {
        public double ExecuteCommand(ICommand command)
        {
            return command.Execute();
        }
    }
}
