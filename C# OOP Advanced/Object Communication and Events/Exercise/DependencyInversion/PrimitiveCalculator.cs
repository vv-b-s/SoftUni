using DependencyInversion.Contracts;
using System.Collections.Generic;
using System.Linq;

namespace DependencyInversion
{
    public class PrimitiveCalculator
    {
        private Dictionary<char, IStrategy> strategyMap;
        private IStrategy cuurentStrategy;

        public PrimitiveCalculator(Dictionary<char, IStrategy> strategies)
        {
            this.strategyMap = strategies;
            this.cuurentStrategy = strategyMap.First().Value;
        }

        public void ChangeStrategy(char @operator)
        {
            this.cuurentStrategy = this.strategyMap[@operator];
        }

        public int PerformCalculation(int firstOperand, int secondOperand)
        {
            var result = this.cuurentStrategy.Calculate(firstOperand, secondOperand);

            return result;
        }
    }
}
