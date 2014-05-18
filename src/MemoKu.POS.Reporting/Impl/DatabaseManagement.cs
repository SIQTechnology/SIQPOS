using MemoKu.POS.Database;

namespace MemoKu.POS.Reporting
{
    public class DatabaseManagement : IDatabaseManagement
    {
        public DatabaseManagement()
        {
            SQLCeDb.CreateDatabase();
        }

        public void CreateTablesIfNecessary()
        {
            createTableProduct();
            createTableSession();
            createTableUser();
            createTableCompanyProfile();
            createTableAutoNumber();
        }

        private void createTableAutoNumber()
        {
            if (SQLCeDb.IsTableExist("tblautonumber"))
                return;
            SQLCeDb.Do(@"CREATE TABLE tblautonumber(
                        organizationid NVARCHAR(64),
                        clientid NVARCHAR(8),
                        date DATETIME,
                        number bigint)").Execute();
        }

        private void createTableCompanyProfile()
        {
            if (SQLCeDb.IsTableExist("tblcompanyprofile"))
                return;
            SQLCeDb.Do(@"CREATE TABLE tblcompanyprofile(
                        organizationid NVARCHAR(64),
                        clientid NVARCHAR(8),
                        name NVARCHAR(128),
                        address NTEXT,
                        logo varbinary)").Execute();
        }

        private void createTableUser()
        {
            if (SQLCeDb.IsTableExist("tbluser"))
                return;
            SQLCeDb.Do(@"CREATE TABLE tbluser (
                        username NVARCHAR(32) PRIMARY KEY, 
                        password NVARCHAR(128), 
                        roles NVARCHAR,
                        rules NVARCHAR);").Execute();
            SQLCeDb.Do("CREATE UNIQUE INDEX user_username_idx on tbluser(username)").Execute();
        }

        private void createTableSession()
        {
            if (SQLCeDb.IsTableExist("tblsession"))
                return;
            var sqlStatement = @"CREATE TABLE tblsession(id uniqueidentifier PRIMARY KEY, 
                        username NVARCHAR(32) NOT NULL,
                        opendate datetime,
                        closedate datetime,
                        sessionstate INTEGER NOT NULL)";
            SQLCeDb.Do(sqlStatement).Execute();
            SQLCeDb.Do("CREATE UNIQUE INDEX session_id_idx on tblsession(id)").Execute();
            SQLCeDb.Do("CREATE INDEX session_username_idx on tblsession(username)").Execute();
            SQLCeDb.Do("CREATE INDEX session_sessionstate_idx on tblsession(sessionstate)").Execute();
            SQLCeDb.Do("CREATE INDEX session_opendate_idx on tblsession(opendate)").Execute();
        }

        private void createTableProduct()
        {
            if (SQLCeDb.IsTableExist("tblproduct"))
                return;
            SQLCeDb.Do(@"CREATE TABLE tblproduct (
                        id uniqueidentifier PRIMARY KEY,
                        name NVARCHAR(256),
                        barcode NVARCHAR(64),
                        price FLOAT,
                        groupid uniqueidentifier, 
                        ccyid uniqueidentifier,
                        unitid uniqueidentifier)").Execute();
            SQLCeDb.Do("CREATE UNIQUE INDEX product_id_idx on tblproduct(id)").Execute();
            SQLCeDb.Do("CREATE INDEX product_barcode_idx on tblproduct(barcode)").Execute();
            SQLCeDb.Do("CREATE INDEX product_groupid_idx on tblproduct(groupid)").Execute();
            SQLCeDb.Do("CREATE INDEX product_name_idx on tblproduct(name)").Execute();
        }
    }
}
