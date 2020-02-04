<?php include 'view/header.php'?>

<?php
$servername = "localhost:3306";
$username = "root";
$password = "root";
$dbname = "websoft";

// Create connection
$conn = new mysqli($servername, $username, $password, $dbname);
// Check connection
if ($conn->connect_error) {
    die("Connection failed: " . $conn->connect_error);
}
$firstName=$_GET["FirstName"];
$id = $_GET["ID"];
$lastName=$_GET["LastName"];
$sql = "INSERT INTO tech (idtech, fname, lname)
VALUES ('".$id."', '".$firstName."', '".$lastName."')";

if ($conn->query($sql) === TRUE) {
    echo "New record created successfully";
} else {
    echo "Error: " . $sql . "<br>" . $conn->error;
}

$conn->close();
?>
</tbody>
  </table>
  </div>
  <?php include 'view/footer.php'?>
</body>
</html>
