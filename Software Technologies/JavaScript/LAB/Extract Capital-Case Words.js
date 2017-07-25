function getCapCase(arr) {
    main(arr);

    function main(arr){
        arr = extractWords(arr);
        let upperCaseWords = getUpperCaseWords(arr);
        console.log(upperCaseWords.join(', '));
    }


    function extractWords(arr){
        let output = [];
        for(let line of arr){
             let splitedLine = line.split(/[^a-zA-Z]+/);
             for(let word of splitedLine)
                 output.push(word);
        }
        return output.filter(w=>w!=='');
    }

    function getUpperCaseWords(arr) {
        let output = [];
        for(let word of arr){
            let upperWord = word.toUpperCase();
            if(upperWord===word)
                output.push(word);
        }
        return output;
    }
}