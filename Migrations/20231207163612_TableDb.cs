using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EMS_App.Migrations
{
    /// <inheritdoc />
    public partial class TableDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Event",
                columns: table => new
                {
                    Ename = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Ediscription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EBanner = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Event", x => x.Ename);
                });

            migrationBuilder.CreateTable(
                name: "Speaker",
                columns: table => new
                {
                    Sid = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Sname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SBio = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Simage = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Speaker", x => x.Sid);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Uemail = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Uname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Udob = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Unumber = table.Column<int>(type: "int", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Uemail);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Event");

            migrationBuilder.DropTable(
                name: "Speaker");

            migrationBuilder.DropTable(
                name: "User");
        }
    }
}
