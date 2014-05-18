//using MemoKu.POS.Encryption;
//namespace MemoKu.POS.Database
//{
//    /// <summary>
//    /// This class just for temporary, will be replace by database schema versioning consept
//    /// </summary>
//    public static class SQLiteDbBootstrap
//    {
//        public static void Initialize()
//        {
//            createTableDiscountPolicyIfNotExists();
//            createTableProductIfNecessary();
//            createTableUserIfNecessary();
//            createTablePartGroupIfNecessary();
//            createTableCurrencyIfNecessary();
//            createTableUnitIfNecessary();
//            createTableChargeIfNecessary();
//            createTableCardIfNecessary();
//            createTableCompanyProfileIfNecessary();
//            createTableTaxIfNecessary();
//            createTableExchangeRateIfNecessary();
//            createTableExchangeRateItemIfNecessary();
//            createTableTransactionNumberIfNecessary();
//            createTableDiscountPolicyQty();
//            createTableExchangeRateDetail();
//            createTableMemberIfNecessary();
//            createTableEventMessageIfNecessary();
//            createTableReferenceTime();
//            createTableShoppingCardIfNecessary();
//            createTableSessionIfNecessary();
//            dropUnusedTableIfAny();
//        }

//        private static void createTableDiscountPolicyIfNotExists()
//        {
//            var createTableSQL = @"CREATE TABLE IF NOT EXISTS discountpolicy ( 
//                         modelguid VARCHAR,
//                         startdate DATE,
//                         enddate DATE
//                         tenanid INTEGER,
//                         productid INTEGER,
//                         productguid VARCHAR,
//                         nama VARCHAR,
//                         qty INTEGER,
//                         discount REAL,
//                         discountunitamount REAL,
//                         discountpercentamount REAL,
//                         discounttype INTEGER)";
//            SQLiteDb.Do(createTableSQL).Execute();

//            var schema = SQLiteDb.GetSchema("discountpolicy");
//            if (schema.IsColumnNotExists("namadiskon"))
//                SQLiteDb.Do("ALTER TABLE discountpolicy ADD COLUMN namadiskon VARCHAR DEFAULT 'NONE'").Execute();
//            if (schema.IsColumnNotExists("productguid"))
//                SQLiteDb.Do("ALTER TABLE discountpolicy ADD COLUMN productguid VARCHAR").Execute();
//            if (schema.IsColumnNotExists("modelguid"))
//                SQLiteDb.Do("ALTER TABLE discountpolicy ADD COLUMN modelguid VARCHAR").Execute();
//            if (schema.IsColumnNotExists("tenanid"))
//                SQLiteDb.Do("ALTER TABLE discountpolicy ADD COLUMN tenanid INTEGER").Execute();

//            SQLiteDb.Do("CREATE INDEX IF NOT EXISTS discountpolicy_productguid_idx on discountpolicy(productguid)").Execute();
//            SQLiteDb.Do("CREATE INDEX IF NOT EXISTS discountpolicy_modelguid_idx on discountpolicy(modelguid)").Execute();
//            SQLiteDb.Do("CREATE INDEX IF NOT EXISTS discountplicy_tenanid_idx on discountpolicy(tenanid)").Execute();
//        }
//        private static void createTableSessionCookie()
//        {
//            SQLiteDb.Do("CREATE TABLE IF NOT EXISTS sessioncookie(cookie VARCHAR)").Execute();
//        }

//        private static void createTableDiscountPolicyQty()
//        {
//            SQLiteDb.Do(@"CREATE TABLE IF NOT EXISTS discountpolicy(
//                         modelguid VARCHAR,
//                         startdate DATE,
//                         enddate DATE,
//                         tenanid INTEGER,
//                         productid INTEGER,
//                         productguid VARCHAR,
//                         nama VARCHAR,
//                         qty INTEGER,
//                         discountunitamount REAL,
//                         discountpercentamount REAL,
//                         discounttype INTEGER,
//                         namadiskon VARCHAR);").Execute();
//        }

//        private static void createTableExchangeRateDetail()
//        {
//            SQLiteDb.Do(@"CREATE TABLE IF NOT EXISTS exchangeratedetail(
//                         date DATE,
//                         ccycode VARCHAR,
//                         rate REAL);").Execute();
//            var schema = SQLiteDb.GetSchema("exchangeratedetail");
//            if (schema.IsColumnNotExists("tenanid"))
//                SQLiteDb.Do("ALTER TABLE exchangeratedetail ADD COLUMN tenanid INTEGER;").Execute();
//            SQLiteDb.Do("CREATE INDEX IF NOT EXISTS exchangeratedetail_date_idx on exchangeratedetail(date)").Execute();
//            SQLiteDb.Do("CREATE INDEX IF NOT EXISTS exchangeratedetail_ccycode_idx on exchangeratedetail(ccycode)").Execute();
//        }

//        private static void createTableTransactionNumberIfNecessary()
//        {
//            SQLiteDb.Do(@"CREATE TABLE IF NOT EXISTS autonumber (
//                        id INTEGER PRIMARY KEY  AUTOINCREMENT  NOT NULL  UNIQUE  DEFAULT 0, 
//                        number INTEGER NOT NULL);").Execute();
//            var schema = SQLiteDb.GetSchema("autonumber");
//            if (schema.IsColumnNotExists("date"))
//                SQLiteDb.Do("ALTER TABLE autonumber ADD COLUMN date VARCHAR NOT NULL DEFAULT ''").Execute();
//            SQLiteDb.Do("CREATE INDEX IF NOT EXISTS autonumber_date_idx on autonumber(date)").Execute();
//        }

//        private static void createTableExchangeRateItemIfNecessary()
//        {
//            SQLiteDb.Do(@"CREATE TABLE IF NOT EXISTS exchangerateitemtenant (
//                        ccycode VARCHAR,
//                        rate REAL,
//                        tenanid INTEGER);").Execute();
//        }

//        private static void createTableExchangeRateIfNecessary()
//        {
//            SQLiteDb.Do(@"CREATE TABLE IF NOT EXISTS exchangerate (
//                        tenanid INTEGER,
//                        startdate DATE,
//                        enddate DATE);").Execute();
//        }

//        private static void createTableCompanyProfileIfNecessary()
//        {
//            SQLiteDb.Do(@"CREATE TABLE IF NOT EXISTS companyprofile (
//                        tenanid INTEGER,
//                        name VARCHAR,
//                        alamat VARCHAR,
//                        npwp VARCHAR,
//                        nppkp VARCHAR);").Execute();
//            var schema = SQLiteDb.GetSchema("companyprofile");
//            if (schema.IsColumnNotExists("brand"))
//                SQLiteDb.Do("ALTER TABLE companyprofile ADD COLUMN brand VARCHAR").Execute();
//            if (schema.IsColumnNotExists("location"))
//                SQLiteDb.Do("ALTER TABLE companyprofile ADD COLUMN location VARCHAR").Execute();
//            if (schema.IsColumnNotExists("terminal"))
//                SQLiteDb.Do("ALTER TABLE companyprofile ADD COLUMN terminal VARCHAR").Execute();
//            if (schema.IsColumnNotExists("subterminal"))
//                SQLiteDb.Do("ALTER TABLE companyprofile ADD COLUMN subterminal VARCHAR").Execute();
//            if (schema.IsColumnNotExists("phone"))
//                SQLiteDb.Do("ALTER TABLE companyprofile ADD COLUMN phone VARCHAR").Execute();
//        }

//        private static void createTableTaxIfNecessary()
//        {
//            SQLiteDb.Do(@"CREATE TABLE IF NOT EXISTS tax(
//                        guid VARCHAR,
//                        tenantid INTEGER,
//                        hastax INTEGER,
//                        nama VARCHAR,
//                        nominal REAL);").Execute();
//        }

//        private static void createTableChargeIfNecessary()
//        {
//            SQLiteDb.Do(@"CREATE TABLE IF NOT EXISTS charge (
//                        hascharge INTEGER,
//                        chargetype INTEGER,
//                        rate REAL);").Execute();
//        }

//        private static void createTableCardIfNecessary()
//        {
//            SQLiteDb.Do(@"CREATE TABLE IF NOT EXISTS card (
//                        cardid INTEGER,
//                        tenantid INTEGER,
//                        kode VARCHAR,
//                        nama VARCHAR,
//                        modelguid VARCHAR,
//                        biaya DOUBLE,
//                        diskon DOUBLE);").Execute();
//            SQLiteDb.Do("CREATE INDEX IF NOT EXISTS card_modelguid_idx on card(modelguid)").Execute();
//            SQLiteDb.Do("CREATE INDEX IF NOT EXISTS card_tenantid_idx on card(tenantid)").Execute();
//        }

//        private static void createTableUnitIfNecessary()
//        {
//            SQLiteDb.Do(@"CREATE TABLE IF NOT EXISTS unit (
//                        unitid INTEGER,
//                        tenantid INTEGER,
//                        modelguid VARCHAR,
//                        kode VARCHAR,
//                        nama VARCHER);").Execute();
//            SQLiteDb.Do("CREATE INDEX IF NOT EXISTS unit_modelguid_idx on unit(modelguid)").Execute();
//        }

//        private static void createTableCurrencyIfNecessary()
//        {
//            SQLiteDb.Do(@"CREATE TABLE IF NOT EXISTS currency (
//                        kode VARCHAR,
//                        nama VARCHAR,
//                        rounding INTEGER,
//                        isdefault INTEGER,
//                        modelguid VARCHAR);").Execute();
//            SQLiteDb.Do("CREATE INDEX IF NOT EXISTS currency_isdefault_idx on currency(isdefault)").Execute();
//            SQLiteDb.Do("CREATE INDEX IF NOT EXISTS currency_modelguid_idx on currency(modelguid)").Execute();
//        }

//        private static void createTableProductIfNecessary()
//        {
//            SQLiteDb.Do(@"CREATE TABLE IF NOT EXISTS product (
//                        productid INTEGER, 
//                        groupid INTEGER, 
//                        ccyid INTEGER,
//                        unitid INTEGER,
//                        barcode VARCHAR,
//                        hargabeli REAL,
//                        hargajual REAL,
//                        tenantid INTEGER,
//                        kode VARCHAR,
//                        nama VARCHAR,
//                        modelguid VARCHAR);").Execute();
//            var schema = SQLiteDb.GetSchema("product");
//            if (schema.IsColumnNotExists("alwaysnew"))
//                SQLiteDb.Do("ALTER TABLE product ADD COLUMN alwaysnew BOOL").Execute();
//            if (schema.IsColumnNotExists("ccycode"))
//                SQLiteDb.Do("ALTER TABLE product ADD COLUMN ccycode VARCHAR").Execute();
//            if (schema.IsColumnNotExists("groupcode"))
//                SQLiteDb.Do("ALTER TABLE product ADD COLUMN groupcode VARCHAR DEFAULT 'NONE'").Execute();
//            if (schema.IsColumnNotExists("unitcode"))
//                SQLiteDb.Do("ALTER TABLE product ADD COLUMN unitcode VARCHAR DEFAULT 'NONE'").Execute();
//            if (schema.IsColumnNotExists("groupguid"))
//                SQLiteDb.Do("ALTER TABLE product ADD COLUMN groupguid VARCHAR DEFAULT 'NONE'").Execute();
//            SQLiteDb.Do("CREATE INDEX IF NOT EXISTS product_barcode_idx on product(barcode)").Execute();
//            SQLiteDb.Do("CREATE INDEX IF NOT EXISTS product_productid_idx on product(productid)").Execute();
//            SQLiteDb.Do("CREATE INDEX IF NOT EXISTS product_modelguid_idx on product(modelguid)").Execute();
//            SQLiteDb.Do("CREATE INDEX IF NOT EXISTS product_groupid_idx on product(groupid)").Execute();
//            SQLiteDb.Do("CREATE INDEX IF NOT EXISTS product_nama_idx on product(nama)").Execute();
//            SQLiteDb.Do("CREATE INDEX IF NOT EXISTS product_kode_idx on product(kode)").Execute();
//            SQLiteDb.Do("CREATE INDEX IF NOT EXISTS product_groupguid_idx on product(groupguid)").Execute();
//        }

//        private static void createTableUserIfNecessary()
//        {
//            SQLiteDb.Do(@"CREATE TABLE IF NOT EXISTS user (
//                        username VARCHAR, 
//                        userpassword VARCHAR, 
//                        roles VARCHAR);").Execute();
//            var simpleAES = new SimpleAES();
//            var defaultEncrpytedRules = simpleAES.EncryptToString("");
//            var schema = SQLiteDb.GetSchema("user");
//            if (schema.IsColumnNotExists("rules"))
//                SQLiteDb.Do("ALTER TABLE user ADD COLUMN rules VARCHAR DEFAULT '" + defaultEncrpytedRules + "'").Execute();
//            SQLiteDb.Do("CREATE INDEX IF NOT EXISTS user_username_idx on user(username)").Execute();
//        }

//        private static void createTablePartGroupIfNecessary()
//        {
//            SQLiteDb.Do(@"CREATE TABLE IF NOT EXISTS partgroup (
//                        groupid INTEGER, 
//                        tenantid INTEGER, 
//                        modelguid VARCHAR,
//                        kode VARCHAR,
//                        nama VARCHAR);").Execute();
//            SQLiteDb.Do("CREATE INDEX IF NOT EXISTS partgroup_groupid_idx on partgroup(groupid)").Execute();
//            SQLiteDb.Do("CREATE INDEX IF NOT EXISTS partgroup_modelguid_idx on partgroup(modelguid)").Execute();
//        }
//        private static void createTableMemberIfNecessary()
//        {
//            SQLiteDb.Do(@"CREATE TABLE IF NOT EXISTS member(
//                    modelguid VARCHAR NOT NULL,
//                    idkartu VARCHAR NOT NULL,
//                    membername VARCHAR NOT NULL,
//                    membermail VARCHAR,
//                    memberaddress VARCHAR,
//                    memberphone VARCHAR,
//                    memberstart DATE,
//                    memberend DATE,
//                    status VARCHAR NOT NULL,
//                    discountpercent REAL)").Execute();
//            SQLiteDb.Do("CREATE INDEX IF NOT EXISTS member_idkartu_idx on member(idkartu)").Execute();
//        }
//        private static void createTableEventMessageIfNecessary()
//        {
//            SQLiteDb.Do(@"CREATE TABLE IF NOT EXISTS errorqueue (
//                        id INTEGER PRIMARY KEY  AUTOINCREMENT NOT NULL UNIQUE DEFAULT 0, 
//                        messagetype VARCHAR NOT NULL,
//                        payload VARCHAR NOT NULL,
//                        errormessage VARCHAR,
//                        queueid VARCHAR NOT NULL)").Execute();
//            var schema = SQLiteDb.GetSchema("errorqueue");
//            if (schema.IsColumnNotExists("date"))
//                SQLiteDb.Do("ALTER TABLE errorqueue ADD COLUMN date DATE").Execute();
//            if (schema.IsColumnNotExists("status"))
//                SQLiteDb.Do("ALTER TABLE errorqueue ADD COLUMN status INTEGER DEFAULT 0 NOT NULL").Execute();
//            SQLiteDb.Do("CREATE INDEX IF NOT EXISTS errorqueue_status_idx on errorqueue(status)").Execute();
//            SQLiteDb.Do("CREATE INDEX IF NOT EXISTS errorqueue_messagetype_idx on errorqueue(messagetype)").Execute();
//            SQLiteDb.Do("CREATE INDEX IF NOT EXISTS errorqueue_queueid_idx on errorqueue(queueid)").Execute();
//            SQLiteDb.Do("CREATE INDEX IF NOT EXISTS errorqueue_payload_idx on errorqueue(payload)").Execute();
//            SQLiteDb.Do("CREATE INDEX IF NOT EXISTS errorqueue_date_idx on errorqueue(date)").Execute();
//            SQLiteDb.Do("Update errorqueue set status = 0 where status is null").Execute();
//        }
//        private static void createTableReferenceTime()
//        {
//            SQLiteDb.Do("CREATE TABLE IF NOT EXISTS referencetime(time DATE);").Execute();
//        }
//        private static void createTableShoppingCardIfNecessary()
//        {
//            var createTabelSQL = @"CREATE TABLE IF NOT EXISTS shoppingcart (id INTEGER PRIMARY KEY  AUTOINCREMENT  NOT NULL  UNIQUE  DEFAULT 0, 
//                        shoppingcartid VARCHAR NOT NULL  UNIQUE, 
//                        transactionnumber VARCHAR NOT NULL UNIQUE,
//                        sessionid VARCHAR NOT NULL,
//                        payload VARCHAR NOT NULL,
//                        isvoided BOOL DEFAULT(0),
//                        statusshoppingcart INTEGER DEFAULT(0))";
//            SQLiteDb.Do(createTabelSQL).Execute();
//            var schema = SQLiteDb.GetSchema("shoppingcart");
//            if (schema.IsColumnNotExists("isvoided"))
//                SQLiteDb.Do("ALTER TABLE shoppingcart ADD COLUMN isvoided BOOL DEFAULT(0)").Execute();
//            SQLiteDb.Do("update shoppingcart set isvoided=0 where isvoided is null").Execute();
//            if (schema.IsColumnNotExists("statusshoppingcart"))
//                SQLiteDb.Do("ALTER TABLE shoppingcart ADD COLUMN statusshoppingcart INTEGER DEFAULT 0").Execute();
//            SQLiteDb.Do("CREATE INDEX IF NOT EXISTS shoppingcart_sessionid_idx on shoppingcart(sessionid)").Execute();
//            SQLiteDb.Do("CREATE INDEX IF NOT EXISTS shoppingcart_payload_idx on shoppingcart(payload)").Execute();
//            SQLiteDb.Do("CREATE INDEX IF NOT EXISTS shoppingcart_transnumber_idx on shoppingcart(transactionnumber)").Execute();
//        }
//        private static void createTableSessionIfNecessary()
//        {
//            var createTableSQL = @"CREATE TABLE IF NOT EXISTS session (id INTEGER PRIMARY KEY  AUTOINCREMENT  NOT NULL  UNIQUE  DEFAULT 0, 
//                        sessionid VARCHAR NOT NULL UNIQUE, 
//                        username VARCHAR NOT NULL,
//                        sessionstate VARCHAR NOT NULL,
//                        payload VARCHAR NOT NULL)";
//            SQLiteDb.Do(createTableSQL).Execute();
//            var schema = SQLiteDb.GetSchema("session");
//            if (schema.IsColumnNotExists("opensessiondate"))
//                SQLiteDb.Do("ALTER TABLE session ADD COLUMN opensessiondate DATE").Execute();
//            SQLiteDb.Do("CREATE INDEX IF NOT EXISTS session_sessionid_idx on session(sessionid)").Execute();
//            SQLiteDb.Do("CREATE INDEX IF NOT EXISTS session_username_idx on session(username)").Execute();
//            SQLiteDb.Do("CREATE INDEX IF NOT EXISTS session_sessionstate_idx on session(sessionstate)").Execute();
//            SQLiteDb.Do("CREATE INDEX IF NOT EXISTS session_payload_idx on session(payload)").Execute();
//            SQLiteDb.Do("CREATE INDEX IF NOT EXISTS session_opensessiondate_idx on session(opensessiondate)").Execute();
//        }
//        private static void dropUnusedTableIfAny()
//        {
//            SQLiteDb.Do("DROP TABLE IF EXISTS updatetask;").Execute();
//        }
//    }
//}