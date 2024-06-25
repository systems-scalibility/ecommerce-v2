import axios from 'axios';
import prettyMilliseconds from 'pretty-ms';

const connection = "http://localhost:8085/"

const request = axios.create({
    baseURL: connection
})

const getAllByCodeNumber = async (codeNumber) => {
    await request.get(`api/SalesOrderItems?$filter=Product/CodeNumber eq '${codeNumber}'`)
}

const getAllByDate = async (startDate, endDate) => {
    await request
        .get(`api/SalesOrderItems?$filter=DateCreated ge ${startDate} and DateCreated le ${endDate}`)
}

const getAllByQuantity = async (quantity, condition) => {
    await request.get(`api/SalesOrderItems?$filter=Quantity eq ${quantity}`)
}

const calculateTime = (start, end) => {
    let time = end - start;
    let timeStr = prettyMilliseconds(time, {separateMilliseconds: true});
    console.log(`Executed in ${timeStr}`);
}


console.log('Starting petitions for code numbers...')
let start = new Date().getTime()
for (let i = 0; i < 1000; i++) {
    await getAllByCodeNumber(`P000${i + 1}`)
}
let end = new Date().getTime()
calculateTime(start, end)

console.log('Starting petitions for dates...')
start = new Date().getTime()
for (let i = 0; i < 1000; i++) {
    await getAllByDate('2024-06-25T11:51:45Z', '2024-06-25T11:58:45Z')
}
end = new Date().getTime()
calculateTime(start, end)

console.log('Starting petitions for quantities...')
start = new Date().getTime()
for (let i = 0; i < 1000; i++) {
    await getAllByQuantity(Math.floor(Math.random() * 10) + 1, '=')
}
end = new Date().getTime()
calculateTime(start, end)
