DROP DATABASE `uvi_dining`;

create database if not exists UVI_Dining;
use UVI_Dining;

-- create campus table to insert STT and STX
create table Campus(
campus_id INT NOT NULL AUTO_INCREMENT,
campus_loc VARCHAR(45),
PRIMARY KEY(campus_id));

-- create admins table for staff info
create table Admins(
admin_id INT NOT NULL AUTO_INCREMENT,
FName VARCHAR(45),
LName VARCHAR(45),
Email VARCHAR(45),
Password VARCHAR(45),
user_Status VARCHAR(45),
campus_id INT NOT NULL,
PRIMARY KEY(admin_id,campus_id),
FOREIGN KEY (campus_id) references Campus(campus_id),
UNIQUE (Email));

-- create foods table food
create table Foods(
food_id INT NOT NULL AUTO_INCREMENT,
food_name VARCHAR(45),
food_category VARCHAR(45),
campus_id INT NOT NULL,
PRIMARY KEY(food_id),
FOREIGN KEY (campus_id) references Campus(campus_id),
UNIQUE (food_name));

-- create menu table
create table Menu(
menu_id INT NOT NULL AUTO_INCREMENT,
menu_name VARCHAR(45),
campus_id INT NOT NULL,
PRIMARY KEY(menu_id),
FOREIGN KEY (campus_id) references Campus(campus_id),
UNIQUE (menu_name));

create table Dish(
food_id INT NOT NULL,
menu_id INT NOT NULL,
campus_id INT NOT NULL,
PRIMARY KEY(food_id, menu_id),
FOREIGN KEY (campus_id) references Campus(campus_id));

create table PlanMeal(
MDate DATE,
Meal VARCHAR(45),
campus_id INT NOT NULL,
menu_id INT NOT NULL,
PRIMARY KEY(MDate,Meal,menu_id),
FOREIGN KEY (campus_id) references Campus(campus_id));

INSERT INTO campus(campus_loc) values('STT'),('STX');

-- create two staff
INSERT INTO admins (FName,LName,Email,Password,user_Status,campus_id) VALUES('Bianca','Beth','bb@yahoo.com','bianca','Manager',1);
INSERT INTO admins (FName,LName,Email,Password,user_Status,campus_id) VALUES('Rhonda','Forbes','rf@yahoo.com','yea','Cashier',2);

-- insert foods for STT
insert into foods(food_name,food_category,campus_id) values('mahi mahi','Meat','1');
insert into foods(food_name,food_category,campus_id) values('salmon','Meat','1');
insert into foods(food_name,food_category,campus_id) values('Cheese','Dairy','1');

-- insert food for STX
insert into foods(food_name,food_category,campus_id) values('Bacon','Meat','2');
insert into foods(food_name,food_category,campus_id) values('Meatballs','Meat','2');
insert into foods(food_name,food_category,campus_id) values('Milk','Dairy','2');



