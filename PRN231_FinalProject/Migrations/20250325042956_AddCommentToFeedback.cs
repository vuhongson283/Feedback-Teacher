using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PRN231_FinalProject.Migrations
{
    public partial class AddCommentToFeedback : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Comment",
                table: "FeedbackForms",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Comment",
                table: "FeedbackForms");
        }
    }
}
