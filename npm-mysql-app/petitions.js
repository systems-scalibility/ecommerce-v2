import axios from 'axios';

const connection = "http://localhost:5157/"

const request = axios.create({
    baseURL: connection
})

const getAllByCodeNumber = async (codeNumber) => {
    const {data} = await request.get(`api/SalesOrderItem/product/${codeNumber}`)
    console.log(data)
}

const getAllByDate = async (startDate, endDate) => {
    const {data} = await request
        .get(`api/SalesOrderItem/range-dates?startDate=${startDate}&endDate=${endDate}`)
    console.log(data)
}

const getAllByQuantity = async (quantity, condition) => {
    const {data} = await request.get(`api/SalesOrderItem/quantity/${quantity}?condition=${condition}`)
    console.log(data)
}

await getAllByCodeNumber('P0002')
await getAllByDate('2024-06-19 12:31:05', '2024-06-19 12:31:06')
await getAllByQuantity(10, '=')
