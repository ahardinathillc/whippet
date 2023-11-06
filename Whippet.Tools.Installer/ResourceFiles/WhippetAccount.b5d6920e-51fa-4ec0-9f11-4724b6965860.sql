USE [master]
GO

IF (SELECT COUNT(*) FROM [master].[sys].[server_principals] WHERE name = N'whippet_sa') = 0
BEGIN
    CREATE LOGIN [whippet_sa] WITH PASSWORD=N'HJbv34#$J', DEFAULT_DATABASE=[master], DEFAULT_LANGUAGE=[us_english], CHECK_EXPIRATION=OFF, CHECK_POLICY=ON
    ALTER LOGIN [whippet_sa] ENABLE
    ALTER SERVER ROLE [sysadmin] ADD MEMBER [whippet_sa]
    ALTER SERVER ROLE [serveradmin] ADD MEMBER [whippet_sa]
    ALTER SERVER ROLE [dbcreator] ADD MEMBER [whippet_sa]
END
GO