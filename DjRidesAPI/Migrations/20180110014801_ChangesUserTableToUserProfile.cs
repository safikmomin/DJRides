using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace DjRidesAPI.Migrations
{
    public partial class ChangesUserTableToUserProfile : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Addresses_Users_UserID",
                table: "Addresses");

            migrationBuilder.DropForeignKey(
                name: "FK_Cars_Users_UserID",
                table: "Cars");

            migrationBuilder.DropForeignKey(
                name: "FK_Rides_Users_UserID",
                table: "Rides");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.RenameColumn(
                name: "UserID",
                table: "Rides",
                newName: "UserProfileID");

            migrationBuilder.RenameIndex(
                name: "IX_Rides_UserID",
                table: "Rides",
                newName: "IX_Rides_UserProfileID");

            migrationBuilder.RenameColumn(
                name: "UserID",
                table: "Cars",
                newName: "UserProfileID");

            migrationBuilder.RenameIndex(
                name: "IX_Cars_UserID",
                table: "Cars",
                newName: "IX_Cars_UserProfileID");

            migrationBuilder.RenameColumn(
                name: "UserID",
                table: "Addresses",
                newName: "UserProfileID");

            migrationBuilder.RenameIndex(
                name: "IX_Addresses_UserID",
                table: "Addresses",
                newName: "IX_Addresses_UserProfileID");

            migrationBuilder.AddColumn<int>(
                name: "Test",
                table: "Rides",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "UserProfiles",
                columns: table => new
                {
                    UserProfileID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AuthID = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserProfiles", x => x.UserProfileID);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Addresses_UserProfiles_UserProfileID",
                table: "Addresses",
                column: "UserProfileID",
                principalTable: "UserProfiles",
                principalColumn: "UserProfileID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Cars_UserProfiles_UserProfileID",
                table: "Cars",
                column: "UserProfileID",
                principalTable: "UserProfiles",
                principalColumn: "UserProfileID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Rides_UserProfiles_UserProfileID",
                table: "Rides",
                column: "UserProfileID",
                principalTable: "UserProfiles",
                principalColumn: "UserProfileID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Addresses_UserProfiles_UserProfileID",
                table: "Addresses");

            migrationBuilder.DropForeignKey(
                name: "FK_Cars_UserProfiles_UserProfileID",
                table: "Cars");

            migrationBuilder.DropForeignKey(
                name: "FK_Rides_UserProfiles_UserProfileID",
                table: "Rides");

            migrationBuilder.DropTable(
                name: "UserProfiles");

            migrationBuilder.DropColumn(
                name: "Test",
                table: "Rides");

            migrationBuilder.RenameColumn(
                name: "UserProfileID",
                table: "Rides",
                newName: "UserID");

            migrationBuilder.RenameIndex(
                name: "IX_Rides_UserProfileID",
                table: "Rides",
                newName: "IX_Rides_UserID");

            migrationBuilder.RenameColumn(
                name: "UserProfileID",
                table: "Cars",
                newName: "UserID");

            migrationBuilder.RenameIndex(
                name: "IX_Cars_UserProfileID",
                table: "Cars",
                newName: "IX_Cars_UserID");

            migrationBuilder.RenameColumn(
                name: "UserProfileID",
                table: "Addresses",
                newName: "UserID");

            migrationBuilder.RenameIndex(
                name: "IX_Addresses_UserProfileID",
                table: "Addresses",
                newName: "IX_Addresses_UserID");

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AuthID = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserID);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Addresses_Users_UserID",
                table: "Addresses",
                column: "UserID",
                principalTable: "Users",
                principalColumn: "UserID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Cars_Users_UserID",
                table: "Cars",
                column: "UserID",
                principalTable: "Users",
                principalColumn: "UserID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Rides_Users_UserID",
                table: "Rides",
                column: "UserID",
                principalTable: "Users",
                principalColumn: "UserID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
