/*
--------------------------------------------------------------------
Name   : Gisella Chaffo
Description   : Data Insert
Version: 1.0
--------------------------------------------------------------------
*/

/*
--------------------------------------------------------------------
© 2017 sqlservertutorial.net All Rights Reserved
--------------------------------------------------------------------
Name   : BikeStores
Link   : http://www.sqlservertutorial.net/load-sample-database/
Version: 1.0
--------------------------------------------------------------------
*/

USE TRANZACT;



SET IDENTITY_INSERT products ON;
INSERT INTO products(product_id, product_name, brand_name, price) VALUES(1,'Trek 820 - 2016','Electra',379.99)
INSERT INTO products(product_id, product_name, brand_name, price) VALUES(2,'Ritchey Timberwolf Frameset - 2016','Electra',749.99)
INSERT INTO products(product_id, product_name, brand_name, price) VALUES(3,'Surly Wednesday Frameset - 2016','Electra',999.99)
INSERT INTO products(product_id, product_name, brand_name, price) VALUES(4,'Trek Fuel EX 8 29 - 2016','Electra',2899.99)

SET IDENTITY_INSERT products OFF;