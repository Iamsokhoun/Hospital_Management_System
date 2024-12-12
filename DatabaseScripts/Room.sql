Create Table[dbo].[Room](
RoomID varchar(10),
RoomName varchar(30) Not NUll,
RoomType varchar(20),
Capacity int Not Null,
CurStatus varchar(20)Not Null,
Primary Key (RoomID),
);