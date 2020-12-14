using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApp.Migrations
{
    public partial class _20201214 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "fruit",
                columns: table => new
                {
                    fruitidx = table.Column<int>(type: "int(11)", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    name = table.Column<string>(type: "varchar(100)", nullable: true)
                        .Annotation("MySql:CharSet", "utf8")
                        .Annotation("MySql:Collation", "utf8_bin")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.fruitidx);
                });

            migrationBuilder.CreateTable(
                name: "goods",
                columns: table => new
                {
                    goodsidx = table.Column<int>(type: "int(11)", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    storeidx = table.Column<int>(type: "int(11)", nullable: false),
                    price = table.Column<int>(type: "int(11)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.goodsidx);
                });

            migrationBuilder.CreateTable(
                name: "order",
                columns: table => new
                {
                    orderidx = table.Column<int>(type: "int(11)", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    goodsidx = table.Column<int>(type: "int(11)", nullable: false),
                    orderdate = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.orderidx);
                });

            migrationBuilder.CreateTable(
                name: "store",
                columns: table => new
                {
                    storeidx = table.Column<int>(type: "int(11)", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    storename = table.Column<string>(type: "varchar(100)", nullable: true)
                        .Annotation("MySql:CharSet", "utf8")
                        .Annotation("MySql:Collation", "utf8_bin"),
                    delegatename = table.Column<string>(type: "varchar(50)", nullable: true)
                        .Annotation("MySql:CharSet", "utf8")
                        .Annotation("MySql:Collation", "utf8_bin")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.storeidx);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "fruit");

            migrationBuilder.DropTable(
                name: "goods");

            migrationBuilder.DropTable(
                name: "order");

            migrationBuilder.DropTable(
                name: "store");
        }
    }
}
