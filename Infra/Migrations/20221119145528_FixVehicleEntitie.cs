using Microsoft.EntityFrameworkCore.Migrations;

namespace Infra.Migrations
{
    public partial class FixVehicleEntitie : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TB_CONTRACTS_Vehicles_VHCL",
                table: "TB_CONTRACTS");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Vehicles",
                table: "Vehicles");

            migrationBuilder.RenameTable(
                name: "Vehicles",
                newName: "TB_VEHICLES");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TB_VEHICLES",
                table: "TB_VEHICLES",
                column: "VHCL_ID");

            migrationBuilder.AddForeignKey(
                name: "FK_TB_CONTRACTS_TB_VEHICLES_VHCL",
                table: "TB_CONTRACTS",
                column: "VHCL",
                principalTable: "TB_VEHICLES",
                principalColumn: "VHCL_ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TB_CONTRACTS_TB_VEHICLES_VHCL",
                table: "TB_CONTRACTS");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TB_VEHICLES",
                table: "TB_VEHICLES");

            migrationBuilder.RenameTable(
                name: "TB_VEHICLES",
                newName: "Vehicles");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Vehicles",
                table: "Vehicles",
                column: "VHCL_ID");

            migrationBuilder.AddForeignKey(
                name: "FK_TB_CONTRACTS_Vehicles_VHCL",
                table: "TB_CONTRACTS",
                column: "VHCL",
                principalTable: "Vehicles",
                principalColumn: "VHCL_ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
