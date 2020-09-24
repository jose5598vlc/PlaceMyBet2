CREATE DATABASE PlaceMyBet;
USE PlaceMyBet;

CREATE TABLE Evento (

idEvento INT PRIMARY KEY,
equipoLocal VARCHAR(45),
equipoVisitante VARCHAR(45),
fecha DATE
)

CREATE TABLE Mercado (

idMercado INT PRIMARY KEY,
infocuotaOver INT,
infocuotaUnder INT,
dineroapostadoOver INT,
dineroapostadoUnder INT,
FOREIGN KEY (idEvento) REFERENCES Evento(idEvento)
)


CREATE TABLE Usuario (

idUsuario INT,
Email INT PRIMARY KEY,
Nombre VARCHAR(45),
Apellidos VARCHAR(45),
Edad INT

)

CREATE CBancaria (

idCBancaria INT PRIMARY KEY,
saldoBanco INT,
nombreBanco VARCHAR(45),
numtarCredito INT,
FOREIGN KEY (idUsuario) REFERENCES Usuario(idUsuario)

)

CREATE TABLE APUESTA (

idApuesta INT PRIMARY KEY,
tipoApuesta BOOL,
cuota INT,
dineroApostado INT,
fecha DATE,
FOREIGN KEY (idUsuario) REFERENCES Usuario(idUsuario)
FOREIGN KEY (idMercado) REFERENCES Mercado(idMercado)
)

);