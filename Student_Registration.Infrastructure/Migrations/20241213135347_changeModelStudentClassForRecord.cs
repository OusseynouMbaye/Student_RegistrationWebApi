using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Student_Registration.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class changeModelStudentClassForRecord : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "phoneNum",
                table: "Students",
                newName: "PhoneNum");

            migrationBuilder.RenameColumn(
                name: "name",
                table: "Students",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "gender",
                table: "Students",
                newName: "Gender");

            migrationBuilder.RenameColumn(
                name: "age",
                table: "Students",
                newName: "Age");

            migrationBuilder.RenameColumn(
                name: "address",
                table: "Students",
                newName: "Address");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Students",
                type: "TEXT",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Age",
                table: "Students",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PhoneNum",
                table: "Students",
                newName: "phoneNum");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Students",
                newName: "name");

            migrationBuilder.RenameColumn(
                name: "Gender",
                table: "Students",
                newName: "gender");

            migrationBuilder.RenameColumn(
                name: "Age",
                table: "Students",
                newName: "age");

            migrationBuilder.RenameColumn(
                name: "Address",
                table: "Students",
                newName: "address");

            migrationBuilder.AlterColumn<string>(
                name: "name",
                table: "Students",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.AlterColumn<int>(
                name: "age",
                table: "Students",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);
        }
    }
}
