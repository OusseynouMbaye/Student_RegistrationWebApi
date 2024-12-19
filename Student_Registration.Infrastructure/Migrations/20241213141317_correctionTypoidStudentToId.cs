using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Student_Registration.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class correctionTypoidStudentToId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "id",
                table: "Students",
                newName: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Students",
                newName: "id");
        }
    }
}
