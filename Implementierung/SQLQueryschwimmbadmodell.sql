Use SwimmingPoolShop;

--If Object_ID ('Customer') Is not Null 
--drop table Customer; 

--If OBJECT_ID ('Product') is not null 
--drop table Product;

--If OBJECT_ID ('OrderItem') is not null
--drop table OrderItem;

--If OBJECT_ID ('CustomerOrder') is not null
--drop table CustomerOrder;


Create Table  Customer
(
Customer_ID int Primary Key not null,
CustomerName nvarchar(100) not null,
Email nvarchar(100)unique not null,
AccountPassword nvarchar(100)not null
)

Create Table Product 
(
Product_ID int Primary Key not null,
ProductName nvarchar (100) not null,
ProductDescription nvarchar(1000),
Price Decimal (20,2) not null,
Order_ID int,
foreign key (Order_ID) references CustomerOrder(Order_ID)
)

Create Table CustomerOrder
(
Order_ID int Primary Key not null,
Orderdate DATETIME DEFAULT CURRENT_TIMESTAMP,
TotalAmount Decimal(20,2),
Customer_ID int not Null
Foreign Key (Customer_ID) References Customer(Customer_ID)
	on delete cascade
)

Create Table Product_CustomerOrder
(
Product_ID int Foreign Key ,
Order_ID int Primary Key not null,
)

