using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TeamVisionGR.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class FixCollaboratorProjectTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CollaboratorProject_Collaborator_CollaboratorsId",
                table: "CollaboratorProject");

            migrationBuilder.DropForeignKey(
                name: "FK_CollaboratorProject_Project_ProjectsId",
                table: "CollaboratorProject");

            migrationBuilder.RenameColumn(
                name: "ProjectsId",
                table: "CollaboratorProject",
                newName: "ProjectId");

            migrationBuilder.RenameColumn(
                name: "CollaboratorsId",
                table: "CollaboratorProject",
                newName: "CollaboratorId");

            migrationBuilder.RenameIndex(
                name: "IX_CollaboratorProject_ProjectsId",
                table: "CollaboratorProject",
                newName: "IX_CollaboratorProject_ProjectId");

            migrationBuilder.AlterColumn<string>(
                name: "Password",
                table: "User",
                type: "character varying(255)",
                maxLength: 255,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "LastName",
                table: "User",
                type: "character varying(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "FirstName",
                table: "User",
                type: "character varying(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "User",
                type: "character varying(62)",
                maxLength: 62,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<bool>(
                name: "Active",
                table: "User",
                type: "boolean",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "boolean");

            migrationBuilder.AddColumn<DateTime>(
                name: "EntryDate",
                table: "CollaboratorProject",
                type: "timestamp with time zone",
                nullable: false,
                defaultValueSql: "CURRENT_TIMESTAMP");

            migrationBuilder.AddColumn<DateTime>(
                name: "LeavingDate",
                table: "CollaboratorProject",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "Active",
                table: "Collaborator",
                type: "boolean",
                nullable: false,
                defaultValue: true,
                oldClrType: typeof(bool),
                oldType: "boolean");

            migrationBuilder.AddForeignKey(
                name: "FK_CollaboratorProject_Collaborator_CollaboratorId",
                table: "CollaboratorProject",
                column: "CollaboratorId",
                principalTable: "Collaborator",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CollaboratorProject_Project_ProjectId",
                table: "CollaboratorProject",
                column: "ProjectId",
                principalTable: "Project",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CollaboratorProject_Collaborator_CollaboratorId",
                table: "CollaboratorProject");

            migrationBuilder.DropForeignKey(
                name: "FK_CollaboratorProject_Project_ProjectId",
                table: "CollaboratorProject");

            migrationBuilder.DropColumn(
                name: "EntryDate",
                table: "CollaboratorProject");

            migrationBuilder.DropColumn(
                name: "LeavingDate",
                table: "CollaboratorProject");

            migrationBuilder.RenameColumn(
                name: "ProjectId",
                table: "CollaboratorProject",
                newName: "ProjectsId");

            migrationBuilder.RenameColumn(
                name: "CollaboratorId",
                table: "CollaboratorProject",
                newName: "CollaboratorsId");

            migrationBuilder.RenameIndex(
                name: "IX_CollaboratorProject_ProjectId",
                table: "CollaboratorProject",
                newName: "IX_CollaboratorProject_ProjectsId");

            migrationBuilder.AlterColumn<string>(
                name: "Password",
                table: "User",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(255)",
                oldMaxLength: 255);

            migrationBuilder.AlterColumn<string>(
                name: "LastName",
                table: "User",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "FirstName",
                table: "User",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "User",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(62)",
                oldMaxLength: 62);

            migrationBuilder.AlterColumn<bool>(
                name: "Active",
                table: "User",
                type: "boolean",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "boolean",
                oldDefaultValue: false);

            migrationBuilder.AlterColumn<bool>(
                name: "Active",
                table: "Collaborator",
                type: "boolean",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "boolean",
                oldDefaultValue: true);

            migrationBuilder.AddForeignKey(
                name: "FK_CollaboratorProject_Collaborator_CollaboratorsId",
                table: "CollaboratorProject",
                column: "CollaboratorsId",
                principalTable: "Collaborator",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CollaboratorProject_Project_ProjectsId",
                table: "CollaboratorProject",
                column: "ProjectsId",
                principalTable: "Project",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
