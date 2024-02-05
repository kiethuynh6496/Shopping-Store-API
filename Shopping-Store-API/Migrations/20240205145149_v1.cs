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
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
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
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
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
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
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
                name: "Address",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    AddressName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    isDefault = table.Column<bool>(type: "bit", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Address", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Address_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Order",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Total = table.Column<long>(type: "bigint", nullable: false),
                    OrderStatus = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Order", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Order_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
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
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValue: new DateTime(2024, 2, 5, 21, 51, 49, 157, DateTimeKind.Local).AddTicks(3925)),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true, defaultValue: "admin"),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
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
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
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
                name: "OrderItem",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderID = table.Column<int>(type: "int", nullable: false),
                    ItemId = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderItem", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderItem_Order_OrderID",
                        column: x => x.OrderID,
                        principalTable: "Order",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderItem_Product_ItemId",
                        column: x => x.ItemId,
                        principalTable: "Product",
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
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
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
                    { 1, null, new DateTime(2024, 2, 5, 21, 51, 49, 157, DateTimeKind.Local).AddTicks(9986), false, "Dell", null, null },
                    { 2, null, new DateTime(2024, 2, 5, 21, 51, 49, 157, DateTimeKind.Local).AddTicks(9987), false, "Apple", null, null },
                    { 3, null, new DateTime(2024, 2, 5, 21, 51, 49, 157, DateTimeKind.Local).AddTicks(9988), false, "Gigabyte", null, null },
                    { 4, null, new DateTime(2024, 2, 5, 21, 51, 49, 157, DateTimeKind.Local).AddTicks(9989), false, "Corsair", null, null },
                    { 5, null, new DateTime(2024, 2, 5, 21, 51, 49, 157, DateTimeKind.Local).AddTicks(9990), false, "LG", null, null },
                    { 6, null, new DateTime(2024, 2, 5, 21, 51, 49, 157, DateTimeKind.Local).AddTicks(9991), false, "Asus", null, null },
                    { 7, null, new DateTime(2024, 2, 5, 21, 51, 49, 157, DateTimeKind.Local).AddTicks(9992), false, "Viewsonic", null, null },
                    { 8, null, new DateTime(2024, 2, 5, 21, 51, 49, 157, DateTimeKind.Local).AddTicks(9993), false, "Acer", null, null }
                });

            migrationBuilder.InsertData(
                table: "Category",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "IsDeleted", "Name", "UpdatedBy", "UpdatedDate" },
                values: new object[,]
                {
                    { 1, null, new DateTime(2024, 2, 5, 21, 51, 49, 158, DateTimeKind.Local).AddTicks(122), false, "Laptop", null, null },
                    { 2, null, new DateTime(2024, 2, 5, 21, 51, 49, 158, DateTimeKind.Local).AddTicks(124), false, "Ipad", null, null },
                    { 3, null, new DateTime(2024, 2, 5, 21, 51, 49, 158, DateTimeKind.Local).AddTicks(125), false, "Screen", null, null },
                    { 4, null, new DateTime(2024, 2, 5, 21, 51, 49, 158, DateTimeKind.Local).AddTicks(126), false, "Iphone", null, null },
                    { 5, null, new DateTime(2024, 2, 5, 21, 51, 49, 158, DateTimeKind.Local).AddTicks(127), false, "Macbook", null, null },
                    { 6, null, new DateTime(2024, 2, 5, 21, 51, 49, 158, DateTimeKind.Local).AddTicks(128), false, "Mainboard", null, null },
                    { 7, null, new DateTime(2024, 2, 5, 21, 51, 49, 158, DateTimeKind.Local).AddTicks(128), false, "Case", null, null }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "44bc1c18-51a6-46b0-8e20-0df40a2ae0b9", "a7bee7c8-748b-4e11-9f65-e8df283761af", "Admin", "ADMIN" },
                    { "4d267d01-3ce5-44d4-bf99-a3fd2172ba17", "02d1fe54-d386-412a-badf-6e35a963d3bf", "User", "USER" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AccessFailedCount", "Birthday", "ConcurrencyStamp", "Email", "EmailConfirmed", "FullName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "94a12a30-1a9b-48ad-950d-29f80865003d", 0, null, "26532239-4aea-4c63-8d72-3ce21ec4b422", null, false, "mangoc", false, null, null, null, null, null, false, "7037ef73-8e81-433a-a160-fcb1fed0236c", false, null },
                    { "d68dcb5f-2706-4cb5-bb0b-37bf39400420", 0, null, "bcd859fe-7282-46f7-8408-d7bc3b2ac480", null, false, "kiethuynh", false, null, null, null, null, null, false, "d000f7f8-e8dd-4307-a255-f0f4752ce391", false, null },
                    { "f222bfbf-86bf-4b65-9958-bc818ba5f822", 0, null, "0f675472-f9d3-46bb-8611-73f244e9abe2", null, false, "auduongphong", false, null, null, null, null, null, false, "abb29ab2-2cc0-4da6-bdef-6821542148a3", false, null }
                });

            migrationBuilder.InsertData(
                table: "Address",
                columns: new[] { "Id", "AddressName", "City", "CreatedBy", "CreatedDate", "IsDeleted", "UpdatedBy", "UpdatedDate", "UserId", "isDefault" },
                values: new object[,]
                {
                    { 1, "172/26 Ly Thai To, Q.3", "HCM", null, new DateTime(2024, 2, 5, 21, 51, 49, 158, DateTimeKind.Local).AddTicks(2937), false, null, null, "d68dcb5f-2706-4cb5-bb0b-37bf39400420", true },
                    { 2, "175 Duong so 1, Go Vap", "HCM", null, new DateTime(2024, 2, 5, 21, 51, 49, 158, DateTimeKind.Local).AddTicks(2941), false, null, null, "d68dcb5f-2706-4cb5-bb0b-37bf39400420", false },
                    { 3, "175 Duong so 10, Binh Thanh", "HCM", null, new DateTime(2024, 2, 5, 21, 51, 49, 158, DateTimeKind.Local).AddTicks(2942), false, null, null, "94a12a30-1a9b-48ad-950d-29f80865003d", true },
                    { 4, "11 Duong so 1, Binh Thanh", "HCM", null, new DateTime(2024, 2, 5, 21, 51, 49, 158, DateTimeKind.Local).AddTicks(2944), false, null, null, "f222bfbf-86bf-4b65-9958-bc818ba5f822", true }
                });

            migrationBuilder.InsertData(
                table: "Order",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "IsDeleted", "OrderStatus", "Total", "UpdatedBy", "UpdatedDate", "UserId" },
                values: new object[,]
                {
                    { 1, null, new DateTime(2024, 2, 5, 21, 51, 49, 158, DateTimeKind.Local).AddTicks(4279), false, 0, 100000L, null, null, "d68dcb5f-2706-4cb5-bb0b-37bf39400420" },
                    { 2, null, new DateTime(2024, 2, 5, 21, 51, 49, 158, DateTimeKind.Local).AddTicks(4283), false, 0, 110000L, null, null, "d68dcb5f-2706-4cb5-bb0b-37bf39400420" },
                    { 3, null, new DateTime(2024, 2, 5, 21, 51, 49, 158, DateTimeKind.Local).AddTicks(4284), false, 0, 120000L, null, null, "94a12a30-1a9b-48ad-950d-29f80865003d" },
                    { 4, null, new DateTime(2024, 2, 5, 21, 51, 49, 158, DateTimeKind.Local).AddTicks(4285), false, 0, 130000L, null, null, "f222bfbf-86bf-4b65-9958-bc818ba5f822" }
                });

            migrationBuilder.InsertData(
                table: "Product",
                columns: new[] { "Id", "BrandID", "CategoryID", "CreatedBy", "CreatedDate", "Description", "IsDeleted", "Name", "PictureUrl", "Price", "QuantityInStock", "UpdatedBy", "UpdatedDate" },
                values: new object[,]
                {
                    { 1, 1, 1, null, new DateTime(2024, 2, 5, 21, 51, 49, 157, DateTimeKind.Local).AddTicks(9769), "Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Maecenas porttitor congue massa. Fusce posuere, magna sed pulvinar ultricies, purus lectus malesuada libero, sit amet commodo magna eros quis urna.", false, "Dell Latitude 7320", "/images/products/product-01.png", 1000L, 100, null, null },
                    { 2, 1, 1, null, new DateTime(2024, 2, 5, 21, 51, 49, 157, DateTimeKind.Local).AddTicks(9776), "Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Maecenas porttitor congue massa. Fusce posuere, magna sed pulvinar ultricies, purus lectus malesuada libero, sit amet commodo magna eros quis urna.", false, "Dell Latitude 7330", "/images/products/product-02.png", 2000L, 100, null, null },
                    { 3, 1, 1, null, new DateTime(2024, 2, 5, 21, 51, 49, 157, DateTimeKind.Local).AddTicks(9778), "Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Maecenas porttitor congue massa. Fusce posuere, magna sed pulvinar ultricies, purus lectus malesuada libero, sit amet commodo magna eros quis urna.", false, "Dell Inspiron 6430", "/images/products/product-03.png", 3000L, 100, null, null },
                    { 4, 1, 1, null, new DateTime(2024, 2, 5, 21, 51, 49, 157, DateTimeKind.Local).AddTicks(9779), "Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Maecenas porttitor congue massa. Fusce posuere, magna sed pulvinar ultricies, purus lectus malesuada libero, sit amet commodo magna eros quis urna.", false, "Dell Inspiron 6530", "/images/products/product-04.png", 4000L, 100, null, null },
                    { 5, 2, 2, null, new DateTime(2024, 2, 5, 21, 51, 49, 157, DateTimeKind.Local).AddTicks(9782), "Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Maecenas porttitor congue massa. Fusce posuere, magna sed pulvinar ultricies, purus lectus malesuada libero, sit amet commodo magna eros quis urna.", false, "Ipad M1 12.9", "/images/products/product-05.png", 5000L, 100, null, null },
                    { 6, 2, 2, null, new DateTime(2024, 2, 5, 21, 51, 49, 157, DateTimeKind.Local).AddTicks(9783), "Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Maecenas porttitor congue massa. Fusce posuere, magna sed pulvinar ultricies, purus lectus malesuada libero, sit amet commodo magna eros quis urna.", false, "Ipad M1 12.9", "/images/products/product-06.png", 6000L, 100, null, null },
                    { 7, 1, 3, null, new DateTime(2024, 2, 5, 21, 51, 49, 157, DateTimeKind.Local).AddTicks(9784), "Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Maecenas porttitor congue massa. Fusce posuere, magna sed pulvinar ultricies, purus lectus malesuada libero, sit amet commodo magna eros quis urna.", false, "Dell Screen 27inch", "/images/products/product-07.png", 7000L, 100, null, null },
                    { 8, 1, 3, null, new DateTime(2024, 2, 5, 21, 51, 49, 157, DateTimeKind.Local).AddTicks(9785), "Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Maecenas porttitor congue massa. Fusce posuere, magna sed pulvinar ultricies, purus lectus malesuada libero, sit amet commodo magna eros quis urna.", false, "Dell Screen 27inch", "/images/products/product-08.png", 8000L, 100, null, null },
                    { 9, 2, 4, null, new DateTime(2024, 2, 5, 21, 51, 49, 157, DateTimeKind.Local).AddTicks(9826), "Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Maecenas porttitor congue massa. Fusce posuere, magna sed pulvinar ultricies, purus lectus malesuada libero, sit amet commodo magna eros quis urna.", false, "Iphone 14 Pro Max", "/images/products/product-09.jpeg", 9000L, 100, null, null },
                    { 10, 2, 4, null, new DateTime(2024, 2, 5, 21, 51, 49, 157, DateTimeKind.Local).AddTicks(9828), "Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Maecenas porttitor congue massa. Fusce posuere, magna sed pulvinar ultricies, purus lectus malesuada libero, sit amet commodo magna eros quis urna.", false, "Iphone 14 Pro Max", "/images/products/product-10.jpeg", 10000L, 100, null, null },
                    { 11, 2, 5, null, new DateTime(2024, 2, 5, 21, 51, 49, 157, DateTimeKind.Local).AddTicks(9829), "Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Maecenas porttitor congue massa. Fusce posuere, magna sed pulvinar ultricies, purus lectus malesuada libero, sit amet commodo magna eros quis urna.", false, "Macbook Air M1", "/images/products/product-11.jpeg", 11000L, 100, null, null },
                    { 12, 2, 5, null, new DateTime(2024, 2, 5, 21, 51, 49, 157, DateTimeKind.Local).AddTicks(9831), "Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Maecenas porttitor congue massa. Fusce posuere, magna sed pulvinar ultricies, purus lectus malesuada libero, sit amet commodo magna eros quis urna.", false, "Macbook Air M1", "/images/products/product-12.png", 12000L, 100, null, null },
                    { 13, 3, 6, null, new DateTime(2024, 2, 5, 21, 51, 49, 157, DateTimeKind.Local).AddTicks(9832), "Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Maecenas porttitor congue massa. Fusce posuere, magna sed pulvinar ultricies, purus lectus malesuada libero, sit amet commodo magna eros quis urna.", false, "Mainboard Gigabyte 6330", "/images/products/product-13.png", 13000L, 100, null, null },
                    { 14, 3, 6, null, new DateTime(2024, 2, 5, 21, 51, 49, 157, DateTimeKind.Local).AddTicks(9833), "Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Maecenas porttitor congue massa. Fusce posuere, magna sed pulvinar ultricies, purus lectus malesuada libero, sit amet commodo magna eros quis urna.", false, "Mainboard Gigabyte 6330", "/images/products/product-14.png", 14000L, 100, null, null },
                    { 15, 4, 7, null, new DateTime(2024, 2, 5, 21, 51, 49, 157, DateTimeKind.Local).AddTicks(9834), "Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Maecenas porttitor congue massa. Fusce posuere, magna sed pulvinar ultricies, purus lectus malesuada libero, sit amet commodo magna eros quis urna.", false, "Case Corsair", "/images/products/product-15.png", 15000L, 100, null, null },
                    { 16, 5, 3, null, new DateTime(2024, 2, 5, 21, 51, 49, 157, DateTimeKind.Local).AddTicks(9836), "Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Maecenas porttitor congue massa. Fusce posuere, magna sed pulvinar ultricies, purus lectus malesuada libero, sit amet commodo magna eros quis urna.", false, "LG Ultra Gear", "/images/products/product-16.png", 16000L, 100, null, null },
                    { 17, 5, 3, null, new DateTime(2024, 2, 5, 21, 51, 49, 157, DateTimeKind.Local).AddTicks(9837), "Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Maecenas porttitor congue massa. Fusce posuere, magna sed pulvinar ultricies, purus lectus malesuada libero, sit amet commodo magna eros quis urna.", false, "LG Ultra Gear", "/images/products/product-17.png", 17000L, 100, null, null },
                    { 18, 6, 3, null, new DateTime(2024, 2, 5, 21, 51, 49, 157, DateTimeKind.Local).AddTicks(9838), "Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Maecenas porttitor congue massa. Fusce posuere, magna sed pulvinar ultricies, purus lectus malesuada libero, sit amet commodo magna eros quis urna.", false, "MSI 27", "/images/products/product-18.png", 18000L, 100, null, null },
                    { 19, 7, 3, null, new DateTime(2024, 2, 5, 21, 51, 49, 157, DateTimeKind.Local).AddTicks(9839), "Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Maecenas porttitor congue massa. Fusce posuere, magna sed pulvinar ultricies, purus lectus malesuada libero, sit amet commodo magna eros quis urna.", false, "Viewsonic 24", "/images/products/product-19.png", 19000L, 100, null, null },
                    { 20, 8, 3, null, new DateTime(2024, 2, 5, 21, 51, 49, 157, DateTimeKind.Local).AddTicks(9840), "Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Maecenas porttitor congue massa. Fusce posuere, magna sed pulvinar ultricies, purus lectus malesuada libero, sit amet commodo magna eros quis urna.", false, "Acer 27", "/images/products/product-20.png", 10000L, 100, null, null },
                    { 21, 6, 3, null, new DateTime(2024, 2, 5, 21, 51, 49, 157, DateTimeKind.Local).AddTicks(9842), "Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Maecenas porttitor congue massa. Fusce posuere, magna sed pulvinar ultricies, purus lectus malesuada libero, sit amet commodo magna eros quis urna.", false, "Asus 27 Freesync", "/images/products/product-21.png", 21000L, 100, null, null },
                    { 22, 6, 3, null, new DateTime(2024, 2, 5, 21, 51, 49, 157, DateTimeKind.Local).AddTicks(9843), "Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Maecenas porttitor congue massa. Fusce posuere, magna sed pulvinar ultricies, purus lectus malesuada libero, sit amet commodo magna eros quis urna.", false, "Asus 24 Freesync", "/images/products/product-22.png", 22000L, 100, null, null },
                    { 23, 7, 3, null, new DateTime(2024, 2, 5, 21, 51, 49, 157, DateTimeKind.Local).AddTicks(9844), "Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Maecenas porttitor congue massa. Fusce posuere, magna sed pulvinar ultricies, purus lectus malesuada libero, sit amet commodo magna eros quis urna.", false, "Viewsonic 24 Freesync", "/images/products/product-23.png", 23000L, 100, null, null },
                    { 24, 7, 3, null, new DateTime(2024, 2, 5, 21, 51, 49, 157, DateTimeKind.Local).AddTicks(9845), "Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Maecenas porttitor congue massa. Fusce posuere, magna sed pulvinar ultricies, purus lectus malesuada libero, sit amet commodo magna eros quis urna.", false, "Viewsonic 24 Freesync 75Hz", "/images/products/product-24.png", 24000L, 100, null, null },
                    { 25, 6, 3, null, new DateTime(2024, 2, 5, 21, 51, 49, 157, DateTimeKind.Local).AddTicks(9848), "Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Maecenas porttitor congue massa. Fusce posuere, magna sed pulvinar ultricies, purus lectus malesuada libero, sit amet commodo magna eros quis urna.", false, "Asus TUF Gaming 24", "/images/products/product-25.png", 25000L, 100, null, null },
                    { 26, 3, 3, null, new DateTime(2024, 2, 5, 21, 51, 49, 157, DateTimeKind.Local).AddTicks(9849), "Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Maecenas porttitor congue massa. Fusce posuere, magna sed pulvinar ultricies, purus lectus malesuada libero, sit amet commodo magna eros quis urna.", false, "Gigabyte 24", "/images/products/product-26.png", 26000L, 100, null, null },
                    { 27, 6, 3, null, new DateTime(2024, 2, 5, 21, 51, 49, 157, DateTimeKind.Local).AddTicks(9851), "Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Maecenas porttitor congue massa. Fusce posuere, magna sed pulvinar ultricies, purus lectus malesuada libero, sit amet commodo magna eros quis urna.", false, "Asus GM27", "/images/products/product-27.png", 27000L, 100, null, null },
                    { 28, 8, 3, null, new DateTime(2024, 2, 5, 21, 51, 49, 157, DateTimeKind.Local).AddTicks(9852), "Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Maecenas porttitor congue massa. Fusce posuere, magna sed pulvinar ultricies, purus lectus malesuada libero, sit amet commodo magna eros quis urna.", false, "Acer 75hz 27", "/images/products/product-28.png", 28000L, 100, null, null },
                    { 29, 5, 3, null, new DateTime(2024, 2, 5, 21, 51, 49, 157, DateTimeKind.Local).AddTicks(9853), "Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Maecenas porttitor congue massa. Fusce posuere, magna sed pulvinar ultricies, purus lectus malesuada libero, sit amet commodo magna eros quis urna.", false, "LG 75hz 27", "/images/products/product-29.png", 29000L, 100, null, null },
                    { 30, 6, 3, null, new DateTime(2024, 2, 5, 21, 51, 49, 157, DateTimeKind.Local).AddTicks(9855), "Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Maecenas porttitor congue massa. Fusce posuere, magna sed pulvinar ultricies, purus lectus malesuada libero, sit amet commodo magna eros quis urna.", false, "Asus 100hz 27", "/images/products/product-30.png", 30000L, 100, null, null }
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
                columns: new[] { "Id", "CreatedDate", "IsDeleted", "UpdatedBy", "UpdatedDate", "UserId" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 2, 5, 21, 51, 49, 157, DateTimeKind.Local).AddTicks(4216), false, null, null, "d68dcb5f-2706-4cb5-bb0b-37bf39400420" },
                    { 2, new DateTime(2024, 2, 5, 21, 51, 49, 157, DateTimeKind.Local).AddTicks(4221), false, null, null, "94a12a30-1a9b-48ad-950d-29f80865003d" },
                    { 3, new DateTime(2024, 2, 5, 21, 51, 49, 157, DateTimeKind.Local).AddTicks(4223), false, null, null, "f222bfbf-86bf-4b65-9958-bc818ba5f822" }
                });

            migrationBuilder.InsertData(
                table: "Token",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "ExpiresAt", "IPAddress", "IsDeleted", "RefreshToken", "UpdatedBy", "UpdatedDate", "UserAgent", "UserId" },
                values: new object[,]
                {
                    { 1, null, new DateTime(2024, 2, 5, 21, 51, 49, 158, DateTimeKind.Local).AddTicks(1419), new DateTime(2024, 2, 5, 21, 51, 49, 158, DateTimeKind.Local).AddTicks(1424), "192.168.0.1", false, "", null, null, "Chrome/91.0.4472.124", "d68dcb5f-2706-4cb5-bb0b-37bf39400420" },
                    { 2, null, new DateTime(2024, 2, 5, 21, 51, 49, 158, DateTimeKind.Local).AddTicks(1428), new DateTime(2024, 2, 5, 21, 51, 49, 158, DateTimeKind.Local).AddTicks(1429), "192.168.0.2", false, "", null, null, "Mozilla/5.0 (Windows NT 10.0; Win64; x64)", "d68dcb5f-2706-4cb5-bb0b-37bf39400420" },
                    { 3, null, new DateTime(2024, 2, 5, 21, 51, 49, 158, DateTimeKind.Local).AddTicks(1429), new DateTime(2024, 2, 5, 21, 51, 49, 158, DateTimeKind.Local).AddTicks(1430), "192.168.0.3", false, "", null, null, "Safari/537.36", "94a12a30-1a9b-48ad-950d-29f80865003d" }
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
                table: "OrderItem",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "IsDeleted", "ItemId", "OrderID", "Quantity", "UpdatedBy", "UpdatedDate" },
                values: new object[,]
                {
                    { 1, null, new DateTime(2024, 2, 5, 21, 51, 49, 158, DateTimeKind.Local).AddTicks(6714), false, 1, 1, 3, null, null },
                    { 2, null, new DateTime(2024, 2, 5, 21, 51, 49, 158, DateTimeKind.Local).AddTicks(6719), false, 2, 1, 3, null, null },
                    { 3, null, new DateTime(2024, 2, 5, 21, 51, 49, 158, DateTimeKind.Local).AddTicks(6720), false, 3, 1, 3, null, null },
                    { 4, null, new DateTime(2024, 2, 5, 21, 51, 49, 158, DateTimeKind.Local).AddTicks(6721), false, 3, 2, 3, null, null },
                    { 5, null, new DateTime(2024, 2, 5, 21, 51, 49, 158, DateTimeKind.Local).AddTicks(6722), false, 3, 3, 3, null, null },
                    { 6, null, new DateTime(2024, 2, 5, 21, 51, 49, 158, DateTimeKind.Local).AddTicks(6723), false, 3, 4, 3, null, null }
                });

            migrationBuilder.InsertData(
                table: "ShoppingCartItem",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "IsDeleted", "ItemId", "Quantity", "ShoppingCartID", "UpdatedBy", "UpdatedDate" },
                values: new object[,]
                {
                    { 1, null, new DateTime(2024, 2, 5, 21, 51, 49, 157, DateTimeKind.Local).AddTicks(6783), false, 1, 3, 1, null, null },
                    { 2, null, new DateTime(2024, 2, 5, 21, 51, 49, 157, DateTimeKind.Local).AddTicks(6788), false, 2, 3, 1, null, null },
                    { 3, null, new DateTime(2024, 2, 5, 21, 51, 49, 157, DateTimeKind.Local).AddTicks(6789), false, 3, 3, 1, null, null },
                    { 4, null, new DateTime(2024, 2, 5, 21, 51, 49, 157, DateTimeKind.Local).AddTicks(6790), false, 1, 3, 2, null, null },
                    { 5, null, new DateTime(2024, 2, 5, 21, 51, 49, 157, DateTimeKind.Local).AddTicks(6791), false, 2, 3, 2, null, null },
                    { 6, null, new DateTime(2024, 2, 5, 21, 51, 49, 157, DateTimeKind.Local).AddTicks(6792), false, 3, 3, 2, null, null },
                    { 7, null, new DateTime(2024, 2, 5, 21, 51, 49, 157, DateTimeKind.Local).AddTicks(6792), false, 1, 3, 3, null, null },
                    { 8, null, new DateTime(2024, 2, 5, 21, 51, 49, 157, DateTimeKind.Local).AddTicks(6793), false, 2, 3, 3, null, null },
                    { 9, null, new DateTime(2024, 2, 5, 21, 51, 49, 157, DateTimeKind.Local).AddTicks(6794), false, 3, 3, 3, null, null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Address_UserId",
                table: "Address",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Order_UserId",
                table: "Order",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderItem_ItemId",
                table: "OrderItem",
                column: "ItemId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderItem_OrderID",
                table: "OrderItem",
                column: "OrderID");

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
                name: "Address");

            migrationBuilder.DropTable(
                name: "OrderItem");

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
                name: "Order");

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
