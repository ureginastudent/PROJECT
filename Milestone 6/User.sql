DROP TABLE IF EXISTS User;

CREATE TABLE User (
  user_id int(10) NOT NULL,
  user_name varchar(30) NOT NULL,
  email varchar(50) NOT NULL,
  password varchar(30) NOT NULL,
  PRIMARY KEY (user_id)
);

-- populate with users
insert into User (user_id, first_name, last_name, user_name, email, password) values (1, '', '', '', '', '');