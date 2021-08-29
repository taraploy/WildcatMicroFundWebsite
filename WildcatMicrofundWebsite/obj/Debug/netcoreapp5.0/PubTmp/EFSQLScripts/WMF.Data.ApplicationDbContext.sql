IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210722211127_InitialCreateWMF207222021')
BEGIN
    CREATE TABLE [AspNetRoles] (
        [Id] nvarchar(450) NOT NULL,
        [Name] nvarchar(256) NULL,
        [NormalizedName] nvarchar(256) NULL,
        [ConcurrencyStamp] nvarchar(max) NULL,
        CONSTRAINT [PK_AspNetRoles] PRIMARY KEY ([Id])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210722211127_InitialCreateWMF207222021')
BEGIN
    CREATE TABLE [AspNetUsers] (
        [Id] nvarchar(450) NOT NULL,
        [UserName] nvarchar(256) NULL,
        [NormalizedUserName] nvarchar(256) NULL,
        [Email] nvarchar(256) NULL,
        [NormalizedEmail] nvarchar(256) NULL,
        [EmailConfirmed] bit NOT NULL,
        [PasswordHash] nvarchar(max) NULL,
        [SecurityStamp] nvarchar(max) NULL,
        [ConcurrencyStamp] nvarchar(max) NULL,
        [PhoneNumber] nvarchar(max) NULL,
        [PhoneNumberConfirmed] bit NOT NULL,
        [TwoFactorEnabled] bit NOT NULL,
        [LockoutEnd] datetimeoffset NULL,
        [LockoutEnabled] bit NOT NULL,
        [AccessFailedCount] int NOT NULL,
        [Discriminator] nvarchar(max) NOT NULL,
        [FirstName] nvarchar(max) NULL,
        [LastName] nvarchar(max) NULL,
        [Address] nvarchar(max) NULL,
        [City] nvarchar(max) NULL,
        [County] nvarchar(max) NULL,
        [Zip] nvarchar(max) NULL,
        [BirthDate] datetime2 NULL,
        [Gender] nvarchar(max) NULL,
        [Race] nvarchar(max) NULL,
        [Income] nvarchar(max) NULL,
        [Education] nvarchar(max) NULL,
        [Residence] nvarchar(max) NULL,
        [Military] nvarchar(max) NULL,
        CONSTRAINT [PK_AspNetUsers] PRIMARY KEY ([Id])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210722211127_InitialCreateWMF207222021')
BEGIN
    CREATE TABLE [FormsControlLookup] (
        [Id] int NOT NULL IDENTITY,
        [FormControlType] nvarchar(max) NULL,
        [FormControlDescription] nvarchar(max) NULL,
        CONSTRAINT [PK_FormsControlLookup] PRIMARY KEY ([Id])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210722211127_InitialCreateWMF207222021')
BEGIN
    CREATE TABLE [QuestionCategories] (
        [Id] int NOT NULL IDENTITY,
        [QuestionCategory] nvarchar(max) NOT NULL,
        [EnableDisable] bit NOT NULL,
        CONSTRAINT [PK_QuestionCategories] PRIMARY KEY ([Id])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210722211127_InitialCreateWMF207222021')
BEGIN
    CREATE TABLE [ScoringCategory] (
        [ScoringCategoryId] int NOT NULL IDENTITY,
        [ScoreCategory] nvarchar(max) NULL,
        [EnableDisable] bit NOT NULL,
        CONSTRAINT [PK_ScoringCategory] PRIMARY KEY ([ScoringCategoryId])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210722211127_InitialCreateWMF207222021')
BEGIN
    CREATE TABLE [Status] (
        [Id] int NOT NULL IDENTITY,
        [StatusDescription] nvarchar(max) NULL,
        CONSTRAINT [PK_Status] PRIMARY KEY ([Id])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210722211127_InitialCreateWMF207222021')
BEGIN
    CREATE TABLE [AspNetRoleClaims] (
        [Id] int NOT NULL IDENTITY,
        [RoleId] nvarchar(450) NOT NULL,
        [ClaimType] nvarchar(max) NULL,
        [ClaimValue] nvarchar(max) NULL,
        CONSTRAINT [PK_AspNetRoleClaims] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_AspNetRoleClaims_AspNetRoles_RoleId] FOREIGN KEY ([RoleId]) REFERENCES [AspNetRoles] ([Id]) ON DELETE CASCADE
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210722211127_InitialCreateWMF207222021')
BEGIN
    CREATE TABLE [AspNetUserClaims] (
        [Id] int NOT NULL IDENTITY,
        [UserId] nvarchar(450) NOT NULL,
        [ClaimType] nvarchar(max) NULL,
        [ClaimValue] nvarchar(max) NULL,
        CONSTRAINT [PK_AspNetUserClaims] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_AspNetUserClaims_AspNetUsers_UserId] FOREIGN KEY ([UserId]) REFERENCES [AspNetUsers] ([Id]) ON DELETE CASCADE
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210722211127_InitialCreateWMF207222021')
BEGIN
    CREATE TABLE [AspNetUserLogins] (
        [LoginProvider] nvarchar(450) NOT NULL,
        [ProviderKey] nvarchar(450) NOT NULL,
        [ProviderDisplayName] nvarchar(max) NULL,
        [UserId] nvarchar(450) NOT NULL,
        CONSTRAINT [PK_AspNetUserLogins] PRIMARY KEY ([LoginProvider], [ProviderKey]),
        CONSTRAINT [FK_AspNetUserLogins_AspNetUsers_UserId] FOREIGN KEY ([UserId]) REFERENCES [AspNetUsers] ([Id]) ON DELETE CASCADE
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210722211127_InitialCreateWMF207222021')
BEGIN
    CREATE TABLE [AspNetUserRoles] (
        [UserId] nvarchar(450) NOT NULL,
        [RoleId] nvarchar(450) NOT NULL,
        CONSTRAINT [PK_AspNetUserRoles] PRIMARY KEY ([UserId], [RoleId]),
        CONSTRAINT [FK_AspNetUserRoles_AspNetRoles_RoleId] FOREIGN KEY ([RoleId]) REFERENCES [AspNetRoles] ([Id]) ON DELETE CASCADE,
        CONSTRAINT [FK_AspNetUserRoles_AspNetUsers_UserId] FOREIGN KEY ([UserId]) REFERENCES [AspNetUsers] ([Id]) ON DELETE CASCADE
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210722211127_InitialCreateWMF207222021')
BEGIN
    CREATE TABLE [AspNetUserTokens] (
        [UserId] nvarchar(450) NOT NULL,
        [LoginProvider] nvarchar(450) NOT NULL,
        [Name] nvarchar(450) NOT NULL,
        [Value] nvarchar(max) NULL,
        CONSTRAINT [PK_AspNetUserTokens] PRIMARY KEY ([UserId], [LoginProvider], [Name]),
        CONSTRAINT [FK_AspNetUserTokens_AspNetUsers_UserId] FOREIGN KEY ([UserId]) REFERENCES [AspNetUsers] ([Id]) ON DELETE CASCADE
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210722211127_InitialCreateWMF207222021')
BEGIN
    CREATE TABLE [FormsControlValues] (
        [Id] int NOT NULL IDENTITY,
        [Description] nvarchar(max) NULL,
        [DefaultValue] bit NOT NULL,
        [ValueOrder] int NOT NULL,
        [FormControlsLookupId] int NOT NULL,
        CONSTRAINT [PK_FormsControlValues] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_FormsControlValues_FormsControlLookup_FormControlsLookupId] FOREIGN KEY ([FormControlsLookupId]) REFERENCES [FormsControlLookup] ([Id]) ON DELETE CASCADE
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210722211127_InitialCreateWMF207222021')
BEGIN
    CREATE TABLE [Questions] (
        [Id] int NOT NULL IDENTITY,
        [Question] nvarchar(max) NOT NULL,
        [QuestionOrder] int NOT NULL,
        [QuestionType] nvarchar(max) NOT NULL,
        [EnableDisable] bit NOT NULL,
        [QuestionCategoriesId] int NOT NULL,
        CONSTRAINT [PK_Questions] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_Questions_QuestionCategories_QuestionCategoriesId] FOREIGN KEY ([QuestionCategoriesId]) REFERENCES [QuestionCategories] ([Id]) ON DELETE CASCADE
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210722211127_InitialCreateWMF207222021')
BEGIN
    CREATE TABLE [ScoringQuestions] (
        [ScoringQuestionId] int NOT NULL IDENTITY,
        [ScoreQuestions] nvarchar(max) NULL,
        [MaxScore] int NOT NULL,
        [ScoringOrder] int NOT NULL,
        [ScoringCategoryId] int NOT NULL,
        CONSTRAINT [PK_ScoringQuestions] PRIMARY KEY ([ScoringQuestionId]),
        CONSTRAINT [FK_ScoringQuestions_ScoringCategory_ScoringCategoryId] FOREIGN KEY ([ScoringCategoryId]) REFERENCES [ScoringCategory] ([ScoringCategoryId]) ON DELETE CASCADE
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210722211127_InitialCreateWMF207222021')
BEGIN
    CREATE TABLE [Application] (
        [Id] int NOT NULL IDENTITY,
        [ApplicationDate] datetime2 NOT NULL,
        [StatusDescription] nvarchar(max) NULL,
        [BusinessName] nvarchar(max) NULL,
        [Comments] nvarchar(max) NULL,
        [ApplicationUserId] nvarchar(450) NULL,
        [StatusId] int NOT NULL,
        CONSTRAINT [PK_Application] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_Application_AspNetUsers_ApplicationUserId] FOREIGN KEY ([ApplicationUserId]) REFERENCES [AspNetUsers] ([Id]) ON DELETE NO ACTION,
        CONSTRAINT [FK_Application_Status_StatusId] FOREIGN KEY ([StatusId]) REFERENCES [Status] ([Id]) ON DELETE CASCADE
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210722211127_InitialCreateWMF207222021')
BEGIN
    CREATE TABLE [PitchEvents] (
        [PitchEventsId] int NOT NULL IDENTITY,
        [PitchDateTime] datetime2 NOT NULL,
        [CashFunds] real NOT NULL,
        [ServiceFunds] real NOT NULL,
        [PitchEventDescription] nvarchar(max) NULL,
        [StatusId] int NOT NULL,
        CONSTRAINT [PK_PitchEvents] PRIMARY KEY ([PitchEventsId]),
        CONSTRAINT [FK_PitchEvents_Status_StatusId] FOREIGN KEY ([StatusId]) REFERENCES [Status] ([Id]) ON DELETE CASCADE
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210722211127_InitialCreateWMF207222021')
BEGIN
    CREATE TABLE [AwardHistory] (
        [Id] int NOT NULL IDENTITY,
        [AwardDate] datetime2 NOT NULL,
        [AwardAmount] real NOT NULL,
        [AwardAgreement] nvarchar(max) NULL,
        [ReqNumber] int NOT NULL,
        [MailDate] datetime2 NOT NULL,
        [Provider] nvarchar(max) NULL,
        [AwardType] nvarchar(max) NULL,
        [Comments] nvarchar(max) NULL,
        [ApplicationId] int NOT NULL,
        CONSTRAINT [PK_AwardHistory] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_AwardHistory_Application_ApplicationId] FOREIGN KEY ([ApplicationId]) REFERENCES [Application] ([Id]) ON DELETE CASCADE
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210722211127_InitialCreateWMF207222021')
BEGIN
    CREATE TABLE [MentorAssignment] (
        [Id] int NOT NULL IDENTITY,
        [DateAssigned] datetime2 NOT NULL,
        [ApprovedToPitchDate] datetime2 NOT NULL,
        [MentorEnabled] bit NOT NULL,
        [ApplicationId] int NOT NULL,
        CONSTRAINT [PK_MentorAssignment] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_MentorAssignment_Application_ApplicationId] FOREIGN KEY ([ApplicationId]) REFERENCES [Application] ([Id]) ON DELETE CASCADE
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210722211127_InitialCreateWMF207222021')
BEGIN
    CREATE TABLE [QuestionResponses] (
        [Id] int NOT NULL IDENTITY,
        [QuestionResponseDate] datetime2 NOT NULL,
        [QuestionResponse] nvarchar(max) NULL,
        [ApplicationId] int NOT NULL,
        [QuestionId] int NOT NULL,
        CONSTRAINT [PK_QuestionResponses] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_QuestionResponses_Application_ApplicationId] FOREIGN KEY ([ApplicationId]) REFERENCES [Application] ([Id]) ON DELETE CASCADE,
        CONSTRAINT [FK_QuestionResponses_Questions_QuestionId] FOREIGN KEY ([QuestionId]) REFERENCES [Questions] ([Id]) ON DELETE CASCADE
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210722211127_InitialCreateWMF207222021')
BEGIN
    CREATE TABLE [JudgesAssigned] (
        [JudgesAssignedId] int NOT NULL IDENTITY,
        [SystemUserId] nvarchar(450) NULL,
        [PitchEventsId] int NOT NULL,
        CONSTRAINT [PK_JudgesAssigned] PRIMARY KEY ([JudgesAssignedId]),
        CONSTRAINT [FK_JudgesAssigned_PitchEvents_PitchEventsId] FOREIGN KEY ([PitchEventsId]) REFERENCES [PitchEvents] ([PitchEventsId]) ON DELETE CASCADE,
        CONSTRAINT [FK_JudgesAssigned_AspNetUsers_SystemUserId] FOREIGN KEY ([SystemUserId]) REFERENCES [AspNetUsers] ([Id]) ON DELETE NO ACTION
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210722211127_InitialCreateWMF207222021')
BEGIN
    CREATE TABLE [MentorNotes] (
        [Id] int NOT NULL IDENTITY,
        [NotesDate] datetime2 NOT NULL,
        [Notes] nvarchar(max) NULL,
        [MentorAssignmentId] int NOT NULL,
        CONSTRAINT [PK_MentorNotes] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_MentorNotes_MentorAssignment_MentorAssignmentId] FOREIGN KEY ([MentorAssignmentId]) REFERENCES [MentorAssignment] ([Id]) ON DELETE CASCADE
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210722211127_InitialCreateWMF207222021')
BEGIN
    CREATE TABLE [JudgeScoreCard] (
        [Id] int NOT NULL IDENTITY,
        [JudgeScore] real NOT NULL,
        [JudgeComment] nvarchar(max) NULL,
        [JudgesAssignedId] int NOT NULL,
        [ScoringCategoryId] int NOT NULL,
        [ScoringApplicationId] int NOT NULL,
        CONSTRAINT [PK_JudgeScoreCard] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_JudgeScoreCard_JudgesAssigned_JudgesAssignedId] FOREIGN KEY ([JudgesAssignedId]) REFERENCES [JudgesAssigned] ([JudgesAssignedId]) ON DELETE CASCADE,
        CONSTRAINT [FK_JudgeScoreCard_Application_ScoringApplicationId] FOREIGN KEY ([ScoringApplicationId]) REFERENCES [Application] ([Id]),
        CONSTRAINT [FK_JudgeScoreCard_ScoringCategory_ScoringCategoryId] FOREIGN KEY ([ScoringCategoryId]) REFERENCES [ScoringCategory] ([ScoringCategoryId]) ON DELETE CASCADE
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210722211127_InitialCreateWMF207222021')
BEGIN
    CREATE INDEX [IX_Application_ApplicationUserId] ON [Application] ([ApplicationUserId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210722211127_InitialCreateWMF207222021')
BEGIN
    CREATE INDEX [IX_Application_StatusId] ON [Application] ([StatusId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210722211127_InitialCreateWMF207222021')
BEGIN
    CREATE INDEX [IX_AspNetRoleClaims_RoleId] ON [AspNetRoleClaims] ([RoleId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210722211127_InitialCreateWMF207222021')
BEGIN
    CREATE UNIQUE INDEX [RoleNameIndex] ON [AspNetRoles] ([NormalizedName]) WHERE [NormalizedName] IS NOT NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210722211127_InitialCreateWMF207222021')
BEGIN
    CREATE INDEX [IX_AspNetUserClaims_UserId] ON [AspNetUserClaims] ([UserId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210722211127_InitialCreateWMF207222021')
BEGIN
    CREATE INDEX [IX_AspNetUserLogins_UserId] ON [AspNetUserLogins] ([UserId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210722211127_InitialCreateWMF207222021')
BEGIN
    CREATE INDEX [IX_AspNetUserRoles_RoleId] ON [AspNetUserRoles] ([RoleId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210722211127_InitialCreateWMF207222021')
BEGIN
    CREATE INDEX [EmailIndex] ON [AspNetUsers] ([NormalizedEmail]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210722211127_InitialCreateWMF207222021')
BEGIN
    CREATE UNIQUE INDEX [UserNameIndex] ON [AspNetUsers] ([NormalizedUserName]) WHERE [NormalizedUserName] IS NOT NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210722211127_InitialCreateWMF207222021')
BEGIN
    CREATE INDEX [IX_AwardHistory_ApplicationId] ON [AwardHistory] ([ApplicationId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210722211127_InitialCreateWMF207222021')
BEGIN
    CREATE INDEX [IX_FormsControlValues_FormControlsLookupId] ON [FormsControlValues] ([FormControlsLookupId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210722211127_InitialCreateWMF207222021')
BEGIN
    CREATE INDEX [IX_JudgesAssigned_PitchEventsId] ON [JudgesAssigned] ([PitchEventsId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210722211127_InitialCreateWMF207222021')
BEGIN
    CREATE INDEX [IX_JudgesAssigned_SystemUserId] ON [JudgesAssigned] ([SystemUserId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210722211127_InitialCreateWMF207222021')
BEGIN
    CREATE INDEX [IX_JudgeScoreCard_JudgesAssignedId] ON [JudgeScoreCard] ([JudgesAssignedId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210722211127_InitialCreateWMF207222021')
BEGIN
    CREATE INDEX [IX_JudgeScoreCard_ScoringApplicationId] ON [JudgeScoreCard] ([ScoringApplicationId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210722211127_InitialCreateWMF207222021')
BEGIN
    CREATE INDEX [IX_JudgeScoreCard_ScoringCategoryId] ON [JudgeScoreCard] ([ScoringCategoryId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210722211127_InitialCreateWMF207222021')
BEGIN
    CREATE INDEX [IX_MentorAssignment_ApplicationId] ON [MentorAssignment] ([ApplicationId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210722211127_InitialCreateWMF207222021')
BEGIN
    CREATE INDEX [IX_MentorNotes_MentorAssignmentId] ON [MentorNotes] ([MentorAssignmentId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210722211127_InitialCreateWMF207222021')
BEGIN
    CREATE INDEX [IX_PitchEvents_StatusId] ON [PitchEvents] ([StatusId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210722211127_InitialCreateWMF207222021')
BEGIN
    CREATE INDEX [IX_QuestionResponses_ApplicationId] ON [QuestionResponses] ([ApplicationId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210722211127_InitialCreateWMF207222021')
BEGIN
    CREATE INDEX [IX_QuestionResponses_QuestionId] ON [QuestionResponses] ([QuestionId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210722211127_InitialCreateWMF207222021')
BEGIN
    CREATE INDEX [IX_Questions_QuestionCategoriesId] ON [Questions] ([QuestionCategoriesId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210722211127_InitialCreateWMF207222021')
BEGIN
    CREATE INDEX [IX_ScoringQuestions_ScoringCategoryId] ON [ScoringQuestions] ([ScoringCategoryId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210722211127_InitialCreateWMF207222021')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20210722211127_InitialCreateWMF207222021', N'3.1.13');
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210722215109_ScoringQuestionsandCategoryFix')
BEGIN
    ALTER TABLE [JudgesAssigned] DROP CONSTRAINT [FK_JudgesAssigned_PitchEvents_PitchEventsId];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210722215109_ScoringQuestionsandCategoryFix')
BEGIN
    ALTER TABLE [ScoringQuestions] DROP CONSTRAINT [FK_ScoringQuestions_ScoringCategory_ScoringCategoryId];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210722215109_ScoringQuestionsandCategoryFix')
BEGIN
    DROP INDEX [IX_ScoringQuestions_ScoringCategoryId] ON [ScoringQuestions];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210722215109_ScoringQuestionsandCategoryFix')
BEGIN
    ALTER TABLE [PitchEvents] DROP CONSTRAINT [PK_PitchEvents];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210722215109_ScoringQuestionsandCategoryFix')
BEGIN
    DROP INDEX [IX_JudgeScoreCard_ScoringCategoryId] ON [JudgeScoreCard];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210722215109_ScoringQuestionsandCategoryFix')
BEGIN
    DECLARE @var0 sysname;
    SELECT @var0 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[ScoringQuestions]') AND [c].[name] = N'ScoringCategoryId');
    IF @var0 IS NOT NULL EXEC(N'ALTER TABLE [ScoringQuestions] DROP CONSTRAINT [' + @var0 + '];');
    ALTER TABLE [ScoringQuestions] DROP COLUMN [ScoringCategoryId];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210722215109_ScoringQuestionsandCategoryFix')
BEGIN
    ALTER TABLE [ScoringCategory] ADD [ScoringQuestionsId] int NOT NULL DEFAULT 0;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210722215109_ScoringQuestionsandCategoryFix')
BEGIN
    ALTER TABLE [PitchEvents] ADD CONSTRAINT [PK_PitchEvents] PRIMARY KEY ([Id]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210722215109_ScoringQuestionsandCategoryFix')
BEGIN
    CREATE INDEX [IX_ScoringCategory_ScoringQuestionsId] ON [ScoringCategory] ([ScoringQuestionsId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210722215109_ScoringQuestionsandCategoryFix')
BEGIN
    CREATE INDEX [IX_JudgeScoreCard_ScoringQuestionsId] ON [JudgeScoreCard] ([ScoringQuestionsId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210722215109_ScoringQuestionsandCategoryFix')
BEGIN
    ALTER TABLE [JudgesAssigned] ADD CONSTRAINT [FK_JudgesAssigned_PitchEvents_PitchEventsId] FOREIGN KEY ([PitchEventsId]) REFERENCES [PitchEvents] ([Id]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210722215109_ScoringQuestionsandCategoryFix')
BEGIN
    ALTER TABLE [ScoringCategory] ADD CONSTRAINT [FK_ScoringCategory_ScoringQuestions_ScoringQuestionsId] FOREIGN KEY ([ScoringQuestionsId]) REFERENCES [ScoringQuestions] ([ScoringQuestionId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210722215109_ScoringQuestionsandCategoryFix')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20210722215109_ScoringQuestionsandCategoryFix', N'3.1.13');
END;

GO

