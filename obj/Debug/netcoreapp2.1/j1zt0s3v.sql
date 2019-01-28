IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;

GO

CREATE TABLE [Orchestra] (
    [Id] int NOT NULL IDENTITY,
    [Name] varchar(50) NOT NULL,
    [AddressLine1] varchar(50) NOT NULL,
    [AddressLine2] varchar(50) NULL,
    [City] varchar(50) NOT NULL,
    [State] varchar(2) NOT NULL,
    [ZipCode] varchar(5) NOT NULL,
    [WebsiteURL] varchar(50) NULL,
    CONSTRAINT [PK_Orchestra] PRIMARY KEY ([Id])
);

GO

CREATE TABLE [Musician] (
    [Id] int NOT NULL IDENTITY,
    [FirstName] varchar(50) NOT NULL,
    [LastName] varchar(50) NOT NULL,
    [Section] varchar(50) NOT NULL,
    [SectionLeader] bit NOT NULL,
    [OrchestraId] int NOT NULL,
    CONSTRAINT [PK_Musician] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Orchestra] FOREIGN KEY ([OrchestraId]) REFERENCES [Orchestra] ([Id]) ON DELETE CASCADE
);

GO

CREATE TABLE [Instrument] (
    [Id] int NOT NULL IDENTITY,
    [SerialNumber] varchar(50) NULL,
    [Description] varchar(max) NOT NULL,
    [Maintenance_Date] date NULL,
    [Condition] varchar(50) NULL,
    [MusicianId] int NOT NULL,
    CONSTRAINT [PK_Instrument] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Musician] FOREIGN KEY ([MusicianId]) REFERENCES [Musician] ([Id]) ON DELETE CASCADE
);

GO

CREATE INDEX [IX_Instrument_MusicianId] ON [Instrument] ([MusicianId]);

GO

CREATE INDEX [IX_Musician_OrchestraId] ON [Musician] ([OrchestraId]);

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20181006205156_init', N'2.1.2-rtm-30932');

GO

