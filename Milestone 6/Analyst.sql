DROP TABLE IF EXISTS Analyst;

CREATE TABLE Analyst (
  analyst_id int(10) NOT NULL,
  first_name varchar(30) NOT NULL,
  last_name varchar(30) NOT NULL,
  user_name varchar(30) NOT NULL,
  email varchar(50) NOT NULL,
  password varchar(30) NOT NULL,
  PRIMARY KEY (analyst_id)
);

-- populate with more analysts 
insert into Analyst (analyst_id, first_name, last_name, user_name, email, password) values (1, 'John', 'Doe', 'john_doe', 'john_doe@hell.ca', 'a94a8fe5ccb19ba61c4c0873d391e987982fbbd3');



