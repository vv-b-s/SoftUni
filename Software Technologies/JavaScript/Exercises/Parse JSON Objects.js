function paseJSON(JSONstrings) {
    JSONstrings = JSONstrings.map(JSON.parse);

    for(let data of JSONstrings)
        console.log(`Name: ${data.name}\nAge: ${data.age}\nDate: ${data.date}`);
}