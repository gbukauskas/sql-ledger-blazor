--
-- PostgreSQL database dump
--

-- Dumped from database version 14.9 (Ubuntu 14.9-0ubuntu0.22.04.1)
-- Dumped by pg_dump version 14.9 (Ubuntu 14.9-0ubuntu0.22.04.1)

SET statement_timeout = 0;
SET lock_timeout = 0;
SET idle_in_transaction_session_timeout = 0;
SET client_encoding = 'UTF8';
SET standard_conforming_strings = on;
SELECT pg_catalog.set_config('search_path', '', false);
SET check_function_bodies = false;
SET xmloption = content;
SET client_min_messages = warning;
SET row_security = off;

SET default_tablespace = '';

SET default_table_access_method = heap;

--
-- Name: acc_trans; Type: TABLE; Schema: public; Owner: gediminas
--
/* Perkeltos lentos 
CREATE TABLE public.acc_trans (
    trans_id integer,
    chart_id integer,
    amount double precision,
    transdate date DEFAULT CURRENT_DATE,
    source text,
    approved boolean DEFAULT true,
    fx_transaction boolean DEFAULT false,
    project_id integer,
    memo text,
    id integer,
    cleared date,
    vr_id integer
);

ALTER TABLE public.acc_trans OWNER TO gediminas;

--
-- Name: id; Type: SEQUENCE; Schema: public; Owner: gediminas
--

CREATE SEQUENCE public.id
    START WITH 10000
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;
	
ALTER TABLE public.id OWNER TO gediminas;

--
-- Name: acsrole; Type: TABLE; Schema: public; Owner: gediminas
--
CREATE TABLE public.acsrole (
    id integer DEFAULT nextval('public.id'::regclass) NOT NULL,
    description text,
    acs text,
    rn smallint
);

ALTER TABLE public.acsrole OWNER TO gediminas;

--
-- Name: addressid; Type: SEQUENCE; Schema: public; Owner: gediminas
--

CREATE SEQUENCE public.addressid
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE public.addressid OWNER TO gediminas;

--
-- Name: address; Type: TABLE; Schema: public; Owner: gediminas
--

CREATE TABLE public.address (
    id integer DEFAULT nextval('public.addressid'::regclass) NOT NULL,
    trans_id integer,
    address1 character varying(32),
    address2 character varying(32),
    city character varying(32),
    state character varying(32),
    zipcode character varying(10),
    country character varying(32)
);

ALTER TABLE public.address OWNER TO gediminas;

--
-- Name: ap; Type: TABLE; Schema: public; Owner: gediminas
--

CREATE TABLE public.ap (
    id integer DEFAULT nextval('public.id'::regclass),
    invnumber text,
    transdate date DEFAULT CURRENT_DATE,
    vendor_id integer,
    taxincluded boolean DEFAULT false,
    amount double precision,
    netamount double precision,
    paid double precision,
    datepaid date,
    duedate date,
    invoice boolean DEFAULT false,
    ordnumber text,
    curr character(3),
    notes text,
    employee_id integer,
    till character varying(20),
    quonumber text,
    intnotes text,
    department_id integer DEFAULT 0,
    shipvia text,
    language_code character varying(6),
    ponumber text,
    shippingpoint text,
    terms smallint DEFAULT 0,
    approved boolean DEFAULT true,
    cashdiscount real,
    discountterms smallint,
    waybill text,
    warehouse_id integer,
    description text,
    onhold boolean DEFAULT false,
    exchangerate double precision,
    dcn text,
    bank_id integer,
    paymentmethod_id integer
);


ALTER TABLE public.ap OWNER TO gediminas;
--
-- Name: ar; Type: TABLE; Schema: public; Owner: gediminas
--

CREATE TABLE public.ar (
    id integer DEFAULT nextval('public.id'::regclass),
    invnumber text,
    transdate date DEFAULT CURRENT_DATE,
    customer_id integer,
    taxincluded boolean,
    amount double precision,
    netamount double precision,
    paid double precision,
    datepaid date,
    duedate date,
    invoice boolean DEFAULT false,
    shippingpoint text,
    terms smallint DEFAULT 0,
    notes text,
    curr character(3),
    ordnumber text,
    employee_id integer,
    till character varying(20),
    quonumber text,
    intnotes text,
    department_id integer DEFAULT 0,
    shipvia text,
    language_code character varying(6),
    ponumber text,
    approved boolean DEFAULT true,
    cashdiscount real,
    discountterms smallint,
    waybill text,
    warehouse_id integer,
    description text,
    onhold boolean DEFAULT false,
    exchangerate double precision,
    dcn text,
    bank_id integer,
    paymentmethod_id integer
);

ALTER TABLE public.ar OWNER TO gediminas;

--
-- Name: archiveid; Type: SEQUENCE; Schema: public; Owner: gediminas
--

CREATE SEQUENCE public.archiveid
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE public.archiveid OWNER TO gediminas;

--
-- Name: archive; Type: TABLE; Schema: public; Owner: gediminas
--

CREATE TABLE public.archive (
    id integer DEFAULT nextval('public.archiveid'::regclass) NOT NULL,
    filename text
);


ALTER TABLE public.archive OWNER TO gediminas;

--
-- Name: archivedata; Type: TABLE; Schema: public; Owner: gediminas
--

CREATE TABLE public.archivedata (
    archive_id integer,
    bt text,
    rn integer
);


ALTER TABLE public.archivedata OWNER TO gediminas;

--
-- Name: assemblyid; Type: SEQUENCE; Schema: public; Owner: gediminas
--

CREATE SEQUENCE public.assemblyid
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE public.assemblyid OWNER TO gediminas;

--
-- Name: assembly; Type: TABLE; Schema: public; Owner: gediminas
--

CREATE TABLE public.assembly (
    id integer DEFAULT nextval('public.assemblyid'::regclass),
    parts_id integer,
    qty double precision,
    bom boolean,
    adj boolean,
    aid integer
);


ALTER TABLE public.assembly OWNER TO gediminas;

----------------------------------------------------
*/



--
-- Name: audittrail; Type: TABLE; Schema: public; Owner: gediminas
--

CREATE TABLE public.audittrail (
    trans_id integer,
    tablename text,
    reference text,
    formname text,
    action text,
    transdate timestamp without time zone DEFAULT CURRENT_TIMESTAMP,
    employee_id integer
);


ALTER TABLE public.audittrail OWNER TO gediminas;

--
-- Name: bank; Type: TABLE; Schema: public; Owner: gediminas
--

CREATE TABLE public.bank (
    id integer,
    name character varying(64),
    iban character varying(34),
    bic character varying(11),
    address_id integer DEFAULT nextval('public.addressid'::regclass),
    dcn text,
    rvc text,
    membernumber text,
    clearingnumber text
);


ALTER TABLE public.bank OWNER TO gediminas;

--
-- Name: br; Type: TABLE; Schema: public; Owner: gediminas
--

CREATE TABLE public.br (
    id integer DEFAULT nextval('public.id'::regclass) NOT NULL,
    batchnumber text,
    description text,
    batch text,
    transdate date DEFAULT CURRENT_DATE,
    apprdate date,
    amount double precision,
    managerid integer,
    employee_id integer
);


ALTER TABLE public.br OWNER TO gediminas;

--
-- Name: business; Type: TABLE; Schema: public; Owner: gediminas
--

CREATE TABLE public.business (
    id integer DEFAULT nextval('public.id'::regclass),
    description text,
    discount real,
    rn integer
);


ALTER TABLE public.business OWNER TO gediminas;

--
-- Name: cargo; Type: TABLE; Schema: public; Owner: gediminas
--

CREATE TABLE public.cargo (
    id integer NOT NULL,
    trans_id integer NOT NULL,
    package text,
    netweight double precision,
    grossweight double precision,
    volume double precision
);


ALTER TABLE public.cargo OWNER TO gediminas;

--
-- Name: chart; Type: TABLE; Schema: public; Owner: gediminas
--

CREATE TABLE public.chart (
    id integer DEFAULT nextval('public.id'::regclass),
    accno text NOT NULL,
    description text,
    charttype character(1) DEFAULT 'A'::bpchar,
    category character(1),
    link text,
    gifi_accno text,
    contra boolean DEFAULT false,
    closed boolean DEFAULT false
);


ALTER TABLE public.chart OWNER TO gediminas;

--
-- Name: contactid; Type: SEQUENCE; Schema: public; Owner: gediminas
--

CREATE SEQUENCE public.contactid
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE public.contactid OWNER TO gediminas;

--
-- Name: contact; Type: TABLE; Schema: public; Owner: gediminas
--

CREATE TABLE public.contact (
    id integer DEFAULT nextval('public.contactid'::regclass) NOT NULL,
    trans_id integer NOT NULL,
    salutation character varying(32),
    firstname character varying(32),
    lastname character varying(32),
    contacttitle character varying(32),
    occupation character varying(32),
    phone character varying(20),
    fax character varying(20),
    mobile character varying(20),
    email text,
    gender character(1) DEFAULT 'M'::bpchar,
    parent_id integer,
    typeofcontact character varying(20)
);


ALTER TABLE public.contact OWNER TO gediminas;

--
-- Name: curr; Type: TABLE; Schema: public; Owner: gediminas
--

CREATE TABLE public.curr (
    rn smallint,
    curr character(3) NOT NULL,
    prec smallint
);


ALTER TABLE public.curr OWNER TO gediminas;

--
-- Name: customer; Type: TABLE; Schema: public; Owner: gediminas
--

CREATE TABLE public.customer (
    id integer DEFAULT nextval('public.id'::regclass) NOT NULL,
    name character varying(64),
    contact character varying(64),
    phone character varying(20),
    fax character varying(20),
    email text,
    notes text,
    terms smallint DEFAULT 0,
    taxincluded boolean DEFAULT false,
    customernumber character varying(32),
    cc text,
    bcc text,
    business_id integer,
    taxnumber character varying(32),
    sic_code character varying(6),
    discount real,
    creditlimit double precision DEFAULT 0,
    employee_id integer,
    language_code character varying(6),
    pricegroup_id integer,
    curr character(3),
    startdate date,
    enddate date,
    arap_accno_id integer,
    payment_accno_id integer,
    discount_accno_id integer,
    cashdiscount real,
    discountterms smallint,
    threshold double precision,
    paymentmethod_id integer,
    remittancevoucher boolean,
    prepayment_accno_id integer
);


ALTER TABLE public.customer OWNER TO gediminas;

--
-- Name: customertax; Type: TABLE; Schema: public; Owner: gediminas
--

CREATE TABLE public.customertax (
    customer_id integer,
    chart_id integer
);


ALTER TABLE public.customertax OWNER TO gediminas;

--
-- Name: deduct; Type: TABLE; Schema: public; Owner: gediminas
--

CREATE TABLE public.deduct (
    trans_id integer,
    deduction_id integer,
    withholding boolean,
    percent real
);


ALTER TABLE public.deduct OWNER TO gediminas;

--
-- Name: deduction; Type: TABLE; Schema: public; Owner: gediminas
--

CREATE TABLE public.deduction (
    id integer DEFAULT nextval('public.id'::regclass) NOT NULL,
    description text,
    employee_accno_id integer,
    employeepays real,
    employer_accno_id integer,
    employerpays real,
    fromage smallint,
    toage smallint,
    agedob boolean,
    basedon integer
);


ALTER TABLE public.deduction OWNER TO gediminas;

--
-- Name: deductionrate; Type: TABLE; Schema: public; Owner: gediminas
--

CREATE TABLE public.deductionrate (
    rn smallint,
    trans_id integer,
    rate double precision,
    amount double precision,
    above double precision,
    below double precision
);


ALTER TABLE public.deductionrate OWNER TO gediminas;

--
-- Name: defaults; Type: TABLE; Schema: public; Owner: gediminas
--

CREATE TABLE public.defaults (
    fldname text,
    fldvalue text
);


ALTER TABLE public.defaults OWNER TO gediminas;

--
-- Name: department; Type: TABLE; Schema: public; Owner: gediminas
--

CREATE TABLE public.department (
    id integer DEFAULT nextval('public.id'::regclass),
    description text,
    role character(1) DEFAULT 'P'::bpchar,
    rn integer
);


ALTER TABLE public.department OWNER TO gediminas;

--
-- Name: dpt_trans; Type: TABLE; Schema: public; Owner: gediminas
--

CREATE TABLE public.dpt_trans (
    trans_id integer,
    department_id integer
);


ALTER TABLE public.dpt_trans OWNER TO gediminas;

--
-- Name: employee; Type: TABLE; Schema: public; Owner: gediminas
--

CREATE TABLE public.employee (
    id integer DEFAULT nextval('public.id'::regclass) NOT NULL,
    login text,
    name character varying(64),
    workphone character varying(20),
    workfax character varying(20),
    workmobile character varying(20),
    homephone character varying(20),
    homemobile character varying(20),
    startdate date DEFAULT CURRENT_DATE,
    enddate date,
    notes text,
    sales boolean DEFAULT false,
    email text,
    ssn character varying(20),
    employeenumber character varying(32),
    dob date,
    payperiod smallint,
    apid integer,
    paymentid integer,
    paymentmethod_id integer,
    acsrole_id integer,
    acs text
);


ALTER TABLE public.employee OWNER TO gediminas;

--
-- Name: employeededuction; Type: TABLE; Schema: public; Owner: gediminas
--

CREATE TABLE public.employeededuction (
    id integer,
    employee_id integer,
    deduction_id integer,
    exempt double precision,
    maximum double precision
);


ALTER TABLE public.employeededuction OWNER TO gediminas;

--
-- Name: employeewage; Type: TABLE; Schema: public; Owner: gediminas
--

CREATE TABLE public.employeewage (
    id integer,
    employee_id integer,
    wage_id integer
);


ALTER TABLE public.employeewage OWNER TO gediminas;

--
-- Name: exchangerate; Type: TABLE; Schema: public; Owner: gediminas
--

CREATE TABLE public.exchangerate (
    curr character(3),
    transdate date,
    exchangerate double precision
);


ALTER TABLE public.exchangerate OWNER TO gediminas;

--
-- Name: gifi; Type: TABLE; Schema: public; Owner: gediminas
--

CREATE TABLE public.gifi (
    accno text,
    description text
);


ALTER TABLE public.gifi OWNER TO gediminas;

--
-- Name: gl; Type: TABLE; Schema: public; Owner: gediminas
--

CREATE TABLE public.gl (
    id integer DEFAULT nextval('public.id'::regclass),
    reference text,
    description text,
    transdate date DEFAULT CURRENT_DATE,
    employee_id integer,
    notes text,
    department_id integer DEFAULT 0,
    approved boolean DEFAULT true,
    curr character(3),
    exchangerate double precision
);


ALTER TABLE public.gl OWNER TO gediminas;

--
-- Name: inventoryid; Type: SEQUENCE; Schema: public; Owner: gediminas
--

CREATE SEQUENCE public.inventoryid
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE public.inventoryid OWNER TO gediminas;

--
-- Name: inventory; Type: TABLE; Schema: public; Owner: gediminas
--

CREATE TABLE public.inventory (
    id integer DEFAULT nextval('public.inventoryid'::regclass),
    warehouse_id integer,
    parts_id integer,
    trans_id integer,
    orderitems_id integer,
    qty double precision,
    shippingdate date,
    employee_id integer
);


ALTER TABLE public.inventory OWNER TO gediminas;

--
-- Name: invoiceid; Type: SEQUENCE; Schema: public; Owner: gediminas
--

CREATE SEQUENCE public.invoiceid
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE public.invoiceid OWNER TO gediminas;

--
-- Name: invoice; Type: TABLE; Schema: public; Owner: gediminas
--

CREATE TABLE public.invoice (
    id integer DEFAULT nextval('public.invoiceid'::regclass) NOT NULL,
    trans_id integer,
    parts_id integer,
    description text,
    qty double precision,
    allocated double precision,
    sellprice double precision,
    fxsellprice double precision,
    discount real,
    assemblyitem boolean DEFAULT false,
    unit character varying(5),
    project_id integer,
    deliverydate date,
    serialnumber text,
    itemnotes text,
    lineitemdetail boolean,
    ordernumber text,
    ponumber text,
    cost double precision,
    vendor text,
    vendor_id integer,
    kititem boolean DEFAULT false
);


ALTER TABLE public.invoice OWNER TO gediminas;

--
-- Name: jcitemsid; Type: SEQUENCE; Schema: public; Owner: gediminas
--

CREATE SEQUENCE public.jcitemsid
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE public.jcitemsid OWNER TO gediminas;

--
-- Name: jcitems; Type: TABLE; Schema: public; Owner: gediminas
--

CREATE TABLE public.jcitems (
    id integer DEFAULT nextval('public.jcitemsid'::regclass),
    project_id integer,
    parts_id integer,
    description text,
    qty double precision,
    allocated double precision,
    sellprice double precision,
    fxsellprice double precision,
    serialnumber text,
    checkedin timestamp with time zone,
    checkedout timestamp with time zone,
    employee_id integer,
    notes text
);


ALTER TABLE public.jcitems OWNER TO gediminas;

--
-- Name: language; Type: TABLE; Schema: public; Owner: gediminas
--

CREATE TABLE public.language (
    code character varying(6),
    description text
);


ALTER TABLE public.language OWNER TO gediminas;

--
-- Name: makemodel; Type: TABLE; Schema: public; Owner: gediminas
--

CREATE TABLE public.makemodel (
    parts_id integer,
    make text,
    model text
);


ALTER TABLE public.makemodel OWNER TO gediminas;

--
-- Name: mimetype; Type: TABLE; Schema: public; Owner: gediminas
--

CREATE TABLE public.mimetype (
    extension character varying(32) NOT NULL,
    contenttype character varying(64)
);


ALTER TABLE public.mimetype OWNER TO gediminas;

--
-- Name: oe; Type: TABLE; Schema: public; Owner: gediminas
--

CREATE TABLE public.oe (
    id integer DEFAULT nextval('public.id'::regclass),
    ordnumber text,
    transdate date DEFAULT CURRENT_DATE,
    vendor_id integer,
    customer_id integer,
    amount double precision,
    netamount double precision,
    reqdate date,
    taxincluded boolean,
    shippingpoint text,
    notes text,
    curr character(3),
    employee_id integer,
    closed boolean DEFAULT false,
    quotation boolean DEFAULT false,
    quonumber text,
    intnotes text,
    department_id integer DEFAULT 0,
    shipvia text,
    language_code character varying(6),
    ponumber text,
    terms smallint DEFAULT 0,
    waybill text,
    warehouse_id integer,
    description text,
    aa_id integer,
    exchangerate double precision,
    backorder boolean DEFAULT false
);


ALTER TABLE public.oe OWNER TO gediminas;

--
-- Name: orderitemsid; Type: SEQUENCE; Schema: public; Owner: gediminas
--

CREATE SEQUENCE public.orderitemsid
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE public.orderitemsid OWNER TO gediminas;

--
-- Name: orderitems; Type: TABLE; Schema: public; Owner: gediminas
--

CREATE TABLE public.orderitems (
    id integer DEFAULT nextval('public.orderitemsid'::regclass),
    trans_id integer,
    parts_id integer,
    description text,
    qty double precision,
    sellprice double precision,
    discount real,
    unit character varying(5),
    project_id integer,
    reqdate date,
    ship double precision,
    serialnumber text,
    itemnotes text,
    lineitemdetail boolean,
    ordernumber text,
    ponumber text,
    cost double precision,
    vendor text,
    vendor_id integer
);


ALTER TABLE public.orderitems OWNER TO gediminas;

--
-- Name: parts; Type: TABLE; Schema: public; Owner: gediminas
--

CREATE TABLE public.parts (
    id integer DEFAULT nextval('public.id'::regclass),
    partnumber text,
    description text,
    unit character varying(5),
    listprice double precision,
    sellprice double precision,
    lastcost double precision,
    priceupdate date DEFAULT CURRENT_DATE,
    weight double precision,
    onhand double precision DEFAULT 0,
    notes text,
    makemodel boolean DEFAULT false,
    assembly boolean DEFAULT false,
    alternate boolean DEFAULT false,
    rop double precision,
    inventory_accno_id integer,
    income_accno_id integer,
    expense_accno_id integer,
    bin text,
    obsolete boolean DEFAULT false,
    bom boolean DEFAULT false,
    image text,
    drawing text,
    microfiche text,
    partsgroup_id integer,
    project_id integer,
    avgcost double precision,
    tariff_hscode text,
    countryorigin text,
    barcode text,
    toolnumber text,
    lot text,
    expires date,
    checkinventory boolean DEFAULT false
);


ALTER TABLE public.parts OWNER TO gediminas;

--
-- Name: partscustomer; Type: TABLE; Schema: public; Owner: gediminas
--

CREATE TABLE public.partscustomer (
    parts_id integer,
    customer_id integer,
    pricegroup_id integer,
    pricebreak double precision,
    sellprice double precision,
    validfrom date,
    validto date,
    curr character(3)
);


ALTER TABLE public.partscustomer OWNER TO gediminas;

--
-- Name: partsgroup; Type: TABLE; Schema: public; Owner: gediminas
--

CREATE TABLE public.partsgroup (
    id integer DEFAULT nextval('public.id'::regclass),
    partsgroup text,
    pos boolean DEFAULT true,
    code text,
    image text
);


ALTER TABLE public.partsgroup OWNER TO gediminas;

--
-- Name: partstax; Type: TABLE; Schema: public; Owner: gediminas
--

CREATE TABLE public.partstax (
    parts_id integer,
    chart_id integer
);


ALTER TABLE public.partstax OWNER TO gediminas;

--
-- Name: partsvendor; Type: TABLE; Schema: public; Owner: gediminas
--

CREATE TABLE public.partsvendor (
    vendor_id integer,
    parts_id integer,
    partnumber text,
    leadtime smallint,
    lastcost double precision,
    curr character(3)
);


ALTER TABLE public.partsvendor OWNER TO gediminas;

--
-- Name: pay_trans; Type: TABLE; Schema: public; Owner: gediminas
--

CREATE TABLE public.pay_trans (
    trans_id integer,
    id integer,
    glid integer,
    qty double precision,
    amount double precision
);


ALTER TABLE public.pay_trans OWNER TO gediminas;

--
-- Name: payment; Type: TABLE; Schema: public; Owner: gediminas
--

CREATE TABLE public.payment (
    id integer NOT NULL,
    trans_id integer NOT NULL,
    exchangerate double precision DEFAULT 1,
    paymentmethod_id integer
);


ALTER TABLE public.payment OWNER TO gediminas;

--
-- Name: paymentmethod; Type: TABLE; Schema: public; Owner: gediminas
--

CREATE TABLE public.paymentmethod (
    id integer DEFAULT nextval('public.id'::regclass) NOT NULL,
    description text,
    fee double precision,
    rn integer,
    roundchange real
);


ALTER TABLE public.paymentmethod OWNER TO gediminas;

--
-- Name: payrate; Type: TABLE; Schema: public; Owner: gediminas
--

CREATE TABLE public.payrate (
    trans_id integer,
    id integer,
    rate double precision,
    above double precision
);


ALTER TABLE public.payrate OWNER TO gediminas;

--
-- Name: pricegroup; Type: TABLE; Schema: public; Owner: gediminas
--

CREATE TABLE public.pricegroup (
    id integer DEFAULT nextval('public.id'::regclass),
    pricegroup text
);


ALTER TABLE public.pricegroup OWNER TO gediminas;

--
-- Name: project; Type: TABLE; Schema: public; Owner: gediminas
--

CREATE TABLE public.project (
    id integer DEFAULT nextval('public.id'::regclass),
    projectnumber text,
    description text,
    startdate date,
    enddate date,
    parts_id integer,
    production double precision DEFAULT 0,
    completed double precision DEFAULT 0,
    customer_id integer
);


ALTER TABLE public.project OWNER TO gediminas;

--
-- Name: recurring; Type: TABLE; Schema: public; Owner: gediminas
--

CREATE TABLE public.recurring (
    id integer,
    reference text,
    startdate date,
    nextdate date,
    enddate date,
    repeat smallint,
    unit character varying(6),
    howmany integer,
    payment boolean DEFAULT false,
    description text
);


ALTER TABLE public.recurring OWNER TO gediminas;

--
-- Name: recurringemail; Type: TABLE; Schema: public; Owner: gediminas
--

CREATE TABLE public.recurringemail (
    id integer,
    formname text,
    format text,
    message text
);


ALTER TABLE public.recurringemail OWNER TO gediminas;

--
-- Name: recurringprint; Type: TABLE; Schema: public; Owner: gediminas
--

CREATE TABLE public.recurringprint (
    id integer,
    formname text,
    format text,
    printer text
);


ALTER TABLE public.recurringprint OWNER TO gediminas;

--
-- Name: referenceid; Type: SEQUENCE; Schema: public; Owner: gediminas
--

CREATE SEQUENCE public.referenceid
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE public.referenceid OWNER TO gediminas;

--
-- Name: reference; Type: TABLE; Schema: public; Owner: gediminas
--

CREATE TABLE public.reference (
    id integer DEFAULT nextval('public.referenceid'::regclass) NOT NULL,
    code text,
    trans_id integer,
    description text,
    archive_id integer,
    login text,
    formname text,
    folder text
);


ALTER TABLE public.reference OWNER TO gediminas;

--
-- Name: report; Type: TABLE; Schema: public; Owner: gediminas
--

CREATE TABLE public.report (
    reportid integer DEFAULT nextval('public.id'::regclass) NOT NULL,
    reportcode text,
    reportdescription text,
    login text
);


ALTER TABLE public.report OWNER TO gediminas;

--
-- Name: reportvars; Type: TABLE; Schema: public; Owner: gediminas
--

CREATE TABLE public.reportvars (
    reportid integer NOT NULL,
    reportvariable text,
    reportvalue text
);


ALTER TABLE public.reportvars OWNER TO gediminas;

--
-- Name: semaphore; Type: TABLE; Schema: public; Owner: gediminas
--

CREATE TABLE public.semaphore (
    id integer,
    login text,
    module text,
    expires character varying(12)
);


ALTER TABLE public.semaphore OWNER TO gediminas;

--
-- Name: shipto; Type: TABLE; Schema: public; Owner: gediminas
--

CREATE TABLE public.shipto (
    trans_id integer,
    shiptoname character varying(64),
    shiptoaddress1 character varying(32),
    shiptoaddress2 character varying(32),
    shiptocity character varying(32),
    shiptostate character varying(32),
    shiptozipcode character varying(10),
    shiptocountry character varying(32),
    shiptocontact character varying(64),
    shiptophone character varying(20),
    shiptofax character varying(20),
    shiptoemail text,
    shiptorecurring boolean DEFAULT false
);


ALTER TABLE public.shipto OWNER TO gediminas;

--
-- Name: sic; Type: TABLE; Schema: public; Owner: gediminas
--

CREATE TABLE public.sic (
    code character varying(6),
    sictype character(1),
    description text
);


ALTER TABLE public.sic OWNER TO gediminas;

--
-- Name: status; Type: TABLE; Schema: public; Owner: gediminas
--

CREATE TABLE public.status (
    trans_id integer,
    formname text,
    printed boolean DEFAULT false,
    emailed boolean DEFAULT false,
    spoolfile text
);


ALTER TABLE public.status OWNER TO gediminas;

--
-- Name: tax; Type: TABLE; Schema: public; Owner: gediminas
--

CREATE TABLE public.tax (
    chart_id integer,
    rate double precision,
    taxnumber text,
    validto date
);


ALTER TABLE public.tax OWNER TO gediminas;

--
-- Name: translation; Type: TABLE; Schema: public; Owner: gediminas
--

CREATE TABLE public.translation (
    trans_id integer,
    language_code character varying(6),
    description text
);


ALTER TABLE public.translation OWNER TO gediminas;

--
-- Name: vendor; Type: TABLE; Schema: public; Owner: gediminas
--

CREATE TABLE public.vendor (
    id integer DEFAULT nextval('public.id'::regclass) NOT NULL,
    name character varying(64),
    contact character varying(64),
    phone character varying(20),
    fax character varying(20),
    email text,
    notes text,
    terms smallint DEFAULT 0,
    taxincluded boolean DEFAULT false,
    vendornumber character varying(32),
    cc text,
    bcc text,
    gifi_accno character varying(30),
    business_id integer,
    taxnumber character varying(32),
    sic_code character varying(6),
    discount real,
    creditlimit double precision DEFAULT 0,
    employee_id integer,
    language_code character varying(6),
    pricegroup_id integer,
    curr character(3),
    startdate date,
    enddate date,
    arap_accno_id integer,
    payment_accno_id integer,
    discount_accno_id integer,
    cashdiscount real,
    discountterms smallint,
    threshold double precision,
    paymentmethod_id integer,
    remittancevoucher boolean,
    prepayment_accno_id integer
);


ALTER TABLE public.vendor OWNER TO gediminas;

--
-- Name: vendortax; Type: TABLE; Schema: public; Owner: gediminas
--

CREATE TABLE public.vendortax (
    vendor_id integer,
    chart_id integer
);


ALTER TABLE public.vendortax OWNER TO gediminas;

--
-- Name: vr; Type: TABLE; Schema: public; Owner: gediminas
--

CREATE TABLE public.vr (
    br_id integer,
    trans_id integer NOT NULL,
    id integer DEFAULT nextval('public.id'::regclass) NOT NULL,
    vouchernumber text
);


ALTER TABLE public.vr OWNER TO gediminas;

--
-- Name: wage; Type: TABLE; Schema: public; Owner: gediminas
--

CREATE TABLE public.wage (
    id integer DEFAULT nextval('public.id'::regclass) NOT NULL,
    description text,
    amount double precision,
    defer integer,
    exempt boolean DEFAULT false,
    chart_id integer
);


ALTER TABLE public.wage OWNER TO gediminas;

--
-- Name: warehouse; Type: TABLE; Schema: public; Owner: gediminas
--

CREATE TABLE public.warehouse (
    id integer DEFAULT nextval('public.id'::regclass),
    description text,
    rn integer
);


ALTER TABLE public.warehouse OWNER TO gediminas;

--
-- Name: yearend; Type: TABLE; Schema: public; Owner: gediminas
--

CREATE TABLE public.yearend (
    trans_id integer,
    transdate date
);


ALTER TABLE public.yearend OWNER TO gediminas;

--
-- Data for Name: acc_trans; Type: TABLE DATA; Schema: public; Owner: gediminas
--

COPY public.acc_trans (trans_id, chart_id, amount, transdate, source, approved, fx_transaction, project_id, memo, id, cleared, vr_id) FROM stdin;
\.


--
-- Data for Name: acsrole; Type: TABLE DATA; Schema: public; Owner: gediminas
--

COPY public.acsrole (id, description, acs, rn) FROM stdin;
\.


--
-- Data for Name: address; Type: TABLE DATA; Schema: public; Owner: gediminas
--

COPY public.address (id, trans_id, address1, address2, city, state, zipcode, country) FROM stdin;
\.


--
-- Data for Name: ap; Type: TABLE DATA; Schema: public; Owner: gediminas
--

COPY public.ap (id, invnumber, transdate, vendor_id, taxincluded, amount, netamount, paid, datepaid, duedate, invoice, ordnumber, curr, notes, employee_id, till, quonumber, intnotes, department_id, shipvia, language_code, ponumber, shippingpoint, terms, approved, cashdiscount, discountterms, waybill, warehouse_id, description, onhold, exchangerate, dcn, bank_id, paymentmethod_id) FROM stdin;
\.


--
-- Data for Name: ar; Type: TABLE DATA; Schema: public; Owner: gediminas
--

COPY public.ar (id, invnumber, transdate, customer_id, taxincluded, amount, netamount, paid, datepaid, duedate, invoice, shippingpoint, terms, notes, curr, ordnumber, employee_id, till, quonumber, intnotes, department_id, shipvia, language_code, ponumber, approved, cashdiscount, discountterms, waybill, warehouse_id, description, onhold, exchangerate, dcn, bank_id, paymentmethod_id) FROM stdin;
\.


--
-- Data for Name: archive; Type: TABLE DATA; Schema: public; Owner: gediminas
--

COPY public.archive (id, filename) FROM stdin;
\.


--
-- Data for Name: archivedata; Type: TABLE DATA; Schema: public; Owner: gediminas
--

COPY public.archivedata (archive_id, bt, rn) FROM stdin;
\.


--
-- Data for Name: assembly; Type: TABLE DATA; Schema: public; Owner: gediminas
--

COPY public.assembly (id, parts_id, qty, bom, adj, aid) FROM stdin;
\.


--
-- Data for Name: audittrail; Type: TABLE DATA; Schema: public; Owner: gediminas
--

COPY public.audittrail (trans_id, tablename, reference, formname, action, transdate, employee_id) FROM stdin;
\.


--
-- Data for Name: bank; Type: TABLE DATA; Schema: public; Owner: gediminas
--

COPY public.bank (id, name, iban, bic, address_id, dcn, rvc, membernumber, clearingnumber) FROM stdin;
\.


--
-- Data for Name: br; Type: TABLE DATA; Schema: public; Owner: gediminas
--

COPY public.br (id, batchnumber, description, batch, transdate, apprdate, amount, managerid, employee_id) FROM stdin;
\.


--
-- Data for Name: business; Type: TABLE DATA; Schema: public; Owner: gediminas
--

COPY public.business (id, description, discount, rn) FROM stdin;
\.


--
-- Data for Name: cargo; Type: TABLE DATA; Schema: public; Owner: gediminas
--

COPY public.cargo (id, trans_id, package, netweight, grossweight, volume) FROM stdin;
\.


--
-- Data for Name: chart; Type: TABLE DATA; Schema: public; Owner: gediminas
--

COPY public.chart (id, accno, description, charttype, category, link, gifi_accno, contra, closed) FROM stdin;
10001	1000	CURRENT ASSETS	H	A			f	f
10002	1060	Checking Account	A	A	AR_paid:AP_paid		f	f
10003	1065	Petty Cash	A	A	AR_paid:AP_paid		f	f
10004	1200	Accounts Receivables	A	A	AR		f	f
10005	1205	Allowance for doubtful accounts	A	A			f	f
10006	1500	INVENTORY ASSETS	H	A			f	f
10007	1520	Inventory / General	A	A	IC		f	f
10008	1530	Inventory / Aftermarket Parts	A	A	IC		f	f
10009	1800	CAPITAL ASSETS	H	A			f	f
10010	1820	Office Furniture & Equipment	A	A			f	f
10011	1825	Accum. Amort. -Furn. & Equip.	A	A			t	f
10012	1840	Vehicle	A	A			f	f
10013	1845	Accum. Amort. -Vehicle	A	A			t	f
10014	2000	CURRENT LIABILITIES	H	L			f	f
10015	2100	Accounts Payable	A	L	AP		f	f
10016	2160	Corporate Taxes Payable	A	L			f	f
10017	2190	Federal Income Tax Payable	A	L			f	f
10018	2210	Workers Comp Payable	A	L			f	f
10019	2220	Vacation Pay Payable	A	L			f	f
10020	2250	Pension Plan Payable	A	L			f	f
10021	2260	Employment Insurance Payable	A	L			f	f
10022	2280	Payroll Taxes Payable	A	L			f	f
10023	2310	VAT (10%)	A	L	AR_tax:AP_tax:IC_taxpart:IC_taxservice		f	f
10024	2320	VAT (14%)	A	L	AR_tax:AP_tax:IC_taxpart:IC_taxservice		f	f
10025	2330	VAT (30%)	A	L	AR_tax:AP_tax:IC_taxpart:IC_taxservice		f	f
10026	2600	LONG TERM LIABILITIES	H	L			f	f
10027	2620	Bank Loans	A	L			f	f
10028	2680	Loans from Shareholders	A	L	AP_paid		f	f
10029	3300	SHARE CAPITAL	H	Q			f	f
10030	3350	Common Shares	A	Q			f	f
10031	4000	SALES REVENUE	H	I			f	f
10032	4020	Sales / General	A	I	AR_amount:IC_sale		f	f
10033	4030	Sales / Aftermarket Parts	A	I	AR_amount:IC_sale		f	f
10034	4300	CONSULTING REVENUE	H	I			f	f
10035	4320	Consulting	A	I	AR_amount:IC_income		f	f
10036	4400	OTHER REVENUE	H	I			f	f
10037	4430	Shipping & Handling	A	I	IC_income		f	f
10038	4440	Interest	A	I			f	f
10039	4450	Foreign Exchange Gain	A	I			f	f
10040	5000	COST OF GOODS SOLD	H	E			f	f
10041	5010	Purchases	A	E	AP_amount:IC_expense		f	f
10042	5020	COGS / General	A	E	AP_amount:IC_cogs		f	f
10043	5030	COGS / Aftermarket Parts	A	E	AP_amount:IC_cogs		f	f
10044	5100	Freight	A	E	AP_amount:IC_expense		f	f
10045	5400	PAYROLL EXPENSES	H	E			f	f
10046	5410	Wages & Salaries	A	E			f	f
10047	5420	Employment Insurance Expense	A	E			f	f
10048	5430	Pension Plan Expense	A	E			f	f
10049	5440	Workers Comp Expense	A	E			f	f
10050	5470	Employee Benefits	A	E			f	f
10051	5600	GENERAL & ADMINISTRATIVE EXPENSES	H	E			f	f
10052	5610	Accounting & Legal	A	E	AP_amount		f	f
10053	5615	Advertising & Promotions	A	E	AP_amount		f	f
10054	5620	Bad Debts	A	E			f	f
10055	5650	Capital Cost Allowance Expense	A	E			f	f
10056	5660	Amortization Expense	A	E			f	f
10057	5680	Income Taxes	A	E			f	f
10058	5685	Insurance	A	E	AP_amount		f	f
10059	5690	Interest & Bank Charges	A	E			f	f
10060	5700	Office Supplies	A	E	AP_amount		f	f
10061	5760	Rent	A	E	AP_amount		f	f
10062	5765	Repair & Maintenance	A	E	AP_amount		f	f
10063	5780	Telephone	A	E	AP_amount		f	f
10064	5785	Travel & Entertainment	A	E			f	f
10065	5790	Utilities	A	E	AP_amount		f	f
10066	5795	Registrations	A	E	AP_amount		f	f
10067	5800	Licenses	A	E	AP_amount		f	f
10068	5810	Foreign Exchange Loss	A	E			f	f
\.


--
-- Data for Name: contact; Type: TABLE DATA; Schema: public; Owner: gediminas
--

COPY public.contact (id, trans_id, salutation, firstname, lastname, contacttitle, occupation, phone, fax, mobile, email, gender, parent_id, typeofcontact) FROM stdin;
\.


--
-- Data for Name: curr; Type: TABLE DATA; Schema: public; Owner: gediminas
--

COPY public.curr (rn, curr, prec) FROM stdin;
1	USD	2
2	CAD	2
3	EUR	2
\.


--
-- Data for Name: customer; Type: TABLE DATA; Schema: public; Owner: gediminas
--

COPY public.customer (id, name, contact, phone, fax, email, notes, terms, taxincluded, customernumber, cc, bcc, business_id, taxnumber, sic_code, discount, creditlimit, employee_id, language_code, pricegroup_id, curr, startdate, enddate, arap_accno_id, payment_accno_id, discount_accno_id, cashdiscount, discountterms, threshold, paymentmethod_id, remittancevoucher, prepayment_accno_id) FROM stdin;
\.


--
-- Data for Name: customertax; Type: TABLE DATA; Schema: public; Owner: gediminas
--

COPY public.customertax (customer_id, chart_id) FROM stdin;
\.


--
-- Data for Name: deduct; Type: TABLE DATA; Schema: public; Owner: gediminas
--

COPY public.deduct (trans_id, deduction_id, withholding, percent) FROM stdin;
\.


--
-- Data for Name: deduction; Type: TABLE DATA; Schema: public; Owner: gediminas
--

COPY public.deduction (id, description, employee_accno_id, employeepays, employer_accno_id, employerpays, fromage, toage, agedob, basedon) FROM stdin;
\.


--
-- Data for Name: deductionrate; Type: TABLE DATA; Schema: public; Owner: gediminas
--

COPY public.deductionrate (rn, trans_id, rate, amount, above, below) FROM stdin;
\.


--
-- Data for Name: defaults; Type: TABLE DATA; Schema: public; Owner: gediminas
--

COPY public.defaults (fldname, fldvalue) FROM stdin;
version	3.2.4
inventory_accno_id	10007
income_accno_id	10032
expense_accno_id	10041
fxgain_accno_id	10039
fxloss_accno_id	10068
weightunit	kg
precision	2
company	Home computer
roundchange	0.01
\.


--
-- Data for Name: department; Type: TABLE DATA; Schema: public; Owner: gediminas
--

COPY public.department (id, description, role, rn) FROM stdin;
\.


--
-- Data for Name: dpt_trans; Type: TABLE DATA; Schema: public; Owner: gediminas
--

COPY public.dpt_trans (trans_id, department_id) FROM stdin;
\.


--
-- Data for Name: employee; Type: TABLE DATA; Schema: public; Owner: gediminas
--

COPY public.employee (id, login, name, workphone, workfax, workmobile, homephone, homemobile, startdate, enddate, notes, sales, email, ssn, employeenumber, dob, payperiod, apid, paymentid, paymentmethod_id, acsrole_id, acs) FROM stdin;
\.


--
-- Data for Name: employeededuction; Type: TABLE DATA; Schema: public; Owner: gediminas
--

COPY public.employeededuction (id, employee_id, deduction_id, exempt, maximum) FROM stdin;
\.


--
-- Data for Name: employeewage; Type: TABLE DATA; Schema: public; Owner: gediminas
--

COPY public.employeewage (id, employee_id, wage_id) FROM stdin;
\.


--
-- Data for Name: exchangerate; Type: TABLE DATA; Schema: public; Owner: gediminas
--

COPY public.exchangerate (curr, transdate, exchangerate) FROM stdin;
\.


--
-- Data for Name: gifi; Type: TABLE DATA; Schema: public; Owner: gediminas
--

COPY public.gifi (accno, description) FROM stdin;
\.


--
-- Data for Name: gl; Type: TABLE DATA; Schema: public; Owner: gediminas
--

COPY public.gl (id, reference, description, transdate, employee_id, notes, department_id, approved, curr, exchangerate) FROM stdin;
\.


--
-- Data for Name: inventory; Type: TABLE DATA; Schema: public; Owner: gediminas
--

COPY public.inventory (id, warehouse_id, parts_id, trans_id, orderitems_id, qty, shippingdate, employee_id) FROM stdin;
\.


--
-- Data for Name: invoice; Type: TABLE DATA; Schema: public; Owner: gediminas
--

COPY public.invoice (id, trans_id, parts_id, description, qty, allocated, sellprice, fxsellprice, discount, assemblyitem, unit, project_id, deliverydate, serialnumber, itemnotes, lineitemdetail, ordernumber, ponumber, cost, vendor, vendor_id, kititem) FROM stdin;
\.


--
-- Data for Name: jcitems; Type: TABLE DATA; Schema: public; Owner: gediminas
--

COPY public.jcitems (id, project_id, parts_id, description, qty, allocated, sellprice, fxsellprice, serialnumber, checkedin, checkedout, employee_id, notes) FROM stdin;
\.


--
-- Data for Name: language; Type: TABLE DATA; Schema: public; Owner: gediminas
--

COPY public.language (code, description) FROM stdin;
\.


--
-- Data for Name: makemodel; Type: TABLE DATA; Schema: public; Owner: gediminas
--

COPY public.makemodel (parts_id, make, model) FROM stdin;
\.


--
-- Data for Name: mimetype; Type: TABLE DATA; Schema: public; Owner: gediminas
--

COPY public.mimetype (extension, contenttype) FROM stdin;
acx	application/internet-property-stream
ai	application/postscript
aif	audio/x-aiff
aifc	audio/x-aiff
aiff	audio/x-aiff
asf	video/x-ms-asf
asr	video/x-ms-asf
asx	video/x-ms-asf
au	audio/basic
avi	video/x-msvideo
axs	application/olescript
bas	text/plain
bcpio	application/x-bcpio
bin	application/octet-stream
bmp	image/bmp
c	text/plain
cat	application/vnd.ms-pkiseccat
cdf	application/x-cdf
cer	application/x-x509-ca-cert
class	application/octet-stream
clp	application/x-msclip
cmx	image/x-cmx
cod	image/cis-cod
cpio	application/x-cpio
crd	application/x-mscardfile
crl	application/pkix-crl
crt	application/x-x509-ca-cert
csh	application/x-csh
css	text/css
dcr	application/x-director
der	application/x-x509-ca-cert
dir	application/x-director
dll	application/x-msdownload
dms	application/octet-stream
doc	application/msword
dot	application/msword
dvi	application/x-dvi
dxr	application/x-director
eps	application/postscript
etx	text/x-setext
evy	application/envoy
exe	application/octet-stream
fif	application/fractals
flr	x-world/x-vrml
gif	image/gif
gtar	application/x-gtar
gz	application/x-gzip
h	text/plain
hdf	application/x-hdf
hlp	application/winhlp
hqx	application/mac-binhex40
hta	application/hta
htc	text/x-component
htm	text/html
html	text/html
htt	text/webviewhtml
ico	image/x-icon
ief	image/ief
iii	application/x-iphone
ins	application/x-internet-signup
isp	application/x-internet-signup
jfif	image/pipeg
jpe	image/jpeg
jpeg	image/jpeg
jpg	image/jpeg
js	application/x-javascript
latex	application/x-latex
lha	application/octet-stream
lsf	video/x-la-asf
lsx	video/x-la-asf
lzh	application/octet-stream
m13	application/x-msmediaview
m14	application/x-msmediaview
m3u	audio/x-mpegurl
man	application/x-troff-man
mdb	application/x-msaccess
me	application/x-troff-me
mht	message/rfc822
mhtml	message/rfc822
mid	audio/mid
mny	application/x-msmoney
mov	video/quicktime
movie	video/x-sgi-movie
mp2	video/mpeg
mp3	audio/mpeg
mpa	video/mpeg
mpe	video/mpeg
mpeg	video/mpeg
mpg	video/mpeg
mpp	application/vnd.ms-project
mpv2	video/mpeg
ms	application/x-troff-ms
mvb	application/x-msmediaview
nws	message/rfc822
oda	application/oda
ods	application/vnd.oasis.opendocument.spreadsheet
odt	application/vnd.oasis.opendocument.document
p10	application/pkcs10
p12	application/x-pkcs12
p7b	application/x-pkcs7-certificates
p7c	application/x-pkcs7-mime
p7m	application/x-pkcs7-mime
p7r	application/x-pkcs7-certreqresp
p7s	application/x-pkcs7-signature
pbm	image/x-portable-bitmap
pdf	application/pdf
pfx	application/x-pkcs12
pgm	image/x-portable-graymap
pko	application/ynd.ms-pkipko
pma	application/x-perfmon
pmc	application/x-perfmon
pml	application/x-perfmon
pmr	application/x-perfmon
pmw	application/x-perfmon
png	image/png
pnm	image/x-portable-anymap
pot	application/vnd.ms-powerpoint
ppm	image/x-portable-pixmap
pps	application/vnd.ms-powerpoint
ppt	application/vnd.ms-powerpoint
prf	application/pics-rules
ps	application/postscript
pub	application/x-mspublisher
qt	video/quicktime
ra	audio/x-pn-realaudio
ram	audio/x-pn-realaudio
ras	image/x-cmu-raster
rgb	image/x-rgb
rmi	audio/mid
roff	application/x-troff
rtf	application/rtf
rtx	text/richtext
scd	application/x-msschedule
sct	text/scriptlet
setpay	application/set-payment-initiation
setreg	application/set-registration-initiation
sh	application/x-sh
shar	application/x-shar
sit	application/x-stuffit
snd	audio/basic
spc	application/x-pkcs7-certificates
spl	application/futuresplash
src	application/x-wais-source
sst	application/vnd.ms-pkicertstore
stl	application/vnd.ms-pkistl
stm	text/html
svg	image/svg+xml
sv4cpio	application/x-sv4cpio
sv4crc	application/x-sv4crc
swf	application/x-shockwave-flash
t	application/x-troff
tar	application/x-tar
tcl	application/x-tcl
tex	application/x-tex
texi	application/x-texinfo
texinfo	application/x-texinfo
tgz	application/x-compressed
tif	image/tiff
tiff	image/tiff
tr	application/x-troff
trm	application/x-msterminal
tsv	text/tab-separated-values
txt	text/plain
uls	text/iuls
ustar	application/x-ustar
vcf	text/x-vcard
vrml	x-world/x-vrml
wav	audio/x-wav
wcm	application/vnd.ms-works
wdb	application/vnd.ms-works
wks	application/vnd.ms-works
wmf	application/x-msmetafile
wps	application/vnd.ms-works
wri	application/x-mswrite
wrl	x-world/x-vrml
wrz	x-world/x-vrml
xaf	x-world/x-vrml
xbm	image/x-xbitmap
xla	application/vnd.ms-excel
xlc	application/vnd.ms-excel
xlm	application/vnd.ms-excel
xls	application/vnd.ms-excel
xlt	application/vnd.ms-excel
xlw	application/vnd.ms-excel
xof	x-world/x-vrml
xpm	image/x-xpixmap
xwd	image/x-xwindowdump
z	application/x-compress
zip	application/zip
\.


--
-- Data for Name: oe; Type: TABLE DATA; Schema: public; Owner: gediminas
--

COPY public.oe (id, ordnumber, transdate, vendor_id, customer_id, amount, netamount, reqdate, taxincluded, shippingpoint, notes, curr, employee_id, closed, quotation, quonumber, intnotes, department_id, shipvia, language_code, ponumber, terms, waybill, warehouse_id, description, aa_id, exchangerate, backorder) FROM stdin;
\.


--
-- Data for Name: orderitems; Type: TABLE DATA; Schema: public; Owner: gediminas
--

COPY public.orderitems (id, trans_id, parts_id, description, qty, sellprice, discount, unit, project_id, reqdate, ship, serialnumber, itemnotes, lineitemdetail, ordernumber, ponumber, cost, vendor, vendor_id) FROM stdin;
\.


--
-- Data for Name: parts; Type: TABLE DATA; Schema: public; Owner: gediminas
--

COPY public.parts (id, partnumber, description, unit, listprice, sellprice, lastcost, priceupdate, weight, onhand, notes, makemodel, assembly, alternate, rop, inventory_accno_id, income_accno_id, expense_accno_id, bin, obsolete, bom, image, drawing, microfiche, partsgroup_id, project_id, avgcost, tariff_hscode, countryorigin, barcode, toolnumber, lot, expires, checkinventory) FROM stdin;
\.


--
-- Data for Name: partscustomer; Type: TABLE DATA; Schema: public; Owner: gediminas
--

COPY public.partscustomer (parts_id, customer_id, pricegroup_id, pricebreak, sellprice, validfrom, validto, curr) FROM stdin;
\.


--
-- Data for Name: partsgroup; Type: TABLE DATA; Schema: public; Owner: gediminas
--

COPY public.partsgroup (id, partsgroup, pos, code, image) FROM stdin;
\.


--
-- Data for Name: partstax; Type: TABLE DATA; Schema: public; Owner: gediminas
--

COPY public.partstax (parts_id, chart_id) FROM stdin;
\.


--
-- Data for Name: partsvendor; Type: TABLE DATA; Schema: public; Owner: gediminas
--

COPY public.partsvendor (vendor_id, parts_id, partnumber, leadtime, lastcost, curr) FROM stdin;
\.


--
-- Data for Name: pay_trans; Type: TABLE DATA; Schema: public; Owner: gediminas
--

COPY public.pay_trans (trans_id, id, glid, qty, amount) FROM stdin;
\.


--
-- Data for Name: payment; Type: TABLE DATA; Schema: public; Owner: gediminas
--

COPY public.payment (id, trans_id, exchangerate, paymentmethod_id) FROM stdin;
\.


--
-- Data for Name: paymentmethod; Type: TABLE DATA; Schema: public; Owner: gediminas
--

COPY public.paymentmethod (id, description, fee, rn, roundchange) FROM stdin;
\.


--
-- Data for Name: payrate; Type: TABLE DATA; Schema: public; Owner: gediminas
--

COPY public.payrate (trans_id, id, rate, above) FROM stdin;
\.


--
-- Data for Name: pricegroup; Type: TABLE DATA; Schema: public; Owner: gediminas
--

COPY public.pricegroup (id, pricegroup) FROM stdin;
\.


--
-- Data for Name: project; Type: TABLE DATA; Schema: public; Owner: gediminas
--

COPY public.project (id, projectnumber, description, startdate, enddate, parts_id, production, completed, customer_id) FROM stdin;
\.


--
-- Data for Name: recurring; Type: TABLE DATA; Schema: public; Owner: gediminas
--

COPY public.recurring (id, reference, startdate, nextdate, enddate, repeat, unit, howmany, payment, description) FROM stdin;
\.


--
-- Data for Name: recurringemail; Type: TABLE DATA; Schema: public; Owner: gediminas
--

COPY public.recurringemail (id, formname, format, message) FROM stdin;
\.


--
-- Data for Name: recurringprint; Type: TABLE DATA; Schema: public; Owner: gediminas
--

COPY public.recurringprint (id, formname, format, printer) FROM stdin;
\.


--
-- Data for Name: reference; Type: TABLE DATA; Schema: public; Owner: gediminas
--

COPY public.reference (id, code, trans_id, description, archive_id, login, formname, folder) FROM stdin;
\.


--
-- Data for Name: report; Type: TABLE DATA; Schema: public; Owner: gediminas
--

COPY public.report (reportid, reportcode, reportdescription, login) FROM stdin;
\.


--
-- Data for Name: reportvars; Type: TABLE DATA; Schema: public; Owner: gediminas
--

COPY public.reportvars (reportid, reportvariable, reportvalue) FROM stdin;
\.


--
-- Data for Name: semaphore; Type: TABLE DATA; Schema: public; Owner: gediminas
--

COPY public.semaphore (id, login, module, expires) FROM stdin;
\.


--
-- Data for Name: shipto; Type: TABLE DATA; Schema: public; Owner: gediminas
--

COPY public.shipto (trans_id, shiptoname, shiptoaddress1, shiptoaddress2, shiptocity, shiptostate, shiptozipcode, shiptocountry, shiptocontact, shiptophone, shiptofax, shiptoemail, shiptorecurring) FROM stdin;
\.


--
-- Data for Name: sic; Type: TABLE DATA; Schema: public; Owner: gediminas
--

COPY public.sic (code, sictype, description) FROM stdin;
\.


--
-- Data for Name: status; Type: TABLE DATA; Schema: public; Owner: gediminas
--

COPY public.status (trans_id, formname, printed, emailed, spoolfile) FROM stdin;
\.


--
-- Data for Name: tax; Type: TABLE DATA; Schema: public; Owner: gediminas
--

COPY public.tax (chart_id, rate, taxnumber, validto) FROM stdin;
10023	0.1	\N	\N
10024	0.14	\N	\N
10025	0.3	\N	\N
\.


--
-- Data for Name: translation; Type: TABLE DATA; Schema: public; Owner: gediminas
--

COPY public.translation (trans_id, language_code, description) FROM stdin;
\.


--
-- Data for Name: vendor; Type: TABLE DATA; Schema: public; Owner: gediminas
--

COPY public.vendor (id, name, contact, phone, fax, email, notes, terms, taxincluded, vendornumber, cc, bcc, gifi_accno, business_id, taxnumber, sic_code, discount, creditlimit, employee_id, language_code, pricegroup_id, curr, startdate, enddate, arap_accno_id, payment_accno_id, discount_accno_id, cashdiscount, discountterms, threshold, paymentmethod_id, remittancevoucher, prepayment_accno_id) FROM stdin;
\.


--
-- Data for Name: vendortax; Type: TABLE DATA; Schema: public; Owner: gediminas
--

COPY public.vendortax (vendor_id, chart_id) FROM stdin;
\.


--
-- Data for Name: vr; Type: TABLE DATA; Schema: public; Owner: gediminas
--

COPY public.vr (br_id, trans_id, id, vouchernumber) FROM stdin;
\.


--
-- Data for Name: wage; Type: TABLE DATA; Schema: public; Owner: gediminas
--

COPY public.wage (id, description, amount, defer, exempt, chart_id) FROM stdin;
\.


--
-- Data for Name: warehouse; Type: TABLE DATA; Schema: public; Owner: gediminas
--

COPY public.warehouse (id, description, rn) FROM stdin;
\.


--
-- Data for Name: yearend; Type: TABLE DATA; Schema: public; Owner: gediminas
--

COPY public.yearend (trans_id, transdate) FROM stdin;
\.


--
-- Name: addressid; Type: SEQUENCE SET; Schema: public; Owner: gediminas
--

SELECT pg_catalog.setval('public.addressid', 1, true);


--
-- Name: archiveid; Type: SEQUENCE SET; Schema: public; Owner: gediminas
--

SELECT pg_catalog.setval('public.archiveid', 1, true);


--
-- Name: assemblyid; Type: SEQUENCE SET; Schema: public; Owner: gediminas
--

SELECT pg_catalog.setval('public.assemblyid', 1, true);


--
-- Name: contactid; Type: SEQUENCE SET; Schema: public; Owner: gediminas
--

SELECT pg_catalog.setval('public.contactid', 1, true);


--
-- Name: id; Type: SEQUENCE SET; Schema: public; Owner: gediminas
--

SELECT pg_catalog.setval('public.id', 10068, true);


--
-- Name: inventoryid; Type: SEQUENCE SET; Schema: public; Owner: gediminas
--

SELECT pg_catalog.setval('public.inventoryid', 1, true);


--
-- Name: invoiceid; Type: SEQUENCE SET; Schema: public; Owner: gediminas
--

SELECT pg_catalog.setval('public.invoiceid', 1, true);


--
-- Name: jcitemsid; Type: SEQUENCE SET; Schema: public; Owner: gediminas
--

SELECT pg_catalog.setval('public.jcitemsid', 1, true);


--
-- Name: orderitemsid; Type: SEQUENCE SET; Schema: public; Owner: gediminas
--

SELECT pg_catalog.setval('public.orderitemsid', 1, true);


--
-- Name: referenceid; Type: SEQUENCE SET; Schema: public; Owner: gediminas
--

SELECT pg_catalog.setval('public.referenceid', 1, true);


--
-- Name: acsrole acsrole_pkey; Type: CONSTRAINT; Schema: public; Owner: gediminas
--

ALTER TABLE ONLY public.acsrole
    ADD CONSTRAINT acsrole_pkey PRIMARY KEY (id);


--
-- Name: address address_pkey; Type: CONSTRAINT; Schema: public; Owner: gediminas
--

ALTER TABLE ONLY public.address
    ADD CONSTRAINT address_pkey PRIMARY KEY (id);


--
-- Name: archive archive_pkey; Type: CONSTRAINT; Schema: public; Owner: gediminas
--

ALTER TABLE ONLY public.archive
    ADD CONSTRAINT archive_pkey PRIMARY KEY (id);


--
-- Name: br br_pkey; Type: CONSTRAINT; Schema: public; Owner: gediminas
--

ALTER TABLE ONLY public.br
    ADD CONSTRAINT br_pkey PRIMARY KEY (id);


--
-- Name: contact contact_pkey; Type: CONSTRAINT; Schema: public; Owner: gediminas
--

ALTER TABLE ONLY public.contact
    ADD CONSTRAINT contact_pkey PRIMARY KEY (id);


--
-- Name: curr curr_pkey; Type: CONSTRAINT; Schema: public; Owner: gediminas
--

ALTER TABLE ONLY public.curr
    ADD CONSTRAINT curr_pkey PRIMARY KEY (curr);


--
-- Name: customer customer_pkey; Type: CONSTRAINT; Schema: public; Owner: gediminas
--

ALTER TABLE ONLY public.customer
    ADD CONSTRAINT customer_pkey PRIMARY KEY (id);


--
-- Name: deduction deduction_pkey; Type: CONSTRAINT; Schema: public; Owner: gediminas
--

ALTER TABLE ONLY public.deduction
    ADD CONSTRAINT deduction_pkey PRIMARY KEY (id);


--
-- Name: employee employee_pkey; Type: CONSTRAINT; Schema: public; Owner: gediminas
--

ALTER TABLE ONLY public.employee
    ADD CONSTRAINT employee_pkey PRIMARY KEY (id);


--
-- Name: invoice invoice_pkey; Type: CONSTRAINT; Schema: public; Owner: gediminas
--

ALTER TABLE ONLY public.invoice
    ADD CONSTRAINT invoice_pkey PRIMARY KEY (id);


--
-- Name: mimetype mimetype_pkey; Type: CONSTRAINT; Schema: public; Owner: gediminas
--

ALTER TABLE ONLY public.mimetype
    ADD CONSTRAINT mimetype_pkey PRIMARY KEY (extension);


--
-- Name: paymentmethod paymentmethod_pkey; Type: CONSTRAINT; Schema: public; Owner: gediminas
--

ALTER TABLE ONLY public.paymentmethod
    ADD CONSTRAINT paymentmethod_pkey PRIMARY KEY (id);


--
-- Name: reference reference_pkey; Type: CONSTRAINT; Schema: public; Owner: gediminas
--

ALTER TABLE ONLY public.reference
    ADD CONSTRAINT reference_pkey PRIMARY KEY (id);


--
-- Name: report report_pkey; Type: CONSTRAINT; Schema: public; Owner: gediminas
--

ALTER TABLE ONLY public.report
    ADD CONSTRAINT report_pkey PRIMARY KEY (reportid);


--
-- Name: vendor vendor_pkey; Type: CONSTRAINT; Schema: public; Owner: gediminas
--

ALTER TABLE ONLY public.vendor
    ADD CONSTRAINT vendor_pkey PRIMARY KEY (id);


--
-- Name: wage wage_pkey; Type: CONSTRAINT; Schema: public; Owner: gediminas
--

ALTER TABLE ONLY public.wage
    ADD CONSTRAINT wage_pkey PRIMARY KEY (id);


--
-- Name: acc_trans_chart_id_key; Type: INDEX; Schema: public; Owner: gediminas
--

CREATE INDEX acc_trans_chart_id_key ON public.acc_trans USING btree (chart_id);


--
-- Name: acc_trans_source_key; Type: INDEX; Schema: public; Owner: gediminas
--

CREATE INDEX acc_trans_source_key ON public.acc_trans USING btree (lower(source));


--
-- Name: acc_trans_trans_id_key; Type: INDEX; Schema: public; Owner: gediminas
--

CREATE INDEX acc_trans_trans_id_key ON public.acc_trans USING btree (trans_id);


--
-- Name: acc_trans_transdate_key; Type: INDEX; Schema: public; Owner: gediminas
--

CREATE INDEX acc_trans_transdate_key ON public.acc_trans USING btree (transdate);


--
-- Name: ap_employee_id_key; Type: INDEX; Schema: public; Owner: gediminas
--

CREATE INDEX ap_employee_id_key ON public.ap USING btree (employee_id);


--
-- Name: ap_id_key; Type: INDEX; Schema: public; Owner: gediminas
--

CREATE INDEX ap_id_key ON public.ap USING btree (id);


--
-- Name: ap_invnumber_key; Type: INDEX; Schema: public; Owner: gediminas
--

CREATE INDEX ap_invnumber_key ON public.ap USING btree (invnumber);


--
-- Name: ap_ordnumber_key; Type: INDEX; Schema: public; Owner: gediminas
--

CREATE INDEX ap_ordnumber_key ON public.ap USING btree (ordnumber);


--
-- Name: ap_quonumber_key; Type: INDEX; Schema: public; Owner: gediminas
--

CREATE INDEX ap_quonumber_key ON public.ap USING btree (quonumber);


--
-- Name: ap_transdate_key; Type: INDEX; Schema: public; Owner: gediminas
--

CREATE INDEX ap_transdate_key ON public.ap USING btree (transdate);


--
-- Name: ap_vendor_id_key; Type: INDEX; Schema: public; Owner: gediminas
--

CREATE INDEX ap_vendor_id_key ON public.ap USING btree (vendor_id);


--
-- Name: ar_customer_id_key; Type: INDEX; Schema: public; Owner: gediminas
--

CREATE INDEX ar_customer_id_key ON public.ar USING btree (customer_id);


--
-- Name: ar_employee_id_key; Type: INDEX; Schema: public; Owner: gediminas
--

CREATE INDEX ar_employee_id_key ON public.ar USING btree (employee_id);


--
-- Name: ar_id_key; Type: INDEX; Schema: public; Owner: gediminas
--

CREATE INDEX ar_id_key ON public.ar USING btree (id);


--
-- Name: ar_invnumber_key; Type: INDEX; Schema: public; Owner: gediminas
--

CREATE INDEX ar_invnumber_key ON public.ar USING btree (invnumber);


--
-- Name: ar_ordnumber_key; Type: INDEX; Schema: public; Owner: gediminas
--

CREATE INDEX ar_ordnumber_key ON public.ar USING btree (ordnumber);


--
-- Name: ar_quonumber_key; Type: INDEX; Schema: public; Owner: gediminas
--

CREATE INDEX ar_quonumber_key ON public.ar USING btree (quonumber);


--
-- Name: ar_transdate_key; Type: INDEX; Schema: public; Owner: gediminas
--

CREATE INDEX ar_transdate_key ON public.ar USING btree (transdate);


--
-- Name: assembly_id_key; Type: INDEX; Schema: public; Owner: gediminas
--

CREATE INDEX assembly_id_key ON public.assembly USING btree (id);


--
-- Name: audittrail_trans_id_key; Type: INDEX; Schema: public; Owner: gediminas
--

CREATE INDEX audittrail_trans_id_key ON public.audittrail USING btree (trans_id);


--
-- Name: cargo_id_key; Type: INDEX; Schema: public; Owner: gediminas
--

CREATE INDEX cargo_id_key ON public.cargo USING btree (id, trans_id);


--
-- Name: chart_accno_key; Type: INDEX; Schema: public; Owner: gediminas
--

CREATE UNIQUE INDEX chart_accno_key ON public.chart USING btree (accno);


--
-- Name: chart_category_key; Type: INDEX; Schema: public; Owner: gediminas
--

CREATE INDEX chart_category_key ON public.chart USING btree (category);


--
-- Name: chart_gifi_accno_key; Type: INDEX; Schema: public; Owner: gediminas
--

CREATE INDEX chart_gifi_accno_key ON public.chart USING btree (gifi_accno);


--
-- Name: chart_id_key; Type: INDEX; Schema: public; Owner: gediminas
--

CREATE INDEX chart_id_key ON public.chart USING btree (id);


--
-- Name: chart_link_key; Type: INDEX; Schema: public; Owner: gediminas
--

CREATE INDEX chart_link_key ON public.chart USING btree (link);


--
-- Name: customer_contact_key; Type: INDEX; Schema: public; Owner: gediminas
--

CREATE INDEX customer_contact_key ON public.customer USING btree (lower((contact)::text));


--
-- Name: customer_customer_id_key; Type: INDEX; Schema: public; Owner: gediminas
--

CREATE INDEX customer_customer_id_key ON public.customertax USING btree (customer_id);


--
-- Name: customer_customernumber_key; Type: INDEX; Schema: public; Owner: gediminas
--

CREATE INDEX customer_customernumber_key ON public.customer USING btree (customernumber);


--
-- Name: customer_name_key; Type: INDEX; Schema: public; Owner: gediminas
--

CREATE INDEX customer_name_key ON public.customer USING btree (lower((name)::text));


--
-- Name: department_id_key; Type: INDEX; Schema: public; Owner: gediminas
--

CREATE INDEX department_id_key ON public.department USING btree (id);


--
-- Name: employee_login_key; Type: INDEX; Schema: public; Owner: gediminas
--

CREATE UNIQUE INDEX employee_login_key ON public.employee USING btree (login);


--
-- Name: employee_name_key; Type: INDEX; Schema: public; Owner: gediminas
--

CREATE INDEX employee_name_key ON public.employee USING btree (lower((name)::text));


--
-- Name: exchangerate_ct_key; Type: INDEX; Schema: public; Owner: gediminas
--

CREATE INDEX exchangerate_ct_key ON public.exchangerate USING btree (curr, transdate);


--
-- Name: gifi_accno_key; Type: INDEX; Schema: public; Owner: gediminas
--

CREATE UNIQUE INDEX gifi_accno_key ON public.gifi USING btree (accno);


--
-- Name: gl_description_key; Type: INDEX; Schema: public; Owner: gediminas
--

CREATE INDEX gl_description_key ON public.gl USING btree (lower(description));


--
-- Name: gl_employee_id_key; Type: INDEX; Schema: public; Owner: gediminas
--

CREATE INDEX gl_employee_id_key ON public.gl USING btree (employee_id);


--
-- Name: gl_id_key; Type: INDEX; Schema: public; Owner: gediminas
--

CREATE INDEX gl_id_key ON public.gl USING btree (id);


--
-- Name: gl_reference_key; Type: INDEX; Schema: public; Owner: gediminas
--

CREATE INDEX gl_reference_key ON public.gl USING btree (reference);


--
-- Name: gl_transdate_key; Type: INDEX; Schema: public; Owner: gediminas
--

CREATE INDEX gl_transdate_key ON public.gl USING btree (transdate);


--
-- Name: inventory_parts_id_key; Type: INDEX; Schema: public; Owner: gediminas
--

CREATE INDEX inventory_parts_id_key ON public.inventory USING btree (parts_id);


--
-- Name: invoice_trans_id_key; Type: INDEX; Schema: public; Owner: gediminas
--

CREATE INDEX invoice_trans_id_key ON public.invoice USING btree (trans_id);


--
-- Name: jcitems_id_key; Type: INDEX; Schema: public; Owner: gediminas
--

CREATE INDEX jcitems_id_key ON public.jcitems USING btree (id);


--
-- Name: language_code_key; Type: INDEX; Schema: public; Owner: gediminas
--

CREATE UNIQUE INDEX language_code_key ON public.language USING btree (code);


--
-- Name: makemodel_make_key; Type: INDEX; Schema: public; Owner: gediminas
--

CREATE INDEX makemodel_make_key ON public.makemodel USING btree (lower(make));


--
-- Name: makemodel_model_key; Type: INDEX; Schema: public; Owner: gediminas
--

CREATE INDEX makemodel_model_key ON public.makemodel USING btree (lower(model));


--
-- Name: makemodel_parts_id_key; Type: INDEX; Schema: public; Owner: gediminas
--

CREATE INDEX makemodel_parts_id_key ON public.makemodel USING btree (parts_id);


--
-- Name: oe_employee_id_key; Type: INDEX; Schema: public; Owner: gediminas
--

CREATE INDEX oe_employee_id_key ON public.oe USING btree (employee_id);


--
-- Name: oe_id_key; Type: INDEX; Schema: public; Owner: gediminas
--

CREATE INDEX oe_id_key ON public.oe USING btree (id);


--
-- Name: oe_ordnumber_key; Type: INDEX; Schema: public; Owner: gediminas
--

CREATE INDEX oe_ordnumber_key ON public.oe USING btree (ordnumber);


--
-- Name: oe_transdate_key; Type: INDEX; Schema: public; Owner: gediminas
--

CREATE INDEX oe_transdate_key ON public.oe USING btree (transdate);


--
-- Name: orderitems_trans_id_key; Type: INDEX; Schema: public; Owner: gediminas
--

CREATE INDEX orderitems_trans_id_key ON public.orderitems USING btree (trans_id);


--
-- Name: parts_description_key; Type: INDEX; Schema: public; Owner: gediminas
--

CREATE INDEX parts_description_key ON public.parts USING btree (lower(description));


--
-- Name: parts_id_key; Type: INDEX; Schema: public; Owner: gediminas
--

CREATE INDEX parts_id_key ON public.parts USING btree (id);


--
-- Name: parts_partnumber_key; Type: INDEX; Schema: public; Owner: gediminas
--

CREATE INDEX parts_partnumber_key ON public.parts USING btree (lower(partnumber));


--
-- Name: partscustomer_customer_id_key; Type: INDEX; Schema: public; Owner: gediminas
--

CREATE INDEX partscustomer_customer_id_key ON public.partscustomer USING btree (customer_id);


--
-- Name: partscustomer_parts_id_key; Type: INDEX; Schema: public; Owner: gediminas
--

CREATE INDEX partscustomer_parts_id_key ON public.partscustomer USING btree (parts_id);


--
-- Name: partsgroup_id_key; Type: INDEX; Schema: public; Owner: gediminas
--

CREATE INDEX partsgroup_id_key ON public.partsgroup USING btree (id);


--
-- Name: partsgroup_key; Type: INDEX; Schema: public; Owner: gediminas
--

CREATE UNIQUE INDEX partsgroup_key ON public.partsgroup USING btree (partsgroup);


--
-- Name: partstax_parts_id_key; Type: INDEX; Schema: public; Owner: gediminas
--

CREATE INDEX partstax_parts_id_key ON public.partstax USING btree (parts_id);


--
-- Name: partsvendor_parts_id_key; Type: INDEX; Schema: public; Owner: gediminas
--

CREATE INDEX partsvendor_parts_id_key ON public.partsvendor USING btree (parts_id);


--
-- Name: partsvendor_vendor_id_key; Type: INDEX; Schema: public; Owner: gediminas
--

CREATE INDEX partsvendor_vendor_id_key ON public.partsvendor USING btree (vendor_id);


--
-- Name: pricegroup_id_key; Type: INDEX; Schema: public; Owner: gediminas
--

CREATE INDEX pricegroup_id_key ON public.pricegroup USING btree (id);


--
-- Name: pricegroup_pricegroup_key; Type: INDEX; Schema: public; Owner: gediminas
--

CREATE INDEX pricegroup_pricegroup_key ON public.pricegroup USING btree (pricegroup);


--
-- Name: project_id_key; Type: INDEX; Schema: public; Owner: gediminas
--

CREATE INDEX project_id_key ON public.project USING btree (id);


--
-- Name: projectnumber_key; Type: INDEX; Schema: public; Owner: gediminas
--

CREATE UNIQUE INDEX projectnumber_key ON public.project USING btree (projectnumber);


--
-- Name: shipto_trans_id_key; Type: INDEX; Schema: public; Owner: gediminas
--

CREATE INDEX shipto_trans_id_key ON public.shipto USING btree (trans_id);


--
-- Name: status_trans_id_key; Type: INDEX; Schema: public; Owner: gediminas
--

CREATE INDEX status_trans_id_key ON public.status USING btree (trans_id);


--
-- Name: translation_trans_id_key; Type: INDEX; Schema: public; Owner: gediminas
--

CREATE INDEX translation_trans_id_key ON public.translation USING btree (trans_id);


--
-- Name: vendor_contact_key; Type: INDEX; Schema: public; Owner: gediminas
--

CREATE INDEX vendor_contact_key ON public.vendor USING btree (lower((contact)::text));


--
-- Name: vendor_name_key; Type: INDEX; Schema: public; Owner: gediminas
--

CREATE INDEX vendor_name_key ON public.vendor USING btree (lower((name)::text));


--
-- Name: vendor_vendornumber_key; Type: INDEX; Schema: public; Owner: gediminas
--

CREATE INDEX vendor_vendornumber_key ON public.vendor USING btree (vendornumber);


--
-- Name: vendortax_vendor_id_key; Type: INDEX; Schema: public; Owner: gediminas
--

CREATE INDEX vendortax_vendor_id_key ON public.vendortax USING btree (vendor_id);


--
-- Name: archivedata archivedata_archive_id_fkey; Type: FK CONSTRAINT; Schema: public; Owner: gediminas
--

ALTER TABLE ONLY public.archivedata
    ADD CONSTRAINT archivedata_archive_id_fkey FOREIGN KEY (archive_id) REFERENCES public.archive(id) ON DELETE CASCADE;


--
-- Name: vr vr_br_id_fkey; Type: FK CONSTRAINT; Schema: public; Owner: gediminas
--

ALTER TABLE ONLY public.vr
    ADD CONSTRAINT vr_br_id_fkey FOREIGN KEY (br_id) REFERENCES public.br(id) ON DELETE CASCADE;


--
-- PostgreSQL database dump complete
--

