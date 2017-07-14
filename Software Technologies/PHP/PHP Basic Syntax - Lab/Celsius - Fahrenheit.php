<!DOCTYPE html>
<html>
<head>
    <title>Hello</title>
</head>
<body>
    <?php
    function ToCel() {
        if(isset($_GET['fah'])){
            $deg = $_GET['fah'];
            $degC = ($deg-32)/1.8;
            return "$deg &deg;F = $degC &deg;C";
        }
        else return "";
    }

    function ToFah(){
        if(isset($_GET['cel'])){
            $deg = $_GET['cel'];
            $degF = $deg*1.8+32;
            return "$deg &deg;C = $degF &deg;F";
        }
        else return "";
    }
    ?>
    <form>
        Celsius: <input type="text" name="cel" />
        <input type="submit" value="Convert">
        <?= ToFah(); ?>
    </form>
    <form>
        Fahrenheit: <input type="text" name="fah" />
        <input type="submit" value="Convert">
        <?= ToCel(); ?>
    </form>
</body>
</html>