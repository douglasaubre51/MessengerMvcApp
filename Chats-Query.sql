select *
from UserDetails;

exec sp_help UserDetails;

insert into UserDetails
    (
    UserName,
    EmailID,
    Conversation
    )
values
    (
        'jiraiya',
        'jiraiya@gmail.com',
        'i am fine how are ye'
);

update UserDetails set Password='iwannalive' where Id=1;

update UserDetails set Password='iamdead' where Id=2;