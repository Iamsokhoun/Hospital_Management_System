Create Table [dbo].[Patient](
	PatientID varchar(10) Not Null,
	FirstName varchar(20) Not Null,
	LastName varchar(20) Not Null,
	RegisterDate Date Not Null,
	Gender varchar(6) Not Null,
	Disease varchar(50) Not Null,
	Contact varchar(12) Not Null,
	DateOFBirth Date Not Null,
	CurAddress varchar(80) Not Null,
	TreatBY varchar(10) Not Null,
	RoomID varchar(10) Not Null,
	BedID varchar(10) Not Null,
	CurStatus varchar(20) Not Null,
	Primary Key (PatientID),
	Constraint FK_Patient_Doctor Foreign Key(TreatBY) References Doctor(DoctorID)
	ON Update NO ACTION
	ON Delete NO ACTION,
	Constraint FK_Patient_Room Foreign Key(RoomID) References Room (RoomID)
	ON Update CASCADE
	ON Delete CASCADE,
	Constraint FK_Patient_Bed Foreign Key(BedID,RoomID) References Bed(BedID,RoomID)
	ON Update NO ACTION
	ON Delete NO ACTION
);