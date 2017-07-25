function multOrDiv(nums) {
    nums = nums.map(Number);
    console.log(
        nums[0]<=nums[1]?
            nums[0]*nums[1]:
            nums[0]/nums[1]
    );
}