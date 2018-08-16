
if not exists(select 1 from dbo.cookies) 
BEGIN

INSERT INTO dbo.cookies (ImageUrl, [Name], Price) values ('https://intcookie.azureedge.net/cdn/cookie-cc.jpg', 'Chololate Chip', 1.2)
INSERT INTO dbo.cookies (ImageUrl, [Name], Price) values ('https://intcookie.azureedge.net/cdn/cookie-bc.jpg', 'Butter Cookie', 1.0)
INSERT INTO dbo.cookies (ImageUrl, [Name], Price) values ('https://intcookie.azureedge.net/cdn/cookie-mc.jpg', 'Macaroons', 0.9)


END
