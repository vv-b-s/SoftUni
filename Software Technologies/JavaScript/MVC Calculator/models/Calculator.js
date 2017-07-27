function Calculator (leftOperand, operator, rightOperand){
    this.leftOperand  = leftOperand;
    this.operator     =     operator;
    this.rightOperand = rightOperand;

    this.calcilateResult = function () {
        switch (this.operator){
            case '+': return this.leftOperand + this.rightOperand;
            case '-': return this.leftOperand - this.rightOperand;
            case '*': return this.leftOperand * this.rightOperand;
            case '/': return this.leftOperand / this.rightOperand;
            case '%': return this.leftOperand % this.rightOperand;
            case '^': return this.leftOperand ^ this.rightOperand;
            case '|': return this.leftOperand | this.rightOperand;
            case '&': return this.leftOperand & this.rightOperand;
        }

    }
}

module.exports = Calculator;