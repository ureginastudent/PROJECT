<?php
	$conn = mysqli_connect("localhost", "root", "pass", "hells");
	
	if (!$conn) 
	{ 
		die("Connection failed: " . mysqli_connect_error());
	}
?>