using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace sqlledger.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
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
                name: "contact_id");

            migrationBuilder.CreateSequence<int>(
                name: "inventory_id");

            migrationBuilder.CreateSequence<int>(
                name: "invoice_id");

            migrationBuilder.CreateSequence<int>(
                name: "jcitems_id");

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
                    row_version = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: true)
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
                name: "bank",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: true),
                    name = table.Column<string>(type: "nvarchar(64)", nullable: true),
                    iban = table.Column<string>(type: "nvarchar(34)", nullable: true),
                    bic = table.Column<string>(type: "nvarchar(11)", nullable: true),
                    address_id = table.Column<int>(type: "int", nullable: false, defaultValueSql: "NEXT VALUE FOR address_id"),
                    dcn = table.Column<string>(type: "nvarchar(MAX)", nullable: true),
                    rvc = table.Column<string>(type: "nvarchar(MAX)", nullable: true),
                    membernumber = table.Column<string>(type: "nvarchar(MAX)", nullable: true),
                    clearingnumber = table.Column<string>(type: "nvarchar(MAX)", nullable: true),
                    row_version = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "br",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false, defaultValueSql: "NEXT VALUE FOR public_id"),
                    batchnumber = table.Column<string>(type: "nvarchar(MAX)", nullable: true),
                    description = table.Column<string>(type: "nvarchar(MAX)", nullable: true),
                    batch = table.Column<string>(type: "nvarchar(MAX)", nullable: true),
                    transdate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETUTCDATE()"),
                    apprdate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    amount = table.Column<decimal>(type: "decimal(28,6)", precision: 28, scale: 6, nullable: true),
                    managerid = table.Column<int>(type: "int", nullable: true),
                    employee_id = table.Column<int>(type: "int", nullable: true),
                    row_version = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("br_pkey", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "business",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false, defaultValueSql: "NEXT VALUE FOR public_id"),
                    description = table.Column<string>(type: "nvarchar(MAX)", nullable: true),
                    discount = table.Column<float>(type: "real", nullable: true),
                    rn = table.Column<int>(type: "int", nullable: true),
                    row_version = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "cargo",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false),
                    trans_id = table.Column<int>(type: "int", nullable: false),
                    package = table.Column<string>(type: "nvarchar(MAX)", nullable: true),
                    netweight = table.Column<decimal>(type: "decimal(28,6)", precision: 28, scale: 6, nullable: true),
                    grossweight = table.Column<decimal>(type: "decimal(28,6)", precision: 28, scale: 6, nullable: true),
                    volume = table.Column<decimal>(type: "decimal(28,6)", precision: 28, scale: 6, nullable: true),
                    row_version = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("cargo_id_key", x => new { x.id, x.trans_id });
                });

            migrationBuilder.CreateTable(
                name: "contact",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false, defaultValueSql: "NEXT VALUE FOR contact_id"),
                    trans_id = table.Column<int>(type: "int", nullable: false),
                    salutation = table.Column<string>(type: "nvarchar(32)", nullable: true),
                    firstname = table.Column<string>(type: "nvarchar(32)", nullable: true),
                    lastname = table.Column<string>(type: "nvarchar(32)", nullable: true),
                    contacttitle = table.Column<string>(type: "nvarchar(32)", nullable: true),
                    occupation = table.Column<string>(type: "nvarchar(32)", nullable: true),
                    phone = table.Column<string>(type: "nvarchar(20)", nullable: true),
                    fax = table.Column<string>(type: "nvarchar(20)", nullable: true),
                    mobile = table.Column<string>(type: "nvarchar(20)", nullable: true),
                    email = table.Column<string>(type: "nvarchar(MAX)", nullable: true),
                    gender = table.Column<string>(type: "char(1)", nullable: false, defaultValue: "M"),
                    parent_id = table.Column<int>(type: "int", nullable: true),
                    typeofcontact = table.Column<string>(type: "nvarchar(20)", nullable: true),
                    row_version = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("contact_pkey", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "curr",
                columns: table => new
                {
                    curr = table.Column<string>(type: "char(3)", maxLength: 3, nullable: false),
                    rn = table.Column<short>(type: "smallint", nullable: true),
                    prec = table.Column<short>(type: "smallint", nullable: true),
                    row_version = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("curr_pkey", x => x.curr);
                });

            migrationBuilder.CreateTable(
                name: "customer",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false, defaultValueSql: "NEXT VALUE FOR public_id"),
                    name = table.Column<string>(type: "nvarchar(64)", nullable: true),
                    contact = table.Column<string>(type: "nvarchar(64)", nullable: true),
                    phone = table.Column<string>(type: "nvarchar(20)", nullable: true),
                    fax = table.Column<string>(type: "nvarchar(20)", nullable: true),
                    email = table.Column<string>(type: "nvarchar(MAX)", nullable: true),
                    notes = table.Column<string>(type: "nvarchar(MAX)", nullable: true),
                    terms = table.Column<short>(type: "smallint", nullable: false, defaultValue: (short)0),
                    taxincluded = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    customernumber = table.Column<string>(type: "nvarchar(32)", nullable: true),
                    cc = table.Column<string>(type: "nvarchar(MAX)", nullable: true),
                    bcc = table.Column<string>(type: "nvarchar(MAX)", nullable: true),
                    business_id = table.Column<int>(type: "int", nullable: true),
                    taxnumber = table.Column<string>(type: "nvarchar(32)", nullable: true),
                    sic_code = table.Column<string>(type: "nvarchar(6)", nullable: true),
                    discount = table.Column<float>(type: "real", nullable: true),
                    creditlimit = table.Column<decimal>(type: "decimal(28,6)", precision: 28, scale: 6, nullable: false, defaultValue: 0m),
                    employee_id = table.Column<int>(type: "int", nullable: true),
                    language_code = table.Column<string>(type: "nvarchar(6)", maxLength: 6, nullable: true),
                    pricegroup_id = table.Column<int>(type: "int", nullable: true),
                    curr = table.Column<string>(type: "char(3)", maxLength: 3, nullable: true),
                    startdate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    enddate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    arap_accno_id = table.Column<int>(type: "int", nullable: true),
                    payment_accno_id = table.Column<int>(type: "int", nullable: true),
                    discount_accno_id = table.Column<int>(type: "int", nullable: true),
                    cashdiscount = table.Column<float>(type: "real", nullable: true),
                    discountterms = table.Column<short>(type: "smallint", nullable: true),
                    threshold = table.Column<decimal>(type: "decimal(28,6)", precision: 28, scale: 6, nullable: true),
                    paymentmethod_id = table.Column<int>(type: "int", nullable: true),
                    remittancevoucher = table.Column<bool>(type: "bit", nullable: true),
                    prepayment_accno_id = table.Column<int>(type: "int", nullable: true),
                    row_version = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("customer_pkey", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "deduction",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false, defaultValueSql: "NEXT VALUE FOR public_id"),
                    description = table.Column<string>(type: "nvarchar(MAX)", nullable: true),
                    employee_accno_id = table.Column<int>(type: "int", nullable: true),
                    employeepays = table.Column<decimal>(type: "decimal(28,6)", precision: 28, scale: 6, nullable: true),
                    employer_accno_id = table.Column<int>(type: "int", nullable: true),
                    employerpays = table.Column<decimal>(type: "decimal(28,6)", precision: 28, scale: 6, nullable: true),
                    fromage = table.Column<short>(type: "smallint", nullable: true),
                    toage = table.Column<short>(type: "smallint", nullable: true),
                    agedob = table.Column<bool>(type: "bit", nullable: true),
                    basedon = table.Column<int>(type: "int", nullable: true),
                    row_version = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("deduction_pkey", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "deductionrate",
                columns: table => new
                {
                    trans_id = table.Column<int>(type: "int", nullable: false),
                    rn = table.Column<short>(type: "smallint", nullable: true),
                    rate = table.Column<decimal>(type: "decimal(28,6)", precision: 28, scale: 6, nullable: true),
                    amount = table.Column<decimal>(type: "decimal(28,6)", precision: 28, scale: 6, nullable: true),
                    above = table.Column<decimal>(type: "decimal(28,6)", precision: 28, scale: 6, nullable: true),
                    below = table.Column<decimal>(type: "decimal(28,6)", precision: 28, scale: 6, nullable: true),
                    row_version = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("deductionrate_pkey", x => x.trans_id);
                });

            migrationBuilder.CreateTable(
                name: "defaults",
                columns: table => new
                {
                    fldname = table.Column<string>(type: "nvarchar(4000)", nullable: false),
                    fldvalue = table.Column<string>(type: "nvarchar(MAX)", nullable: true),
                    row_version = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "department",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false, defaultValueSql: "NEXT VALUE FOR public_id"),
                    description = table.Column<string>(type: "nvarchar(MAX)", nullable: false),
                    role = table.Column<string>(type: "char(1)", nullable: false, defaultValue: "P"),
                    rn = table.Column<int>(type: "int", nullable: true),
                    row_version = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("department_id_key", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "employee",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false, defaultValueSql: "NEXT VALUE FOR public_id"),
                    login = table.Column<string>(type: "nvarchar(4000)", nullable: true),
                    name = table.Column<string>(type: "nvarchar(64)", nullable: true),
                    workphone = table.Column<string>(type: "nvarchar(20)", nullable: true),
                    workfax = table.Column<string>(type: "nvarchar(20)", nullable: true),
                    workmobile = table.Column<string>(type: "nvarchar(20)", nullable: true),
                    homephone = table.Column<string>(type: "nvarchar(20)", nullable: true),
                    homemobile = table.Column<string>(type: "nvarchar(20)", nullable: true),
                    startdate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETUTCDATE()"),
                    enddate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    notes = table.Column<string>(type: "nvarchar(MAX)", nullable: true),
                    sales = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    email = table.Column<string>(type: "nvarchar(MAX)", nullable: true),
                    ssn = table.Column<string>(type: "nvarchar(20)", nullable: true),
                    employeenumber = table.Column<string>(type: "nvarchar(20)", nullable: true),
                    dob = table.Column<DateTime>(type: "datetime2", nullable: true),
                    payperiod = table.Column<short>(type: "smallint", nullable: false),
                    apid = table.Column<int>(type: "int", nullable: true),
                    paymentid = table.Column<int>(type: "int", nullable: true),
                    paymentmethod_id = table.Column<int>(type: "int", nullable: true),
                    acsrole_id = table.Column<int>(type: "int", nullable: true),
                    acs = table.Column<string>(type: "nvarchar(MAX)", nullable: true),
                    row_version = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("employee_pkey", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "employeewage",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: true),
                    employee_id = table.Column<int>(type: "int", nullable: false),
                    wage_id = table.Column<int>(type: "int", nullable: false),
                    row_version = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "gifi",
                columns: table => new
                {
                    accno = table.Column<string>(type: "nvarchar(4000)", nullable: false),
                    description = table.Column<string>(type: "nvarchar(MAX)", nullable: true),
                    row_version = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("gifi_acc_no", x => x.accno);
                });

            migrationBuilder.CreateTable(
                name: "gl",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false, defaultValueSql: "NEXT VALUE FOR public_id"),
                    reference = table.Column<string>(type: "nvarchar(4000)", nullable: true),
                    description = table.Column<string>(type: "nvarchar(4000)", nullable: true),
                    transdate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETUTCDATE()"),
                    employee_id = table.Column<int>(type: "int", nullable: true),
                    notes = table.Column<string>(type: "nvarchar(MAX)", nullable: true),
                    department_id = table.Column<int>(type: "int", nullable: true, defaultValue: 0),
                    approved = table.Column<bool>(type: "bit", nullable: true, defaultValue: true),
                    curr = table.Column<string>(type: "char(3)", maxLength: 3, nullable: true),
                    exchangerate = table.Column<double>(type: "float", nullable: true),
                    row_version = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("gl_id_key", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "inventory",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false, defaultValueSql: "NEXT VALUE FOR inventory_id"),
                    warehouse_id = table.Column<int>(type: "int", nullable: true),
                    parts_id = table.Column<int>(type: "int", nullable: true),
                    trans_id = table.Column<int>(type: "int", nullable: true),
                    orderitems_id = table.Column<int>(type: "int", nullable: true),
                    qty = table.Column<decimal>(type: "decimal(28,6)", precision: 28, scale: 6, nullable: true),
                    shippingdate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    employee_id = table.Column<int>(type: "int", nullable: true),
                    row_version = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("inventory_id_key", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "invoice",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false, defaultValueSql: "NEXT VALUE FOR invoice_id"),
                    trans_id = table.Column<int>(type: "int", nullable: true),
                    parts_id = table.Column<int>(type: "int", nullable: true),
                    description = table.Column<string>(type: "nvarchar(MAX)", nullable: true),
                    qty = table.Column<decimal>(type: "decimal(28,6)", precision: 28, scale: 6, nullable: true),
                    allocated = table.Column<decimal>(type: "decimal(28,6)", precision: 28, scale: 6, nullable: true),
                    sellprice = table.Column<decimal>(type: "decimal(28,6)", precision: 28, scale: 6, nullable: true),
                    fxsellprice = table.Column<decimal>(type: "decimal(28,6)", precision: 28, scale: 6, nullable: true),
                    discount = table.Column<float>(type: "real", nullable: true),
                    assemblyitem = table.Column<bool>(type: "bit", nullable: true, defaultValue: false),
                    unit = table.Column<string>(type: "nvarchar(5)", nullable: true),
                    project_id = table.Column<int>(type: "int", nullable: true),
                    deliverydate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    serialnumber = table.Column<string>(type: "nvarchar(MAX)", nullable: true),
                    itemnotes = table.Column<string>(type: "nvarchar(MAX)", nullable: true),
                    lineitemdetail = table.Column<bool>(type: "bit", nullable: true),
                    ordernumber = table.Column<string>(type: "nvarchar(MAX)", nullable: true),
                    ponumber = table.Column<string>(type: "nvarchar(MAX)", nullable: true),
                    cost = table.Column<decimal>(type: "decimal(28,6)", precision: 28, scale: 6, nullable: true),
                    vendor = table.Column<string>(type: "nvarchar(MAX)", nullable: true),
                    vendor_id = table.Column<int>(type: "int", nullable: true),
                    kititem = table.Column<bool>(type: "bit", nullable: true, defaultValue: false),
                    row_version = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("invoice_pkey", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "jcitems",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false, defaultValueSql: "NEXT VALUE FOR jcitems_id"),
                    project_id = table.Column<int>(type: "int", nullable: true),
                    parts_id = table.Column<int>(type: "int", nullable: true),
                    description = table.Column<string>(type: "nvarchar(MAX)", nullable: true),
                    qty = table.Column<decimal>(type: "decimal(28,6)", precision: 28, scale: 6, nullable: true),
                    allocated = table.Column<decimal>(type: "decimal(28,6)", precision: 28, scale: 6, nullable: true),
                    sellprice = table.Column<decimal>(type: "decimal(28,6)", precision: 28, scale: 6, nullable: true),
                    fxsellprice = table.Column<decimal>(type: "decimal(28,6)", precision: 28, scale: 6, nullable: true),
                    serialnumber = table.Column<string>(type: "nvarchar(MAX)", nullable: true),
                    checkedin = table.Column<DateTime>(type: "datetime2", nullable: true),
                    checkedout = table.Column<DateTime>(type: "datetime2", nullable: true),
                    employee_id = table.Column<int>(type: "int", nullable: true),
                    notes = table.Column<string>(type: "nvarchar(MAX)", nullable: true),
                    row_version = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("jcitems_id_key", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "language",
                columns: table => new
                {
                    code = table.Column<string>(type: "nvarchar(6)", maxLength: 6, nullable: false),
                    description = table.Column<string>(type: "nvarchar(MAX)", nullable: true),
                    rtl = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    row_version = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("language_code_key", x => x.code);
                });

            migrationBuilder.CreateTable(
                name: "makemodel",
                columns: table => new
                {
                    parts_id = table.Column<int>(type: "int", nullable: true),
                    make = table.Column<string>(type: "nvarchar(4000)", nullable: true),
                    model = table.Column<string>(type: "nvarchar(4000)", nullable: true),
                    row_version = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "tax",
                columns: table => new
                {
                    chart_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    rate = table.Column<decimal>(type: "decimal(28,6)", precision: 28, scale: 6, nullable: true),
                    taxnumber = table.Column<string>(type: "nvarchar(MAX)", nullable: true),
                    validto = table.Column<DateTime>(type: "datetime2", nullable: true),
                    row_version = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("tax_pkey", x => x.chart_id);
                });

            migrationBuilder.CreateTable(
                name: "wage",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false, defaultValueSql: "NEXT VALUE FOR public_id"),
                    description = table.Column<string>(type: "nvarchar(MAX)", nullable: true),
                    amount = table.Column<decimal>(type: "decimal(28,6)", precision: 28, scale: 6, nullable: true),
                    defer = table.Column<int>(type: "int", nullable: true),
                    exempt = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    chart_id = table.Column<int>(type: "int", nullable: false),
                    row_version = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("wage_pkey", x => x.id);
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

            migrationBuilder.CreateTable(
                name: "vr",
                columns: table => new
                {
                    br_id = table.Column<int>(type: "int", nullable: false),
                    trans_id = table.Column<int>(type: "int", nullable: false),
                    id = table.Column<int>(type: "int", nullable: false, defaultValueSql: "NEXT VALUE FOR public_id"),
                    vouchernumber = table.Column<string>(type: "nvarchar(MAX)", nullable: true),
                    row_version = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: true)
                },
                constraints: table =>
                {
                    table.ForeignKey(
                        name: "vr_br_id_fkey",
                        column: x => x.br_id,
                        principalTable: "br",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "exchangerate",
                columns: table => new
                {
                    curr = table.Column<string>(type: "char(3)", maxLength: 3, nullable: false),
                    transdate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    exchangerate = table.Column<double>(type: "float", nullable: true),
                    row_version = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("exchangerate_ct_key", x => new { x.curr, x.transdate });
                    table.ForeignKey(
                        name: "exchangerate_curr_id_fkey",
                        column: x => x.curr,
                        principalTable: "curr",
                        principalColumn: "curr",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "deduct",
                columns: table => new
                {
                    trans_id = table.Column<int>(type: "int", nullable: false),
                    deduction_id = table.Column<int>(type: "int", nullable: false),
                    withholding = table.Column<bool>(type: "bit", nullable: true),
                    percent = table.Column<float>(type: "real", nullable: true),
                    row_version = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("deduct_pkey", x => new { x.trans_id, x.deduction_id });
                    table.ForeignKey(
                        name: "FK_deduct_deduction_trans_id",
                        column: x => x.trans_id,
                        principalTable: "deduction",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_deduct_deductionrate_deduction_id",
                        column: x => x.deduction_id,
                        principalTable: "deductionrate",
                        principalColumn: "trans_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "dpt_trans",
                columns: table => new
                {
                    trans_id = table.Column<int>(type: "int", nullable: false),
                    department_id = table.Column<int>(type: "int", nullable: false),
                    row_version = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: true)
                },
                constraints: table =>
                {
                    table.ForeignKey(
                        name: "department_department_id_fkey",
                        column: x => x.department_id,
                        principalTable: "department",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "employeededuction",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: true),
                    employee_id = table.Column<int>(type: "int", nullable: false),
                    deduction_id = table.Column<int>(type: "int", nullable: true),
                    exempt = table.Column<decimal>(type: "decimal(28,6)", precision: 28, scale: 6, nullable: true),
                    maximum = table.Column<decimal>(type: "decimal(28,6)", precision: 28, scale: 6, nullable: true),
                    row_version = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: true)
                },
                constraints: table =>
                {
                    table.ForeignKey(
                        name: "employee_employee_id_fkey",
                        column: x => x.employee_id,
                        principalTable: "employee",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "chart",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false, defaultValueSql: "NEXT VALUE FOR public_id"),
                    accno = table.Column<string>(type: "nvarchar(4000)", nullable: false),
                    description = table.Column<string>(type: "nvarchar(MAX)", nullable: true),
                    charttype = table.Column<string>(type: "char(1)", nullable: false, defaultValue: "A"),
                    category = table.Column<string>(type: "char(1)", nullable: false),
                    link = table.Column<string>(type: "nvarchar(4000)", nullable: true),
                    gifi_accno = table.Column<string>(type: "nvarchar(4000)", nullable: true),
                    contra = table.Column<bool>(type: "bit", nullable: true, defaultValue: false),
                    closed = table.Column<bool>(type: "bit", nullable: true, defaultValue: false),
                    row_version = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: true)
                },
                constraints: table =>
                {
                    table.ForeignKey(
                        name: "chart_gifi_id_fkey",
                        column: x => x.accno,
                        principalTable: "gifi",
                        principalColumn: "accno",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "customertax",
                columns: table => new
                {
                    customer_id = table.Column<int>(type: "int", nullable: false),
                    chart_id = table.Column<int>(type: "int", nullable: false),
                    row_version = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("customer_tax_pkey", x => new { x.customer_id, x.chart_id });
                    table.ForeignKey(
                        name: "FK_customertax_customer_customer_id",
                        column: x => x.customer_id,
                        principalTable: "customer",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_customertax_tax_chart_id",
                        column: x => x.chart_id,
                        principalTable: "tax",
                        principalColumn: "chart_id",
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

            migrationBuilder.CreateIndex(
                name: "chart_accno_key",
                table: "chart",
                column: "accno",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "chart_category_key",
                table: "chart",
                column: "category");

            migrationBuilder.CreateIndex(
                name: "chart_gifi_accno_key",
                table: "chart",
                column: "gifi_accno");

            migrationBuilder.CreateIndex(
                name: "chart_id_key",
                table: "chart",
                column: "id");

            migrationBuilder.CreateIndex(
                name: "chart_link_key",
                table: "chart",
                column: "link");

            migrationBuilder.CreateIndex(
                name: "customer_contact_key",
                table: "customer",
                column: "contact");

            migrationBuilder.CreateIndex(
                name: "customer_name_key",
                table: "customer",
                column: "name");

            migrationBuilder.CreateIndex(
                name: "customer_number_key",
                table: "customer",
                column: "customernumber");

            migrationBuilder.CreateIndex(
                name: "IX_customertax_chart_id",
                table: "customertax",
                column: "chart_id");

            migrationBuilder.CreateIndex(
                name: "IX_deduct_deduction_id",
                table: "deduct",
                column: "deduction_id");

            migrationBuilder.CreateIndex(
                name: "dpt_trans_department_id_key",
                table: "dpt_trans",
                column: "department_id");

            migrationBuilder.CreateIndex(
                name: "employee_login_key",
                table: "employee",
                column: "login",
                unique: true,
                filter: "[login] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "employee_name_key",
                table: "employee",
                column: "name");

            migrationBuilder.CreateIndex(
                name: "IX_employeededuction_employee_id",
                table: "employeededuction",
                column: "employee_id");

            migrationBuilder.CreateIndex(
                name: "gl_description_key",
                table: "gl",
                column: "description");

            migrationBuilder.CreateIndex(
                name: "gl_employee_id_key",
                table: "gl",
                column: "employee_id");

            migrationBuilder.CreateIndex(
                name: "gl_reference_key",
                table: "gl",
                column: "reference");

            migrationBuilder.CreateIndex(
                name: "gl_transdate_key",
                table: "gl",
                column: "transdate");

            migrationBuilder.CreateIndex(
                name: "inventory_parts_id_key",
                table: "inventory",
                column: "parts_id");

            migrationBuilder.CreateIndex(
                name: "invoice_trans_id_key",
                table: "invoice",
                column: "trans_id");

            migrationBuilder.CreateIndex(
                name: "makemodel_make_key",
                table: "makemodel",
                column: "make");

            migrationBuilder.CreateIndex(
                name: "makemodel_model_key",
                table: "makemodel",
                column: "model");

            migrationBuilder.CreateIndex(
                name: "makemodel_parts_id_key",
                table: "makemodel",
                column: "parts_id");

            migrationBuilder.CreateIndex(
                name: "IX_vr_br_id",
                table: "vr",
                column: "br_id");
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
                name: "bank");

            migrationBuilder.DropTable(
                name: "business");

            migrationBuilder.DropTable(
                name: "cargo");

            migrationBuilder.DropTable(
                name: "chart");

            migrationBuilder.DropTable(
                name: "contact");

            migrationBuilder.DropTable(
                name: "customertax");

            migrationBuilder.DropTable(
                name: "deduct");

            migrationBuilder.DropTable(
                name: "defaults");

            migrationBuilder.DropTable(
                name: "dpt_trans");

            migrationBuilder.DropTable(
                name: "employeededuction");

            migrationBuilder.DropTable(
                name: "employeewage");

            migrationBuilder.DropTable(
                name: "exchangerate");

            migrationBuilder.DropTable(
                name: "gl");

            migrationBuilder.DropTable(
                name: "inventory");

            migrationBuilder.DropTable(
                name: "invoice");

            migrationBuilder.DropTable(
                name: "jcitems");

            migrationBuilder.DropTable(
                name: "language");

            migrationBuilder.DropTable(
                name: "makemodel");

            migrationBuilder.DropTable(
                name: "vr");

            migrationBuilder.DropTable(
                name: "wage");

            migrationBuilder.DropTable(
                name: "archive");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "gifi");

            migrationBuilder.DropTable(
                name: "customer");

            migrationBuilder.DropTable(
                name: "tax");

            migrationBuilder.DropTable(
                name: "deduction");

            migrationBuilder.DropTable(
                name: "deductionrate");

            migrationBuilder.DropTable(
                name: "department");

            migrationBuilder.DropTable(
                name: "employee");

            migrationBuilder.DropTable(
                name: "curr");

            migrationBuilder.DropTable(
                name: "br");

            migrationBuilder.DropSequence(
                name: "address_id");

            migrationBuilder.DropSequence(
                name: "archive_id");

            migrationBuilder.DropSequence(
                name: "assembly_id");

            migrationBuilder.DropSequence(
                name: "contact_id");

            migrationBuilder.DropSequence(
                name: "inventory_id");

            migrationBuilder.DropSequence(
                name: "invoice_id");

            migrationBuilder.DropSequence(
                name: "jcitems_id");

            migrationBuilder.DropSequence(
                name: "public_id");
        }
    }
}
