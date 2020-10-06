CREATE DATABASE PlaceMyBet;
USE PlaceMyBet;

CREATE TABLE Evento (

idEvento INT PRIMARY KEY,
equipoLocal VARCHAR(45),
equipoVisitante VARCHAR(45),
fecha VARCHAR(45)
);

CREATE TABLE Mercado (

idMercado INT PRIMARY KEY,
infocuotaOver DOUBLE,
infocuotaUnder DOUBLE,
dineroapostadoOver DOUBLE,
dineroapostadoUnder DOUBLE,
idEvento INT,
FOREIGN KEY (idEvento) REFERENCES Evento (idEvento)
);


CREATE TABLE Usuario (

idUsuario INT,
Email VARCHAR(45),
PRIMARY KEY (idUsuario, Email),
Nombre VARCHAR(45),
Apellidos VARCHAR(45),
Edad INT

);

CREATE TABLE CBancaria (

idCBancaria INT PRIMARY KEY,
saldoBanco INT,
nombreBanco VARCHAR(45),
numtarCredito INT,
idUsuario INT,
FOREIGN KEY (idUsuario) REFERENCES Usuario (idUsuario)
);

CREATE TABLE Apuesta (

idApuesta INT PRIMARY KEY,
tipoApuesta BOOL,
cuota DOUBLE,
dineroApostado DOUBLE,
fecha VARCHAR(45),
idUsuario INT,
idMercado INT,
FOREIGN KEY (idUsuario) REFERENCES Usuario (idUsuario),
FOREIGN KEY (idMercado) REFERENCES Mercado (idMercado)
);