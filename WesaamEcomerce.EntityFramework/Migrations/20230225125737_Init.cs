using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using WesaamEcomerce.Common.Enums;
using WesaamEcomerce.EntityFramework.Models;

#nullable disable

namespace WesaamEcomerce.EntityFramework.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("Npgsql:Enum:country", "sar,aed")
                .Annotation("Npgsql:Enum:payment_type", "cod,visa");

            migrationBuilder.CreateTable(
                name: "categories",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "text", nullable: false),
                    createddatetime = table.Column<DateTime>(name: "created_date_time", type: "timestamp with time zone", nullable: false),
                    isactive = table.Column<bool>(name: "is_active", type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_categories", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "products",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "text", nullable: false),
                    thumbnail = table.Column<string>(type: "text", nullable: false),
                    discountpercentage = table.Column<double>(name: "discount_percentage", type: "double precision", nullable: false),
                    price = table.Column<double>(type: "double precision", nullable: false),
                    sellingcountries = table.Column<List<Country>>(name: "selling_countries", type: "country[]", nullable: false),
                    description = table.Column<string>(type: "text", nullable: false),
                    imageurls = table.Column<List<string>>(name: "image_urls", type: "text[]", nullable: true),
                    storyimageurls = table.Column<List<string>>(name: "story_image_urls", type: "text[]", nullable: true),
                    categoryid = table.Column<int>(name: "category_id", type: "integer", nullable: true),
                    createddatetime = table.Column<DateTime>(name: "created_date_time", type: "timestamp with time zone", nullable: false),
                    isactive = table.Column<bool>(name: "is_active", type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_products", x => x.id);
                    table.ForeignKey(
                        name: "fk_products_categories_category_id",
                        column: x => x.categoryid,
                        principalTable: "categories",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "carts",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    products = table.Column<List<Product>>(type: "jsonb", nullable: false),
                    createddatetime = table.Column<DateTime>(name: "created_date_time", type: "timestamp with time zone", nullable: false),
                    orderid = table.Column<int>(name: "order_id", type: "integer", nullable: true),
                    isactive = table.Column<bool>(name: "is_active", type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_carts", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "orders",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    cartid = table.Column<int>(name: "cart_id", type: "integer", nullable: false),
                    paymenttype = table.Column<PaymentType>(name: "payment_type", type: "payment_type", nullable: false),
                    createddatetime = table.Column<DateTime>(name: "created_date_time", type: "timestamp with time zone", nullable: false),
                    isactive = table.Column<bool>(name: "is_active", type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_orders", x => x.id);
                    table.ForeignKey(
                        name: "fk_orders_carts_cart_id",
                        column: x => x.cartid,
                        principalTable: "carts",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "coupons",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "text", nullable: false),
                    displaytext = table.Column<string>(name: "display_text", type: "text", nullable: false),
                    code = table.Column<string>(type: "text", nullable: false),
                    percentage = table.Column<double>(type: "double precision", nullable: true),
                    amount = table.Column<double>(type: "double precision", nullable: true),
                    sellingcountries = table.Column<string[]>(name: "selling_countries", type: "text[]", nullable: false),
                    ispublish = table.Column<bool>(name: "is_publish", type: "boolean", nullable: false),
                    isapply = table.Column<bool>(name: "is_apply", type: "boolean", nullable: false),
                    cartid = table.Column<int>(name: "cart_id", type: "integer", nullable: true),
                    orderid = table.Column<int>(name: "order_id", type: "integer", nullable: true),
                    createddatetime = table.Column<DateTime>(name: "created_date_time", type: "timestamp with time zone", nullable: false),
                    isactive = table.Column<bool>(name: "is_active", type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_coupons", x => x.id);
                    table.ForeignKey(
                        name: "fk_coupons_carts_cart_id",
                        column: x => x.cartid,
                        principalTable: "carts",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "fk_coupons_orders_order_id",
                        column: x => x.orderid,
                        principalTable: "orders",
                        principalColumn: "id");
                });

            migrationBuilder.CreateIndex(
                name: "ix_carts_order_id",
                table: "carts",
                column: "order_id");

            migrationBuilder.CreateIndex(
                name: "ix_coupons_cart_id",
                table: "coupons",
                column: "cart_id");

            migrationBuilder.CreateIndex(
                name: "ix_coupons_order_id",
                table: "coupons",
                column: "order_id");

            migrationBuilder.CreateIndex(
                name: "ix_orders_cart_id",
                table: "orders",
                column: "cart_id");

            migrationBuilder.CreateIndex(
                name: "ix_products_category_id",
                table: "products",
                column: "category_id");

            migrationBuilder.AddForeignKey(
                name: "fk_carts_orders_order_id",
                table: "carts",
                column: "order_id",
                principalTable: "orders",
                principalColumn: "id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_carts_orders_order_id",
                table: "carts");

            migrationBuilder.DropTable(
                name: "coupons");

            migrationBuilder.DropTable(
                name: "products");

            migrationBuilder.DropTable(
                name: "categories");

            migrationBuilder.DropTable(
                name: "orders");

            migrationBuilder.DropTable(
                name: "carts");
        }
    }
}
