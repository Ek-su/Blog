using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace KapasitematikBlog.Migrations
{
    public partial class mig1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ADMIN",
                columns: table => new
                {
                    AdminId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AdminAd = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    AdminSifre = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    AdminRole = table.Column<string>(maxLength: 1, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ADMIN", x => x.AdminId);
                });

            migrationBuilder.CreateTable(
                name: "KATEGORI",
                columns: table => new
                {
                    KategoriId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    KategoriAd = table.Column<string>(unicode: false, maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KATEGORI", x => x.KategoriId);
                });

            migrationBuilder.CreateTable(
                name: "KULLANICI",
                columns: table => new
                {
                    KullaniciId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    KullaniciAd = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    KullaniciSoyad = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    KullaniciName = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    KullaniciPassword = table.Column<string>(unicode: false, maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KULLANICI", x => x.KullaniciId);
                });

            migrationBuilder.CreateTable(
                name: "RESIM",
                columns: table => new
                {
                    ResimId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Resim = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RESIM", x => x.ResimId);
                });

            migrationBuilder.CreateTable(
                name: "MAKALE",
                columns: table => new
                {
                    MakaleId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    MakaleBaslik = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    MakaleAciklama = table.Column<string>(nullable: true),
                    MakaleKategoriId = table.Column<int>(nullable: true),
                    ResimUrl = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MAKALE", x => x.MakaleId);
                    table.ForeignKey(
                        name: "FK_MAKALE_KATEGORI1",
                        column: x => x.MakaleKategoriId,
                        principalTable: "KATEGORI",
                        principalColumn: "KategoriId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MAKALE_MakaleKategoriId",
                table: "MAKALE",
                column: "MakaleKategoriId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ADMIN");

            migrationBuilder.DropTable(
                name: "KULLANICI");

            migrationBuilder.DropTable(
                name: "MAKALE");

            migrationBuilder.DropTable(
                name: "RESIM");

            migrationBuilder.DropTable(
                name: "KATEGORI");
        }
    }
}
