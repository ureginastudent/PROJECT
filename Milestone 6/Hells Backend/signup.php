<?php
	include('connect.php');
	/**TODO: implement captcha to prevent DOS and overpopulation**/
	
	
	$em = isset($_GET["email"]) ? $_GET["email"] : '' ;
	$pd = isset($_GET["pass"]) ? $_GET["pass"] : '';
	$un = isset($_GET["user"]) ? $_GET["user"] : '';

	if (empty($em) || empty($pd) || empty($un))
	{
		mysqli_close($conn);
		die("Invalid parameters");
	}
	
	
	$sql = "select user_name FROM hells_user WHERE user_name = '$un'";
	
	if (mysqli_query($conn, $sql)) 
	{
		$result        = mysqli_query($conn, $sql);
		$row           = mysqli_fetch_assoc($result);
		$login_session = $row['user_name'];
    
		if (isset($login_session)) {
			mysqli_close($conn);
			die("User Already Exists");
		}
	}
	else
	{
		mysqli_close($conn);
		die("Error checking for user");
	}
	
	$sql = "INSERT INTO hells_user (user_name, email, password)
								VALUES ('$un', '$em', '$pd')";
	
	
	if (mysqli_query($conn, $sql))
	{
		echo "success";
		
	}

	mysqli_close($conn);
?>