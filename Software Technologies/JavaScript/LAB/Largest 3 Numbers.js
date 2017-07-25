function getLargestThree(arr) {
    let numbers = arr.map(Number);

    numbers.sort((a,b)=>b-a);
    let loopLength = numbers.length<3?numbers.length:3;
    for(let i=0;i<loopLength;i++)
        console.log(numbers[i]);
}