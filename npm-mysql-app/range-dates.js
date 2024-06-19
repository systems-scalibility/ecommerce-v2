import mysql from "mysql2/promise.js"
import date from "date-and-time"

const connection = await mysql.createConnection({
    host: "localhost",
    user: "root",
    password: "password",
    database: "ecommerce"
})


let startDate = new Date("2024-06-19 12:31:05")
let endDate = new Date("2024-06-19 12:31:06")
startDate = date.format(startDate, 'YYYY-MM-DD HH:mm:ss')
endDate = date.format(endDate, 'YYYY-MM-DD HH:mm:ss')
console.log(startDate)
console.log(endDate)

try {
    const [results, fields] = await
        connection.query('SELECT * FROM SalesOrderItem  WHERE DateCreated BETWEEN ? AND ?',
            [startDate, endDate])
    console.log(results)
} catch (e) {
    console.error(e)
}

connection.end()