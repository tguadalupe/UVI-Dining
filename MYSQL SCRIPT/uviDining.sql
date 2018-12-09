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
food_name VARCHAR(45) NULL,
food_category VARCHAR(45) NULL,
campus_id INT NOT NULL,
PRIMARY KEY(food_id),
FOREIGN KEY (campus_id) references Campus(campus_id),
UNIQUE (campus_id,food_name));

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
INSERT INTO admins (FName,LName,Email,Password,user_Status,campus_id) VALUES('Bianca','Beth','bb@yahoo.com','bianca','Manager',2);
INSERT INTO admins (FName,LName,Email,Password,user_Status,campus_id) VALUES('Rhonda','Forbes','rf@yahoo.com','yea','Cashier',1);

-- insert foods for STT
insert into foods(food_name,food_category,campus_id) values('mahi mahi','Meat','1');
insert into foods(food_name,food_category,campus_id) values('salmon','Meat','1');
insert into foods(food_name,food_category,campus_id) values('Potatoes','Vegetables','1');
insert into foods(food_name,food_category,campus_id) values('Pizza','Meat','1');
insert into foods(food_name,food_category,campus_id) values('Pork','Meat','1');
insert into foods(food_name,food_category,campus_id) values('Cheese','Dairy','1');
insert into foods(food_name,food_category,campus_id) values('Milk','Dairy','1');
insert into foods(food_name,food_category,campus_id) values('Apple','Fruits','1');
insert into foods(food_name,food_category,campus_id) values('Sprite','Drink','1');
insert into foods(food_name,food_category,campus_id) values('Rice','Grains','1');
insert into foods(food_name,food_category,campus_id) values('Orange','Fruits','1');


-- insert food for STX
insert into foods(food_name,food_category,campus_id) values('Bacon','Meat','2');
insert into foods(food_name,food_category,campus_id) values('Meatballs','Meat','2');
insert into foods(food_name,food_category,campus_id) values('Milk','Dairy','2');


-- testing food insert STT in Menu
insert into Menu(menu_name,campus_id) value('Menu for Monday','1');
insert into Menu(menu_name,campus_id) value('Menu for Tuesday','1');
insert into Menu(menu_name,campus_id) value('Menu for Wednesday','1');

-- testing Dish insert infor to Dish table as test 
insert into Dish(food_id,menu_id,campus_id) values(7, 1, 1),(10, 1, 1),(11, 1, 1),
(8, 2, 1),(12, 2, 1), (10, 2, 1),
(9, 3, 1),(13, 3, 1), (10, 3, 1);

-- insert into Dish(food_id,menu_id,campus_id) value('1','1','1');
-- insert into Dish(food_id,menu_id,campus_id) value('2','1','1');
-- insert into Menu(menu_id,menu_name,campus_id) value('1','','1');

-- testing someway
-- select f.food_name from foods f join Dish d on d.food_id = f.food_id;
-- select f.food_name from foods f join Dish d on d.food_id = f.food_id where d.menu_id = 1;
-- select f.food_name from foods f join Dish d on d.food_id = f.food_id where d.menu_id = 1;
-- testing to see if the dish table work by showing the food name

-- get all the food_name to see if Dish work as test
select f.food_name from foods f join Dish d on d.food_id = f.food_id;

Select foods.food_name  from foods join Dish on Dish.food_id = foods.food_id 
Where Dish.menu_id = 1;

-- testing script
select menu_name 
from Menu 
where campus_id = 1 and menu_id = 2;

select Menu.menu_name, Foods.food_name
from Menu join Dish on Dish.menu_id = Menu.menu_id and Dish.campus_id = Menu.campus_id
join Foods on Foods.food_id = Dish.food_id 
where Menu.menu_id = 1;

select Foods.food_name from Foods where food_id = 11;

select Menu.menu_name, Foods.food_name 
from Menu join Dish on Dish.menu_id = Menu.menu_id and Dish.campus_id = Menu.campus_id
join Foods on Foods.food_id = Dish.food_id and Foods.campus_id = Dish.campus_id
where Foods.food_id = 11;

-- list all menus and what they contain
select m.menu_name , f.food_name 
from Menu m join Dish d on d.menu_id = m.menu_id and d.campus_id = m.campus_id
join Foods f on f.food_id = d.food_id and f.campus_id = d.campus_id;




