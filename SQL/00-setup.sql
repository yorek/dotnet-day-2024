ALTER DATABASE [DotNetDevDays2024]
SET CHANGE_TRACKING = ON
(CHANGE_RETENTION = 2 DAYS, AUTO_CLEANUP = ON)
go

DROP TABLE IF EXISTS dbo.SampleTable;
CREATE TABLE dbo.SampleTable
(
    Id int not null primary key identity,
    SomeValue nvarchar(50) not null,
    SomeOtherValue nvarchar(50) null
)
go

ALTER TABLE [dbo].[SampleTable]
ENABLE CHANGE_TRACKING;
GO

SELECT CONCAT_WS('.', object_schema_name(object_id), object_name(object_id)) AS table_name, * 
FROM sys.change_tracking_tables
GO


