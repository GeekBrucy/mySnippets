using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ef_core_with_mapper.Migrations
{
    public partial class add_is_deleted_field : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Chapters",
                type: "boolean",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Chapters");
        }
    }
}
