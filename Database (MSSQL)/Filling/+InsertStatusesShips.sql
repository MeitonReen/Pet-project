use SeaCargoTransportation
go

insert into StatusesShips
(
	IDShips,
	IDStatusesForShips,
	DateTimeStatusWasSet
)
	select 
		IDShips,
		(
			select IDStatusesForShips
				from StatusesForShips
					where Status = 'Готов к рейсу'
		) as IDStatusesForShips,
		(
			select '2020.28.06 15:00'
		) as DateTimeStatusWasSet
		from Ships
go