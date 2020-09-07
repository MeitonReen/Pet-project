use SeaCargoTransportation
go

insert into Ships
(
	ShipNumber,
	RegistrationDate,
	IDTypesShips,
	IDSizesShips,
	AmountFreeSpace
)
	values
	(
		'138282-11393',
		'2017.06.11 15:00',
		(
			select IDTypesShips
				from TypesShips
					where TypesShips.Name = 'Грузовой'
		),
		(
			select IDSizesShips
				from SizesShips
					where SizesShips.Name = 'Handysize'
		),
		(
			select Amount
				from SizesShips
					where SizesShips.Name = 'Handysize'
		)
	)
go

insert into Ships
(
	ShipNumber,
	RegistrationDate,
	IDTypesShips,
	IDSizesShips,
	AmountFreeSpace
)
	values
	(
		'1asdsad2-sdfdsf93',
		'2017.06.12 15:00',
		(
			select IDTypesShips
				from TypesShips
					where TypesShips.Name = 'Грузовой'
		),
		(
			select IDSizesShips
				from SizesShips
					where SizesShips.Name = 'Handymax'
		),
		(
			select Amount
				from SizesShips
					where SizesShips.Name = 'Handymax'
		)
	)
go

insert into Ships
(
	ShipNumber,
	RegistrationDate,
	IDTypesShips,
	IDSizesShips,
	AmountFreeSpace
)
	values
	(
		'23434423ads-234dwsrfsd',
		'2017.06.02 15:00',
		(
			select IDTypesShips
				from TypesShips
					where TypesShips.Name = 'Грузовой'
		),
		(
			select IDSizesShips
				from SizesShips
					where SizesShips.Name = 'Seawaymax'
		),
		(
			select Amount
				from SizesShips
					where SizesShips.Name = 'Seawaymax'
		)
	)
go

insert into Ships
(
	ShipNumber,
	RegistrationDate,
	IDTypesShips,
	IDSizesShips,
	AmountFreeSpace
)
	values
	(
		'sad342423-sdf324234',
		'2017.06.12 15:00',
		(
			select IDTypesShips
				from TypesShips
					where TypesShips.Name = 'Грузовой'
		),
		(
			select IDSizesShips
				from SizesShips
					where SizesShips.Name = 'Aframax'
		),
		(
			select Amount
				from SizesShips
					where SizesShips.Name = 'Aframax'
		)
	)
go

insert into Ships
(
	ShipNumber,
	RegistrationDate,
	IDTypesShips,
	IDSizesShips,
	AmountFreeSpace
)
	values
	(
		'sdf3343-fsdfhgfd435',
		'2017.06.11 15:00',
		(
			select IDTypesShips
				from TypesShips
					where TypesShips.Name = 'Грузовой'
		),
		(
			select IDSizesShips
				from SizesShips
					where SizesShips.Name = 'Suezmax'
		),
		(
			select Amount
				from SizesShips
					where SizesShips.Name = 'Suezmax'
		)
	)
go