using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication1.Migrations
{
    /// <inheritdoc />
    public partial class SeedUsers : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("""
INSERT INTO "Users" ("Id", "Username", "Email", "PasswordHash", "CreatedAt", "UpdatedAt")
VALUES
    ('11111111-1111-1111-1111-111111111111', 'admin', 'admin@example.com', 'PrP+ZrMeO00Q+nC1ytSccRIpSvauTkdqHEBRVdRaoSE=', now(), NULL),
    ('22222222-2222-2222-2222-222222222222', 'test', 'test@example.com', 'VN5/YG8lI8uo76wXP6tC+39Z1Wzv+XTI/bc0LPLP40U=', now(), NULL)
ON CONFLICT DO NOTHING;
""");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("""
DELETE FROM "Users"
WHERE "Id" IN ('11111111-1111-1111-1111-111111111111', '22222222-2222-2222-2222-222222222222');
""");
        }
    }
}
