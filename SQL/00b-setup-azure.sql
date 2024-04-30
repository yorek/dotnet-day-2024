CREATE USER [dm-devday2024] FROM EXTERNAL PROVIDER
GO

ALTER ROLE db_datareader ADD MEMBER [dm-devday2024]
ALTER ROLE db_datawriter ADD MEMBER [dm-devday2024]
ALTER ROLE db_ddladmin ADD MEMBER [dm-devday2024]
GRANT VIEW CHANGE TRACKING ON dbo.SampleTable TO [dm-devday2024]
GO