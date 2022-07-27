/*
--------------------------------------------------------------------
Name   : Gisella Chaffo
Description: Create Objects
Version: 1.0
--------------------------------------------------------------------
*/
CREATE DATABASE TRANZACT
USE TRANZACT

CREATE TABLE products (
	product_id INT IDENTITY (1, 1) PRIMARY KEY,
	product_name VARCHAR (255) NOT NULL,
	brand_name VARCHAR (255) NOT NULL,
	price DECIMAL (10, 2) NOT NULL
);
