function turnToJSONstring(objData) {
    let outputObj = {};
    for(let data of objData){
        data = data.split(/ -> /);
        if(Number(data[1]))                     // if NaN, will result in false
            data[1] = Number(data[1]);
        
        outputObj[data[0]] = data[1];
    }

    console.log(JSON.stringify(outputObj));
}