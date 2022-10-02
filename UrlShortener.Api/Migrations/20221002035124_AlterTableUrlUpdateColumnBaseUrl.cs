using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UrlShortener.Api.Migrations
{
    public partial class AlterTableUrlUpdateColumnBaseUrl : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "BaselUrl",
                table: "Url",
                newName: "BaseUrl");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "BaseUrl",
                table: "Url",
                newName: "BaselUrl");
        }
    }
}
