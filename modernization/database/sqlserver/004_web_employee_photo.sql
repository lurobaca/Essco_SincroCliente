SET XACT_ABORT ON;
BEGIN TRANSACTION;

IF OBJECT_ID(N'[dbo].[Web_EmployeePhoto]', N'U') IS NULL
BEGIN
    CREATE TABLE [dbo].[Web_EmployeePhoto]
    (
        [EmployeeIdentification] nvarchar(100) NOT NULL,
        [Content] varbinary(max) NOT NULL,
        [UpdatedAtUtc] datetime2(0) NOT NULL CONSTRAINT [DF_Web_EmployeePhoto_UpdatedAtUtc] DEFAULT SYSUTCDATETIME(),
        CONSTRAINT [PK_Web_EmployeePhoto] PRIMARY KEY CLUSTERED ([EmployeeIdentification])
    );
END;

COMMIT TRANSACTION;
