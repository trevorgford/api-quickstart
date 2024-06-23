create or alter procedure tempSession_load
    @SessionId uniqueidentifier,
    @TenantId int
as

begin transaction

    select      s.UserId 
    from        TempSessions s
    inner join  UserTenants t                   on  s.UserId = t.UserId
                                                and t.TenantId = @TenantId
    where       SessionId = @SessionId 
    and         datediff(minute, CreatedTimestamp, sysutcdatetime()) < 10;

    delete from TempSessions where SessionId = @SessionId;

commit transaction

go
