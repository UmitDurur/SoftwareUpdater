<?php
$database = "database_name";
    $host = "localhost";
    $dbuser = "database_username";
    $dbpass = "database_pass";
    $baglan = new mysqli($host,$dbuser,$dbpass,$database);
if($baglan->connect_error){ die("Can not connect mysql: ".$baglan->connect_error);
}
    $baglan->query("SET NAMES UTF8");
?>