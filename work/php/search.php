<html lang="en">
<head>
    <meta charset="utf-8">
    <title>Search</title>
    <link rel="stylesheet" href="css/style.css">
    <link rel="icon" href="favicon.ico">
</head>
</html>
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

$sql = "SELECT idtech, fname, lname FROM tech";
$result = $conn->query($sql);

if ($result->num_rows > 0) {
    
    while($row = $result->fetch_assoc()) {
        echo "<br> ". $row["idtech"]. " - Name: ". $row["fname"]. " " . $row["lname"] . "<br>";
    }
} else {
    echo "0 results";
}

$conn->close();
?>

</tbody>
  </table>
  </div>
  <?php include 'view/footer.php'?>
</body>
</html>
