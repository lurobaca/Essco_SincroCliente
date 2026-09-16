SET XACT_ABORT ON;
BEGIN TRANSACTION;
IF OBJECT_ID(N'dbo.WebSapJobs',N'U') IS NULL
BEGIN
 CREATE TABLE dbo.WebSapJobs
 (
  JobId uniqueidentifier NOT NULL CONSTRAINT PK_WebSapJobs PRIMARY KEY,
  IdempotencyKey nvarchar(200) NOT NULL,
  OperationType nvarchar(100) NOT NULL,
  Company nvarchar(100) NOT NULL,
  RequestedBy nvarchar(256) NOT NULL,
  Payload nvarchar(max) NOT NULL,
  Status varchar(32) NOT NULL,
  Attempts int NOT NULL CONSTRAINT DF_WebSapJobs_Attempts DEFAULT(0),
  CreatedAt datetimeoffset(7) NOT NULL CONSTRAINT DF_WebSapJobs_CreatedAt DEFAULT(SYSUTCDATETIME()),
  ProcessedAt datetimeoffset(7) NULL,
  NextAttemptAt datetimeoffset(7) NOT NULL CONSTRAINT DF_WebSapJobs_NextAttemptAt DEFAULT(SYSUTCDATETIME()),
  LockedAt datetimeoffset(7) NULL,
  ExternalId nvarchar(200) NULL,
  SanitizedError nvarchar(1000) NULL,
  CONSTRAINT UQ_WebSapJobs_IdempotencyKey UNIQUE(IdempotencyKey),
  CONSTRAINT CK_WebSapJobs_Status CHECK(Status IN('Pending','Processing','Completed','RetryableFailure','PermanentFailure','Cancelled'))
 );
 CREATE INDEX IX_WebSapJobs_Claim ON dbo.WebSapJobs(Status,NextAttemptAt,CreatedAt) INCLUDE(LockedAt);
END;
COMMIT TRANSACTION;
