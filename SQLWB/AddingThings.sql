-- Add some store products
INSERT INTO Products(ProductName, ProductPrice) VALUES
	('Small Harina Tortillas', 2.75),
	('Large Harina Tortillas', 5.00),
	('Trigo Tortillas', 3.00),
	('Yellow Maize Tortillas', 1.50),
	('Red Maize Tortillas', 2.00),
	('Maseca Tortillas', 1.50),
	('1 lb. of Barbacoa', 12.00),
	('2 lb. of Barbacoa', 24.00),
	('0.5 lb. of Barbacoa', 6.00),
	('Pack of Tamales', 8.00),
	('Large Cup of Pinto Beans', 4.00),
	('Cup of Salsa', 3.00);
	
-- Add Two Stores for now
INSERT INTO Stores VALUES
	('Olivares Tortilla Factory', '127 Corn Road'),
	('Los Amigos Tortilleria', '9987 Flour Street')

-- Add a customer
INSERT INTO Customers VALUES
	('Bobby', '112 Wick Way', 'mrmr@gogmail.com', '54856891458')