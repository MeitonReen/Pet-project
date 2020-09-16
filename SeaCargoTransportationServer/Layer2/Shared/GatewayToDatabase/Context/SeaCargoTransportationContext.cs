﻿using System;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using SharedDTOs;

namespace Layer2.Shared.GatewayToDatabase.Context
{
	public partial class SeaCargoTransportationContext : DbContext
	{
		private SqlConnectionStringBuilder SqlConnectionStringBuilder = null;

		public SeaCargoTransportationContext(object loginAndPassword)
		{
			LoginAndPassword LoginAndPassword = (LoginAndPassword)loginAndPassword;

			SqlConnectionStringBuilder =
				new SqlConnectionStringBuilder(Settings1.Default.ConnectToSeaCargoTransportation);
			SqlConnectionStringBuilder["User Id"] = LoginAndPassword.Login;
			SqlConnectionStringBuilder["Password"] = LoginAndPassword.Password;
		}

		public SeaCargoTransportationContext(DbContextOptions<SeaCargoTransportationContext> options)
			: base(options)
		{
		}

		public virtual DbSet<AttributesForCargos> AttributesForCargos { get; set; }
		public virtual DbSet<CargosAttributes> CargosAttributes { get; set; }
		public virtual DbSet<CargosCharacteristics> CargosCharacteristics { get; set; }
		public virtual DbSet<CargosInOrders> CargosInOrders { get; set; }
		public virtual DbSet<Clients> Clients { get; set; }
		public virtual DbSet<Containers> Containers { get; set; }
		public virtual DbSet<ContainersCharacteristics> ContainersCharacteristics { get; set; }
		public virtual DbSet<ContainersForCargosAttributes> ContainersForCargosAttributes { get; set; }
		public virtual DbSet<FlightsSchedule> FlightsSchedule { get; set; }
		public virtual DbSet<Orders> Orders { get; set; }
		public virtual DbSet<OrdersOnFligths> OrdersOnFligths { get; set; }
		public virtual DbSet<Ships> Ships { get; set; }
		public virtual DbSet<SizesShips> SizesShips { get; set; }
		public virtual DbSet<StatusesFligths> StatusesFligths { get; set; }
		public virtual DbSet<StatusesForFligths> StatusesForFligths { get; set; }
		public virtual DbSet<StatusesForShips> StatusesForShips { get; set; }
		public virtual DbSet<StatusesShips> StatusesShips { get; set; }
		public virtual DbSet<TypesOfFlights> TypesOfFlights { get; set; }
		public virtual DbSet<TypesShips> TypesShips { get; set; }
		public virtual DbSet<TypesShipsImplementCargoAttributes> TypesShipsImplementCargoAttributes { get; set; }

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			if (!optionsBuilder.IsConfigured)
			{
				optionsBuilder.UseSqlServer(
					SqlConnectionStringBuilder.ConnectionString,
					options => options.EnableRetryOnFailure(5, TimeSpan.FromSeconds(10), null));
			}
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<AttributesForCargos>(entity =>
			{
				entity.HasKey(e => e.IdattributesForCargos)
					.HasName("PKAttributesForCargos");

				entity.Property(e => e.IdattributesForCargos).HasColumnName("IDAttributesForCargos");

				entity.Property(e => e.Name).HasMaxLength(250);
			});

			modelBuilder.Entity<CargosAttributes>(entity =>
			{
				entity.HasKey(e => new { e.IdattributesForCargos, e.IdcargosInOrders })
					.HasName("PKCargosAttributes");

				entity.Property(e => e.IdattributesForCargos).HasColumnName("IDAttributesForCargos");

				entity.Property(e => e.IdcargosInOrders).HasColumnName("IDCargosInOrders");

				entity.HasOne(d => d.IdattributesForCargosNavigation)
					.WithMany(p => p.CargosAttributes)
					.HasForeignKey(d => d.IdattributesForCargos)
					.OnDelete(DeleteBehavior.ClientSetNull)
					.HasConstraintName("R_9");

				entity.HasOne(d => d.IdcargosInOrdersNavigation)
					.WithMany(p => p.CargosAttributes)
					.HasForeignKey(d => d.IdcargosInOrders)
					.OnDelete(DeleteBehavior.ClientSetNull)
					.HasConstraintName("R_10");
			});

			modelBuilder.Entity<CargosCharacteristics>(entity =>
			{
				entity.HasKey(e => e.IdcargosCharacteristics)
					.HasName("PKCargosCharacteristic");

				entity.Property(e => e.IdcargosCharacteristics).HasColumnName("IDCargosCharacteristics");

				entity.Property(e => e.Amount).HasColumnType("decimal(19, 5)");

				entity.Property(e => e.Height).HasColumnType("decimal(19, 5)");

				entity.Property(e => e.IdcargosInOrders).HasColumnName("IDCargosInOrders");

				entity.Property(e => e.Length).HasColumnType("decimal(19, 5)");

				entity.Property(e => e.Weight).HasColumnType("decimal(19, 5)");

				entity.Property(e => e.Wigth).HasColumnType("decimal(19, 5)");

				entity.HasOne(d => d.IdcargosInOrdersNavigation)
					.WithMany(p => p.CargosCharacteristics)
					.HasForeignKey(d => d.IdcargosInOrders)
					.HasConstraintName("R_42");
			});

			modelBuilder.Entity<CargosInOrders>(entity =>
			{
				entity.HasKey(e => e.IdcargosInOrders)
					.HasName("PKCargosInOrders");

				entity.Property(e => e.IdcargosInOrders).HasColumnName("IDCargosInOrders");

				entity.Property(e => e.Idclient).HasColumnName("IDClient");

				entity.Property(e => e.Idcontainers).HasColumnName("IDContainers");

				entity.Property(e => e.Idorder).HasColumnName("IDOrder");

				entity.HasOne(d => d.IdcontainersNavigation)
					.WithMany(p => p.CargosInOrders)
					.HasForeignKey(d => d.Idcontainers)
					.HasConstraintName("R_22");

				entity.HasOne(d => d.Id)
					.WithMany(p => p.CargosInOrders)
					.HasForeignKey(d => new { d.Idorder, d.Idclient })
					.HasConstraintName("R_21");
			});

			modelBuilder.Entity<Clients>(entity =>
			{
				entity.HasKey(e => e.Idclient)
					.HasName("PKClients");

				entity.HasIndex(e => e.Name)
					.HasName("UQ__Clients__737584F6BA5FABB9")
					.IsUnique();

				entity.Property(e => e.Idclient).HasColumnName("IDClient");

				entity.Property(e => e.Email)
					.HasColumnName("EMail")
					.HasMaxLength(250);

				entity.Property(e => e.FirstName).HasMaxLength(250);

				entity.Property(e => e.LastName).HasMaxLength(250);

				entity.Property(e => e.Name).HasMaxLength(128);

				entity.Property(e => e.Patronymic).HasMaxLength(250);
			});

			modelBuilder.Entity<Containers>(entity =>
			{
				entity.HasKey(e => e.Idcontainers)
					.HasName("PKContainers");

				entity.Property(e => e.Idcontainers).HasColumnName("IDContainers");

				entity.Property(e => e.Name).HasMaxLength(250);
			});

			modelBuilder.Entity<ContainersCharacteristics>(entity =>
			{
				entity.HasKey(e => e.IdcontainersCharacteristics)
					.HasName("PKContainersCharacteristics");

				entity.Property(e => e.IdcontainersCharacteristics).HasColumnName("IDContainersCharacteristics");

				entity.Property(e => e.AmountIn).HasColumnType("decimal(19, 5)");

				entity.Property(e => e.AmountOut).HasColumnType("decimal(19, 5)");

				entity.Property(e => e.HeightIn).HasColumnType("decimal(19, 5)");

				entity.Property(e => e.HeightOut).HasColumnType("decimal(19, 5)");

				entity.Property(e => e.Idcontainers).HasColumnName("IDContainers");

				entity.Property(e => e.LenghtIn).HasColumnType("decimal(19, 5)");

				entity.Property(e => e.LenghtOut).HasColumnType("decimal(19, 5)");

				entity.Property(e => e.Weight).HasColumnType("decimal(19, 5)");

				entity.Property(e => e.WidthIn).HasColumnType("decimal(19, 5)");

				entity.Property(e => e.WidthOut).HasColumnType("decimal(19, 5)");

				entity.HasOne(d => d.IdcontainersNavigation)
					.WithMany(p => p.ContainersCharacteristics)
					.HasForeignKey(d => d.Idcontainers)
					.HasConstraintName("R_19");
			});

			modelBuilder.Entity<ContainersForCargosAttributes>(entity =>
			{
				entity.HasKey(e => new { e.Idcontainers, e.IdattributesForCargos })
					.HasName("PKContainersForCargosAttributes");

				entity.Property(e => e.Idcontainers).HasColumnName("IDContainers");

				entity.Property(e => e.IdattributesForCargos).HasColumnName("IDAttributesForCargos");

				entity.HasOne(d => d.IdattributesForCargosNavigation)
					.WithMany(p => p.ContainersForCargosAttributes)
					.HasForeignKey(d => d.IdattributesForCargos)
					.OnDelete(DeleteBehavior.ClientSetNull)
					.HasConstraintName("R_8");

				entity.HasOne(d => d.IdcontainersNavigation)
					.WithMany(p => p.ContainersForCargosAttributes)
					.HasForeignKey(d => d.Idcontainers)
					.OnDelete(DeleteBehavior.ClientSetNull)
					.HasConstraintName("R_7");
			});

			modelBuilder.Entity<FlightsSchedule>(entity =>
			{
				entity.HasKey(e => new { e.DateTimeOfFlight, e.Idships })
					.HasName("PKFlightsSchedule");

				entity.Property(e => e.DateTimeOfFlight).HasColumnType("datetime");

				entity.Property(e => e.Idships).HasColumnName("IDShips");

				entity.Property(e => e.IdtypesOfFlights).HasColumnName("IDTypesOfFlights");

				entity.HasOne(d => d.IdshipsNavigation)
					.WithMany(p => p.FlightsSchedule)
					.HasForeignKey(d => d.Idships)
					.OnDelete(DeleteBehavior.ClientSetNull)
					.HasConstraintName("R_15");

				entity.HasOne(d => d.IdtypesOfFlightsNavigation)
					.WithMany(p => p.FlightsSchedule)
					.HasForeignKey(d => d.IdtypesOfFlights)
					.HasConstraintName("R_14");
			});

			modelBuilder.Entity<Orders>(entity =>
			{
				entity.HasKey(e => new { e.Idorder, e.Idclient })
					.HasName("PKOrders");

				entity.Property(e => e.Idorder)
					.HasColumnName("IDOrder")
					.ValueGeneratedOnAdd();

				entity.Property(e => e.Idclient).HasColumnName("IDClient");

				entity.Property(e => e.DateTimeCreate).HasColumnType("datetime");

				entity.Property(e => e.ReceiptNumberOfOrder).HasMaxLength(30);

				entity.HasOne(d => d.IdclientNavigation)
					.WithMany(p => p.Orders)
					.HasForeignKey(d => d.Idclient)
					.OnDelete(DeleteBehavior.ClientSetNull)
					.HasConstraintName("R_18");
			});

			modelBuilder.Entity<OrdersOnFligths>(entity =>
			{
				entity.HasKey(e => new { e.DateTimeOfFlight, e.Idships, e.Idorder, e.Idclient })
					.HasName("PKOrdersOnFligths");

				entity.Property(e => e.DateTimeOfFlight).HasColumnType("datetime");

				entity.Property(e => e.Idships).HasColumnName("IDShips");

				entity.Property(e => e.Idorder).HasColumnName("IDOrder");

				entity.Property(e => e.Idclient).HasColumnName("IDClient");

				entity.HasOne(d => d.FlightsSchedule)
					.WithMany(p => p.OrdersOnFligths)
					.HasForeignKey(d => new { d.DateTimeOfFlight, d.Idships })
					.OnDelete(DeleteBehavior.ClientSetNull)
					.HasConstraintName("R_37");

				entity.HasOne(d => d.Id)
					.WithMany(p => p.OrdersOnFligths)
					.HasForeignKey(d => new { d.Idorder, d.Idclient })
					.OnDelete(DeleteBehavior.ClientSetNull)
					.HasConstraintName("R_38");
			});

			modelBuilder.Entity<Ships>(entity =>
			{
				entity.HasKey(e => e.Idships)
					.HasName("PKShips");

				entity.Property(e => e.Idships).HasColumnName("IDShips");

				entity.Property(e => e.IdsizesShips).HasColumnName("IDSizesShips");

				entity.Property(e => e.IdtypesShips).HasColumnName("IDTypesShips");

				entity.Property(e => e.RegistrationDate).HasColumnType("datetime");

				entity.Property(e => e.ShipNumber).HasMaxLength(250);

				entity.HasOne(d => d.IdsizesShipsNavigation)
					.WithMany(p => p.Ships)
					.HasForeignKey(d => d.IdsizesShips)
					.HasConstraintName("R_4");

				entity.HasOne(d => d.IdtypesShipsNavigation)
					.WithMany(p => p.Ships)
					.HasForeignKey(d => d.IdtypesShips)
					.HasConstraintName("R_6");
			});

			modelBuilder.Entity<SizesShips>(entity =>
			{
				entity.HasKey(e => e.IdsizesShips)
					.HasName("PKSize");

				entity.Property(e => e.IdsizesShips).HasColumnName("IDSizesShips");

				entity.Property(e => e.Name).HasMaxLength(250);
			});

			modelBuilder.Entity<StatusesFligths>(entity =>
			{
				entity.HasKey(e => new { e.IdstatusesFligths, e.Idships, e.IdstatusesForFligths })
					.HasName("PKStatusesFligths");

				entity.Property(e => e.IdstatusesFligths)
					.HasColumnName("IDStatusesFligths")
					.ValueGeneratedOnAdd();

				entity.Property(e => e.Idships).HasColumnName("IDShips");

				entity.Property(e => e.IdstatusesForFligths).HasColumnName("IDStatusesForFligths");

				entity.Property(e => e.DateTimeOfFlight).HasColumnType("datetime");

				entity.Property(e => e.DateTimeStatusWasSet).HasColumnType("datetime");

				entity.HasOne(d => d.IdstatusesForFligthsNavigation)
					.WithMany(p => p.StatusesFligths)
					.HasForeignKey(d => d.IdstatusesForFligths)
					.OnDelete(DeleteBehavior.ClientSetNull)
					.HasConstraintName("R_41");

				entity.HasOne(d => d.FlightsSchedule)
					.WithMany(p => p.StatusesFligths)
					.HasForeignKey(d => new { d.DateTimeOfFlight, d.Idships })
					.OnDelete(DeleteBehavior.ClientSetNull)
					.HasConstraintName("R_34");
			});

			modelBuilder.Entity<StatusesForFligths>(entity =>
			{
				entity.HasKey(e => e.IdstatusesForFligths)
					.HasName("PKStatusesForFligths");

				entity.Property(e => e.IdstatusesForFligths).HasColumnName("IDStatusesForFligths");

				entity.Property(e => e.Status).HasMaxLength(250);
			});

			modelBuilder.Entity<StatusesForShips>(entity =>
			{
				entity.HasKey(e => e.IdstatusesForShips)
					.HasName("PKStatusesForShips");

				entity.Property(e => e.IdstatusesForShips).HasColumnName("IDStatusesForShips");

				entity.Property(e => e.Status).HasMaxLength(250);
			});

			modelBuilder.Entity<StatusesShips>(entity =>
			{
				entity.HasKey(e => new { e.Idships, e.IdstatusesShips, e.IdstatusesForShips })
					.HasName("PKStatusesShips");

				entity.Property(e => e.Idships).HasColumnName("IDShips");

				entity.Property(e => e.IdstatusesShips)
					.HasColumnName("IDStatusesShips")
					.ValueGeneratedOnAdd();

				entity.Property(e => e.IdstatusesForShips).HasColumnName("IDStatusesForShips");

				entity.Property(e => e.DateTimeStatusWasSet).HasColumnType("datetime");

				entity.HasOne(d => d.IdshipsNavigation)
					.WithMany(p => p.StatusesShips)
					.HasForeignKey(d => d.Idships)
					.OnDelete(DeleteBehavior.ClientSetNull)
					.HasConstraintName("R_2");

				entity.HasOne(d => d.IdstatusesForShipsNavigation)
					.WithMany(p => p.StatusesShips)
					.HasForeignKey(d => d.IdstatusesForShips)
					.OnDelete(DeleteBehavior.ClientSetNull)
					.HasConstraintName("R_40");
			});

			modelBuilder.Entity<TypesOfFlights>(entity =>
			{
				entity.HasKey(e => e.IdtypesOfFlights)
					.HasName("PKTypesOfFlights");

				entity.Property(e => e.IdtypesOfFlights).HasColumnName("IDTypesOfFlights");

				entity.Property(e => e.Name).HasMaxLength(250);
			});

			modelBuilder.Entity<TypesShips>(entity =>
			{
				entity.HasKey(e => e.IdtypesShips)
					.HasName("PKTypesShips");

				entity.Property(e => e.IdtypesShips).HasColumnName("IDTypesShips");

				entity.Property(e => e.Name).HasMaxLength(250);
			});

			modelBuilder.Entity<TypesShipsImplementCargoAttributes>(entity =>
			{
				entity.HasKey(e => new { e.IdtypesShips, e.IdattributesForCargos })
					.HasName("PKTypesShipsImplementCargoAttributes");

				entity.Property(e => e.IdtypesShips).HasColumnName("IDTypesShips");

				entity.Property(e => e.IdattributesForCargos).HasColumnName("IDAttributesForCargos");

				entity.HasOne(d => d.IdattributesForCargosNavigation)
					.WithMany(p => p.TypesShipsImplementCargoAttributes)
					.HasForeignKey(d => d.IdattributesForCargos)
					.OnDelete(DeleteBehavior.ClientSetNull)
					.HasConstraintName("R_12");

				entity.HasOne(d => d.IdtypesShipsNavigation)
					.WithMany(p => p.TypesShipsImplementCargoAttributes)
					.HasForeignKey(d => d.IdtypesShips)
					.OnDelete(DeleteBehavior.ClientSetNull)
					.HasConstraintName("R_11");
			});

			OnModelCreatingPartial(modelBuilder);
		}

		partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
	}
}
