DELIMITER //

CREATE PROCEDURE PopulateTables()
BEGIN
    DECLARE i INT DEFAULT 1;
    DECLARE j INT DEFAULT 1;
    DECLARE k INT DEFAULT 1;
    DECLARE prod_id INT;
    DECLARE order_id INT;

    -- Temporary tables to store inserted IDs
    CREATE TEMPORARY TABLE TempProducts (Id INT);
    CREATE TEMPORARY TABLE TempSalesOrders (Id INT);

    -- Populate Product table
    WHILE i <= 1000 DO
        INSERT INTO Product (ProductName, CodeNumber, ProductDescription, UnitPrice, RowGuid, DateCreated, DateUpdated)
        VALUES (CONCAT('Product ', i),
                CONCAT('P', LPAD(i, 4, '0')),
                CONCAT('Description for product ', i),
                ROUND(RAND() * 100, 2),
                UUID(),
                NOW(),
                NOW());
        SET prod_id = LAST_INSERT_ID();
        INSERT INTO TempProducts (Id) VALUES (prod_id);
        SET i = i + 1;
    END WHILE;

    -- Populate SalesOrder table
    WHILE j <= 10000 DO
        INSERT INTO SalesOrder (CodeNumber, OrderDate, OrderDescription, RowGuid, DateCreated, DateUpdated)
        VALUES (CONCAT('SO', LPAD(j, 5, '0')),
                NOW() - INTERVAL FLOOR(RAND() * 365) DAY,
                CONCAT('Description for order ', j),
                UUID(),
                NOW(),
                NOW());
        SET order_id = LAST_INSERT_ID();
        INSERT INTO TempSalesOrders (Id) VALUES (order_id);
        SET j = j + 1;
    END WHILE;

    -- Populate SalesOrderItem table
    WHILE k <= 50000 DO
        INSERT INTO SalesOrderItem (SalesOrderId, ProductId, UnitPrice, Quantity, Total, RowGuid, DateCreated, DateUpdated)
        VALUES (
            (SELECT Id FROM TempSalesOrders ORDER BY RAND() LIMIT 1),
            (SELECT Id FROM TempProducts ORDER BY RAND() LIMIT 1),
            ROUND(RAND() * 100, 2),
            ROUND(RAND() * 10 + 1, 2),
            ROUND((RAND() * 100) * (ROUND(RAND() * 10 + 1, 2)), 2),
            UUID(),
            NOW(),
            NOW());
        SET k = k + 1;
    END WHILE;

    DROP TEMPORARY TABLE TempProducts;
    DROP TEMPORARY TABLE TempSalesOrders;
END //

DELIMITER ;
