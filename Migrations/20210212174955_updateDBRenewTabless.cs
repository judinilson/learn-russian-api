using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace learn_Russian_API.Migrations
{
    public partial class updateDBRenewTabless : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
           

            migrationBuilder.CreateTable(
                name: "DemonstrationContentses",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    title = table.Column<string>(nullable: true),
                    src = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DemonstrationContentses", x => x.Id);
                });

           

            migrationBuilder.CreateTable(
                name: "Contents",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    title = table.Column<string>(nullable: true),
                    subtitle = table.Column<string>(nullable: true),
                    coverImage = table.Column<string>(nullable: true),
                    DemonstrationContentID = table.Column<long>(nullable: false),
                    article = table.Column<string>(nullable: true),
                    categoryID = table.Column<long>(nullable: false),
                    isDemo = table.Column<bool>(nullable: false),
                    isArticle = table.Column<bool>(nullable: false),
                    author = table.Column<string>(nullable: true),
                    created = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contents", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Contents_DemonstrationContentses_DemonstrationContentID",
                        column: x => x.DemonstrationContentID,
                        principalTable: "DemonstrationContentses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Contents_Categories_categoryID",
                        column: x => x.categoryID,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

           
            migrationBuilder.CreateIndex(
                name: "IX_Contents_DemonstrationContentID",
                table: "Contents",
                column: "DemonstrationContentID");

            migrationBuilder.CreateIndex(
                name: "IX_Contents_categoryID",
                table: "Contents",
                column: "categoryID");

          
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
           
            migrationBuilder.DropTable(
                name: "Contents");

            
            migrationBuilder.DropTable(
                name: "DemonstrationContentses");

            
        }
    }
}
