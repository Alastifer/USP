use usp;

DROP TABLE IF EXISTS users;
DROP TABLE IF EXISTS education2employee;
DROP TABLE IF EXISTS employees;
DROP TABLE IF EXISTS passports;
DROP TABLE IF EXISTS marital_statuses;
DROP TABLE IF EXISTS genders;
DROP TABLE IF EXISTS citizenships;
DROP TABLE IF EXISTS addresses;
DROP TABLE IF EXISTS educations;
DROP TABLE IF EXISTS education_types;
DROP TABLE IF EXISTS qualifications;
DROP TABLE IF EXISTS specialties;
DROP TABLE IF EXISTS purposes;
DROP TABLE IF EXISTS subdivisions;
DROP TABLE IF EXISTS positions;
DROP TABLE IF EXISTS insurances;
DROP TABLE IF EXISTS insurance_types;

CREATE TABLE users (
	email VARCHAR(400),
	password VARCHAR(400) NOT NULL,
	PRIMARY KEY (email)
);

CREATE TABLE insurance_types (
	id INT AUTO_INCREMENT,
	name VARCHAR(400) NOT NULL,
	PRIMARY KEY (id)
);

CREATE TABLE insurances (
	id INT UNIQUE NOT NULL,
	id_insurance_type INT NOT NULL,
	PRIMARY KEY (id),
	FOREIGN KEY (id_insurance_type) REFERENCES insurance_types(id)
);

CREATE TABLE positions (
	id INT AUTO_INCREMENT,
	name VARCHAR(400) NOT NULL,
	PRIMARY KEY (id)
);

CREATE TABLE subdivisions (
	id INT AUTO_INCREMENT,
	name VARCHAR(400) NOT NULL,
	PRIMARY KEY (id)
);	

CREATE TABLE purposes (
	id INT AUTO_INCREMENT,
	id_position INT NOT NULL,
	id_subdivision INT NOT NULL,
	appointment_date DATE NOT NULL,
	bets FLOAT NOT NULL,
	salary FLOAT NOT NULL,
	order_number INT NOT NULL,
	PRIMARY KEY (id),
	FOREIGN KEY (id_position) REFERENCES positions(id),
	FOREIGN KEY (id_subdivision) REFERENCES subdivisions(id)
);

CREATE TABLE specialties (
	id INT AUTO_INCREMENT,
	name VARCHAR(400) NOT NULL,
	PRIMARY KEY (id)
);

CREATE TABLE qualifications (
	id INT AUTO_INCREMENT,
	name VARCHAR(400) NOT NULL,
	PRIMARY KEY (id)
);

CREATE TABLE education_types (
	id INT AUTO_INCREMENT,
	name VARCHAR(400) NOT NULL,
	PRIMARY KEY (id)
);

CREATE TABLE educations (
	id INT AUTO_INCREMENT,
	name VARCHAR(400) NOT NULL,
	id_specialty INT NOT NULL,
	id_qualification INT NOT NULL,
	id_education_type INT NOT NULL,
	begin_year INT NOT NULL,
	end_year INT,
	PRIMARY KEY (id),
	FOREIGN KEY (id_specialty) REFERENCES specialties(id),
	FOREIGN KEY (id_qualification) REFERENCES qualifications(id),
	FOREIGN KEY (id_education_type) REFERENCES education_types(id)
);

CREATE TABLE addresses (
	id INT AUTO_INCREMENT,
	country VARCHAR(400) NOT NULL,
	region VARCHAR(400) NOT NULL,
	district VARCHAR(400) NOT NULL,
	city VARCHAR(400) NOT NULL,
	address_index INT NOT NULL,
	street VARCHAR(400) NOT NULL,
	house INT NOT NULL,
	flat INT NOT NULL,
	corps INT,
	home_phone VARCHAR(400),
	mobile_phone VARCHAR(400),
	PRIMARY KEY (id)
);

CREATE TABLE citizenships (
	id INT AUTO_INCREMENT,
	name VARCHAR(400) NOT NULL,
	PRIMARY KEY (id)
);

CREATE TABLE genders (
	id INT AUTO_INCREMENT,
	name VARCHAR(400) NOT NULL,
	PRIMARY KEY (id)
);

CREATE TABLE marital_statuses (
	id INT AUTO_INCREMENT,
	name VARCHAR(400) NOT NULL,
	PRIMARY KEY (id)
);

CREATE TABLE passports (
	passport_number VARCHAR(400) UNIQUE NOT NULL,
	first_name VARCHAR(400) NOT NULL,
	last_name VARCHAR(400) NOT NULL,
	middle_name VARCHAR(400) NOT NULL,
	birth_date DATE NOT NULL,
	issuing_authority VARCHAR(1400) NOT NULL,
	ident_number VARCHAR(400) UNIQUE NOT NULL,
	id_citizenship INT NOT NULL,
	id_gender INT NOT NULL,
	id_marital_status INT NOT NULL,
	id_birth_place INT NOT NULL,
	PRIMARY KEY (passport_number),
	FOREIGN KEY (id_citizenship) REFERENCES citizenships(id),
	FOREIGN KEY (id_gender) REFERENCES genders(id),
	FOREIGN KEY (id_marital_status) REFERENCES marital_statuses(id),
	FOREIGN KEY (id_birth_place) REFERENCES addresses(id)
);
	
CREATE TABLE employees (
	id INT AUTO_INCREMENT,
	trade_union BIT(1) NOT NULL,
	passport_number VARCHAR(400) NOT NULL,
	id_registration INT NOT NULL,
	id_residence INT NOT NULL,
	id_insurance INT NOT NULL,
	id_purpose INT NOT NULL,
	PRIMARY KEY (id),
	FOREIGN KEY (passport_number) REFERENCES passports(passport_number),
	FOREIGN KEY (id_registration) REFERENCES addresses(id),
	FOREIGN KEY (id_residence) REFERENCES addresses(id),
	FOREIGN KEY (id_insurance) REFERENCES insurances(id),
	FOREIGN KEY (id_purpose) REFERENCES purposes(id)
);

CREATE TABLE education2employee (
	id_education INT NOT NULL,
	id_employee INT NOT NULL,
	FOREIGN KEY (id_education) REFERENCES educations(id),
	FOREIGN KEY (id_employee) REFERENCES employees(id)
);

INSERT INTO users VALUES ("admin@ad.me", "adminADMIN");
INSERT INTO users VALUES ("user@usr.me", "justUsr");

INSERT INTO insurance_types VALUES (1, "Стандарт");
INSERT INTO insurance_types VALUES (2, "Про");

INSERT INTO insurances VALUES (1, 1);
INSERT INTO insurances VALUES (2, 2);

INSERT INTO specialties VALUES (1, "Программное обеспечение информационных технологий");
INSERT INTO specialties VALUES (2, "Аривы и делопроизводство");

INSERT INTO qualifications VALUES (1, "техник-программист");
INSERT INTO qualifications VALUES (2, "архивист");
INSERT INTO qualifications VALUES (3, "высший архивист");

INSERT INTO education_types VALUES (1, "среднее общее");
INSERT INTO education_types VALUES (2, "среднее профессиональное");
INSERT INTO education_types VALUES (3, "высшее образование(бакалавриат)");
INSERT INTO education_types VALUES (4, "высшее образование(аспирантура)");
INSERT INTO education_types VALUES (5, "высшее образование(магистратура)");
INSERT INTO education_types VALUES (6, "высшее образование(докторантура)");

INSERT INTO educations VALUES (1, "Белорусский государственный университет", 2, 2, 3, "2001", "2006");
INSERT INTO educations VALUES (2, "Белорусский государственный университет", 2, 3, 4, "2006", "2008");
INSERT INTO educations VALUES (3, "Белорусский государственный радиотехнический университет", 1, 1, 3, "2010", "2015");

INSERT INTO subdivisions VALUES (1, "ОНТОД");
INSERT INTO subdivisions VALUES (2, "ИКТ");

INSERT INTO positions VALUES (1, "главный архивист");
INSERT INTO positions VALUES (2, "инженер-программист");

INSERT INTO purposes VALUES (1, 1, 1, "2016-02-01", 1, 512.56, 2344);
INSERT INTO purposes VALUES (2, 2, 2, "2015-11-30", 1.5, 450.50, 1694);

INSERT INTO addresses VALUES (1, "Беларусь", "Минская", "Минский", "Минск", 220059, "Победителей", 63, 127, NULL, "80172132658", "375251624290");
INSERT INTO addresses VALUES (2, "Беларусь", "Минская", "Минский", "Минск", 225096, "Кабушкина", 19, 54, NULL, "8017614925", "3752636369");

INSERT INTO genders VALUES (1, "Ж");
INSERT INTO genders VALUES (2, "М");

INSERT INTO marital_statuses VALUES (1, "замужем"); 
INSERT INTO marital_statuses VALUES (2, "не замужем");
INSERT INTO marital_statuses VALUES (3, "женат"); 
INSERT INTO marital_statuses VALUES (4, "холост"); 
INSERT INTO marital_statuses VALUES (5, "разведен"); 
INSERT INTO marital_statuses VALUES (6, "разведена"); 
INSERT INTO marital_statuses VALUES (7, "в гражданском браке"); 

INSERT INTO citizenships VALUES (1, "белорус");
INSERT INTO citizenships VALUES (2, "белоруска");
INSERT INTO citizenships VALUES (3, "русский");
INSERT INTO citizenships VALUES (4, "русская");

INSERT INTO passports VALUES ("5678IV834KI0000K", "Семён", "Пеньков", "Семенович", "1968-12-22", "РУВД Советского района", "MP1345560", 1, 2, 3, 1);
INSERT INTO passports VALUES ("3477IV456KI0000K", "Зинаида", "Кушнова", "Филипповна", "1987-04-26", "РУВД Московского района", "MP7654321", 2, 1, 6, 2);

INSERT INTO employees VALUES (1, 1, "5678IV834KI0000K", 1, 1, 1, 1);
INSERT INTO employees VALUES (2, 1, "3477IV456KI0000K", 2, 2, 2, 2);

INSERT INTO education2employee VALUES (1, 1);
INSERT INTO education2employee VALUES (2, 1);
INSERT INTO education2employee VALUES (3, 2);