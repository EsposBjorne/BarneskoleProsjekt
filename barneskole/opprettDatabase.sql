CREATE SCHEMA IF NOT EXISTS `nes` DEFAULT CHARACTER SET utf8 ;
USE `nes` ;

CREATE TABLE IF NOT EXISTS `nes`.`brukertype` (
  `BrukertypeID` INT(10) NOT NULL AUTO_INCREMENT,
  `Beskrivelse` VARCHAR(10) NOT NULL,
  PRIMARY KEY (`BrukertypeID`))
ENGINE = InnoDB
AUTO_INCREMENT = 0;

CREATE TABLE IF NOT EXISTS `nes`.`bruker` (
  `BrukerID` INT(10) NOT NULL AUTO_INCREMENT,
  `Brukernavn` VARCHAR(20) NOT NULL,
  `Passord` VARCHAR(20) NOT NULL,
  `Fornavn` VARCHAR(45) NOT NULL,
  `Etternavn` VARCHAR(45) NOT NULL,
  `BrukertypeID` INT(10) NOT NULL,
  INDEX `TypeID_idx` (`BrukertypeID` ASC),
  PRIMARY KEY (`BrukerID`),
  UNIQUE INDEX `Brukernavn_UNIQUE` (`Brukernavn` ASC),
  CONSTRAINT `typeFK_brukertype`
    FOREIGN KEY (`BrukertypeID`)
    REFERENCES `nes`.`brukertype` (`BrukertypeID`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB
AUTO_INCREMENT = 0;

CREATE TABLE IF NOT EXISTS `nes`.`elev` (
  `FNummer` VARCHAR(11) NOT NULL,
  `Fornavn` VARCHAR(45) NOT NULL,
  `Etternavn` VARCHAR(45) NOT NULL,
  `Kjønn` VARCHAR(10) NOT NULL,
  `Aktiv` TINYINT(1) NOT NULL,
  PRIMARY KEY (`FNummer`))
ENGINE = InnoDB;

CREATE TABLE IF NOT EXISTS `nes`.`klasse` (
  `Betegnelse` VARCHAR(10) NOT NULL,
  `Skoleår` INT(10) NOT NULL,
  PRIMARY KEY (`Betegnelse`, `Skoleår`))
ENGINE = InnoDB;

CREATE TABLE IF NOT EXISTS `nes`.`test` (
  `TestID` INT(10) NOT NULL AUTO_INCREMENT,
  `Testnavn` VARCHAR(45) NOT NULL,
  `Fagnavn` VARCHAR(45) NOT NULL,
  PRIMARY KEY (`TestID`))
ENGINE = InnoDB
AUTO_INCREMENT = 0;


CREATE TABLE IF NOT EXISTS `nes`.`klassetest` (
  `Betegnelse` VARCHAR(10) NOT NULL,
  `Skoleår` INT(10) NOT NULL,
  `TestID` INT(10) NOT NULL,
  PRIMARY KEY (`Betegnelse`, `TestID`, `Skoleår`),
  INDEX `KlasseID_idx` (`Betegnelse` ASC, `Skoleår` ASC),
  CONSTRAINT `klasseFK_klasseID`
    FOREIGN KEY (`Betegnelse` , `Skoleår`)
    REFERENCES `nes`.`klasse` (`Betegnelse` , `Skoleår`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `testFK_test`
    FOREIGN KEY (`TestID`)
    REFERENCES `nes`.`test` (`TestID`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;

CREATE TABLE IF NOT EXISTS `nes`.`deltest` (
  `DeltestID` INT(10) NOT NULL AUTO_INCREMENT,
  `Deltestnavn` VARCHAR(45) NOT NULL,
  `Semester` VARCHAR(10) NOT NULL,
  `MaksPoeng` INT(5) NOT NULL,
  `Kritiskgrense` INT(5) NOT NULL,
  `TestID` INT(10) NOT NULL,
  PRIMARY KEY (`DeltestID`),
  INDEX `delprøve_prøve_idx` (`TestID` ASC),
  CONSTRAINT `delprøve_prøve`
    FOREIGN KEY (`TestID`)
    REFERENCES `nes`.`test` (`TestID`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB
AUTO_INCREMENT = 0;

CREATE TABLE IF NOT EXISTS `nes`.`resultat` (
  `FNummer` VARCHAR(11) NOT NULL,
  `DeltestID` INT(10) NOT NULL,
  `Betegnelse` VARCHAR(10) NOT NULL,
  `Skoleår` INT(10) NOT NULL,
  `Dato` DATE NOT NULL,
  `Poeng` INT(5) NOT NULL,
  `Kommentar` VARCHAR(1000) NULL,
  `BrukerID` INT(10) NOT NULL,
  INDEX `resulat_delprøve_idx` (`DeltestID` ASC),
  PRIMARY KEY (`FNummer`, `DeltestID`, `Betegnelse`, `Skoleår`, `Dato`),
  INDEX `resultat_klasse_idx` (`Betegnelse` ASC, `Skoleår` ASC),
  INDEX `resultat_bruker_idx` (`BrukerID` ASC),
  INDEX `resultat_elev_idx` (`FNummer` ASC),
  CONSTRAINT `resulat_deltest`
    FOREIGN KEY (`DeltestID`)
    REFERENCES `nes`.`deltest` (`DeltestID`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `resultat_klasse`
    FOREIGN KEY (`Betegnelse` , `Skoleår`)
    REFERENCES `nes`.`klasse` (`Betegnelse` , `Skoleår`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `resultat_bruker`
    FOREIGN KEY (`BrukerID`)
    REFERENCES `nes`.`bruker` (`BrukerID`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `resultat_elev`
    FOREIGN KEY (`FNummer`)
    REFERENCES `nes`.`elev` (`FNummer`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;

CREATE TABLE IF NOT EXISTS `nes`.`elevklasse` (
  `FNummer` VARCHAR(11) NOT NULL,
  `Betegnelse` VARCHAR(10) NOT NULL,
  `Skoleår` INT(10) NOT NULL,
  PRIMARY KEY (`FNummer`, `Betegnelse`, `Skoleår`),
  INDEX `elevklasse_klasse_idx` (`Betegnelse` ASC, `Skoleår` ASC),
  CONSTRAINT `elevklasse_klasse`
    FOREIGN KEY (`Betegnelse` , `Skoleår`)
    REFERENCES `nes`.`klasse` (`Betegnelse` , `Skoleår`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `elevklasse_elev`
    FOREIGN KEY (`FNummer`)
    REFERENCES `nes`.`elev` (`FNummer`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;

CREATE TABLE IF NOT EXISTS `nes`.`fil` (
  `FilID` INT(10) NOT NULL AUTO_INCREMENT,
  `Filnavn` VARCHAR(45) NOT NULL,
  `Fil` LONGBLOB NOT NULL,
  `Filtype` VARCHAR(10) NOT NULL,
  `TestID` INT(10) NOT NULL,
  PRIMARY KEY (`FilID`),
  INDEX `fil_test_idx` (`TestID` ASC),
  CONSTRAINT `fil_test`
    FOREIGN KEY (`TestID`)
    REFERENCES `nes`.`test` (`TestID`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB
AUTO_INCREMENT = 0;

INSERT IGNORE INTO `brukertype` VALUES (1,'Admin'),(2,'Bruker');
