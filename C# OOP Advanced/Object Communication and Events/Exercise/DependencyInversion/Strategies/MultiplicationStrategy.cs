using DependencyInversion.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace DependencyInversion.Strategies
{
    public class MultiplicationStrategy : IStrategy
    {
        public int Calculate(int firstOperand, int secondOperand)
        {
            return firstOperand * secondOperand;
        }
    }
}
