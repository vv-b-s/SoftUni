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
function factorial(float $number):float {
    if ($number == 0)
        return 1;
    return $number * factorial($number - 1);
}

    if(isset($_GET['num'])){
        echo factorial(floatval($_GET['num']));
    }
?>
</body>
</html>
