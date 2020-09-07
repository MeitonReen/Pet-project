use SeaCargoTransportation
go

insert into TypesShipsImplementCargoAttributes
(
	IDTypesShips,
	IDAttributesForCargos
)
select IDTypesShips, IDAttributesForCargos
from TypesShips
	join
	(
		select IDAttributesForCargos
		from AttributesForCargos
	) Table2
	on 1=1
	