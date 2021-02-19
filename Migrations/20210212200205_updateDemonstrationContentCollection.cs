using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace learn_Russian_API.Migrations
{
    public partial class updateDemonstrationContentCollection : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "src",
                table: "DemonstrationContentses");

            migrationBuilder.DropColumn(
                name: "title",
                table: "DemonstrationContentses");

            migrationBuilder.CreateTable(
                name: "DemoContentsModel",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    title = table.Column<string>(type: "text", nullable: true),
                    src = table.Column<string>(type: "text", nullable: true),
                    DemonstrationContentsId = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DemoContentsModel", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DemoContentsModel_DemonstrationContentses_DemonstrationCont~",
                        column: x => x.DemonstrationContentsId,
                        principalTable: "DemonstrationContentses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DemoContentsModel_DemonstrationContentsId",
                table: "DemoContentsModel",
                column: "DemonstrationContentsId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DemoContentsModel");

            migrationBuilder.AddColumn<string>(
                name: "src",
                table: "DemonstrationContentses",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "title",
                table: "DemonstrationContentses",
                type: "text",
                nullable: true);
        }
    }
}
