function convertToObjectData(rawStrings) {
    let students = [];
    for(let str of rawStrings){
        str = str.split(/ -> /);
        let name = str[0];
        let age = str[1];
        let grade = str[2];
        students.push({Name: name, Age: age, Grade:grade});
    }

    for(let student of students)
        for(let studentData in student)
            console.log(`${studentData}: ${student[studentData]}`);

}
