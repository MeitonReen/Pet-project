use SeaCargoTransportation
go
CREATE LOGIN Eduard
WITH
        PASSWORD=N'Eduard2344',
        DEFAULT_DATABASE=SeaCargoTransportation,
        CHECK_EXPIRATION=OFF,
        CHECK_POLICY=OFF
GO

CREATE USER Eduard FOR LOGIN Eduard WITH DEFAULT_SCHEMA=[dbo]
GO
ALTER ROLE db_datawriter add member Eduard
GO
ALTER ROLE db_datareader add member Eduard
GO


CREATE LOGIN Gevorg
WITH
        PASSWORD=N'Gevorg2344',
        DEFAULT_DATABASE=SeaCargoTransportation,
        CHECK_EXPIRATION=OFF,
        CHECK_POLICY=OFF
GO


CREATE USER Gevorg FOR LOGIN Gevorg WITH DEFAULT_SCHEMA=[dbo]
GO
ALTER ROLE db_datawriter add member Gevorg
GO
ALTER ROLE db_datareader add member Gevorg
GO

CREATE LOGIN Daniil
WITH
        PASSWORD=N'Daniil2344',
        DEFAULT_DATABASE=SeaCargoTransportation,
        CHECK_EXPIRATION=OFF,
        CHECK_POLICY=OFF
GO


CREATE USER Daniil FOR LOGIN Daniil WITH DEFAULT_SCHEMA=[dbo]
GO
ALTER ROLE db_datawriter add member Daniil
GO
ALTER ROLE db_datareader add member Daniil
GO