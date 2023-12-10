INSERT INTO AF.Priklauso_vienetui VALUES(2001, 0001, 1002, 'dalyvis', '2023-05-01', '2024-05-01');
INSERT INTO AF.Priklauso_vienetui VALUES(2002, 0004, 1004, 'atstovas', '2023-05-01', '2024-05-01');
INSERT INTO AF.Priklauso_vienetui VALUES(2003, 0003, 1005, 'narys', '2023-09-01', '2024-09-01');

INSERT INTO AF.Asmuo (Vardas, Pavarde, Lytis, Gim_data, El_pastas, Tel_nr, Krastas, Aprasymas, Gatve, Miestas, Namas, Butas) VALUES 
    ('Balys', 'Vabalas', 'vyr', '2003-09-07', 'vabalas@gmail.com', '+37065666772', 'Vilniaus', 'sveiki!', 'Laisves al.', 'Kaunas', '13', '100'),
    ('Ignas', 'Labokas', 'vyr', '2004-01-06', 'ignas@gmail.com', '324325435', 'Vilniaus' 'labas...', 'Zemaites g.', 'Kaunas', '4', '50'),
    ('Pijus', 'Ivanskas', 'vyr', '2004-05-12', 'pij@ateitis.lt', '234234', 'Vilniaus', 'Esu Mikalojaus k. globejas', 'Uzupes g.', 'Vilnius', '11', '1'),
    ('Eglė', 'Skarota', 'mot', '2003-11-12', 'egle@gmail.com', '112', 'Kauno', 'tra ta ra', 'Sopeno', 'Labunava', '1', '1');
    ('Deimante', 'Rust', 'mot', '2001-03-01', 'deim@gmail.com', '+1234567890', 'Telsiu', 'tra ta ra', 'Dovydaicio', 'Meksika', '2', '4');


INSERT INTO AF.Nario_mokestis (Asmens_nr, Suma, Apmokejimo_data) VALUES
    (10001, 15.0, '2023-12-10'),
    (10002, 15.0, '2023-12-09');

INSERT INTO AF.Nario_mokestis (Asmens_nr, Suma) VALUES
	(10002, 10.0),
    (10004, 10.0);


INSERT INTO AF.Vienetas (Pavadinimas, Tipas, Aprasymas, Adresas) VALUES
    ('AF valdyba', 'valdomasis', NULL, 'Nuotolinis'),
    ('AF taryba', 'valdomasis', NULL, 'Nuotolinis'),
    ('MAS valdyba', 'valdomasis', NULL, 'Nuotolinis'),
    ('Juozo Girniaus Kuopa', 'kuopa', 'Studentu globojama Vilniaus kuopa', 'AV12'),
    ('Tomo Moro klubas', 'klubas', 'Politikos mokslu studentai');

-- renginiai

INSERT INTO AF.Priklauso_vienetui (Asmens_nr, Vieneto_nr, Data_nuo, Data_iki) VALUES
    (10001, 3, '2023-05-01', '2024-05-01'),
    (10001, 3, '2022-05-01', '2023-05-01'),
    (10001, 1, '2023-05-01', '2024-05-01'),
    (10002, 4, '2021-09-01', '2022-09-01'),
    (10003, 4, '2021-09-01', '2022-09-01'),
    (10004, 3, '2022-05-01', '2023-05-01'),
    (10005, 5, '2023-09-01', '2024-09-01');

INSERT INTO AF.Izodis (Asmens_nr, Sajunga, Izodzio_data, Renginio_nr) VALUES
    (10001, 'MAS', '2022-05-02', NULL),
    (10001, 'SAS', '2023-10-14', NULL),
    (10003, 'MAS', '2020-08-28', NULL),



