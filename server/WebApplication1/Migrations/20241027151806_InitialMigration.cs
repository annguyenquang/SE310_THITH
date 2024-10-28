using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace WebApplication1.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Accounts",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Role = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Accounts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Shoes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Brand = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<double>(type: "float", nullable: false),
                    Stock = table.Column<int>(type: "int", nullable: false),
                    PictureUrl = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Shoes", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Accounts",
                columns: new[] { "Id", "Password", "Role", "Username" },
                values: new object[,]
                {
                    { new Guid("6838e6e9-f72c-467d-8022-1e12cb3cfebc"), "admin", 0, "admin" },
                    { new Guid("a614ff89-c0a5-49fb-892e-a25bd0fce69f"), "user", 1, "user" }
                });

            migrationBuilder.InsertData(
                table: "Shoes",
                columns: new[] { "Id", "Brand", "Name", "PictureUrl", "Price", "Stock" },
                values: new object[,]
                {
                    { new Guid("1f86de8e-530d-4bb9-bd64-21706656fe4d"), "Converse", "Converse Chuck TaylorSwitf", "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcTDoUFSk5h4bCAyn-e_Pwe7C2wkBzfljFPW2g&s", 60.0, 3 },
                    { new Guid("386c6eaf-3850-427e-878c-ed6f366fa4e6"), "Adidas", "Adidas Superstar 2", "https://assets.adidas.com/images/w_600,f_auto,q_auto/e4a1154466e347f7a00856f0c7327afc_9366/SUPERSTAR_DJen_IH3121_01_standard.jpg", 80.0, 5 },
                    { new Guid("39195801-b78c-44cd-948a-008410dcff40"), "Converse", "Converse Chuck Taylor", "https://product.hstatic.net/1000382698/product/162050standard_0f83705012cb41c9930c876853344a92_master.jpg", 60.0, 3 },
                    { new Guid("bea35181-46df-49b9-b072-44f0783ceb0d"), "Adidas", "Adidas Superstar", "https://encrypted-tbn2.gstatic.com/shopping?q=tbn:ANd9GcQ5aPLZv9-TuQejBdX7xycecTrxMRl4azdF_u2ts1GQmbtale2hQxq9xmp8cqZ6p5ZzOmtsCuDOodQZjHud5ZufOJIbocinSSA6Ygt7GPjCTb3OFPvvOcdMpg&usqp=CAc", 80.0, 5 },
                    { new Guid("fb2d43ea-a13d-4abb-b769-9c5e8bec6fa7"), "Nike", "Nike Air Max 50", "https://kicksmaniac.com/zdjecia/2018/04/17/404/56/6867AA3824_001_4.png", 100.0, 10 },
                    { new Guid("fd4b3c6b-da25-4356-9b02-e110969eac37"), "Nike", "Nike Air Max 90", "https://static.nike.com/a/images/t_PDP_936_v1/f_auto,q_auto:eco/m55is6buar3k4isirw0k/AIR+MAX+90.png", 100.0, 10 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Accounts");

            migrationBuilder.DropTable(
                name: "Shoes");
        }
    }
}
