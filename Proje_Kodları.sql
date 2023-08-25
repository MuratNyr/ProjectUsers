CREATE TABLE People (
    ID int PRIMARY KEY IDENTITY(1,1),
    Name varchar(50),
    Surname varchar(50),
    Birthdate date,
    Email varchar(100),
    PhoneNumber varchar(20),
    Address varchar(200),
    City varchar(50),
    Country varchar(50),
    PhotoUrl varchar(255)
);


ALTER TABLE People
ADD PhotoUrl varchar(255);


INSERT INTO People (Name, Surname, Birthdate, Email, PhoneNumber, Address, City, Country, PhotoUrl)
VALUES
    ('Ahmet', 'Y�lmaz', '1990-05-15', 'ahmet.yilmaz@example.com', '1234567890', '123 Anayurt Cad.', '�stanbul', 'T�rkiye', 'photo1.jpg'),
    ('Ay�e', 'Kara', '1985-09-30', 'ayse.kara@example.com', '9876543210', '456 Ye�ilyurt Sok.', 'Ankara', 'T�rkiye', 'photo2.jpg'),
    ('Mehmet', 'Demir', '1982-03-25', 'mehmet.demir@example.com', '5551234567', '789 Mavili Mah.', '�zmir', 'T�rkiye', 'photo3.jpg'),
    ('Fatma', 'K�l��', '1995-11-02', 'fatma.kilic@example.com', '4447890123', '321 G�m�� Sk.', 'Bursa', 'T�rkiye', 'photo4.jpg'),
    ('Osman', '�elik', '1991-07-10', 'osman.celik@example.com', '2224567890', '567 K�rm�z� Bulv.', 'Antalya', 'T�rkiye', 'photo5.jpg'),
    ('Zeynep', 'Y�ld�r�m', '1988-12-18', 'zeynep.yildirim@example.com', '6669876543', '891 Beyaz Cad.', 'Adana', 'T�rkiye', 'photo6.jpg'),
    ('Mustafa', 'Arslan', '1980-04-09', 'mustafa.arslan@example.com', '1115557890', '753 Turuncu Sok.', 'Konya', 'T�rkiye', 'photo7.jpg'),
    ('Havva', 'Ta�', '1993-02-28', 'havva.tas@example.com', '7774443330', '159 Pembe Mah.', 'Diyarbak�r', 'T�rkiye', 'photo8.jpg'),
    ('Ali', 'Erdo�an', '1987-06-12', 'ali.erdogan@example.com', '9991234560', '246 Mor Sk.', 'Gaziantep', 'T�rkiye', 'photo9.jpg'),
    ('Elif', 'Ayd�n', '1984-08-22', 'elif.aydin@example.com', '2229993330', '357 Siyah Bulv.', 'Eski�ehir', 'T�rkiye', 'photo10.jpg');

select COUNT(*) From People