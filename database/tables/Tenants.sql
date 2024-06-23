if not exists ( select * from sys.tables where name = 'Tenants' )
create table Tenants (
    TenantId int identity not null,
    --Add Other Columns Here
    constraint PK_Tenants primary key ( TenantId )
);
go