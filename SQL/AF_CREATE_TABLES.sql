CREATE SCHEMA AF;

CREATE TABLE AF.Person (
    Id              INTEGER         NOT NULL PRIMARY KEY 
                                    GENERATED ALWAYS AS IDENTITY (START WITH 10000),
    FirstName       VARCHAR(32)     NOT NULL,
    LastName        VARCHAR(32)     NOT NULL,
    Gender          VARCHAR(4)      NOT NULL 
                                    CHECK (Gender IN ('vyr', 'mot')),
    BirthDate       DATE            NOT NULL 
                                    CONSTRAINT CK_Person_BirthDate 
                                        CHECK(EXTRACT(YEAR FROM BirthDate) > 1920 AND EXTRACT(YEAR FROM BirthDate) < EXTRACT(YEAR FROM CURRENT_DATE) + 1),
    Email           CHAR(50),
    Phone           VARCHAR(15),
    Country         VARCHAR(32),
    Description     VARCHAR(500), 
    Street          VARCHAR(30),
    City            VARCHAR(20),
    House           VARCHAR(5),
    Apartment       VARCHAR(5),
    RegistrationDate TIMESTAMP       NOT NULL 
                                    DEFAULT CURRENT_TIMESTAMP
);

CREATE TABLE AF.MembershipFee (
    PaymentId       INTEGER         NOT NULL 
                                    GENERATED ALWAYS AS IDENTITY,
    PersonId        INTEGER         NOT NULL,
    Amount          DECIMAL(10, 2)  NOT NULL,
    Description     VARCHAR(500),
    PaymentDate     DATE       NOT NULL 
                                    DEFAULT CURRENT_DATE,

    CONSTRAINT FK_Person_MembershipFee_PersonId 
        FOREIGN KEY (PersonId) REFERENCES AF.Person(Id) ON DELETE CASCADE ON UPDATE SET NULL
);

CREATE TABLE AF.Unit (
    Id              INTEGER         NOT NULL PRIMARY KEY 
                                    GENERATED ALWAYS AS IDENTITY,
    Name            VARCHAR(50)     NOT NULL,
    Type            VARCHAR(32)     NOT NULL 
                                    CHECK (Type IN ('kuopa', 'korporacija', 'klubas', 'vienetas', 'juridinis asmuo', 'valdomasis'))
                                    DEFAULT 'vienetas',
    Description     VARCHAR(500),
    Address         VARCHAR(50),
    EstablishmentDate DATE          NOT NULL 
                                    DEFAULT CURRENT_DATE
);

CREATE TABLE AF.Event (
    Id              INTEGER         NOT NULL PRIMARY KEY 
                                    GENERATED ALWAYS AS IDENTITY,
    Name            VARCHAR(50)     NOT NULL,
    Organizer       VARCHAR(50)     NOT NULL,
    Description     VARCHAR(500),
    Location        VARCHAR(50),
    StartDate       TIMESTAMP       NOT NULL,
    EndDate         TIMESTAMP       NOT NULL 
                                    CHECK (EndDate >= StartDate)
);

CREATE TABLE AF.BelongsToUnit (
    Id              INTEGER         NOT NULL PRIMARY KEY 
                                    GENERATED ALWAYS AS IDENTITY,
    PersonId        INTEGER         NOT NULL,
    UnitId          INTEGER         NOT NULL,
    Position        VARCHAR(32)     NOT NULL 
                                    CHECK (Position IN ('globėjas', 'narys'))
                                    DEFAULT 'narys',
    StartDate       DATE            NOT NULL,
    EndDate         DATE            NOT NULL 
                                    CHECK (EndDate >= StartDate),

    CONSTRAINT FK_Person_BelongsToUnit_PersonId 
        FOREIGN KEY (PersonId) REFERENCES AF.Person(Id) ON DELETE CASCADE ON UPDATE SET NULL,
    CONSTRAINT FK_Unit_BelongsToUnit_UnitId 
        FOREIGN KEY (UnitId) REFERENCES AF.Unit(Id) ON DELETE CASCADE ON UPDATE SET NULL
);

CREATE TABLE AF.AttendsEvent (
    Id              INTEGER         NOT NULL PRIMARY KEY 
                                    GENERATED ALWAYS AS IDENTITY,
    EventId         INTEGER         NOT NULL,
    PersonId        INTEGER         NOT NULL,
    Position        VARCHAR(32)     NOT NULL 
                                    CHECK (Position IN ('dalyvis', 'vadovas', 'svečias', 'programos vadovas', 'vyriausias-vadovas', 'komendantas'))
                                    DEFAULT 'dalyvis',

    CONSTRAINT FK_Person_AttendsEvent_PersonId 
        FOREIGN KEY (PersonId) REFERENCES AF.Person(Id) ON DELETE CASCADE ON UPDATE SET NULL,
    CONSTRAINT FK_Event_AttendsEvent_EventId 
        FOREIGN KEY (EventId) REFERENCES AF.Event(Id) ON DELETE CASCADE ON UPDATE SET NULL
);

CREATE TABLE AF.Pledge (
    Id              INTEGER         NOT NULL PRIMARY KEY 
                                    GENERATED ALWAYS AS IDENTITY,
    PersonId        INTEGER         NOT NULL,
    Association     VARCHAR(4)      NOT NULL 
                                    CHECK (Association IN ('JAS', 'MAS', 'SAS', 'ASS')),
    Date      DATE            NOT NULL 
                                    DEFAULT CURRENT_DATE,
    EventId         INTEGER, 

    CONSTRAINT FK_Person_Pledge_PersonId 
        FOREIGN KEY (PersonId) REFERENCES AF.Person(Id) ON DELETE CASCADE ON UPDATE CASCADE,
    CONSTRAINT FK_Event_Pledge_EventId 
        FOREIGN KEY (EventId) REFERENCES AF.Event(Id) ON DELETE CASCADE ON UPDATE CASCADE
);

-- Indexes
CREATE INDEX idx_Person_FirstName_LastName
ON AF.Person (FirstName, LastName);

CREATE INDEX idx_MembershipFee_PaymentDate
ON AF.MembershipFee (PaymentDate);

-- Views
CREATE VIEW AF.Person_Full AS
SELECT
    P.Id,
    P.FirstName,
    P.LastName,
    P.Gender,
    P.BirthDate,
    EXTRACT(YEAR FROM AGE(P.BirthDate)) AS Age,
    P.Email,
    P.Phone,
    P.Description,
    P.Country,
    P.City || ', ' || P.Street || ' ' || P.House || '-' || P.Apartment AS Address,
    COALESCE((
        SELECT I.Association
        FROM AF.Pledge I
        WHERE I.PersonId = P.Id
        ORDER BY I.Date DESC
        LIMIT 1
    ), NULL) AS MembershipStatus,
    P.RegistrationDate,
    COALESCE((
        SELECT MAX(E.EndDate)
        FROM AF.AttendsEvent AE
        JOIN AF.Event E ON AE.EventId = E.Id
        WHERE AE.PersonId = P.Id
    ), NULL) AS LastEventDate
FROM
    AF.Person P;

CREATE VIEW AF.Members AS
SELECT * FROM AF.Person_Full
WHERE MembershipStatus IS NOT NULL;

CREATE VIEW AF.MembershipFeeFull AS
SELECT
    mf.PaymentId,
    mf.PersonId,
    p.FirstName AS PersonFirstName,
    p.LastName AS PersonLastName,
    mf.Amount,
    mf.PaymentDate,
    mf.Description,
        COALESCE((
        SELECT I.Association
        FROM AF.Pledge I
        WHERE I.PersonId = p.Id
        ORDER BY I.Date DESC
        LIMIT 1
    ), NULL) AS MembershipStatus
FROM
    AF.MembershipFee mf
JOIN
    AF.Person p ON mf.PersonId = p.Id;

-- Trigger to check if a person exists when adding them to an event or unit
-- Trigger to check if a person exists when adding them to an event or unit

-- Trigger that creates a new person if they don't exist when adding them to an event or unit

-- Trigger to check if adding a new pledge, the person has not given the same association pledge
CREATE OR REPLACE FUNCTION check_duplicate_pledge()
RETURNS TRIGGER AS $$
BEGIN
    IF EXISTS (
        SELECT 1
        FROM AF.Pledge
        WHERE NEW.PersonId = PersonId
          AND NEW.Association = Association
    ) THEN
        RAISE EXCEPTION 'Cannot add a second pledge of the same association for the same person.';
    END IF;
    RETURN NEW;
END;
$$ LANGUAGE plpgsql;

CREATE TRIGGER before_insert_pledge
BEFORE INSERT ON AF.Pledge
FOR EACH ROW
EXECUTE FUNCTION check_duplicate_pledge();