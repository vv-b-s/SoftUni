function arrayManipulator(commands){
    let array = [];
    for(let command of commands){
        command = command.split(' ');
        let action = command[0];
        let numberOrIndex = Number(command[1]);

        switch(action){
            case 'add':
                array.push(numberOrIndex);
                break;
            case 'remove':
                if(numberOrIndex in array)
                    array.splice(numberOrIndex,1);
        }
    }

    for(let element of array)
        console.log(element);
}