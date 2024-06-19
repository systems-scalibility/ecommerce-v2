import mysql from "mysql2/promise";
import date from "date-and-time";

const connection = await mysql.createConnection({
    host: "localhost",
    user: "root",
    password: "password",
    database: "ecommerce"
});

const codeNumber = "Order003"; 
try {
    const [results, fields] = await connection.query(
        'SELECT * FROM SalesOrder WHERE CodeNumber = ?',
        [codeNumber]
    );
    console.log(results);
} catch (e) {
    console.error(e);
}

connection.end();
