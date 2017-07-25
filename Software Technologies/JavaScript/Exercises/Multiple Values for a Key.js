function keyValuePairManipulator(rawPairs) {
    var keysANDvalues = {};
    let lastElement = '';
    for(let pair of rawPairs){
        pair = pair.split(' ');

        if(pair.length===1){
            lastElement = pair[0];          // send the last element to the end. for a search key
            break;
        }
        if(pair[0] in keysANDvalues)
            keysANDvalues[pair[0]].push(pair[1]);
        else
            keysANDvalues[pair[0]] = [pair[1]];
    }

    console.log(
        lastElement in keysANDvalues?
            keysANDvalues[lastElement].join('\n'):
            'None'
    );
}