USE ecommerce;

CALL InsertProducts();

INSERT INTO SalesOrder (CodeNumber, OrderDate, OrderDescription, RowGuid, DateCreated, DateUpdated)
VALUES
('Order001', '2024-01-01 10:00:00', 'First order description', UUID(), NOW(), NOW()),
('Order002', '2024-01-02 11:00:00', 'Second order description', UUID(), NOW(), NOW()),
('Order003', '2024-01-03 12:00:00', 'Third order description', UUID(), NOW(), NOW());

INSERT INTO SalesOrderItem (SalesOrderId, ProductId, UnitPrice, Quantity, Total, RowGuid, DateCreated, DateUpdated)
VALUES
-- For Order 1
(1, 1, 100.00, 2, 200.00, UUID(), NOW(), NOW()),
(1, 2, 150.00, 1, 150.00, UUID(), NOW(), NOW()),
(1, 3, 50.00, 3, 150.00, UUID(), NOW(), NOW()),

-- For Order 2
(2, 1, 100.00, 1, 100.00, UUID(), NOW(), NOW()),
(2, 2, 150.00, 2, 300.00, UUID(), NOW(), NOW()),
(2, 3, 50.00, 4, 200.00, UUID(), NOW(), NOW()),

-- For Order 3
(3, 1, 100.00, 5, 500.00, UUID(), NOW(), NOW()),
(3, 2, 150.00, 3, 450.00, UUID(), NOW(), NOW()),
(3, 3, 50.00, 2, 100.00, UUID(), NOW(), NOW());
