using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Infra.Migrations
{
    public partial class NewEntitiesAdd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CLNT_STATUS",
                table: "AspNetUsers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Vehicles",
                columns: table => new
                {
                    VHCL_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VHCL_MANUFACTURER = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    VHCL_MODEL = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    VHCL_YEAR = table.Column<int>(type: "int", nullable: false),
                    VHCL_CATEGORY = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vehicles", x => x.VHCL_ID);
                });

            migrationBuilder.CreateTable(
                name: "TB_CONTRACTS",
                columns: table => new
                {
                    CTRC_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CLNT = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    VHCL = table.Column<int>(type: "int", nullable: true),
                    CTRC_START = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CTRC_FINISH = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CTRC_PRICE = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_CONTRACTS", x => x.CTRC_ID);
                    table.ForeignKey(
                        name: "FK_TB_CONTRACTS_AspNetUsers_CLNT",
                        column: x => x.CLNT,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TB_CONTRACTS_Vehicles_VHCL",
                        column: x => x.VHCL,
                        principalTable: "Vehicles",
                        principalColumn: "VHCL_ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TB_CONTRACTS_CLNT",
                table: "TB_CONTRACTS",
                column: "CLNT");

            migrationBuilder.CreateIndex(
                name: "IX_TB_CONTRACTS_VHCL",
                table: "TB_CONTRACTS",
                column: "VHCL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TB_CONTRACTS");

            migrationBuilder.DropTable(
                name: "Vehicles");

            migrationBuilder.DropColumn(
                name: "CLNT_STATUS",
                table: "AspNetUsers");
        }
    }
}
