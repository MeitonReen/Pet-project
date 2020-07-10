use SeaCargoTransportation
go

CREATE TABLE AttributesForCargos
( 
	IDAttributesForCargos int identity  NOT NULL ,
	Name                 nvarchar(250)  NULL 
)
go



ALTER TABLE AttributesForCargos
	ADD CONSTRAINT PKAttributesForCargos PRIMARY KEY  CLUSTERED (IDAttributesForCargos ASC)
go



CREATE TABLE CargosAttributes
( 
	IDAttributesForCargos int  NOT NULL ,
	IDCargosInOrders     int  NOT NULL 
)
go



ALTER TABLE CargosAttributes
	ADD CONSTRAINT PKCargosAttributes PRIMARY KEY  CLUSTERED (IDAttributesForCargos ASC,IDCargosInOrders ASC)
go



CREATE TABLE CargosCharacteristics
( 
	IDCargosCharacteristics int identity  NOT NULL ,
	Weight               decimal(19,5)  NULL ,
	Length               decimal(19,5)  NULL ,
	Wigth                decimal(19,5)  NULL ,
	Height               decimal(19,5)  NULL ,
	Amount              decimal(19,5)  NULL ,
	IDCargosInOrders     int  NULL 
)
go



ALTER TABLE CargosCharacteristics
	ADD CONSTRAINT PKCargosCharacteristic PRIMARY KEY  CLUSTERED (IDCargosCharacteristics ASC)
go



CREATE TABLE CargosInOrders
( 
	IDCargosInOrders     int identity  NOT NULL ,
	IDOrder              int  NULL ,
	IDClient             int  NULL ,
	IDContainers         int  NULL 
)
go



ALTER TABLE CargosInOrders
	ADD CONSTRAINT PKCargosInOrders PRIMARY KEY  CLUSTERED (IDCargosInOrders ASC)
go




CREATE TABLE Clients
( 
	IDClient             int identity NOT NULL ,
	FirstName            nvarchar(250)  NULL ,
	LastName             nvarchar(250)  NULL ,
	Patronymic           nvarchar(250)  NULL ,
	EMail				 nvarchar(250)  NULL 
)
go



ALTER TABLE Clients
	ADD CONSTRAINT PKClients PRIMARY KEY  CLUSTERED (IDClient ASC)
go



CREATE TABLE Containers
( 
	IDContainers         int identity  NOT NULL ,
	Name                 nvarchar(250)  NULL 
)
go



ALTER TABLE Containers
	ADD CONSTRAINT PKContainers PRIMARY KEY  CLUSTERED (IDContainers ASC)
go



CREATE TABLE ContainersCharacteristics
( 
	IDContainersCharacteristics int identity NOT NULL ,
	Weight               decimal(19,5)  NULL ,
	LenghtOut            decimal(19,5)  NULL ,
	WidthOut             decimal(19,5)  NULL ,
	HeightOut            decimal(19,5)  NULL ,
	AmountOut               decimal(19,5)  NULL ,
	LenghtIn             decimal(19,5)  NULL ,
	HeightIn             decimal(19,5)  NULL ,
	WidthIn              decimal(19,5)  NULL ,
	AmountIn			 decimal(19,5)  NULL, 
	IDContainers         int  NULL 
)
go



ALTER TABLE ContainersCharacteristics
	ADD CONSTRAINT PKContainersCharacteristics PRIMARY KEY  CLUSTERED (IDContainersCharacteristics ASC)
go



CREATE TABLE ContainersForCargosAttributes
( 
	IDContainers         int  NOT NULL ,
	IDAttributesForCargos int  NOT NULL 
)
go



ALTER TABLE ContainersForCargosAttributes
	ADD CONSTRAINT PKContainersForCargosAttributes PRIMARY KEY  CLUSTERED (IDContainers ASC,IDAttributesForCargos ASC)
go



CREATE TABLE FlightsSchedule
( 
	IDTypesOfFlights     int  NULL ,
	DateTimeOfFlight     datetime  NOT NULL ,
	IDShips              int  NOT NULL 
)
go



ALTER TABLE FlightsSchedule
	ADD CONSTRAINT PKFlightsSchedule PRIMARY KEY  CLUSTERED (DateTimeOfFlight ASC,IDShips ASC)
go



CREATE TABLE Orders
( 
	IDOrder              int identity NOT NULL ,
	IDClient             int  NOT NULL 
)
go



ALTER TABLE Orders
	ADD CONSTRAINT PKOrders PRIMARY KEY  CLUSTERED (IDOrder ASC, IDClient ASC)
go



CREATE TABLE OrdersOnFligths
( 
	DateTimeOfFlight     datetime  NOT NULL ,
	IDShips              int  NOT NULL ,
	IDOrder              int  NOT NULL ,
	IDClient             int  NOT NULL 
)
go



ALTER TABLE OrdersOnFligths
	ADD CONSTRAINT PKOrdersOnFligths PRIMARY KEY  CLUSTERED (DateTimeOfFlight ASC,IDShips ASC,IDOrder ASC,IDClient ASC)
go



CREATE TABLE Ships
( 
	IDShips              int identity  NOT NULL ,
	ShipNumber           nvarchar(250)  NULL ,
	RegistrationDate     datetime  NULL ,
	AmountFreeSpace      int  NULL ,
	IDSizesShips         int  NULL ,
	IDTypesShips         int  NULL 
)
go



ALTER TABLE Ships
	ADD CONSTRAINT PKShips PRIMARY KEY  CLUSTERED (IDShips ASC)
go



CREATE TABLE SizesShips
( 
	IDSizesShips         int identity  NOT NULL ,
	Name                 nvarchar(250)  NULL ,
	Amount               int  NULL 
)
go



ALTER TABLE SizesShips
	ADD CONSTRAINT PKSize PRIMARY KEY  CLUSTERED (IDSizesShips ASC)
go



CREATE TABLE StatusesFligths
( 
	IDStatusesFligths int identity NOT NULL,
	DateTimeStatusWasSet datetime  NOT NULL ,
	DateTimeOfFlight     datetime  NOT NULL ,
	IDShips              int  NOT NULL ,
	IDStatusesForFligths int  NOT NULL 
)
go



ALTER TABLE StatusesFligths
	ADD CONSTRAINT PKStatusesFligths PRIMARY KEY  CLUSTERED (IDStatusesFligths ASC, IDShips ASC,IDStatusesForFligths ASC)
go



CREATE TABLE StatusesForFligths
( 
	IDStatusesForFligths int identity  NOT NULL ,
	Status               nvarchar(250)  NULL 
)
go



ALTER TABLE StatusesForFligths
	ADD CONSTRAINT PKStatusesForFligths PRIMARY KEY  CLUSTERED (IDStatusesForFligths ASC)
go



CREATE TABLE StatusesForShips
( 
	IDStatusesForShips   int identity  NOT NULL ,
	Status               nvarchar(250)  NULL 
)
go



ALTER TABLE StatusesForShips
	ADD CONSTRAINT PKStatusesForShips PRIMARY KEY  CLUSTERED (IDStatusesForShips ASC)
go



CREATE TABLE StatusesShips
( 
	IDStatusesShips int identity NOT NULL,
	IDShips              int  NOT NULL ,
	DateTimeStatusWasSet datetime  NOT NULL ,
	IDStatusesForShips   int  NOT NULL 
)
go



ALTER TABLE StatusesShips
	ADD CONSTRAINT PKStatusesShips PRIMARY KEY  CLUSTERED (IDShips ASC,IDStatusesShips ASC,IDStatusesForShips ASC)
go



CREATE TABLE TypesOfFlights
( 
	IDTypesOfFlights     int identity  NOT NULL ,
	Name                 nvarchar(250)  NULL 
)
go



ALTER TABLE TypesOfFlights
	ADD CONSTRAINT PKTypesOfFlights PRIMARY KEY  CLUSTERED (IDTypesOfFlights ASC)
go



CREATE TABLE TypesShips
( 
	IDTypesShips         int identity NOT NULL ,
	Name                 nvarchar(250)  NULL 
)
go



ALTER TABLE TypesShips
	ADD CONSTRAINT PKTypesShips PRIMARY KEY  CLUSTERED (IDTypesShips ASC)
go



CREATE TABLE TypesShipsImplementCargoAttributes
( 
	IDTypesShips         int  NOT NULL ,
	IDAttributesForCargos int  NOT NULL 
)
go



ALTER TABLE TypesShipsImplementCargoAttributes
	ADD CONSTRAINT PKTypesShipsImplementCargoAttributes PRIMARY KEY  CLUSTERED (IDTypesShips ASC,IDAttributesForCargos ASC)
go




ALTER TABLE CargosAttributes
	ADD CONSTRAINT R_9 FOREIGN KEY (IDAttributesForCargos) REFERENCES AttributesForCargos(IDAttributesForCargos)
		ON DELETE NO ACTION
		ON UPDATE NO ACTION
go




ALTER TABLE CargosAttributes
	ADD CONSTRAINT R_10 FOREIGN KEY (IDCargosInOrders) REFERENCES CargosInOrders(IDCargosInOrders)
		ON DELETE NO ACTION
		ON UPDATE NO ACTION
go




ALTER TABLE CargosCharacteristics
	ADD CONSTRAINT R_42 FOREIGN KEY (IDCargosInOrders) REFERENCES CargosInOrders(IDCargosInOrders)
		ON DELETE NO ACTION
		ON UPDATE NO ACTION
go




ALTER TABLE CargosInOrders
	ADD CONSTRAINT R_21 FOREIGN KEY (IDOrder,IDClient) REFERENCES Orders(IDOrder,IDClient)
		ON DELETE NO ACTION
		ON UPDATE NO ACTION
go




ALTER TABLE CargosInOrders
	ADD CONSTRAINT R_22 FOREIGN KEY (IDContainers) REFERENCES Containers(IDContainers)
		ON DELETE NO ACTION
		ON UPDATE NO ACTION
go




ALTER TABLE ContainersCharacteristics
	ADD CONSTRAINT R_19 FOREIGN KEY (IDContainers) REFERENCES Containers(IDContainers)
		ON DELETE NO ACTION
		ON UPDATE NO ACTION
go




ALTER TABLE ContainersForCargosAttributes
	ADD CONSTRAINT R_7 FOREIGN KEY (IDContainers) REFERENCES Containers(IDContainers)
		ON DELETE NO ACTION
		ON UPDATE NO ACTION
go




ALTER TABLE ContainersForCargosAttributes
	ADD CONSTRAINT R_8 FOREIGN KEY (IDAttributesForCargos) REFERENCES AttributesForCargos(IDAttributesForCargos)
		ON DELETE NO ACTION
		ON UPDATE NO ACTION
go




ALTER TABLE FlightsSchedule
	ADD CONSTRAINT R_14 FOREIGN KEY (IDTypesOfFlights) REFERENCES TypesOfFlights(IDTypesOfFlights)
		ON DELETE NO ACTION
		ON UPDATE NO ACTION
go




ALTER TABLE FlightsSchedule
	ADD CONSTRAINT R_15 FOREIGN KEY (IDShips) REFERENCES Ships(IDShips)
		ON DELETE NO ACTION
		ON UPDATE NO ACTION
go




ALTER TABLE Orders
	ADD CONSTRAINT R_18 FOREIGN KEY (IDClient) REFERENCES Clients(IDClient)
		ON DELETE NO ACTION
		ON UPDATE NO ACTION
go




ALTER TABLE OrdersOnFligths
	ADD CONSTRAINT R_37 FOREIGN KEY (DateTimeOfFlight,IDShips) REFERENCES FlightsSchedule(DateTimeOfFlight,IDShips)
		ON DELETE NO ACTION
		ON UPDATE NO ACTION
go




ALTER TABLE OrdersOnFligths
	ADD CONSTRAINT R_38 FOREIGN KEY (IDOrder,IDClient) REFERENCES Orders(IDOrder,IDClient)
		ON DELETE NO ACTION
		ON UPDATE NO ACTION
go




ALTER TABLE Ships
	ADD CONSTRAINT R_4 FOREIGN KEY (IDSizesShips) REFERENCES SizesShips(IDSizesShips)
		ON DELETE NO ACTION
		ON UPDATE NO ACTION
go



ALTER TABLE Ships
	ADD CONSTRAINT R_6 FOREIGN KEY (IDTypesShips) REFERENCES TypesShips(IDTypesShips)
		ON DELETE NO ACTION
		ON UPDATE NO ACTION
go




ALTER TABLE StatusesFligths
	ADD CONSTRAINT R_34 FOREIGN KEY (DateTimeOfFlight,IDShips) REFERENCES FlightsSchedule(DateTimeOfFlight,IDShips)
		ON DELETE NO ACTION
		ON UPDATE NO ACTION
go




ALTER TABLE StatusesFligths
	ADD CONSTRAINT R_41 FOREIGN KEY (IDStatusesForFligths) REFERENCES StatusesForFligths(IDStatusesForFligths)
		ON DELETE NO ACTION
		ON UPDATE NO ACTION
go




ALTER TABLE StatusesShips
	ADD CONSTRAINT R_2 FOREIGN KEY (IDShips) REFERENCES Ships(IDShips)
		ON DELETE NO ACTION
		ON UPDATE NO ACTION
go




ALTER TABLE StatusesShips
	ADD CONSTRAINT R_40 FOREIGN KEY (IDStatusesForShips) REFERENCES StatusesForShips(IDStatusesForShips)
		ON DELETE NO ACTION
		ON UPDATE NO ACTION
go




ALTER TABLE TypesShipsImplementCargoAttributes
	ADD CONSTRAINT R_11 FOREIGN KEY (IDTypesShips) REFERENCES TypesShips(IDTypesShips)
		ON DELETE NO ACTION
		ON UPDATE NO ACTION
go




ALTER TABLE TypesShipsImplementCargoAttributes
	ADD CONSTRAINT R_12 FOREIGN KEY (IDAttributesForCargos) REFERENCES AttributesForCargos(IDAttributesForCargos)
		ON DELETE NO ACTION
		ON UPDATE NO ACTION
go