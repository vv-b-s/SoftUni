function posORneg(numbers) {
    numbers = numbers.map(Number);
    console.log(
        getMinusCount(numbers)%2===0?
            'Positive':
            'Negative'
    );

    function getMinusCount(numbers) {
        if(numbers.includes(0))
            return 0;

        let minusCount = 0;
        for(let number of numbers)
            if(number<0)
                minusCount++;
        return minusCount;
    }
}