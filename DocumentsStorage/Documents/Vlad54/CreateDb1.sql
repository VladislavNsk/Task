CREATE DATABASE transport_locations;
GO

USE transport_locations;

CREATE TABLE cars_types(
	id INTEGER NOT NULL IDENTITY(1,1),
	car_type VARCHAR(50) NOT NULL,
	PRIMARY KEY (Id)
);

CREATE TABLE coordinates(
	license_plate_number VARCHAR(10) NOT NULL,
	lat VARCHAR(30) NOT NULL,
	lng VARCHAR(30) NOT NULL,
	cars_types_id INTEGER NOT NULL,
	PRIMARY KEY (license_plate_number),
	FOREIGN KEY (cars_types_id) REFERENCES cars_types (id)
);

INSERT INTO cars_types(car_type)
VALUES ('Трактор'),
('Самосвал'),
('Экскаватор');

DECLARE @lat VARCHAR(10);
DECLARE @lng VARCHAR(10);
DECLARE @license_plate_number VARCHAR(10);

DECLARE @numbers VARCHAR(10) = '0123456789';
DECLARE @letters VARCHAR(12) = 'АВЕКМНОРСТУХ';
DECLARE @counter SMALLINT = 1; 

WHILE @counter < 10  
	BEGIN  
		
		SET @lng = FORMAT(rand() * 90, 'N7');
		SET @lat = FORMAT(rand() * 90, 'N7');
		SET  @license_plate_number = 
		substring(@letters, cast(ABS(CHECKSUM(NewId())) % 12 + 1 AS INT), 1) +
		substring(@numbers, cast(ABS(CHECKSUM(NewId())) % 10 + 1 AS INT), 1) +
		substring(@numbers, cast(ABS(CHECKSUM(NewId())) % 10 + 1 AS INT), 1) +
		substring(@numbers, cast(ABS(CHECKSUM(NewId())) % 10 + 1 AS INT), 1) +
		substring(@letters, cast(ABS(CHECKSUM(NewId())) % 12 + 1 AS INT), 1) +
		substring(@letters, cast(ABS(CHECKSUM(NewId())) % 12 + 1 AS INT), 1) +
		cast(54 AS VARCHAR);

		INSERT INTO coordinates(license_plate_number, lat, lng, cars_types_id)
		VALUES (@license_plate_number, @lat, @lng, cast(ABS(CHECKSUM(NewId())) % 3 + 1 AS INT));

		SET @counter = @counter + 1;

	END;