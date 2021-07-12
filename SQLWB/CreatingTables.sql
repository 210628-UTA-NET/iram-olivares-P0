-- Customer Table
-- One Customer to Many Orders
-- CustomerID to uniquely identify Customers
create table Customers(
	CustomerID int IDENTITY,
	CustomerName varchar(30),
	CustomerAddress varchar(30),
	CustomerEmail varchar(30),
	CustomerPhone varchar (30),
	
	CONSTRAINT PK_CustomerID PRIMARY KEY (CustomerID)
)

-- Store Table
-- One Store to Many Orders
-- One Store to Many LineItems
-- StoreID to uniquely identify a Store
create table Stores(
	StoreID int IDENTITY,
	StoreName varchar(30),
	StoreAddress varchar(30),
	
	CONSTRAINT PK_StoreID PRIMARY KEY (StoreID)
)

-- Order Table
-- One Order to Many LineItems
-- Many Orders to One Customer (FK references CustomerID)
-- Many Orders to One StoreFront (FK references StoreID)
-- OrderID to uniquely identify an Order
create table Orders(
	OrderID int IDENTITY,
	Order_CustomerID int,
	Order_StoreID int,
	OrderLocation varchar(30),
	OrderPrice smallmoney,
	
	CONSTRAINT PK_OrderID PRIMARY KEY (OrderID),
	CONSTRAINT FK_Order_CustomerID FOREIGN KEY (Order_CustomerID) REFERENCES Customers(CustomerID),
	CONSTRAINT FK_Order_StoreID FOREIGN KEY (Order_StoreID) REFERENCES Stores(StoreID)
)

-- Product Table
-- One Product to One LineItem
-- ProductID to uniquely identify a Product
create table Products(
	ProductID int IDENTITY,
	ProductName varchar(30),
	ProductPrice smallmoney,
	
	CONSTRAINT PK_ProductID PRIMARY KEY (ProductID),
)

-- LineItem Table
-- Many LineItems to One Order (FK references OrderID)
-- Many LineItems to One Store (FK references StoreID)
-- One LineItem to One Product (FK references ProductID)
-- LineItemID to uniquely identify a LineItem
create table LineItems(
	LineItemID int IDENTITY,
	LineItem_OrderID int,
	LineItem_StoreID int,
	LineItem_ProductID int,
	LineItemQuantity int,
	
	CONSTRAINT PK_LineItemID PRIMARY KEY (LineItemID),
	CONSTRAINT FK_LineItem_OrderID FOREIGN KEY (LineItem_OrderID) REFERENCES Orders(OrderID),
	CONSTRAINT FK_LineItem_StoreID FOREIGN KEY (LineItem_StoreID) REFERENCES Stores(StoreID),
	CONSTRAINT FK_LineItem_ProductID FOREIGN KEY (LineItem_ProductID) REFERENCES Products(ProductID)
)