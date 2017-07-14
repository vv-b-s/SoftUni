<!DOCTYPE html>
<html>
<head>
    <title>Hello</title>
</head>
<body>
    <?php
        if(isset($_GET['num1']) && isset($_GET['num2'])) {
            $n1 = $_GET['num1'];
            $n2 = $_GET['num2'];

            echo " $n1 + $n2 = " . ($n1 + $n2);
        }
    ?>
    <form>
        <div>First Number:</div>
        <input type="number" name="num1" />
        <div>Second Number:</div>
        <input type="number" name="num2" />
        <div><input type="submit" /></div>
    </form>
</body>
</html>