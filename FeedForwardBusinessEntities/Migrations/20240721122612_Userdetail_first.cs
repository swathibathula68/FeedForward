using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FeedForwardBusinessEntities.Migrations
{
    public partial class Userdetail_first : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DesignationLevels",
                columns: table => new
                {
                    DesignationID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Designation = table.Column<string>(type: "varchar(100)", nullable: false),
                    LevelID = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "varchar(500)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    CreatedBy = table.Column<string>(type: "varchar(50)", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    ModifiedBy = table.Column<string>(type: "varchar(50)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DesignationLevels", x => x.DesignationID);
                });

            migrationBuilder.CreateTable(
                name: "FeedbackCaptions",
                columns: table => new
                {
                    FCID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FCDescription = table.Column<string>(type: "varchar(50)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    CreatedBy = table.Column<string>(type: "varchar(50)", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    ModifiedBy = table.Column<string>(type: "varchar(50)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FeedbackCaptions", x => x.FCID);
                });

            migrationBuilder.CreateTable(
                name: "FeedBackCategoryLevels",
                columns: table => new
                {
                    FCLID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FCLDescription = table.Column<string>(type: "varchar(500)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "DateTime", nullable: true),
                    CreadtedBy = table.Column<string>(type: "varchar(500)", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "DateTime", nullable: true),
                    ModifiedBy = table.Column<string>(type: "varchar(500)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FeedBackCategoryLevels", x => x.FCLID);
                });

            migrationBuilder.CreateTable(
                name: "FeedbackScheduingDetails",
                columns: table => new
                {
                    SchID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FeedBackBy = table.Column<string>(type: "varchar(50)", nullable: false),
                    FeedBackTo = table.Column<string>(type: "varchar(50)", nullable: false),
                    FSID = table.Column<int>(type: "int", nullable: false),
                    Fstatus = table.Column<bool>(type: "bit", nullable: false),
                    FComment = table.Column<string>(type: "varchar(5000)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FeedbackScheduingDetails", x => x.SchID);
                });

            migrationBuilder.CreateTable(
                name: "FeedbackSessions",
                columns: table => new
                {
                    FSID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FSDescription = table.Column<string>(type: "varchar(50)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    CreatedBy = table.Column<string>(type: "varchar(50)", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    ModifiedBy = table.Column<string>(type: "varchar(50)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FeedbackSessions", x => x.FSID);
                });

            migrationBuilder.CreateTable(
                name: "LevelDetails",
                columns: table => new
                {
                    LevelID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LevelDescription = table.Column<string>(type: "varchar(100)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "DateTime", nullable: true),
                    CreatedBy = table.Column<string>(type: "varchar(100)", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "DateTime", nullable: true),
                    ModifiedBy = table.Column<string>(type: "varchar(100)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LevelDetails", x => x.LevelID);
                });

            migrationBuilder.CreateTable(
                name: "QuestionDetails",
                columns: table => new
                {
                    QID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Question = table.Column<string>(type: "varchar(100)", nullable: false),
                    LevelID = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "DateTime", nullable: true),
                    CreatedBy = table.Column<string>(type: "varchar(50)", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "DateTime", nullable: true),
                    ModifiedBy = table.Column<string>(type: "varchar(50)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuestionDetails", x => x.QID);
                });

            migrationBuilder.CreateTable(
                name: "RoleDetails",
                columns: table => new
                {
                    RoleID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleDescription = table.Column<string>(type: "varchar(50)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    CreatedBy = table.Column<string>(type: "varchar(50)", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    ModifiedBy = table.Column<string>(type: "varchar(50)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoleDetails", x => x.RoleID);
                });

            migrationBuilder.CreateTable(
                name: "UserDetails",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserID = table.Column<string>(type: "varchar(50)", nullable: false),
                    Password = table.Column<string>(type: "varchar(50)", nullable: true),
                    Name = table.Column<string>(type: "varchar(100)", nullable: true),
                    RoleID = table.Column<int>(type: "int", nullable: false),
                    Email = table.Column<string>(type: "varchar(50)", nullable: true),
                    Mobile = table.Column<string>(type: "varchar(20)", nullable: true),
                    EmpID = table.Column<string>(type: "varchar(20)", nullable: true),
                    PasswordChangeDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    DesignationID = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    CreatedBy = table.Column<string>(type: "varchar(50)", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    ModifiedBy = table.Column<string>(type: "varchar(50)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserDetails", x => x.ID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DesignationLevels");

            migrationBuilder.DropTable(
                name: "FeedbackCaptions");

            migrationBuilder.DropTable(
                name: "FeedBackCategoryLevels");

            migrationBuilder.DropTable(
                name: "FeedbackScheduingDetails");

            migrationBuilder.DropTable(
                name: "FeedbackSessions");

            migrationBuilder.DropTable(
                name: "LevelDetails");

            migrationBuilder.DropTable(
                name: "QuestionDetails");

            migrationBuilder.DropTable(
                name: "RoleDetails");

            migrationBuilder.DropTable(
                name: "UserDetails");
        }
    }
}
