/* Dodavanje Turnira u bazu */

SET IDENTITY_INSERT Turnir ON;
/* Nisam povezivao tabele, tako da moram sam da određujem ključ kada ubacujem uz ppmoć sql-a */

INSERT INTO Turnir (ID, Naziv, MaxDisciplina) VALUES (1,'Olimpijada', 20);
INSERT INTO Turnir (ID, Naziv, MaxDisciplina) VALUES (2,'Azijske Igre', 15);
INSERT INTO Turnir (ID, Naziv, MaxDisciplina) VALUES (3,'Paralimpijada', 10);

SET IDENTITY_INSERT Turnir OFF;


/* Dodavanje Disciplina u bazu */
SET IDENTITY_INSERT Disciplina ON;

/* U Turnir sa ID-om {1} */
INSERT INTO Disciplina (ID, TurnirID, Naziv, Lokacija, Maksimalni_Broj_Učesnika) VALUES (1, 1, 'Konjički skokovi', 'Camp Nou', 20);
INSERT INTO Disciplina (ID, TurnirID, Naziv, Lokacija, Maksimalni_Broj_Učesnika) VALUES (2, 1, 'Umetnička gimnastika', 'Stade Velodrome', 30);
INSERT INTO Disciplina (ID, TurnirID, Naziv, Lokacija, Maksimalni_Broj_Učesnika) VALUES (3, 1, 'Kajakaštvo', 'Tisa', 10);
INSERT INTO Disciplina (ID, TurnirID, Naziv, Lokacija, Maksimalni_Broj_Učesnika) VALUES (4, 1, 'Vožnja bicikle - planina', 'Kopaonik', 16);
INSERT INTO Disciplina (ID, TurnirID, Naziv, Lokacija, Maksimalni_Broj_Učesnika) VALUES (5, 1, 'Plivanje', 'Krestovsky Stadium', 40);
INSERT INTO Disciplina (ID, TurnirID, Naziv, Lokacija, Maksimalni_Broj_Učesnika) VALUES (6, 1, 'Šah', 'Štar Arena', 40);

/* U Turnir sa ID-om {2} */
INSERT INTO Disciplina (ID, TurnirID, Naziv, Lokacija, Maksimalni_Broj_Učesnika) VALUES (7, 2, 'Vaterpolo', 'Salt Lake Stadium', 40);
INSERT INTO Disciplina (ID, TurnirID, Naziv, Lokacija, Maksimalni_Broj_Učesnika) VALUES (8, 2, 'Jujitsu', 'Azadi Stadium', 30);
INSERT INTO Disciplina (ID, TurnirID, Naziv, Lokacija, Maksimalni_Broj_Učesnika) VALUES (9, 2, 'Tenis', 'Yokohama Stadium', 10);
INSERT INTO Disciplina (ID, TurnirID, Naziv, Lokacija, Maksimalni_Broj_Učesnika) VALUES (10, 2, 'Paraglajding', 'Guangdong Olympic Stadium', 15);

/* U Turnir sa ID-om {3} */
INSERT INTO Disciplina (ID, TurnirID, Naziv, Lokacija, Maksimalni_Broj_Učesnika) VALUES (11, 3, 'Skijanje', 'Alpi', 20);
INSERT INTO Disciplina (ID, TurnirID, Naziv, Lokacija, Maksimalni_Broj_Učesnika) VALUES (12, 3, 'Streljaštvo', 'Ataturk Olympic Stadium', 20);
INSERT INTO Disciplina (ID, TurnirID, Naziv, Lokacija, Maksimalni_Broj_Učesnika) VALUES (13, 3, 'Veslanje - slalom', 'Athens Olympic Stadium', 20);

SET IDENTITY_INSERT Disciplina OFF;


/* Dodavanje Učesnika u bazu */

/* Na Turnir sa ID-om {1} */
/* Na Disciplinu sa ID-om {1} */
INSERT INTO Učesnik (DisciplinaID, TurnirID, Ime, Prezime, Brzina) VALUES (1, 1, 'Petar', 'Pavlović', 20);
INSERT INTO Učesnik (DisciplinaID, TurnirID, Ime, Prezime, Brzina) VALUES (1, 1, 'Richard', 'Morris', 22);
INSERT INTO Učesnik (DisciplinaID, TurnirID, Ime, Prezime, Brzina) VALUES (1, 1, 'Nick', 'Birch', 21);
INSERT INTO Učesnik (DisciplinaID, TurnirID, Ime, Prezime, Brzina) VALUES (1, 1, 'Jessie', 'Richards', 20);
INSERT INTO Učesnik (DisciplinaID, TurnirID, Ime, Prezime, Brzina) VALUES (1, 1, 'Emilija', 'Ostojić', 21);

/* Na Turnir sa ID-om {1} */
/* Na Disciplinu sa ID-om {2} */
INSERT INTO Učesnik (DisciplinaID, TurnirID, Ime, Prezime, Brzina) VALUES (2, 1, 'Homer', 'Simpson', 23);
INSERT INTO Učesnik (DisciplinaID, TurnirID, Ime, Prezime, Brzina) VALUES (2, 1, 'Elijah', 'Gnome', 22);
INSERT INTO Učesnik (DisciplinaID, TurnirID, Ime, Prezime, Brzina) VALUES (2, 1, 'Olivia', 'OBrien', 25);

/* Na Turnir sa ID-om {1} */
/* Na Disciplinu sa ID-om {3} */
INSERT INTO Učesnik (DisciplinaID, TurnirID, Ime, Prezime, Brzina) VALUES (3, 1, 'Melanija', 'Martinez', 28);
INSERT INTO Učesnik (DisciplinaID, TurnirID, Ime, Prezime, Brzina) VALUES (3, 1, 'Steve', 'Renolds', 25);
INSERT INTO Učesnik (DisciplinaID, TurnirID, Ime, Prezime, Brzina) VALUES (3, 1, 'Osman', 'Kajić', 26);

/* Na Turnir sa ID-om {1} */
/* Na Disciplinu sa ID-om {4} */
INSERT INTO Učesnik (DisciplinaID, TurnirID, Ime, Prezime, Brzina) VALUES (4, 1, 'Pabllo', 'Escobar', 27);
INSERT INTO Učesnik (DisciplinaID, TurnirID, Ime, Prezime, Brzina) VALUES (4, 1, 'SpongeBob', 'Squarepants', 29);
INSERT INTO Učesnik (DisciplinaID, TurnirID, Ime, Prezime, Brzina) VALUES (4, 1, 'Millie', 'Morris', 27);

/* Na Turnir sa ID-om {1} */
/* Na Disciplinu sa ID-om {5} */
INSERT INTO Učesnik (DisciplinaID, TurnirID, Ime, Prezime, Brzina) VALUES (5, 1, 'Miley', 'Kahn', 25);
INSERT INTO Učesnik (DisciplinaID, TurnirID, Ime, Prezime, Brzina) VALUES (5, 1, 'Steve', 'Nicks', 24);
INSERT INTO Učesnik (DisciplinaID, TurnirID, Ime, Prezime, Brzina) VALUES (5, 1, 'Marko', 'Stević', 26);

/* Na Turnir sa ID-om {1} */
/* Na Disciplinu sa ID-om {6} */
INSERT INTO Učesnik (DisciplinaID, TurnirID, Ime, Prezime, Brzina) VALUES (6, 1, 'Luka', 'Obradović', 26);
INSERT INTO Učesnik (DisciplinaID, TurnirID, Ime, Prezime, Brzina) VALUES (6, 1, 'Manuel', 'Rodriguez', 26);
INSERT INTO Učesnik (DisciplinaID, TurnirID, Ime, Prezime, Brzina) VALUES (6, 1, 'Katherine', 'Minaj', 26);
INSERT INTO Učesnik (DisciplinaID, TurnirID, Ime, Prezime, Brzina) VALUES (6, 1, 'Stefan', 'Aleksić', 26);
INSERT INTO Učesnik (DisciplinaID, TurnirID, Ime, Prezime, Brzina) VALUES (6, 1, 'Kiki', 'Salmon', 26);


/* Na Turnir sa ID-om {2} */
/* Na Disciplinu sa ID-om {7} */
INSERT INTO Učesnik (DisciplinaID, TurnirID, Ime, Prezime, Brzina) VALUES (7, 2, 'Seka', 'Amsterdam', 30);
INSERT INTO Učesnik (DisciplinaID, TurnirID, Ime, Prezime, Brzina) VALUES (7, 2, 'Svetlana', 'Enigma', 27);
INSERT INTO Učesnik (DisciplinaID, TurnirID, Ime, Prezime, Brzina) VALUES (7, 2, 'Kilye', 'Monogue', 26);

/* Na Turnir sa ID-om {2} */
/* Na Disciplinu sa ID-om {8} */
INSERT INTO Učesnik (DisciplinaID, TurnirID, Ime, Prezime, Brzina) VALUES (8, 2, 'Dixie', 'Austin', 29);
INSERT INTO Učesnik (DisciplinaID, TurnirID, Ime, Prezime, Brzina) VALUES (8, 2, 'Simon', 'Cruel', 28);
INSERT INTO Učesnik (DisciplinaID, TurnirID, Ime, Prezime, Brzina) VALUES (8, 2, 'Aelita', 'Stevens', 28 );

/* Na Turnir sa ID-om {2} */
/* Na Disciplinu sa ID-om {9} */
INSERT INTO Učesnik (DisciplinaID, TurnirID, Ime, Prezime, Brzina) VALUES (9, 2, 'Amanda', 'Krestić', 30);
INSERT INTO Učesnik (DisciplinaID, TurnirID, Ime, Prezime, Brzina) VALUES (9, 2, 'Stojan', 'Simić', 28);
INSERT INTO Učesnik (DisciplinaID, TurnirID, Ime, Prezime, Brzina) VALUES (9, 2, 'Brzi', 'Gonzales', 27);

/* Na Turnir sa ID-om {2} */
/* Na Disciplinu sa ID-om {10} */
INSERT INTO Učesnik (DisciplinaID, TurnirID, Ime, Prezime, Brzina) VALUES (10, 2, 'Le petit', 'Chaperon rouge', 30);
INSERT INTO Učesnik (DisciplinaID, TurnirID, Ime, Prezime, Brzina) VALUES (10, 2, 'Liddle', 'Sicker', 27);
INSERT INTO Učesnik (DisciplinaID, TurnirID, Ime, Prezime, Brzina) VALUES (10, 2, 'Kawaii', 'Senpai', 27);


/* Na Turnir sa ID-om {3} */
/* Na Disciplinu sa ID-om {11} */
INSERT INTO Učesnik (DisciplinaID, TurnirID, Ime, Prezime, Brzina) VALUES (11, 3, 'Lisa', 'Diamond', 26);
INSERT INTO Učesnik (DisciplinaID, TurnirID, Ime, Prezime, Brzina) VALUES (11, 3, 'Kreina', 'Steings', 27);
INSERT INTO Učesnik (DisciplinaID, TurnirID, Ime, Prezime, Brzina) VALUES (11, 3, 'Sou', 'Yeah', 29);

/* Na Turnir sa ID-om {3} */
/* Na Disciplinu sa ID-om {12} */
INSERT INTO Učesnik (DisciplinaID, TurnirID, Ime, Prezime, Brzina) VALUES (12, 3, 'Petra', 'Stević', 25);
INSERT INTO Učesnik (DisciplinaID, TurnirID, Ime, Prezime, Brzina) VALUES (12, 3, 'Silvija', 'Sretković', 26);
INSERT INTO Učesnik (DisciplinaID, TurnirID, Ime, Prezime, Brzina) VALUES (12, 3, 'Ahasim', 'Stock', 28);

/* Na Turnir sa ID-om {3} */
/* Na Disciplinu sa ID-om {13} */
INSERT INTO Učesnik (DisciplinaID, TurnirID, Ime, Prezime, Brzina) VALUES (13, 3, 'Peter', 'Mallard', 24);
INSERT INTO Učesnik (DisciplinaID, TurnirID, Ime, Prezime, Brzina) VALUES (13, 3, 'Tina', 'Hecks', 25);
INSERT INTO Učesnik (DisciplinaID, TurnirID, Ime, Prezime, Brzina) VALUES (13, 3, 'Rajna', 'Majnić', 26);