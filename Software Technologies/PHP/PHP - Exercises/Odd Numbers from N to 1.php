<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <title>First Steps Into PHP</title>

</head>
<body>
<form>
    N: <input type="text" name="num" />
    <input type="submit" />
</form>
<?php
if(isset($_GET['num'])){
    echo getOddNums(intval($_GET['num']));
}

function getOddNums(int $n):string {
    $n = $n%2==0?$n-1:$n;
    $output = [];
    for($i=$n;$i>=1;$i-=2)
        $output[] = $i;
    return implode(' ',$output);
}
?>
</body>
</html>
