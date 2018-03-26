<?php
	include('connect.php');
	
	$user_name = isset($_GET["user"]) ? $_GET["user"] : '';
    $user_pass  = isset($_GET["pass"]) ? $_GET["pass"] : '';
	$type = isset($_GET["type"]) ? $_GET["type"] : '';
	
	
	if (empty($user_name) || empty($user_pass) || empty($type))
	{
		mysqli_close($conn);
		die("Invalid parameters");
	}
	
	$id = "";
	
	if ($type == "User")
	{
		$id = "user_id";
		$type = "hells_user";
	}
	else if ($type == "Approver")
	{
		$id = "approver_id";
		$type = "approver";
	}
	else if ($type == "Analyst")
	{
		$id = "analyst_id";
		$type = "analyst";
	}
	
	$sql = "SELECT " . $id . ", user_name, password FROM " . $type . " WHERE user_name = '$user_name' and password = '$user_pass'";
	
	$result = mysqli_query($conn, $sql);
	$row = mysqli_fetch_assoc($result);
	
	if (mysqli_num_rows($result)==0){
		
		mysqli_close($conn);
		die("Invalid Credentials");
	}
	
	echo "success:" . $row[$id];
	
	mysqli_close($conn);
	
?>