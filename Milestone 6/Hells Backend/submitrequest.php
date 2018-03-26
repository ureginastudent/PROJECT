<?php
	include('connect.php');
	include('session.php');
	
	if ($user_type != "user")
	{
		mysqli_close($conn);
		die("Invalid user type");
	}

	$software_id = isset($_GET['software_id']) ? $_GET['software_id'] : '';

	$safe_user_id = $user_id;
	$safe_software_id = mysqli_real_escape_string($conn, $software_id);
	
	$sql = "SELECT approver_id FROM hells_software WHERE software_id = '$safe_software_id'";
	
	$result = mysqli_query($conn, $sql);
	$row = mysqli_fetch_assoc($result);
	
	if (mysqli_num_rows($result)==0){
		
		mysqli_close($conn);
		die("Failed to locate software");
	}
	
	$approver_id = $row['approver_id'];
	
	$sql = "SELECT * FROM software_request WHERE software_id = '$safe_software_id' and user_id = '$safe_user_id'";
	
	$result = mysqli_query($conn, $sql);
	$row = mysqli_fetch_assoc($result);
	
	if (mysqli_num_rows($result)>0){
		
		mysqli_close($conn);
		die("Software already requested");
	}

	$sql = "INSERT INTO software_request (user_id, software_id, approver_id)
			VALUES ('$safe_user_id', '$safe_software_id', '$approver_id')";
								
	$result = mysqli_query($conn, $sql);

	echo $result;
	
	mysqli_close($conn);
	
?>