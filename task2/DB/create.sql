IF EXISTS (SELECT * FROM sys.databases WHERE name = 'PolandDB')
BEGIN
    DROP DATABASE PolandDB;
END
GO

CREATE DATABASE PolandDB;
GO

USE PolandDB;
GO

DROP TABLE IF EXISTS employments;
DROP TABLE IF EXISTS marriages;
DROP TABLE IF EXISTS enterprises;
DROP TABLE IF EXISTS persons;
GO

CREATE TABLE persons
(
    id			INT IDENTITY(1,1) PRIMARY KEY,
    first_name	VARCHAR(50) NOT NULL,
    last_name	VARCHAR(50) NOT NULL,
    birth_date	DATE NOT NULL,
    gender		CHAR(1) NOT NULL CHECK (gender IN ('M','F')),
    salary		DECIMAL(12,2) NULL,
    mother_id	INT NULL,
    father_id	INT NULL,

    CONSTRAINT fk_mother FOREIGN KEY (mother_id) REFERENCES persons(id),
    CONSTRAINT fk_father FOREIGN KEY (father_id) REFERENCES persons(id)
);
GO

CREATE TABLE enterprises
(
    id			 INT IDENTITY(1,1) PRIMARY KEY,
    name		 VARCHAR(255) NOT NULL,
    president_id INT NOT NULL

    CONSTRAINT fk_president REFERENCES persons(id)
);
GO

CREATE TABLE employments
(
    id			  INT IDENTITY(1,1) PRIMARY KEY,
    person_id	  INT NOT NULL
	CONSTRAINT fk_emp_person REFERENCES persons(id),
    enterprise_id INT NOT NULL
	CONSTRAINT fk_emp_enterprises REFERENCES enterprises(id),
    contract_type VARCHAR(20) NOT NULL
	CONSTRAINT ck_contract_type CHECK (contract_type IN ('umowa_o_prace','umowa_zlecenie'))
);
GO

CREATE TABLE marriages
(
    id			  INT IDENTITY(1,1) PRIMARY KEY,
    husband_id	  INT NOT NULL UNIQUE
	CONSTRAINT fk_husband REFERENCES persons(id),
    wife_id		  INT NOT NULL UNIQUE
	CONSTRAINT fk_wife REFERENCES persons(id)
);
GO