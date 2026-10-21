-- Action log for sign-in, edits, and deletions. Existing saves still work if this insert fails.

IF NOT EXISTS (SELECT 1 FROM sys.tables WHERE name = 'AUDIT_LOG')
BEGIN
    CREATE TABLE AUDIT_LOG (
        SEQ_NO int IDENTITY(1,1) NOT NULL CONSTRAINT PK_AUDIT_LOG PRIMARY KEY,
        ACTED_AT datetime NOT NULL CONSTRAINT DF_AUDIT_LOG_ACTED_AT DEFAULT GETDATE(),
        USER_ID varchar(50) NULL,
        USER_NAME varchar(100) NULL,
        ACTION varchar(20) NOT NULL,
        FORM_NAME varchar(80) NULL,
        DETAIL nvarchar(400) NULL
    );
END
