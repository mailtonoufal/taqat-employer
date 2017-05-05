BEGIN TRANSACTION;
CREATE TABLE "WatchedJobs" (
	`id`	INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT UNIQUE,
	`JobPostId`	TEXT
);
CREATE TABLE "WatchedClients" (
	`Id`	INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT UNIQUE,
	`JobPostId`	TEXT,
	`ProfileId`	TEXT,
	`JSON`	'TEXT',
	`AddedById`	TEXT,
	`AddedWhen`	TEXT
);
CREATE TABLE `SavedSearches` ( `id` INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT UNIQUE, `SearchText` TEXT );
CREATE TABLE `Programs` ( `Id` INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT UNIQUE, `ProgramId` INTEGER, `JSON` TEXT );
CREATE TABLE "Notifications" ( `id` INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT UNIQUE, `NotificationId` INTEGER UNIQUE, `Title` TEXT, `Body` TEXT, `Image` TEXT, `Status` TEXT, `Received` TEXT );
CREATE TABLE "MyServices" (
	`Id`	INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT UNIQUE,
	`ServiceId`	INTEGER,
	`JSON`	TEXT
);
CREATE TABLE "MyPrograms" ( `Id` INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT UNIQUE, `ProgramId` INTEGER, `JSON` TEXT );
CREATE TABLE "MatchedClients" (
	`Id`	INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT UNIQUE,
	`ProfileId`	TEXT,
	`JSON`	TEXT,
	`JobPostId`	TEXT
);
CREATE TABLE "JobApplicant" (
	`Id`	INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT UNIQUE,
	`ApplicantId`	TEXT,
	`JobPostId`	TEXT,
	`JSON`	TEXT
);
CREATE TABLE "EventDetails" ( `id` INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT UNIQUE, `EventId` INTEGER, `EventStart` TEXT, `EventEnd` TEXT, `EventLocation` TEXT, `EventTitle` TEXT, `Status` TEXT, `PhoneNumber` TEXT, `Email` TEXT, `AdditionalInfo` TEXT, `JobPostId` TEXT );
CREATE TABLE "EmployerJobs" (
	`ID`	INTEGER PRIMARY KEY AUTOINCREMENT,
	`JobPostId`	TEXT,
	`Status`	TEXT,
	`JSON`	TEXT
);
CREATE TABLE "ComplaintRaised" (
	`Id`	INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT UNIQUE,
	`ComplaintId`	INTEGER,
	`Subject`	TEXT,
	`Status`	TEXT,
	`CreatedOn`	TEXT,
	`ClosedOn`	TEXT,
	`ComplaintText`	TEXT,
	`Category`	TEXT,
	`DOB`	TEXT,
	`NIN`	TEXT
);
CREATE TABLE "CompanyUser" (
	`Id`	INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT UNIQUE,
	`UserId`	INTEGER,
	`UserRole`	TEXT,
	`JSON`	TEXT
);
CREATE TABLE `CompanyReps` ( `Id` INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT UNIQUE, `UserId` INTEGER, `JSON` TEXT );
CREATE TABLE `CompanyRecruiter` ( `Id` INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT UNIQUE, `UserId` INTEGER, `JSON` TEXT );
CREATE TABLE `CompanyProfile` ( `Id` INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT UNIQUE,  `ProfileId` INTEGER, JSON 'TEXT');
CREATE TABLE "Branches" ( `id` INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT UNIQUE, `BranchId` INTEGER, `BranchName` TEXT, `BranchAddress` TEXT, `Longitude` REAL, `Latitude` REAL, `Image` TEXT );
CREATE TABLE "AppValues" (
	`id`	INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT UNIQUE,
	`Key`	TEXT,
	`ParentKey`	TEXT,
	`Value`	TEXT,
	`CatType`	TEXT,
	`English`	TEXT,
	`Arabic`	TEXT
);
INSERT INTO `AppValues` (id,Key,ParentKey,Value,CatType,English,Arabic) VALUES (1,'culture','0','en','Culture','English',NULL),
 (2,'culture','0','ar','Culture','عربى',NULL),
 (3,'100','0','','Complaints','Technical Issues(s)','المشكلات الفنية'),
 (4,'200','100',NULL,'Complaints','Registration','التسجيل'),
 (5,'201','100',NULL,'Complaints','Technical difficulties with web portal','الصعوبات التقنية مع البوابة الإلكترونية'),
 (6,'202','100','','Complaints','Password Related Issues','كلمة المرور المشكلات ذات الصلة'),
 (7,'400','202',NULL,'Complaints','Unlock Account','فتح الحساب'),
 (8,'401','202','','Complaints','Reset Password','إعادة تعيين كلمة المرور'),
 (9,'300','200',NULL,'Complaints','Issues With registration','قضايا مع التسجيل'),
 (10,'301','200',NULL,'Complaints','Petition against validation decision','التماس ضد قرار المصادقة');
CREATE TABLE "AppSettings" ( `id` INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT UNIQUE, `Key` TEXT NOT NULL UNIQUE, `Value` TEXT NOT NULL, `TextValue` TEXT );
INSERT INTO `AppSettings` (id,Key,Value,TextValue) VALUES (1,'culture','en','english');
CREATE TABLE "Announcement" (
	`id`	INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT UNIQUE,
	`Ttle`	TEXT,
	`Description`	TEXT,
	`Image`	TEXT,
	`CompanyName`	TEXT,
	`Featured`	INTEGER,
	`Url`	TEXT
);
CREATE TABLE "AllServices" (
	`Id`	INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT UNIQUE,
	`ServiceId`	INTEGER,
	`JSON`	TEXT
);
COMMIT;
