using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebEnterpriseAPI.Migrations
{
    public partial class v2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "9cc213f6-10b4-4058-a252-fdf22d562ab6", "AQAAAAEAACcQAAAAEMiGpY1GYUG9/XVoanCQhHS7mMfHEM9jj85EgPgyKTgA07ELPMB4WfnWaUX+eto5Sg==", "8dc853e6-3ea0-467e-9eee-2e7c40accd52" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f847353d-7246-4f45-8bb4-9161e6e52a71", "AQAAAAEAACcQAAAAEEqgRCX8faEh/Xcs+0SIEY22NCGzC+vAJUCa4mBjqIMkqk2Q4Jb+slGNOTNq15NXBg==", "95f47eb2-24ce-43ba-8623-acf615913465" });
        }
    }
}
