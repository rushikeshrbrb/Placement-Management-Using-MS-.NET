using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplicationIdentity.Migrations
{
    /// <inheritdoc />
    public partial class jobapplication : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Applyforjob_AddJobs_Job_Id",
                table: "Applyforjob");

            migrationBuilder.DropForeignKey(
                name: "FK_Applyforjob_Companies_Company_Id",
                table: "Applyforjob");

            migrationBuilder.DropForeignKey(
                name: "FK_Applyforjob_Student_StudentId",
                table: "Applyforjob");

            migrationBuilder.AlterColumn<string>(
                name: "ResumeFilePath",
                table: "Student",
                type: "longtext",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "longtext")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "TextareaValue",
                table: "Applyforjob",
                type: "longtext",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "longtext")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "StudentId",
                table: "Applyforjob",
                type: "varchar(255)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(255)")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "Resume",
                table: "Applyforjob",
                type: "longtext",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "longtext")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "Remark",
                table: "Applyforjob",
                type: "longtext",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "longtext")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "MobileNo",
                table: "Applyforjob",
                type: "longtext",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "longtext")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "Job_Id",
                table: "Applyforjob",
                type: "varchar(255)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(255)")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "GraduationYear",
                table: "Applyforjob",
                type: "longtext",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "longtext")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<int>(
                name: "Experience",
                table: "Applyforjob",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Applyforjob",
                type: "longtext",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "longtext")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "Company_Id",
                table: "Applyforjob",
                type: "varchar(255)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(255)")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<int>(
                name: "CompanyId",
                table: "Applyforjob",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "JobApplications",
                columns: table => new
                {
                    ApplicationId = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Email = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    MobileNo = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Experience = table.Column<int>(type: "int", nullable: true),
                    GraduationYear = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    skills = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Status = table.Column<int>(type: "int", nullable: true),
                    StudentId = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Company_Id = table.Column<string>(type: "varchar(255)", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Job_Id = table.Column<string>(type: "varchar(255)", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JobApplications", x => x.ApplicationId);
                    table.ForeignKey(
                        name: "FK_JobApplications_AddJobs_Job_Id",
                        column: x => x.Job_Id,
                        principalTable: "AddJobs",
                        principalColumn: "Job_Id");
                    table.ForeignKey(
                        name: "FK_JobApplications_Companies_Company_Id",
                        column: x => x.Company_Id,
                        principalTable: "Companies",
                        principalColumn: "Company_Id");
                    table.ForeignKey(
                        name: "FK_JobApplications_Student_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Student",
                        principalColumn: "StudentId",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_JobApplications_Company_Id",
                table: "JobApplications",
                column: "Company_Id");

            migrationBuilder.CreateIndex(
                name: "IX_JobApplications_Job_Id",
                table: "JobApplications",
                column: "Job_Id");

            migrationBuilder.CreateIndex(
                name: "IX_JobApplications_StudentId",
                table: "JobApplications",
                column: "StudentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Applyforjob_AddJobs_Job_Id",
                table: "Applyforjob",
                column: "Job_Id",
                principalTable: "AddJobs",
                principalColumn: "Job_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Applyforjob_Companies_Company_Id",
                table: "Applyforjob",
                column: "Company_Id",
                principalTable: "Companies",
                principalColumn: "Company_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Applyforjob_Student_StudentId",
                table: "Applyforjob",
                column: "StudentId",
                principalTable: "Student",
                principalColumn: "StudentId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Applyforjob_AddJobs_Job_Id",
                table: "Applyforjob");

            migrationBuilder.DropForeignKey(
                name: "FK_Applyforjob_Companies_Company_Id",
                table: "Applyforjob");

            migrationBuilder.DropForeignKey(
                name: "FK_Applyforjob_Student_StudentId",
                table: "Applyforjob");

            migrationBuilder.DropTable(
                name: "JobApplications");

            migrationBuilder.DropColumn(
                name: "CompanyId",
                table: "Applyforjob");

            migrationBuilder.UpdateData(
                table: "Student",
                keyColumn: "ResumeFilePath",
                keyValue: null,
                column: "ResumeFilePath",
                value: "");

            migrationBuilder.AlterColumn<string>(
                name: "ResumeFilePath",
                table: "Student",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext",
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.UpdateData(
                table: "Applyforjob",
                keyColumn: "TextareaValue",
                keyValue: null,
                column: "TextareaValue",
                value: "");

            migrationBuilder.AlterColumn<string>(
                name: "TextareaValue",
                table: "Applyforjob",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext",
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.UpdateData(
                table: "Applyforjob",
                keyColumn: "StudentId",
                keyValue: null,
                column: "StudentId",
                value: "");

            migrationBuilder.AlterColumn<string>(
                name: "StudentId",
                table: "Applyforjob",
                type: "varchar(255)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(255)",
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.UpdateData(
                table: "Applyforjob",
                keyColumn: "Resume",
                keyValue: null,
                column: "Resume",
                value: "");

            migrationBuilder.AlterColumn<string>(
                name: "Resume",
                table: "Applyforjob",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext",
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.UpdateData(
                table: "Applyforjob",
                keyColumn: "Remark",
                keyValue: null,
                column: "Remark",
                value: "");

            migrationBuilder.AlterColumn<string>(
                name: "Remark",
                table: "Applyforjob",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext",
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.UpdateData(
                table: "Applyforjob",
                keyColumn: "MobileNo",
                keyValue: null,
                column: "MobileNo",
                value: "");

            migrationBuilder.AlterColumn<string>(
                name: "MobileNo",
                table: "Applyforjob",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext",
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.UpdateData(
                table: "Applyforjob",
                keyColumn: "Job_Id",
                keyValue: null,
                column: "Job_Id",
                value: "");

            migrationBuilder.AlterColumn<string>(
                name: "Job_Id",
                table: "Applyforjob",
                type: "varchar(255)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(255)",
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.UpdateData(
                table: "Applyforjob",
                keyColumn: "GraduationYear",
                keyValue: null,
                column: "GraduationYear",
                value: "");

            migrationBuilder.AlterColumn<string>(
                name: "GraduationYear",
                table: "Applyforjob",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext",
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<int>(
                name: "Experience",
                table: "Applyforjob",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "Applyforjob",
                keyColumn: "Email",
                keyValue: null,
                column: "Email",
                value: "");

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Applyforjob",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext",
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.UpdateData(
                table: "Applyforjob",
                keyColumn: "Company_Id",
                keyValue: null,
                column: "Company_Id",
                value: "");

            migrationBuilder.AlterColumn<string>(
                name: "Company_Id",
                table: "Applyforjob",
                type: "varchar(255)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(255)",
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddForeignKey(
                name: "FK_Applyforjob_AddJobs_Job_Id",
                table: "Applyforjob",
                column: "Job_Id",
                principalTable: "AddJobs",
                principalColumn: "Job_Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Applyforjob_Companies_Company_Id",
                table: "Applyforjob",
                column: "Company_Id",
                principalTable: "Companies",
                principalColumn: "Company_Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Applyforjob_Student_StudentId",
                table: "Applyforjob",
                column: "StudentId",
                principalTable: "Student",
                principalColumn: "StudentId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
