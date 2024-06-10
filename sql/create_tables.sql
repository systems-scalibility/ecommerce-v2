CREATE TABLE Product (
    Id INT AUTO_INCREMENT PRIMARY KEY,
    ProductName NVARCHAR(100) NOT NULL,
    CodeNumber NVARCHAR(100) NOT NULL,
    ProductDescription NVARCHAR(255),
    UnitPrice FLOAT NOT NULL,
    RowGuid CHAR(36) NOT NULL,
    DateCreated DATETIME NOT NULL,
    DateUpdated DATETIME NOT NULL
);

CREATE TABLE SalesOrder (
    Id INT AUTO_INCREMENT PRIMARY KEY,
    CodeNumber NVARCHAR(100) NOT NULL,
    OrderDate DATETIME NOT NULL,
    OrderDescription NVARCHAR(255),
    RowGuid CHAR(36) NOT NULL,
    DateCreated DATETIME NOT NULL,
    DateUpdated DATETIME NOT NULL
);

CREATE TABLE SalesOrderItem (
    Id INT AUTO_INCREMENT PRIMARY KEY,
    SalesOrderId INT NOT NULL,
    ProductId INT NOT NULL,
    UnitPrice FLOAT NOT NULL,
    Quantity FLOAT NOT NULL,
    Total FLOAT NOT NULL,
    RowGuid CHAR(36) NOT NULL,
    DateCreated DATETIME NOT NULL,
    DateUpdated DATETIME NOT NULL,
    FOREIGN KEY (SalesOrderId) REFERENCES SalesOrder(Id),
    FOREIGN KEY (ProductId) REFERENCES Product(Id)
);
