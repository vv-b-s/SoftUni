function keyValuePairManipulator(rawPairs) {
    var keysANDvalues = {};
    let lastElement = '';
    for(let pair of rawPairs){
        pair = pair.split(' ');

        if(pair.length===1){
            lastElement = pair[0];          // send the last element to the end. for a search key
            break;
        }

        keysANDvalues[pair[0]] = pair[1];
    }
    console.log(
        lastElement in keysANDvalues?
            keysANDvalues[lastElement]:
            'None'
    );
}