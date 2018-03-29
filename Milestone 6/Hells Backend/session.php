<?php
	session_start();

	$user_id = isset($_SESSION['login_id']) ? $_SESSION['login_id'] : '';
	$user_type = isset($_SESSION['login_type']) ? $_SESSION['login_type'] : '';

	if (empty($user_id) || empty($user_type))
	{
		session_destroy();
		die();
		mysqli_close($conn);
	}
	
	$sql = "SELECT * FROM " . $user_type . " WHERE " . $user_type . "_id = '$user_id'";
	
	if (mysqli_query($conn, $sql)) 
	{
		$result        = mysqli_query($conn, $sql);
		$row           = mysqli_fetch_assoc($result);
		
		$login_session = $row[$user_type . "_id"];
    
		if (!isset($login_session)) {
			session_destroy();
			mysqli_close($conn);
			die();
		}
	}
?>