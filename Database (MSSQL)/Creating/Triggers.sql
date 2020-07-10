use SeaCargoTransportation
go


CREATE TRIGGER tD_AttributesForCargos ON AttributesForCargos FOR DELETE AS
/* ERwin Builtin Trigger */
/* DELETE trigger on AttributesForCargos */
BEGIN
  DECLARE  @errno   int,
           @errmsg  varchar(255)
    /* ERwin Builtin Trigger */
    /* AttributesForCargos  ContainersForCargosAttributes on parent delete no action */
    /* ERWIN_RELATION:CHECKSUM="0003bf83", PARENT_OWNER="", PARENT_TABLE="AttributesForCargos"
    CHILD_OWNER="", CHILD_TABLE="ContainersForCargosAttributes"
    P2C_VERB_PHRASE="", C2P_VERB_PHRASE="", 
    FK_CONSTRAINT="R_8", FK_COLUMNS="IDAttributesForCargos" */
    IF EXISTS (
      SELECT * FROM deleted,ContainersForCargosAttributes
      WHERE
        /*  %JoinFKPK(ContainersForCargosAttributes,deleted," = "," AND") */
        ContainersForCargosAttributes.IDAttributesForCargos = deleted.IDAttributesForCargos
    )
    BEGIN
      SELECT @errno  = 30001,
             @errmsg = 'Cannot delete AttributesForCargos because ContainersForCargosAttributes exists.'
      GOTO ERROR
    END

    /* ERwin Builtin Trigger */
    /* AttributesForCargos  CargosAttributes on parent delete no action */
    /* ERWIN_RELATION:CHECKSUM="00000000", PARENT_OWNER="", PARENT_TABLE="AttributesForCargos"
    CHILD_OWNER="", CHILD_TABLE="CargosAttributes"
    P2C_VERB_PHRASE="", C2P_VERB_PHRASE="", 
    FK_CONSTRAINT="R_9", FK_COLUMNS="IDAttributesForCargos" */
    IF EXISTS (
      SELECT * FROM deleted,CargosAttributes
      WHERE
        /*  %JoinFKPK(CargosAttributes,deleted," = "," AND") */
        CargosAttributes.IDAttributesForCargos = deleted.IDAttributesForCargos
    )
    BEGIN
      SELECT @errno  = 30001,
             @errmsg = 'Cannot delete AttributesForCargos because CargosAttributes exists.'
      GOTO ERROR
    END

    /* ERwin Builtin Trigger */
    /* AttributesForCargos  TypesShipsImplementCargoAttributes on parent delete no action */
    /* ERWIN_RELATION:CHECKSUM="00000000", PARENT_OWNER="", PARENT_TABLE="AttributesForCargos"
    CHILD_OWNER="", CHILD_TABLE="TypesShipsImplementCargoAttributes"
    P2C_VERB_PHRASE="", C2P_VERB_PHRASE="", 
    FK_CONSTRAINT="R_12", FK_COLUMNS="IDAttributesForCargos" */
    IF EXISTS (
      SELECT * FROM deleted,TypesShipsImplementCargoAttributes
      WHERE
        /*  %JoinFKPK(TypesShipsImplementCargoAttributes,deleted," = "," AND") */
        TypesShipsImplementCargoAttributes.IDAttributesForCargos = deleted.IDAttributesForCargos
    )
    BEGIN
      SELECT @errno  = 30001,
             @errmsg = 'Cannot delete AttributesForCargos because TypesShipsImplementCargoAttributes exists.'
      GOTO ERROR
    END


    /* ERwin Builtin Trigger */
    RETURN
ERROR:
    raiserror (@errmsg, -1, -1)
    rollback transaction
END

go


CREATE TRIGGER tU_AttributesForCargos ON AttributesForCargos FOR UPDATE AS
/* ERwin Builtin Trigger */
/* UPDATE trigger on AttributesForCargos */
BEGIN
  DECLARE  @NUMROWS int,
           @nullcnt int,
           @validcnt int,
           @insIDAttributesForCargos integer,
           @errno   int,
           @errmsg  varchar(255)

  SELECT @NUMROWS = @@rowcount
  /* ERwin Builtin Trigger */
  /* AttributesForCargos  ContainersForCargosAttributes on parent update no action */
  /* ERWIN_RELATION:CHECKSUM="0004146c", PARENT_OWNER="", PARENT_TABLE="AttributesForCargos"
    CHILD_OWNER="", CHILD_TABLE="ContainersForCargosAttributes"
    P2C_VERB_PHRASE="", C2P_VERB_PHRASE="", 
    FK_CONSTRAINT="R_8", FK_COLUMNS="IDAttributesForCargos" */
  IF
    /* %ParentPK(" OR",UPDATE) */
    UPDATE(IDAttributesForCargos)
  BEGIN
    IF EXISTS (
      SELECT * FROM deleted,ContainersForCargosAttributes
      WHERE
        /*  %JoinFKPK(ContainersForCargosAttributes,deleted," = "," AND") */
        ContainersForCargosAttributes.IDAttributesForCargos = deleted.IDAttributesForCargos
    )
    BEGIN
      SELECT @errno  = 30005,
             @errmsg = 'Cannot update AttributesForCargos because ContainersForCargosAttributes exists.'
      GOTO ERROR
    END
  END

  /* ERwin Builtin Trigger */
  /* AttributesForCargos  CargosAttributes on parent update no action */
  /* ERWIN_RELATION:CHECKSUM="00000000", PARENT_OWNER="", PARENT_TABLE="AttributesForCargos"
    CHILD_OWNER="", CHILD_TABLE="CargosAttributes"
    P2C_VERB_PHRASE="", C2P_VERB_PHRASE="", 
    FK_CONSTRAINT="R_9", FK_COLUMNS="IDAttributesForCargos" */
  IF
    /* %ParentPK(" OR",UPDATE) */
    UPDATE(IDAttributesForCargos)
  BEGIN
    IF EXISTS (
      SELECT * FROM deleted,CargosAttributes
      WHERE
        /*  %JoinFKPK(CargosAttributes,deleted," = "," AND") */
        CargosAttributes.IDAttributesForCargos = deleted.IDAttributesForCargos
    )
    BEGIN
      SELECT @errno  = 30005,
             @errmsg = 'Cannot update AttributesForCargos because CargosAttributes exists.'
      GOTO ERROR
    END
  END

  /* ERwin Builtin Trigger */
  /* AttributesForCargos  TypesShipsImplementCargoAttributes on parent update no action */
  /* ERWIN_RELATION:CHECKSUM="00000000", PARENT_OWNER="", PARENT_TABLE="AttributesForCargos"
    CHILD_OWNER="", CHILD_TABLE="TypesShipsImplementCargoAttributes"
    P2C_VERB_PHRASE="", C2P_VERB_PHRASE="", 
    FK_CONSTRAINT="R_12", FK_COLUMNS="IDAttributesForCargos" */
  IF
    /* %ParentPK(" OR",UPDATE) */
    UPDATE(IDAttributesForCargos)
  BEGIN
    IF EXISTS (
      SELECT * FROM deleted,TypesShipsImplementCargoAttributes
      WHERE
        /*  %JoinFKPK(TypesShipsImplementCargoAttributes,deleted," = "," AND") */
        TypesShipsImplementCargoAttributes.IDAttributesForCargos = deleted.IDAttributesForCargos
    )
    BEGIN
      SELECT @errno  = 30005,
             @errmsg = 'Cannot update AttributesForCargos because TypesShipsImplementCargoAttributes exists.'
      GOTO ERROR
    END
  END


  /* ERwin Builtin Trigger */
  RETURN
ERROR:
    raiserror (@errmsg, -1, -1)
    rollback transaction
END

go




CREATE TRIGGER tD_CargosAttributes ON CargosAttributes FOR DELETE AS
/* ERwin Builtin Trigger */
/* DELETE trigger on CargosAttributes */
BEGIN
  DECLARE  @errno   int,
           @errmsg  varchar(255)
    /* ERwin Builtin Trigger */
    /* AttributesForCargos  CargosAttributes on child delete no action */
    /* ERWIN_RELATION:CHECKSUM="0002e084", PARENT_OWNER="", PARENT_TABLE="AttributesForCargos"
    CHILD_OWNER="", CHILD_TABLE="CargosAttributes"
    P2C_VERB_PHRASE="", C2P_VERB_PHRASE="", 
    FK_CONSTRAINT="R_9", FK_COLUMNS="IDAttributesForCargos" */
    IF EXISTS (SELECT * FROM deleted,AttributesForCargos
      WHERE
        /* %JoinFKPK(deleted,AttributesForCargos," = "," AND") */
        deleted.IDAttributesForCargos = AttributesForCargos.IDAttributesForCargos AND
        NOT EXISTS (
          SELECT * FROM CargosAttributes
          WHERE
            /* %JoinFKPK(CargosAttributes,AttributesForCargos," = "," AND") */
            CargosAttributes.IDAttributesForCargos = AttributesForCargos.IDAttributesForCargos
        )
    )
    BEGIN
      SELECT @errno  = 30010,
             @errmsg = 'Cannot delete last CargosAttributes because AttributesForCargos exists.'
      GOTO ERROR
    END

    /* ERwin Builtin Trigger */
    /* CargosInOrders  CargosAttributes on child delete no action */
    /* ERWIN_RELATION:CHECKSUM="00000000", PARENT_OWNER="", PARENT_TABLE="CargosInOrders"
    CHILD_OWNER="", CHILD_TABLE="CargosAttributes"
    P2C_VERB_PHRASE="", C2P_VERB_PHRASE="", 
    FK_CONSTRAINT="R_10", FK_COLUMNS="IDCargosInOrders" */
    IF EXISTS (SELECT * FROM deleted,CargosInOrders
      WHERE
        /* %JoinFKPK(deleted,CargosInOrders," = "," AND") */
        deleted.IDCargosInOrders = CargosInOrders.IDCargosInOrders AND
        NOT EXISTS (
          SELECT * FROM CargosAttributes
          WHERE
            /* %JoinFKPK(CargosAttributes,CargosInOrders," = "," AND") */
            CargosAttributes.IDCargosInOrders = CargosInOrders.IDCargosInOrders
        )
    )
    BEGIN
      SELECT @errno  = 30010,
             @errmsg = 'Cannot delete last CargosAttributes because CargosInOrders exists.'
      GOTO ERROR
    END


    /* ERwin Builtin Trigger */
    RETURN
ERROR:
    raiserror (@errmsg, -1, -1)
    rollback transaction
END

go


CREATE TRIGGER tU_CargosAttributes ON CargosAttributes FOR UPDATE AS
/* ERwin Builtin Trigger */
/* UPDATE trigger on CargosAttributes */
BEGIN
  DECLARE  @NUMROWS int,
           @nullcnt int,
           @validcnt int,
           @insIDAttributesForCargos integer, 
           @insIDCargosInOrders integer,
           @errno   int,
           @errmsg  varchar(255)

  SELECT @NUMROWS = @@rowcount
  /* ERwin Builtin Trigger */
  /* AttributesForCargos  CargosAttributes on child update no action */
  /* ERWIN_RELATION:CHECKSUM="0002fa02", PARENT_OWNER="", PARENT_TABLE="AttributesForCargos"
    CHILD_OWNER="", CHILD_TABLE="CargosAttributes"
    P2C_VERB_PHRASE="", C2P_VERB_PHRASE="", 
    FK_CONSTRAINT="R_9", FK_COLUMNS="IDAttributesForCargos" */
  IF
    /* %ChildFK(" OR",UPDATE) */
    UPDATE(IDAttributesForCargos)
  BEGIN
    SELECT @nullcnt = 0
    SELECT @validcnt = count(*)
      FROM inserted,AttributesForCargos
        WHERE
          /* %JoinFKPK(inserted,AttributesForCargos) */
          inserted.IDAttributesForCargos = AttributesForCargos.IDAttributesForCargos
    /* %NotnullFK(inserted," IS NULL","select @nullcnt = count(*) from inserted where"," AND") */
    
    IF @validcnt + @nullcnt != @NUMROWS
    BEGIN
      SELECT @errno  = 30007,
             @errmsg = 'Cannot update CargosAttributes because AttributesForCargos does not exist.'
      GOTO ERROR
    END
  END

  /* ERwin Builtin Trigger */
  /* CargosInOrders  CargosAttributes on child update no action */
  /* ERWIN_RELATION:CHECKSUM="00000000", PARENT_OWNER="", PARENT_TABLE="CargosInOrders"
    CHILD_OWNER="", CHILD_TABLE="CargosAttributes"
    P2C_VERB_PHRASE="", C2P_VERB_PHRASE="", 
    FK_CONSTRAINT="R_10", FK_COLUMNS="IDCargosInOrders" */
  IF
    /* %ChildFK(" OR",UPDATE) */
    UPDATE(IDCargosInOrders)
  BEGIN
    SELECT @nullcnt = 0
    SELECT @validcnt = count(*)
      FROM inserted,CargosInOrders
        WHERE
          /* %JoinFKPK(inserted,CargosInOrders) */
          inserted.IDCargosInOrders = CargosInOrders.IDCargosInOrders
    /* %NotnullFK(inserted," IS NULL","select @nullcnt = count(*) from inserted where"," AND") */
    
    IF @validcnt + @nullcnt != @NUMROWS
    BEGIN
      SELECT @errno  = 30007,
             @errmsg = 'Cannot update CargosAttributes because CargosInOrders does not exist.'
      GOTO ERROR
    END
  END


  /* ERwin Builtin Trigger */
  RETURN
ERROR:
    raiserror (@errmsg, -1, -1)
    rollback transaction
END

go




CREATE TRIGGER tD_CargosCharacteristics ON CargosCharacteristics FOR DELETE AS
/* ERwin Builtin Trigger */
/* DELETE trigger on CargosCharacteristics */
BEGIN
  DECLARE  @errno   int,
           @errmsg  varchar(255)
    /* ERwin Builtin Trigger */
    /* CargosInOrders  CargosCharacteristics on child delete no action */
    /* ERWIN_RELATION:CHECKSUM="00017392", PARENT_OWNER="", PARENT_TABLE="CargosInOrders"
    CHILD_OWNER="", CHILD_TABLE="CargosCharacteristics"
    P2C_VERB_PHRASE="", C2P_VERB_PHRASE="", 
    FK_CONSTRAINT="R_42", FK_COLUMNS="IDCargosInOrders" */
    IF EXISTS (SELECT * FROM deleted,CargosInOrders
      WHERE
        /* %JoinFKPK(deleted,CargosInOrders," = "," AND") */
        deleted.IDCargosInOrders = CargosInOrders.IDCargosInOrders AND
        NOT EXISTS (
          SELECT * FROM CargosCharacteristics
          WHERE
            /* %JoinFKPK(CargosCharacteristics,CargosInOrders," = "," AND") */
            CargosCharacteristics.IDCargosInOrders = CargosInOrders.IDCargosInOrders
        )
    )
    BEGIN
      SELECT @errno  = 30010,
             @errmsg = 'Cannot delete last CargosCharacteristics because CargosInOrders exists.'
      GOTO ERROR
    END


    /* ERwin Builtin Trigger */
    RETURN
ERROR:
    raiserror (@errmsg, -1, -1)
    rollback transaction
END

go


CREATE TRIGGER tU_CargosCharacteristics ON CargosCharacteristics FOR UPDATE AS
/* ERwin Builtin Trigger */
/* UPDATE trigger on CargosCharacteristics */
BEGIN
  DECLARE  @NUMROWS int,
           @nullcnt int,
           @validcnt int,
           @insIDCargosCharacteristics integer,
           @errno   int,
           @errmsg  varchar(255)

  SELECT @NUMROWS = @@rowcount
  /* ERwin Builtin Trigger */
  /* CargosInOrders  CargosCharacteristics on child update no action */
  /* ERWIN_RELATION:CHECKSUM="0001a488", PARENT_OWNER="", PARENT_TABLE="CargosInOrders"
    CHILD_OWNER="", CHILD_TABLE="CargosCharacteristics"
    P2C_VERB_PHRASE="", C2P_VERB_PHRASE="", 
    FK_CONSTRAINT="R_42", FK_COLUMNS="IDCargosInOrders" */
  IF
    /* %ChildFK(" OR",UPDATE) */
    UPDATE(IDCargosInOrders)
  BEGIN
    SELECT @nullcnt = 0
    SELECT @validcnt = count(*)
      FROM inserted,CargosInOrders
        WHERE
          /* %JoinFKPK(inserted,CargosInOrders) */
          inserted.IDCargosInOrders = CargosInOrders.IDCargosInOrders
    /* %NotnullFK(inserted," IS NULL","select @nullcnt = count(*) from inserted where"," AND") */
    select @nullcnt = count(*) from inserted where
      inserted.IDCargosInOrders IS NULL
    IF @validcnt + @nullcnt != @NUMROWS
    BEGIN
      SELECT @errno  = 30007,
             @errmsg = 'Cannot update CargosCharacteristics because CargosInOrders does not exist.'
      GOTO ERROR
    END
  END


  /* ERwin Builtin Trigger */
  RETURN
ERROR:
    raiserror (@errmsg, -1, -1)
    rollback transaction
END

go




CREATE TRIGGER tD_CargosInOrders ON CargosInOrders FOR DELETE AS
/* ERwin Builtin Trigger */
/* DELETE trigger on CargosInOrders */
BEGIN
  DECLARE  @errno   int,
           @errmsg  varchar(255)
    /* ERwin Builtin Trigger */
    /* CargosInOrders  CargosAttributes on parent delete no action */
    /* ERWIN_RELATION:CHECKSUM="0004e52a", PARENT_OWNER="", PARENT_TABLE="CargosInOrders"
    CHILD_OWNER="", CHILD_TABLE="CargosAttributes"
    P2C_VERB_PHRASE="", C2P_VERB_PHRASE="", 
    FK_CONSTRAINT="R_10", FK_COLUMNS="IDCargosInOrders" */
    IF EXISTS (
      SELECT * FROM deleted,CargosAttributes
      WHERE
        /*  %JoinFKPK(CargosAttributes,deleted," = "," AND") */
        CargosAttributes.IDCargosInOrders = deleted.IDCargosInOrders
    )
    BEGIN
      SELECT @errno  = 30001,
             @errmsg = 'Cannot delete CargosInOrders because CargosAttributes exists.'
      GOTO ERROR
    END

    /* ERwin Builtin Trigger */
    /* CargosInOrders  CargosCharacteristics on parent delete no action */
    /* ERWIN_RELATION:CHECKSUM="00000000", PARENT_OWNER="", PARENT_TABLE="CargosInOrders"
    CHILD_OWNER="", CHILD_TABLE="CargosCharacteristics"
    P2C_VERB_PHRASE="", C2P_VERB_PHRASE="", 
    FK_CONSTRAINT="R_42", FK_COLUMNS="IDCargosInOrders" */
    IF EXISTS (
      SELECT * FROM deleted,CargosCharacteristics
      WHERE
        /*  %JoinFKPK(CargosCharacteristics,deleted," = "," AND") */
        CargosCharacteristics.IDCargosInOrders = deleted.IDCargosInOrders
    )
    BEGIN
      SELECT @errno  = 30001,
             @errmsg = 'Cannot delete CargosInOrders because CargosCharacteristics exists.'
      GOTO ERROR
    END

    /* ERwin Builtin Trigger */
    /* Orders  CargosInOrders on child delete no action */
    /* ERWIN_RELATION:CHECKSUM="00000000", PARENT_OWNER="", PARENT_TABLE="Orders"
    CHILD_OWNER="", CHILD_TABLE="CargosInOrders"
    P2C_VERB_PHRASE="", C2P_VERB_PHRASE="", 
    FK_CONSTRAINT="R_21", FK_COLUMNS="IDOrder""IDClient" */
    IF EXISTS (SELECT * FROM deleted,Orders
      WHERE
        /* %JoinFKPK(deleted,Orders," = "," AND") */
        deleted.IDOrder = Orders.IDOrder AND
        deleted.IDClient = Orders.IDClient AND
        NOT EXISTS (
          SELECT * FROM CargosInOrders
          WHERE
            /* %JoinFKPK(CargosInOrders,Orders," = "," AND") */
            CargosInOrders.IDOrder = Orders.IDOrder AND
            CargosInOrders.IDClient = Orders.IDClient
        )
    )
    BEGIN
      SELECT @errno  = 30010,
             @errmsg = 'Cannot delete last CargosInOrders because Orders exists.'
      GOTO ERROR
    END

    /* ERwin Builtin Trigger */
    /* Containers  CargosInOrders on child delete no action */
    /* ERWIN_RELATION:CHECKSUM="00000000", PARENT_OWNER="", PARENT_TABLE="Containers"
    CHILD_OWNER="", CHILD_TABLE="CargosInOrders"
    P2C_VERB_PHRASE="", C2P_VERB_PHRASE="", 
    FK_CONSTRAINT="R_22", FK_COLUMNS="IDContainers" */
    IF EXISTS (SELECT * FROM deleted,Containers
      WHERE
        /* %JoinFKPK(deleted,Containers," = "," AND") */
        deleted.IDContainers = Containers.IDContainers AND
        NOT EXISTS (
          SELECT * FROM CargosInOrders
          WHERE
            /* %JoinFKPK(CargosInOrders,Containers," = "," AND") */
            CargosInOrders.IDContainers = Containers.IDContainers
        )
    )
    BEGIN
      SELECT @errno  = 30010,
             @errmsg = 'Cannot delete last CargosInOrders because Containers exists.'
      GOTO ERROR
    END


    /* ERwin Builtin Trigger */
    RETURN
ERROR:
    raiserror (@errmsg, -1, -1)
    rollback transaction
END

go


CREATE TRIGGER tU_CargosInOrders ON CargosInOrders FOR UPDATE AS
/* ERwin Builtin Trigger */
/* UPDATE trigger on CargosInOrders */
BEGIN
  DECLARE  @NUMROWS int,
           @nullcnt int,
           @validcnt int,
           @insIDCargosInOrders integer,
           @errno   int,
           @errmsg  varchar(255)

  SELECT @NUMROWS = @@rowcount
  /* ERwin Builtin Trigger */
  /* CargosInOrders  CargosAttributes on parent update no action */
  /* ERWIN_RELATION:CHECKSUM="000573d2", PARENT_OWNER="", PARENT_TABLE="CargosInOrders"
    CHILD_OWNER="", CHILD_TABLE="CargosAttributes"
    P2C_VERB_PHRASE="", C2P_VERB_PHRASE="", 
    FK_CONSTRAINT="R_10", FK_COLUMNS="IDCargosInOrders" */
  IF
    /* %ParentPK(" OR",UPDATE) */
    UPDATE(IDCargosInOrders)
  BEGIN
    IF EXISTS (
      SELECT * FROM deleted,CargosAttributes
      WHERE
        /*  %JoinFKPK(CargosAttributes,deleted," = "," AND") */
        CargosAttributes.IDCargosInOrders = deleted.IDCargosInOrders
    )
    BEGIN
      SELECT @errno  = 30005,
             @errmsg = 'Cannot update CargosInOrders because CargosAttributes exists.'
      GOTO ERROR
    END
  END

  /* ERwin Builtin Trigger */
  /* CargosInOrders  CargosCharacteristics on parent update no action */
  /* ERWIN_RELATION:CHECKSUM="00000000", PARENT_OWNER="", PARENT_TABLE="CargosInOrders"
    CHILD_OWNER="", CHILD_TABLE="CargosCharacteristics"
    P2C_VERB_PHRASE="", C2P_VERB_PHRASE="", 
    FK_CONSTRAINT="R_42", FK_COLUMNS="IDCargosInOrders" */
  IF
    /* %ParentPK(" OR",UPDATE) */
    UPDATE(IDCargosInOrders)
  BEGIN
    IF EXISTS (
      SELECT * FROM deleted,CargosCharacteristics
      WHERE
        /*  %JoinFKPK(CargosCharacteristics,deleted," = "," AND") */
        CargosCharacteristics.IDCargosInOrders = deleted.IDCargosInOrders
    )
    BEGIN
      SELECT @errno  = 30005,
             @errmsg = 'Cannot update CargosInOrders because CargosCharacteristics exists.'
      GOTO ERROR
    END
  END

  /* ERwin Builtin Trigger */
  /* Orders  CargosInOrders on child update no action */
  /* ERWIN_RELATION:CHECKSUM="00000000", PARENT_OWNER="", PARENT_TABLE="Orders"
    CHILD_OWNER="", CHILD_TABLE="CargosInOrders"
    P2C_VERB_PHRASE="", C2P_VERB_PHRASE="", 
    FK_CONSTRAINT="R_21", FK_COLUMNS="IDOrder""IDClient" */
  IF
    /* %ChildFK(" OR",UPDATE) */
    UPDATE(IDOrder) OR
    UPDATE(IDClient)
  BEGIN
    SELECT @nullcnt = 0
    SELECT @validcnt = count(*)
      FROM inserted,Orders
        WHERE
          /* %JoinFKPK(inserted,Orders) */
          inserted.IDOrder = Orders.IDOrder and
          inserted.IDClient = Orders.IDClient
    /* %NotnullFK(inserted," IS NULL","select @nullcnt = count(*) from inserted where"," AND") */
    select @nullcnt = count(*) from inserted where
      inserted.IDOrder IS NULL AND
      inserted.IDClient IS NULL
    IF @validcnt + @nullcnt != @NUMROWS
    BEGIN
      SELECT @errno  = 30007,
             @errmsg = 'Cannot update CargosInOrders because Orders does not exist.'
      GOTO ERROR
    END
  END

  /* ERwin Builtin Trigger */
  /* Containers  CargosInOrders on child update no action */
  /* ERWIN_RELATION:CHECKSUM="00000000", PARENT_OWNER="", PARENT_TABLE="Containers"
    CHILD_OWNER="", CHILD_TABLE="CargosInOrders"
    P2C_VERB_PHRASE="", C2P_VERB_PHRASE="", 
    FK_CONSTRAINT="R_22", FK_COLUMNS="IDContainers" */
  IF
    /* %ChildFK(" OR",UPDATE) */
    UPDATE(IDContainers)
  BEGIN
    SELECT @nullcnt = 0
    SELECT @validcnt = count(*)
      FROM inserted,Containers
        WHERE
          /* %JoinFKPK(inserted,Containers) */
          inserted.IDContainers = Containers.IDContainers
    /* %NotnullFK(inserted," IS NULL","select @nullcnt = count(*) from inserted where"," AND") */
    select @nullcnt = count(*) from inserted where
      inserted.IDContainers IS NULL
    IF @validcnt + @nullcnt != @NUMROWS
    BEGIN
      SELECT @errno  = 30007,
             @errmsg = 'Cannot update CargosInOrders because Containers does not exist.'
      GOTO ERROR
    END
  END


  /* ERwin Builtin Trigger */
  RETURN
ERROR:
    raiserror (@errmsg, -1, -1)
    rollback transaction
END

go




CREATE TRIGGER tD_ClassesShips ON ClassesShips FOR DELETE AS
/* ERwin Builtin Trigger */
/* DELETE trigger on ClassesShips */
BEGIN
  DECLARE  @errno   int,
           @errmsg  varchar(255)
    /* ERwin Builtin Trigger */
    /* ClassesShips  Ships on parent delete no action */
    /* ERWIN_RELATION:CHECKSUM="0000eaae", PARENT_OWNER="", PARENT_TABLE="ClassesShips"
    CHILD_OWNER="", CHILD_TABLE="Ships"
    P2C_VERB_PHRASE="", C2P_VERB_PHRASE="", 
    FK_CONSTRAINT="R_5", FK_COLUMNS="IDClassesShips" */
    IF EXISTS (
      SELECT * FROM deleted,Ships
      WHERE
        /*  %JoinFKPK(Ships,deleted," = "," AND") */
        Ships.IDClassesShips = deleted.IDClassesShips
    )
    BEGIN
      SELECT @errno  = 30001,
             @errmsg = 'Cannot delete ClassesShips because Ships exists.'
      GOTO ERROR
    END


    /* ERwin Builtin Trigger */
    RETURN
ERROR:
    raiserror (@errmsg, -1, -1)
    rollback transaction
END

go


CREATE TRIGGER tU_ClassesShips ON ClassesShips FOR UPDATE AS
/* ERwin Builtin Trigger */
/* UPDATE trigger on ClassesShips */
BEGIN
  DECLARE  @NUMROWS int,
           @nullcnt int,
           @validcnt int,
           @insIDClassesShips integer,
           @errno   int,
           @errmsg  varchar(255)

  SELECT @NUMROWS = @@rowcount
  /* ERwin Builtin Trigger */
  /* ClassesShips  Ships on parent update no action */
  /* ERWIN_RELATION:CHECKSUM="00011641", PARENT_OWNER="", PARENT_TABLE="ClassesShips"
    CHILD_OWNER="", CHILD_TABLE="Ships"
    P2C_VERB_PHRASE="", C2P_VERB_PHRASE="", 
    FK_CONSTRAINT="R_5", FK_COLUMNS="IDClassesShips" */
  IF
    /* %ParentPK(" OR",UPDATE) */
    UPDATE(IDClassesShips)
  BEGIN
    IF EXISTS (
      SELECT * FROM deleted,Ships
      WHERE
        /*  %JoinFKPK(Ships,deleted," = "," AND") */
        Ships.IDClassesShips = deleted.IDClassesShips
    )
    BEGIN
      SELECT @errno  = 30005,
             @errmsg = 'Cannot update ClassesShips because Ships exists.'
      GOTO ERROR
    END
  END


  /* ERwin Builtin Trigger */
  RETURN
ERROR:
    raiserror (@errmsg, -1, -1)
    rollback transaction
END

go




CREATE TRIGGER tD_Clients ON Clients FOR DELETE AS
/* ERwin Builtin Trigger */
/* DELETE trigger on Clients */
BEGIN
  DECLARE  @errno   int,
           @errmsg  varchar(255)
    /* ERwin Builtin Trigger */
    /* Clients  Orders on parent delete no action */
    /* ERWIN_RELATION:CHECKSUM="0000f14b", PARENT_OWNER="", PARENT_TABLE="Clients"
    CHILD_OWNER="", CHILD_TABLE="Orders"
    P2C_VERB_PHRASE="", C2P_VERB_PHRASE="", 
    FK_CONSTRAINT="R_18", FK_COLUMNS="IDClient" */
    IF EXISTS (
      SELECT * FROM deleted,Orders
      WHERE
        /*  %JoinFKPK(Orders,deleted," = "," AND") */
        Orders.IDClient = deleted.IDClient
    )
    BEGIN
      SELECT @errno  = 30001,
             @errmsg = 'Cannot delete Clients because Orders exists.'
      GOTO ERROR
    END


    /* ERwin Builtin Trigger */
    RETURN
ERROR:
    raiserror (@errmsg, -1, -1)
    rollback transaction
END

go


CREATE TRIGGER tU_Clients ON Clients FOR UPDATE AS
/* ERwin Builtin Trigger */
/* UPDATE trigger on Clients */
BEGIN
  DECLARE  @NUMROWS int,
           @nullcnt int,
           @validcnt int,
           @insIDClient integer,
           @errno   int,
           @errmsg  varchar(255)

  SELECT @NUMROWS = @@rowcount
  /* ERwin Builtin Trigger */
  /* Clients  Orders on parent update no action */
  /* ERWIN_RELATION:CHECKSUM="000100b4", PARENT_OWNER="", PARENT_TABLE="Clients"
    CHILD_OWNER="", CHILD_TABLE="Orders"
    P2C_VERB_PHRASE="", C2P_VERB_PHRASE="", 
    FK_CONSTRAINT="R_18", FK_COLUMNS="IDClient" */
  IF
    /* %ParentPK(" OR",UPDATE) */
    UPDATE(IDClient)
  BEGIN
    IF EXISTS (
      SELECT * FROM deleted,Orders
      WHERE
        /*  %JoinFKPK(Orders,deleted," = "," AND") */
        Orders.IDClient = deleted.IDClient
    )
    BEGIN
      SELECT @errno  = 30005,
             @errmsg = 'Cannot update Clients because Orders exists.'
      GOTO ERROR
    END
  END


  /* ERwin Builtin Trigger */
  RETURN
ERROR:
    raiserror (@errmsg, -1, -1)
    rollback transaction
END

go




CREATE TRIGGER tD_Containers ON Containers FOR DELETE AS
/* ERwin Builtin Trigger */
/* DELETE trigger on Containers */
BEGIN
  DECLARE  @errno   int,
           @errmsg  varchar(255)
    /* ERwin Builtin Trigger */
    /* Containers  ContainersForCargosAttributes on parent delete no action */
    /* ERWIN_RELATION:CHECKSUM="00033c7e", PARENT_OWNER="", PARENT_TABLE="Containers"
    CHILD_OWNER="", CHILD_TABLE="ContainersForCargosAttributes"
    P2C_VERB_PHRASE="", C2P_VERB_PHRASE="", 
    FK_CONSTRAINT="R_7", FK_COLUMNS="IDContainers" */
    IF EXISTS (
      SELECT * FROM deleted,ContainersForCargosAttributes
      WHERE
        /*  %JoinFKPK(ContainersForCargosAttributes,deleted," = "," AND") */
        ContainersForCargosAttributes.IDContainers = deleted.IDContainers
    )
    BEGIN
      SELECT @errno  = 30001,
             @errmsg = 'Cannot delete Containers because ContainersForCargosAttributes exists.'
      GOTO ERROR
    END

    /* ERwin Builtin Trigger */
    /* Containers  ContainersCharacteristics on parent delete no action */
    /* ERWIN_RELATION:CHECKSUM="00000000", PARENT_OWNER="", PARENT_TABLE="Containers"
    CHILD_OWNER="", CHILD_TABLE="ContainersCharacteristics"
    P2C_VERB_PHRASE="", C2P_VERB_PHRASE="", 
    FK_CONSTRAINT="R_19", FK_COLUMNS="IDContainers" */
    IF EXISTS (
      SELECT * FROM deleted,ContainersCharacteristics
      WHERE
        /*  %JoinFKPK(ContainersCharacteristics,deleted," = "," AND") */
        ContainersCharacteristics.IDContainers = deleted.IDContainers
    )
    BEGIN
      SELECT @errno  = 30001,
             @errmsg = 'Cannot delete Containers because ContainersCharacteristics exists.'
      GOTO ERROR
    END

    /* ERwin Builtin Trigger */
    /* Containers  CargosInOrders on parent delete no action */
    /* ERWIN_RELATION:CHECKSUM="00000000", PARENT_OWNER="", PARENT_TABLE="Containers"
    CHILD_OWNER="", CHILD_TABLE="CargosInOrders"
    P2C_VERB_PHRASE="", C2P_VERB_PHRASE="", 
    FK_CONSTRAINT="R_22", FK_COLUMNS="IDContainers" */
    IF EXISTS (
      SELECT * FROM deleted,CargosInOrders
      WHERE
        /*  %JoinFKPK(CargosInOrders,deleted," = "," AND") */
        CargosInOrders.IDContainers = deleted.IDContainers
    )
    BEGIN
      SELECT @errno  = 30001,
             @errmsg = 'Cannot delete Containers because CargosInOrders exists.'
      GOTO ERROR
    END


    /* ERwin Builtin Trigger */
    RETURN
ERROR:
    raiserror (@errmsg, -1, -1)
    rollback transaction
END

go


CREATE TRIGGER tU_Containers ON Containers FOR UPDATE AS
/* ERwin Builtin Trigger */
/* UPDATE trigger on Containers */
BEGIN
  DECLARE  @NUMROWS int,
           @nullcnt int,
           @validcnt int,
           @insIDContainers integer,
           @errno   int,
           @errmsg  varchar(255)

  SELECT @NUMROWS = @@rowcount
  /* ERwin Builtin Trigger */
  /* Containers  ContainersForCargosAttributes on parent update no action */
  /* ERWIN_RELATION:CHECKSUM="00039a67", PARENT_OWNER="", PARENT_TABLE="Containers"
    CHILD_OWNER="", CHILD_TABLE="ContainersForCargosAttributes"
    P2C_VERB_PHRASE="", C2P_VERB_PHRASE="", 
    FK_CONSTRAINT="R_7", FK_COLUMNS="IDContainers" */
  IF
    /* %ParentPK(" OR",UPDATE) */
    UPDATE(IDContainers)
  BEGIN
    IF EXISTS (
      SELECT * FROM deleted,ContainersForCargosAttributes
      WHERE
        /*  %JoinFKPK(ContainersForCargosAttributes,deleted," = "," AND") */
        ContainersForCargosAttributes.IDContainers = deleted.IDContainers
    )
    BEGIN
      SELECT @errno  = 30005,
             @errmsg = 'Cannot update Containers because ContainersForCargosAttributes exists.'
      GOTO ERROR
    END
  END

  /* ERwin Builtin Trigger */
  /* Containers  ContainersCharacteristics on parent update no action */
  /* ERWIN_RELATION:CHECKSUM="00000000", PARENT_OWNER="", PARENT_TABLE="Containers"
    CHILD_OWNER="", CHILD_TABLE="ContainersCharacteristics"
    P2C_VERB_PHRASE="", C2P_VERB_PHRASE="", 
    FK_CONSTRAINT="R_19", FK_COLUMNS="IDContainers" */
  IF
    /* %ParentPK(" OR",UPDATE) */
    UPDATE(IDContainers)
  BEGIN
    IF EXISTS (
      SELECT * FROM deleted,ContainersCharacteristics
      WHERE
        /*  %JoinFKPK(ContainersCharacteristics,deleted," = "," AND") */
        ContainersCharacteristics.IDContainers = deleted.IDContainers
    )
    BEGIN
      SELECT @errno  = 30005,
             @errmsg = 'Cannot update Containers because ContainersCharacteristics exists.'
      GOTO ERROR
    END
  END

  /* ERwin Builtin Trigger */
  /* Containers  CargosInOrders on parent update no action */
  /* ERWIN_RELATION:CHECKSUM="00000000", PARENT_OWNER="", PARENT_TABLE="Containers"
    CHILD_OWNER="", CHILD_TABLE="CargosInOrders"
    P2C_VERB_PHRASE="", C2P_VERB_PHRASE="", 
    FK_CONSTRAINT="R_22", FK_COLUMNS="IDContainers" */
  IF
    /* %ParentPK(" OR",UPDATE) */
    UPDATE(IDContainers)
  BEGIN
    IF EXISTS (
      SELECT * FROM deleted,CargosInOrders
      WHERE
        /*  %JoinFKPK(CargosInOrders,deleted," = "," AND") */
        CargosInOrders.IDContainers = deleted.IDContainers
    )
    BEGIN
      SELECT @errno  = 30005,
             @errmsg = 'Cannot update Containers because CargosInOrders exists.'
      GOTO ERROR
    END
  END


  /* ERwin Builtin Trigger */
  RETURN
ERROR:
    raiserror (@errmsg, -1, -1)
    rollback transaction
END

go




CREATE TRIGGER tD_ContainersCharacteristics ON ContainersCharacteristics FOR DELETE AS
/* ERwin Builtin Trigger */
/* DELETE trigger on ContainersCharacteristics */
BEGIN
  DECLARE  @errno   int,
           @errmsg  varchar(255)
    /* ERwin Builtin Trigger */
    /* Containers  ContainersCharacteristics on child delete no action */
    /* ERWIN_RELATION:CHECKSUM="00016df4", PARENT_OWNER="", PARENT_TABLE="Containers"
    CHILD_OWNER="", CHILD_TABLE="ContainersCharacteristics"
    P2C_VERB_PHRASE="", C2P_VERB_PHRASE="", 
    FK_CONSTRAINT="R_19", FK_COLUMNS="IDContainers" */
    IF EXISTS (SELECT * FROM deleted,Containers
      WHERE
        /* %JoinFKPK(deleted,Containers," = "," AND") */
        deleted.IDContainers = Containers.IDContainers AND
        NOT EXISTS (
          SELECT * FROM ContainersCharacteristics
          WHERE
            /* %JoinFKPK(ContainersCharacteristics,Containers," = "," AND") */
            ContainersCharacteristics.IDContainers = Containers.IDContainers
        )
    )
    BEGIN
      SELECT @errno  = 30010,
             @errmsg = 'Cannot delete last ContainersCharacteristics because Containers exists.'
      GOTO ERROR
    END


    /* ERwin Builtin Trigger */
    RETURN
ERROR:
    raiserror (@errmsg, -1, -1)
    rollback transaction
END

go


CREATE TRIGGER tU_ContainersCharacteristics ON ContainersCharacteristics FOR UPDATE AS
/* ERwin Builtin Trigger */
/* UPDATE trigger on ContainersCharacteristics */
BEGIN
  DECLARE  @NUMROWS int,
           @nullcnt int,
           @validcnt int,
           @insIDContainersCharacteristics integer,
           @errno   int,
           @errmsg  varchar(255)

  SELECT @NUMROWS = @@rowcount
  /* ERwin Builtin Trigger */
  /* Containers  ContainersCharacteristics on child update no action */
  /* ERWIN_RELATION:CHECKSUM="00018acf", PARENT_OWNER="", PARENT_TABLE="Containers"
    CHILD_OWNER="", CHILD_TABLE="ContainersCharacteristics"
    P2C_VERB_PHRASE="", C2P_VERB_PHRASE="", 
    FK_CONSTRAINT="R_19", FK_COLUMNS="IDContainers" */
  IF
    /* %ChildFK(" OR",UPDATE) */
    UPDATE(IDContainers)
  BEGIN
    SELECT @nullcnt = 0
    SELECT @validcnt = count(*)
      FROM inserted,Containers
        WHERE
          /* %JoinFKPK(inserted,Containers) */
          inserted.IDContainers = Containers.IDContainers
    /* %NotnullFK(inserted," IS NULL","select @nullcnt = count(*) from inserted where"," AND") */
    select @nullcnt = count(*) from inserted where
      inserted.IDContainers IS NULL
    IF @validcnt + @nullcnt != @NUMROWS
    BEGIN
      SELECT @errno  = 30007,
             @errmsg = 'Cannot update ContainersCharacteristics because Containers does not exist.'
      GOTO ERROR
    END
  END


  /* ERwin Builtin Trigger */
  RETURN
ERROR:
    raiserror (@errmsg, -1, -1)
    rollback transaction
END

go




CREATE TRIGGER tD_ContainersForCargosAttributes ON ContainersForCargosAttributes FOR DELETE AS
/* ERwin Builtin Trigger */
/* DELETE trigger on ContainersForCargosAttributes */
BEGIN
  DECLARE  @errno   int,
           @errmsg  varchar(255)
    /* ERwin Builtin Trigger */
    /* Containers  ContainersForCargosAttributes on child delete no action */
    /* ERWIN_RELATION:CHECKSUM="00031c21", PARENT_OWNER="", PARENT_TABLE="Containers"
    CHILD_OWNER="", CHILD_TABLE="ContainersForCargosAttributes"
    P2C_VERB_PHRASE="", C2P_VERB_PHRASE="", 
    FK_CONSTRAINT="R_7", FK_COLUMNS="IDContainers" */
    IF EXISTS (SELECT * FROM deleted,Containers
      WHERE
        /* %JoinFKPK(deleted,Containers," = "," AND") */
        deleted.IDContainers = Containers.IDContainers AND
        NOT EXISTS (
          SELECT * FROM ContainersForCargosAttributes
          WHERE
            /* %JoinFKPK(ContainersForCargosAttributes,Containers," = "," AND") */
            ContainersForCargosAttributes.IDContainers = Containers.IDContainers
        )
    )
    BEGIN
      SELECT @errno  = 30010,
             @errmsg = 'Cannot delete last ContainersForCargosAttributes because Containers exists.'
      GOTO ERROR
    END

    /* ERwin Builtin Trigger */
    /* AttributesForCargos  ContainersForCargosAttributes on child delete no action */
    /* ERWIN_RELATION:CHECKSUM="00000000", PARENT_OWNER="", PARENT_TABLE="AttributesForCargos"
    CHILD_OWNER="", CHILD_TABLE="ContainersForCargosAttributes"
    P2C_VERB_PHRASE="", C2P_VERB_PHRASE="", 
    FK_CONSTRAINT="R_8", FK_COLUMNS="IDAttributesForCargos" */
    IF EXISTS (SELECT * FROM deleted,AttributesForCargos
      WHERE
        /* %JoinFKPK(deleted,AttributesForCargos," = "," AND") */
        deleted.IDAttributesForCargos = AttributesForCargos.IDAttributesForCargos AND
        NOT EXISTS (
          SELECT * FROM ContainersForCargosAttributes
          WHERE
            /* %JoinFKPK(ContainersForCargosAttributes,AttributesForCargos," = "," AND") */
            ContainersForCargosAttributes.IDAttributesForCargos = AttributesForCargos.IDAttributesForCargos
        )
    )
    BEGIN
      SELECT @errno  = 30010,
             @errmsg = 'Cannot delete last ContainersForCargosAttributes because AttributesForCargos exists.'
      GOTO ERROR
    END


    /* ERwin Builtin Trigger */
    RETURN
ERROR:
    raiserror (@errmsg, -1, -1)
    rollback transaction
END

go


CREATE TRIGGER tU_ContainersForCargosAttributes ON ContainersForCargosAttributes FOR UPDATE AS
/* ERwin Builtin Trigger */
/* UPDATE trigger on ContainersForCargosAttributes */
BEGIN
  DECLARE  @NUMROWS int,
           @nullcnt int,
           @validcnt int,
           @insIDContainers integer, 
           @insIDAttributesForCargos integer,
           @errno   int,
           @errmsg  varchar(255)

  SELECT @NUMROWS = @@rowcount
  /* ERwin Builtin Trigger */
  /* Containers  ContainersForCargosAttributes on child update no action */
  /* ERWIN_RELATION:CHECKSUM="00031615", PARENT_OWNER="", PARENT_TABLE="Containers"
    CHILD_OWNER="", CHILD_TABLE="ContainersForCargosAttributes"
    P2C_VERB_PHRASE="", C2P_VERB_PHRASE="", 
    FK_CONSTRAINT="R_7", FK_COLUMNS="IDContainers" */
  IF
    /* %ChildFK(" OR",UPDATE) */
    UPDATE(IDContainers)
  BEGIN
    SELECT @nullcnt = 0
    SELECT @validcnt = count(*)
      FROM inserted,Containers
        WHERE
          /* %JoinFKPK(inserted,Containers) */
          inserted.IDContainers = Containers.IDContainers
    /* %NotnullFK(inserted," IS NULL","select @nullcnt = count(*) from inserted where"," AND") */
    
    IF @validcnt + @nullcnt != @NUMROWS
    BEGIN
      SELECT @errno  = 30007,
             @errmsg = 'Cannot update ContainersForCargosAttributes because Containers does not exist.'
      GOTO ERROR
    END
  END

  /* ERwin Builtin Trigger */
  /* AttributesForCargos  ContainersForCargosAttributes on child update no action */
  /* ERWIN_RELATION:CHECKSUM="00000000", PARENT_OWNER="", PARENT_TABLE="AttributesForCargos"
    CHILD_OWNER="", CHILD_TABLE="ContainersForCargosAttributes"
    P2C_VERB_PHRASE="", C2P_VERB_PHRASE="", 
    FK_CONSTRAINT="R_8", FK_COLUMNS="IDAttributesForCargos" */
  IF
    /* %ChildFK(" OR",UPDATE) */
    UPDATE(IDAttributesForCargos)
  BEGIN
    SELECT @nullcnt = 0
    SELECT @validcnt = count(*)
      FROM inserted,AttributesForCargos
        WHERE
          /* %JoinFKPK(inserted,AttributesForCargos) */
          inserted.IDAttributesForCargos = AttributesForCargos.IDAttributesForCargos
    /* %NotnullFK(inserted," IS NULL","select @nullcnt = count(*) from inserted where"," AND") */
    
    IF @validcnt + @nullcnt != @NUMROWS
    BEGIN
      SELECT @errno  = 30007,
             @errmsg = 'Cannot update ContainersForCargosAttributes because AttributesForCargos does not exist.'
      GOTO ERROR
    END
  END


  /* ERwin Builtin Trigger */
  RETURN
ERROR:
    raiserror (@errmsg, -1, -1)
    rollback transaction
END

go




CREATE TRIGGER tD_FlightsSchedule ON FlightsSchedule FOR DELETE AS
/* ERwin Builtin Trigger */
/* DELETE trigger on FlightsSchedule */
BEGIN
  DECLARE  @errno   int,
           @errmsg  varchar(255)
    /* ERwin Builtin Trigger */
    /* FlightsSchedule  StatusesFligths on parent delete no action */
    /* ERWIN_RELATION:CHECKSUM="0004dd48", PARENT_OWNER="", PARENT_TABLE="FlightsSchedule"
    CHILD_OWNER="", CHILD_TABLE="StatusesFligths"
    P2C_VERB_PHRASE="", C2P_VERB_PHRASE="", 
    FK_CONSTRAINT="R_34", FK_COLUMNS="DateTimeOfFlight""IDShips" */
    IF EXISTS (
      SELECT * FROM deleted,StatusesFligths
      WHERE
        /*  %JoinFKPK(StatusesFligths,deleted," = "," AND") */
        StatusesFligths.DateTimeOfFlight = deleted.DateTimeOfFlight AND
        StatusesFligths.IDShips = deleted.IDShips
    )
    BEGIN
      SELECT @errno  = 30001,
             @errmsg = 'Cannot delete FlightsSchedule because StatusesFligths exists.'
      GOTO ERROR
    END

    /* ERwin Builtin Trigger */
    /* FlightsSchedule  OrdersOnFligths on parent delete no action */
    /* ERWIN_RELATION:CHECKSUM="00000000", PARENT_OWNER="", PARENT_TABLE="FlightsSchedule"
    CHILD_OWNER="", CHILD_TABLE="OrdersOnFligths"
    P2C_VERB_PHRASE="", C2P_VERB_PHRASE="", 
    FK_CONSTRAINT="R_37", FK_COLUMNS="DateTimeOfFlight""IDShips" */
    IF EXISTS (
      SELECT * FROM deleted,OrdersOnFligths
      WHERE
        /*  %JoinFKPK(OrdersOnFligths,deleted," = "," AND") */
        OrdersOnFligths.DateTimeOfFlight = deleted.DateTimeOfFlight AND
        OrdersOnFligths.IDShips = deleted.IDShips
    )
    BEGIN
      SELECT @errno  = 30001,
             @errmsg = 'Cannot delete FlightsSchedule because OrdersOnFligths exists.'
      GOTO ERROR
    END

    /* ERwin Builtin Trigger */
    /* TypesOfFlights  FlightsSchedule on child delete no action */
    /* ERWIN_RELATION:CHECKSUM="00000000", PARENT_OWNER="", PARENT_TABLE="TypesOfFlights"
    CHILD_OWNER="", CHILD_TABLE="FlightsSchedule"
    P2C_VERB_PHRASE="", C2P_VERB_PHRASE="", 
    FK_CONSTRAINT="R_14", FK_COLUMNS="IDTypesOfFlights" */
    IF EXISTS (SELECT * FROM deleted,TypesOfFlights
      WHERE
        /* %JoinFKPK(deleted,TypesOfFlights," = "," AND") */
        deleted.IDTypesOfFlights = TypesOfFlights.IDTypesOfFlights AND
        NOT EXISTS (
          SELECT * FROM FlightsSchedule
          WHERE
            /* %JoinFKPK(FlightsSchedule,TypesOfFlights," = "," AND") */
            FlightsSchedule.IDTypesOfFlights = TypesOfFlights.IDTypesOfFlights
        )
    )
    BEGIN
      SELECT @errno  = 30010,
             @errmsg = 'Cannot delete last FlightsSchedule because TypesOfFlights exists.'
      GOTO ERROR
    END

    /* ERwin Builtin Trigger */
    /* Ships  FlightsSchedule on child delete no action */
    /* ERWIN_RELATION:CHECKSUM="00000000", PARENT_OWNER="", PARENT_TABLE="Ships"
    CHILD_OWNER="", CHILD_TABLE="FlightsSchedule"
    P2C_VERB_PHRASE="", C2P_VERB_PHRASE="", 
    FK_CONSTRAINT="R_15", FK_COLUMNS="IDShips" */
    IF EXISTS (SELECT * FROM deleted,Ships
      WHERE
        /* %JoinFKPK(deleted,Ships," = "," AND") */
        deleted.IDShips = Ships.IDShips AND
        NOT EXISTS (
          SELECT * FROM FlightsSchedule
          WHERE
            /* %JoinFKPK(FlightsSchedule,Ships," = "," AND") */
            FlightsSchedule.IDShips = Ships.IDShips
        )
    )
    BEGIN
      SELECT @errno  = 30010,
             @errmsg = 'Cannot delete last FlightsSchedule because Ships exists.'
      GOTO ERROR
    END


    /* ERwin Builtin Trigger */
    RETURN
ERROR:
    raiserror (@errmsg, -1, -1)
    rollback transaction
END

go


CREATE TRIGGER tU_FlightsSchedule ON FlightsSchedule FOR UPDATE AS
/* ERwin Builtin Trigger */
/* UPDATE trigger on FlightsSchedule */
BEGIN
  DECLARE  @NUMROWS int,
           @nullcnt int,
           @validcnt int,
           @insDateTimeOfFlight datetime, 
           @insIDShips integer,
           @errno   int,
           @errmsg  varchar(255)

  SELECT @NUMROWS = @@rowcount
  /* ERwin Builtin Trigger */
  /* FlightsSchedule  StatusesFligths on parent update no action */
  /* ERWIN_RELATION:CHECKSUM="000571ad", PARENT_OWNER="", PARENT_TABLE="FlightsSchedule"
    CHILD_OWNER="", CHILD_TABLE="StatusesFligths"
    P2C_VERB_PHRASE="", C2P_VERB_PHRASE="", 
    FK_CONSTRAINT="R_34", FK_COLUMNS="DateTimeOfFlight""IDShips" */
  IF
    /* %ParentPK(" OR",UPDATE) */
    UPDATE(DateTimeOfFlight) OR
    UPDATE(IDShips)
  BEGIN
    IF EXISTS (
      SELECT * FROM deleted,StatusesFligths
      WHERE
        /*  %JoinFKPK(StatusesFligths,deleted," = "," AND") */
        StatusesFligths.DateTimeOfFlight = deleted.DateTimeOfFlight AND
        StatusesFligths.IDShips = deleted.IDShips
    )
    BEGIN
      SELECT @errno  = 30005,
             @errmsg = 'Cannot update FlightsSchedule because StatusesFligths exists.'
      GOTO ERROR
    END
  END

  /* ERwin Builtin Trigger */
  /* FlightsSchedule  OrdersOnFligths on parent update no action */
  /* ERWIN_RELATION:CHECKSUM="00000000", PARENT_OWNER="", PARENT_TABLE="FlightsSchedule"
    CHILD_OWNER="", CHILD_TABLE="OrdersOnFligths"
    P2C_VERB_PHRASE="", C2P_VERB_PHRASE="", 
    FK_CONSTRAINT="R_37", FK_COLUMNS="DateTimeOfFlight""IDShips" */
  IF
    /* %ParentPK(" OR",UPDATE) */
    UPDATE(DateTimeOfFlight) OR
    UPDATE(IDShips)
  BEGIN
    IF EXISTS (
      SELECT * FROM deleted,OrdersOnFligths
      WHERE
        /*  %JoinFKPK(OrdersOnFligths,deleted," = "," AND") */
        OrdersOnFligths.DateTimeOfFlight = deleted.DateTimeOfFlight AND
        OrdersOnFligths.IDShips = deleted.IDShips
    )
    BEGIN
      SELECT @errno  = 30005,
             @errmsg = 'Cannot update FlightsSchedule because OrdersOnFligths exists.'
      GOTO ERROR
    END
  END

  /* ERwin Builtin Trigger */
  /* TypesOfFlights  FlightsSchedule on child update no action */
  /* ERWIN_RELATION:CHECKSUM="00000000", PARENT_OWNER="", PARENT_TABLE="TypesOfFlights"
    CHILD_OWNER="", CHILD_TABLE="FlightsSchedule"
    P2C_VERB_PHRASE="", C2P_VERB_PHRASE="", 
    FK_CONSTRAINT="R_14", FK_COLUMNS="IDTypesOfFlights" */
  IF
    /* %ChildFK(" OR",UPDATE) */
    UPDATE(IDTypesOfFlights)
  BEGIN
    SELECT @nullcnt = 0
    SELECT @validcnt = count(*)
      FROM inserted,TypesOfFlights
        WHERE
          /* %JoinFKPK(inserted,TypesOfFlights) */
          inserted.IDTypesOfFlights = TypesOfFlights.IDTypesOfFlights
    /* %NotnullFK(inserted," IS NULL","select @nullcnt = count(*) from inserted where"," AND") */
    select @nullcnt = count(*) from inserted where
      inserted.IDTypesOfFlights IS NULL
    IF @validcnt + @nullcnt != @NUMROWS
    BEGIN
      SELECT @errno  = 30007,
             @errmsg = 'Cannot update FlightsSchedule because TypesOfFlights does not exist.'
      GOTO ERROR
    END
  END

  /* ERwin Builtin Trigger */
  /* Ships  FlightsSchedule on child update no action */
  /* ERWIN_RELATION:CHECKSUM="00000000", PARENT_OWNER="", PARENT_TABLE="Ships"
    CHILD_OWNER="", CHILD_TABLE="FlightsSchedule"
    P2C_VERB_PHRASE="", C2P_VERB_PHRASE="", 
    FK_CONSTRAINT="R_15", FK_COLUMNS="IDShips" */
  IF
    /* %ChildFK(" OR",UPDATE) */
    UPDATE(IDShips)
  BEGIN
    SELECT @nullcnt = 0
    SELECT @validcnt = count(*)
      FROM inserted,Ships
        WHERE
          /* %JoinFKPK(inserted,Ships) */
          inserted.IDShips = Ships.IDShips
    /* %NotnullFK(inserted," IS NULL","select @nullcnt = count(*) from inserted where"," AND") */
    
    IF @validcnt + @nullcnt != @NUMROWS
    BEGIN
      SELECT @errno  = 30007,
             @errmsg = 'Cannot update FlightsSchedule because Ships does not exist.'
      GOTO ERROR
    END
  END


  /* ERwin Builtin Trigger */
  RETURN
ERROR:
    raiserror (@errmsg, -1, -1)
    rollback transaction
END

go




CREATE TRIGGER tD_Orders ON Orders FOR DELETE AS
/* ERwin Builtin Trigger */
/* DELETE trigger on Orders */
BEGIN
  DECLARE  @errno   int,
           @errmsg  varchar(255)
    /* ERwin Builtin Trigger */
    /* Orders  CargosInOrders on parent delete no action */
    /* ERWIN_RELATION:CHECKSUM="00034dd4", PARENT_OWNER="", PARENT_TABLE="Orders"
    CHILD_OWNER="", CHILD_TABLE="CargosInOrders"
    P2C_VERB_PHRASE="", C2P_VERB_PHRASE="", 
    FK_CONSTRAINT="R_21", FK_COLUMNS="IDOrder""IDClient" */
    IF EXISTS (
      SELECT * FROM deleted,CargosInOrders
      WHERE
        /*  %JoinFKPK(CargosInOrders,deleted," = "," AND") */
        CargosInOrders.IDOrder = deleted.IDOrder AND
        CargosInOrders.IDClient = deleted.IDClient
    )
    BEGIN
      SELECT @errno  = 30001,
             @errmsg = 'Cannot delete Orders because CargosInOrders exists.'
      GOTO ERROR
    END

    /* ERwin Builtin Trigger */
    /* Orders  OrdersOnFligths on parent delete no action */
    /* ERWIN_RELATION:CHECKSUM="00000000", PARENT_OWNER="", PARENT_TABLE="Orders"
    CHILD_OWNER="", CHILD_TABLE="OrdersOnFligths"
    P2C_VERB_PHRASE="", C2P_VERB_PHRASE="", 
    FK_CONSTRAINT="R_38", FK_COLUMNS="IDOrder""IDClient" */
    IF EXISTS (
      SELECT * FROM deleted,OrdersOnFligths
      WHERE
        /*  %JoinFKPK(OrdersOnFligths,deleted," = "," AND") */
        OrdersOnFligths.IDOrder = deleted.IDOrder AND
        OrdersOnFligths.IDClient = deleted.IDClient
    )
    BEGIN
      SELECT @errno  = 30001,
             @errmsg = 'Cannot delete Orders because OrdersOnFligths exists.'
      GOTO ERROR
    END

    /* ERwin Builtin Trigger */
    /* Clients  Orders on child delete no action */
    /* ERWIN_RELATION:CHECKSUM="00000000", PARENT_OWNER="", PARENT_TABLE="Clients"
    CHILD_OWNER="", CHILD_TABLE="Orders"
    P2C_VERB_PHRASE="", C2P_VERB_PHRASE="", 
    FK_CONSTRAINT="R_18", FK_COLUMNS="IDClient" */
    IF EXISTS (SELECT * FROM deleted,Clients
      WHERE
        /* %JoinFKPK(deleted,Clients," = "," AND") */
        deleted.IDClient = Clients.IDClient AND
        NOT EXISTS (
          SELECT * FROM Orders
          WHERE
            /* %JoinFKPK(Orders,Clients," = "," AND") */
            Orders.IDClient = Clients.IDClient
        )
    )
    BEGIN
      SELECT @errno  = 30010,
             @errmsg = 'Cannot delete last Orders because Clients exists.'
      GOTO ERROR
    END


    /* ERwin Builtin Trigger */
    RETURN
ERROR:
    raiserror (@errmsg, -1, -1)
    rollback transaction
END

go


CREATE TRIGGER tU_Orders ON Orders FOR UPDATE AS
/* ERwin Builtin Trigger */
/* UPDATE trigger on Orders */
BEGIN
  DECLARE  @NUMROWS int,
           @nullcnt int,
           @validcnt int,
           @insIDOrder integer, 
           @insIDClient integer,
           @errno   int,
           @errmsg  varchar(255)

  SELECT @NUMROWS = @@rowcount
  /* ERwin Builtin Trigger */
  /* Orders  CargosInOrders on parent update no action */
  /* ERWIN_RELATION:CHECKSUM="0003af2f", PARENT_OWNER="", PARENT_TABLE="Orders"
    CHILD_OWNER="", CHILD_TABLE="CargosInOrders"
    P2C_VERB_PHRASE="", C2P_VERB_PHRASE="", 
    FK_CONSTRAINT="R_21", FK_COLUMNS="IDOrder""IDClient" */
  IF
    /* %ParentPK(" OR",UPDATE) */
    UPDATE(IDOrder) OR
    UPDATE(IDClient)
  BEGIN
    IF EXISTS (
      SELECT * FROM deleted,CargosInOrders
      WHERE
        /*  %JoinFKPK(CargosInOrders,deleted," = "," AND") */
        CargosInOrders.IDOrder = deleted.IDOrder AND
        CargosInOrders.IDClient = deleted.IDClient
    )
    BEGIN
      SELECT @errno  = 30005,
             @errmsg = 'Cannot update Orders because CargosInOrders exists.'
      GOTO ERROR
    END
  END

  /* ERwin Builtin Trigger */
  /* Orders  OrdersOnFligths on parent update no action */
  /* ERWIN_RELATION:CHECKSUM="00000000", PARENT_OWNER="", PARENT_TABLE="Orders"
    CHILD_OWNER="", CHILD_TABLE="OrdersOnFligths"
    P2C_VERB_PHRASE="", C2P_VERB_PHRASE="", 
    FK_CONSTRAINT="R_38", FK_COLUMNS="IDOrder""IDClient" */
  IF
    /* %ParentPK(" OR",UPDATE) */
    UPDATE(IDOrder) OR
    UPDATE(IDClient)
  BEGIN
    IF EXISTS (
      SELECT * FROM deleted,OrdersOnFligths
      WHERE
        /*  %JoinFKPK(OrdersOnFligths,deleted," = "," AND") */
        OrdersOnFligths.IDOrder = deleted.IDOrder AND
        OrdersOnFligths.IDClient = deleted.IDClient
    )
    BEGIN
      SELECT @errno  = 30005,
             @errmsg = 'Cannot update Orders because OrdersOnFligths exists.'
      GOTO ERROR
    END
  END

  /* ERwin Builtin Trigger */
  /* Clients  Orders on child update no action */
  /* ERWIN_RELATION:CHECKSUM="00000000", PARENT_OWNER="", PARENT_TABLE="Clients"
    CHILD_OWNER="", CHILD_TABLE="Orders"
    P2C_VERB_PHRASE="", C2P_VERB_PHRASE="", 
    FK_CONSTRAINT="R_18", FK_COLUMNS="IDClient" */
  IF
    /* %ChildFK(" OR",UPDATE) */
    UPDATE(IDClient)
  BEGIN
    SELECT @nullcnt = 0
    SELECT @validcnt = count(*)
      FROM inserted,Clients
        WHERE
          /* %JoinFKPK(inserted,Clients) */
          inserted.IDClient = Clients.IDClient
    /* %NotnullFK(inserted," IS NULL","select @nullcnt = count(*) from inserted where"," AND") */
    
    IF @validcnt + @nullcnt != @NUMROWS
    BEGIN
      SELECT @errno  = 30007,
             @errmsg = 'Cannot update Orders because Clients does not exist.'
      GOTO ERROR
    END
  END


  /* ERwin Builtin Trigger */
  RETURN
ERROR:
    raiserror (@errmsg, -1, -1)
    rollback transaction
END

go




CREATE TRIGGER tD_OrdersOnFligths ON OrdersOnFligths FOR DELETE AS
/* ERwin Builtin Trigger */
/* DELETE trigger on OrdersOnFligths */
BEGIN
  DECLARE  @errno   int,
           @errmsg  varchar(255)
    /* ERwin Builtin Trigger */
    /* FlightsSchedule  OrdersOnFligths on child delete no action */
    /* ERWIN_RELATION:CHECKSUM="0002f928", PARENT_OWNER="", PARENT_TABLE="FlightsSchedule"
    CHILD_OWNER="", CHILD_TABLE="OrdersOnFligths"
    P2C_VERB_PHRASE="", C2P_VERB_PHRASE="", 
    FK_CONSTRAINT="R_37", FK_COLUMNS="DateTimeOfFlight""IDShips" */
    IF EXISTS (SELECT * FROM deleted,FlightsSchedule
      WHERE
        /* %JoinFKPK(deleted,FlightsSchedule," = "," AND") */
        deleted.DateTimeOfFlight = FlightsSchedule.DateTimeOfFlight AND
        deleted.IDShips = FlightsSchedule.IDShips AND
        NOT EXISTS (
          SELECT * FROM OrdersOnFligths
          WHERE
            /* %JoinFKPK(OrdersOnFligths,FlightsSchedule," = "," AND") */
            OrdersOnFligths.DateTimeOfFlight = FlightsSchedule.DateTimeOfFlight AND
            OrdersOnFligths.IDShips = FlightsSchedule.IDShips
        )
    )
    BEGIN
      SELECT @errno  = 30010,
             @errmsg = 'Cannot delete last OrdersOnFligths because FlightsSchedule exists.'
      GOTO ERROR
    END

    /* ERwin Builtin Trigger */
    /* Orders  OrdersOnFligths on child delete no action */
    /* ERWIN_RELATION:CHECKSUM="00000000", PARENT_OWNER="", PARENT_TABLE="Orders"
    CHILD_OWNER="", CHILD_TABLE="OrdersOnFligths"
    P2C_VERB_PHRASE="", C2P_VERB_PHRASE="", 
    FK_CONSTRAINT="R_38", FK_COLUMNS="IDOrder""IDClient" */
    IF EXISTS (SELECT * FROM deleted,Orders
      WHERE
        /* %JoinFKPK(deleted,Orders," = "," AND") */
        deleted.IDOrder = Orders.IDOrder AND
        deleted.IDClient = Orders.IDClient AND
        NOT EXISTS (
          SELECT * FROM OrdersOnFligths
          WHERE
            /* %JoinFKPK(OrdersOnFligths,Orders," = "," AND") */
            OrdersOnFligths.IDOrder = Orders.IDOrder AND
            OrdersOnFligths.IDClient = Orders.IDClient
        )
    )
    BEGIN
      SELECT @errno  = 30010,
             @errmsg = 'Cannot delete last OrdersOnFligths because Orders exists.'
      GOTO ERROR
    END


    /* ERwin Builtin Trigger */
    RETURN
ERROR:
    raiserror (@errmsg, -1, -1)
    rollback transaction
END

go


CREATE TRIGGER tU_OrdersOnFligths ON OrdersOnFligths FOR UPDATE AS
/* ERwin Builtin Trigger */
/* UPDATE trigger on OrdersOnFligths */
BEGIN
  DECLARE  @NUMROWS int,
           @nullcnt int,
           @validcnt int,
           @insDateTimeOfFlight datetime, 
           @insIDShips integer, 
           @insIDOrder integer, 
           @insIDClient integer,
           @errno   int,
           @errmsg  varchar(255)

  SELECT @NUMROWS = @@rowcount
  /* ERwin Builtin Trigger */
  /* FlightsSchedule  OrdersOnFligths on child update no action */
  /* ERWIN_RELATION:CHECKSUM="0002f67d", PARENT_OWNER="", PARENT_TABLE="FlightsSchedule"
    CHILD_OWNER="", CHILD_TABLE="OrdersOnFligths"
    P2C_VERB_PHRASE="", C2P_VERB_PHRASE="", 
    FK_CONSTRAINT="R_37", FK_COLUMNS="DateTimeOfFlight""IDShips" */
  IF
    /* %ChildFK(" OR",UPDATE) */
    UPDATE(DateTimeOfFlight) OR
    UPDATE(IDShips)
  BEGIN
    SELECT @nullcnt = 0
    SELECT @validcnt = count(*)
      FROM inserted,FlightsSchedule
        WHERE
          /* %JoinFKPK(inserted,FlightsSchedule) */
          inserted.DateTimeOfFlight = FlightsSchedule.DateTimeOfFlight and
          inserted.IDShips = FlightsSchedule.IDShips
    /* %NotnullFK(inserted," IS NULL","select @nullcnt = count(*) from inserted where"," AND") */
    
    IF @validcnt + @nullcnt != @NUMROWS
    BEGIN
      SELECT @errno  = 30007,
             @errmsg = 'Cannot update OrdersOnFligths because FlightsSchedule does not exist.'
      GOTO ERROR
    END
  END

  /* ERwin Builtin Trigger */
  /* Orders  OrdersOnFligths on child update no action */
  /* ERWIN_RELATION:CHECKSUM="00000000", PARENT_OWNER="", PARENT_TABLE="Orders"
    CHILD_OWNER="", CHILD_TABLE="OrdersOnFligths"
    P2C_VERB_PHRASE="", C2P_VERB_PHRASE="", 
    FK_CONSTRAINT="R_38", FK_COLUMNS="IDOrder""IDClient" */
  IF
    /* %ChildFK(" OR",UPDATE) */
    UPDATE(IDOrder) OR
    UPDATE(IDClient)
  BEGIN
    SELECT @nullcnt = 0
    SELECT @validcnt = count(*)
      FROM inserted,Orders
        WHERE
          /* %JoinFKPK(inserted,Orders) */
          inserted.IDOrder = Orders.IDOrder and
          inserted.IDClient = Orders.IDClient
    /* %NotnullFK(inserted," IS NULL","select @nullcnt = count(*) from inserted where"," AND") */
    
    IF @validcnt + @nullcnt != @NUMROWS
    BEGIN
      SELECT @errno  = 30007,
             @errmsg = 'Cannot update OrdersOnFligths because Orders does not exist.'
      GOTO ERROR
    END
  END


  /* ERwin Builtin Trigger */
  RETURN
ERROR:
    raiserror (@errmsg, -1, -1)
    rollback transaction
END

go




CREATE TRIGGER tD_Ships ON Ships FOR DELETE AS
/* ERwin Builtin Trigger */
/* DELETE trigger on Ships */
BEGIN
  DECLARE  @errno   int,
           @errmsg  varchar(255)
    /* ERwin Builtin Trigger */
    /* Ships  StatusesShips on parent delete no action */
    /* ERWIN_RELATION:CHECKSUM="00056ad9", PARENT_OWNER="", PARENT_TABLE="Ships"
    CHILD_OWNER="", CHILD_TABLE="StatusesShips"
    P2C_VERB_PHRASE="", C2P_VERB_PHRASE="", 
    FK_CONSTRAINT="R_2", FK_COLUMNS="IDShips" */
    IF EXISTS (
      SELECT * FROM deleted,StatusesShips
      WHERE
        /*  %JoinFKPK(StatusesShips,deleted," = "," AND") */
        StatusesShips.IDShips = deleted.IDShips
    )
    BEGIN
      SELECT @errno  = 30001,
             @errmsg = 'Cannot delete Ships because StatusesShips exists.'
      GOTO ERROR
    END

    /* ERwin Builtin Trigger */
    /* Ships  FlightsSchedule on parent delete no action */
    /* ERWIN_RELATION:CHECKSUM="00000000", PARENT_OWNER="", PARENT_TABLE="Ships"
    CHILD_OWNER="", CHILD_TABLE="FlightsSchedule"
    P2C_VERB_PHRASE="", C2P_VERB_PHRASE="", 
    FK_CONSTRAINT="R_15", FK_COLUMNS="IDShips" */
    IF EXISTS (
      SELECT * FROM deleted,FlightsSchedule
      WHERE
        /*  %JoinFKPK(FlightsSchedule,deleted," = "," AND") */
        FlightsSchedule.IDShips = deleted.IDShips
    )
    BEGIN
      SELECT @errno  = 30001,
             @errmsg = 'Cannot delete Ships because FlightsSchedule exists.'
      GOTO ERROR
    END

    /* ERwin Builtin Trigger */
    /* SizesShips  Ships on child delete no action */
    /* ERWIN_RELATION:CHECKSUM="00000000", PARENT_OWNER="", PARENT_TABLE="SizesShips"
    CHILD_OWNER="", CHILD_TABLE="Ships"
    P2C_VERB_PHRASE="", C2P_VERB_PHRASE="", 
    FK_CONSTRAINT="R_4", FK_COLUMNS="IDSizesShips" */
    IF EXISTS (SELECT * FROM deleted,SizesShips
      WHERE
        /* %JoinFKPK(deleted,SizesShips," = "," AND") */
        deleted.IDSizesShips = SizesShips.IDSizesShips AND
        NOT EXISTS (
          SELECT * FROM Ships
          WHERE
            /* %JoinFKPK(Ships,SizesShips," = "," AND") */
            Ships.IDSizesShips = SizesShips.IDSizesShips
        )
    )
    BEGIN
      SELECT @errno  = 30010,
             @errmsg = 'Cannot delete last Ships because SizesShips exists.'
      GOTO ERROR
    END

    /* ERwin Builtin Trigger */
    /* ClassesShips  Ships on child delete no action */
    /* ERWIN_RELATION:CHECKSUM="00000000", PARENT_OWNER="", PARENT_TABLE="ClassesShips"
    CHILD_OWNER="", CHILD_TABLE="Ships"
    P2C_VERB_PHRASE="", C2P_VERB_PHRASE="", 
    FK_CONSTRAINT="R_5", FK_COLUMNS="IDClassesShips" */
    IF EXISTS (SELECT * FROM deleted,ClassesShips
      WHERE
        /* %JoinFKPK(deleted,ClassesShips," = "," AND") */
        deleted.IDClassesShips = ClassesShips.IDClassesShips AND
        NOT EXISTS (
          SELECT * FROM Ships
          WHERE
            /* %JoinFKPK(Ships,ClassesShips," = "," AND") */
            Ships.IDClassesShips = ClassesShips.IDClassesShips
        )
    )
    BEGIN
      SELECT @errno  = 30010,
             @errmsg = 'Cannot delete last Ships because ClassesShips exists.'
      GOTO ERROR
    END

    /* ERwin Builtin Trigger */
    /* TypesShips  Ships on child delete no action */
    /* ERWIN_RELATION:CHECKSUM="00000000", PARENT_OWNER="", PARENT_TABLE="TypesShips"
    CHILD_OWNER="", CHILD_TABLE="Ships"
    P2C_VERB_PHRASE="", C2P_VERB_PHRASE="", 
    FK_CONSTRAINT="R_6", FK_COLUMNS="IDTypesShips" */
    IF EXISTS (SELECT * FROM deleted,TypesShips
      WHERE
        /* %JoinFKPK(deleted,TypesShips," = "," AND") */
        deleted.IDTypesShips = TypesShips.IDTypesShips AND
        NOT EXISTS (
          SELECT * FROM Ships
          WHERE
            /* %JoinFKPK(Ships,TypesShips," = "," AND") */
            Ships.IDTypesShips = TypesShips.IDTypesShips
        )
    )
    BEGIN
      SELECT @errno  = 30010,
             @errmsg = 'Cannot delete last Ships because TypesShips exists.'
      GOTO ERROR
    END


    /* ERwin Builtin Trigger */
    RETURN
ERROR:
    raiserror (@errmsg, -1, -1)
    rollback transaction
END

go


CREATE TRIGGER tU_Ships ON Ships FOR UPDATE AS
/* ERwin Builtin Trigger */
/* UPDATE trigger on Ships */
BEGIN
  DECLARE  @NUMROWS int,
           @nullcnt int,
           @validcnt int,
           @insIDShips integer,
           @errno   int,
           @errmsg  varchar(255)

  SELECT @NUMROWS = @@rowcount
  /* ERwin Builtin Trigger */
  /* Ships  StatusesShips on parent update no action */
  /* ERWIN_RELATION:CHECKSUM="000660bf", PARENT_OWNER="", PARENT_TABLE="Ships"
    CHILD_OWNER="", CHILD_TABLE="StatusesShips"
    P2C_VERB_PHRASE="", C2P_VERB_PHRASE="", 
    FK_CONSTRAINT="R_2", FK_COLUMNS="IDShips" */
  IF
    /* %ParentPK(" OR",UPDATE) */
    UPDATE(IDShips)
  BEGIN
    IF EXISTS (
      SELECT * FROM deleted,StatusesShips
      WHERE
        /*  %JoinFKPK(StatusesShips,deleted," = "," AND") */
        StatusesShips.IDShips = deleted.IDShips
    )
    BEGIN
      SELECT @errno  = 30005,
             @errmsg = 'Cannot update Ships because StatusesShips exists.'
      GOTO ERROR
    END
  END

  /* ERwin Builtin Trigger */
  /* Ships  FlightsSchedule on parent update no action */
  /* ERWIN_RELATION:CHECKSUM="00000000", PARENT_OWNER="", PARENT_TABLE="Ships"
    CHILD_OWNER="", CHILD_TABLE="FlightsSchedule"
    P2C_VERB_PHRASE="", C2P_VERB_PHRASE="", 
    FK_CONSTRAINT="R_15", FK_COLUMNS="IDShips" */
  IF
    /* %ParentPK(" OR",UPDATE) */
    UPDATE(IDShips)
  BEGIN
    IF EXISTS (
      SELECT * FROM deleted,FlightsSchedule
      WHERE
        /*  %JoinFKPK(FlightsSchedule,deleted," = "," AND") */
        FlightsSchedule.IDShips = deleted.IDShips
    )
    BEGIN
      SELECT @errno  = 30005,
             @errmsg = 'Cannot update Ships because FlightsSchedule exists.'
      GOTO ERROR
    END
  END

  /* ERwin Builtin Trigger */
  /* SizesShips  Ships on child update no action */
  /* ERWIN_RELATION:CHECKSUM="00000000", PARENT_OWNER="", PARENT_TABLE="SizesShips"
    CHILD_OWNER="", CHILD_TABLE="Ships"
    P2C_VERB_PHRASE="", C2P_VERB_PHRASE="", 
    FK_CONSTRAINT="R_4", FK_COLUMNS="IDSizesShips" */
  IF
    /* %ChildFK(" OR",UPDATE) */
    UPDATE(IDSizesShips)
  BEGIN
    SELECT @nullcnt = 0
    SELECT @validcnt = count(*)
      FROM inserted,SizesShips
        WHERE
          /* %JoinFKPK(inserted,SizesShips) */
          inserted.IDSizesShips = SizesShips.IDSizesShips
    /* %NotnullFK(inserted," IS NULL","select @nullcnt = count(*) from inserted where"," AND") */
    select @nullcnt = count(*) from inserted where
      inserted.IDSizesShips IS NULL
    IF @validcnt + @nullcnt != @NUMROWS
    BEGIN
      SELECT @errno  = 30007,
             @errmsg = 'Cannot update Ships because SizesShips does not exist.'
      GOTO ERROR
    END
  END

  /* ERwin Builtin Trigger */
  /* ClassesShips  Ships on child update no action */
  /* ERWIN_RELATION:CHECKSUM="00000000", PARENT_OWNER="", PARENT_TABLE="ClassesShips"
    CHILD_OWNER="", CHILD_TABLE="Ships"
    P2C_VERB_PHRASE="", C2P_VERB_PHRASE="", 
    FK_CONSTRAINT="R_5", FK_COLUMNS="IDClassesShips" */
  IF
    /* %ChildFK(" OR",UPDATE) */
    UPDATE(IDClassesShips)
  BEGIN
    SELECT @nullcnt = 0
    SELECT @validcnt = count(*)
      FROM inserted,ClassesShips
        WHERE
          /* %JoinFKPK(inserted,ClassesShips) */
          inserted.IDClassesShips = ClassesShips.IDClassesShips
    /* %NotnullFK(inserted," IS NULL","select @nullcnt = count(*) from inserted where"," AND") */
    select @nullcnt = count(*) from inserted where
      inserted.IDClassesShips IS NULL
    IF @validcnt + @nullcnt != @NUMROWS
    BEGIN
      SELECT @errno  = 30007,
             @errmsg = 'Cannot update Ships because ClassesShips does not exist.'
      GOTO ERROR
    END
  END

  /* ERwin Builtin Trigger */
  /* TypesShips  Ships on child update no action */
  /* ERWIN_RELATION:CHECKSUM="00000000", PARENT_OWNER="", PARENT_TABLE="TypesShips"
    CHILD_OWNER="", CHILD_TABLE="Ships"
    P2C_VERB_PHRASE="", C2P_VERB_PHRASE="", 
    FK_CONSTRAINT="R_6", FK_COLUMNS="IDTypesShips" */
  IF
    /* %ChildFK(" OR",UPDATE) */
    UPDATE(IDTypesShips)
  BEGIN
    SELECT @nullcnt = 0
    SELECT @validcnt = count(*)
      FROM inserted,TypesShips
        WHERE
          /* %JoinFKPK(inserted,TypesShips) */
          inserted.IDTypesShips = TypesShips.IDTypesShips
    /* %NotnullFK(inserted," IS NULL","select @nullcnt = count(*) from inserted where"," AND") */
    select @nullcnt = count(*) from inserted where
      inserted.IDTypesShips IS NULL
    IF @validcnt + @nullcnt != @NUMROWS
    BEGIN
      SELECT @errno  = 30007,
             @errmsg = 'Cannot update Ships because TypesShips does not exist.'
      GOTO ERROR
    END
  END


  /* ERwin Builtin Trigger */
  RETURN
ERROR:
    raiserror (@errmsg, -1, -1)
    rollback transaction
END

go




CREATE TRIGGER tD_SizesShips ON SizesShips FOR DELETE AS
/* ERwin Builtin Trigger */
/* DELETE trigger on SizesShips */
BEGIN
  DECLARE  @errno   int,
           @errmsg  varchar(255)
    /* ERwin Builtin Trigger */
    /* SizesShips  Ships on parent delete no action */
    /* ERWIN_RELATION:CHECKSUM="0000e451", PARENT_OWNER="", PARENT_TABLE="SizesShips"
    CHILD_OWNER="", CHILD_TABLE="Ships"
    P2C_VERB_PHRASE="", C2P_VERB_PHRASE="", 
    FK_CONSTRAINT="R_4", FK_COLUMNS="IDSizesShips" */
    IF EXISTS (
      SELECT * FROM deleted,Ships
      WHERE
        /*  %JoinFKPK(Ships,deleted," = "," AND") */
        Ships.IDSizesShips = deleted.IDSizesShips
    )
    BEGIN
      SELECT @errno  = 30001,
             @errmsg = 'Cannot delete SizesShips because Ships exists.'
      GOTO ERROR
    END


    /* ERwin Builtin Trigger */
    RETURN
ERROR:
    raiserror (@errmsg, -1, -1)
    rollback transaction
END

go


CREATE TRIGGER tU_SizesShips ON SizesShips FOR UPDATE AS
/* ERwin Builtin Trigger */
/* UPDATE trigger on SizesShips */
BEGIN
  DECLARE  @NUMROWS int,
           @nullcnt int,
           @validcnt int,
           @insIDSizesShips integer,
           @errno   int,
           @errmsg  varchar(255)

  SELECT @NUMROWS = @@rowcount
  /* ERwin Builtin Trigger */
  /* SizesShips  Ships on parent update no action */
  /* ERWIN_RELATION:CHECKSUM="000107c7", PARENT_OWNER="", PARENT_TABLE="SizesShips"
    CHILD_OWNER="", CHILD_TABLE="Ships"
    P2C_VERB_PHRASE="", C2P_VERB_PHRASE="", 
    FK_CONSTRAINT="R_4", FK_COLUMNS="IDSizesShips" */
  IF
    /* %ParentPK(" OR",UPDATE) */
    UPDATE(IDSizesShips)
  BEGIN
    IF EXISTS (
      SELECT * FROM deleted,Ships
      WHERE
        /*  %JoinFKPK(Ships,deleted," = "," AND") */
        Ships.IDSizesShips = deleted.IDSizesShips
    )
    BEGIN
      SELECT @errno  = 30005,
             @errmsg = 'Cannot update SizesShips because Ships exists.'
      GOTO ERROR
    END
  END


  /* ERwin Builtin Trigger */
  RETURN
ERROR:
    raiserror (@errmsg, -1, -1)
    rollback transaction
END

go




CREATE TRIGGER tD_StatusesFligths ON StatusesFligths FOR DELETE AS
/* ERwin Builtin Trigger */
/* DELETE trigger on StatusesFligths */
BEGIN
  DECLARE  @errno   int,
           @errmsg  varchar(255)
    /* ERwin Builtin Trigger */
    /* FlightsSchedule  StatusesFligths on child delete no action */
    /* ERWIN_RELATION:CHECKSUM="00031449", PARENT_OWNER="", PARENT_TABLE="FlightsSchedule"
    CHILD_OWNER="", CHILD_TABLE="StatusesFligths"
    P2C_VERB_PHRASE="", C2P_VERB_PHRASE="", 
    FK_CONSTRAINT="R_34", FK_COLUMNS="DateTimeOfFlight""IDShips" */
    IF EXISTS (SELECT * FROM deleted,FlightsSchedule
      WHERE
        /* %JoinFKPK(deleted,FlightsSchedule," = "," AND") */
        deleted.DateTimeOfFlight = FlightsSchedule.DateTimeOfFlight AND
        deleted.IDShips = FlightsSchedule.IDShips AND
        NOT EXISTS (
          SELECT * FROM StatusesFligths
          WHERE
            /* %JoinFKPK(StatusesFligths,FlightsSchedule," = "," AND") */
            StatusesFligths.DateTimeOfFlight = FlightsSchedule.DateTimeOfFlight AND
            StatusesFligths.IDShips = FlightsSchedule.IDShips
        )
    )
    BEGIN
      SELECT @errno  = 30010,
             @errmsg = 'Cannot delete last StatusesFligths because FlightsSchedule exists.'
      GOTO ERROR
    END

    /* ERwin Builtin Trigger */
    /* StatusesForFligths  StatusesFligths on child delete no action */
    /* ERWIN_RELATION:CHECKSUM="00000000", PARENT_OWNER="", PARENT_TABLE="StatusesForFligths"
    CHILD_OWNER="", CHILD_TABLE="StatusesFligths"
    P2C_VERB_PHRASE="", C2P_VERB_PHRASE="", 
    FK_CONSTRAINT="R_41", FK_COLUMNS="IDStatusesForFligths" */
    IF EXISTS (SELECT * FROM deleted,StatusesForFligths
      WHERE
        /* %JoinFKPK(deleted,StatusesForFligths," = "," AND") */
        deleted.IDStatusesForFligths = StatusesForFligths.IDStatusesForFligths AND
        NOT EXISTS (
          SELECT * FROM StatusesFligths
          WHERE
            /* %JoinFKPK(StatusesFligths,StatusesForFligths," = "," AND") */
            StatusesFligths.IDStatusesForFligths = StatusesForFligths.IDStatusesForFligths
        )
    )
    BEGIN
      SELECT @errno  = 30010,
             @errmsg = 'Cannot delete last StatusesFligths because StatusesForFligths exists.'
      GOTO ERROR
    END


    /* ERwin Builtin Trigger */
    RETURN
ERROR:
    raiserror (@errmsg, -1, -1)
    rollback transaction
END

go


CREATE TRIGGER tU_StatusesFligths ON StatusesFligths FOR UPDATE AS
/* ERwin Builtin Trigger */
/* UPDATE trigger on StatusesFligths */
BEGIN
  DECLARE  @NUMROWS int,
           @nullcnt int,
           @validcnt int,
           @insDateTimeStatusWasSet datetime, 
           @insDateTimeOfFlight datetime, 
           @insIDShips integer, 
           @insIDStatusesForFligths integer,
           @errno   int,
           @errmsg  varchar(255)

  SELECT @NUMROWS = @@rowcount
  /* ERwin Builtin Trigger */
  /* FlightsSchedule  StatusesFligths on child update no action */
  /* ERWIN_RELATION:CHECKSUM="0003181e", PARENT_OWNER="", PARENT_TABLE="FlightsSchedule"
    CHILD_OWNER="", CHILD_TABLE="StatusesFligths"
    P2C_VERB_PHRASE="", C2P_VERB_PHRASE="", 
    FK_CONSTRAINT="R_34", FK_COLUMNS="DateTimeOfFlight""IDShips" */
  IF
    /* %ChildFK(" OR",UPDATE) */
    UPDATE(DateTimeOfFlight) OR
    UPDATE(IDShips)
  BEGIN
    SELECT @nullcnt = 0
    SELECT @validcnt = count(*)
      FROM inserted,FlightsSchedule
        WHERE
          /* %JoinFKPK(inserted,FlightsSchedule) */
          inserted.DateTimeOfFlight = FlightsSchedule.DateTimeOfFlight and
          inserted.IDShips = FlightsSchedule.IDShips
    /* %NotnullFK(inserted," IS NULL","select @nullcnt = count(*) from inserted where"," AND") */
    
    IF @validcnt + @nullcnt != @NUMROWS
    BEGIN
      SELECT @errno  = 30007,
             @errmsg = 'Cannot update StatusesFligths because FlightsSchedule does not exist.'
      GOTO ERROR
    END
  END

  /* ERwin Builtin Trigger */
  /* StatusesForFligths  StatusesFligths on child update no action */
  /* ERWIN_RELATION:CHECKSUM="00000000", PARENT_OWNER="", PARENT_TABLE="StatusesForFligths"
    CHILD_OWNER="", CHILD_TABLE="StatusesFligths"
    P2C_VERB_PHRASE="", C2P_VERB_PHRASE="", 
    FK_CONSTRAINT="R_41", FK_COLUMNS="IDStatusesForFligths" */
  IF
    /* %ChildFK(" OR",UPDATE) */
    UPDATE(IDStatusesForFligths)
  BEGIN
    SELECT @nullcnt = 0
    SELECT @validcnt = count(*)
      FROM inserted,StatusesForFligths
        WHERE
          /* %JoinFKPK(inserted,StatusesForFligths) */
          inserted.IDStatusesForFligths = StatusesForFligths.IDStatusesForFligths
    /* %NotnullFK(inserted," IS NULL","select @nullcnt = count(*) from inserted where"," AND") */
    
    IF @validcnt + @nullcnt != @NUMROWS
    BEGIN
      SELECT @errno  = 30007,
             @errmsg = 'Cannot update StatusesFligths because StatusesForFligths does not exist.'
      GOTO ERROR
    END
  END


  /* ERwin Builtin Trigger */
  RETURN
ERROR:
    raiserror (@errmsg, -1, -1)
    rollback transaction
END

go




CREATE TRIGGER tD_StatusesForFligths ON StatusesForFligths FOR DELETE AS
/* ERwin Builtin Trigger */
/* DELETE trigger on StatusesForFligths */
BEGIN
  DECLARE  @errno   int,
           @errmsg  varchar(255)
    /* ERwin Builtin Trigger */
    /* StatusesForFligths  StatusesFligths on parent delete no action */
    /* ERWIN_RELATION:CHECKSUM="000119c7", PARENT_OWNER="", PARENT_TABLE="StatusesForFligths"
    CHILD_OWNER="", CHILD_TABLE="StatusesFligths"
    P2C_VERB_PHRASE="", C2P_VERB_PHRASE="", 
    FK_CONSTRAINT="R_41", FK_COLUMNS="IDStatusesForFligths" */
    IF EXISTS (
      SELECT * FROM deleted,StatusesFligths
      WHERE
        /*  %JoinFKPK(StatusesFligths,deleted," = "," AND") */
        StatusesFligths.IDStatusesForFligths = deleted.IDStatusesForFligths
    )
    BEGIN
      SELECT @errno  = 30001,
             @errmsg = 'Cannot delete StatusesForFligths because StatusesFligths exists.'
      GOTO ERROR
    END


    /* ERwin Builtin Trigger */
    RETURN
ERROR:
    raiserror (@errmsg, -1, -1)
    rollback transaction
END

go


CREATE TRIGGER tU_StatusesForFligths ON StatusesForFligths FOR UPDATE AS
/* ERwin Builtin Trigger */
/* UPDATE trigger on StatusesForFligths */
BEGIN
  DECLARE  @NUMROWS int,
           @nullcnt int,
           @validcnt int,
           @insIDStatusesForFligths integer,
           @errno   int,
           @errmsg  varchar(255)

  SELECT @NUMROWS = @@rowcount
  /* ERwin Builtin Trigger */
  /* StatusesForFligths  StatusesFligths on parent update no action */
  /* ERWIN_RELATION:CHECKSUM="00013a73", PARENT_OWNER="", PARENT_TABLE="StatusesForFligths"
    CHILD_OWNER="", CHILD_TABLE="StatusesFligths"
    P2C_VERB_PHRASE="", C2P_VERB_PHRASE="", 
    FK_CONSTRAINT="R_41", FK_COLUMNS="IDStatusesForFligths" */
  IF
    /* %ParentPK(" OR",UPDATE) */
    UPDATE(IDStatusesForFligths)
  BEGIN
    IF EXISTS (
      SELECT * FROM deleted,StatusesFligths
      WHERE
        /*  %JoinFKPK(StatusesFligths,deleted," = "," AND") */
        StatusesFligths.IDStatusesForFligths = deleted.IDStatusesForFligths
    )
    BEGIN
      SELECT @errno  = 30005,
             @errmsg = 'Cannot update StatusesForFligths because StatusesFligths exists.'
      GOTO ERROR
    END
  END


  /* ERwin Builtin Trigger */
  RETURN
ERROR:
    raiserror (@errmsg, -1, -1)
    rollback transaction
END

go




CREATE TRIGGER tD_StatusesForShips ON StatusesForShips FOR DELETE AS
/* ERwin Builtin Trigger */
/* DELETE trigger on StatusesForShips */
BEGIN
  DECLARE  @errno   int,
           @errmsg  varchar(255)
    /* ERwin Builtin Trigger */
    /* StatusesForShips  StatusesShips on parent delete no action */
    /* ERWIN_RELATION:CHECKSUM="0001144c", PARENT_OWNER="", PARENT_TABLE="StatusesForShips"
    CHILD_OWNER="", CHILD_TABLE="StatusesShips"
    P2C_VERB_PHRASE="", C2P_VERB_PHRASE="", 
    FK_CONSTRAINT="R_40", FK_COLUMNS="IDStatusesForShips" */
    IF EXISTS (
      SELECT * FROM deleted,StatusesShips
      WHERE
        /*  %JoinFKPK(StatusesShips,deleted," = "," AND") */
        StatusesShips.IDStatusesForShips = deleted.IDStatusesForShips
    )
    BEGIN
      SELECT @errno  = 30001,
             @errmsg = 'Cannot delete StatusesForShips because StatusesShips exists.'
      GOTO ERROR
    END


    /* ERwin Builtin Trigger */
    RETURN
ERROR:
    raiserror (@errmsg, -1, -1)
    rollback transaction
END

go


CREATE TRIGGER tU_StatusesForShips ON StatusesForShips FOR UPDATE AS
/* ERwin Builtin Trigger */
/* UPDATE trigger on StatusesForShips */
BEGIN
  DECLARE  @NUMROWS int,
           @nullcnt int,
           @validcnt int,
           @insIDStatusesForShips integer,
           @errno   int,
           @errmsg  varchar(255)

  SELECT @NUMROWS = @@rowcount
  /* ERwin Builtin Trigger */
  /* StatusesForShips  StatusesShips on parent update no action */
  /* ERWIN_RELATION:CHECKSUM="000125f0", PARENT_OWNER="", PARENT_TABLE="StatusesForShips"
    CHILD_OWNER="", CHILD_TABLE="StatusesShips"
    P2C_VERB_PHRASE="", C2P_VERB_PHRASE="", 
    FK_CONSTRAINT="R_40", FK_COLUMNS="IDStatusesForShips" */
  IF
    /* %ParentPK(" OR",UPDATE) */
    UPDATE(IDStatusesForShips)
  BEGIN
    IF EXISTS (
      SELECT * FROM deleted,StatusesShips
      WHERE
        /*  %JoinFKPK(StatusesShips,deleted," = "," AND") */
        StatusesShips.IDStatusesForShips = deleted.IDStatusesForShips
    )
    BEGIN
      SELECT @errno  = 30005,
             @errmsg = 'Cannot update StatusesForShips because StatusesShips exists.'
      GOTO ERROR
    END
  END


  /* ERwin Builtin Trigger */
  RETURN
ERROR:
    raiserror (@errmsg, -1, -1)
    rollback transaction
END

go




CREATE TRIGGER tD_StatusesShips ON StatusesShips FOR DELETE AS
/* ERwin Builtin Trigger */
/* DELETE trigger on StatusesShips */
BEGIN
  DECLARE  @errno   int,
           @errmsg  varchar(255)
    /* ERwin Builtin Trigger */
    /* Ships  StatusesShips on child delete no action */
    /* ERWIN_RELATION:CHECKSUM="0002a318", PARENT_OWNER="", PARENT_TABLE="Ships"
    CHILD_OWNER="", CHILD_TABLE="StatusesShips"
    P2C_VERB_PHRASE="", C2P_VERB_PHRASE="", 
    FK_CONSTRAINT="R_2", FK_COLUMNS="IDShips" */
    IF EXISTS (SELECT * FROM deleted,Ships
      WHERE
        /* %JoinFKPK(deleted,Ships," = "," AND") */
        deleted.IDShips = Ships.IDShips AND
        NOT EXISTS (
          SELECT * FROM StatusesShips
          WHERE
            /* %JoinFKPK(StatusesShips,Ships," = "," AND") */
            StatusesShips.IDShips = Ships.IDShips
        )
    )
    BEGIN
      SELECT @errno  = 30010,
             @errmsg = 'Cannot delete last StatusesShips because Ships exists.'
      GOTO ERROR
    END

    /* ERwin Builtin Trigger */
    /* StatusesForShips  StatusesShips on child delete no action */
    /* ERWIN_RELATION:CHECKSUM="00000000", PARENT_OWNER="", PARENT_TABLE="StatusesForShips"
    CHILD_OWNER="", CHILD_TABLE="StatusesShips"
    P2C_VERB_PHRASE="", C2P_VERB_PHRASE="", 
    FK_CONSTRAINT="R_40", FK_COLUMNS="IDStatusesForShips" */
    IF EXISTS (SELECT * FROM deleted,StatusesForShips
      WHERE
        /* %JoinFKPK(deleted,StatusesForShips," = "," AND") */
        deleted.IDStatusesForShips = StatusesForShips.IDStatusesForShips AND
        NOT EXISTS (
          SELECT * FROM StatusesShips
          WHERE
            /* %JoinFKPK(StatusesShips,StatusesForShips," = "," AND") */
            StatusesShips.IDStatusesForShips = StatusesForShips.IDStatusesForShips
        )
    )
    BEGIN
      SELECT @errno  = 30010,
             @errmsg = 'Cannot delete last StatusesShips because StatusesForShips exists.'
      GOTO ERROR
    END


    /* ERwin Builtin Trigger */
    RETURN
ERROR:
    raiserror (@errmsg, -1, -1)
    rollback transaction
END

go


CREATE TRIGGER tU_StatusesShips ON StatusesShips FOR UPDATE AS
/* ERwin Builtin Trigger */
/* UPDATE trigger on StatusesShips */
BEGIN
  DECLARE  @NUMROWS int,
           @nullcnt int,
           @validcnt int,
           @insIDShips integer, 
           @insDateTimeStatusWasSet datetime, 
           @insIDStatusesForShips integer,
           @errno   int,
           @errmsg  varchar(255)

  SELECT @NUMROWS = @@rowcount
  /* ERwin Builtin Trigger */
  /* Ships  StatusesShips on child update no action */
  /* ERWIN_RELATION:CHECKSUM="0002ba28", PARENT_OWNER="", PARENT_TABLE="Ships"
    CHILD_OWNER="", CHILD_TABLE="StatusesShips"
    P2C_VERB_PHRASE="", C2P_VERB_PHRASE="", 
    FK_CONSTRAINT="R_2", FK_COLUMNS="IDShips" */
  IF
    /* %ChildFK(" OR",UPDATE) */
    UPDATE(IDShips)
  BEGIN
    SELECT @nullcnt = 0
    SELECT @validcnt = count(*)
      FROM inserted,Ships
        WHERE
          /* %JoinFKPK(inserted,Ships) */
          inserted.IDShips = Ships.IDShips
    /* %NotnullFK(inserted," IS NULL","select @nullcnt = count(*) from inserted where"," AND") */
    
    IF @validcnt + @nullcnt != @NUMROWS
    BEGIN
      SELECT @errno  = 30007,
             @errmsg = 'Cannot update StatusesShips because Ships does not exist.'
      GOTO ERROR
    END
  END

  /* ERwin Builtin Trigger */
  /* StatusesForShips  StatusesShips on child update no action */
  /* ERWIN_RELATION:CHECKSUM="00000000", PARENT_OWNER="", PARENT_TABLE="StatusesForShips"
    CHILD_OWNER="", CHILD_TABLE="StatusesShips"
    P2C_VERB_PHRASE="", C2P_VERB_PHRASE="", 
    FK_CONSTRAINT="R_40", FK_COLUMNS="IDStatusesForShips" */
  IF
    /* %ChildFK(" OR",UPDATE) */
    UPDATE(IDStatusesForShips)
  BEGIN
    SELECT @nullcnt = 0
    SELECT @validcnt = count(*)
      FROM inserted,StatusesForShips
        WHERE
          /* %JoinFKPK(inserted,StatusesForShips) */
          inserted.IDStatusesForShips = StatusesForShips.IDStatusesForShips
    /* %NotnullFK(inserted," IS NULL","select @nullcnt = count(*) from inserted where"," AND") */
    
    IF @validcnt + @nullcnt != @NUMROWS
    BEGIN
      SELECT @errno  = 30007,
             @errmsg = 'Cannot update StatusesShips because StatusesForShips does not exist.'
      GOTO ERROR
    END
  END


  /* ERwin Builtin Trigger */
  RETURN
ERROR:
    raiserror (@errmsg, -1, -1)
    rollback transaction
END

go




CREATE TRIGGER tD_TypesOfFlights ON TypesOfFlights FOR DELETE AS
/* ERwin Builtin Trigger */
/* DELETE trigger on TypesOfFlights */
BEGIN
  DECLARE  @errno   int,
           @errmsg  varchar(255)
    /* ERwin Builtin Trigger */
    /* TypesOfFlights  FlightsSchedule on parent delete no action */
    /* ERWIN_RELATION:CHECKSUM="000107c0", PARENT_OWNER="", PARENT_TABLE="TypesOfFlights"
    CHILD_OWNER="", CHILD_TABLE="FlightsSchedule"
    P2C_VERB_PHRASE="", C2P_VERB_PHRASE="", 
    FK_CONSTRAINT="R_14", FK_COLUMNS="IDTypesOfFlights" */
    IF EXISTS (
      SELECT * FROM deleted,FlightsSchedule
      WHERE
        /*  %JoinFKPK(FlightsSchedule,deleted," = "," AND") */
        FlightsSchedule.IDTypesOfFlights = deleted.IDTypesOfFlights
    )
    BEGIN
      SELECT @errno  = 30001,
             @errmsg = 'Cannot delete TypesOfFlights because FlightsSchedule exists.'
      GOTO ERROR
    END


    /* ERwin Builtin Trigger */
    RETURN
ERROR:
    raiserror (@errmsg, -1, -1)
    rollback transaction
END

go


CREATE TRIGGER tU_TypesOfFlights ON TypesOfFlights FOR UPDATE AS
/* ERwin Builtin Trigger */
/* UPDATE trigger on TypesOfFlights */
BEGIN
  DECLARE  @NUMROWS int,
           @nullcnt int,
           @validcnt int,
           @insIDTypesOfFlights integer,
           @errno   int,
           @errmsg  varchar(255)

  SELECT @NUMROWS = @@rowcount
  /* ERwin Builtin Trigger */
  /* TypesOfFlights  FlightsSchedule on parent update no action */
  /* ERWIN_RELATION:CHECKSUM="00012400", PARENT_OWNER="", PARENT_TABLE="TypesOfFlights"
    CHILD_OWNER="", CHILD_TABLE="FlightsSchedule"
    P2C_VERB_PHRASE="", C2P_VERB_PHRASE="", 
    FK_CONSTRAINT="R_14", FK_COLUMNS="IDTypesOfFlights" */
  IF
    /* %ParentPK(" OR",UPDATE) */
    UPDATE(IDTypesOfFlights)
  BEGIN
    IF EXISTS (
      SELECT * FROM deleted,FlightsSchedule
      WHERE
        /*  %JoinFKPK(FlightsSchedule,deleted," = "," AND") */
        FlightsSchedule.IDTypesOfFlights = deleted.IDTypesOfFlights
    )
    BEGIN
      SELECT @errno  = 30005,
             @errmsg = 'Cannot update TypesOfFlights because FlightsSchedule exists.'
      GOTO ERROR
    END
  END


  /* ERwin Builtin Trigger */
  RETURN
ERROR:
    raiserror (@errmsg, -1, -1)
    rollback transaction
END

go




CREATE TRIGGER tD_TypesShips ON TypesShips FOR DELETE AS
/* ERwin Builtin Trigger */
/* DELETE trigger on TypesShips */
BEGIN
  DECLARE  @errno   int,
           @errmsg  varchar(255)
    /* ERwin Builtin Trigger */
    /* TypesShips  Ships on parent delete no action */
    /* ERWIN_RELATION:CHECKSUM="00022e57", PARENT_OWNER="", PARENT_TABLE="TypesShips"
    CHILD_OWNER="", CHILD_TABLE="Ships"
    P2C_VERB_PHRASE="", C2P_VERB_PHRASE="", 
    FK_CONSTRAINT="R_6", FK_COLUMNS="IDTypesShips" */
    IF EXISTS (
      SELECT * FROM deleted,Ships
      WHERE
        /*  %JoinFKPK(Ships,deleted," = "," AND") */
        Ships.IDTypesShips = deleted.IDTypesShips
    )
    BEGIN
      SELECT @errno  = 30001,
             @errmsg = 'Cannot delete TypesShips because Ships exists.'
      GOTO ERROR
    END

    /* ERwin Builtin Trigger */
    /* TypesShips  TypesShipsImplementCargoAttributes on parent delete no action */
    /* ERWIN_RELATION:CHECKSUM="00000000", PARENT_OWNER="", PARENT_TABLE="TypesShips"
    CHILD_OWNER="", CHILD_TABLE="TypesShipsImplementCargoAttributes"
    P2C_VERB_PHRASE="", C2P_VERB_PHRASE="", 
    FK_CONSTRAINT="R_11", FK_COLUMNS="IDTypesShips" */
    IF EXISTS (
      SELECT * FROM deleted,TypesShipsImplementCargoAttributes
      WHERE
        /*  %JoinFKPK(TypesShipsImplementCargoAttributes,deleted," = "," AND") */
        TypesShipsImplementCargoAttributes.IDTypesShips = deleted.IDTypesShips
    )
    BEGIN
      SELECT @errno  = 30001,
             @errmsg = 'Cannot delete TypesShips because TypesShipsImplementCargoAttributes exists.'
      GOTO ERROR
    END


    /* ERwin Builtin Trigger */
    RETURN
ERROR:
    raiserror (@errmsg, -1, -1)
    rollback transaction
END

go


CREATE TRIGGER tU_TypesShips ON TypesShips FOR UPDATE AS
/* ERwin Builtin Trigger */
/* UPDATE trigger on TypesShips */
BEGIN
  DECLARE  @NUMROWS int,
           @nullcnt int,
           @validcnt int,
           @insIDTypesShips integer,
           @errno   int,
           @errmsg  varchar(255)

  SELECT @NUMROWS = @@rowcount
  /* ERwin Builtin Trigger */
  /* TypesShips  Ships on parent update no action */
  /* ERWIN_RELATION:CHECKSUM="00026076", PARENT_OWNER="", PARENT_TABLE="TypesShips"
    CHILD_OWNER="", CHILD_TABLE="Ships"
    P2C_VERB_PHRASE="", C2P_VERB_PHRASE="", 
    FK_CONSTRAINT="R_6", FK_COLUMNS="IDTypesShips" */
  IF
    /* %ParentPK(" OR",UPDATE) */
    UPDATE(IDTypesShips)
  BEGIN
    IF EXISTS (
      SELECT * FROM deleted,Ships
      WHERE
        /*  %JoinFKPK(Ships,deleted," = "," AND") */
        Ships.IDTypesShips = deleted.IDTypesShips
    )
    BEGIN
      SELECT @errno  = 30005,
             @errmsg = 'Cannot update TypesShips because Ships exists.'
      GOTO ERROR
    END
  END

  /* ERwin Builtin Trigger */
  /* TypesShips  TypesShipsImplementCargoAttributes on parent update no action */
  /* ERWIN_RELATION:CHECKSUM="00000000", PARENT_OWNER="", PARENT_TABLE="TypesShips"
    CHILD_OWNER="", CHILD_TABLE="TypesShipsImplementCargoAttributes"
    P2C_VERB_PHRASE="", C2P_VERB_PHRASE="", 
    FK_CONSTRAINT="R_11", FK_COLUMNS="IDTypesShips" */
  IF
    /* %ParentPK(" OR",UPDATE) */
    UPDATE(IDTypesShips)
  BEGIN
    IF EXISTS (
      SELECT * FROM deleted,TypesShipsImplementCargoAttributes
      WHERE
        /*  %JoinFKPK(TypesShipsImplementCargoAttributes,deleted," = "," AND") */
        TypesShipsImplementCargoAttributes.IDTypesShips = deleted.IDTypesShips
    )
    BEGIN
      SELECT @errno  = 30005,
             @errmsg = 'Cannot update TypesShips because TypesShipsImplementCargoAttributes exists.'
      GOTO ERROR
    END
  END


  /* ERwin Builtin Trigger */
  RETURN
ERROR:
    raiserror (@errmsg, -1, -1)
    rollback transaction
END

go




CREATE TRIGGER tD_TypesShipsImplementCargoAttributes ON TypesShipsImplementCargoAttributes FOR DELETE AS
/* ERwin Builtin Trigger */
/* DELETE trigger on TypesShipsImplementCargoAttributes */
BEGIN
  DECLARE  @errno   int,
           @errmsg  varchar(255)
    /* ERwin Builtin Trigger */
    /* TypesShips  TypesShipsImplementCargoAttributes on child delete no action */
    /* ERWIN_RELATION:CHECKSUM="00033171", PARENT_OWNER="", PARENT_TABLE="TypesShips"
    CHILD_OWNER="", CHILD_TABLE="TypesShipsImplementCargoAttributes"
    P2C_VERB_PHRASE="", C2P_VERB_PHRASE="", 
    FK_CONSTRAINT="R_11", FK_COLUMNS="IDTypesShips" */
    IF EXISTS (SELECT * FROM deleted,TypesShips
      WHERE
        /* %JoinFKPK(deleted,TypesShips," = "," AND") */
        deleted.IDTypesShips = TypesShips.IDTypesShips AND
        NOT EXISTS (
          SELECT * FROM TypesShipsImplementCargoAttributes
          WHERE
            /* %JoinFKPK(TypesShipsImplementCargoAttributes,TypesShips," = "," AND") */
            TypesShipsImplementCargoAttributes.IDTypesShips = TypesShips.IDTypesShips
        )
    )
    BEGIN
      SELECT @errno  = 30010,
             @errmsg = 'Cannot delete last TypesShipsImplementCargoAttributes because TypesShips exists.'
      GOTO ERROR
    END

    /* ERwin Builtin Trigger */
    /* AttributesForCargos  TypesShipsImplementCargoAttributes on child delete no action */
    /* ERWIN_RELATION:CHECKSUM="00000000", PARENT_OWNER="", PARENT_TABLE="AttributesForCargos"
    CHILD_OWNER="", CHILD_TABLE="TypesShipsImplementCargoAttributes"
    P2C_VERB_PHRASE="", C2P_VERB_PHRASE="", 
    FK_CONSTRAINT="R_12", FK_COLUMNS="IDAttributesForCargos" */
    IF EXISTS (SELECT * FROM deleted,AttributesForCargos
      WHERE
        /* %JoinFKPK(deleted,AttributesForCargos," = "," AND") */
        deleted.IDAttributesForCargos = AttributesForCargos.IDAttributesForCargos AND
        NOT EXISTS (
          SELECT * FROM TypesShipsImplementCargoAttributes
          WHERE
            /* %JoinFKPK(TypesShipsImplementCargoAttributes,AttributesForCargos," = "," AND") */
            TypesShipsImplementCargoAttributes.IDAttributesForCargos = AttributesForCargos.IDAttributesForCargos
        )
    )
    BEGIN
      SELECT @errno  = 30010,
             @errmsg = 'Cannot delete last TypesShipsImplementCargoAttributes because AttributesForCargos exists.'
      GOTO ERROR
    END


    /* ERwin Builtin Trigger */
    RETURN
ERROR:
    raiserror (@errmsg, -1, -1)
    rollback transaction
END

go


CREATE TRIGGER tU_TypesShipsImplementCargoAttributes ON TypesShipsImplementCargoAttributes FOR UPDATE AS
/* ERwin Builtin Trigger */
/* UPDATE trigger on TypesShipsImplementCargoAttributes */
BEGIN
  DECLARE  @NUMROWS int,
           @nullcnt int,
           @validcnt int,
           @insIDTypesShips integer, 
           @insIDAttributesForCargos integer,
           @errno   int,
           @errmsg  varchar(255)

  SELECT @NUMROWS = @@rowcount
  /* ERwin Builtin Trigger */
  /* TypesShips  TypesShipsImplementCargoAttributes on child update no action */
  /* ERWIN_RELATION:CHECKSUM="0003210b", PARENT_OWNER="", PARENT_TABLE="TypesShips"
    CHILD_OWNER="", CHILD_TABLE="TypesShipsImplementCargoAttributes"
    P2C_VERB_PHRASE="", C2P_VERB_PHRASE="", 
    FK_CONSTRAINT="R_11", FK_COLUMNS="IDTypesShips" */
  IF
    /* %ChildFK(" OR",UPDATE) */
    UPDATE(IDTypesShips)
  BEGIN
    SELECT @nullcnt = 0
    SELECT @validcnt = count(*)
      FROM inserted,TypesShips
        WHERE
          /* %JoinFKPK(inserted,TypesShips) */
          inserted.IDTypesShips = TypesShips.IDTypesShips
    /* %NotnullFK(inserted," IS NULL","select @nullcnt = count(*) from inserted where"," AND") */
    
    IF @validcnt + @nullcnt != @NUMROWS
    BEGIN
      SELECT @errno  = 30007,
             @errmsg = 'Cannot update TypesShipsImplementCargoAttributes because TypesShips does not exist.'
      GOTO ERROR
    END
  END

  /* ERwin Builtin Trigger */
  /* AttributesForCargos  TypesShipsImplementCargoAttributes on child update no action */
  /* ERWIN_RELATION:CHECKSUM="00000000", PARENT_OWNER="", PARENT_TABLE="AttributesForCargos"
    CHILD_OWNER="", CHILD_TABLE="TypesShipsImplementCargoAttributes"
    P2C_VERB_PHRASE="", C2P_VERB_PHRASE="", 
    FK_CONSTRAINT="R_12", FK_COLUMNS="IDAttributesForCargos" */
  IF
    /* %ChildFK(" OR",UPDATE) */
    UPDATE(IDAttributesForCargos)
  BEGIN
    SELECT @nullcnt = 0
    SELECT @validcnt = count(*)
      FROM inserted,AttributesForCargos
        WHERE
          /* %JoinFKPK(inserted,AttributesForCargos) */
          inserted.IDAttributesForCargos = AttributesForCargos.IDAttributesForCargos
    /* %NotnullFK(inserted," IS NULL","select @nullcnt = count(*) from inserted where"," AND") */
    
    IF @validcnt + @nullcnt != @NUMROWS
    BEGIN
      SELECT @errno  = 30007,
             @errmsg = 'Cannot update TypesShipsImplementCargoAttributes because AttributesForCargos does not exist.'
      GOTO ERROR
    END
  END


  /* ERwin Builtin Trigger */
  RETURN
ERROR:
    raiserror (@errmsg, -1, -1)
    rollback transaction
END

go

