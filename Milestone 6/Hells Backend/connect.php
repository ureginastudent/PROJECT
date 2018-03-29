<?php
	$conn = mysqli_connect("localhost", "ellia20i", "123123", "ellia20i");
	
	if (!$conn) 
	{ 
		die("Connection failed: " . mysqli_connect_error());
	}
?>