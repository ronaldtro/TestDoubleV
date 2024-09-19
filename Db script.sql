CREATE DATABASE tasksSystemDb
USE tasksSystemDb

CREATE TABLE [user](
	userId varchar(100) NOT NULL PRIMARY KEY, 
	username varchar(10),
	email varchar(50),
	[password] varchar(200),
	names varchar(50),
	lastNames varchar(50),
	dateOfBirth DATETIME2,
	createdAt DATETIME2 DEFAULT SYSDATETIME()
);

CREATE TABLE [role](
	roleId varchar(100) NOT NULL PRIMARY KEY,
	[name] varchar(20),
	createdAt DATETIME2 DEFAULT SYSDATETIME()
);

CREATE TABLE user_role(
	userRoleId varchar(100) NOT NULL PRIMARY KEY,
	userId varchar(100) NOT NULL,
	roleId varchar(100) NOT NULL,
	createdAt DATETIME2 DEFAULT SYSDATETIME(),
	FOREIGN KEY (userId) REFERENCES [user](userId),
	FOREIGN KEY (roleId) REFERENCES [role](roleId)
);

CREATE TABLE task_state(
	taskStateId varchar(100) NOT NULL PRIMARY KEY,
	[name] varchar(20),
	createdAt DATETIME2 DEFAULT SYSDATETIME()
);

CREATE TABLE task(
	taskId varchar(100) NOT NULL PRIMARY KEY,
	[name] varchar(50),
	[description] varchar(500),
	taskStateId varchar(100) NOT NULL,
	createdAt DATETIME2 DEFAULT SYSDATETIME(),
	FOREIGN KEY (taskStateId) REFERENCES task_state(taskStateId)
);

CREATE TABLE user_task(
	userTaskId varchar(100) NOT NULL PRIMARY KEY,
	userId varchar(100) NOT NULL,
	taskId varchar(100) NOT NULL,
	createdAt DATETIME2 DEFAULT SYSDATETIME(),
	FOREIGN KEY (userId) REFERENCES [user](userId),
	FOREIGN KEY (taskId) REFERENCES task(taskId)
);