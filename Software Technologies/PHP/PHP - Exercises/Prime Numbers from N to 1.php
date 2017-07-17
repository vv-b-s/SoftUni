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
    $n = intval($_GET['num']);

    $primeSet = [];
    for($i=$n;$i>0;$i--)
        if(isPrime($i))
            $primeSet[] = $i;

    echo implode(' ',$primeSet);
}

function isPrime(int $number):bool{
    if($number==1||$number==0) return false;
    if($number==2) return true;

    $boundary = floor(sqrt($number));

    for($i=2;$i<=$boundary;$i++)
        if($number % $i==0) return false;
    return true;
}
?>
</body>
</html>
