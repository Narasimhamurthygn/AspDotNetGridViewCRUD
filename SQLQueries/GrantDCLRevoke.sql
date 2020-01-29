---GRANT  <Privileges|All>
---ON <DBObjects>
---TO<Users>
---[With Grant option]

GRANT Select, Update, Insert
ON Shippers
To dbo
with grant option


---REVOKE <Privileges>
---ON <DBObjects>
---FROM <user>
---[CASCADE]

Revoke update
On Shippers
From dbo
Cascade