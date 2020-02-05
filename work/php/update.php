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

    $firstName=$_GET["FirstName"];
    $id = $_GET["ID"];
    $lastName=$_GET["LastName"];
    $sql = "UPDATE tech SET fname='".$firstName."',lname='".$lastName."' WHERE idtech='".$id."'";

    if ($conn->query($sql) === TRUE) {
        echo "Record updated successfully";
    } else {
        echo "Error updating record: " . $conn->error;
    }

    $conn->close();



?>

</tbody>
  </table>
  </div>
  <?php include 'view/footer.php'?>
</body>
</html>
