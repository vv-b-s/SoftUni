using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Froggy
{
    public class Lake : IEnumerable<int>
    {
        private int[] digits;

        public Lake(int[] digits)
        {
            this.digits = new int[digits.Length];
            var digitsFieldIndex = 0;

            for (int i = 0; i < digits.Length; i += 2, digitsFieldIndex++)
                this.digits[digitsFieldIndex] = digits[i];

            var backwardsStartIndex = digits.Length % 2 == 0 ?
                digits.Length - 1 :
                digits.Length - 2;

            for (int i = backwardsStartIndex; i >= 0; i -= 2, digitsFieldIndex++)
                this.digits[digitsFieldIndex] = digits[i];
        }

        public IEnumerator<int> GetEnumerator()
        {
            foreach (var digit in this.digits)
                yield return digit;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
