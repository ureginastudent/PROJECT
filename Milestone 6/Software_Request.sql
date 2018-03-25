DROP TABLE IF EXISTS Software_Request;

CREATE TABLE Software_Request (
  request_id int(10) NOT NULL,
  user_id int(10) NOT NULL,
  software_id int(10) NOT NULL,
  approver_id int(10) NOT NULL,
  approved_status varchar(50) NOT NULL,
  PRIMARY KEY (request_id),
  FOREIGN KEY (user_id) REFERENCES User(user_id),
  FOREIGN KEY (approver_id) REFERENCES Approver(approver_id)
);


-- populate with software requests
insert into Approver (approver_id, first_name, last_name, user_name, email, password) values (1, '', '', '', '', '');