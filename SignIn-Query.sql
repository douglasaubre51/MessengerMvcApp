exec sp_help UserDetails;

alter table UserDetails alter column 
 Password varchar(255);

 exec sp_rename 'UserDetails.DAte','Date','Column';

 insert into UserDetails(
 EmailID,
 UserName,
 Password
 ) values (
 'douglasaubre@gmail.com',
 'allen',
 'aceisdead'
 );

 select * from UserDetails;
