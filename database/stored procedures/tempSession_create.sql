create or alter procedure tempSession_create
    @SessionId uniqueidentifier,
    @UserId int
as

insert into tempSessions ( SessionId, UserId, CreatedTimestamp )
values ( @SessionId, @UserId, sysutcdatetime() );

go
