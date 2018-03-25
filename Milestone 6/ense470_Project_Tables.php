<?php

$conn = mysqli_connect("localhost", "cross23j", "Rest238", "cross23j");

// if failed to establish a connection, then exit the php program
if (!$conn) {
  die("connection failed: " . mysqli_connect_error());
}

// creates table for Users
$sql = "CREATE TABLE User (
  user_id int(10) NOT NULL,
  user_name varchar(30) NOT NULL,
  email varchar(50) NOT NULL,
  password varchar(30) NOT NULL,
  PRIMARY KEY (user_id)
  )";

if (mysqli_query($conn, $sql)) {
    echo "\nTable User created successfully.\n";
} 
else {
    echo "Error creating table: " . mysqli_error($conn);
}

// creates table for Approvers
$sql = "CREATE TABLE Approver (
  approver_id int(10) NOT NULL,
  first_name varchar(30) NOT NULL,
  last_name varchar(30) NOT NULL,
  user_name varchar(30) NOT NULL,
  email varchar(50) NOT NULL,
  password varchar(30) NOT NULL,
  PRIMARY KEY (approver_id)
  )";

if (mysqli_query($conn, $sql)) {
    echo "\nTable Approver created successfully.\n";
} 
else {
    echo "Error creating table: " . mysqli_error($conn);
}

// creates table for Analysts
$sql = "CREATE TABLE Analyst (
  analyst_id int(10) NOT NULL,
  first_name varchar(30) NOT NULL,
  last_name varchar(30) NOT NULL,
  user_name varchar(30) NOT NULL,
  email varchar(50) NOT NULL,
  password varchar(30) NOT NULL,
  PRIMARY KEY (analyst_id)
  )";

if (mysqli_query($conn, $sql)) {
    echo "\nTable Analyst created successfully.\n";
} 
else {
    echo "Error creating table: " . mysqli_error($conn);
}

// creates table for software requests

$sql = "CREATE TABLE Software_Request (
  request_id int(10) NOT NULL,
  user_id int(10) NOT NULL,
  software_id int(10) NOT NULL,
  approver_id int(10) NOT NULL,
  approved_status varchar(50) NOT NULL,
  PRIMARY KEY (request_id),
  FOREIGN KEY (user_id) REFERENCES User(user_id),
  FOREIGN KEY (approver_id) REFERENCES Approver(approver_id)
  )";

if (mysqli_query($conn, $sql)) {
    echo "\nTable Software_Request created successfully.\n";
} 
else {
    echo "Error creating table: " . mysqli_error($conn);
}

mysqli_close($conn);
?>


