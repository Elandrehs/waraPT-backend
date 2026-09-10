CREATE DATABASE IF NOT EXISTS wara_workers CHARACTER SET utf8mb4;
USE wara_workers;

CREATE TABLE Users (
  UserId INT AUTO_INCREMENT PRIMARY KEY,
  Username VARCHAR(50) NOT NULL UNIQUE,
  Password VARCHAR(255) NOT NULL
);

CREATE TABLE Workers (
  WorkerId INT AUTO_INCREMENT PRIMARY KEY,
  FirstName VARCHAR(100) NOT NULL,
  LastName VARCHAR(100) NOT NULL,
  Dni VARCHAR(20) NOT NULL UNIQUE,
  Age INT NOT NULL,
  UserId INT NULL,
  FOREIGN KEY (UserId) REFERENCES Users(UserId)
);

INSERT INTO Users (Username, Password) VALUES ('admin', 'admin123');

DELIMITER $$

CREATE PROCEDURE sp_Login(IN p_Username VARCHAR(50), IN p_Password VARCHAR(255))
BEGIN
  SELECT UserId, Username
  FROM Users
  WHERE Username = p_Username AND Password = p_Password;
END $$

CREATE PROCEDURE sp_ListWorkers(IN p_Dni VARCHAR(20))
BEGIN
  SELECT WorkerId, FirstName, LastName, Dni, Age
  FROM Workers
  WHERE p_Dni IS NULL OR p_Dni = '' OR Dni LIKE CONCAT('%', p_Dni, '%');
END $$

CREATE PROCEDURE sp_AddWorker(
  IN p_FirstName VARCHAR(100),
  IN p_LastName VARCHAR(100),
  IN p_Dni VARCHAR(20),
  IN p_Age INT
)
BEGIN
  INSERT INTO Workers (FirstName, LastName, Dni, Age)
  VALUES (p_FirstName, p_LastName, p_Dni, p_Age);
  SELECT LAST_INSERT_ID() AS CreatedId;
END $$

DELIMITER ;