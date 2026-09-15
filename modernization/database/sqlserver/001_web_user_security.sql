SET XACT_ABORT ON;
BEGIN TRANSACTION;

IF OBJECT_ID(N'[dbo].[Web_UserSecurity]', N'U') IS NULL
BEGIN
    CREATE TABLE [dbo].[Web_UserSecurity]
    (
        [UserId] int NOT NULL,
        [CredentialHash] nvarchar(512) NULL,
        [CredentialFormat] tinyint NOT NULL CONSTRAINT [DF_Web_UserSecurity_CredentialFormat] DEFAULT (0),
        [MustChangePassword] bit NOT NULL CONSTRAINT [DF_Web_UserSecurity_MustChange] DEFAULT (1),
        [FailedAccessCount] int NOT NULL CONSTRAINT [DF_Web_UserSecurity_FailedAccess] DEFAULT (0),
        [LockedUntil] datetimeoffset(0) NULL,
        [UpdatedAt] datetime2(0) NOT NULL CONSTRAINT [DF_Web_UserSecurity_UpdatedAt] DEFAULT (SYSUTCDATETIME()),
        [Version] rowversion NOT NULL,
        CONSTRAINT [PK_Web_UserSecurity] PRIMARY KEY ([UserId]),
        CONSTRAINT [CK_Web_UserSecurity_FailedAccess] CHECK ([FailedAccessCount] >= 0),
        CONSTRAINT [CK_Web_UserSecurity_CredentialFormat] CHECK ([CredentialFormat] IN (0, 1)),
        CONSTRAINT [CK_Web_UserSecurity_HashRequired] CHECK ([CredentialFormat] = 0 OR [CredentialHash] IS NOT NULL)
    );
END;

COMMIT TRANSACTION;
