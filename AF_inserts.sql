INSERT INTO AF.Asmuo VALUES(0001,'Balys', 'Vabalas', 'Vyras', '2003-09-07', 'vabalas@gmail.com', '112', NULL, 'Vilniaus k.');
INSERT INTO AF.Asmuo VALUES(0002,'Andrius', 'Gadinskas', 'Vyras', '2003-06-27', 'andrius@gmail.com', '112', NULL, 'Vilniaus k.');
INSERT INTO AF.Asmuo VALUES(0003,'Ignas', 'Labokas', 'Vyras', '2004-01-06', 'ignas@gmail.com', '112', NULL, 'Vilniaus k.');
INSERT INTO AF.Asmuo VALUES(0004,'Pijus', 'Ivanskas', 'Vyras', '2004-05-12', 'pij@ateitis.lt', '112', NULL, 'Vilniaus k.', 'Mikalojaus k. globejas');
INSERT INTO AF.Asmuo VALUES(0005,'Eglė', 'Skarota', 'Moteris', '2003-11-12', 'egle@gmail.com', '112', NULL,  'Kauno k.');

INSERT INTO AF.Nario_mokestis VALUES(123, 0001, 10.0, '2023-12-07');
INSERT INTO AF.Nario_mokestis VALUES(124, 0001, 10.0, '2022-11-01');
INSERT INTO AF.Nario_mokestis VALUES(125, 0003, 10.0, NULL);
INSERT INTO AF.Nario_mokestis VALUES(127, 0004, 10.0, '2023-09-04');

INSERT INTO AF.Vienetas VALUES(1001, 'Juozo Girniaus kuopa', 'Jega!', NULL, '2012-09-07');
INSERT INTO AF.Vienetas VALUES(1002, 'AF Valdyba', NULL, NULL, '1990-01-01');
INSERT INTO AF.Vienetas VALUES(1003, 'AF Taryba', NULL, NULL, '1990-01-01');
INSERT INTO AF.Vienetas VALUES(1004, 'Tomo Moro klubas', 'Politikos mokslu studentai', NULL, '2016-09-01');
INSERT INTO AF.Vienetas VALUES(1005, 'Šv. Mikalojaus kuopa', 'Jaunučiai', NULL, '2015-12-17');

INSERT INTO AF.Priklauso_vienetui VALUES(2001, 0001, 1002, 'dalyvis', '2023-05-01', '2024-05-01');
INSERT INTO AF.Priklauso_vienetui VALUES(2002, 0004, 1004, 'atstovas', '2023-05-01', '2024-05-01');
INSERT INTO AF.Priklauso_vienetui VALUES(2003, 0003, 1005, 'narys', '2023-09-01', '2024-09-01');



