#!/bin/sh
cd
docker exec -it mysql-master bash
apt update
echo "
[mysqld]
skip-name-resolve
default_authentication_plugin = mysql_native_password
log-bin=mysql-bin
server-id=1
binlog_format = ROW
" >> /etc/mysql/my.cnf
docker exec -it mysql-slave bash
apt-update
echo "
[mysqld]
skip-name-resolve
default_authentication_plugin = mysql_native_password
server-id=2
log-bin=mysql-replica-bin
relay-log=relay-log
" >> /etc/mysql/my.cnf
docker compose restart
docker exec -it mysql-master mysql -u root -p
CREATE USER 'repl'@'%' IDENTIFIED BY 'pw';
GRANT REPLICATION SLAVE ON *.* TO 'repl'@'%';
FLUSH PRIVILEGES;
SHOW MASTER STATUS;
docker exec -it mysql-slave mysql -u root -p
CHANGE MASTER TO MASTER_HOST='mysql-master', MASTER_USER='repl', MASTER_PASSWORD='pw', MASTER_LOG_FILE='mysql-bin.000001', MASTER_LOG_POS=826;
START SLAVE;
SHOW SLAVE STATUS\G

# MySQL Commands

mysql -h localhost -u root -p
use ecommerce;
show tables;
SELECT COUNT(*) FROM Product;
SELECT COUNT(*) FROM SalesOrder;
SELECT COUNT(*) FROM SalesOrderItem;
