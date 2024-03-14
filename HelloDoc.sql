IF NOT EXISTS (SELECT * FROM sys.databases WHERE name = 'HelloDoc')
BEGIN
	CREATE DATABASE HelloDoc;
END
 use HelloDoc 

CREATE TABLE AspNetUsers(
    Id nvarchar(128) PRIMARY KEY,
    UserName nvarchar(256) NOT NULL,
    PasswordHash nvarchar(MAX),
    Email nvarchar(256),
    PhoneNumber nvarchar(20),
    IP nvarchar(20),
    CreatedDate datetime NOT NULL,
    ModifiedDate datetime,
);

CREATE TABLE [User] (
    UserId int PRIMARY KEY identity(1,1),
    AspNetUserId nvarchar(128) FOREIGN KEY REFERENCES AspNetUsers(Id),
    FirstName nvarchar(100) NOT NULL,
    LastName nvarchar(100),
    Email nvarchar(256) NOT NULL,
    Mobile nvarchar(20),
    IsMobile bit,
    BirthDate DateTime NOT NULL,
    Street nvarchar(100),
    City nvarchar(50),
    State nvarchar(20),
    RegionId int ,
    ZipCode nvarchar(10),
    strMonth nvarchar(20),
    intYear int,
    intDate int,
    CreatedBy nvarchar(256) NOT NULL,
    CreatedDate datetime NOT NULL,
    ModifiedBy nvarchar(256),
    ModifiedDate datetime,
    Status tinyint,
    IsDeleted bit,
    IP nvarchar(20),
    IsRequestWithEmail bit
);

CREATE TABLE Physician (
    PhysicianId bigint PRIMARY KEY NOT NULL identity(1,1),
    AspNetUserId nvarchar(128) FOREIGN KEY REFERENCES AspNetUsers(Id) ,
    FirstName nvarchar(100) NOT NULL,
    LastName nvarchar(100) ,
    Email nvarchar(50) NOT NULL,
    Mobile nvarchar(20) ,
    MedicalLicense nvarchar(500) ,
    Photo nvarchar(100) ,
    AdminNotes nvarchar(500) ,
    IsAgreementDoc bit ,
    IsBackgroundDoc bit ,
    IsTrainingDoc bit ,
    IsNonDisclosureDoc bit ,
    Address1 nvarchar(500) ,
    Address2 nvarchar(500) ,
    City nvarchar(100) ,
    RegionId int ,
    Zip nvarchar(10) ,
    AltPhone nvarchar(20) ,
    CreatedBy nvarchar(128) NOT NULL FOREIGN KEY REFERENCES AspNetUsers(Id),
    CreatedDate datetime  NOT NULL,
    ModifiedBy nvarchar(128)  FOREIGN KEY REFERENCES AspNetUsers(Id),
    ModifiedDate datetime ,
    Status tinyint ,
    BusinessName nvarchar(100) NOT NULL,
    BusinessWebsite nvarchar(200) NOT NULL,
    IsDeleted bit ,
    RoleId int ,
    NPINumber nvarchar(500) ,
    IsLicenseDoc bit ,
    Signature nvarchar(100) ,
    IsCredentialDoc bit ,
    IsTokenGenerate bit ,
    SyncEmailAddress nvarchar(50) 
);

CREATE SEQUENCE RequestTypeIdSequence
    START WITH 1
    INCREMENT BY 1;

CREATE TABLE Request (
    RequestId int PRIMARY KEY NOT NULL identity(1,1),
    RequestTypeId int NOT NULL DEFAULT NEXT VALUE FOR RequestTypeIdSequence,
    UserId  int  FOREIGN KEY REFERENCES [User](UserId) ,
    FirstName nvarchar(100) ,
    LastName nvarchar(100) ,
    PhoneNumber nvarchar(23) ,
    Email nvarchar(50) ,
    Status tinyint NOT NULL,
    PhysicianId bigint FOREIGN KEY REFERENCES Physician(PhysicianId) ,
    ConfirmationNumber nvarchar(20) ,
    CreatedDate datetime NOT NULL,
    IsDeleted bit ,
    ModifiedDate datetime ,
    DeclinedBy varchar(250) ,
    IsUrgentEmailSent bit NOT NULL,
    LastWellnessDate datetime ,
    IsMobile bit ,
    CallType tinyint ,
    CompletedByPhysician int ,
    LastReservationDate datetime ,
    AcceptedDate datetime ,
    RelationName nvarchar(100) ,
    CaseNumber nvarchar(50) ,
    IP nvarchar(20) ,
    CaseTag nvarchar(50),
    CaseTagPhysician nvarchar(50),
    PatientAccountId int ,
    CreatedUserId int 
   );

  
   CREATE TABLE Region (
    RegionId int  NOT NULL Primary Key identity(1,1),
    Name nvarchar(50) NOT NULL,
    Abbreviation nvarchar(50) ,
   
);

CREATE TABLE RequestClient (
    RequestClientId int NOT NULL PRIMARY KEY identity(1,1),
    RequestId int NOT NULL FOREIGN KEY REFERENCES Request(RequestId),
    FirstName nvarchar(100) NOT NULL,
    LastName nvarchar(100) ,
    PhoneNumber nvarchar(23) ,
    Location nvarchar(100) ,
    Address nvarchar(500) ,
    RegionId int FOREIGN KEY REFERENCES Region(RegionId),
    NotiMobile nvarchar(20),
    NotiEmail nvarchar(50) ,
    Notes nvarchar(500),
    Email nvarchar(500),
    strMonth nvarchar(20),
    intYear int ,
    intDate int ,
    IsMobile bit ,
    Street nvarchar(100) ,
    City nvarchar(100) ,
    State nvarchar(100) ,
    ZipCode nvarchar(10) ,
    CommunicationType tinyint ,
    RemindReservationCount tinyint ,
    RemindHouseCallCount tinyint ,
    IsSetFollowupSent tinyint ,
    IP nvarchar(20) ,
    IsReservationReminderSent tinyint ,
    Latitude decimal(9) ,
    Longitude decimal(9) ,
    
);

CREATE TABLE Admin (
     Adminld int NOT NULL PRIMARY KEY identity(1,1),
     AspNetUserld nvarchar(128) NOT NULL  FOREIGN KEY REFERENCES AspNetUsers(Id),
    FirstName nvarchar(100) NOT NULL,
    LastName nvarchar(100),
    Email nvarchar(50) NOT NULL,
    Mobile nvarchar(20) ,
    Address1 nvarchar(500) ,
    Address2 nvarchar(500) ,
    City nvarchar(100) ,
    Regionld int ,
    Zip nvarchar(10) ,
    AltPhone nvarchar(20) ,
    CreatedBy nvarchar(128) NOT NULL,
    CreatedDate datetime NOT NULL,
     ModifiedBy nvarchar(128) FOREIGN KEY REFERENCES AspNetUsers(Id),
    ModifiedDate datetime ,
    Status tinyint,
    IsDeleted bit,
    Roleld int ,
    
);

CREATE TABLE RequestWiseFile (
    RequestWiseFileID int NOT NULL PRIMARY KEY identity(1,1),
    Requestid int NOT NULL FOREIGN KEY REFERENCES Request(RequestId),
    FileName nvarchar(500) NOT NULL,
    CreatedDate datetime NOT NULL,
    Physicianld bigint FOREIGN KEY REFERENCES Physician(PhysicianId),
    Adminld int FOREIGN KEY REFERENCES Admin(Adminld),
    DocType tinyint ,
    IsFrontSide bit ,
    IsCompensation bit ,
    IP nvarchar(20) ,
    IsFinalize bit ,
    IsDeleted bit ,
    IsPatientRecords bit 
);


use HelloDoc

select * from AspNetUsers;
select * from [User];
select * from Request;


delete from AspNetUsers;
delete from [User];
delete from Request;