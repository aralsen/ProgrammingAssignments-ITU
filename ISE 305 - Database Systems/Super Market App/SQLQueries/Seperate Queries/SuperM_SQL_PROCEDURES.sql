/* LOGIN */

create or alter procedure sp_get_employee(@email nvarchar(100), @password varchar(50))
as
begin
		select count(1) from employees
			where email = @email and password = @password
end

go

/* CATEGORY */

create or alter procedure sp_display_categories
as
begin
		select * from categories
end

go

create or alter procedure sp_get_category_names
as
begin
	select category_name from categories
end

go

create or alter procedure sp_add_category (@category_id int, @category_name varchar(50), @description varchar(250))
as
begin
		insert into categories values (@category_id, @category_name, @description)
end

go

create or alter procedure sp_delete_category (@category_id int)
as
begin
		delete from categories where category_id = @category_id
end

go

create or alter procedure sp_update_category (@category_id int, @category_name varchar(50), @description varchar(250))
as
begin
	update categories
		set category_name = @category_name,
			description = @description
			where category_id = @category_id
end

go

/* PRODUCT */

create or alter procedure sp_get_category_id (@category_name varchar(50))
as
begin
		select category_id from categories where category_name = @category_name
end

go

create or alter procedure sp_add_product (@product_id int, @product_name varchar(100), @stock int, @price int, @category_id int)
as
begin
	insert into products values (@product_id, @product_name, @stock, @price, @category_id)
end

go

create or alter procedure sp_display_products
as
begin
	select * from products
end

go

create or alter procedure sp_delete_product (@product_id int)
	as
		begin
			delete from products where product_id = @product_id
		end;
go

create or alter procedure sp_update_product (@product_id int, @product_name varchar(100), @stock int, @price int, @category_id int)
as
begin
	update products
		set product_name = @product_name,
			stock = @stock,
			price = @price,
			category_id = @category_id
			where product_id = @product_id
end

go

create or alter procedure sp_get_product_names
as
begin
	select product_name from products
end

go

create or alter procedure sp_get_products_by_category (@category_name varchar(50))
as
begin
	select p.product_id, p.product_name, p.stock, p.price, p.category_id from products p, categories c where c.category_name = @category_name and c.category_id = p.category_id
end

go

/* BILL */

create or alter procedure sp_add_bill (@bill_id int, @employee_id int, @bill_date varchar(50), @total_amount int)
as
begin
	insert into bills values (@bill_id, @employee_id, @bill_date, @total_amount)
end

go

create or alter procedure sp_delete_bill(@bill_id int)
as
begin
	delete from bills where bill_id = @bill_id
end

go

create or alter procedure sp_get_bills
as
begin
	select b.bill_id, b.employee_id, b.bill_date, b.total_amount from bills b
end

/* SELLING */

go

create or alter procedure sp_get_product_namepricequantity
as
begin
	select product_name, price, stock from products
end

go

create or alter procedure sp_get_product_namepricequantity_by_category(@category_name varchar(50))
as
begin
	select product_name, price, stock from products p, categories c
		where c.category_name = @category_name and p.category_id = c.category_id
end

go

/* EMPLOYEE */

create or alter procedure sp_get_employee_id (@email nvarchar(100))
as
begin
		select employee_id from employees where email = @email
end

go

create procedure sp_display_managers
as
begin
	select * from employees where job_id = 1
end

go

create procedure sp_display_salespersons
as
begin
	select * from employees where job_id = 2
end

go

create or alter procedure sp_add_employee (@employee_id int, @email nvarchar(100), @name nvarchar(100), @phone char(14), @age int, @job_id int, @password varchar(50))
as
begin
	insert into employees values
		(@employee_id, @email, @name, @phone, @age, @job_id, @password)
end

go

create or alter procedure sp_delete_employee (@employee_id int)
as
begin
	delete from employees where employee_id = @employee_id
end

go

create or alter procedure sp_update_employee (@employee_id int, @email nvarchar(100), @name nvarchar(100), @phone char(14), @age int, @job_id int, @password varchar(50))
as
begin
	update employees
		set 
			employee_id = @employee_id,
			email = @email,
			name = @name,
			phone = @phone,
			age = @age,
			job_id = @job_id,
			password = @password
		where employee_id = @employee_id
end

go
