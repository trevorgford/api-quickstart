if not exists ( select * from sys.tables where name = 'Users' )
create table Users (
    UserId int identity not null,
    --Add Other Columns Here
    constraint PK_Users primary key ( UserId )
);
go