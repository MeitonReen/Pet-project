use SeaCargoTransportation
go

insert into
	ContainersForCargosAttributes
	(
		IDAttributesForCargos,
		IDContainers
	)
	select 
		IDAttributesForCargos,
		IDContainers
	from 
		AttributesForCargos
		cross join
			Containers
	