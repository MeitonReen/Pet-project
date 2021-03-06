use SeaCargoTransportation
go

ALTER TABLE CargosAttributes DROP CONSTRAINT R_9
go

ALTER TABLE CargosAttributes
	ADD CONSTRAINT R_9 FOREIGN KEY (IDAttributesForCargos) REFERENCES AttributesForCargos(IDAttributesForCargos)
		ON DELETE CASCADE
		ON UPDATE CASCADE
go

ALTER TABLE CargosAttributes DROP CONSTRAINT R_10
go
ALTER TABLE CargosAttributes
	ADD CONSTRAINT R_10 FOREIGN KEY (IDCargosInOrders) REFERENCES CargosInOrders(IDCargosInOrders)
		ON DELETE CASCADE
		ON UPDATE CASCADE
go

ALTER TABLE CargosCharacteristics DROP CONSTRAINT R_42
go
ALTER TABLE CargosCharacteristics
	ADD CONSTRAINT R_42 FOREIGN KEY (IDCargosInOrders) REFERENCES CargosInOrders(IDCargosInOrders)
		ON DELETE CASCADE
		ON UPDATE CASCADE
go

ALTER TABLE CargosInOrders DROP CONSTRAINT R_21
go
ALTER TABLE CargosInOrders
	ADD CONSTRAINT R_21 FOREIGN KEY (IDOrder,IDClient) REFERENCES Orders(IDOrder,IDClient)
		ON DELETE CASCADE
		ON UPDATE CASCADE
go

ALTER TABLE CargosInOrders DROP CONSTRAINT R_22
go
ALTER TABLE CargosInOrders
	ADD CONSTRAINT R_22 FOREIGN KEY (IDContainers) REFERENCES Containers(IDContainers)
		ON DELETE CASCADE
		ON UPDATE CASCADE
go

ALTER TABLE ContainersCharacteristics DROP CONSTRAINT R_19
go

ALTER TABLE ContainersCharacteristics
	ADD CONSTRAINT R_19 FOREIGN KEY (IDContainers) REFERENCES Containers(IDContainers)
		ON DELETE CASCADE
		ON UPDATE CASCADE
go


ALTER TABLE ContainersForCargosAttributes DROP CONSTRAINT R_7
go

ALTER TABLE ContainersForCargosAttributes
	ADD CONSTRAINT R_7 FOREIGN KEY (IDContainers) REFERENCES Containers(IDContainers)
		ON DELETE CASCADE
		ON UPDATE CASCADE
go


ALTER TABLE ContainersForCargosAttributes DROP CONSTRAINT R_8
go

ALTER TABLE ContainersForCargosAttributes
	ADD CONSTRAINT R_8 FOREIGN KEY (IDAttributesForCargos) REFERENCES AttributesForCargos(IDAttributesForCargos)
		ON DELETE CASCADE
		ON UPDATE CASCADE
go


ALTER TABLE FlightsSchedule DROP CONSTRAINT R_14
go

ALTER TABLE FlightsSchedule
	ADD CONSTRAINT R_14 FOREIGN KEY (IDTypesOfFlights) REFERENCES TypesOfFlights(IDTypesOfFlights)
		ON DELETE CASCADE
		ON UPDATE CASCADE
go


ALTER TABLE FlightsSchedule DROP CONSTRAINT R_15
go

ALTER TABLE FlightsSchedule
	ADD CONSTRAINT R_15 FOREIGN KEY (IDShips) REFERENCES Ships(IDShips)
		ON DELETE CASCADE
		ON UPDATE CASCADE
go


ALTER TABLE Orders DROP CONSTRAINT R_18
go


ALTER TABLE Orders
	ADD CONSTRAINT R_18 FOREIGN KEY (IDClient) REFERENCES Clients(IDClient)
		ON DELETE CASCADE
		ON UPDATE CASCADE
go


ALTER TABLE OrdersOnFligths DROP CONSTRAINT R_37
go

ALTER TABLE OrdersOnFligths
	ADD CONSTRAINT R_37 FOREIGN KEY (DateTimeOfFlight,IDShips) REFERENCES FlightsSchedule(DateTimeOfFlight,IDShips)
		ON DELETE CASCADE
		ON UPDATE CASCADE
go


ALTER TABLE OrdersOnFligths DROP CONSTRAINT R_38
go

ALTER TABLE OrdersOnFligths
	ADD CONSTRAINT R_38 FOREIGN KEY (IDOrder,IDClient) REFERENCES Orders(IDOrder,IDClient)
		ON DELETE CASCADE
		ON UPDATE CASCADE
go


ALTER TABLE Ships DROP CONSTRAINT R_4
go


ALTER TABLE Ships
	ADD CONSTRAINT R_4 FOREIGN KEY (IDSizesShips) REFERENCES SizesShips(IDSizesShips)
		ON DELETE CASCADE
		ON UPDATE CASCADE
go

ALTER TABLE Ships DROP CONSTRAINT R_6
go

ALTER TABLE Ships
	ADD CONSTRAINT R_6 FOREIGN KEY (IDTypesShips) REFERENCES TypesShips(IDTypesShips)
		ON DELETE CASCADE
		ON UPDATE CASCADE
go


ALTER TABLE StatusesFligths DROP CONSTRAINT R_34
go

ALTER TABLE StatusesFligths
	ADD CONSTRAINT R_34 FOREIGN KEY (DateTimeOfFlight,IDShips) REFERENCES FlightsSchedule(DateTimeOfFlight,IDShips)
		ON DELETE CASCADE
		ON UPDATE CASCADE
go


ALTER TABLE StatusesFligths DROP CONSTRAINT R_41
go

ALTER TABLE StatusesFligths
	ADD CONSTRAINT R_41 FOREIGN KEY (IDStatusesForFligths) REFERENCES StatusesForFligths(IDStatusesForFligths)
		ON DELETE CASCADE
		ON UPDATE CASCADE
go


ALTER TABLE StatusesShips DROP CONSTRAINT R_2
go

ALTER TABLE StatusesShips
	ADD CONSTRAINT R_2 FOREIGN KEY (IDShips) REFERENCES Ships(IDShips)
		ON DELETE CASCADE
		ON UPDATE CASCADE
go


ALTER TABLE StatusesShips DROP CONSTRAINT R_40
go

ALTER TABLE StatusesShips
	ADD CONSTRAINT R_40 FOREIGN KEY (IDStatusesForShips) REFERENCES StatusesForShips(IDStatusesForShips)
		ON DELETE CASCADE
		ON UPDATE CASCADE
go


ALTER TABLE TypesShipsImplementCargoAttributes DROP CONSTRAINT R_11
go

ALTER TABLE TypesShipsImplementCargoAttributes
	ADD CONSTRAINT R_11 FOREIGN KEY (IDTypesShips) REFERENCES TypesShips(IDTypesShips)
		ON DELETE CASCADE
		ON UPDATE CASCADE
go

ALTER TABLE TypesShipsImplementCargoAttributes DROP CONSTRAINT R_12
go


ALTER TABLE TypesShipsImplementCargoAttributes
	ADD CONSTRAINT R_12 FOREIGN KEY (IDAttributesForCargos) REFERENCES AttributesForCargos(IDAttributesForCargos)
		ON DELETE CASCADE
		ON UPDATE CASCADE
go