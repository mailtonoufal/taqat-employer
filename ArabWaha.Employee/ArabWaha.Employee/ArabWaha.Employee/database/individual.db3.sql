BEGIN TRANSACTION;
CREATE TABLE "WatchedJobs" (
	`Id`	INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT UNIQUE,
	`JobPostId`	TEXT
);
CREATE TABLE `UserProfile` (
	`Id`	INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT UNIQUE,
	`Firstname`	TEXT,
	`Secondname`	TEXT,
	`Thirdname`	TEXT,
	`Lastname`	TEXT,
	`Username`	INTEGER,
	`ProfileTitle`	INTEGER,
	`ProfileId`	INTEGER,
	`EmploymentStatus`	INTEGER
);
CREATE TABLE `Skills` (
	`SkillTitle`	TEXT,
	`ProfileId`	INTEGER,
	`id`	INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT UNIQUE,
	`SkillLevel`	INTEGER
);
CREATE TABLE `SavedSearches` (
	`id`	INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT UNIQUE,
	`SearchText`	TEXT
);
CREATE TABLE `Programs` (
	`Id`	INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT UNIQUE,
	`ProgramId`	INTEGER,
	`JSON`	TEXT
);
CREATE TABLE "Notifications" (
	`id`	INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT UNIQUE,
	`NotificationId`	INTEGER UNIQUE,
	`Title`	TEXT,
	`Body`	TEXT,
	`Image`	TEXT,
	`Status`	TEXT,
	`Received`	TEXT
);
CREATE TABLE "MyPrograms" (
	`id`	INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT UNIQUE,
	`ProgramId`	INTEGER,
	`JSON`	TEXT
);
CREATE TABLE "JobsData" (
	`Id`	INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT UNIQUE,
	`JobPostId`	TEXT,
	`JSON`	TEXT
);
CREATE TABLE "EventDetails" (
	`id`	INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT UNIQUE,
	`EventId`	INTEGER,
	`EventStart`	TEXT,
	`EventEnd`	TEXT,
	`EventLocation`	TEXT,
	`EventTitle`	TEXT,
	`Status`	TEXT,
	`PhoneNumber`	TEXT,
	`Email`	TEXT,
	`AdditionalInfo`	TEXT,
	`JobPostId`	TEXT
);
CREATE TABLE "ComplaintRaised" ( `Id` INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT UNIQUE, `ComplaintId` INTEGER, `Subject` TEXT, `Status` TEXT, `CreatedOn` TEXT, `ClosedOn` TEXT, `ComplaintText` TEXT, `Category` TEXT, `DOB` TEXT, `NIN` TEXT );
CREATE TABLE "Branches" (
	`id`	INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT UNIQUE,
	`BranchId`	INTEGER,
	`BranchName`	TEXT,
	`BranchAddress`	TEXT,
	`Longitude`	REAL,
	`Latitude`	REAL,
	`Image`	TEXT
);
CREATE TABLE `Badges` (
	`id`	INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT UNIQUE,
	`BadgeId`	INTEGER,
	`BadgeDescription`	TEXT,
	`BadgeStatus`	TEXT,
	`BadgeIcon`	TEXT
);
CREATE TABLE "AppliedJobs" (
	`id`	INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT UNIQUE,
	`JobPostId`	TEXT,
	`ApplicationStatus`	TEXT,
	`ApplicationDate`	TEXT,
	`NesIndividualID`	INTEGER,
	`ApplicationID`	INTEGER,
	`CoverletterId`	TEXT
);
CREATE TABLE "AppValues" ( `id` INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT UNIQUE, `Key` TEXT, `ParentKey` TEXT, `Value` TEXT, `CatType` TEXT, `English` TEXT, `Arabic` TEXT );
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
CREATE TABLE "AppSettings" (
	`id`	INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT UNIQUE,
	`Key`	TEXT NOT NULL UNIQUE,
	`Value`	TEXT NOT NULL,
	`TextValue`	TEXT
);
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
INSERT INTO `Announcement` (id,Ttle,Description,Image,CompanyName,Featured,Url) VALUES (1,'Find Your Ideal job','Check out the thousands of vacancies currently available across KSA to find the ideal one for you',NULL,NULL,NULL,NULL),
 (2,'Give Yourself a Bonus','Obtan upto 24,000 SAR in bonuses for maintaining employment with the same employer',NULL,NULL,NULL,NULL),
 (3,'Earn rewards','Join the TAQAT Awsema program and earn rewards for your activity in Taqat',NULL,NULL,NULL,NULL),
 (4,'Get Yoursef Noticed','Create your candidate profile in just minutes to begin getting noticed immediately by employers across KSA',NULL,NULL,NULL,NULL);
COMMIT;
