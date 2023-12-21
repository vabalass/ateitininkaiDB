CREATE SCHEMA AF;

CREATE TABLE AF.Asmuo (
    Nr 		  			INTEGER 		NOT NULL PRIMARY KEY 
			   		  					GENERATED ALWAYS AS IDENTITY (START WITH 10000),
    Vardas    			VARCHAR(32) 	NOT NULL,
	Pavarde   			VARCHAR(32) 	NOT NULL,
	Lytis 	  			VARCHAR(4) 		NOT NULL,
										CHECK (Lytis IN ('vyr', 'mot')),
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
	Tipas			VARCHAR(32)		NOT NULL
									CHECK (Tipas IN ('kuopa', 'korporacija', 'klubas', 'vienetas', 'juridinis asmuo', 'valdomasis'))
									DEFAULT 'vienetas',
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
    Pareigybe 	VARCHAR(32) NOT NULL 
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
    Pareigybe 		VARCHAR(32) NOT NULL 
					   			CHECK (Pareigybe IN ('dalyvis', 'vadovas', 'svečias', 'programos vadovas', 'vyriausias-vadovas', 'komendantas'))
					   			DEFAULT 'dalyvis',

	CONSTRAINT IAsmeni FOREIGN KEY (Asmens_nr) REFERENCES AF.Asmuo ON DELETE RESTRICT ON UPDATE RESTRICT,
	CONSTRAINT IVieneta FOREIGN KEY (Renginio_nr) REFERENCES AF.Renginys ON DELETE RESTRICT ON UPDATE RESTRICT
);

CREATE TABLE AF.Izodis (
    Nr 				INTEGER 	NOT NULL PRIMARY KEY 
						    	GENERATED ALWAYS AS IDENTITY,
    Asmens_nr     	INTEGER 	NOT NULL,
    Sajunga			VARCHAR(4)	NOT NULL
								CHECK (Sajunga IN ('JAS', 'MAS', 'SAS', 'ASS')),
	Izodzio_data 	DATE 		NOT NULL 
							 	DEFAULT CURRENT_DATE,
	Renginio_nr 	INTEGER, 		
	
	CONSTRAINT IAsmeni FOREIGN KEY (Asmens_nr) REFERENCES AF.Asmuo ON DELETE RESTRICT ON UPDATE RESTRICT,
	CONSTRAINT IRengini FOREIGN KEY (Renginio_nr) REFERENCES AF.Renginys ON DELETE RESTRICT ON UPDATE RESTRICT
);

-- Indeksai
CREATE INDEX idx_Asmuo_Vardas_Pavarde
ON AF.Asmuo (Vardas, Pavarde);

CREATE INDEX idx_Nario_mokestis_Data
ON AF.Nario_mokestis (Apmokejimo_data);

-- Views
CREATE VIEW AF.Asmuo_pilnas AS
SELECT
    A.Nr,
    A.Vardas,
    A.Pavarde,
    A.Lytis,
    A.Gim_data,
    EXTRACT(YEAR FROM AGE(A.Gim_data)) AS Amzius,
    A.El_pastas,
    A.Tel_nr,
    A.Aprasymas,
    A.Krastas,
    A.Miestas || ', ' || A.Gatve || ' ' || A.Namas || '-' || A.Butas AS Adresas,
    COALESCE((
        SELECT I.Sajunga
        FROM AF.Izodis I
        WHERE I.Asmens_nr = A.Nr
        ORDER BY I.Izodzio_data DESC
        LIMIT 1
    ), '-') AS Narystes_statusas,
	A.Registravimo_data,
	COALESCE((
        SELECT MAX(R.Data_iki)
        FROM AF.Dalyvauja_renginyje DR
        JOIN AF.Renginys R ON DR.Renginio_nr = R.Nr
        WHERE DR.Asmens_nr = A.Nr
    ), NULL) AS Paskutinio_renginio_data
FROM
    AF.Asmuo A;

CREATE VIEW AF.Nariai AS
SELECT * FROM AF.Asmuo_pilnas
WHERE Narystes_statusas <> '-';

-- trigeris kuris patikrina ar pridedant prie renginio asmeni jis egzistuoja
-- trigeris kuris patikrina ar pridedant prie vieneto asmeni jis egzistuoja

-- trigeris, kuris sukuria nauja asmeni jei pridedant prie vieneto arba renginio jis neegzistuoja

--trigeris, kuris patikrina ar pridedant nauja izodi tas asmuo jau nera daves tos sajungos izodzio
CREATE OR REPLACE FUNCTION check_duplicate_izodis()
RETURNS TRIGGER AS $$
BEGIN
    IF EXISTS (
        SELECT 1
        FROM AF.Izodis
        WHERE NEW.Asmens_nr = Asmens_nr
          AND NEW.Sajunga = Sajunga
    ) THEN
        RAISE EXCEPTION 'Negalima pridėti antro įžodžio tos pačios sąjungos, tam pačiam asmeniui.';
    END IF;
    RETURN NEW;
END;
$$ LANGUAGE plpgsql;

CREATE TRIGGER before_insert_izodis
BEFORE INSERT ON AF.Izodis
FOR EACH ROW
EXECUTE FUNCTION check_duplicate_izodis();

CREATE MATERIALIZED VIEW MatView_AF_Valdyba AS
SELECT
    A.Nr,
    A.Vardas,
    A.Pavarde,
    A.El_pastas,
    A.Tel_nr,
    PV.Pareigybe,
    V.Pavadinimas AS Vieneto_Pavadinimas
FROM
    AF.Asmuo A
JOIN
    AF.Priklauso_vienetui PV ON A.Nr = PV.Asmens_nr
JOIN
    AF.Vienetas V ON PV.Vieneto_nr = V.Nr
WHERE
    V.Pavadinimas = 'AF valdyba'
    AND CURRENT_DATE >= PV.Data_nuo
    AND CURRENT_DATE <= PV.Data_iki;