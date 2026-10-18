using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TindahanOS.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitDatabase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AuditLogs",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    StoreId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ActionType = table.Column<int>(type: "int", nullable: false),
                    EntityName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    EntityId = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Description = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    IpAddress = table.Column<string>(type: "nvarchar(45)", maxLength: 45, nullable: true),
                    OccurredAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AuditLogs", x => x.Id);
                    table.CheckConstraint("CK_AuditLogs_ActionType_Valid", "[ActionType] IN (1, 2, 3, 4, 5, 6, 7, 8, 9, 10)");
                });

            migrationBuilder.CreateTable(
                name: "Stores",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    BusinessName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    Address = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false, defaultValue: 1),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stores", x => x.Id);
                    table.CheckConstraint("CK_Stores_Status_Valid", "[Status] IN (1,2,3)");
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Username = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    FullName = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(254)", maxLength: 254, nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false, defaultValue: 1),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    StoreId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FullName = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    Address = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true),
                    Notes = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false, defaultValue: 1),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.Id);
                    table.UniqueConstraint("AK_Customers_StoreId_Id", x => new { x.StoreId, x.Id });
                    table.CheckConstraint("CK_Customers_Status_Valid", "[Status] IN (1, 2)");
                    table.ForeignKey(
                        name: "FK_Customers_Stores_StoreId",
                        column: x => x.StoreId,
                        principalTable: "Stores",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "GCashTransactions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    StoreId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TransactionType = table.Column<int>(type: "int", nullable: false, defaultValue: 1),
                    CustomerName = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    ReferenceNumber = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false, defaultValue: 1),
                    Notes = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    TransactionDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GCashTransactions", x => x.Id);
                    table.CheckConstraint("CK_GCashTransactions_Amount_Positive", "[Amount] > 0");
                    table.CheckConstraint("CK_GCashTransactions_Status_Valid", "[Status] IN (1, 2, 3, 4)");
                    table.CheckConstraint("CK_GCashTransactions_Type_Valid", "[TransactionType] IN (1, 2)");
                    table.ForeignKey(
                        name: "FK_GCashTransactions_Stores_StoreId",
                        column: x => x.StoreId,
                        principalTable: "Stores",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    StoreId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    SKU = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Unit = table.Column<int>(type: "int", nullable: false, defaultValue: 1),
                    SellingPrice = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    CostPrice = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false, defaultValue: 1),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                    table.UniqueConstraint("AK_Products_StoreId_Id", x => new { x.StoreId, x.Id });
                    table.CheckConstraint("CK_Products_CostPrice_NonNegative", "[CostPrice] IS NULL OR [CostPrice] >= 0");
                    table.CheckConstraint("CK_Products_SellingPrice_NonNegative", "[SellingPrice] >= 0");
                    table.CheckConstraint("CK_Products_Status_Valid", "[Status] IN (1,2)");
                    table.CheckConstraint("CK_Products_Unit_Valid", "[Unit] IN (1,2,3,4,5,6,7,8,9,10)");
                    table.ForeignKey(
                        name: "FK_Products_Stores_StoreId",
                        column: x => x.StoreId,
                        principalTable: "Stores",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "StoreSettings",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    StoreId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CurrencyCode = table.Column<string>(type: "nvarchar(3)", maxLength: 3, nullable: false, defaultValue: "PHP"),
                    TimeZoneId = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false, defaultValue: "Asia/Manila"),
                    AllowNegativeStock = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    RequireGCashVerification = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    DefaultDebtDueDays = table.Column<int>(type: "int", nullable: false, defaultValue: 0),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StoreSettings", x => x.Id);
                    table.CheckConstraint("CK_StoreSettings_DebtDueDays_Range", "[DefaultDebtDueDays] BETWEEN 0 AND 365");
                    table.ForeignKey(
                        name: "FK_StoreSettings_Stores_StoreId",
                        column: x => x.StoreId,
                        principalTable: "Stores",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "StoreMemberships",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    StoreId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Role = table.Column<int>(type: "int", nullable: false, defaultValue: 3),
                    Status = table.Column<int>(type: "int", nullable: false, defaultValue: 1),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StoreMemberships", x => x.Id);
                    table.CheckConstraint("CK_StoreMemberships_Role_Valid", "[Role] IN (1,2,3)");
                    table.CheckConstraint("CK_StoreMemberships_Status_Valid", "[Status] IN (1,2)");
                    table.ForeignKey(
                        name: "FK_StoreMemberships_Stores_StoreId",
                        column: x => x.StoreId,
                        principalTable: "Stores",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_StoreMemberships_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "DebtAccounts",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    StoreId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CustomerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false, defaultValue: 1),
                    Notes = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DebtAccounts", x => x.Id);
                    table.UniqueConstraint("AK_DebtAccounts_StoreId_Id", x => new { x.StoreId, x.Id });
                    table.ForeignKey(
                        name: "FK_DebtAccounts_Customers_StoreId_CustomerId",
                        columns: x => new { x.StoreId, x.CustomerId },
                        principalTable: "Customers",
                        principalColumns: new[] { "StoreId", "Id" });
                    table.ForeignKey(
                        name: "FK_DebtAccounts_Stores_StoreId",
                        column: x => x.StoreId,
                        principalTable: "Stores",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "GCashTransactionReviews",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    GCashTransactionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ReviewerUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ReviewResult = table.Column<int>(type: "int", nullable: false),
                    Reason = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    ReviewedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GCashTransactionReviews", x => x.Id);
                    table.CheckConstraint("CK_GCashTransactionReviews_Result_Valid", "[ReviewResult] IN (1, 2, 3, 4)");
                    table.ForeignKey(
                        name: "FK_GCashTransactionReviews_GCashTransactions_GCashTransactionId",
                        column: x => x.GCashTransactionId,
                        principalTable: "GCashTransactions",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_GCashTransactionReviews_Users_ReviewerUserId",
                        column: x => x.ReviewerUserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "InventoryMovements",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    StoreId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProductId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MovementType = table.Column<int>(type: "int", nullable: false, defaultValue: 1),
                    Quantity = table.Column<decimal>(type: "decimal(18,3)", precision: 18, scale: 3, nullable: false),
                    ReferenceNumber = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Notes = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    MovementDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InventoryMovements", x => x.Id);
                    table.CheckConstraint("CK_InventoryMovements_Quantity_Positive", "[Quantity] > 0");
                    table.CheckConstraint("CK_InventoryMovements_Type_Valid", "[MovementType] IN (1, 2, 3, 4, 5, 6)");
                    table.ForeignKey(
                        name: "FK_InventoryMovements_Products_StoreId_ProductId",
                        columns: x => new { x.StoreId, x.ProductId },
                        principalTable: "Products",
                        principalColumns: new[] { "StoreId", "Id" });
                    table.ForeignKey(
                        name: "FK_InventoryMovements_Stores_StoreId",
                        column: x => x.StoreId,
                        principalTable: "Stores",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "DebtTransactions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    StoreId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DebtAccountId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Type = table.Column<int>(type: "int", nullable: false, defaultValue: 1),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    TransactionDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ReferenceNumber = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Notes = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DebtTransactions", x => x.Id);
                    table.UniqueConstraint("AK_DebtTransactions_StoreId_Id", x => new { x.StoreId, x.Id });
                    table.CheckConstraint("CK_DebtTransactions_Amount_Positive", "[Amount] > 0");
                    table.ForeignKey(
                        name: "FK_DebtTransactions_DebtAccounts_StoreId_DebtAccountId",
                        columns: x => new { x.StoreId, x.DebtAccountId },
                        principalTable: "DebtAccounts",
                        principalColumns: new[] { "StoreId", "Id" });
                });

            migrationBuilder.CreateTable(
                name: "DebtTransactionItems",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    StoreId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DebtTransactionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProductId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Quantity = table.Column<decimal>(type: "decimal(18,3)", precision: 18, scale: 3, nullable: false),
                    UnitPrice = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    LineTotal = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DebtTransactionItems", x => x.Id);
                    table.CheckConstraint("CK_DebtTransactionItems_LineTotal_NonNegative", "[LineTotal] >= 0");
                    table.CheckConstraint("CK_DebtTransactionItems_Quantity_Positive", "[Quantity] > 0");
                    table.CheckConstraint("CK_DebtTransactionItems_UnitPrice_NonNegative", "[UnitPrice] >= 0");
                    table.ForeignKey(
                        name: "FK_DebtTransactionItems_DebtTransactions_StoreId_DebtTransactionId",
                        columns: x => new { x.StoreId, x.DebtTransactionId },
                        principalTable: "DebtTransactions",
                        principalColumns: new[] { "StoreId", "Id" });
                    table.ForeignKey(
                        name: "FK_DebtTransactionItems_Products_StoreId_ProductId",
                        columns: x => new { x.StoreId, x.ProductId },
                        principalTable: "Products",
                        principalColumns: new[] { "StoreId", "Id" });
                });

            migrationBuilder.CreateIndex(
                name: "IX_AuditLogs_EntityName_EntityId",
                table: "AuditLogs",
                columns: new[] { "EntityName", "EntityId" });

            migrationBuilder.CreateIndex(
                name: "IX_AuditLogs_StoreId_OccurredAt",
                table: "AuditLogs",
                columns: new[] { "StoreId", "OccurredAt" });

            migrationBuilder.CreateIndex(
                name: "IX_AuditLogs_UserId_OccurredAt",
                table: "AuditLogs",
                columns: new[] { "UserId", "OccurredAt" });

            migrationBuilder.CreateIndex(
                name: "IX_Customers_StoreId",
                table: "Customers",
                column: "StoreId");

            migrationBuilder.CreateIndex(
                name: "IX_Customers_StoreId_FullName",
                table: "Customers",
                columns: new[] { "StoreId", "FullName" });

            migrationBuilder.CreateIndex(
                name: "IX_DebtAccounts_StoreId",
                table: "DebtAccounts",
                column: "StoreId");

            migrationBuilder.CreateIndex(
                name: "IX_DebtAccounts_StoreId_CustomerId",
                table: "DebtAccounts",
                columns: new[] { "StoreId", "CustomerId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_DebtTransactionItems_StoreId_DebtTransactionId",
                table: "DebtTransactionItems",
                columns: new[] { "StoreId", "DebtTransactionId" });

            migrationBuilder.CreateIndex(
                name: "IX_DebtTransactionItems_StoreId_ProductId",
                table: "DebtTransactionItems",
                columns: new[] { "StoreId", "ProductId" });

            migrationBuilder.CreateIndex(
                name: "IX_DebtTransactions_DebtAccountId_TransactionDate",
                table: "DebtTransactions",
                columns: new[] { "DebtAccountId", "TransactionDate" });

            migrationBuilder.CreateIndex(
                name: "IX_DebtTransactions_ReferenceNumber",
                table: "DebtTransactions",
                column: "ReferenceNumber");

            migrationBuilder.CreateIndex(
                name: "IX_DebtTransactions_StoreId_DebtAccountId",
                table: "DebtTransactions",
                columns: new[] { "StoreId", "DebtAccountId" });

            migrationBuilder.CreateIndex(
                name: "IX_GCashTransactionReviews_GCashTransactionId_ReviewedAt",
                table: "GCashTransactionReviews",
                columns: new[] { "GCashTransactionId", "ReviewedAt" });

            migrationBuilder.CreateIndex(
                name: "IX_GCashTransactionReviews_ReviewerUserId",
                table: "GCashTransactionReviews",
                column: "ReviewerUserId");

            migrationBuilder.CreateIndex(
                name: "IX_GCashTransactions_StoreId_PhoneNumber_TransactionDate",
                table: "GCashTransactions",
                columns: new[] { "StoreId", "PhoneNumber", "TransactionDate" });

            migrationBuilder.CreateIndex(
                name: "IX_GCashTransactions_StoreId_ReferenceNumber",
                table: "GCashTransactions",
                columns: new[] { "StoreId", "ReferenceNumber" });

            migrationBuilder.CreateIndex(
                name: "IX_GCashTransactions_StoreId_Status_TransactionDate",
                table: "GCashTransactions",
                columns: new[] { "StoreId", "Status", "TransactionDate" });

            migrationBuilder.CreateIndex(
                name: "IX_InventoryMovements_ReferenceNumber",
                table: "InventoryMovements",
                column: "ReferenceNumber");

            migrationBuilder.CreateIndex(
                name: "IX_InventoryMovements_StoreId_ProductId_MovementDate",
                table: "InventoryMovements",
                columns: new[] { "StoreId", "ProductId", "MovementDate" });

            migrationBuilder.CreateIndex(
                name: "IX_Products_StoreId",
                table: "Products",
                column: "StoreId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_StoreId_Name",
                table: "Products",
                columns: new[] { "StoreId", "Name" });

            migrationBuilder.CreateIndex(
                name: "IX_Products_StoreId_SKU",
                table: "Products",
                columns: new[] { "StoreId", "SKU" },
                unique: true,
                filter: "[SKU] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_StoreMemberships_StoreId_UserId",
                table: "StoreMemberships",
                columns: new[] { "StoreId", "UserId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_StoreMemberships_UserId",
                table: "StoreMemberships",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_StoreSettings_StoreId",
                table: "StoreSettings",
                column: "StoreId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_Email",
                table: "Users",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_Username",
                table: "Users",
                column: "Username",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AuditLogs");

            migrationBuilder.DropTable(
                name: "DebtTransactionItems");

            migrationBuilder.DropTable(
                name: "GCashTransactionReviews");

            migrationBuilder.DropTable(
                name: "InventoryMovements");

            migrationBuilder.DropTable(
                name: "StoreMemberships");

            migrationBuilder.DropTable(
                name: "StoreSettings");

            migrationBuilder.DropTable(
                name: "DebtTransactions");

            migrationBuilder.DropTable(
                name: "GCashTransactions");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "DebtAccounts");

            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "Stores");
        }
    }
}
