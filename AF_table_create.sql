CREATE SCHEMA AF;

CREATE TABLE AF.Asmuo (
    Nr 		  			INTEGER 		NOT NULL PRIMARY KEY 
			   		  					GENERATED ALWAYS AS IDENTITY (START WITH 10000),
    Vardas    			VARCHAR(32) 	NOT NULL,
	Pavarde   			VARCHAR(32) 	NOT NULL,
	Lytis 	  			VARCHAR(10) 	NOT NULL,
										CHECK (Lytis IN ('Vyras', 'Moteris')),
	Gim_data  			DATE     		NOT NULL CONSTRAINT GimimoMetai 
                            			CHECK(EXTRACT(YEAR FROM Gim_data) > 1920 AND EXTRACT(YEAR FROM Gim_data) < EXTRACT(YEAR FROM CURRENT_DATE) + 1),
	El_pastas 			CHAR(50),
	Tel_nr 	  			VARCHAR(15),
	Krastas   			VARCHAR(32),
	Aprasymas 			VARCHAR(500), 
    Gatve     			VARCHAR(30),
	Miestas   			VARCHAR(20),
	Namas     			VARCHAR(5),
	Butas     			VARCHAR(5),
	Registravimo_data 	TIMESTAMP 		NOT NULL 
										DEFAULT CURRENT_TIMESTAMP
);

CREATE TABLE AF.Nario_mokestis (
    Apmokejimo_nr 	INTEGER 		NOT NULL 
						    		GENERATED ALWAYS AS IDENTITY,
    Asmens_nr     	INTEGER 		NOT NULL,
    Suma 		   	DECIMAL(10, 2) 	NOT NULL,
	Apmokejimo_data TIMESTAMP 		NOT NULL 
							 		DEFAULT CURRENT_TIMESTAMP,

	CONSTRAINT IAsmeni FOREIGN KEY (Asmens_nr) REFERENCES AF.Asmuo ON DELETE RESTRICT ON UPDATE RESTRICT
);

CREATE TABLE AF.Vienetas (
    Nr 			 	INTEGER   		NOT NULL PRIMARY KEY 
			     		   			GENERATED ALWAYS AS IDENTITY,
	Pavadinimas  	VARCHAR(50)  	NOT NULL,
	Aprasymas 	 	VARCHAR(500),
    Adresas 	 	VARCHAR(50),
	Ikurimo_data 	DATE 			NOT NULL 
						   			DEFAULT CURRENT_DATE
);

CREATE TABLE AF.Renginys (
    Nr				INTEGER 		NOT NULL PRIMARY KEY 
									GENERATED ALWAYS AS IDENTITY,
	Pavadinimas    	VARCHAR(50)  	NOT NULL,
	Organizatorius 	VARCHAR(50)  	NOT NULL,
	Aprasymas 	   	VARCHAR(500),
    Vieta 		   	VARCHAR(50),
	Data_nuo       	TIMESTAMP		NOT NULL,
	Data_iki	   	TIMESTAMP 		NOT NULL 
							 		CHECK (Data_iki >= Data_nuo)
);

CREATE TABLE AF.Priklauso_vienetui (
    Nr 			INTEGER 	NOT NULL PRIMARY KEY 
							GENERATED ALWAYS AS IDENTITY,
    Asmens_nr 	INTEGER 	NOT NULL,
	Vieneto_nr 	INTEGER 	NOT NULL,
    Pareigybe 	VARCHAR(32) 	NOT NULL 
					   		CHECK (Pareigybe IN ('globėjas', 'narys'))
					   		DEFAULT 'narys',
	Data_nuo 	DATE 		NOT NULL,
	Data_iki 	DATE 		NOT NULL,
							CHECK (Data_iki >= Data_nuo),

	CONSTRAINT IAsmeni FOREIGN KEY (Asmens_nr) REFERENCES AF.Asmuo ON DELETE RESTRICT ON UPDATE RESTRICT,
	CONSTRAINT IVieneta FOREIGN KEY (Vieneto_nr) REFERENCES AF.Vienetas ON DELETE RESTRICT ON UPDATE RESTRICT
);

CREATE TABLE AF.Dalyvauja_renginyje (
    Nr 				INTEGER 	NOT NULL PRIMARY KEY 
								GENERATED ALWAYS AS IDENTITY,
    Renginio_nr 	INTEGER 	NOT NULL,
	Asmens_nr 		INTEGER 	NOT NULL,
    Pareigybe 		VARCHAR(32) 	NOT NULL 
					   			CHECK (Pareigybe IN ('dalyvis', 'vadovas', 'svečias', 'programos vadovas', 'vyriausias-vadovas', 'komendantas'))
					   			DEFAULT 'dalyvis',

	CONSTRAINT IAsmeni FOREIGN KEY (Asmens_nr) REFERENCES AF.Asmuo ON DELETE RESTRICT ON UPDATE RESTRICT,
	CONSTRAINT IVieneta FOREIGN KEY (Renginio_nr) REFERENCES AF.Renginys ON DELETE RESTRICT ON UPDATE RESTRICT
);

CREATE TABLE AF.Izodis (
    Nr 				INTEGER 		NOT NULL PRIMARY KEY 
						    		GENERATED ALWAYS AS IDENTITY,
    Asmens_nr     	INTEGER 		NOT NULL,
    Sajunga			VARCHAR(4)		NOT NULL
									CHECK (Sajunga IN ('JAS', 'MAS', 'SAS', 'ASS')),
	Izodzio_data 	DATE 			NOT NULL 
							 		DEFAULT CURRENT_DATE,
	Renginio_nr 	INTEGER, 		
	
	CONSTRAINT IAsmeni FOREIGN KEY (Asmens_nr) REFERENCES AF.Asmuo ON DELETE RESTRICT ON UPDATE RESTRICT,
	CONSTRAINT IRengini FOREIGN KEY (Renginio_nr) REFERENCES AF.Renginys ON DELETE RESTRICT ON UPDATE RESTRICT
);


