select * from UserDetails;

exec sp_help UserDetails;

insert into UserDetails (
UserName,
EmailID,
Conversation
) values (
'jiraiya',
'jiraiya@gmail.com',
'i am fine how are ye'
);
