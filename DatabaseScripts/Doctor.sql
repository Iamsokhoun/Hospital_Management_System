Create Table [dbo].[Doctor](
	DoctorID varchar(10) Not Null,
	FirstName varchar(20) Not Null,
	LastName varchar(20) Not Null,
	Gender varchar(6) Not Null,
	ProfessionalType varchar(10) Not Null,
	HiredDate Date Not Null,
	Salary float Not Null,
	Contact varchar(12) Not Null,
	CurAddress varchar(80) Not Null,
	DateOFBirth Date Not Null,
	CurStatus varchar(10) Not Null,
	Primary Key (DoctorID)
);