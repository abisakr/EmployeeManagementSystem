USE [EmployeeManagementDb]
GO
CREATE PROCEDURE spUserLogin
    @Email NVARCHAR(110)
AS
BEGIN
  SELECT  UserId,UserName,Email,PasswordHash,Role,CreatedAt FROM UsersDb 
  WHERE Email=@Email
END

CREATE PROCEDURE spUserRegisteration
  @UserName NVARCHAR(110),
  @Email NVARCHAR(110),
  @PasswordHash NVARCHAR(255)
AS
BEGIN
  IF NOT EXISTS (
    SELECT 1 FROM UsersDb WHERE UserName = @UserName OR Email = @Email
  )
BEGIN
  INSERT INTO UsersDb(UserName, Email, PasswordHash)
  VALUES(@UserName, @Email, @PasswordHash)
END
END

CREATE PROCEDURE spGetEmployeeById
   @Id INT
AS
BEGIN
    SELECT  EmployeeId,EmployeeName, Email, Address, Department, Position, Salary, CreatedAt FROM EmployeeDb
    WHERE EmployeeId = @Id
END

CREATE PROCEDURE spAddEmployee
    @EmployeeName NVARCHAR(110),
    @Email NVARCHAR(110),
    @Address NVARCHAR(255),
	@Department NVARCHAR(110),
	@Position NVARCHAR(110),
	@Salary  DECIMAL(18,2)
AS
BEGIN
    INSERT INTO  EmployeeDb(EmployeeName, Email, Address,Department,Position,Salary )
    VALUES (@EmployeeName, @Email, @Address,@Department,@Position,@Salary)
END

CREATE PROCEDURE spGetAllEmployee
AS
BEGIN
  SELECT EmployeeId, EmployeeName, Email, Address, Department, Position, Salary, CreatedAt FROM EmployeeDb
END

CREATE PROCEDURE spDeleteEmployee
@Id INT
AS 
BEGIN
  DELETE FROM EmployeeDb WHERE EmployeeId=@Id
END


CREATE PROCEDURE spEditEmployee
    @EmployeeId INT,
    @EmployeeName NVARCHAR(110),
    @Email NVARCHAR(110),
    @Address NVARCHAR(255),
    @Department NVARCHAR(110),
    @Position NVARCHAR(110),
    @Salary DECIMAL(18,2)
AS
BEGIN
  UPDATE EmployeeDb
SET
        EmployeeName = @EmployeeName,
        Email = @Email,
        Address = @Address,
        Department = @Department,
        Position = @Position,
        Salary = @Salary
  WHERE EmployeeId = @EmployeeId
END
