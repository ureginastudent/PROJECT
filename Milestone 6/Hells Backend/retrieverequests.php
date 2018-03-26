<?php
	include('connect.php');
	
	
	$user_id = isset($_GET['user_id']) ? $_GET['user_id'] : '';
	
	if (empty($user_id))
	{
		mysqli_close($conn);
		die("Invalid parameters");
	}

	$safe_variable = mysqli_real_escape_string($conn, $user_id);
	$sql = "";
	
	if ($safe_variable == "*")
	{
		$sql = "select * FROM software_request";
	}
	else
	{
	    $sql = "select * FROM software_request WHERE user_id = '$safe_variable'";
	}

	if (mysqli_query($conn, $sql))
	{
		$return_arr = array();
		$result = mysqli_query($conn, $sql);
		while($row = mysqli_fetch_assoc($result))
		{
			$software_arr['request_id'] = $row['request_id'];
			$software_arr['user_id'] = $row['user_id'];
			$software_arr['software_id'] = $row['software_id'];
			$software_arr['approver_id'] = $row['approver_id'];
			$software_arr['approved_status'] = $row['approved_status'];
			
			array_push($return_arr, $software_arr);
		}
		echo json_encode($return_arr);
	}
	
	mysqli_close($conn);
?>