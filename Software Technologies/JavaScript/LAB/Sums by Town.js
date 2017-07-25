function proccessJSON(towns) {
    towns = towns.map(JSON.parse);
    let incomes = {};
    for(let townIncome of towns){
        if(townIncome.town in incomes)
            incomes[townIncome.town]+=townIncome.income;
        else
            incomes[townIncome.town]=townIncome.income;
    }

    let townKeys = Object.keys(incomes);
    townKeys.sort();
    for(let town of townKeys){
        console.log(`${town} -> ${incomes[town]}`);
    }
}