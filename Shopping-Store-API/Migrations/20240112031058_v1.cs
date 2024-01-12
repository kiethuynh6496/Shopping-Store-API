using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ShoppingStoreAPI.Migrations
{
    /// <inheritdoc />
    public partial class v1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Brand",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValue: new DateTime(2024, 1, 12, 10, 10, 57, 921, DateTimeKind.Local).AddTicks(4654)),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false, defaultValue: "admin"),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Brand", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Category",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValue: new DateTime(2024, 1, 12, 10, 10, 57, 921, DateTimeKind.Local).AddTicks(5766)),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false, defaultValue: "admin"),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.Id);
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
                name: "Product",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Price = table.Column<long>(type: "bigint", nullable: false),
                    PictureUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    QuantityInStock = table.Column<int>(type: "int", nullable: false),
                    CategoryID = table.Column<int>(type: "int", nullable: false),
                    BrandID = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValue: new DateTime(2024, 1, 12, 10, 10, 57, 921, DateTimeKind.Local).AddTicks(533)),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false, defaultValue: "admin"),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Product_Brand_BrandID",
                        column: x => x.BrandID,
                        principalTable: "Brand",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Product_Category_CategoryID",
                        column: x => x.CategoryID,
                        principalTable: "Category",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
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
                table: "Brand",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "IsDeleted", "Name", "UpdatedBy", "UpdatedDate" },
                values: new object[,]
                {
                    { 1, "admin", new DateTime(2024, 1, 12, 10, 10, 57, 921, DateTimeKind.Local).AddTicks(4852), false, "Dell", "admin", null },
                    { 2, "admin", new DateTime(2024, 1, 12, 10, 10, 57, 921, DateTimeKind.Local).AddTicks(4856), false, "Apple", "admin", null },
                    { 3, "admin", new DateTime(2024, 1, 12, 10, 10, 57, 921, DateTimeKind.Local).AddTicks(4857), false, "Gigabyte", "admin", null },
                    { 4, "admin", new DateTime(2024, 1, 12, 10, 10, 57, 921, DateTimeKind.Local).AddTicks(4858), false, "Corsair", "admin", null },
                    { 5, "admin", new DateTime(2024, 1, 12, 10, 10, 57, 921, DateTimeKind.Local).AddTicks(4859), false, "LG", "admin", null },
                    { 6, "admin", new DateTime(2024, 1, 12, 10, 10, 57, 921, DateTimeKind.Local).AddTicks(4860), false, "Asus", "admin", null },
                    { 7, "admin", new DateTime(2024, 1, 12, 10, 10, 57, 921, DateTimeKind.Local).AddTicks(4861), false, "Viewsonic", "admin", null },
                    { 8, "admin", new DateTime(2024, 1, 12, 10, 10, 57, 921, DateTimeKind.Local).AddTicks(4863), false, "Acer", "admin", null }
                });

            migrationBuilder.InsertData(
                table: "Category",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "IsDeleted", "Name", "UpdatedBy", "UpdatedDate" },
                values: new object[,]
                {
                    { 1, "admin", new DateTime(2024, 1, 12, 10, 10, 57, 921, DateTimeKind.Local).AddTicks(5972), false, "Laptop", "admin", null },
                    { 2, "admin", new DateTime(2024, 1, 12, 10, 10, 57, 921, DateTimeKind.Local).AddTicks(5975), false, "Ipad", "admin", null },
                    { 3, "admin", new DateTime(2024, 1, 12, 10, 10, 57, 921, DateTimeKind.Local).AddTicks(5976), false, "Screen", "admin", null },
                    { 4, "admin", new DateTime(2024, 1, 12, 10, 10, 57, 921, DateTimeKind.Local).AddTicks(5977), false, "Iphone", "admin", null },
                    { 5, "admin", new DateTime(2024, 1, 12, 10, 10, 57, 921, DateTimeKind.Local).AddTicks(5979), false, "Macbook", "admin", null },
                    { 6, "admin", new DateTime(2024, 1, 12, 10, 10, 57, 921, DateTimeKind.Local).AddTicks(5980), false, "Mainboard", "admin", null },
                    { 7, "admin", new DateTime(2024, 1, 12, 10, 10, 57, 921, DateTimeKind.Local).AddTicks(5981), false, "Case", "admin", null }
                });

            migrationBuilder.InsertData(
                table: "Product",
                columns: new[] { "Id", "BrandID", "CategoryID", "CreatedBy", "CreatedDate", "Description", "IsDeleted", "Name", "PictureUrl", "Price", "QuantityInStock", "UpdatedBy", "UpdatedDate" },
                values: new object[,]
                {
                    { 1, 1, 1, "admin", new DateTime(2024, 1, 12, 10, 10, 57, 921, DateTimeKind.Local).AddTicks(3877), "Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Maecenas porttitor congue massa. Fusce posuere, magna sed pulvinar ultricies, purus lectus malesuada libero, sit amet commodo magna eros quis urna.", false, "Dell Latitude 7320", "/images/products/product-01.png", 20000L, 100, "admin", null },
                    { 2, 1, 1, "admin", new DateTime(2024, 1, 12, 10, 10, 57, 921, DateTimeKind.Local).AddTicks(3885), "Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Maecenas porttitor congue massa. Fusce posuere, magna sed pulvinar ultricies, purus lectus malesuada libero, sit amet commodo magna eros quis urna.", false, "Dell Latitude 7330", "/images/products/product-02.png", 20000L, 100, "admin", null },
                    { 3, 1, 1, "admin", new DateTime(2024, 1, 12, 10, 10, 57, 921, DateTimeKind.Local).AddTicks(3886), "Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Maecenas porttitor congue massa. Fusce posuere, magna sed pulvinar ultricies, purus lectus malesuada libero, sit amet commodo magna eros quis urna.", false, "Dell Inspiron 6430", "/images/products/product-03.png", 20000L, 100, "admin", null },
                    { 4, 1, 1, "admin", new DateTime(2024, 1, 12, 10, 10, 57, 921, DateTimeKind.Local).AddTicks(3888), "Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Maecenas porttitor congue massa. Fusce posuere, magna sed pulvinar ultricies, purus lectus malesuada libero, sit amet commodo magna eros quis urna.", false, "Dell Inspiron 6530", "/images/products/product-04.png", 20000L, 100, "admin", null },
                    { 5, 2, 2, "admin", new DateTime(2024, 1, 12, 10, 10, 57, 921, DateTimeKind.Local).AddTicks(3889), "Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Maecenas porttitor congue massa. Fusce posuere, magna sed pulvinar ultricies, purus lectus malesuada libero, sit amet commodo magna eros quis urna.", false, "Ipad M1 12.9", "/images/products/product-05.png", 20000L, 100, "admin", null },
                    { 6, 2, 2, "admin", new DateTime(2024, 1, 12, 10, 10, 57, 921, DateTimeKind.Local).AddTicks(3891), "Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Maecenas porttitor congue massa. Fusce posuere, magna sed pulvinar ultricies, purus lectus malesuada libero, sit amet commodo magna eros quis urna.", false, "Ipad M1 12.9", "/images/products/product-06.png", 20000L, 100, "admin", null },
                    { 7, 1, 3, "admin", new DateTime(2024, 1, 12, 10, 10, 57, 921, DateTimeKind.Local).AddTicks(3893), "Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Maecenas porttitor congue massa. Fusce posuere, magna sed pulvinar ultricies, purus lectus malesuada libero, sit amet commodo magna eros quis urna.", false, "Dell Screen 27inch", "/images/products/product-07.png", 20000L, 100, "admin", null },
                    { 8, 1, 3, "admin", new DateTime(2024, 1, 12, 10, 10, 57, 921, DateTimeKind.Local).AddTicks(3895), "Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Maecenas porttitor congue massa. Fusce posuere, magna sed pulvinar ultricies, purus lectus malesuada libero, sit amet commodo magna eros quis urna.", false, "Dell Screen 27inch", "/images/products/product-08.png", 20000L, 100, "admin", null },
                    { 9, 2, 4, "admin", new DateTime(2024, 1, 12, 10, 10, 57, 921, DateTimeKind.Local).AddTicks(3896), "Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Maecenas porttitor congue massa. Fusce posuere, magna sed pulvinar ultricies, purus lectus malesuada libero, sit amet commodo magna eros quis urna.", false, "Iphone 14 Pro Max", "/images/products/product-09.jpeg", 20000L, 100, "admin", null },
                    { 10, 2, 4, "admin", new DateTime(2024, 1, 12, 10, 10, 57, 921, DateTimeKind.Local).AddTicks(3897), "Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Maecenas porttitor congue massa. Fusce posuere, magna sed pulvinar ultricies, purus lectus malesuada libero, sit amet commodo magna eros quis urna.", false, "Iphone 14 Pro Max", "/images/products/product-10.jpeg", 20000L, 100, "admin", null },
                    { 11, 2, 5, "admin", new DateTime(2024, 1, 12, 10, 10, 57, 921, DateTimeKind.Local).AddTicks(3899), "Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Maecenas porttitor congue massa. Fusce posuere, magna sed pulvinar ultricies, purus lectus malesuada libero, sit amet commodo magna eros quis urna.", false, "Macbook Air M1", "/images/products/product-11.jpeg", 20000L, 100, "admin", null },
                    { 12, 2, 5, "admin", new DateTime(2024, 1, 12, 10, 10, 57, 921, DateTimeKind.Local).AddTicks(3900), "Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Maecenas porttitor congue massa. Fusce posuere, magna sed pulvinar ultricies, purus lectus malesuada libero, sit amet commodo magna eros quis urna.", false, "Macbook Air M1", "/images/products/product-12.png", 20000L, 100, "admin", null },
                    { 13, 3, 6, "admin", new DateTime(2024, 1, 12, 10, 10, 57, 921, DateTimeKind.Local).AddTicks(3901), "Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Maecenas porttitor congue massa. Fusce posuere, magna sed pulvinar ultricies, purus lectus malesuada libero, sit amet commodo magna eros quis urna.", false, "Mainboard Gigabyte 6330", "/images/products/product-13.png", 20000L, 100, "admin", null },
                    { 14, 3, 6, "admin", new DateTime(2024, 1, 12, 10, 10, 57, 921, DateTimeKind.Local).AddTicks(3903), "Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Maecenas porttitor congue massa. Fusce posuere, magna sed pulvinar ultricies, purus lectus malesuada libero, sit amet commodo magna eros quis urna.", false, "Mainboard Gigabyte 6330", "/images/products/product-14.png", 20000L, 100, "admin", null },
                    { 15, 4, 7, "admin", new DateTime(2024, 1, 12, 10, 10, 57, 921, DateTimeKind.Local).AddTicks(3904), "Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Maecenas porttitor congue massa. Fusce posuere, magna sed pulvinar ultricies, purus lectus malesuada libero, sit amet commodo magna eros quis urna.", false, "Case Corsair", "/images/products/product-15.png", 20000L, 100, "admin", null },
                    { 16, 5, 3, "admin", new DateTime(2024, 1, 12, 10, 10, 57, 921, DateTimeKind.Local).AddTicks(3906), "Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Maecenas porttitor congue massa. Fusce posuere, magna sed pulvinar ultricies, purus lectus malesuada libero, sit amet commodo magna eros quis urna.", false, "LG Ultra Gear", "/images/products/product-16.png", 20000L, 100, "admin", null },
                    { 17, 5, 3, "admin", new DateTime(2024, 1, 12, 10, 10, 57, 921, DateTimeKind.Local).AddTicks(3908), "Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Maecenas porttitor congue massa. Fusce posuere, magna sed pulvinar ultricies, purus lectus malesuada libero, sit amet commodo magna eros quis urna.", false, "LG Ultra Gear", "/images/products/product-17.png", 20000L, 100, "admin", null },
                    { 18, 6, 3, "admin", new DateTime(2024, 1, 12, 10, 10, 57, 921, DateTimeKind.Local).AddTicks(3909), "Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Maecenas porttitor congue massa. Fusce posuere, magna sed pulvinar ultricies, purus lectus malesuada libero, sit amet commodo magna eros quis urna.", false, "MSI 27", "/images/products/product-18.png", 20000L, 100, "admin", null },
                    { 19, 7, 3, "admin", new DateTime(2024, 1, 12, 10, 10, 57, 921, DateTimeKind.Local).AddTicks(3911), "Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Maecenas porttitor congue massa. Fusce posuere, magna sed pulvinar ultricies, purus lectus malesuada libero, sit amet commodo magna eros quis urna.", false, "Viewsonic 24", "/images/products/product-19.png", 20000L, 100, "admin", null },
                    { 20, 8, 3, "admin", new DateTime(2024, 1, 12, 10, 10, 57, 921, DateTimeKind.Local).AddTicks(3912), "Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Maecenas porttitor congue massa. Fusce posuere, magna sed pulvinar ultricies, purus lectus malesuada libero, sit amet commodo magna eros quis urna.", false, "Acer 27", "/images/products/product-20.png", 20000L, 100, "admin", null },
                    { 21, 6, 3, "admin", new DateTime(2024, 1, 12, 10, 10, 57, 921, DateTimeKind.Local).AddTicks(3913), "Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Maecenas porttitor congue massa. Fusce posuere, magna sed pulvinar ultricies, purus lectus malesuada libero, sit amet commodo magna eros quis urna.", false, "Asus 27 Freesync", "/images/products/product-21.png", 20000L, 100, "admin", null },
                    { 22, 6, 3, "admin", new DateTime(2024, 1, 12, 10, 10, 57, 921, DateTimeKind.Local).AddTicks(3915), "Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Maecenas porttitor congue massa. Fusce posuere, magna sed pulvinar ultricies, purus lectus malesuada libero, sit amet commodo magna eros quis urna.", false, "Asus 24 Freesync", "/images/products/product-22.png", 20000L, 100, "admin", null },
                    { 23, 7, 3, "admin", new DateTime(2024, 1, 12, 10, 10, 57, 921, DateTimeKind.Local).AddTicks(3916), "Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Maecenas porttitor congue massa. Fusce posuere, magna sed pulvinar ultricies, purus lectus malesuada libero, sit amet commodo magna eros quis urna.", false, "Viewsonic 24 Freesync", "/images/products/product-23.png", 20000L, 100, "admin", null },
                    { 24, 7, 3, "admin", new DateTime(2024, 1, 12, 10, 10, 57, 921, DateTimeKind.Local).AddTicks(3917), "Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Maecenas porttitor congue massa. Fusce posuere, magna sed pulvinar ultricies, purus lectus malesuada libero, sit amet commodo magna eros quis urna.", false, "Viewsonic 24 Freesync 75Hz", "/images/products/product-24.png", 20000L, 100, "admin", null },
                    { 25, 6, 3, "admin", new DateTime(2024, 1, 12, 10, 10, 57, 921, DateTimeKind.Local).AddTicks(3919), "Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Maecenas porttitor congue massa. Fusce posuere, magna sed pulvinar ultricies, purus lectus malesuada libero, sit amet commodo magna eros quis urna.", false, "Asus TUF Gaming 24", "/images/products/product-25.png", 20000L, 100, "admin", null },
                    { 26, 3, 3, "admin", new DateTime(2024, 1, 12, 10, 10, 57, 921, DateTimeKind.Local).AddTicks(3920), "Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Maecenas porttitor congue massa. Fusce posuere, magna sed pulvinar ultricies, purus lectus malesuada libero, sit amet commodo magna eros quis urna.", false, "Gigabyte 24", "/images/products/product-26.png", 20000L, 100, "admin", null },
                    { 27, 6, 3, "admin", new DateTime(2024, 1, 12, 10, 10, 57, 921, DateTimeKind.Local).AddTicks(3921), "Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Maecenas porttitor congue massa. Fusce posuere, magna sed pulvinar ultricies, purus lectus malesuada libero, sit amet commodo magna eros quis urna.", false, "Asus GM27", "/images/products/product-27.png", 20000L, 100, "admin", null },
                    { 28, 8, 3, "admin", new DateTime(2024, 1, 12, 10, 10, 57, 921, DateTimeKind.Local).AddTicks(3923), "Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Maecenas porttitor congue massa. Fusce posuere, magna sed pulvinar ultricies, purus lectus malesuada libero, sit amet commodo magna eros quis urna.", false, "Acer 75hz 27", "/images/products/product-28.png", 20000L, 100, "admin", null },
                    { 29, 5, 3, "admin", new DateTime(2024, 1, 12, 10, 10, 57, 921, DateTimeKind.Local).AddTicks(3924), "Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Maecenas porttitor congue massa. Fusce posuere, magna sed pulvinar ultricies, purus lectus malesuada libero, sit amet commodo magna eros quis urna.", false, "LG 75hz 27", "/images/products/product-29.png", 20000L, 100, "admin", null },
                    { 30, 6, 3, "admin", new DateTime(2024, 1, 12, 10, 10, 57, 921, DateTimeKind.Local).AddTicks(3926), "Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Maecenas porttitor congue massa. Fusce posuere, magna sed pulvinar ultricies, purus lectus malesuada libero, sit amet commodo magna eros quis urna.", false, "Asus 100hz 27", "/images/products/product-30.png", 20000L, 100, "admin", null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Product_BrandID",
                table: "Product",
                column: "BrandID");

            migrationBuilder.CreateIndex(
                name: "IX_Product_CategoryID",
                table: "Product",
                column: "CategoryID");

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
                name: "Brand");

            migrationBuilder.DropTable(
                name: "Category");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
