<?php include 'view/header.php'?>
<?php
$servername = "localhost:3306";
$username = "root";
$password = "root";
$dbname = "websoft";


$conn = new mysqli($servername, $username, $password, $dbname);

if ($conn->connect_error) {
    die("Connection failed: " . $conn->connect_error);
}

$id = $_GET["ID"];
$sql = "DELETE FROM tech WHERE idtech='".$id."'";

if ($conn->query($sql) === TRUE) {
    echo "Record deleted successfully";
} else {
    echo "Error deleting record: " . $conn->error;
}

$conn->close();
?>
