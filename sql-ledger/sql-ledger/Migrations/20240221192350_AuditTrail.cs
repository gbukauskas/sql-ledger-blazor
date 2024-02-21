﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace sqlledger.Migrations
{
    /// <inheritdoc />
    public partial class AuditTrail : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateSequence<int>(
                name: "address_id");

            migrationBuilder.CreateSequence<int>(
                name: "archive_id");

            migrationBuilder.CreateSequence<int>(
                name: "assembly_id");

            migrationBuilder.CreateSequence<int>(
                name: "public_id",
                startValue: 10000L);

            migrationBuilder.CreateTable(
                name: "acc_trans",
                columns: table => new
                {
                    trans_id = table.Column<int>(type: "int", nullable: true),
                    chart_id = table.Column<int>(type: "int", nullable: true),
                    amount = table.Column<decimal>(type: "decimal(28,6)", precision: 28, scale: 6, nullable: true),
                    transdate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    source = table.Column<string>(type: "nvarchar(4000)", nullable: true),
                    approved = table.Column<bool>(type: "bit", nullable: true),
                    fx_transaction = table.Column<bool>(type: "bit", nullable: true, defaultValue: false),
                    project_id = table.Column<int>(type: "int", nullable: true),
                    memo = table.Column<string>(type: "nvarchar(MAX)", nullable: true),
                    id = table.Column<int>(type: "int", nullable: true),
                    cleared = table.Column<DateTime>(type: "datetime2", nullable: true),
                    vr_id = table.Column<int>(type: "int", nullable: true),
                    row_version = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "acsrole",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false, defaultValueSql: "NEXT VALUE FOR public_id"),
                    description = table.Column<string>(type: "nvarchar(MAX)", nullable: true),
                    acs = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    rn = table.Column<short>(type: "smallint", nullable: true),
                    row_version = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("acsrole_pkey", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "address",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false, defaultValueSql: "NEXT VALUE FOR address_id"),
                    trans_id = table.Column<int>(type: "int", nullable: true),
                    address1 = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: true),
                    address2 = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: true),
                    city = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: true),
                    state = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: true),
                    zipcode = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    country = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: true),
                    row_version = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("address_pkey", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "ap",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false, defaultValueSql: "NEXT VALUE FOR public_id"),
                    invnumber = table.Column<string>(type: "nvarchar(4000)", nullable: true),
                    transdate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETUTCDATE()"),
                    vendor_id = table.Column<int>(type: "int", nullable: true),
                    taxincluded = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    amount = table.Column<decimal>(type: "decimal(28,6)", precision: 28, scale: 6, nullable: true),
                    netamount = table.Column<decimal>(type: "decimal(28,6)", precision: 28, scale: 6, nullable: true),
                    paid = table.Column<decimal>(type: "decimal(28,6)", precision: 28, scale: 6, nullable: true),
                    datepaid = table.Column<DateTime>(type: "datetime2", nullable: true),
                    duedate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    invoice = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    ordnumber = table.Column<string>(type: "nvarchar(4000)", nullable: true),
                    curr = table.Column<string>(type: "char(3)", maxLength: 3, nullable: true),
                    notes = table.Column<string>(type: "nvarchar(MAX)", nullable: true),
                    employee_id = table.Column<int>(type: "int", nullable: true),
                    till = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    quonumber = table.Column<string>(type: "nvarchar(4000)", nullable: true),
                    intnotes = table.Column<string>(type: "nvarchar(MAX)", nullable: true),
                    department_id = table.Column<int>(type: "int", nullable: true, defaultValue: 0),
                    shipvia = table.Column<string>(type: "nvarchar(MAX)", nullable: true),
                    language_code = table.Column<string>(type: "nvarchar(6)", maxLength: 6, nullable: true),
                    ponumber = table.Column<string>(type: "nvarchar(MAX)", nullable: true),
                    shippingpoint = table.Column<string>(type: "nvarchar(MAX)", nullable: true),
                    terms = table.Column<short>(type: "smallint", nullable: false, defaultValue: (short)0),
                    approved = table.Column<bool>(type: "bit", nullable: true, defaultValue: true),
                    cashdiscount = table.Column<float>(type: "real", nullable: true),
                    discountterms = table.Column<short>(type: "smallint", nullable: true),
                    waybill = table.Column<string>(type: "nvarchar(MAX)", nullable: true),
                    warehouse_id = table.Column<int>(type: "int", nullable: true),
                    description = table.Column<string>(type: "nvarchar(MAX)", nullable: true),
                    onhold = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    exchangerate = table.Column<double>(type: "float", nullable: true),
                    dcn = table.Column<string>(type: "nvarchar(MAX)", nullable: true),
                    bank_id = table.Column<int>(type: "int", nullable: true),
                    paymentmethod_id = table.Column<int>(type: "int", nullable: true),
                    RowVersion = table.Column<byte[]>(type: "varbinary(max)", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "ar",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false, defaultValueSql: "NEXT VALUE FOR public_id"),
                    invnumber = table.Column<string>(type: "nvarchar(4000)", nullable: true),
                    transdate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETUTCDATE()"),
                    customer_id = table.Column<int>(type: "int", nullable: true),
                    taxincluded = table.Column<bool>(type: "bit", nullable: true),
                    amount = table.Column<decimal>(type: "decimal(28,6)", precision: 28, scale: 6, nullable: true),
                    netamount = table.Column<decimal>(type: "decimal(28,6)", precision: 28, scale: 6, nullable: true),
                    paid = table.Column<decimal>(type: "decimal(28,6)", precision: 28, scale: 6, nullable: true),
                    datepaid = table.Column<DateTime>(type: "datetime2", nullable: true),
                    duedate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    invoice = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    shippingpoint = table.Column<string>(type: "nvarchar(MAX)", nullable: true),
                    terms = table.Column<short>(type: "smallint", nullable: false, defaultValue: (short)0),
                    notes = table.Column<string>(type: "nvarchar(MAX)", nullable: true),
                    curr = table.Column<string>(type: "char(3)", maxLength: 3, nullable: true),
                    ordnumber = table.Column<string>(type: "nvarchar(4000)", nullable: true),
                    employee_id = table.Column<int>(type: "int", nullable: true),
                    till = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    quonumber = table.Column<string>(type: "nvarchar(4000)", nullable: true),
                    intnotes = table.Column<string>(type: "nvarchar(MAX)", nullable: true),
                    department_id = table.Column<int>(type: "int", nullable: true, defaultValue: 0),
                    shipvia = table.Column<string>(type: "nvarchar(MAX)", nullable: true),
                    language_code = table.Column<string>(type: "nvarchar(6)", maxLength: 6, nullable: true),
                    ponumber = table.Column<string>(type: "nvarchar(MAX)", nullable: true),
                    approved = table.Column<bool>(type: "bit", nullable: true, defaultValue: true),
                    cashdiscount = table.Column<float>(type: "real", nullable: true),
                    discountterms = table.Column<short>(type: "smallint", nullable: true),
                    waybill = table.Column<string>(type: "nvarchar(MAX)", nullable: true),
                    warehouse_id = table.Column<int>(type: "int", nullable: true),
                    description = table.Column<string>(type: "nvarchar(MAX)", nullable: true),
                    onhold = table.Column<bool>(type: "bit", nullable: true, defaultValue: false),
                    exchangerate = table.Column<double>(type: "float", nullable: true),
                    dcn = table.Column<string>(type: "nvarchar(MAX)", nullable: true),
                    bank_id = table.Column<int>(type: "int", nullable: true),
                    paymentmethod_id = table.Column<int>(type: "int", nullable: true),
                    RowVersion = table.Column<byte[]>(type: "varbinary(max)", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "archive",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false, defaultValueSql: "NEXT VALUE FOR archive_id"),
                    filename = table.Column<string>(type: "nvarchar(MAX)", nullable: true),
                    row_version = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("archive_pkey", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
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
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "assembly",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false, defaultValueSql: "NEXT VALUE FOR assembly_id"),
                    parts_id = table.Column<int>(type: "int", nullable: true),
                    qty = table.Column<decimal>(type: "decimal(28,6)", precision: 28, scale: 6, nullable: true),
                    bom = table.Column<bool>(type: "bit", nullable: true),
                    adj = table.Column<bool>(type: "bit", nullable: true),
                    aid = table.Column<int>(type: "int", nullable: true),
                    row_version = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("assembly_id_key", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "audittrail",
                columns: table => new
                {
                    trans_id = table.Column<int>(type: "int", nullable: true),
                    tablename = table.Column<string>(type: "nvarchar(MAX)", nullable: true),
                    reference = table.Column<string>(type: "nvarchar(MAX)", nullable: true),
                    formname = table.Column<string>(type: "nvarchar(MAX)", nullable: true),
                    action = table.Column<string>(type: "nvarchar(MAX)", nullable: true),
                    transdate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "CAST(GETUTCDATE() AS Date)"),
                    employee_id = table.Column<int>(type: "int", nullable: true),
                    row_version = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "archivedata",
                columns: table => new
                {
                    archive_id = table.Column<int>(type: "int", nullable: false),
                    bt = table.Column<string>(type: "nvarchar(MAX)", nullable: true),
                    rn = table.Column<int>(type: "int", nullable: true),
                    row_version = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: true)
                },
                constraints: table =>
                {
                    table.ForeignKey(
                        name: "archivedata_archive_id_fkey",
                        column: x => x.archive_id,
                        principalTable: "archive",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
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
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
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
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
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
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
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
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
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

            migrationBuilder.CreateIndex(
                name: "acc_trans_chart_id_key",
                table: "acc_trans",
                column: "chart_id");

            migrationBuilder.CreateIndex(
                name: "acc_trans_source_key",
                table: "acc_trans",
                column: "source");

            migrationBuilder.CreateIndex(
                name: "acc_trans_trans_id_key",
                table: "acc_trans",
                column: "trans_id");

            migrationBuilder.CreateIndex(
                name: "acc_trans_transdate_key",
                table: "acc_trans",
                column: "transdate");

            migrationBuilder.CreateIndex(
                name: "ap_employee_id_key",
                table: "ap",
                column: "employee_id");

            migrationBuilder.CreateIndex(
                name: "ap_id_key",
                table: "ap",
                column: "id");

            migrationBuilder.CreateIndex(
                name: "ap_invnumber_key",
                table: "ap",
                column: "invnumber");

            migrationBuilder.CreateIndex(
                name: "ap_ordnumber_key",
                table: "ap",
                column: "ordnumber");

            migrationBuilder.CreateIndex(
                name: "ap_quonumber_key",
                table: "ap",
                column: "quonumber");

            migrationBuilder.CreateIndex(
                name: "ap_transdate_key",
                table: "ap",
                column: "transdate");

            migrationBuilder.CreateIndex(
                name: "ap_vendor_id_key",
                table: "ap",
                column: "vendor_id");

            migrationBuilder.CreateIndex(
                name: "ar_customer_id_key",
                table: "ar",
                column: "customer_id");

            migrationBuilder.CreateIndex(
                name: "ar_employee_id_key",
                table: "ar",
                column: "employee_id");

            migrationBuilder.CreateIndex(
                name: "ar_id_key",
                table: "ar",
                column: "id");

            migrationBuilder.CreateIndex(
                name: "ar_invnumber_key",
                table: "ar",
                column: "invnumber");

            migrationBuilder.CreateIndex(
                name: "ar_ordnumber_key",
                table: "ar",
                column: "ordnumber");

            migrationBuilder.CreateIndex(
                name: "ar_quonumber_key",
                table: "ar",
                column: "quonumber");

            migrationBuilder.CreateIndex(
                name: "ar_transdate_key",
                table: "ar",
                column: "transdate");

            migrationBuilder.CreateIndex(
                name: "IX_archivedata_archive_id",
                table: "archivedata",
                column: "archive_id");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

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
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "audittrail_trans_id_key",
                table: "audittrail",
                column: "trans_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "acc_trans");

            migrationBuilder.DropTable(
                name: "acsrole");

            migrationBuilder.DropTable(
                name: "address");

            migrationBuilder.DropTable(
                name: "ap");

            migrationBuilder.DropTable(
                name: "ar");

            migrationBuilder.DropTable(
                name: "archivedata");

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
                name: "assembly");

            migrationBuilder.DropTable(
                name: "audittrail");

            migrationBuilder.DropTable(
                name: "archive");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropSequence(
                name: "address_id");

            migrationBuilder.DropSequence(
                name: "archive_id");

            migrationBuilder.DropSequence(
                name: "assembly_id");

            migrationBuilder.DropSequence(
                name: "public_id");
        }
    }
}
