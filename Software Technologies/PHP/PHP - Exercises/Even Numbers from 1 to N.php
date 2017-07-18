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
    echo getEvenNums(intval($_GET['num']));
}

function getEvenNums(int $n):string {
    $output = [];
    for($i=2;$i<=$n;$i+=2)
        $output[] = $i;
    return implode(' ',$output);
}
?>
</body>
</html>
