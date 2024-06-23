if not exists ( select * from sys.tables where name = 'TempSessions' )
create table TempSessions (
    SessionId uniqueidentifier not null,
    UserId int not null,
    CreatedTimestamp datetime2 not null
);
go

if not exists ( select * from sys.indexes where name = 'IX_TempSessions_SessionId' )
create index IX_TempSessions_SessionId on TempSessions ( SessionId );
go