-- Inserting data into the AF.Person table
INSERT INTO AF.Person (FirstName, LastName, Gender, BirthDate, Email, Phone, Country, Description, Street, City, House, Apartment)
VALUES 
    ('Balys', 'Vabalas', 'vyr', '2003-09-07', 'vabalas@gmail.com', '+37065666772', 'Vilniaus', 'sveiki!', 'Laisves al.', 'Kaunas', '13', '100'),
    ('Ignas', 'Labokas', 'vyr', '2004-01-06', 'ignas@gmail.com', '324325435', 'Vilniaus', 'labas...', 'Zemaites g.', 'Kaunas', '4', '50'),
    ('Pijus', 'Ivanskas', 'vyr', '2004-05-12', 'pij@ateitis.lt', '234234', 'Vilniaus', 'Esu Mikalojaus k. globejas', 'Uzupes g.', 'Vilnius', '11', '1'),
    ('Eglė', 'Skarota', 'mot', '2003-11-12', 'egle@gmail.com', '112', 'Kauno', 'tra ta ra', 'Sopeno', 'Labunava', '1', '1'),
    ('Deimante', 'Rust', 'mot', '2001-03-01', 'deim@gmail.com', '+1234567890', 'Telsiu', 'tra ta ra', 'Dovydaicio', 'Meksika', '2', '4');

-- Inserting data into the AF.MembershipFee table
INSERT INTO AF.MembershipFee (PersonId, Amount, PaymentDate)
VALUES
    (10001, 15.0, '2023-12-10'),
    (10000, 10.0, '2022-12-09');

INSERT INTO AF.MembershipFee (PersonId, Amount)
VALUES
    (10000, 15.0),
    (10004, 10.0);

-- Inserting data into the AF.Unit table
INSERT INTO AF.Unit (Name, Type, Description, Address)
VALUES
    ('AF valdyba', 'valdomasis', NULL, 'Nuotolinis'),
    ('AF taryba', 'valdomasis', NULL, 'Nuotolinis'),
    ('MAS valdyba', 'valdomasis', NULL, 'Nuotolinis'),
    ('Juozo Girniaus Kuopa', 'kuopa', 'Studentu globojama Vilniaus kuopa', 'AV12'),
    ('Tomo Moro klubas', 'klubas', NULL, 'Politikos mokslu studentai');

-- Inserting data into the AF.Event table
INSERT INTO AF.Event (Name, Organizer, Description, Location, StartDate, EndDate)
VALUES
    ('DB sukurimo svente', 'Balys Vabalas', 'Vyko DB testavai', 'VU MIF, Vilnius', '2023-12-01', '2023-12-30'),
    ('Kuopų lyderių savaitgalis', 'MAS valdyba', NULL, 'Kauno kunigų seminarija', '2023-10-21', '2023-10-22');

-- Inserting data into the AF.AttendsEvent table
INSERT INTO AF.AttendsEvent (EventId, PersonId, Position)
VALUES
    (1, 10000, 'vyriausias-vadovas'),
    (2, 10003, 'vadovas'),
    (2, 10000, 'vadovas'),
    (1, 10001, 'dalyvis');

-- Inserting data into the AF.BelongsToUnit table
INSERT INTO AF.BelongsToUnit (PersonId, UnitId, StartDate, EndDate)
VALUES
    (10000, 3, '2023-05-01', '2024-05-01'),
    (10000, 3, '2022-05-01', '2023-05-01'),
    (10000, 1, '2023-05-01', '2024-05-01'),
    (10001, 4, '2021-09-01', '2022-09-01'),
    (10002, 4, '2021-09-01', '2022-09-01'),
    (10003, 3, '2022-05-01', '2023-05-01'),
    (10004, 5, '2023-09-01', '2024-09-01');

-- Inserting data into the AF.Pledge table
INSERT INTO AF.Pledge (PersonId, Association, Date, EventId)
VALUES
    (10000, 'MAS', '2022-05-02', NULL),
    (10000, 'SAS', '2023-10-14', NULL),
    (10002, 'MAS', '2020-08-28', NULL);