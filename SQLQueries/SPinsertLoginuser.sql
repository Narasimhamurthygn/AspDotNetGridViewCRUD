insert into TblLogin
values (1,'user2','12345',1)

select * from TblLogin


exec UserLogin  @UserId=2, @UserName='user1', @Password='1234', @Admin=0

