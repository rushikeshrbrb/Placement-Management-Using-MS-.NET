using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplicationIdentity.Migrations
{
    /// <inheritdoc />
    public partial class jobuserid : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "User_id",
                table: "JobApplications",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "User_id",
                table: "JobApplications");
        }
    }
}
