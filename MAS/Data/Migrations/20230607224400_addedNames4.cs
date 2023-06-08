using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MAS.Data.Migrations
{
    /// <inheritdoc />
    public partial class addedNames4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Serviceman_idPerson",
                table: "Job",
                newName: "idPerson");

            migrationBuilder.RenameIndex(
                name: "IX_Job_Serviceman_idPerson",
                table: "Job",
                newName: "IX_Job_idPerson");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "idPerson",
                table: "Job",
                newName: "Serviceman_idPerson");

            migrationBuilder.RenameIndex(
                name: "IX_Job_idPerson",
                table: "Job",
                newName: "IX_Job_Serviceman_idPerson");
        }
    }
}
