function reverseNumbers(numbers) {
    console.log(
        numbers
            .map(Number)
            .reverse()
            .join('\n')
    );
}