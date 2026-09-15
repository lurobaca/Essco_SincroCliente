SET XACT_ABORT ON;
BEGIN TRANSACTION;

IF OBJECT_ID(N'[dbo].[Web_AuditLog]', N'U') IS NULL
BEGIN
    CREATE TABLE [dbo].[Web_AuditLog]
    (
        [AuditId] bigint IDENTITY(1,1) NOT NULL,
        [EventId] uniqueidentifier NOT NULL,
        [OccurredAt] datetimeoffset(0) NOT NULL,
        [UserId] int NULL,
        [Username] nvarchar(256) NULL,
        [Company] nvarchar(128) NULL,
        [Operation] nvarchar(128) NOT NULL,
        [EntityType] nvarchar(128) NOT NULL,
        [EntityId] nvarchar(256) NULL,
        [Outcome] nvarchar(64) NOT NULL,
        [CorrelationId] nvarchar(128) NOT NULL,
        [IpAddress] nvarchar(64) NULL,
        CONSTRAINT [PK_Web_AuditLog] PRIMARY KEY CLUSTERED ([AuditId]),
        CONSTRAINT [UQ_Web_AuditLog_EventId] UNIQUE ([EventId])
    );

    CREATE INDEX [IX_Web_AuditLog_OccurredAt] ON [dbo].[Web_AuditLog] ([OccurredAt] DESC);
    CREATE INDEX [IX_Web_AuditLog_UserId_OccurredAt] ON [dbo].[Web_AuditLog] ([UserId], [OccurredAt] DESC);
    CREATE INDEX [IX_Web_AuditLog_Entity] ON [dbo].[Web_AuditLog] ([EntityType], [EntityId], [OccurredAt] DESC);
END;

COMMIT TRANSACTION;
