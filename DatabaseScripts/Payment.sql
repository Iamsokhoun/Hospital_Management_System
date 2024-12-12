Create Table [dbo].[Payment](
BillID int  IDENTITY(1,1) Not Null ,
PatientID varchar(10) NOT Null,
PaymentDate Date Not Null,
Amount money NOT Null,
PaymentStatus varchar(20)
Primary Key(BillID),
Constraint FK_Payment_Patient Foreign Key(PatientID) References Patient(PatientID)
ON Update CASCADE
ON Delete CASCADE
);