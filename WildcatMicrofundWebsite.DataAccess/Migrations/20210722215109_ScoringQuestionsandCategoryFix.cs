using Microsoft.EntityFrameworkCore.Migrations;

namespace WMF.DataAccess.Migrations
{
    public partial class ScoringQuestionsandCategoryFix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_JudgesAssigned_PitchEvents_PitchEventsId",
                table: "JudgesAssigned");           

            migrationBuilder.DropForeignKey(
                name: "FK_ScoringQuestions_ScoringCategory_ScoringCategoryId",
                table: "ScoringQuestions");

            migrationBuilder.DropIndex(
                name: "IX_ScoringQuestions_ScoringCategoryId",
                table: "ScoringQuestions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PitchEvents",
                table: "PitchEvents");

            migrationBuilder.DropIndex(
                name: "IX_JudgeScoreCard_ScoringCategoryId",
                table: "JudgeScoreCard");

            migrationBuilder.DropColumn(
                name: "ScoringCategoryId",
                table: "ScoringQuestions");                      

            migrationBuilder.AddColumn<int>(
                name: "ScoringQuestionsId",
                table: "ScoringCategory",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_PitchEvents",
                table: "PitchEvents",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_ScoringCategory_ScoringQuestionsId",
                table: "ScoringCategory",
                column: "ScoringQuestionsId");

            migrationBuilder.CreateIndex(
                name: "IX_JudgeScoreCard_ScoringQuestionsId",
                table: "JudgeScoreCard",
                column: "ScoringQuestionsId");

            migrationBuilder.AddForeignKey(
                name: "FK_JudgesAssigned_PitchEvents_PitchEventsId",
                table: "JudgesAssigned",
                column: "PitchEventsId",
                principalTable: "PitchEvents",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);           

            migrationBuilder.AddForeignKey(
                name: "FK_ScoringCategory_ScoringQuestions_ScoringQuestionsId",
                table: "ScoringCategory",
                column: "ScoringQuestionsId",
                principalTable: "ScoringQuestions",
                principalColumn: "ScoringQuestionId",
                onDelete: ReferentialAction.NoAction);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_JudgesAssigned_PitchEvents_PitchEventsId",
                table: "JudgesAssigned");

            migrationBuilder.DropForeignKey(
                name: "FK_JudgeScoreCard_ScoringQuestions_ScoringQuestionsId",
                table: "JudgeScoreCard");

            migrationBuilder.DropForeignKey(
                name: "FK_ScoringCategory_ScoringQuestions_ScoringQuestionsId",
                table: "ScoringCategory");

            migrationBuilder.DropIndex(
                name: "IX_ScoringCategory_ScoringQuestionsId",
                table: "ScoringCategory");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PitchEvents",
                table: "PitchEvents");

            migrationBuilder.DropIndex(
                name: "IX_JudgeScoreCard_ScoringQuestionsId",
                table: "JudgeScoreCard");

            migrationBuilder.DropColumn(
                name: "ScoringQuestionsId",
                table: "ScoringCategory");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "PitchEvents");

            migrationBuilder.DropColumn(
                name: "ScoringQuestionsId",
                table: "JudgeScoreCard");

            migrationBuilder.AddColumn<int>(
                name: "ScoringCategoryId",
                table: "ScoringQuestions",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PitchEventsId",
                table: "PitchEvents",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "ScoringCategoryId",
                table: "JudgeScoreCard",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_PitchEvents",
                table: "PitchEvents",
                column: "PitchEventsId");

            migrationBuilder.CreateIndex(
                name: "IX_ScoringQuestions_ScoringCategoryId",
                table: "ScoringQuestions",
                column: "ScoringCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_JudgeScoreCard_ScoringCategoryId",
                table: "JudgeScoreCard",
                column: "ScoringCategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_JudgesAssigned_PitchEvents_PitchEventsId",
                table: "JudgesAssigned",
                column: "PitchEventsId",
                principalTable: "PitchEvents",
                principalColumn: "PitchEventsId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_JudgeScoreCard_ScoringCategory_ScoringCategoryId",
                table: "JudgeScoreCard",
                column: "ScoringCategoryId",
                principalTable: "ScoringCategory",
                principalColumn: "ScoringCategoryId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ScoringQuestions_ScoringCategory_ScoringCategoryId",
                table: "ScoringQuestions",
                column: "ScoringCategoryId",
                principalTable: "ScoringCategory",
                principalColumn: "ScoringCategoryId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
