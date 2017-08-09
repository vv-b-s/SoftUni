using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Calculator_CSharp.Models
{
    public class Calculator
    {
        public decimal LeftOperand { set; get; }
        public decimal RightOperand { set; get; }
        public string Operator { get; set; }
        public decimal Result { get; set; }

        public void CalculateResult()
        {
            switch (Operator)
            {
                case "+": Result = LeftOperand + RightOperand; break;
                case "-": Result = LeftOperand - RightOperand; break;
                case "*": Result = LeftOperand * RightOperand; break;
                case "/": Result = LeftOperand / RightOperand; break;
                case "%": Result = LeftOperand % RightOperand; break;
                case "^": Result = (int)LeftOperand ^ (int)RightOperand; break;
                case "|": Result = (int)LeftOperand | (int)RightOperand; break;
                case "&": Result = (int)LeftOperand & (int)RightOperand; break;
            }
        }
    }
}