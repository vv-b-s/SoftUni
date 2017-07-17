<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <title>First Steps Into PHP</title>
    <style>
        div {
            display: inline-block;
            margin: 5px;
            width: 20px;
            height: 20px;
        }
    </style>
</head>
<body>
<?php
for($i=0,$greyRow = 0;$i<5;$i++,$greyRow+=51) {
    for ($j = 0, $greyCol = $greyRow; $j < 10; $j++, $greyCol += 5)
        echo "<div style = 'background-color: rgb($greyCol,$greyCol,$greyCol)'></div>";
    echo '<br>';
}
?>
</body>
</html>
