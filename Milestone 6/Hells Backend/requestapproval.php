<?php
	include('connect.php');
	include('session.php');
	
	if ($user_type != "analyst")
	{
		mysqli_close($conn);
		die("Invalid user type");
	}
	
	$software_id = isset($_GET['software_id']) ? $_GET['software_id'] : '';
	$user_id_software = isset($_GET['user_id']) ? $_GET['user_id'] : '';
	
	if (empty($user_id_software) || empty($software_id))
	{
		mysqli_close($conn);
		die("Invalid parameters");
	}
	
	$safe_user_id = mysqli_real_escape_string($conn, $user_id_software);
	$safe_software_id = mysqli_real_escape_string($conn, $software_id);
	
	$sql = "UPDATE software_request SET approved_status='pending approval' WHERE software_id = '$safe_software_id' and user_id = '$safe_user_id'";
	$result = mysqli_query($conn, $sql);

	echo $result;
	mysqli_close($conn);
?>