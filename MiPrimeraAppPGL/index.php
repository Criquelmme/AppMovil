<?php
$DBuser = "cpr52313_test";
$DBpass = "ppopxxed";  // en mi caso tengo contraseña pero en casa caso introducidla aquí.
$DBhost = "localhost";
$DBname = "cpr52313_test_usr";

try{
  
    $DBcon = new PDO("mysql:host=$DBhost;dbname=$DBname",$DBuser,$DBpass);
    $DBcon->setAttribute(PDO::ATTR_ERRMODE, PDO::ERRMODE_EXCEPTION);
    
   }catch(PDOException $ex){
    
    die($ex->getMessage());
   }
$query = "SELECT * FROM usuarios";
 
$stmt = $DBcon->prepare($query);
$stmt->execute();

$userData = array();

while($row=$stmt->fetch(PDO::FETCH_ASSOC)){
  
      $userData = $row;
 
}

echo json_encode($userData);

