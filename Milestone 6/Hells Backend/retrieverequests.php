<?php
	include('connect.php');
	include('session.php');
	
	$all = isset($_GET['all']) ? $_GET['all'] : '';
	$sql = "";
	
	if (!empty($all))
	{
		$sql = "select * FROM software_request";
	}
	else
	{
	    $sql = "select * FROM software_request WHERE user_id = '$user_id'";
	}
	
	if (mysqli_query($conn, $sql))
	{
		$return_arr = array();
		$result = mysqli_query($conn, $sql);
		while($row = mysqli_fetch_assoc($result))
		{
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