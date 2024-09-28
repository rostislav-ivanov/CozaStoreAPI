using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CozaStoreAPI.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class _01 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    FirstName = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false, comment: "First Name"),
                    LastName = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false, comment: "Last Name"),
                    ShippingCity = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false, comment: "User's shipping city"),
                    ShippingOffice = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false, comment: "User's shipping office"),
                    UserName = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "boolean", nullable: false),
                    PasswordHash = table.Column<string>(type: "text", nullable: true),
                    SecurityStamp = table.Column<string>(type: "text", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "text", nullable: true),
                    PhoneNumber = table.Column<string>(type: "text", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "boolean", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "boolean", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "boolean", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false, comment: "The category's primary key")
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false, comment: "The category's name")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                },
                comment: "The category of the product");

            migrationBuilder.CreateTable(
                name: "Colors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false, comment: "The color's primary key")
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false, comment: "The color's name")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Colors", x => x.Id);
                },
                comment: "The color of the product");

            migrationBuilder.CreateTable(
                name: "EcontCities",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false, comment: "Shipping city Id"),
                    Name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false, comment: "Name of shipping city")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EcontCities", x => x.Id);
                },
                comment: "Table of shipping cities");

            migrationBuilder.CreateTable(
                name: "Messages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false, comment: "Primary key")
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Email = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false, comment: "Email of the user"),
                    FirstName = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false, comment: "First name of the user"),
                    LastName = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false, comment: "Last name of the user"),
                    Subject = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false, comment: "Subject of the message"),
                    Content = table.Column<string>(type: "character varying(1000)", maxLength: 1000, nullable: false, comment: "Content of the message")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Messages", x => x.Id);
                },
                comment: "Table of messages from users");

            migrationBuilder.CreateTable(
                name: "Sizes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false, comment: "The size's primary key")
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false, comment: "The size's name")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sizes", x => x.Id);
                },
                comment: "The size of the product");

            migrationBuilder.CreateTable(
                name: "StatusOrders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false, comment: "Primary key")
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false, comment: "Name of the status")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StatusOrders", x => x.Id);
                },
                comment: "Status of the order");

            migrationBuilder.CreateTable(
                name: "Subscribes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Email = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Subscribes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    RoleId = table.Column<Guid>(type: "uuid", nullable: false),
                    ClaimType = table.Column<string>(type: "text", nullable: true),
                    ClaimValue = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserId = table.Column<Guid>(type: "uuid", nullable: false),
                    ClaimType = table.Column<string>(type: "text", nullable: true),
                    ClaimValue = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "text", nullable: false),
                    ProviderKey = table.Column<string>(type: "text", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "text", nullable: true),
                    UserId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uuid", nullable: false),
                    RoleId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uuid", nullable: false),
                    LoginProvider = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Value = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false, comment: "The product's primary key")
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false, comment: "The product's name"),
                    Description = table.Column<string>(type: "character varying(2000)", maxLength: 2000, nullable: false, comment: "The product's description"),
                    Price = table.Column<decimal>(type: "numeric(18,2)", nullable: false, comment: "The product's price"),
                    CategoryId = table.Column<int>(type: "integer", nullable: true, comment: "The product's category id"),
                    Material = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false, comment: "The product's material"),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false, comment: "The product is deleted or not"),
                    CreatedAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false, comment: "The product's created date"),
                    UpdatedAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false, comment: "The product's updated date")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Products_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id");
                },
                comment: "The product");

            migrationBuilder.CreateTable(
                name: "EcontOffices",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false, comment: "Shipping office Id"),
                    Name = table.Column<string>(type: "character varying(300)", maxLength: 300, nullable: false, comment: "Name of office city"),
                    CityId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EcontOffices", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EcontOffices_EcontCities_CityId",
                        column: x => x.CityId,
                        principalTable: "EcontCities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                },
                comment: "Table of shipping cities");

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false, comment: "Order Id")
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    AppUserId = table.Column<Guid>(type: "uuid", nullable: false, comment: "App User Id"),
                    OrderNumber = table.Column<string>(type: "text", nullable: false, comment: "Order Number"),
                    CreatedOn = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false, comment: "Date of Order Creating"),
                    StatusOrderId = table.Column<int>(type: "integer", nullable: false, comment: "Status of Order"),
                    DateShipping = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true, comment: "Date of Shipping Creating"),
                    TrackingNumber = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: true, comment: "Tracking Number of Order"),
                    IsPaid = table.Column<bool>(type: "boolean", nullable: false, comment: "Is Paid Order"),
                    ShippingPrice = table.Column<decimal>(type: "numeric(18,2)", nullable: false, comment: "Shipping Price"),
                    TotalPrice = table.Column<decimal>(type: "numeric(18,2)", nullable: false, comment: "Total Price"),
                    FirstName = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false, comment: "First Name Recipient"),
                    LastName = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false, comment: "Last Name Recipient"),
                    PhoneNumber = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false, comment: "Phone Number Recipient"),
                    ShippingProvider = table.Column<string>(type: "text", nullable: true, comment: "Shipping Provider"),
                    ShippingCity = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true, comment: "City Recipient"),
                    ShippingOffice = table.Column<string>(type: "character varying(300)", maxLength: 300, nullable: true, comment: "Office Recipient")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Orders_AspNetUsers_AppUserId",
                        column: x => x.AppUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Orders_StatusOrders_StatusOrderId",
                        column: x => x.StatusOrderId,
                        principalTable: "StatusOrders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ImageProducts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false, comment: "The image id")
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ImagePath = table.Column<string>(type: "character varying(300)", maxLength: 300, nullable: false, comment: "The path of the image"),
                    ImageOrder = table.Column<int>(type: "integer", nullable: false, comment: "The image's order in slider"),
                    ProductId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ImageProducts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ImageProducts_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                },
                comment: "The image of the product");

            migrationBuilder.CreateTable(
                name: "ProductsColors",
                columns: table => new
                {
                    ProductId = table.Column<int>(type: "integer", nullable: false, comment: "The product's id"),
                    ColorId = table.Column<int>(type: "integer", nullable: false, comment: "The size's id")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductsColors", x => new { x.ProductId, x.ColorId });
                    table.ForeignKey(
                        name: "FK_ProductsColors_Colors_ColorId",
                        column: x => x.ColorId,
                        principalTable: "Colors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductsColors_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                },
                comment: "Many to many relation between products and colors");

            migrationBuilder.CreateTable(
                name: "ProductsSizes",
                columns: table => new
                {
                    ProductId = table.Column<int>(type: "integer", nullable: false, comment: "The product's id"),
                    SizeId = table.Column<int>(type: "integer", nullable: false, comment: "The size's id")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductsSizes", x => new { x.ProductId, x.SizeId });
                    table.ForeignKey(
                        name: "FK_ProductsSizes_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductsSizes_Sizes_SizeId",
                        column: x => x.SizeId,
                        principalTable: "Sizes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                },
                comment: "Many to many relation between products and sizes");

            migrationBuilder.CreateTable(
                name: "Reviews",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false, comment: "The review's primary key")
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ProductId = table.Column<int>(type: "integer", nullable: false, comment: "The product Id"),
                    AuthorId = table.Column<Guid>(type: "uuid", nullable: false, comment: "The author Id"),
                    Rating = table.Column<int>(type: "integer", nullable: false, comment: "The rating of the review."),
                    Title = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false, comment: "The title of the review."),
                    Comment = table.Column<string>(type: "character varying(1000)", maxLength: 1000, nullable: false, comment: "The comment of the review."),
                    CreatedOn = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false, comment: "The date when the review was created.")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reviews", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Reviews_AspNetUsers_AuthorId",
                        column: x => x.AuthorId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Reviews_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                },
                comment: "The review of the product");

            migrationBuilder.CreateTable(
                name: "Wishes",
                columns: table => new
                {
                    AppUserId = table.Column<Guid>(type: "uuid", nullable: false, comment: "The user id"),
                    ProductId = table.Column<int>(type: "integer", nullable: false, comment: "The product id")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Wishes", x => new { x.AppUserId, x.ProductId });
                    table.ForeignKey(
                        name: "FK_Wishes_AspNetUsers_AppUserId",
                        column: x => x.AppUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Wishes_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                },
                comment: "This table contains the products that the user has added to his wish list");

            migrationBuilder.CreateTable(
                name: "ProductsOrders",
                columns: table => new
                {
                    ProductId = table.Column<int>(type: "integer", nullable: false),
                    OrderId = table.Column<int>(type: "integer", nullable: false),
                    Quantity = table.Column<int>(type: "integer", nullable: false, comment: "The quantity of the product in the order"),
                    Price = table.Column<decimal>(type: "numeric(18,2)", nullable: false, comment: "The price of the product at the time of the order"),
                    ImagePath = table.Column<string>(type: "character varying(300)", maxLength: 300, nullable: true, comment: "The image path of the product at the time of the order"),
                    Size = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true, comment: "The size of the product at the time of the order"),
                    Color = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true, comment: "The color of the product at the time of the order")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductsOrders", x => new { x.ProductId, x.OrderId });
                    table.ForeignKey(
                        name: "FK_ProductsOrders_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductsOrders_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                },
                comment: "Many to many relation between products and orders");

            migrationBuilder.CreateTable(
                name: "ImageReviews",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false, comment: "The image id")
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ImagePath = table.Column<string>(type: "character varying(300)", maxLength: 300, nullable: false, comment: "The path of the image"),
                    ReviewId = table.Column<int>(type: "integer", nullable: false, comment: "The review id")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ImageReviews", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ImageReviews_Reviews_ReviewId",
                        column: x => x.ReviewId,
                        principalTable: "Reviews",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                },
                comment: "The image of the review");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "ShippingCity", "ShippingOffice", "TwoFactorEnabled", "UserName" },
                values: new object[] { new Guid("f415401c-db9c-4e89-bf5f-d75b7e1301fc"), 0, "e00cde30-23dd-4d56-b6f7-2e551a6c02d1", "test@test.com", true, "TestFirstName", "TestLastName", false, null, "TEST@TEST.COM", "TEST@TEST.COM", "AQAAAAIAAYagAAAAEIDV5z3uIpqH0mMSfGi6kA/r+myic+aN4lgo2MfqgLTrcQsA5TBzVMSxjDRRY6WitQ==", "0888 888 888", false, "NNC2KI3MK4ONPNJIS5HUOKHN3565MBID", "", "", false, "test@test.com" });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "women" },
                    { 2, "man" },
                    { 3, "shoes" },
                    { 4, "watches" },
                    { 5, "bag" }
                });

            migrationBuilder.InsertData(
                table: "Colors",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "White" },
                    { 2, "Black" },
                    { 3, "Red" },
                    { 4, "Green" },
                    { 5, "Blue" }
                });

            migrationBuilder.InsertData(
                table: "Sizes",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "XS" },
                    { 2, "S" },
                    { 3, "M" },
                    { 4, "L" },
                    { 5, "XL" },
                    { 6, "36" },
                    { 7, "37" },
                    { 8, "38" },
                    { 9, "39" },
                    { 10, "40" },
                    { 11, "85" },
                    { 12, "90" },
                    { 13, "95" },
                    { 14, "100" }
                });

            migrationBuilder.InsertData(
                table: "StatusOrders",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Неизпълнена" },
                    { 2, "Отменена" },
                    { 3, "Изпълнена" },
                    { 4, "Получена" },
                    { 5, "Върната" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryId", "CreatedAt", "Description", "IsDeleted", "Material", "Name", "Price", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, 1, new DateTimeOffset(new DateTime(2024, 9, 26, 20, 25, 56, 631, DateTimeKind.Unspecified).AddTicks(6660), new TimeSpan(0, 3, 0, 0, 0)), "Description of product Esprit Ruffle Shirt", false, "60% cotton, 40% polyester", "Esprit Ruffle Shirt", 16.64m, new DateTimeOffset(new DateTime(2024, 9, 26, 20, 25, 56, 631, DateTimeKind.Unspecified).AddTicks(6721), new TimeSpan(0, 3, 0, 0, 0)) },
                    { 2, 1, new DateTimeOffset(new DateTime(2024, 9, 26, 20, 25, 56, 631, DateTimeKind.Unspecified).AddTicks(6726), new TimeSpan(0, 3, 0, 0, 0)), "Description of product Herschel supply", false, "60% cotton, 40% polyester", "Herschel supply", 35.31m, new DateTimeOffset(new DateTime(2024, 9, 26, 20, 25, 56, 631, DateTimeKind.Unspecified).AddTicks(6728), new TimeSpan(0, 3, 0, 0, 0)) },
                    { 3, 2, new DateTimeOffset(new DateTime(2024, 9, 26, 20, 25, 56, 631, DateTimeKind.Unspecified).AddTicks(6733), new TimeSpan(0, 3, 0, 0, 0)), "Description of product Only Check Trouser", false, "60% cotton, 40% polyester", "Only Check Trouser", 25.50m, new DateTimeOffset(new DateTime(2024, 9, 26, 20, 25, 56, 631, DateTimeKind.Unspecified).AddTicks(6735), new TimeSpan(0, 3, 0, 0, 0)) },
                    { 4, 1, new DateTimeOffset(new DateTime(2024, 9, 26, 20, 25, 56, 631, DateTimeKind.Unspecified).AddTicks(6739), new TimeSpan(0, 3, 0, 0, 0)), "Description of product Classic Trench Coat", false, "60% cotton, 40% polyester", "Classic Trench Coat", 75.00m, new DateTimeOffset(new DateTime(2024, 9, 26, 20, 25, 56, 631, DateTimeKind.Unspecified).AddTicks(6741), new TimeSpan(0, 3, 0, 0, 0)) },
                    { 5, 1, new DateTimeOffset(new DateTime(2024, 9, 26, 20, 25, 56, 631, DateTimeKind.Unspecified).AddTicks(6746), new TimeSpan(0, 3, 0, 0, 0)), "Description of product Front Pocket Jumper", false, "60% cotton, 40% polyester", "Front Pocket Jumper", 34.75m, new DateTimeOffset(new DateTime(2024, 9, 26, 20, 25, 56, 631, DateTimeKind.Unspecified).AddTicks(6748), new TimeSpan(0, 3, 0, 0, 0)) },
                    { 6, 4, new DateTimeOffset(new DateTime(2024, 9, 26, 20, 25, 56, 631, DateTimeKind.Unspecified).AddTicks(6753), new TimeSpan(0, 3, 0, 0, 0)), "Description of product Vintage Inspired Classic", false, "", "Vintage Inspired Classic", 93.20m, new DateTimeOffset(new DateTime(2024, 9, 26, 20, 25, 56, 631, DateTimeKind.Unspecified).AddTicks(6755), new TimeSpan(0, 3, 0, 0, 0)) },
                    { 7, 1, new DateTimeOffset(new DateTime(2024, 9, 26, 20, 25, 56, 631, DateTimeKind.Unspecified).AddTicks(6759), new TimeSpan(0, 3, 0, 0, 0)), "Description of product Shirt in Stretch Cotton", false, "60% cotton, 40% polyester", "Shirt in Stretch Cotton", 52.66m, new DateTimeOffset(new DateTime(2024, 9, 26, 20, 25, 56, 631, DateTimeKind.Unspecified).AddTicks(6761), new TimeSpan(0, 3, 0, 0, 0)) },
                    { 8, 1, new DateTimeOffset(new DateTime(2024, 9, 26, 20, 25, 56, 631, DateTimeKind.Unspecified).AddTicks(6832), new TimeSpan(0, 3, 0, 0, 0)), "Description of product Pieces Metallic Printed", false, "60% cotton, 40% polyester", "Pieces Metallic Printed", 18.96m, new DateTimeOffset(new DateTime(2024, 9, 26, 20, 25, 56, 631, DateTimeKind.Unspecified).AddTicks(6834), new TimeSpan(0, 3, 0, 0, 0)) },
                    { 9, 3, new DateTimeOffset(new DateTime(2024, 9, 26, 20, 25, 56, 631, DateTimeKind.Unspecified).AddTicks(6839), new TimeSpan(0, 3, 0, 0, 0)), "Description of product Converse All Star Hi Plimsolls", false, "60% cotton, 40% polyester", "Converse All Star Hi Plimsolls", 75.00m, new DateTimeOffset(new DateTime(2024, 9, 26, 20, 25, 56, 631, DateTimeKind.Unspecified).AddTicks(6841), new TimeSpan(0, 3, 0, 0, 0)) },
                    { 10, 1, new DateTimeOffset(new DateTime(2024, 9, 26, 20, 25, 56, 631, DateTimeKind.Unspecified).AddTicks(6845), new TimeSpan(0, 3, 0, 0, 0)), "Description of product Femme T-Shirt In Stripe", false, "60% cotton, 40% polyester", "Femme T-Shirt In Stripe", 25.85m, new DateTimeOffset(new DateTime(2024, 9, 26, 20, 25, 56, 631, DateTimeKind.Unspecified).AddTicks(6847), new TimeSpan(0, 3, 0, 0, 0)) },
                    { 11, 2, new DateTimeOffset(new DateTime(2024, 9, 26, 20, 25, 56, 631, DateTimeKind.Unspecified).AddTicks(6851), new TimeSpan(0, 3, 0, 0, 0)), "Description of product Herschel supply", false, "60% cotton, 40% polyester", "Herschel supply", 63.16m, new DateTimeOffset(new DateTime(2024, 9, 26, 20, 25, 56, 631, DateTimeKind.Unspecified).AddTicks(6853), new TimeSpan(0, 3, 0, 0, 0)) },
                    { 12, 2, new DateTimeOffset(new DateTime(2024, 9, 26, 20, 25, 56, 631, DateTimeKind.Unspecified).AddTicks(6857), new TimeSpan(0, 3, 0, 0, 0)), "Description of product Herschel supply", false, "100% leather", "Herschel supply", 63.15m, new DateTimeOffset(new DateTime(2024, 9, 26, 20, 25, 56, 631, DateTimeKind.Unspecified).AddTicks(6859), new TimeSpan(0, 3, 0, 0, 0)) },
                    { 13, 1, new DateTimeOffset(new DateTime(2024, 9, 26, 20, 25, 56, 631, DateTimeKind.Unspecified).AddTicks(6863), new TimeSpan(0, 3, 0, 0, 0)), "Description of product T-Shirt with Sleeve", false, "60% cotton, 40% polyester", "T-Shirt with Sleeve", 18.49m, new DateTimeOffset(new DateTime(2024, 9, 26, 20, 25, 56, 631, DateTimeKind.Unspecified).AddTicks(6865), new TimeSpan(0, 3, 0, 0, 0)) },
                    { 14, 1, new DateTimeOffset(new DateTime(2024, 9, 26, 20, 25, 56, 631, DateTimeKind.Unspecified).AddTicks(6869), new TimeSpan(0, 3, 0, 0, 0)), "Description of product Pretty Little Thing", false, "60% cotton, 40% polyester", "Pretty Little Thing", 54.79m, new DateTimeOffset(new DateTime(2024, 9, 26, 20, 25, 56, 631, DateTimeKind.Unspecified).AddTicks(6871), new TimeSpan(0, 3, 0, 0, 0)) },
                    { 15, 4, new DateTimeOffset(new DateTime(2024, 9, 26, 20, 25, 56, 631, DateTimeKind.Unspecified).AddTicks(6875), new TimeSpan(0, 3, 0, 0, 0)), "Description of product Mini Silver Mesh Watch", false, "", "Mini Silver Mesh Watch", 86.85m, new DateTimeOffset(new DateTime(2024, 9, 26, 20, 25, 56, 631, DateTimeKind.Unspecified).AddTicks(6877), new TimeSpan(0, 3, 0, 0, 0)) },
                    { 16, 1, new DateTimeOffset(new DateTime(2024, 9, 26, 20, 25, 56, 631, DateTimeKind.Unspecified).AddTicks(6881), new TimeSpan(0, 3, 0, 0, 0)), "Description of product Square Neck Back", false, "60% cotton, 40% polyester", "Square Neck Back", 29.64m, new DateTimeOffset(new DateTime(2024, 9, 26, 20, 25, 56, 631, DateTimeKind.Unspecified).AddTicks(6883), new TimeSpan(0, 3, 0, 0, 0)) }
                });

            migrationBuilder.InsertData(
                table: "ImageProducts",
                columns: new[] { "Id", "ImageOrder", "ImagePath", "ProductId" },
                values: new object[,]
                {
                    { 1, 1, "/images/product-01.jpg", 1 },
                    { 2, 2, "/images/product-02.jpg", 1 },
                    { 3, 1, "/images/product-02.jpg", 2 },
                    { 4, 1, "/images/product-03.jpg", 3 },
                    { 5, 1, "/images/product-04.jpg", 4 },
                    { 6, 1, "/images/product-05.jpg", 5 },
                    { 7, 1, "/images/product-06.jpg", 6 },
                    { 8, 1, "/images/product-07.jpg", 7 },
                    { 9, 1, "/images/product-08.jpg", 8 },
                    { 10, 1, "/images/product-09.jpg", 9 },
                    { 11, 1, "/images/product-10.jpg", 10 },
                    { 12, 1, "/images/product-11.jpg", 11 },
                    { 13, 1, "/images/product-12.jpg", 12 },
                    { 14, 1, "/images/product-13.jpg", 13 },
                    { 15, 1, "/images/product-14.jpg", 14 },
                    { 16, 1, "/images/product-15.jpg", 15 },
                    { 17, 1, "/images/product-16.jpg", 16 }
                });

            migrationBuilder.InsertData(
                table: "ProductsColors",
                columns: new[] { "ColorId", "ProductId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 2, 1 },
                    { 3, 1 },
                    { 4, 1 },
                    { 5, 1 },
                    { 1, 2 },
                    { 2, 2 },
                    { 3, 2 },
                    { 4, 2 },
                    { 5, 2 },
                    { 1, 3 },
                    { 2, 3 },
                    { 3, 3 },
                    { 4, 3 },
                    { 5, 3 },
                    { 1, 4 },
                    { 2, 4 },
                    { 3, 4 },
                    { 4, 4 },
                    { 5, 4 },
                    { 1, 5 },
                    { 2, 5 },
                    { 3, 5 },
                    { 4, 5 },
                    { 5, 5 },
                    { 1, 7 },
                    { 2, 7 },
                    { 3, 7 },
                    { 4, 7 },
                    { 5, 7 },
                    { 1, 8 },
                    { 2, 8 },
                    { 3, 8 },
                    { 4, 8 },
                    { 5, 8 },
                    { 1, 9 },
                    { 2, 9 },
                    { 3, 9 },
                    { 4, 9 },
                    { 5, 9 },
                    { 1, 10 },
                    { 2, 10 },
                    { 3, 10 },
                    { 4, 10 },
                    { 5, 10 },
                    { 1, 11 },
                    { 2, 11 },
                    { 3, 11 },
                    { 4, 11 },
                    { 5, 11 },
                    { 2, 12 },
                    { 5, 12 },
                    { 1, 13 },
                    { 2, 13 },
                    { 3, 13 },
                    { 4, 13 },
                    { 5, 13 },
                    { 1, 14 },
                    { 2, 14 },
                    { 3, 14 },
                    { 4, 14 },
                    { 5, 14 },
                    { 1, 16 },
                    { 2, 16 },
                    { 3, 16 },
                    { 4, 16 },
                    { 5, 16 }
                });

            migrationBuilder.InsertData(
                table: "ProductsSizes",
                columns: new[] { "ProductId", "SizeId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 1, 2 },
                    { 1, 3 },
                    { 1, 4 },
                    { 1, 5 },
                    { 2, 1 },
                    { 2, 2 },
                    { 2, 3 },
                    { 2, 4 },
                    { 2, 5 },
                    { 3, 1 },
                    { 3, 2 },
                    { 3, 3 },
                    { 3, 4 },
                    { 3, 5 },
                    { 4, 1 },
                    { 4, 2 },
                    { 4, 3 },
                    { 4, 4 },
                    { 4, 5 },
                    { 5, 1 },
                    { 5, 2 },
                    { 5, 3 },
                    { 5, 4 },
                    { 5, 5 },
                    { 7, 1 },
                    { 7, 2 },
                    { 7, 3 },
                    { 7, 4 },
                    { 7, 5 },
                    { 8, 1 },
                    { 8, 2 },
                    { 8, 3 },
                    { 8, 4 },
                    { 8, 5 },
                    { 9, 6 },
                    { 9, 7 },
                    { 9, 8 },
                    { 9, 9 },
                    { 10, 1 },
                    { 10, 2 },
                    { 10, 3 },
                    { 10, 4 },
                    { 10, 5 },
                    { 11, 1 },
                    { 11, 2 },
                    { 11, 3 },
                    { 11, 4 },
                    { 11, 5 },
                    { 12, 11 },
                    { 12, 12 },
                    { 12, 13 },
                    { 12, 14 },
                    { 13, 1 },
                    { 13, 2 },
                    { 13, 3 },
                    { 13, 4 },
                    { 13, 5 },
                    { 14, 1 },
                    { 14, 2 },
                    { 14, 3 },
                    { 14, 4 },
                    { 14, 5 },
                    { 16, 1 },
                    { 16, 2 },
                    { 16, 3 },
                    { 16, 4 },
                    { 16, 5 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_EcontOffices_CityId",
                table: "EcontOffices",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_ImageProducts_ProductId",
                table: "ImageProducts",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_ImageReviews_ReviewId",
                table: "ImageReviews",
                column: "ReviewId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_AppUserId",
                table: "Orders",
                column: "AppUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_StatusOrderId",
                table: "Orders",
                column: "StatusOrderId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_CategoryId",
                table: "Products",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductsColors_ColorId",
                table: "ProductsColors",
                column: "ColorId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductsOrders_OrderId",
                table: "ProductsOrders",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductsSizes_SizeId",
                table: "ProductsSizes",
                column: "SizeId");

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_AuthorId",
                table: "Reviews",
                column: "AuthorId");

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_ProductId",
                table: "Reviews",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Wishes_ProductId",
                table: "Wishes",
                column: "ProductId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "EcontOffices");

            migrationBuilder.DropTable(
                name: "ImageProducts");

            migrationBuilder.DropTable(
                name: "ImageReviews");

            migrationBuilder.DropTable(
                name: "Messages");

            migrationBuilder.DropTable(
                name: "ProductsColors");

            migrationBuilder.DropTable(
                name: "ProductsOrders");

            migrationBuilder.DropTable(
                name: "ProductsSizes");

            migrationBuilder.DropTable(
                name: "Subscribes");

            migrationBuilder.DropTable(
                name: "Wishes");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "EcontCities");

            migrationBuilder.DropTable(
                name: "Reviews");

            migrationBuilder.DropTable(
                name: "Colors");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Sizes");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "StatusOrders");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
