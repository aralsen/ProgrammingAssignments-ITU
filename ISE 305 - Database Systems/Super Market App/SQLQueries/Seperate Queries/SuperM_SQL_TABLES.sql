create database managementDB

go

use managementDB

go

create table job_types (
    job_id int identity(1, 1) primary key,
    description nvarchar(15) not null
)

go

create table employees (
	employee_id int primary key,
	email nvarchar(100) unique not null,
	name nvarchar(100) not null, 
	phone char(14) not null,
	age int not null,
	job_id int foreign key references job_types(job_id) not null,
	password varchar(50) not null
)

go

create table categories (
	category_id int primary key,
	category_name varchar(50) not null,
	description varchar(250) not null
)

go

create table products (
	product_id int primary key,
	product_name varchar(100) not null,
	stock int not null,
	price int not null,
	category_id int foreign key references categories(category_id) not null
)

go

create table bills (
	bill_id int primary key,
	employee_id int foreign key references employees(employee_id) not null,
	bill_date varchar(50) not null,
	total_amount int not null
)