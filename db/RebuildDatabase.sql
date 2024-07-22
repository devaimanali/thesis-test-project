USE master
GO

IF NOT EXISTS (SELECT * FROM sys.databases WHERE name = 'ThesisExercise')
BEGIN
  CREATE DATABASE ThesisExercise;
END
GO

USE ThesisExercise
GO

-- Create the Tables
CREATE TABLE Computers (
    ComputerID INT PRIMARY KEY IDENTITY(1,1),
    RAM VARCHAR(20),
    DiskSpace VARCHAR(20),
    Processor VARCHAR(100),
    Ports VARCHAR(100)
);

-- Insert Data into Computers Table
INSERT INTO Computers (RAM, DiskSpace, Processor, Ports)
VALUES
('8 GB', '1 TB SSD', 'Intel® Celeron™ N3050 Processor', '2 x USB 3.0, 4 x USB 2.0'),
('16 GB', '2 TB HDD', 'AMD FX 4300 Processor', '3 x USB 3.0, 4 x USB 2.0'),
('8 GB', '3 TB HDD', 'AMD Athlon Quad-Core APU Athlon 5150', '4 x USB 3.0, 4 x USB 2.0'),
('16 GB', '4 TB HDD', 'AMD FX 8-Core Black Edition FX-8350', '5 x USB 2.0, 4 x USB 3.0'),
('32 GB', '750 GB SDD', 'AMD FX 8-Core Black Edition FX-8370', '2 x USB 3.0, 2 x USB 2.0, 1 x USB C'),
('32 GB', '2 TB SDD', 'Intel Core i7-6700K 4GHz Processor', '2 x USB C, 4 x USB 3.0'),
('8 GB', '2 TB HDD', 'Intel® Core™ i5-6400 Processor', '8 x USB 3.0'),
('16 GB', '500 GB SDD', 'Intel® Core™ i5-6400 Processor', '4 x USB 2.0'),
('2 GB', '2 TB HDD', 'Intel Core i7 Extreme Edition 3 GHz Processor', '10 x USB 3.0, 10 x USB 2.0, 10 x USB C'),
('512 MB', '80 GB SSD', 'Intel® Core™ i5-6400 Processor', '19 x USB 3.0, 4 x USB 2.0');


