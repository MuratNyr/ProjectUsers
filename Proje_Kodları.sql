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
    ('Ahmet', 'Yýlmaz', '1990-05-15', 'ahmet.yilmaz@example.com', '1234567890', '123 Anayurt Cad.', 'Ýstanbul', 'Türkiye', 'photo1.jpg'),
    ('Ayþe', 'Kara', '1985-09-30', 'ayse.kara@example.com', '9876543210', '456 Yeþilyurt Sok.', 'Ankara', 'Türkiye', 'photo2.jpg'),
    ('Mehmet', 'Demir', '1982-03-25', 'mehmet.demir@example.com', '5551234567', '789 Mavili Mah.', 'Ýzmir', 'Türkiye', 'photo3.jpg'),
    ('Fatma', 'Kýlýç', '1995-11-02', 'fatma.kilic@example.com', '4447890123', '321 Gümüþ Sk.', 'Bursa', 'Türkiye', 'photo4.jpg'),
    ('Osman', 'Çelik', '1991-07-10', 'osman.celik@example.com', '2224567890', '567 Kýrmýzý Bulv.', 'Antalya', 'Türkiye', 'photo5.jpg'),
    ('Zeynep', 'Yýldýrým', '1988-12-18', 'zeynep.yildirim@example.com', '6669876543', '891 Beyaz Cad.', 'Adana', 'Türkiye', 'photo6.jpg'),
    ('Mustafa', 'Arslan', '1980-04-09', 'mustafa.arslan@example.com', '1115557890', '753 Turuncu Sok.', 'Konya', 'Türkiye', 'photo7.jpg'),
    ('Havva', 'Taþ', '1993-02-28', 'havva.tas@example.com', '7774443330', '159 Pembe Mah.', 'Diyarbakýr', 'Türkiye', 'photo8.jpg'),
    ('Ali', 'Erdoðan', '1987-06-12', 'ali.erdogan@example.com', '9991234560', '246 Mor Sk.', 'Gaziantep', 'Türkiye', 'photo9.jpg'),
    ('Elif', 'Aydýn', '1984-08-22', 'elif.aydin@example.com', '2229993330', '357 Siyah Bulv.', 'Eskiþehir', 'Türkiye', 'photo10.jpg');

select COUNT(*) From People