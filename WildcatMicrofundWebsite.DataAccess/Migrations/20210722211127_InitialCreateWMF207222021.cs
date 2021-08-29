using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WMF.DataAccess.Migrations
{
    public partial class InitialCreateWMF207222021 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    UserName = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(maxLength: 256, nullable: true),
                    Email = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    PasswordHash = table.Column<string>(nullable: true),
                    SecurityStamp = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(nullable: false),
                    TwoFactorEnabled = table.Column<bool>(nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
                    LockoutEnabled = table.Column<bool>(nullable: false),
                    AccessFailedCount = table.Column<int>(nullable: false),
                    Discriminator = table.Column<string>(nullable: false),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    Address = table.Column<string>(nullable: true),
                    City = table.Column<string>(nullable: true),
                    County = table.Column<string>(nullable: true),
                    Zip = table.Column<string>(nullable: true),
                    BirthDate = table.Column<DateTime>(nullable: true),
                    Gender = table.Column<string>(nullable: true),
                    Race = table.Column<string>(nullable: true),
                    Income = table.Column<string>(nullable: true),
                    Education = table.Column<string>(nullable: true),
                    Residence = table.Column<string>(nullable: true),
                    Military = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FormsControlLookup",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FormControlType = table.Column<string>(nullable: true),
                    FormControlDescription = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FormsControlLookup", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "QuestionCategories",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    QuestionCategory = table.Column<string>(nullable: false),
                    EnableDisable = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuestionCategories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ScoringCategory",
                columns: table => new
                {
                    ScoringCategoryId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ScoreCategory = table.Column<string>(nullable: true),
                    EnableDisable = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ScoringCategory", x => x.ScoringCategoryId);
                });

            migrationBuilder.CreateTable(
                name: "Status",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StatusDescription = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Status", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(nullable: false),
                    ProviderKey = table.Column<string>(nullable: false),
                    ProviderDisplayName = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    RoleId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    LoginProvider = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FormsControlValues",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(nullable: true),
                    DefaultValue = table.Column<bool>(nullable: false),
                    ValueOrder = table.Column<int>(nullable: false),
                    FormControlsLookupId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FormsControlValues", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FormsControlValues_FormsControlLookup_FormControlsLookupId",
                        column: x => x.FormControlsLookupId,
                        principalTable: "FormsControlLookup",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Questions",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Question = table.Column<string>(nullable: false),
                    QuestionOrder = table.Column<int>(nullable: false),
                    QuestionType = table.Column<string>(nullable: false),
                    EnableDisable = table.Column<bool>(nullable: false),
                    QuestionCategoriesId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Questions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Questions_QuestionCategories_QuestionCategoriesId",
                        column: x => x.QuestionCategoriesId,
                        principalTable: "QuestionCategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ScoringQuestions",
                columns: table => new
                {
                    ScoringQuestionId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ScoreQuestions = table.Column<string>(nullable: true),
                    MaxScore = table.Column<int>(nullable: false),
                    ScoringOrder = table.Column<int>(nullable: false),
                    ScoringCategoryId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ScoringQuestions", x => x.ScoringQuestionId);
                    table.ForeignKey(
                        name: "FK_ScoringQuestions_ScoringCategory_ScoringCategoryId",
                        column: x => x.ScoringCategoryId,
                        principalTable: "ScoringCategory",
                        principalColumn: "ScoringCategoryId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Application",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ApplicationDate = table.Column<DateTime>(nullable: false),
                    StatusDescription = table.Column<string>(nullable: true),
                    BusinessName = table.Column<string>(nullable: true),
                    Comments = table.Column<string>(nullable: true),
                    ApplicationUserId = table.Column<string>(nullable: true),
                    StatusId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Application", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Application_AspNetUsers_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Application_Status_StatusId",
                        column: x => x.StatusId,
                        principalTable: "Status",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PitchEvents",
                columns: table => new
                {
                    PitchEventsId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PitchDateTime = table.Column<DateTime>(nullable: false),
                    CashFunds = table.Column<float>(nullable: false),
                    ServiceFunds = table.Column<float>(nullable: false),
                    PitchEventDescription = table.Column<string>(nullable: true),
                    StatusId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PitchEvents", x => x.PitchEventsId);
                    table.ForeignKey(
                        name: "FK_PitchEvents_Status_StatusId",
                        column: x => x.StatusId,
                        principalTable: "Status",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AwardHistory",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AwardDate = table.Column<DateTime>(nullable: false),
                    AwardAmount = table.Column<float>(nullable: false),
                    AwardAgreement = table.Column<string>(nullable: true),
                    ReqNumber = table.Column<int>(nullable: false),
                    MailDate = table.Column<DateTime>(nullable: false),
                    Provider = table.Column<string>(nullable: true),
                    AwardType = table.Column<string>(nullable: true),
                    Comments = table.Column<string>(nullable: true),
                    ApplicationId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AwardHistory", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AwardHistory_Application_ApplicationId",
                        column: x => x.ApplicationId,
                        principalTable: "Application",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MentorAssignment",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DateAssigned = table.Column<DateTime>(nullable: false),
                    ApprovedToPitchDate = table.Column<DateTime>(nullable: false),
                    MentorEnabled = table.Column<bool>(nullable: false),
                    ApplicationId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MentorAssignment", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MentorAssignment_Application_ApplicationId",
                        column: x => x.ApplicationId,
                        principalTable: "Application",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "QuestionResponses",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    QuestionResponseDate = table.Column<DateTime>(nullable: false),
                    QuestionResponse = table.Column<string>(nullable: true),
                    ApplicationId = table.Column<int>(nullable: false),
                    QuestionId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuestionResponses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_QuestionResponses_Application_ApplicationId",
                        column: x => x.ApplicationId,
                        principalTable: "Application",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_QuestionResponses_Questions_QuestionId",
                        column: x => x.QuestionId,
                        principalTable: "Questions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "JudgesAssigned",
                columns: table => new
                {
                    JudgesAssignedId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SystemUserId = table.Column<string>(nullable: true),
                    PitchEventsId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JudgesAssigned", x => x.JudgesAssignedId);
                    table.ForeignKey(
                        name: "FK_JudgesAssigned_PitchEvents_PitchEventsId",
                        column: x => x.PitchEventsId,
                        principalTable: "PitchEvents",
                        principalColumn: "PitchEventsId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_JudgesAssigned_AspNetUsers_SystemUserId",
                        column: x => x.SystemUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "MentorNotes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NotesDate = table.Column<DateTime>(nullable: false),
                    Notes = table.Column<string>(nullable: true),
                    MentorAssignmentId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MentorNotes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MentorNotes_MentorAssignment_MentorAssignmentId",
                        column: x => x.MentorAssignmentId,
                        principalTable: "MentorAssignment",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "JudgeScoreCard",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    JudgeScore = table.Column<float>(nullable: false),
                    JudgeComment = table.Column<string>(nullable: true),
                    JudgesAssignedId = table.Column<int>(nullable: false),
                    ScoringCategoryId = table.Column<int>(nullable: false),
                    ScoringApplicationId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JudgeScoreCard", x => x.Id);
                    table.ForeignKey(
                        name: "FK_JudgeScoreCard_JudgesAssigned_JudgesAssignedId",
                        column: x => x.JudgesAssignedId,
                        principalTable: "JudgesAssigned",
                        principalColumn: "JudgesAssignedId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_JudgeScoreCard_Application_ScoringApplicationId",
                        column: x => x.ScoringApplicationId,
                        principalTable: "Application",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_JudgeScoreCard_ScoringCategory_ScoringCategoryId",
                        column: x => x.ScoringCategoryId,
                        principalTable: "ScoringCategory",
                        principalColumn: "ScoringCategoryId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Application_ApplicationUserId",
                table: "Application",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Application_StatusId",
                table: "Application",
                column: "StatusId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AwardHistory_ApplicationId",
                table: "AwardHistory",
                column: "ApplicationId");

            migrationBuilder.CreateIndex(
                name: "IX_FormsControlValues_FormControlsLookupId",
                table: "FormsControlValues",
                column: "FormControlsLookupId");

            migrationBuilder.CreateIndex(
                name: "IX_JudgesAssigned_PitchEventsId",
                table: "JudgesAssigned",
                column: "PitchEventsId");

            migrationBuilder.CreateIndex(
                name: "IX_JudgesAssigned_SystemUserId",
                table: "JudgesAssigned",
                column: "SystemUserId");

            migrationBuilder.CreateIndex(
                name: "IX_JudgeScoreCard_JudgesAssignedId",
                table: "JudgeScoreCard",
                column: "JudgesAssignedId");

            migrationBuilder.CreateIndex(
                name: "IX_JudgeScoreCard_ScoringApplicationId",
                table: "JudgeScoreCard",
                column: "ScoringApplicationId");

            migrationBuilder.CreateIndex(
                name: "IX_JudgeScoreCard_ScoringCategoryId",
                table: "JudgeScoreCard",
                column: "ScoringCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_MentorAssignment_ApplicationId",
                table: "MentorAssignment",
                column: "ApplicationId");

            migrationBuilder.CreateIndex(
                name: "IX_MentorNotes_MentorAssignmentId",
                table: "MentorNotes",
                column: "MentorAssignmentId");

            migrationBuilder.CreateIndex(
                name: "IX_PitchEvents_StatusId",
                table: "PitchEvents",
                column: "StatusId");

            migrationBuilder.CreateIndex(
                name: "IX_QuestionResponses_ApplicationId",
                table: "QuestionResponses",
                column: "ApplicationId");

            migrationBuilder.CreateIndex(
                name: "IX_QuestionResponses_QuestionId",
                table: "QuestionResponses",
                column: "QuestionId");

            migrationBuilder.CreateIndex(
                name: "IX_Questions_QuestionCategoriesId",
                table: "Questions",
                column: "QuestionCategoriesId");

            migrationBuilder.CreateIndex(
                name: "IX_ScoringQuestions_ScoringCategoryId",
                table: "ScoringQuestions",
                column: "ScoringCategoryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "AwardHistory");

            migrationBuilder.DropTable(
                name: "FormsControlValues");

            migrationBuilder.DropTable(
                name: "JudgeScoreCard");

            migrationBuilder.DropTable(
                name: "MentorNotes");

            migrationBuilder.DropTable(
                name: "QuestionResponses");

            migrationBuilder.DropTable(
                name: "ScoringQuestions");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "FormsControlLookup");

            migrationBuilder.DropTable(
                name: "JudgesAssigned");

            migrationBuilder.DropTable(
                name: "MentorAssignment");

            migrationBuilder.DropTable(
                name: "Questions");

            migrationBuilder.DropTable(
                name: "ScoringCategory");

            migrationBuilder.DropTable(
                name: "PitchEvents");

            migrationBuilder.DropTable(
                name: "Application");

            migrationBuilder.DropTable(
                name: "QuestionCategories");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Status");
        }
    }
}
