using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Shopping_Store_API.Migrations
{
    public partial class v1 : Migration
    {
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
                    PublicIdCloudary = table.Column<string>(type: "nvarchar(max)", nullable: true),
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
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Total = table.Column<long>(type: "bigint", nullable: false),
                    OrderStatus = table.Column<int>(type: "int", nullable: false),
                    PaymentIntenId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MomoRequestId = table.Column<string>(type: "nvarchar(max)", nullable: true),
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
                    ClientSecret = table.Column<string>(type: "nvarchar(max)", nullable: true)
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
                    OrderID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
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
                    { 1, null, new DateTime(2024, 3, 1, 9, 26, 51, 609, DateTimeKind.Local).AddTicks(7946), false, "Dell", null, null },
                    { 2, null, new DateTime(2024, 3, 1, 9, 26, 51, 609, DateTimeKind.Local).AddTicks(7950), false, "Apple", null, null },
                    { 3, null, new DateTime(2024, 3, 1, 9, 26, 51, 609, DateTimeKind.Local).AddTicks(7951), false, "Gigabyte", null, null },
                    { 4, null, new DateTime(2024, 3, 1, 9, 26, 51, 609, DateTimeKind.Local).AddTicks(7952), false, "Corsair", null, null },
                    { 5, null, new DateTime(2024, 3, 1, 9, 26, 51, 609, DateTimeKind.Local).AddTicks(7953), false, "LG", null, null },
                    { 6, null, new DateTime(2024, 3, 1, 9, 26, 51, 609, DateTimeKind.Local).AddTicks(7954), false, "Asus", null, null },
                    { 7, null, new DateTime(2024, 3, 1, 9, 26, 51, 609, DateTimeKind.Local).AddTicks(7955), false, "Viewsonic", null, null },
                    { 8, null, new DateTime(2024, 3, 1, 9, 26, 51, 609, DateTimeKind.Local).AddTicks(7956), false, "Acer", null, null }
                });

            migrationBuilder.InsertData(
                table: "Category",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "IsDeleted", "Name", "UpdatedBy", "UpdatedDate" },
                values: new object[,]
                {
                    { 1, null, new DateTime(2024, 3, 1, 9, 26, 51, 609, DateTimeKind.Local).AddTicks(8018), false, "Laptop", null, null },
                    { 2, null, new DateTime(2024, 3, 1, 9, 26, 51, 609, DateTimeKind.Local).AddTicks(8021), false, "Ipad", null, null },
                    { 3, null, new DateTime(2024, 3, 1, 9, 26, 51, 609, DateTimeKind.Local).AddTicks(8022), false, "Screen", null, null },
                    { 4, null, new DateTime(2024, 3, 1, 9, 26, 51, 609, DateTimeKind.Local).AddTicks(8023), false, "Iphone", null, null },
                    { 5, null, new DateTime(2024, 3, 1, 9, 26, 51, 609, DateTimeKind.Local).AddTicks(8023), false, "Macbook", null, null },
                    { 6, null, new DateTime(2024, 3, 1, 9, 26, 51, 609, DateTimeKind.Local).AddTicks(8024), false, "Mainboard", null, null },
                    { 7, null, new DateTime(2024, 3, 1, 9, 26, 51, 609, DateTimeKind.Local).AddTicks(8026), false, "Case", null, null }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "44bc1c18-51a6-46b0-8e20-0df40a2ae0b9", "7c032900-506e-4313-a6fb-5d4ddebee860", "Admin", "ADMIN" },
                    { "4d267d01-3ce5-44d4-bf99-a3fd2172ba17", "b85cc498-038f-4eb1-9919-700385d65bf7", "User", "USER" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AccessFailedCount", "Birthday", "ConcurrencyStamp", "Email", "EmailConfirmed", "FullName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "d68dcb5f-2706-4cb5-bb0b-37bf39400420", 0, null, "bb12e202-ebb6-4c37-a1f8-653c40e5c3b4", "admin@gmail.com", false, "admin", false, null, null, null, "AQAAAAEAACcQAAAAEORqsu30Xu2m4FyF5WRg8ScZ6GZOtWBBeEVNO3Hgfq03k/bjHmUAKOh0SWJRkMjVdA==", null, false, "12a856eb-bdb9-444d-b41b-aefae37250c0", false, "admin@gmail.com" });

            migrationBuilder.InsertData(
                table: "Address",
                columns: new[] { "Id", "AddressName", "City", "CreatedBy", "CreatedDate", "IsDeleted", "UpdatedBy", "UpdatedDate", "UserId", "isDefault" },
                values: new object[,]
                {
                    { 1, "172/26 Ly Thai To, Q.3", "HCM", null, new DateTime(2024, 3, 1, 9, 26, 51, 610, DateTimeKind.Local).AddTicks(1353), false, null, null, "d68dcb5f-2706-4cb5-bb0b-37bf39400420", true },
                    { 2, "175 Duong so 1, Go Vap", "HCM", null, new DateTime(2024, 3, 1, 9, 26, 51, 610, DateTimeKind.Local).AddTicks(1360), false, null, null, "d68dcb5f-2706-4cb5-bb0b-37bf39400420", false }
                });

            migrationBuilder.InsertData(
                table: "Product",
                columns: new[] { "Id", "BrandID", "CategoryID", "CreatedBy", "CreatedDate", "Description", "IsDeleted", "Name", "PictureUrl", "Price", "PublicIdCloudary", "QuantityInStock", "UpdatedBy", "UpdatedDate" },
                values: new object[,]
                {
                    { 1, 1, 1, null, new DateTime(2024, 3, 1, 9, 26, 51, 609, DateTimeKind.Local).AddTicks(7678), "Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Maecenas porttitor congue massa. Fusce posuere, magna sed pulvinar ultricies, purus lectus malesuada libero, sit amet commodo magna eros quis urna.", false, "Dell Latitude 7320", "https://res.cloudinary.com/donrlyxgv/image/upload/v1708693471/shopee/products/jqyuena1vpsuojaht4vu.png", 1000L, null, 100, null, null },
                    { 2, 1, 1, null, new DateTime(2024, 3, 1, 9, 26, 51, 609, DateTimeKind.Local).AddTicks(7695), "Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Maecenas porttitor congue massa. Fusce posuere, magna sed pulvinar ultricies, purus lectus malesuada libero, sit amet commodo magna eros quis urna.", false, "Dell Latitude 7330", "https://res.cloudinary.com/donrlyxgv/image/upload/v1708693471/shopee/products/n28l0eh9rjx2bihtxoy5.jpg", 2000L, null, 100, null, null },
                    { 3, 1, 1, null, new DateTime(2024, 3, 1, 9, 26, 51, 609, DateTimeKind.Local).AddTicks(7699), "Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Maecenas porttitor congue massa. Fusce posuere, magna sed pulvinar ultricies, purus lectus malesuada libero, sit amet commodo magna eros quis urna.", false, "Dell Inspiron 6430", "https://res.cloudinary.com/donrlyxgv/image/upload/v1708693472/shopee/products/hpgz7xlaqa52xo7ubjw9.png", 3000L, null, 100, null, null },
                    { 4, 1, 1, null, new DateTime(2024, 3, 1, 9, 26, 51, 609, DateTimeKind.Local).AddTicks(7701), "Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Maecenas porttitor congue massa. Fusce posuere, magna sed pulvinar ultricies, purus lectus malesuada libero, sit amet commodo magna eros quis urna.", false, "Dell Inspiron 6530", "https://res.cloudinary.com/donrlyxgv/image/upload/v1708693472/shopee/products/enebiqezhcup3lgkcstb.png", 4000L, null, 100, null, null },
                    { 5, 2, 2, null, new DateTime(2024, 3, 1, 9, 26, 51, 609, DateTimeKind.Local).AddTicks(7703), "Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Maecenas porttitor congue massa. Fusce posuere, magna sed pulvinar ultricies, purus lectus malesuada libero, sit amet commodo magna eros quis urna.", false, "Ipad M1 12.9", "https://res.cloudinary.com/donrlyxgv/image/upload/v1708693472/shopee/products/gpomm9nf5w3w4juiooiv.png", 5000L, null, 100, null, null },
                    { 6, 2, 2, null, new DateTime(2024, 3, 1, 9, 26, 51, 609, DateTimeKind.Local).AddTicks(7705), "Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Maecenas porttitor congue massa. Fusce posuere, magna sed pulvinar ultricies, purus lectus malesuada libero, sit amet commodo magna eros quis urna.", false, "Ipad M1 12.9", "https://res.cloudinary.com/donrlyxgv/image/upload/v1708693472/shopee/products/yysgxkbqiufbui1hb9si.jpg", 6000L, null, 100, null, null },
                    { 7, 1, 3, null, new DateTime(2024, 3, 1, 9, 26, 51, 609, DateTimeKind.Local).AddTicks(7706), "Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Maecenas porttitor congue massa. Fusce posuere, magna sed pulvinar ultricies, purus lectus malesuada libero, sit amet commodo magna eros quis urna.", false, "Dell Screen 27inch", "https://res.cloudinary.com/donrlyxgv/image/upload/v1708693472/shopee/products/wsb51zjp5mc4wqbfxatp.png", 7000L, null, 100, null, null },
                    { 8, 1, 3, null, new DateTime(2024, 3, 1, 9, 26, 51, 609, DateTimeKind.Local).AddTicks(7709), "Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Maecenas porttitor congue massa. Fusce posuere, magna sed pulvinar ultricies, purus lectus malesuada libero, sit amet commodo magna eros quis urna.", false, "Dell Screen 27inch", "https://res.cloudinary.com/donrlyxgv/image/upload/v1708693473/shopee/products/teghmyo3k3hdkau9qne7.png", 8000L, null, 100, null, null },
                    { 9, 2, 4, null, new DateTime(2024, 3, 1, 9, 26, 51, 609, DateTimeKind.Local).AddTicks(7710), "Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Maecenas porttitor congue massa. Fusce posuere, magna sed pulvinar ultricies, purus lectus malesuada libero, sit amet commodo magna eros quis urna.", false, "Iphone 14 Pro Max", "https://res.cloudinary.com/donrlyxgv/image/upload/v1708693473/shopee/products/i39drgkscnglo4qh6tvr.jpg", 9000L, null, 100, null, null },
                    { 10, 2, 4, null, new DateTime(2024, 3, 1, 9, 26, 51, 609, DateTimeKind.Local).AddTicks(7711), "Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Maecenas porttitor congue massa. Fusce posuere, magna sed pulvinar ultricies, purus lectus malesuada libero, sit amet commodo magna eros quis urna.", false, "Iphone 14 Pro Max", "https://res.cloudinary.com/donrlyxgv/image/upload/v1708693473/shopee/products/iwoww4fcebhsximqr2e7.jpg", 10000L, null, 100, null, null },
                    { 11, 2, 5, null, new DateTime(2024, 3, 1, 9, 26, 51, 609, DateTimeKind.Local).AddTicks(7713), "Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Maecenas porttitor congue massa. Fusce posuere, magna sed pulvinar ultricies, purus lectus malesuada libero, sit amet commodo magna eros quis urna.", false, "Macbook Air M1", "https://res.cloudinary.com/donrlyxgv/image/upload/v1708693473/shopee/products/bsca35kdtcrrsrahalrb.jpg", 11000L, null, 100, null, null },
                    { 12, 2, 5, null, new DateTime(2024, 3, 1, 9, 26, 51, 609, DateTimeKind.Local).AddTicks(7714), "Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Maecenas porttitor congue massa. Fusce posuere, magna sed pulvinar ultricies, purus lectus malesuada libero, sit amet commodo magna eros quis urna.", false, "Macbook Air M1", "https://res.cloudinary.com/donrlyxgv/image/upload/v1708693474/shopee/products/eiwqbjg53c1iiyfyuubx.png", 12000L, null, 100, null, null },
                    { 13, 3, 6, null, new DateTime(2024, 3, 1, 9, 26, 51, 609, DateTimeKind.Local).AddTicks(7716), "Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Maecenas porttitor congue massa. Fusce posuere, magna sed pulvinar ultricies, purus lectus malesuada libero, sit amet commodo magna eros quis urna.", false, "Mainboard Gigabyte 6330", "https://res.cloudinary.com/donrlyxgv/image/upload/v1708693474/shopee/products/vhxrw4q797mox11xllpf.png", 13000L, null, 100, null, null },
                    { 14, 3, 6, null, new DateTime(2024, 3, 1, 9, 26, 51, 609, DateTimeKind.Local).AddTicks(7717), "Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Maecenas porttitor congue massa. Fusce posuere, magna sed pulvinar ultricies, purus lectus malesuada libero, sit amet commodo magna eros quis urna.", false, "Mainboard Gigabyte 6330", "https://res.cloudinary.com/donrlyxgv/image/upload/v1708693471/shopee/products/jxdj5mfcy47ee0bwfmnp.webp", 14000L, null, 100, null, null },
                    { 15, 4, 7, null, new DateTime(2024, 3, 1, 9, 26, 51, 609, DateTimeKind.Local).AddTicks(7795), "Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Maecenas porttitor congue massa. Fusce posuere, magna sed pulvinar ultricies, purus lectus malesuada libero, sit amet commodo magna eros quis urna.", false, "Case Corsair", "https://res.cloudinary.com/donrlyxgv/image/upload/v1708693471/shopee/products/iilp2mh1066ifpxiluur.png", 15000L, null, 100, null, null },
                    { 16, 5, 3, null, new DateTime(2024, 3, 1, 9, 26, 51, 609, DateTimeKind.Local).AddTicks(7798), "Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Maecenas porttitor congue massa. Fusce posuere, magna sed pulvinar ultricies, purus lectus malesuada libero, sit amet commodo magna eros quis urna.", false, "LG Ultra Gear", "https://res.cloudinary.com/donrlyxgv/image/upload/v1708693471/shopee/products/x8nbir1cb3vymmubj0qd.webp", 16000L, null, 100, null, null },
                    { 17, 5, 3, null, new DateTime(2024, 3, 1, 9, 26, 51, 609, DateTimeKind.Local).AddTicks(7801), "Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Maecenas porttitor congue massa. Fusce posuere, magna sed pulvinar ultricies, purus lectus malesuada libero, sit amet commodo magna eros quis urna.", false, "LG Ultra Gear", "https://res.cloudinary.com/donrlyxgv/image/upload/v1708693472/shopee/products/kvk93lqt9iyjfnbhf39u.webp", 17000L, null, 100, null, null },
                    { 18, 6, 3, null, new DateTime(2024, 3, 1, 9, 26, 51, 609, DateTimeKind.Local).AddTicks(7802), "Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Maecenas porttitor congue massa. Fusce posuere, magna sed pulvinar ultricies, purus lectus malesuada libero, sit amet commodo magna eros quis urna.", false, "MSI 27", "https://res.cloudinary.com/donrlyxgv/image/upload/v1708693472/shopee/products/k5uu8rmgex2g8nr45ldi.webp", 18000L, null, 100, null, null },
                    { 19, 7, 3, null, new DateTime(2024, 3, 1, 9, 26, 51, 609, DateTimeKind.Local).AddTicks(7803), "Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Maecenas porttitor congue massa. Fusce posuere, magna sed pulvinar ultricies, purus lectus malesuada libero, sit amet commodo magna eros quis urna.", false, "Viewsonic 24", "https://res.cloudinary.com/donrlyxgv/image/upload/v1708693472/shopee/products/v01sbaf9rbkzw8yhtdwv.webp", 19000L, null, 100, null, null },
                    { 20, 8, 3, null, new DateTime(2024, 3, 1, 9, 26, 51, 609, DateTimeKind.Local).AddTicks(7805), "Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Maecenas porttitor congue massa. Fusce posuere, magna sed pulvinar ultricies, purus lectus malesuada libero, sit amet commodo magna eros quis urna.", false, "Acer 27", "https://res.cloudinary.com/donrlyxgv/image/upload/v1708693473/shopee/products/njtxjkkamuulhb4alvdg.webp", 10000L, null, 100, null, null },
                    { 21, 6, 3, null, new DateTime(2024, 3, 1, 9, 26, 51, 609, DateTimeKind.Local).AddTicks(7806), "Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Maecenas porttitor congue massa. Fusce posuere, magna sed pulvinar ultricies, purus lectus malesuada libero, sit amet commodo magna eros quis urna.", false, "Asus 27 Freesync", "https://res.cloudinary.com/donrlyxgv/image/upload/v1708693473/shopee/products/jhxgm22du9zgbe2sw5zc.webp", 21000L, null, 100, null, null },
                    { 22, 6, 3, null, new DateTime(2024, 3, 1, 9, 26, 51, 609, DateTimeKind.Local).AddTicks(7807), "Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Maecenas porttitor congue massa. Fusce posuere, magna sed pulvinar ultricies, purus lectus malesuada libero, sit amet commodo magna eros quis urna.", false, "Asus 24 Freesync", "https://res.cloudinary.com/donrlyxgv/image/upload/v1708693474/shopee/products/lrjtodqgvmojr94durpt.webp", 22000L, null, 100, null, null },
                    { 23, 7, 3, null, new DateTime(2024, 3, 1, 9, 26, 51, 609, DateTimeKind.Local).AddTicks(7808), "Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Maecenas porttitor congue massa. Fusce posuere, magna sed pulvinar ultricies, purus lectus malesuada libero, sit amet commodo magna eros quis urna.", false, "Viewsonic 24 Freesync", "https://res.cloudinary.com/donrlyxgv/image/upload/v1708693474/shopee/products/tihrkueyfuawaaob6f0g.webp", 23000L, null, 100, null, null },
                    { 24, 7, 3, null, new DateTime(2024, 3, 1, 9, 26, 51, 609, DateTimeKind.Local).AddTicks(7809), "Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Maecenas porttitor congue massa. Fusce posuere, magna sed pulvinar ultricies, purus lectus malesuada libero, sit amet commodo magna eros quis urna.", false, "Viewsonic 24 Freesync 75Hz", "https://res.cloudinary.com/donrlyxgv/image/upload/v1708693474/shopee/products/timgmpaw7v0i9gpx0ayv.webp", 24000L, null, 100, null, null },
                    { 25, 6, 3, null, new DateTime(2024, 3, 1, 9, 26, 51, 609, DateTimeKind.Local).AddTicks(7811), "Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Maecenas porttitor congue massa. Fusce posuere, magna sed pulvinar ultricies, purus lectus malesuada libero, sit amet commodo magna eros quis urna.", false, "Asus TUF Gaming 24", "https://res.cloudinary.com/donrlyxgv/image/upload/v1708693474/shopee/products/tmjzsdvpgixl7dedthkm.webp", 25000L, null, 100, null, null },
                    { 26, 3, 3, null, new DateTime(2024, 3, 1, 9, 26, 51, 609, DateTimeKind.Local).AddTicks(7812), "Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Maecenas porttitor congue massa. Fusce posuere, magna sed pulvinar ultricies, purus lectus malesuada libero, sit amet commodo magna eros quis urna.", false, "Gigabyte 24", "https://res.cloudinary.com/donrlyxgv/image/upload/v1708693474/shopee/products/ncpg1p2grvu9mbj66gh4.webp", 26000L, null, 100, null, null },
                    { 27, 6, 3, null, new DateTime(2024, 3, 1, 9, 26, 51, 609, DateTimeKind.Local).AddTicks(7813), "Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Maecenas porttitor congue massa. Fusce posuere, magna sed pulvinar ultricies, purus lectus malesuada libero, sit amet commodo magna eros quis urna.", false, "Asus GM27", "https://res.cloudinary.com/donrlyxgv/image/upload/v1708693476/shopee/products/qmauhpz1jych8vf6g2hb.webp", 27000L, null, 100, null, null },
                    { 28, 8, 3, null, new DateTime(2024, 3, 1, 9, 26, 51, 609, DateTimeKind.Local).AddTicks(7816), "Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Maecenas porttitor congue massa. Fusce posuere, magna sed pulvinar ultricies, purus lectus malesuada libero, sit amet commodo magna eros quis urna.", false, "Acer 75hz 27", "https://res.cloudinary.com/donrlyxgv/image/upload/v1708693474/shopee/products/qamr31r8gxd9rfcxkaiw.webp", 28000L, null, 100, null, null },
                    { 29, 5, 3, null, new DateTime(2024, 3, 1, 9, 26, 51, 609, DateTimeKind.Local).AddTicks(7817), "Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Maecenas porttitor congue massa. Fusce posuere, magna sed pulvinar ultricies, purus lectus malesuada libero, sit amet commodo magna eros quis urna.", false, "LG 75hz 27", "https://res.cloudinary.com/donrlyxgv/image/upload/v1708693475/shopee/products/gwt4kwqllyybkrwofd1m.webp", 29000L, null, 100, null, null },
                    { 30, 6, 3, null, new DateTime(2024, 3, 1, 9, 26, 51, 609, DateTimeKind.Local).AddTicks(7818), "Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Maecenas porttitor congue massa. Fusce posuere, magna sed pulvinar ultricies, purus lectus malesuada libero, sit amet commodo magna eros quis urna.", false, "Asus 100hz 27", "https://res.cloudinary.com/donrlyxgv/image/upload/v1708693475/shopee/products/feqpxb8w3aw97cwq3d8v.webp", 30000L, null, 100, null, null }
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
                columns: new[] { "Id", "ClientSecret", "PaymentIntenId", "UserId" },
                values: new object[] { 1, null, null, "d68dcb5f-2706-4cb5-bb0b-37bf39400420" });

            migrationBuilder.InsertData(
                table: "UserClaims",
                columns: new[] { "Id", "ClaimType", "ClaimValue", "UserId" },
                values: new object[] { 1, "Country", "VN", "d68dcb5f-2706-4cb5-bb0b-37bf39400420" });

            migrationBuilder.InsertData(
                table: "UserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "44bc1c18-51a6-46b0-8e20-0df40a2ae0b9", "d68dcb5f-2706-4cb5-bb0b-37bf39400420" },
                    { "4d267d01-3ce5-44d4-bf99-a3fd2172ba17", "d68dcb5f-2706-4cb5-bb0b-37bf39400420" }
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
