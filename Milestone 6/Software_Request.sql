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
insert into Software_Request (request_id, user_id, software_id, approver_id, approved_status) values (1, 1, 1, 1, '');