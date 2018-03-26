<?php
	include('connect.php');
	include('session.php');
	
	$software_id = isset($_GET['software_id']) ? $_GET['software_id'] : '';
	$sql = "";
	
	if (empty($software_id))
	{
		$sql = "select * FROM hells_software";
	}
	else
	{
		$safe_software_id = mysqli_real_escape_string($conn, $software_id);
		$sql = "select * FROM hells_software WHERE software_id = '$safe_software_id'";
	}
	
	if (mysqli_query($conn, $sql))
	{
		$return_arr = array();
		$result = mysqli_query($conn, $sql);
		while($row = mysqli_fetch_assoc($result))
		{
			$software_arr['approver_id'] = $row['approver_id'];
			$software_arr['first_name'] = $row['first_name'];
			$software_arr['last_name'] = $row['last_name'];
			$software_arr['software_id'] = $row['software_id'];
			$software_arr['software_name'] = $row['software_name'];
			$software_arr['software_acronym'] = $row['software_acronym'];
			$software_arr['software_province'] = $row['software_province'];
			
			array_push($return_arr, $software_arr);
		}
		echo json_encode($return_arr);
	}
	
	mysqli_close($conn);
?>