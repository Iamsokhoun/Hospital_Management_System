Create Table [dbo].[Bed](
BedID varchar(10) ,
BedNO varchar(10) Not Null,
CurStatus varchar(20)Not Null,
RoomID varchar(10) Not Null,
Primary Key (BedID,RoomID),
Constraint FK_Bed_Room Foreign Key (RoomID) References Room(RoomID)
ON Update CASCADE
ON Delete CASCADE,
);