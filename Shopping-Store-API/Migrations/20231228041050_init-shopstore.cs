using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ShoppingStoreAPI.Migrations
{
    /// <inheritdoc />
    public partial class initshopstore : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Product",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Price = table.Column<long>(type: "bigint", nullable: false),
                    PictureUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Brand = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    QuantityInStock = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValue: new DateTime(2023, 12, 28, 11, 10, 50, 352, DateTimeKind.Local).AddTicks(2916)),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false, defaultValue: "admin"),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    FullName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Address = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Birthday = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RoleClaims_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserClaims_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_UserLogins_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_UserRoles_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserRoles_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_UserTokens_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Product",
                columns: new[] { "Id", "Brand", "CreatedBy", "CreatedDate", "Description", "IsDeleted", "Name", "PictureUrl", "Price", "QuantityInStock", "Type", "UpdatedBy", "UpdatedDate" },
                values: new object[,]
                {
                    { 1, "Dell", "admin", new DateTime(2023, 12, 28, 11, 10, 50, 352, DateTimeKind.Local).AddTicks(3143), "Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Maecenas porttitor congue massa. Fusce posuere, magna sed pulvinar ultricies, purus lectus malesuada libero, sit amet commodo magna eros quis urna.", false, "Dell Latitude 7320", "/images/products/product-01.png", 20000L, 100, "Laptop", "admin", null },
                    { 2, "Dell", "admin", new DateTime(2023, 12, 28, 11, 10, 50, 352, DateTimeKind.Local).AddTicks(3147), "Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Maecenas porttitor congue massa. Fusce posuere, magna sed pulvinar ultricies, purus lectus malesuada libero, sit amet commodo magna eros quis urna.", false, "Dell Latitude 7330", "/images/products/product-02.png", 20000L, 100, "Laptop", "admin", null },
                    { 3, "Dell", "admin", new DateTime(2023, 12, 28, 11, 10, 50, 352, DateTimeKind.Local).AddTicks(3149), "Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Maecenas porttitor congue massa. Fusce posuere, magna sed pulvinar ultricies, purus lectus malesuada libero, sit amet commodo magna eros quis urna.", false, "Dell Inspiron 6430", "/images/products/product-03.png", 20000L, 100, "Laptop", "admin", null },
                    { 4, "Dell", "admin", new DateTime(2023, 12, 28, 11, 10, 50, 352, DateTimeKind.Local).AddTicks(3151), "Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Maecenas porttitor congue massa. Fusce posuere, magna sed pulvinar ultricies, purus lectus malesuada libero, sit amet commodo magna eros quis urna.", false, "Dell Inspiron 6530", "/images/products/product-04.png", 20000L, 100, "Laptop", "admin", null },
                    { 5, "Apple", "admin", new DateTime(2023, 12, 28, 11, 10, 50, 352, DateTimeKind.Local).AddTicks(3152), "Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Maecenas porttitor congue massa. Fusce posuere, magna sed pulvinar ultricies, purus lectus malesuada libero, sit amet commodo magna eros quis urna.", false, "Ipad M1 12.9", "/images/products/product-05.png", 20000L, 100, "Ipad", "admin", null },
                    { 6, "Apple", "admin", new DateTime(2023, 12, 28, 11, 10, 50, 352, DateTimeKind.Local).AddTicks(3155), "Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Maecenas porttitor congue massa. Fusce posuere, magna sed pulvinar ultricies, purus lectus malesuada libero, sit amet commodo magna eros quis urna.", false, "Ipad M1 12.9", "/images/products/product-06.png", 20000L, 100, "Ipad", "admin", null },
                    { 7, "Dell", "admin", new DateTime(2023, 12, 28, 11, 10, 50, 352, DateTimeKind.Local).AddTicks(3158), "Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Maecenas porttitor congue massa. Fusce posuere, magna sed pulvinar ultricies, purus lectus malesuada libero, sit amet commodo magna eros quis urna.", false, "Dell Screen 27inch", "/images/products/product-07.png", 20000L, 100, "Screen", "admin", null },
                    { 8, "Dell", "admin", new DateTime(2023, 12, 28, 11, 10, 50, 352, DateTimeKind.Local).AddTicks(3160), "Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Maecenas porttitor congue massa. Fusce posuere, magna sed pulvinar ultricies, purus lectus malesuada libero, sit amet commodo magna eros quis urna.", false, "Dell Screen 27inch", "/images/products/product-08.png", 20000L, 100, "Screen", "admin", null },
                    { 9, "Apple", "admin", new DateTime(2023, 12, 28, 11, 10, 50, 352, DateTimeKind.Local).AddTicks(3161), "Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Maecenas porttitor congue massa. Fusce posuere, magna sed pulvinar ultricies, purus lectus malesuada libero, sit amet commodo magna eros quis urna.", false, "Iphone 14 Pro Max", "/images/products/product-09.jpeg", 20000L, 100, "Iphone", "admin", null },
                    { 10, "Apple", "admin", new DateTime(2023, 12, 28, 11, 10, 50, 352, DateTimeKind.Local).AddTicks(3162), "Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Maecenas porttitor congue massa. Fusce posuere, magna sed pulvinar ultricies, purus lectus malesuada libero, sit amet commodo magna eros quis urna.", false, "Iphone 14 Pro Max", "/images/products/product-10.jpeg", 20000L, 100, "Iphone", "admin", null },
                    { 11, "Apple", "admin", new DateTime(2023, 12, 28, 11, 10, 50, 352, DateTimeKind.Local).AddTicks(3164), "Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Maecenas porttitor congue massa. Fusce posuere, magna sed pulvinar ultricies, purus lectus malesuada libero, sit amet commodo magna eros quis urna.", false, "Macbook Air M1", "/images/products/product-11.jpeg", 20000L, 100, "Macbook", "admin", null },
                    { 12, "Apple", "admin", new DateTime(2023, 12, 28, 11, 10, 50, 352, DateTimeKind.Local).AddTicks(3165), "Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Maecenas porttitor congue massa. Fusce posuere, magna sed pulvinar ultricies, purus lectus malesuada libero, sit amet commodo magna eros quis urna.", false, "Macbook Air M1", "/images/products/product-12.png", 20000L, 100, "Macbook", "admin", null },
                    { 13, "Gigabyte", "admin", new DateTime(2023, 12, 28, 11, 10, 50, 352, DateTimeKind.Local).AddTicks(3168), "Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Maecenas porttitor congue massa. Fusce posuere, magna sed pulvinar ultricies, purus lectus malesuada libero, sit amet commodo magna eros quis urna.", false, "Mainboard Gigabyte 6330", "/images/products/product-13.png", 20000L, 100, "Mainboard", "admin", null },
                    { 14, "Gigabyte", "admin", new DateTime(2023, 12, 28, 11, 10, 50, 352, DateTimeKind.Local).AddTicks(3169), "Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Maecenas porttitor congue massa. Fusce posuere, magna sed pulvinar ultricies, purus lectus malesuada libero, sit amet commodo magna eros quis urna.", false, "Mainboard Gigabyte 6330", "/images/products/product-14.png", 20000L, 100, "Mainboard", "admin", null },
                    { 15, "Corsair", "admin", new DateTime(2023, 12, 28, 11, 10, 50, 352, DateTimeKind.Local).AddTicks(3171), "Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Maecenas porttitor congue massa. Fusce posuere, magna sed pulvinar ultricies, purus lectus malesuada libero, sit amet commodo magna eros quis urna.", false, "Case Corsair", "/images/products/product-15.png", 20000L, 100, "Case", "admin", null },
                    { 16, "LG", "admin", new DateTime(2023, 12, 28, 11, 10, 50, 352, DateTimeKind.Local).AddTicks(3172), "Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Maecenas porttitor congue massa. Fusce posuere, magna sed pulvinar ultricies, purus lectus malesuada libero, sit amet commodo magna eros quis urna.", false, "LG Ultra Gear", "/images/products/product-16.png", 20000L, 100, "Screen", "admin", null },
                    { 17, "LG", "admin", new DateTime(2023, 12, 28, 11, 10, 50, 352, DateTimeKind.Local).AddTicks(3174), "Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Maecenas porttitor congue massa. Fusce posuere, magna sed pulvinar ultricies, purus lectus malesuada libero, sit amet commodo magna eros quis urna.", false, "LG Ultra Gear", "/images/products/product-17.png", 20000L, 100, "Screen", "admin", null },
                    { 18, "Asus", "admin", new DateTime(2023, 12, 28, 11, 10, 50, 352, DateTimeKind.Local).AddTicks(3176), "Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Maecenas porttitor congue massa. Fusce posuere, magna sed pulvinar ultricies, purus lectus malesuada libero, sit amet commodo magna eros quis urna.", false, "MSI 27", "/images/products/product-18.png", 20000L, 100, "Screen", "admin", null },
                    { 19, "Viewsonic", "admin", new DateTime(2023, 12, 28, 11, 10, 50, 352, DateTimeKind.Local).AddTicks(3177), "Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Maecenas porttitor congue massa. Fusce posuere, magna sed pulvinar ultricies, purus lectus malesuada libero, sit amet commodo magna eros quis urna.", false, "Viewsonic 24", "/images/products/product-19.png", 20000L, 100, "Screen", "admin", null },
                    { 20, "Acer", "admin", new DateTime(2023, 12, 28, 11, 10, 50, 352, DateTimeKind.Local).AddTicks(3179), "Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Maecenas porttitor congue massa. Fusce posuere, magna sed pulvinar ultricies, purus lectus malesuada libero, sit amet commodo magna eros quis urna.", false, "Acer 27", "/images/products/product-20.png", 20000L, 100, "Screen", "admin", null },
                    { 21, "Asus", "admin", new DateTime(2023, 12, 28, 11, 10, 50, 352, DateTimeKind.Local).AddTicks(3180), "Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Maecenas porttitor congue massa. Fusce posuere, magna sed pulvinar ultricies, purus lectus malesuada libero, sit amet commodo magna eros quis urna.", false, "Asus 27 Freesync", "/images/products/product-21.png", 20000L, 100, "Screen", "admin", null },
                    { 22, "Asus", "admin", new DateTime(2023, 12, 28, 11, 10, 50, 352, DateTimeKind.Local).AddTicks(3181), "Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Maecenas porttitor congue massa. Fusce posuere, magna sed pulvinar ultricies, purus lectus malesuada libero, sit amet commodo magna eros quis urna.", false, "Asus 24 Freesync", "/images/products/product-22.png", 20000L, 100, "Screen", "admin", null },
                    { 23, "Viewsonic", "admin", new DateTime(2023, 12, 28, 11, 10, 50, 352, DateTimeKind.Local).AddTicks(3183), "Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Maecenas porttitor congue massa. Fusce posuere, magna sed pulvinar ultricies, purus lectus malesuada libero, sit amet commodo magna eros quis urna.", false, "Viewsonic 24 Freesync", "/images/products/product-23.png", 20000L, 100, "Screen", "admin", null },
                    { 24, "Viewsonic", "admin", new DateTime(2023, 12, 28, 11, 10, 50, 352, DateTimeKind.Local).AddTicks(3185), "Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Maecenas porttitor congue massa. Fusce posuere, magna sed pulvinar ultricies, purus lectus malesuada libero, sit amet commodo magna eros quis urna.", false, "Viewsonic 24 Freesync 75Hz", "/images/products/product-24.png", 20000L, 100, "Screen", "admin", null },
                    { 25, "Asus", "admin", new DateTime(2023, 12, 28, 11, 10, 50, 352, DateTimeKind.Local).AddTicks(3186), "Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Maecenas porttitor congue massa. Fusce posuere, magna sed pulvinar ultricies, purus lectus malesuada libero, sit amet commodo magna eros quis urna.", false, "Asus TUF Gaming 24", "/images/products/product-25.png", 20000L, 100, "Screen", "admin", null },
                    { 26, "Gigabyte", "admin", new DateTime(2023, 12, 28, 11, 10, 50, 352, DateTimeKind.Local).AddTicks(3187), "Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Maecenas porttitor congue massa. Fusce posuere, magna sed pulvinar ultricies, purus lectus malesuada libero, sit amet commodo magna eros quis urna.", false, "Gigabyte 24", "/images/products/product-26.png", 20000L, 100, "Screen", "admin", null },
                    { 27, "Asus", "admin", new DateTime(2023, 12, 28, 11, 10, 50, 352, DateTimeKind.Local).AddTicks(3189), "Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Maecenas porttitor congue massa. Fusce posuere, magna sed pulvinar ultricies, purus lectus malesuada libero, sit amet commodo magna eros quis urna.", false, "Asus GM27", "/images/products/product-27.png", 20000L, 100, "Screen", "admin", null },
                    { 28, "Acer", "admin", new DateTime(2023, 12, 28, 11, 10, 50, 352, DateTimeKind.Local).AddTicks(3190), "Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Maecenas porttitor congue massa. Fusce posuere, magna sed pulvinar ultricies, purus lectus malesuada libero, sit amet commodo magna eros quis urna.", false, "Acer 75hz 27", "/images/products/product-28.png", 20000L, 100, "Screen", "admin", null },
                    { 29, "LG", "admin", new DateTime(2023, 12, 28, 11, 10, 50, 352, DateTimeKind.Local).AddTicks(3192), "Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Maecenas porttitor congue massa. Fusce posuere, magna sed pulvinar ultricies, purus lectus malesuada libero, sit amet commodo magna eros quis urna.", false, "LG 75hz 27", "/images/products/product-29.png", 20000L, 100, "Screen", "admin", null },
                    { 30, "Asus", "admin", new DateTime(2023, 12, 28, 11, 10, 50, 352, DateTimeKind.Local).AddTicks(3193), "Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Maecenas porttitor congue massa. Fusce posuere, magna sed pulvinar ultricies, purus lectus malesuada libero, sit amet commodo magna eros quis urna.", false, "Asus 100hz 27", "/images/products/product-30.png", 20000L, 100, "Screen", "admin", null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_RoleClaims_RoleId",
                table: "RoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "Roles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_UserClaims_UserId",
                table: "UserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserLogins_UserId",
                table: "UserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserRoles_RoleId",
                table: "UserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "Users",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "Users",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Product");

            migrationBuilder.DropTable(
                name: "RoleClaims");

            migrationBuilder.DropTable(
                name: "UserClaims");

            migrationBuilder.DropTable(
                name: "UserLogins");

            migrationBuilder.DropTable(
                name: "UserRoles");

            migrationBuilder.DropTable(
                name: "UserTokens");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
