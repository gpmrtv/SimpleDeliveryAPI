using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SimpleDelivery.DAL.Migrations
{
    public partial class changeOrderRelation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Routes_Orders_OrderId",
                table: "Routes");

            migrationBuilder.DropIndex(
                name: "IX_Routes_OrderId",
                table: "Routes");

            migrationBuilder.DropColumn(
                name: "OrderId",
                table: "Routes");

            migrationBuilder.AddColumn<Guid>(
                name: "RouteId",
                table: "Orders",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Orders_RouteId",
                table: "Orders",
                column: "RouteId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Routes_RouteId",
                table: "Orders",
                column: "RouteId",
                principalTable: "Routes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Routes_RouteId",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Orders_RouteId",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "RouteId",
                table: "Orders");

            migrationBuilder.AddColumn<Guid>(
                name: "OrderId",
                table: "Routes",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Routes_OrderId",
                table: "Routes",
                column: "OrderId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Routes_Orders_OrderId",
                table: "Routes",
                column: "OrderId",
                principalTable: "Orders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
