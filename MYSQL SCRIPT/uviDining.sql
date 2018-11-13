DROP DATABASE `uvi_dining`;

create database if not exists UVI_Dining;
use UVI_Dining;

create table Campus(
campus_id INT NOT NULL AUTO_INCREMENT,
campus_loc VARCHAR(45),
PRIMARY KEY(campus_id));

create table Admins(
admin_id INT NOT NULL AUTO_INCREMENT,
FName VARCHAR(45),
LName VARCHAR(45),
Email VARCHAR(45),
Password VARCHAR(45),
user_Status VARCHAR(45),
campus_id INT NOT NULL,
PRIMARY KEY(admin_id),
FOREIGN KEY (campus_id) references Campus(campus_id),
UNIQUE (Email));

create table Foods(
food_id INT NOT NULL AUTO_INCREMENT,
food_name VARCHAR(45),
food_category VARCHAR(45),
campus_id INT NOT NULL,
PRIMARY KEY(food_id),
FOREIGN KEY (campus_id) references Campus(campus_id),
UNIQUE (food_name));

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

INSERT INTO campus(campus_loc) values('STT');
INSERT INTO admins (FName,LName,Email,Password,user_Status,campus_id) VALUES('fish','cat','t@yahoo.com','123po','student',1);






