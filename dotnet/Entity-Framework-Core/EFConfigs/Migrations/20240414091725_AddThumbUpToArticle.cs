using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EFConfigs.Migrations
{
    /// <inheritdoc />
    public partial class AddThumbUpToArticle : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "ThumbUp",
                table: "Articles",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ThumbUp",
                table: "Articles");
        }
    }
}
