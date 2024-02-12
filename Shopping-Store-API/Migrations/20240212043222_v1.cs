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
                    PaymentIntenId = table.Column<string>(type: "nvarchar(max)", nullable: true),
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
                    PaymentIntenId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClientSecret = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValue: new DateTime(2024, 2, 12, 11, 32, 22, 482, DateTimeKind.Local).AddTicks(4640)),
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
                    { 1, null, new DateTime(2024, 2, 12, 11, 32, 22, 493, DateTimeKind.Local).AddTicks(9475), false, "Dell", null, null },
                    { 2, null, new DateTime(2024, 2, 12, 11, 32, 22, 493, DateTimeKind.Local).AddTicks(9480), false, "Apple", null, null },
                    { 3, null, new DateTime(2024, 2, 12, 11, 32, 22, 493, DateTimeKind.Local).AddTicks(9481), false, "Gigabyte", null, null },
                    { 4, null, new DateTime(2024, 2, 12, 11, 32, 22, 493, DateTimeKind.Local).AddTicks(9482), false, "Corsair", null, null },
                    { 5, null, new DateTime(2024, 2, 12, 11, 32, 22, 493, DateTimeKind.Local).AddTicks(9483), false, "LG", null, null },
                    { 6, null, new DateTime(2024, 2, 12, 11, 32, 22, 493, DateTimeKind.Local).AddTicks(9484), false, "Asus", null, null },
                    { 7, null, new DateTime(2024, 2, 12, 11, 32, 22, 493, DateTimeKind.Local).AddTicks(9485), false, "Viewsonic", null, null },
                    { 8, null, new DateTime(2024, 2, 12, 11, 32, 22, 493, DateTimeKind.Local).AddTicks(9486), false, "Acer", null, null }
                });

            migrationBuilder.InsertData(
                table: "Category",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "IsDeleted", "Name", "UpdatedBy", "UpdatedDate" },
                values: new object[,]
                {
                    { 1, null, new DateTime(2024, 2, 12, 11, 32, 22, 493, DateTimeKind.Local).AddTicks(9623), false, "Laptop", null, null },
                    { 2, null, new DateTime(2024, 2, 12, 11, 32, 22, 493, DateTimeKind.Local).AddTicks(9629), false, "Ipad", null, null },
                    { 3, null, new DateTime(2024, 2, 12, 11, 32, 22, 493, DateTimeKind.Local).AddTicks(9630), false, "Screen", null, null },
                    { 4, null, new DateTime(2024, 2, 12, 11, 32, 22, 493, DateTimeKind.Local).AddTicks(9631), false, "Iphone", null, null },
                    { 5, null, new DateTime(2024, 2, 12, 11, 32, 22, 493, DateTimeKind.Local).AddTicks(9632), false, "Macbook", null, null },
                    { 6, null, new DateTime(2024, 2, 12, 11, 32, 22, 493, DateTimeKind.Local).AddTicks(9633), false, "Mainboard", null, null },
                    { 7, null, new DateTime(2024, 2, 12, 11, 32, 22, 493, DateTimeKind.Local).AddTicks(9634), false, "Case", null, null }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "44bc1c18-51a6-46b0-8e20-0df40a2ae0b9", "a08036bf-e348-41f4-a7a8-1295dbf2c127", "Admin", "ADMIN" },
                    { "4d267d01-3ce5-44d4-bf99-a3fd2172ba17", "902e9b65-1f14-4503-9613-378c70802aa5", "User", "USER" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AccessFailedCount", "Birthday", "ConcurrencyStamp", "Email", "EmailConfirmed", "FullName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "94a12a30-1a9b-48ad-950d-29f80865003d", 0, null, "fc4d90b6-094e-440c-b4ab-ccdf7ae20f8e", null, false, "mangoc", false, null, null, null, null, null, false, "cc82dcb9-0e14-4697-a3c0-964ad35888f7", false, null },
                    { "d68dcb5f-2706-4cb5-bb0b-37bf39400420", 0, null, "9d25cb87-fe3e-4000-add0-a41ced09dec5", null, false, "kiethuynh", false, null, null, null, null, null, false, "0b2b1673-19dc-42e8-96ac-1d0091afac9a", false, null },
                    { "f222bfbf-86bf-4b65-9958-bc818ba5f822", 0, null, "36a843a1-43c9-4637-9764-4a576a0cb3a1", null, false, "auduongphong", false, null, null, null, null, null, false, "5a35478b-5c3b-413b-ac26-4c7babff390d", false, null }
                });

            migrationBuilder.InsertData(
                table: "Address",
                columns: new[] { "Id", "AddressName", "City", "CreatedBy", "CreatedDate", "IsDeleted", "UpdatedBy", "UpdatedDate", "UserId", "isDefault" },
                values: new object[,]
                {
                    { 1, "172/26 Ly Thai To, Q.3", "HCM", null, new DateTime(2024, 2, 12, 11, 32, 22, 494, DateTimeKind.Local).AddTicks(3957), false, null, null, "d68dcb5f-2706-4cb5-bb0b-37bf39400420", true },
                    { 2, "175 Duong so 1, Go Vap", "HCM", null, new DateTime(2024, 2, 12, 11, 32, 22, 494, DateTimeKind.Local).AddTicks(3962), false, null, null, "d68dcb5f-2706-4cb5-bb0b-37bf39400420", false },
                    { 3, "175 Duong so 10, Binh Thanh", "HCM", null, new DateTime(2024, 2, 12, 11, 32, 22, 494, DateTimeKind.Local).AddTicks(3963), false, null, null, "94a12a30-1a9b-48ad-950d-29f80865003d", true },
                    { 4, "11 Duong so 1, Binh Thanh", "HCM", null, new DateTime(2024, 2, 12, 11, 32, 22, 494, DateTimeKind.Local).AddTicks(3965), false, null, null, "f222bfbf-86bf-4b65-9958-bc818ba5f822", true }
                });

            migrationBuilder.InsertData(
                table: "Order",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "IsDeleted", "OrderStatus", "PaymentIntenId", "Total", "UpdatedBy", "UpdatedDate", "UserId" },
                values: new object[,]
                {
                    { 1, null, new DateTime(2024, 2, 12, 11, 32, 22, 494, DateTimeKind.Local).AddTicks(5151), false, 0, null, 100000L, null, null, "d68dcb5f-2706-4cb5-bb0b-37bf39400420" },
                    { 2, null, new DateTime(2024, 2, 12, 11, 32, 22, 494, DateTimeKind.Local).AddTicks(5157), false, 0, null, 110000L, null, null, "d68dcb5f-2706-4cb5-bb0b-37bf39400420" },
                    { 3, null, new DateTime(2024, 2, 12, 11, 32, 22, 494, DateTimeKind.Local).AddTicks(5158), false, 0, null, 120000L, null, null, "94a12a30-1a9b-48ad-950d-29f80865003d" },
                    { 4, null, new DateTime(2024, 2, 12, 11, 32, 22, 494, DateTimeKind.Local).AddTicks(5159), false, 0, null, 130000L, null, null, "f222bfbf-86bf-4b65-9958-bc818ba5f822" }
                });

            migrationBuilder.InsertData(
                table: "Product",
                columns: new[] { "Id", "BrandID", "CategoryID", "CreatedBy", "CreatedDate", "Description", "IsDeleted", "Name", "PictureUrl", "Price", "QuantityInStock", "UpdatedBy", "UpdatedDate" },
                values: new object[,]
                {
                    { 1, 1, 1, null, new DateTime(2024, 2, 12, 11, 32, 22, 493, DateTimeKind.Local).AddTicks(9048), "Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Maecenas porttitor congue massa. Fusce posuere, magna sed pulvinar ultricies, purus lectus malesuada libero, sit amet commodo magna eros quis urna.", false, "Dell Latitude 7320", "/images/products/product-01.png", 1000L, 100, null, null },
                    { 2, 1, 1, null, new DateTime(2024, 2, 12, 11, 32, 22, 493, DateTimeKind.Local).AddTicks(9071), "Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Maecenas porttitor congue massa. Fusce posuere, magna sed pulvinar ultricies, purus lectus malesuada libero, sit amet commodo magna eros quis urna.", false, "Dell Latitude 7330", "/images/products/product-02.png", 2000L, 100, null, null },
                    { 3, 1, 1, null, new DateTime(2024, 2, 12, 11, 32, 22, 493, DateTimeKind.Local).AddTicks(9073), "Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Maecenas porttitor congue massa. Fusce posuere, magna sed pulvinar ultricies, purus lectus malesuada libero, sit amet commodo magna eros quis urna.", false, "Dell Inspiron 6430", "/images/products/product-03.png", 3000L, 100, null, null },
                    { 4, 1, 1, null, new DateTime(2024, 2, 12, 11, 32, 22, 493, DateTimeKind.Local).AddTicks(9075), "Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Maecenas porttitor congue massa. Fusce posuere, magna sed pulvinar ultricies, purus lectus malesuada libero, sit amet commodo magna eros quis urna.", false, "Dell Inspiron 6530", "/images/products/product-04.png", 4000L, 100, null, null },
                    { 5, 2, 2, null, new DateTime(2024, 2, 12, 11, 32, 22, 493, DateTimeKind.Local).AddTicks(9076), "Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Maecenas porttitor congue massa. Fusce posuere, magna sed pulvinar ultricies, purus lectus malesuada libero, sit amet commodo magna eros quis urna.", false, "Ipad M1 12.9", "/images/products/product-05.png", 5000L, 100, null, null },
                    { 6, 2, 2, null, new DateTime(2024, 2, 12, 11, 32, 22, 493, DateTimeKind.Local).AddTicks(9078), "Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Maecenas porttitor congue massa. Fusce posuere, magna sed pulvinar ultricies, purus lectus malesuada libero, sit amet commodo magna eros quis urna.", false, "Ipad M1 12.9", "/images/products/product-06.png", 6000L, 100, null, null },
                    { 7, 1, 3, null, new DateTime(2024, 2, 12, 11, 32, 22, 493, DateTimeKind.Local).AddTicks(9080), "Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Maecenas porttitor congue massa. Fusce posuere, magna sed pulvinar ultricies, purus lectus malesuada libero, sit amet commodo magna eros quis urna.", false, "Dell Screen 27inch", "/images/products/product-07.png", 7000L, 100, null, null },
                    { 8, 1, 3, null, new DateTime(2024, 2, 12, 11, 32, 22, 493, DateTimeKind.Local).AddTicks(9081), "Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Maecenas porttitor congue massa. Fusce posuere, magna sed pulvinar ultricies, purus lectus malesuada libero, sit amet commodo magna eros quis urna.", false, "Dell Screen 27inch", "/images/products/product-08.png", 8000L, 100, null, null },
                    { 9, 2, 4, null, new DateTime(2024, 2, 12, 11, 32, 22, 493, DateTimeKind.Local).AddTicks(9083), "Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Maecenas porttitor congue massa. Fusce posuere, magna sed pulvinar ultricies, purus lectus malesuada libero, sit amet commodo magna eros quis urna.", false, "Iphone 14 Pro Max", "/images/products/product-09.jpeg", 9000L, 100, null, null },
                    { 10, 2, 4, null, new DateTime(2024, 2, 12, 11, 32, 22, 493, DateTimeKind.Local).AddTicks(9093), "Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Maecenas porttitor congue massa. Fusce posuere, magna sed pulvinar ultricies, purus lectus malesuada libero, sit amet commodo magna eros quis urna.", false, "Iphone 14 Pro Max", "/images/products/product-10.jpeg", 10000L, 100, null, null },
                    { 11, 2, 5, null, new DateTime(2024, 2, 12, 11, 32, 22, 493, DateTimeKind.Local).AddTicks(9095), "Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Maecenas porttitor congue massa. Fusce posuere, magna sed pulvinar ultricies, purus lectus malesuada libero, sit amet commodo magna eros quis urna.", false, "Macbook Air M1", "/images/products/product-11.jpeg", 11000L, 100, null, null },
                    { 12, 2, 5, null, new DateTime(2024, 2, 12, 11, 32, 22, 493, DateTimeKind.Local).AddTicks(9097), "Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Maecenas porttitor congue massa. Fusce posuere, magna sed pulvinar ultricies, purus lectus malesuada libero, sit amet commodo magna eros quis urna.", false, "Macbook Air M1", "/images/products/product-12.png", 12000L, 100, null, null },
                    { 13, 3, 6, null, new DateTime(2024, 2, 12, 11, 32, 22, 493, DateTimeKind.Local).AddTicks(9099), "Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Maecenas porttitor congue massa. Fusce posuere, magna sed pulvinar ultricies, purus lectus malesuada libero, sit amet commodo magna eros quis urna.", false, "Mainboard Gigabyte 6330", "/images/products/product-13.png", 13000L, 100, null, null },
                    { 14, 3, 6, null, new DateTime(2024, 2, 12, 11, 32, 22, 493, DateTimeKind.Local).AddTicks(9101), "Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Maecenas porttitor congue massa. Fusce posuere, magna sed pulvinar ultricies, purus lectus malesuada libero, sit amet commodo magna eros quis urna.", false, "Mainboard Gigabyte 6330", "/images/products/product-14.png", 14000L, 100, null, null },
                    { 15, 4, 7, null, new DateTime(2024, 2, 12, 11, 32, 22, 493, DateTimeKind.Local).AddTicks(9102), "Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Maecenas porttitor congue massa. Fusce posuere, magna sed pulvinar ultricies, purus lectus malesuada libero, sit amet commodo magna eros quis urna.", false, "Case Corsair", "/images/products/product-15.png", 15000L, 100, null, null },
                    { 16, 5, 3, null, new DateTime(2024, 2, 12, 11, 32, 22, 493, DateTimeKind.Local).AddTicks(9104), "Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Maecenas porttitor congue massa. Fusce posuere, magna sed pulvinar ultricies, purus lectus malesuada libero, sit amet commodo magna eros quis urna.", false, "LG Ultra Gear", "/images/products/product-16.png", 16000L, 100, null, null },
                    { 17, 5, 3, null, new DateTime(2024, 2, 12, 11, 32, 22, 493, DateTimeKind.Local).AddTicks(9105), "Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Maecenas porttitor congue massa. Fusce posuere, magna sed pulvinar ultricies, purus lectus malesuada libero, sit amet commodo magna eros quis urna.", false, "LG Ultra Gear", "/images/products/product-17.png", 17000L, 100, null, null },
                    { 18, 6, 3, null, new DateTime(2024, 2, 12, 11, 32, 22, 493, DateTimeKind.Local).AddTicks(9108), "Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Maecenas porttitor congue massa. Fusce posuere, magna sed pulvinar ultricies, purus lectus malesuada libero, sit amet commodo magna eros quis urna.", false, "MSI 27", "/images/products/product-18.png", 18000L, 100, null, null },
                    { 19, 7, 3, null, new DateTime(2024, 2, 12, 11, 32, 22, 493, DateTimeKind.Local).AddTicks(9110), "Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Maecenas porttitor congue massa. Fusce posuere, magna sed pulvinar ultricies, purus lectus malesuada libero, sit amet commodo magna eros quis urna.", false, "Viewsonic 24", "/images/products/product-19.png", 19000L, 100, null, null },
                    { 20, 8, 3, null, new DateTime(2024, 2, 12, 11, 32, 22, 493, DateTimeKind.Local).AddTicks(9111), "Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Maecenas porttitor congue massa. Fusce posuere, magna sed pulvinar ultricies, purus lectus malesuada libero, sit amet commodo magna eros quis urna.", false, "Acer 27", "/images/products/product-20.png", 10000L, 100, null, null },
                    { 21, 6, 3, null, new DateTime(2024, 2, 12, 11, 32, 22, 493, DateTimeKind.Local).AddTicks(9113), "Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Maecenas porttitor congue massa. Fusce posuere, magna sed pulvinar ultricies, purus lectus malesuada libero, sit amet commodo magna eros quis urna.", false, "Asus 27 Freesync", "/images/products/product-21.png", 21000L, 100, null, null },
                    { 22, 6, 3, null, new DateTime(2024, 2, 12, 11, 32, 22, 493, DateTimeKind.Local).AddTicks(9115), "Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Maecenas porttitor congue massa. Fusce posuere, magna sed pulvinar ultricies, purus lectus malesuada libero, sit amet commodo magna eros quis urna.", false, "Asus 24 Freesync", "/images/products/product-22.png", 22000L, 100, null, null },
                    { 23, 7, 3, null, new DateTime(2024, 2, 12, 11, 32, 22, 493, DateTimeKind.Local).AddTicks(9117), "Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Maecenas porttitor congue massa. Fusce posuere, magna sed pulvinar ultricies, purus lectus malesuada libero, sit amet commodo magna eros quis urna.", false, "Viewsonic 24 Freesync", "/images/products/product-23.png", 23000L, 100, null, null },
                    { 24, 7, 3, null, new DateTime(2024, 2, 12, 11, 32, 22, 493, DateTimeKind.Local).AddTicks(9118), "Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Maecenas porttitor congue massa. Fusce posuere, magna sed pulvinar ultricies, purus lectus malesuada libero, sit amet commodo magna eros quis urna.", false, "Viewsonic 24 Freesync 75Hz", "/images/products/product-24.png", 24000L, 100, null, null },
                    { 25, 6, 3, null, new DateTime(2024, 2, 12, 11, 32, 22, 493, DateTimeKind.Local).AddTicks(9120), "Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Maecenas porttitor congue massa. Fusce posuere, magna sed pulvinar ultricies, purus lectus malesuada libero, sit amet commodo magna eros quis urna.", false, "Asus TUF Gaming 24", "/images/products/product-25.png", 25000L, 100, null, null },
                    { 26, 3, 3, null, new DateTime(2024, 2, 12, 11, 32, 22, 493, DateTimeKind.Local).AddTicks(9122), "Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Maecenas porttitor congue massa. Fusce posuere, magna sed pulvinar ultricies, purus lectus malesuada libero, sit amet commodo magna eros quis urna.", false, "Gigabyte 24", "/images/products/product-26.png", 26000L, 100, null, null },
                    { 27, 6, 3, null, new DateTime(2024, 2, 12, 11, 32, 22, 493, DateTimeKind.Local).AddTicks(9124), "Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Maecenas porttitor congue massa. Fusce posuere, magna sed pulvinar ultricies, purus lectus malesuada libero, sit amet commodo magna eros quis urna.", false, "Asus GM27", "/images/products/product-27.png", 27000L, 100, null, null },
                    { 28, 8, 3, null, new DateTime(2024, 2, 12, 11, 32, 22, 493, DateTimeKind.Local).AddTicks(9126), "Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Maecenas porttitor congue massa. Fusce posuere, magna sed pulvinar ultricies, purus lectus malesuada libero, sit amet commodo magna eros quis urna.", false, "Acer 75hz 27", "/images/products/product-28.png", 28000L, 100, null, null },
                    { 29, 5, 3, null, new DateTime(2024, 2, 12, 11, 32, 22, 493, DateTimeKind.Local).AddTicks(9127), "Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Maecenas porttitor congue massa. Fusce posuere, magna sed pulvinar ultricies, purus lectus malesuada libero, sit amet commodo magna eros quis urna.", false, "LG 75hz 27", "/images/products/product-29.png", 29000L, 100, null, null },
                    { 30, 6, 3, null, new DateTime(2024, 2, 12, 11, 32, 22, 493, DateTimeKind.Local).AddTicks(9129), "Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Maecenas porttitor congue massa. Fusce posuere, magna sed pulvinar ultricies, purus lectus malesuada libero, sit amet commodo magna eros quis urna.", false, "Asus 100hz 27", "/images/products/product-30.png", 30000L, 100, null, null }
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
                columns: new[] { "Id", "ClientSecret", "CreatedDate", "IsDeleted", "PaymentIntenId", "UpdatedBy", "UpdatedDate", "UserId" },
                values: new object[,]
                {
                    { 1, null, new DateTime(2024, 2, 12, 11, 32, 22, 482, DateTimeKind.Local).AddTicks(4881), false, null, null, null, "d68dcb5f-2706-4cb5-bb0b-37bf39400420" },
                    { 2, null, new DateTime(2024, 2, 12, 11, 32, 22, 482, DateTimeKind.Local).AddTicks(4890), false, null, null, null, "94a12a30-1a9b-48ad-950d-29f80865003d" },
                    { 3, null, new DateTime(2024, 2, 12, 11, 32, 22, 482, DateTimeKind.Local).AddTicks(4906), false, null, null, null, "f222bfbf-86bf-4b65-9958-bc818ba5f822" }
                });

            migrationBuilder.InsertData(
                table: "Token",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "ExpiresAt", "IPAddress", "IsDeleted", "RefreshToken", "UpdatedBy", "UpdatedDate", "UserAgent", "UserId" },
                values: new object[,]
                {
                    { 1, null, new DateTime(2024, 2, 12, 11, 32, 22, 494, DateTimeKind.Local).AddTicks(1682), new DateTime(2024, 2, 12, 11, 32, 22, 494, DateTimeKind.Local).AddTicks(1688), "192.168.0.1", false, "", null, null, "Chrome/91.0.4472.124", "d68dcb5f-2706-4cb5-bb0b-37bf39400420" },
                    { 2, null, new DateTime(2024, 2, 12, 11, 32, 22, 494, DateTimeKind.Local).AddTicks(1692), new DateTime(2024, 2, 12, 11, 32, 22, 494, DateTimeKind.Local).AddTicks(1694), "192.168.0.2", false, "", null, null, "Mozilla/5.0 (Windows NT 10.0; Win64; x64)", "d68dcb5f-2706-4cb5-bb0b-37bf39400420" },
                    { 3, null, new DateTime(2024, 2, 12, 11, 32, 22, 494, DateTimeKind.Local).AddTicks(1695), new DateTime(2024, 2, 12, 11, 32, 22, 494, DateTimeKind.Local).AddTicks(1696), "192.168.0.3", false, "", null, null, "Safari/537.36", "94a12a30-1a9b-48ad-950d-29f80865003d" }
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
                    { 1, null, new DateTime(2024, 2, 12, 11, 32, 22, 494, DateTimeKind.Local).AddTicks(7826), false, 1, 1, 3, null, null },
                    { 2, null, new DateTime(2024, 2, 12, 11, 32, 22, 494, DateTimeKind.Local).AddTicks(7832), false, 2, 1, 3, null, null },
                    { 3, null, new DateTime(2024, 2, 12, 11, 32, 22, 494, DateTimeKind.Local).AddTicks(7833), false, 3, 1, 3, null, null },
                    { 4, null, new DateTime(2024, 2, 12, 11, 32, 22, 494, DateTimeKind.Local).AddTicks(7834), false, 3, 2, 3, null, null },
                    { 5, null, new DateTime(2024, 2, 12, 11, 32, 22, 494, DateTimeKind.Local).AddTicks(7835), false, 3, 3, 3, null, null },
                    { 6, null, new DateTime(2024, 2, 12, 11, 32, 22, 494, DateTimeKind.Local).AddTicks(7836), false, 3, 4, 3, null, null }
                });

            migrationBuilder.InsertData(
                table: "ShoppingCartItem",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "IsDeleted", "ItemId", "Quantity", "ShoppingCartID", "UpdatedBy", "UpdatedDate" },
                values: new object[,]
                {
                    { 1, null, new DateTime(2024, 2, 12, 11, 32, 22, 482, DateTimeKind.Local).AddTicks(7751), false, 1, 3, 1, null, null },
                    { 2, null, new DateTime(2024, 2, 12, 11, 32, 22, 482, DateTimeKind.Local).AddTicks(7757), false, 2, 3, 1, null, null },
                    { 3, null, new DateTime(2024, 2, 12, 11, 32, 22, 482, DateTimeKind.Local).AddTicks(7759), false, 3, 3, 1, null, null },
                    { 4, null, new DateTime(2024, 2, 12, 11, 32, 22, 482, DateTimeKind.Local).AddTicks(7759), false, 1, 3, 2, null, null },
                    { 5, null, new DateTime(2024, 2, 12, 11, 32, 22, 482, DateTimeKind.Local).AddTicks(7760), false, 2, 3, 2, null, null },
                    { 6, null, new DateTime(2024, 2, 12, 11, 32, 22, 482, DateTimeKind.Local).AddTicks(7761), false, 3, 3, 2, null, null },
                    { 7, null, new DateTime(2024, 2, 12, 11, 32, 22, 482, DateTimeKind.Local).AddTicks(7762), false, 1, 3, 3, null, null },
                    { 8, null, new DateTime(2024, 2, 12, 11, 32, 22, 482, DateTimeKind.Local).AddTicks(7763), false, 2, 3, 3, null, null },
                    { 9, null, new DateTime(2024, 2, 12, 11, 32, 22, 482, DateTimeKind.Local).AddTicks(7764), false, 3, 3, 3, null, null }
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
