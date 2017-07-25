function displayArray(rawArray) {
    let arrayLen = Number(rawArray.shift());
    let array = {};
    for(let i = 0;i<arrayLen;i++){
        for(let keyValP of rawArray){
            let tempArr = keyValP.split(/ - /).map(Number);
            array[tempArr[0]] = tempArr[1];
        }
    }
    for(let i=0;i<arrayLen;i++)
        console.log(
            i in array?
                array[i]:
                0
        );
}
