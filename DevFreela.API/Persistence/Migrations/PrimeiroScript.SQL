IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;
GO

BEGIN TRANSACTION;
GO

CREATE TABLE [Skills] (
    [Id] int NOT NULL IDENTITY,
    [Description] nvarchar(max) NULL,
    [CreatedAt] datetime2 NOT NULL,
    CONSTRAINT [PK_Skills] PRIMARY KEY ([Id])
);
GO

CREATE TABLE [Users] (
    [Id] int NOT NULL IDENTITY,
    [FullName] nvarchar(max) NULL,
    [Email] nvarchar(max) NULL,
    [BirthDate] datetime2 NOT NULL,
    [CreatedAt] datetime2 NOT NULL,
    [Active] bit NOT NULL,
    [Role] nvarchar(max) NULL,
    [Password] nvarchar(max) NULL,
    CONSTRAINT [PK_Users] PRIMARY KEY ([Id])
);
GO

CREATE TABLE [Projects] (
    [Id] int NOT NULL IDENTITY,
    [Title] nvarchar(max) NULL,
    [Description] nvarchar(max) NULL,
    [IdClient] int NOT NULL,
    [IdFreelancer] int NOT NULL,
    [TotalCost] decimal(18,2) NOT NULL,
    [CreatedAt] datetime2 NOT NULL,
    [StartedAt] datetime2 NULL,
    [FinishedAt] datetime2 NULL,
    [Status] int NOT NULL,
    CONSTRAINT [PK_Projects] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Projects_Users_IdClient] FOREIGN KEY ([IdClient]) REFERENCES [Users] ([Id]) ON DELETE NO ACTION,
    CONSTRAINT [FK_Projects_Users_IdFreelancer] FOREIGN KEY ([IdFreelancer]) REFERENCES [Users] ([Id]) ON DELETE NO ACTION
);
GO

CREATE TABLE [UserSkills] (
    [Id] int NOT NULL IDENTITY,
    [IdUser] int NOT NULL,
    [IdSkill] int NOT NULL,
    [SkillId] int NULL,
    CONSTRAINT [PK_UserSkills] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_UserSkills_Skills_SkillId] FOREIGN KEY ([SkillId]) REFERENCES [Skills] ([Id]) ON DELETE NO ACTION,
    CONSTRAINT [FK_UserSkills_Users_IdSkill] FOREIGN KEY ([IdSkill]) REFERENCES [Users] ([Id]) ON DELETE NO ACTION
);
GO

CREATE TABLE [ProjectComments] (
    [Id] int NOT NULL IDENTITY,
    [Content] nvarchar(max) NULL,
    [IdProject] int NOT NULL,
    [IdUser] int NOT NULL,
    [CreatedAt] datetime2 NOT NULL,
    CONSTRAINT [PK_ProjectComments] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_ProjectComments_Projects_IdProject] FOREIGN KEY ([IdProject]) REFERENCES [Projects] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_ProjectComments_Users_IdUser] FOREIGN KEY ([IdUser]) REFERENCES [Users] ([Id]) ON DELETE CASCADE
);
GO

CREATE INDEX [IX_ProjectComments_IdProject] ON [ProjectComments] ([IdProject]);
GO

CREATE INDEX [IX_ProjectComments_IdUser] ON [ProjectComments] ([IdUser]);
GO

CREATE INDEX [IX_Projects_IdClient] ON [Projects] ([IdClient]);
GO

CREATE INDEX [IX_Projects_IdFreelancer] ON [Projects] ([IdFreelancer]);
GO

CREATE INDEX [IX_UserSkills_IdSkill] ON [UserSkills] ([IdSkill]);
GO

CREATE INDEX [IX_UserSkills_SkillId] ON [UserSkills] ([SkillId]);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20220921234043_InitialMigration', N'5.0.0');
GO

COMMIT;
GO

