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
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValue: new DateTime(2024, 2, 2, 14, 42, 55, 506, DateTimeKind.Local).AddTicks(7789)),
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
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValue: new DateTime(2024, 2, 2, 14, 42, 55, 506, DateTimeKind.Local).AddTicks(8715)),
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
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValue: new DateTime(2024, 2, 2, 14, 42, 55, 506, DateTimeKind.Local).AddTicks(2780)),
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
                name: "ShoppingCart",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValue: new DateTime(2024, 2, 2, 14, 42, 55, 505, DateTimeKind.Local).AddTicks(6399)),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false, defaultValue: "admin"),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShoppingCart", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ShoppingCart_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Token",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    IPAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserAgent = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RefreshToken = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ExpiresAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValue: new DateTime(2024, 2, 2, 14, 42, 55, 506, DateTimeKind.Local).AddTicks(9678)),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false, defaultValue: "admin"),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Token", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Token_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
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

            migrationBuilder.CreateTable(
                name: "ShoppingCartItem",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ShoppingCartID = table.Column<int>(type: "int", nullable: false),
                    ItemId = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValue: new DateTime(2024, 2, 2, 14, 42, 55, 505, DateTimeKind.Local).AddTicks(7475)),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false, defaultValue: "admin"),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShoppingCartItem", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ShoppingCartItem_Product_ItemId",
                        column: x => x.ItemId,
                        principalTable: "Product",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ShoppingCartItem_ShoppingCart_ShoppingCartID",
                        column: x => x.ShoppingCartID,
                        principalTable: "ShoppingCart",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Brand",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "IsDeleted", "Name", "UpdatedBy", "UpdatedDate" },
                values: new object[,]
                {
                    { 1, "admin", new DateTime(2024, 2, 2, 14, 42, 55, 506, DateTimeKind.Local).AddTicks(8012), false, "Dell", "admin", null },
                    { 2, "admin", new DateTime(2024, 2, 2, 14, 42, 55, 506, DateTimeKind.Local).AddTicks(8015), false, "Apple", "admin", null },
                    { 3, "admin", new DateTime(2024, 2, 2, 14, 42, 55, 506, DateTimeKind.Local).AddTicks(8017), false, "Gigabyte", "admin", null },
                    { 4, "admin", new DateTime(2024, 2, 2, 14, 42, 55, 506, DateTimeKind.Local).AddTicks(8019), false, "Corsair", "admin", null },
                    { 5, "admin", new DateTime(2024, 2, 2, 14, 42, 55, 506, DateTimeKind.Local).AddTicks(8021), false, "LG", "admin", null },
                    { 6, "admin", new DateTime(2024, 2, 2, 14, 42, 55, 506, DateTimeKind.Local).AddTicks(8022), false, "Asus", "admin", null },
                    { 7, "admin", new DateTime(2024, 2, 2, 14, 42, 55, 506, DateTimeKind.Local).AddTicks(8024), false, "Viewsonic", "admin", null },
                    { 8, "admin", new DateTime(2024, 2, 2, 14, 42, 55, 506, DateTimeKind.Local).AddTicks(8026), false, "Acer", "admin", null }
                });

            migrationBuilder.InsertData(
                table: "Category",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "IsDeleted", "Name", "UpdatedBy", "UpdatedDate" },
                values: new object[,]
                {
                    { 1, "admin", new DateTime(2024, 2, 2, 14, 42, 55, 506, DateTimeKind.Local).AddTicks(8932), false, "Laptop", "admin", null },
                    { 2, "admin", new DateTime(2024, 2, 2, 14, 42, 55, 506, DateTimeKind.Local).AddTicks(8936), false, "Ipad", "admin", null },
                    { 3, "admin", new DateTime(2024, 2, 2, 14, 42, 55, 506, DateTimeKind.Local).AddTicks(8946), false, "Screen", "admin", null },
                    { 4, "admin", new DateTime(2024, 2, 2, 14, 42, 55, 506, DateTimeKind.Local).AddTicks(8948), false, "Iphone", "admin", null },
                    { 5, "admin", new DateTime(2024, 2, 2, 14, 42, 55, 506, DateTimeKind.Local).AddTicks(8950), false, "Macbook", "admin", null },
                    { 6, "admin", new DateTime(2024, 2, 2, 14, 42, 55, 506, DateTimeKind.Local).AddTicks(8952), false, "Mainboard", "admin", null },
                    { 7, "admin", new DateTime(2024, 2, 2, 14, 42, 55, 506, DateTimeKind.Local).AddTicks(8954), false, "Case", "admin", null }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "44bc1c18-51a6-46b0-8e20-0df40a2ae0b9", "a34f3ee0-0520-4f86-aac0-3e0d01f94245", "Admin", "ADMIN" },
                    { "4d267d01-3ce5-44d4-bf99-a3fd2172ba17", "4b401338-a118-4dc4-85cb-4cf5bc246b2b", "User", "USER" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AccessFailedCount", "Address", "Birthday", "ConcurrencyStamp", "Email", "EmailConfirmed", "FullName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "94a12a30-1a9b-48ad-950d-29f80865003d", 0, "TP Ho Chi Minh", null, "22e3687d-352f-476a-9e0d-3c37cf143ce4", null, false, "mangoc", false, null, null, null, null, null, false, "b70d16cf-ad04-424c-af22-297a487bb207", false, null },
                    { "d68dcb5f-2706-4cb5-bb0b-37bf39400420", 0, "TP Ho Chi Minh", null, "8a305987-9fbb-4ec6-8c9c-c81ebf2a1e30", null, false, "kiethuynh", false, null, null, null, null, null, false, "79c557f9-506f-4c88-a853-4cb9e9077010", false, null },
                    { "f222bfbf-86bf-4b65-9958-bc818ba5f822", 0, "TP Ho Chi Minh", null, "448c21e0-7c53-4ba6-b552-941b7251b6fa", null, false, "auduongphong", false, null, null, null, null, null, false, "2b37d29c-e4dc-40b0-8c2a-576eda53c13d", false, null }
                });

            migrationBuilder.InsertData(
                table: "Product",
                columns: new[] { "Id", "BrandID", "CategoryID", "CreatedBy", "CreatedDate", "Description", "IsDeleted", "Name", "PictureUrl", "Price", "QuantityInStock", "UpdatedBy", "UpdatedDate" },
                values: new object[,]
                {
                    { 1, 1, 1, "admin", new DateTime(2024, 2, 2, 14, 42, 55, 506, DateTimeKind.Local).AddTicks(6720), "Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Maecenas porttitor congue massa. Fusce posuere, magna sed pulvinar ultricies, purus lectus malesuada libero, sit amet commodo magna eros quis urna.", false, "Dell Latitude 7320", "/images/products/product-01.png", 1000L, 100, "admin", null },
                    { 2, 1, 1, "admin", new DateTime(2024, 2, 2, 14, 42, 55, 506, DateTimeKind.Local).AddTicks(6728), "Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Maecenas porttitor congue massa. Fusce posuere, magna sed pulvinar ultricies, purus lectus malesuada libero, sit amet commodo magna eros quis urna.", false, "Dell Latitude 7330", "/images/products/product-02.png", 2000L, 100, "admin", null },
                    { 3, 1, 1, "admin", new DateTime(2024, 2, 2, 14, 42, 55, 506, DateTimeKind.Local).AddTicks(6730), "Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Maecenas porttitor congue massa. Fusce posuere, magna sed pulvinar ultricies, purus lectus malesuada libero, sit amet commodo magna eros quis urna.", false, "Dell Inspiron 6430", "/images/products/product-03.png", 3000L, 100, "admin", null },
                    { 4, 1, 1, "admin", new DateTime(2024, 2, 2, 14, 42, 55, 506, DateTimeKind.Local).AddTicks(6732), "Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Maecenas porttitor congue massa. Fusce posuere, magna sed pulvinar ultricies, purus lectus malesuada libero, sit amet commodo magna eros quis urna.", false, "Dell Inspiron 6530", "/images/products/product-04.png", 4000L, 100, "admin", null },
                    { 5, 2, 2, "admin", new DateTime(2024, 2, 2, 14, 42, 55, 506, DateTimeKind.Local).AddTicks(6734), "Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Maecenas porttitor congue massa. Fusce posuere, magna sed pulvinar ultricies, purus lectus malesuada libero, sit amet commodo magna eros quis urna.", false, "Ipad M1 12.9", "/images/products/product-05.png", 5000L, 100, "admin", null },
                    { 6, 2, 2, "admin", new DateTime(2024, 2, 2, 14, 42, 55, 506, DateTimeKind.Local).AddTicks(6737), "Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Maecenas porttitor congue massa. Fusce posuere, magna sed pulvinar ultricies, purus lectus malesuada libero, sit amet commodo magna eros quis urna.", false, "Ipad M1 12.9", "/images/products/product-06.png", 6000L, 100, "admin", null },
                    { 7, 1, 3, "admin", new DateTime(2024, 2, 2, 14, 42, 55, 506, DateTimeKind.Local).AddTicks(6739), "Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Maecenas porttitor congue massa. Fusce posuere, magna sed pulvinar ultricies, purus lectus malesuada libero, sit amet commodo magna eros quis urna.", false, "Dell Screen 27inch", "/images/products/product-07.png", 7000L, 100, "admin", null },
                    { 8, 1, 3, "admin", new DateTime(2024, 2, 2, 14, 42, 55, 506, DateTimeKind.Local).AddTicks(6741), "Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Maecenas porttitor congue massa. Fusce posuere, magna sed pulvinar ultricies, purus lectus malesuada libero, sit amet commodo magna eros quis urna.", false, "Dell Screen 27inch", "/images/products/product-08.png", 8000L, 100, "admin", null },
                    { 9, 2, 4, "admin", new DateTime(2024, 2, 2, 14, 42, 55, 506, DateTimeKind.Local).AddTicks(6743), "Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Maecenas porttitor congue massa. Fusce posuere, magna sed pulvinar ultricies, purus lectus malesuada libero, sit amet commodo magna eros quis urna.", false, "Iphone 14 Pro Max", "/images/products/product-09.jpeg", 9000L, 100, "admin", null },
                    { 10, 2, 4, "admin", new DateTime(2024, 2, 2, 14, 42, 55, 506, DateTimeKind.Local).AddTicks(6745), "Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Maecenas porttitor congue massa. Fusce posuere, magna sed pulvinar ultricies, purus lectus malesuada libero, sit amet commodo magna eros quis urna.", false, "Iphone 14 Pro Max", "/images/products/product-10.jpeg", 10000L, 100, "admin", null },
                    { 11, 2, 5, "admin", new DateTime(2024, 2, 2, 14, 42, 55, 506, DateTimeKind.Local).AddTicks(6747), "Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Maecenas porttitor congue massa. Fusce posuere, magna sed pulvinar ultricies, purus lectus malesuada libero, sit amet commodo magna eros quis urna.", false, "Macbook Air M1", "/images/products/product-11.jpeg", 11000L, 100, "admin", null },
                    { 12, 2, 5, "admin", new DateTime(2024, 2, 2, 14, 42, 55, 506, DateTimeKind.Local).AddTicks(6749), "Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Maecenas porttitor congue massa. Fusce posuere, magna sed pulvinar ultricies, purus lectus malesuada libero, sit amet commodo magna eros quis urna.", false, "Macbook Air M1", "/images/products/product-12.png", 12000L, 100, "admin", null },
                    { 13, 3, 6, "admin", new DateTime(2024, 2, 2, 14, 42, 55, 506, DateTimeKind.Local).AddTicks(6751), "Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Maecenas porttitor congue massa. Fusce posuere, magna sed pulvinar ultricies, purus lectus malesuada libero, sit amet commodo magna eros quis urna.", false, "Mainboard Gigabyte 6330", "/images/products/product-13.png", 13000L, 100, "admin", null },
                    { 14, 3, 6, "admin", new DateTime(2024, 2, 2, 14, 42, 55, 506, DateTimeKind.Local).AddTicks(6753), "Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Maecenas porttitor congue massa. Fusce posuere, magna sed pulvinar ultricies, purus lectus malesuada libero, sit amet commodo magna eros quis urna.", false, "Mainboard Gigabyte 6330", "/images/products/product-14.png", 14000L, 100, "admin", null },
                    { 15, 4, 7, "admin", new DateTime(2024, 2, 2, 14, 42, 55, 506, DateTimeKind.Local).AddTicks(6755), "Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Maecenas porttitor congue massa. Fusce posuere, magna sed pulvinar ultricies, purus lectus malesuada libero, sit amet commodo magna eros quis urna.", false, "Case Corsair", "/images/products/product-15.png", 15000L, 100, "admin", null },
                    { 16, 5, 3, "admin", new DateTime(2024, 2, 2, 14, 42, 55, 506, DateTimeKind.Local).AddTicks(6757), "Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Maecenas porttitor congue massa. Fusce posuere, magna sed pulvinar ultricies, purus lectus malesuada libero, sit amet commodo magna eros quis urna.", false, "LG Ultra Gear", "/images/products/product-16.png", 16000L, 100, "admin", null },
                    { 17, 5, 3, "admin", new DateTime(2024, 2, 2, 14, 42, 55, 506, DateTimeKind.Local).AddTicks(6761), "Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Maecenas porttitor congue massa. Fusce posuere, magna sed pulvinar ultricies, purus lectus malesuada libero, sit amet commodo magna eros quis urna.", false, "LG Ultra Gear", "/images/products/product-17.png", 17000L, 100, "admin", null },
                    { 18, 6, 3, "admin", new DateTime(2024, 2, 2, 14, 42, 55, 506, DateTimeKind.Local).AddTicks(6763), "Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Maecenas porttitor congue massa. Fusce posuere, magna sed pulvinar ultricies, purus lectus malesuada libero, sit amet commodo magna eros quis urna.", false, "MSI 27", "/images/products/product-18.png", 18000L, 100, "admin", null },
                    { 19, 7, 3, "admin", new DateTime(2024, 2, 2, 14, 42, 55, 506, DateTimeKind.Local).AddTicks(6764), "Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Maecenas porttitor congue massa. Fusce posuere, magna sed pulvinar ultricies, purus lectus malesuada libero, sit amet commodo magna eros quis urna.", false, "Viewsonic 24", "/images/products/product-19.png", 19000L, 100, "admin", null },
                    { 20, 8, 3, "admin", new DateTime(2024, 2, 2, 14, 42, 55, 506, DateTimeKind.Local).AddTicks(6766), "Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Maecenas porttitor congue massa. Fusce posuere, magna sed pulvinar ultricies, purus lectus malesuada libero, sit amet commodo magna eros quis urna.", false, "Acer 27", "/images/products/product-20.png", 10000L, 100, "admin", null },
                    { 21, 6, 3, "admin", new DateTime(2024, 2, 2, 14, 42, 55, 506, DateTimeKind.Local).AddTicks(6768), "Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Maecenas porttitor congue massa. Fusce posuere, magna sed pulvinar ultricies, purus lectus malesuada libero, sit amet commodo magna eros quis urna.", false, "Asus 27 Freesync", "/images/products/product-21.png", 21000L, 100, "admin", null },
                    { 22, 6, 3, "admin", new DateTime(2024, 2, 2, 14, 42, 55, 506, DateTimeKind.Local).AddTicks(6770), "Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Maecenas porttitor congue massa. Fusce posuere, magna sed pulvinar ultricies, purus lectus malesuada libero, sit amet commodo magna eros quis urna.", false, "Asus 24 Freesync", "/images/products/product-22.png", 22000L, 100, "admin", null },
                    { 23, 7, 3, "admin", new DateTime(2024, 2, 2, 14, 42, 55, 506, DateTimeKind.Local).AddTicks(6772), "Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Maecenas porttitor congue massa. Fusce posuere, magna sed pulvinar ultricies, purus lectus malesuada libero, sit amet commodo magna eros quis urna.", false, "Viewsonic 24 Freesync", "/images/products/product-23.png", 23000L, 100, "admin", null },
                    { 24, 7, 3, "admin", new DateTime(2024, 2, 2, 14, 42, 55, 506, DateTimeKind.Local).AddTicks(6774), "Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Maecenas porttitor congue massa. Fusce posuere, magna sed pulvinar ultricies, purus lectus malesuada libero, sit amet commodo magna eros quis urna.", false, "Viewsonic 24 Freesync 75Hz", "/images/products/product-24.png", 24000L, 100, "admin", null },
                    { 25, 6, 3, "admin", new DateTime(2024, 2, 2, 14, 42, 55, 506, DateTimeKind.Local).AddTicks(6776), "Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Maecenas porttitor congue massa. Fusce posuere, magna sed pulvinar ultricies, purus lectus malesuada libero, sit amet commodo magna eros quis urna.", false, "Asus TUF Gaming 24", "/images/products/product-25.png", 25000L, 100, "admin", null },
                    { 26, 3, 3, "admin", new DateTime(2024, 2, 2, 14, 42, 55, 506, DateTimeKind.Local).AddTicks(6778), "Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Maecenas porttitor congue massa. Fusce posuere, magna sed pulvinar ultricies, purus lectus malesuada libero, sit amet commodo magna eros quis urna.", false, "Gigabyte 24", "/images/products/product-26.png", 26000L, 100, "admin", null },
                    { 27, 6, 3, "admin", new DateTime(2024, 2, 2, 14, 42, 55, 506, DateTimeKind.Local).AddTicks(6780), "Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Maecenas porttitor congue massa. Fusce posuere, magna sed pulvinar ultricies, purus lectus malesuada libero, sit amet commodo magna eros quis urna.", false, "Asus GM27", "/images/products/product-27.png", 27000L, 100, "admin", null },
                    { 28, 8, 3, "admin", new DateTime(2024, 2, 2, 14, 42, 55, 506, DateTimeKind.Local).AddTicks(6782), "Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Maecenas porttitor congue massa. Fusce posuere, magna sed pulvinar ultricies, purus lectus malesuada libero, sit amet commodo magna eros quis urna.", false, "Acer 75hz 27", "/images/products/product-28.png", 28000L, 100, "admin", null },
                    { 29, 5, 3, "admin", new DateTime(2024, 2, 2, 14, 42, 55, 506, DateTimeKind.Local).AddTicks(6784), "Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Maecenas porttitor congue massa. Fusce posuere, magna sed pulvinar ultricies, purus lectus malesuada libero, sit amet commodo magna eros quis urna.", false, "LG 75hz 27", "/images/products/product-29.png", 29000L, 100, "admin", null },
                    { 30, 6, 3, "admin", new DateTime(2024, 2, 2, 14, 42, 55, 506, DateTimeKind.Local).AddTicks(6786), "Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Maecenas porttitor congue massa. Fusce posuere, magna sed pulvinar ultricies, purus lectus malesuada libero, sit amet commodo magna eros quis urna.", false, "Asus 100hz 27", "/images/products/product-30.png", 30000L, 100, "admin", null }
                });

            migrationBuilder.InsertData(
                table: "RoleClaims",
                columns: new[] { "Id", "ClaimType", "ClaimValue", "RoleId" },
                values: new object[,]
                {
                    { 1, "Permission", "CanManageUsers", "44bc1c18-51a6-46b0-8e20-0df40a2ae0b9" },
                    { 2, "Permission", "CanManageProducts", "44bc1c18-51a6-46b0-8e20-0df40a2ae0b9" },
                    { 3, "Permission", "CanViewProducts", "4d267d01-3ce5-44d4-bf99-a3fd2172ba17" }
                });

            migrationBuilder.InsertData(
                table: "ShoppingCart",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "IsDeleted", "UpdatedBy", "UpdatedDate", "UserId" },
                values: new object[,]
                {
                    { 1, "admin", new DateTime(2024, 2, 2, 14, 42, 55, 505, DateTimeKind.Local).AddTicks(6688), false, "admin", null, "d68dcb5f-2706-4cb5-bb0b-37bf39400420" },
                    { 2, "admin", new DateTime(2024, 2, 2, 14, 42, 55, 505, DateTimeKind.Local).AddTicks(6693), false, "admin", null, "94a12a30-1a9b-48ad-950d-29f80865003d" },
                    { 3, "admin", new DateTime(2024, 2, 2, 14, 42, 55, 505, DateTimeKind.Local).AddTicks(6695), false, "admin", null, "f222bfbf-86bf-4b65-9958-bc818ba5f822" }
                });

            migrationBuilder.InsertData(
                table: "Token",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "ExpiresAt", "IPAddress", "IsDeleted", "RefreshToken", "UpdatedBy", "UpdatedDate", "UserAgent", "UserId" },
                values: new object[,]
                {
                    { 1, "admin", new DateTime(2024, 2, 2, 14, 42, 55, 507, DateTimeKind.Local).AddTicks(1604), new DateTime(2024, 2, 2, 14, 42, 55, 507, DateTimeKind.Local).AddTicks(1597), "192.168.0.1", false, "", "admin", null, "Chrome/91.0.4472.124", "d68dcb5f-2706-4cb5-bb0b-37bf39400420" },
                    { 2, "admin", new DateTime(2024, 2, 2, 14, 42, 55, 507, DateTimeKind.Local).AddTicks(1608), new DateTime(2024, 2, 2, 14, 42, 55, 507, DateTimeKind.Local).AddTicks(1608), "192.168.0.2", false, "", "admin", null, "Mozilla/5.0 (Windows NT 10.0; Win64; x64)", "d68dcb5f-2706-4cb5-bb0b-37bf39400420" },
                    { 3, "admin", new DateTime(2024, 2, 2, 14, 42, 55, 507, DateTimeKind.Local).AddTicks(1611), new DateTime(2024, 2, 2, 14, 42, 55, 507, DateTimeKind.Local).AddTicks(1611), "192.168.0.3", false, "", "admin", null, "Safari/537.36", "94a12a30-1a9b-48ad-950d-29f80865003d" }
                });

            migrationBuilder.InsertData(
                table: "UserClaims",
                columns: new[] { "Id", "ClaimType", "ClaimValue", "UserId" },
                values: new object[,]
                {
                    { 1, "Country", "VN", "d68dcb5f-2706-4cb5-bb0b-37bf39400420" },
                    { 2, "Country", "VN", "94a12a30-1a9b-48ad-950d-29f80865003d" },
                    { 3, "Country", "USA", "f222bfbf-86bf-4b65-9958-bc818ba5f822" }
                });

            migrationBuilder.InsertData(
                table: "UserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "4d267d01-3ce5-44d4-bf99-a3fd2172ba17", "94a12a30-1a9b-48ad-950d-29f80865003d" },
                    { "44bc1c18-51a6-46b0-8e20-0df40a2ae0b9", "d68dcb5f-2706-4cb5-bb0b-37bf39400420" },
                    { "4d267d01-3ce5-44d4-bf99-a3fd2172ba17", "d68dcb5f-2706-4cb5-bb0b-37bf39400420" },
                    { "4d267d01-3ce5-44d4-bf99-a3fd2172ba17", "f222bfbf-86bf-4b65-9958-bc818ba5f822" }
                });

            migrationBuilder.InsertData(
                table: "ShoppingCartItem",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "IsDeleted", "ItemId", "Quantity", "ShoppingCartID", "UpdatedBy", "UpdatedDate" },
                values: new object[,]
                {
                    { 1, "admin", new DateTime(2024, 2, 2, 14, 42, 55, 506, DateTimeKind.Local).AddTicks(1197), false, 1, 3, 1, "admin", null },
                    { 2, "admin", new DateTime(2024, 2, 2, 14, 42, 55, 506, DateTimeKind.Local).AddTicks(1203), false, 2, 3, 1, "admin", null },
                    { 3, "admin", new DateTime(2024, 2, 2, 14, 42, 55, 506, DateTimeKind.Local).AddTicks(1205), false, 3, 3, 1, "admin", null },
                    { 4, "admin", new DateTime(2024, 2, 2, 14, 42, 55, 506, DateTimeKind.Local).AddTicks(1207), false, 1, 3, 2, "admin", null },
                    { 5, "admin", new DateTime(2024, 2, 2, 14, 42, 55, 506, DateTimeKind.Local).AddTicks(1209), false, 2, 3, 2, "admin", null },
                    { 6, "admin", new DateTime(2024, 2, 2, 14, 42, 55, 506, DateTimeKind.Local).AddTicks(1211), false, 3, 3, 2, "admin", null },
                    { 7, "admin", new DateTime(2024, 2, 2, 14, 42, 55, 506, DateTimeKind.Local).AddTicks(1212), false, 1, 3, 3, "admin", null },
                    { 8, "admin", new DateTime(2024, 2, 2, 14, 42, 55, 506, DateTimeKind.Local).AddTicks(1214), false, 2, 3, 3, "admin", null },
                    { 9, "admin", new DateTime(2024, 2, 2, 14, 42, 55, 506, DateTimeKind.Local).AddTicks(1216), false, 3, 3, 3, "admin", null }
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
                name: "IX_ShoppingCart_UserId",
                table: "ShoppingCart",
                column: "UserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ShoppingCartItem_ItemId",
                table: "ShoppingCartItem",
                column: "ItemId");

            migrationBuilder.CreateIndex(
                name: "IX_ShoppingCartItem_ShoppingCartID",
                table: "ShoppingCartItem",
                column: "ShoppingCartID");

            migrationBuilder.CreateIndex(
                name: "IX_Token_UserId",
                table: "Token",
                column: "UserId");

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
                name: "RoleClaims");

            migrationBuilder.DropTable(
                name: "ShoppingCartItem");

            migrationBuilder.DropTable(
                name: "Token");

            migrationBuilder.DropTable(
                name: "UserClaims");

            migrationBuilder.DropTable(
                name: "UserLogins");

            migrationBuilder.DropTable(
                name: "UserRoles");

            migrationBuilder.DropTable(
                name: "UserTokens");

            migrationBuilder.DropTable(
                name: "Product");

            migrationBuilder.DropTable(
                name: "ShoppingCart");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "Brand");

            migrationBuilder.DropTable(
                name: "Category");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
