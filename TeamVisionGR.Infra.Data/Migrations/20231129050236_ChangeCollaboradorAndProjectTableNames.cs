using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TeamVisionGR.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class ChangeCollaboradorAndProjectTableNames : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CollaboratorProject_Collaborators_CollaboratorsId",
                table: "CollaboratorProject");

            migrationBuilder.DropForeignKey(
                name: "FK_CollaboratorProject_Projects_ProjectsId",
                table: "CollaboratorProject");

            migrationBuilder.DropForeignKey(
                name: "FK_UserActivations_Users_UserId",
                table: "UserActivations");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Users",
                table: "Users");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserActivations",
                table: "UserActivations");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Projects",
                table: "Projects");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Collaborators",
                table: "Collaborators");

            migrationBuilder.RenameTable(
                name: "Users",
                newName: "User");

            migrationBuilder.RenameTable(
                name: "UserActivations",
                newName: "UserActivation");

            migrationBuilder.RenameTable(
                name: "Projects",
                newName: "Project");

            migrationBuilder.RenameTable(
                name: "Collaborators",
                newName: "Collaborator");

            migrationBuilder.RenameIndex(
                name: "IX_UserActivations_UserId",
                table: "UserActivation",
                newName: "IX_UserActivation_UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_User",
                table: "User",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserActivation",
                table: "UserActivation",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Project",
                table: "Project",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Collaborator",
                table: "Collaborator",
                column: "Id");

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

            migrationBuilder.AddForeignKey(
                name: "FK_UserActivation_User_UserId",
                table: "UserActivation",
                column: "UserId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CollaboratorProject_Collaborator_CollaboratorsId",
                table: "CollaboratorProject");

            migrationBuilder.DropForeignKey(
                name: "FK_CollaboratorProject_Project_ProjectsId",
                table: "CollaboratorProject");

            migrationBuilder.DropForeignKey(
                name: "FK_UserActivation_User_UserId",
                table: "UserActivation");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserActivation",
                table: "UserActivation");

            migrationBuilder.DropPrimaryKey(
                name: "PK_User",
                table: "User");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Project",
                table: "Project");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Collaborator",
                table: "Collaborator");

            migrationBuilder.RenameTable(
                name: "UserActivation",
                newName: "UserActivations");

            migrationBuilder.RenameTable(
                name: "User",
                newName: "Users");

            migrationBuilder.RenameTable(
                name: "Project",
                newName: "Projects");

            migrationBuilder.RenameTable(
                name: "Collaborator",
                newName: "Collaborators");

            migrationBuilder.RenameIndex(
                name: "IX_UserActivation_UserId",
                table: "UserActivations",
                newName: "IX_UserActivations_UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserActivations",
                table: "UserActivations",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Users",
                table: "Users",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Projects",
                table: "Projects",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Collaborators",
                table: "Collaborators",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CollaboratorProject_Collaborators_CollaboratorsId",
                table: "CollaboratorProject",
                column: "CollaboratorsId",
                principalTable: "Collaborators",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CollaboratorProject_Projects_ProjectsId",
                table: "CollaboratorProject",
                column: "ProjectsId",
                principalTable: "Projects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserActivations_Users_UserId",
                table: "UserActivations",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
