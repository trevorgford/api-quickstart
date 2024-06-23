if not exists ( select * from sys.tables where name = 'UserTenants' )
create table UserTenants (
    UserId int not null,
    TenantId int not null,
    constraint PK_UserTenants primary key ( UserId, TenantId ),
    constraint FK_UserTenants_Users foreign key ( UserId ) references Users ( UserId ),
    constraint FK_UserTenants_Tenants foreign key ( TenantId ) references Tenants ( TenantId )
);
go