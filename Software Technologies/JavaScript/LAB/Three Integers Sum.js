function sum(nums) {
    nums = nums[0].split(' ').map(Number);
    for(let i=0;i<nums.length;i++)
        for(let j = i+1;j<nums.length;j++)
        {
            let sumOfNums = nums[i]+nums[j];
            if((nums.includes(sumOfNums)&& nums[i]!==sumOfNums&&nums[j]!==sumOfNums)|| allNumsAreEqual(nums))
            {
                let smallestN = Math.min(nums[i],nums[j]);
                let highestN = Math.max(nums[i],nums[j]);

                console.log(`${smallestN} + ${highestN} = ${nums[i]+nums[j]}`);
                return
            }
        }
    console.log("No");

    function allNumsAreEqual(arr) {
        for(let a = 1;a<arr.length;a++)
            if(arr[a]!==arr[0])
                return false;
        return true;
    }
}