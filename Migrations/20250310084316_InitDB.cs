using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Trackify.Migrations
{
    /// <inheritdoc />
    public partial class InitDB : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "organizations",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1000, 1"),
                    reference_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    code = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    type = table.Column<int>(type: "int", nullable: false),
                    tax_code = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    phone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    notes = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_organizations", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "products",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1000, 1"),
                    reference_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    code = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    barcode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_products", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "sequence_numbers",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1000, 1"),
                    reference_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    code = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    next_value = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_sequence_numbers", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "system_configurations",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1000, 1"),
                    reference_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    key = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    value = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_system_configurations", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "stock_take_periods",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1000, 1"),
                    reference_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    organization_id = table.Column<int>(type: "int", nullable: false),
                    code = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    start_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    end_date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    is_closed = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_stock_take_periods", x => x.id);
                    table.ForeignKey(
                        name: "fk_stock_take_periods_organizations_organization_id",
                        column: x => x.organization_id,
                        principalTable: "organizations",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "users",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1000, 1"),
                    reference_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    username = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    password_hash = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    display_name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    organization_id = table.Column<int>(type: "int", nullable: false),
                    is_admin = table.Column<bool>(type: "bit", nullable: false),
                    is_locked = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_users", x => x.id);
                    table.ForeignKey(
                        name: "fk_users_organizations_organization_id",
                        column: x => x.organization_id,
                        principalTable: "organizations",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "warehouse_locations",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1000, 1"),
                    reference_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    code = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    rack = table.Column<int>(type: "int", nullable: false),
                    row = table.Column<int>(type: "int", nullable: false),
                    shelf = table.Column<int>(type: "int", nullable: false),
                    bin = table.Column<int>(type: "int", nullable: false),
                    organization_id = table.Column<int>(type: "int", nullable: true),
                    status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_warehouse_locations", x => x.id);
                    table.ForeignKey(
                        name: "fk_warehouse_locations_organizations_organization_id",
                        column: x => x.organization_id,
                        principalTable: "organizations",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "partner_projects",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1000, 1"),
                    reference_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    user_id = table.Column<int>(type: "int", nullable: false),
                    code = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_partner_projects", x => x.id);
                    table.ForeignKey(
                        name: "fk_partner_projects_users_user_id",
                        column: x => x.user_id,
                        principalTable: "users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "pallets",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1000, 1"),
                    reference_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    code = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    order_number = table.Column<int>(type: "int", nullable: false),
                    location_id = table.Column<int>(type: "int", nullable: true),
                    status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_pallets", x => x.id);
                    table.ForeignKey(
                        name: "fk_pallets_warehouse_locations_location_id",
                        column: x => x.location_id,
                        principalTable: "warehouse_locations",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "inbound_orders",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1000, 1"),
                    reference_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    user_id = table.Column<int>(type: "int", nullable: false),
                    code = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    posting_date = table.Column<DateOnly>(type: "date", nullable: false),
                    invoice_no = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    invoice_date = table.Column<DateOnly>(type: "date", nullable: true),
                    period_id = table.Column<int>(type: "int", nullable: false),
                    supplier_id = table.Column<int>(type: "int", nullable: false),
                    partner_id = table.Column<int>(type: "int", nullable: false),
                    project_id = table.Column<int>(type: "int", nullable: true),
                    is_non_storage = table.Column<bool>(type: "bit", nullable: false),
                    notes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    reason = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    created_at_utc = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETUTCDATE()"),
                    updated_at_utc = table.Column<DateTime>(type: "datetime2", nullable: true),
                    status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_inbound_orders", x => x.id);
                    table.ForeignKey(
                        name: "fk_inbound_orders_organizations_partner_id",
                        column: x => x.partner_id,
                        principalTable: "organizations",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_inbound_orders_organizations_supplier_id",
                        column: x => x.supplier_id,
                        principalTable: "organizations",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_inbound_orders_partner_projects_project_id",
                        column: x => x.project_id,
                        principalTable: "partner_projects",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_inbound_orders_stock_take_periods_period_id",
                        column: x => x.period_id,
                        principalTable: "stock_take_periods",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_inbound_orders_users_user_id",
                        column: x => x.user_id,
                        principalTable: "users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "outbound_orders",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1000, 1"),
                    reference_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    user_id = table.Column<int>(type: "int", nullable: false),
                    code = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    posting_date = table.Column<DateOnly>(type: "date", nullable: false),
                    period_id = table.Column<int>(type: "int", nullable: false),
                    customer_id = table.Column<int>(type: "int", nullable: false),
                    partner_id = table.Column<int>(type: "int", nullable: false),
                    project_id = table.Column<int>(type: "int", nullable: true),
                    is_non_storage = table.Column<bool>(type: "bit", nullable: false),
                    notes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    reason = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    created_at_utc = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETUTCDATE()"),
                    updated_at_utc = table.Column<DateTime>(type: "datetime2", nullable: true),
                    status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_outbound_orders", x => x.id);
                    table.ForeignKey(
                        name: "fk_outbound_orders_organizations_customer_id",
                        column: x => x.customer_id,
                        principalTable: "organizations",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_outbound_orders_organizations_partner_id",
                        column: x => x.partner_id,
                        principalTable: "organizations",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_outbound_orders_partner_projects_project_id",
                        column: x => x.project_id,
                        principalTable: "partner_projects",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_outbound_orders_stock_take_periods_period_id",
                        column: x => x.period_id,
                        principalTable: "stock_take_periods",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_outbound_orders_users_user_id",
                        column: x => x.user_id,
                        principalTable: "users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "stock_levels",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1000, 1"),
                    reference_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    period_id = table.Column<int>(type: "int", nullable: false),
                    product_id = table.Column<int>(type: "int", nullable: false),
                    project_id = table.Column<int>(type: "int", nullable: false),
                    beginning_quantity = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    inbound_quantity = table.Column<decimal>(type: "decimal(18,2)", nullable: false, defaultValue: 0m),
                    other_inbound_quantity = table.Column<decimal>(type: "decimal(18,2)", nullable: false, defaultValue: 0m),
                    outbound_quantity = table.Column<decimal>(type: "decimal(18,2)", nullable: false, defaultValue: 0m),
                    other_outbound_quantity = table.Column<decimal>(type: "decimal(18,2)", nullable: false, defaultValue: 0m),
                    ending_quantity = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_stock_levels", x => x.id);
                    table.ForeignKey(
                        name: "fk_stock_levels_partner_projects_project_id",
                        column: x => x.project_id,
                        principalTable: "partner_projects",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_stock_levels_products_product_id",
                        column: x => x.product_id,
                        principalTable: "products",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_stock_levels_stock_take_periods_period_id",
                        column: x => x.period_id,
                        principalTable: "stock_take_periods",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "inbound_order_lines",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1000, 1"),
                    reference_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    inbound_order_id = table.Column<int>(type: "int", nullable: false),
                    product_id = table.Column<int>(type: "int", nullable: false),
                    pallet_id = table.Column<int>(type: "int", nullable: false),
                    quantity = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_inbound_order_lines", x => x.id);
                    table.ForeignKey(
                        name: "fk_inbound_order_lines_inbound_orders_inbound_order_id",
                        column: x => x.inbound_order_id,
                        principalTable: "inbound_orders",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_inbound_order_lines_pallets_pallet_id",
                        column: x => x.pallet_id,
                        principalTable: "pallets",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_inbound_order_lines_products_product_id",
                        column: x => x.product_id,
                        principalTable: "products",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "pallet_contents",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1000, 1"),
                    reference_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    pallet_id = table.Column<int>(type: "int", nullable: false),
                    product_id = table.Column<int>(type: "int", nullable: false),
                    inbound_order_id = table.Column<int>(type: "int", nullable: false),
                    quantity = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_pallet_contents", x => x.id);
                    table.ForeignKey(
                        name: "fk_pallet_contents_inbound_orders_inbound_order_id",
                        column: x => x.inbound_order_id,
                        principalTable: "inbound_orders",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_pallet_contents_pallets_pallet_id",
                        column: x => x.pallet_id,
                        principalTable: "pallets",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_pallet_contents_products_product_id",
                        column: x => x.product_id,
                        principalTable: "products",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "pallet_movement_logs",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1000, 1"),
                    reference_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    pallet_id = table.Column<int>(type: "int", nullable: false),
                    order_id = table.Column<int>(type: "int", nullable: false),
                    order_type = table.Column<int>(type: "int", nullable: false),
                    origin_order_id = table.Column<int>(type: "int", nullable: false),
                    source_location_id = table.Column<int>(type: "int", nullable: true),
                    destination_location_id = table.Column<int>(type: "int", nullable: true),
                    started_at = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ended_at = table.Column<DateTime>(type: "datetime2", nullable: true),
                    type = table.Column<int>(type: "int", nullable: false),
                    status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_pallet_movement_logs", x => x.id);
                    table.ForeignKey(
                        name: "fk_pallet_movement_logs_inbound_orders_origin_order_id",
                        column: x => x.origin_order_id,
                        principalTable: "inbound_orders",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_pallet_movement_logs_pallets_pallet_id",
                        column: x => x.pallet_id,
                        principalTable: "pallets",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_pallet_movement_logs_warehouse_locations_destination_location_id",
                        column: x => x.destination_location_id,
                        principalTable: "warehouse_locations",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_pallet_movement_logs_warehouse_locations_source_location_id",
                        column: x => x.source_location_id,
                        principalTable: "warehouse_locations",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "outbound_order_lines",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1000, 1"),
                    reference_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    outbound_order_id = table.Column<int>(type: "int", nullable: false),
                    product_id = table.Column<int>(type: "int", nullable: false),
                    quantity = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_outbound_order_lines", x => x.id);
                    table.ForeignKey(
                        name: "fk_outbound_order_lines_outbound_orders_outbound_order_id",
                        column: x => x.outbound_order_id,
                        principalTable: "outbound_orders",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_outbound_order_lines_products_product_id",
                        column: x => x.product_id,
                        principalTable: "products",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "ix_inbound_order_lines_inbound_order_id",
                table: "inbound_order_lines",
                column: "inbound_order_id");

            migrationBuilder.CreateIndex(
                name: "ix_inbound_order_lines_pallet_id",
                table: "inbound_order_lines",
                column: "pallet_id");

            migrationBuilder.CreateIndex(
                name: "ix_inbound_order_lines_product_id",
                table: "inbound_order_lines",
                column: "product_id");

            migrationBuilder.CreateIndex(
                name: "ix_inbound_order_lines_reference_id",
                table: "inbound_order_lines",
                column: "reference_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_inbound_orders_code",
                table: "inbound_orders",
                column: "code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_inbound_orders_partner_id",
                table: "inbound_orders",
                column: "partner_id");

            migrationBuilder.CreateIndex(
                name: "ix_inbound_orders_period_id",
                table: "inbound_orders",
                column: "period_id");

            migrationBuilder.CreateIndex(
                name: "ix_inbound_orders_project_id",
                table: "inbound_orders",
                column: "project_id");

            migrationBuilder.CreateIndex(
                name: "ix_inbound_orders_reference_id",
                table: "inbound_orders",
                column: "reference_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_inbound_orders_supplier_id",
                table: "inbound_orders",
                column: "supplier_id");

            migrationBuilder.CreateIndex(
                name: "ix_inbound_orders_user_id",
                table: "inbound_orders",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "ix_organizations_reference_id",
                table: "organizations",
                column: "reference_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_outbound_order_lines_outbound_order_id",
                table: "outbound_order_lines",
                column: "outbound_order_id");

            migrationBuilder.CreateIndex(
                name: "ix_outbound_order_lines_product_id",
                table: "outbound_order_lines",
                column: "product_id");

            migrationBuilder.CreateIndex(
                name: "ix_outbound_order_lines_reference_id",
                table: "outbound_order_lines",
                column: "reference_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_outbound_orders_code",
                table: "outbound_orders",
                column: "code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_outbound_orders_customer_id",
                table: "outbound_orders",
                column: "customer_id");

            migrationBuilder.CreateIndex(
                name: "ix_outbound_orders_partner_id",
                table: "outbound_orders",
                column: "partner_id");

            migrationBuilder.CreateIndex(
                name: "ix_outbound_orders_period_id",
                table: "outbound_orders",
                column: "period_id");

            migrationBuilder.CreateIndex(
                name: "ix_outbound_orders_project_id",
                table: "outbound_orders",
                column: "project_id");

            migrationBuilder.CreateIndex(
                name: "ix_outbound_orders_reference_id",
                table: "outbound_orders",
                column: "reference_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_outbound_orders_user_id",
                table: "outbound_orders",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "ix_pallet_contents_inbound_order_id",
                table: "pallet_contents",
                column: "inbound_order_id");

            migrationBuilder.CreateIndex(
                name: "ix_pallet_contents_pallet_id",
                table: "pallet_contents",
                column: "pallet_id");

            migrationBuilder.CreateIndex(
                name: "ix_pallet_contents_product_id",
                table: "pallet_contents",
                column: "product_id");

            migrationBuilder.CreateIndex(
                name: "ix_pallet_contents_reference_id",
                table: "pallet_contents",
                column: "reference_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_pallet_movement_logs_destination_location_id",
                table: "pallet_movement_logs",
                column: "destination_location_id");

            migrationBuilder.CreateIndex(
                name: "ix_pallet_movement_logs_origin_order_id",
                table: "pallet_movement_logs",
                column: "origin_order_id");

            migrationBuilder.CreateIndex(
                name: "ix_pallet_movement_logs_pallet_id",
                table: "pallet_movement_logs",
                column: "pallet_id");

            migrationBuilder.CreateIndex(
                name: "ix_pallet_movement_logs_reference_id",
                table: "pallet_movement_logs",
                column: "reference_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_pallet_movement_logs_source_location_id",
                table: "pallet_movement_logs",
                column: "source_location_id");

            migrationBuilder.CreateIndex(
                name: "ix_pallets_location_id",
                table: "pallets",
                column: "location_id");

            migrationBuilder.CreateIndex(
                name: "ix_pallets_reference_id",
                table: "pallets",
                column: "reference_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_partner_projects_reference_id",
                table: "partner_projects",
                column: "reference_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_partner_projects_user_id",
                table: "partner_projects",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "ix_products_reference_id",
                table: "products",
                column: "reference_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_sequence_numbers_reference_id",
                table: "sequence_numbers",
                column: "reference_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_stock_levels_period_id_product_id",
                table: "stock_levels",
                columns: new[] { "period_id", "product_id" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_stock_levels_product_id",
                table: "stock_levels",
                column: "product_id");

            migrationBuilder.CreateIndex(
                name: "ix_stock_levels_project_id",
                table: "stock_levels",
                column: "project_id");

            migrationBuilder.CreateIndex(
                name: "ix_stock_levels_reference_id",
                table: "stock_levels",
                column: "reference_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_stock_take_periods_organization_id",
                table: "stock_take_periods",
                column: "organization_id");

            migrationBuilder.CreateIndex(
                name: "ix_stock_take_periods_reference_id",
                table: "stock_take_periods",
                column: "reference_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_system_configurations_reference_id",
                table: "system_configurations",
                column: "reference_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_users_organization_id",
                table: "users",
                column: "organization_id");

            migrationBuilder.CreateIndex(
                name: "ix_users_reference_id",
                table: "users",
                column: "reference_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_users_username",
                table: "users",
                column: "username",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_warehouse_locations_code",
                table: "warehouse_locations",
                column: "code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_warehouse_locations_organization_id",
                table: "warehouse_locations",
                column: "organization_id");

            migrationBuilder.CreateIndex(
                name: "ix_warehouse_locations_reference_id",
                table: "warehouse_locations",
                column: "reference_id",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "inbound_order_lines");

            migrationBuilder.DropTable(
                name: "outbound_order_lines");

            migrationBuilder.DropTable(
                name: "pallet_contents");

            migrationBuilder.DropTable(
                name: "pallet_movement_logs");

            migrationBuilder.DropTable(
                name: "sequence_numbers");

            migrationBuilder.DropTable(
                name: "stock_levels");

            migrationBuilder.DropTable(
                name: "system_configurations");

            migrationBuilder.DropTable(
                name: "outbound_orders");

            migrationBuilder.DropTable(
                name: "inbound_orders");

            migrationBuilder.DropTable(
                name: "pallets");

            migrationBuilder.DropTable(
                name: "products");

            migrationBuilder.DropTable(
                name: "partner_projects");

            migrationBuilder.DropTable(
                name: "stock_take_periods");

            migrationBuilder.DropTable(
                name: "warehouse_locations");

            migrationBuilder.DropTable(
                name: "users");

            migrationBuilder.DropTable(
                name: "organizations");
        }
    }
}
