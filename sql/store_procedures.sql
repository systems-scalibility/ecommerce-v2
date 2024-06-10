USE ecommerce;

DELIMITER //

CREATE PROCEDURE InsertProducts()
BEGIN
    DECLARE counter INT DEFAULT 1;

    WHILE counter <= 1000 DO
        INSERT INTO Product (
            ProductName, 
            CodeNumber, 
            ProductDescription, 
            UnitPrice, 
            RowGuid, 
            DateCreated, 
            DateUpdated
        ) VALUES (
            CONCAT('Product ', counter), 
            CONCAT('Code', LPAD(counter, 4, '0')), 
            CONCAT('Description for product ', counter), 
            ROUND((RAND() * (1000 - 10) + 10), 2), 
            UUID(), 
            NOW(), 
            NOW()
        );
        
        SET counter = counter + 1;
    END WHILE;
END //

DELIMITER ;
