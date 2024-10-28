using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PeikkoDesigner.Migrations
{
    /// <inheritdoc />
    public partial class CompositeKeyForUserRoles : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_user_roles_Roles_role_id",
                table: "user_roles");

            migrationBuilder.DropForeignKey(
                name: "FK_user_roles_Users_user_id",
                table: "user_roles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_user_roles",
                table: "user_roles");

            migrationBuilder.DropIndex(
                name: "IX_user_roles_user_id",
                table: "user_roles");

            migrationBuilder.DropColumn(
                name: "RolesId",
                table: "user_roles");

            migrationBuilder.AddPrimaryKey(
                name: "PK_user_roles",
                table: "user_roles",
                columns: new[] { "user_id", "role_id" });

            migrationBuilder.AddForeignKey(
                name: "FK_UserRoles_RoleId",
                table: "user_roles",
                column: "role_id",
                principalTable: "Roles",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserRoles_UserId",
                table: "user_roles",
                column: "user_id",
                principalTable: "Users",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserRoles_RoleId",
                table: "user_roles");

            migrationBuilder.DropForeignKey(
                name: "FK_UserRoles_UserId",
                table: "user_roles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_user_roles",
                table: "user_roles");

            migrationBuilder.AddColumn<int>(
                name: "RolesId",
                table: "user_roles",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_user_roles",
                table: "user_roles",
                columns: new[] { "RolesId", "user_id" });

            migrationBuilder.CreateIndex(
                name: "IX_user_roles_user_id",
                table: "user_roles",
                column: "user_id");

            migrationBuilder.AddForeignKey(
                name: "FK_user_roles_Roles_role_id",
                table: "user_roles",
                column: "role_id",
                principalTable: "Roles",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_user_roles_Users_user_id",
                table: "user_roles",
                column: "user_id",
                principalTable: "Users",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
