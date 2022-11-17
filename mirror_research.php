<?php

$cors_whitelist = [
    'https://theindiedream.itch.io/transfer/',
    'https://theindiedream.itch.io/',
    'https://v6p9d9t4.ssl.hwcdn.net',
    'https://itch.io/',
    'https://itch.zone/',
];
  
if (in_array($_SERVER['HTTP_ORIGIN'], $cors_whitelist)) 
{
    header('Access-Control-Allow-Origin: ' . $_SERVER['HTTP_ORIGIN']);
}

define("DBHOST","localhost");
define("DBUSER","brandrz2_player");
define("DBPASS","(YSy3#HQ.XiH");
define("DBNAME","brandrz2_Mirror");

$connection = new mysqli(DBHOST,DBUSER,DBPASS, DBNAME);

if (isset($_POST['store_research']))
{
    $ID = $_POST['ID'];
    $TREAT = $_POST['TREAT'];
	
	$CMP = mysqli_escape_string($connection, $_POST['CMP']);
    $CMP = filter_var($CMP, FILTER_SANITIZE_STRING, FILTER_FLAG_STRIP_LOW | FILTER_FLAG_STRIP_HIGH);
	
    $CLN = $_POST['CLN'];
    $JMP = $_POST['JMP'];
	
	$TSPB = mysqli_escape_string($connection, $_POST['TSPB']);
    $TSPB = filter_var($TSPB, FILTER_SANITIZE_STRING, FILTER_FLAG_STRIP_LOW | FILTER_FLAG_STRIP_HIGH);
	
	$TTCL = mysqli_escape_string($connection, $_POST['TTCL']);
    $TTCL = filter_var($TTCL, FILTER_SANITIZE_STRING, FILTER_FLAG_STRIP_LOW | FILTER_FLAG_STRIP_HIGH);
	
    $KCST = $_POST['KCST'];
    $KCSA = $_POST['KCSA'];
    $KCSB = $_POST['KCSB'];
    $KCSC = $_POST['KCSC'];
    $KCSD = $_POST['KCSD'];
    $KCSE = $_POST['KCSE'];
    $KCSF = $_POST['KCSF'];
    $PCBT = $_POST['PCBT'];
    $PCBA = $_POST['PCBA'];
    $PCBB = $_POST['PCBB'];
    $PCBC = $_POST['PCBC'];
    $PCBD = $_POST['PCBD'];

    $statement = $connection->prepare("INSERT INTO mirror_research (ID, TREAT, CMP, CLN, JMP, TSPB, TTCL, KCST, KCSA, KCSB, KCSC, KCSD, KCSE, KCSF, PCBT, PCBA, PCBB, PCBC, PCBD) VALUES (?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?)");
    $statement->bind_param("si", $ID, $TREAT, $CMP, $CLN, $JMP, $TSPB, $TTCL, $KCST, $KCSA, $KCSB, $KCSC, $KCSD, $KCSE, $KCSF, $PCBT, $PCBA, $PCBB, $PCBC, $PCBD);

    $statement->execute();
    $statement->close();
}

$connection->close();

?>