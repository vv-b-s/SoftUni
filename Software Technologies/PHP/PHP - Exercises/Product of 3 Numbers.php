<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <title>First Steps Into PHP</title>

</head>
<body>
<form>
    X: <input type="text" name="num1" />
    Y: <input type="text" name="num2" />
    Z: <input type="text" name="num3" />
    <input type="submit" />
</form>
<?php
if(isset($_GET['num1'])&&isset($_GET['num2'])&&isset($_GET['num3']))
{
    $n = [
        floatval($_GET['num1']),
        floatval($_GET['num2']),
        floatval($_GET['num3'])
    ];

    echo countNegative($n)%2!=0 && !in_array(0,$n)?
        'Negative':
        'Positive';
}

function countNegative(array $arr):int{
    $negCount = 0;

    foreach ($arr as $item)
        $negCount+= $item< 0? 1:0;
    return $negCount;
}
?>
</body>
</html>
