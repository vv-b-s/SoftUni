<?php
echo "<ul>";
for($i=1;$i<=20;$i++){
    echo $i%2!=0?
        "<li><span style='color: blue;'>{$i}</span></li>":
        "<li><span style='color: green;'>{$i}</span></li>";
}

echo "</ul>";