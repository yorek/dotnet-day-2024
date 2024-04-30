select * from dbo.SampleTable
go

insert into dbo.SampleTable (SomeValue, SomeOtherValue) values
('Hello','World'),
('Hi', 'There')
go

update dbo.SampleTable set SomeOtherValue = 'Davide'
go

delete from dbo.SampleTable 
go

/* 
    Execute the next two commands together 
*/
insert into dbo.SampleTable (SomeValue, SomeOtherValue) values
('Hello','World'),
('Hi', 'There');
go
update dbo.SampleTable set SomeOtherValue = 'Davide'
go