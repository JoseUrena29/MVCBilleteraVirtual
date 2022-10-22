/*  I Parcial Programaci�n V
    Estudiante: Jose Ure�a Aguilar*/

CREATE DATABASE BilleteraVirtual

USE BilleteraVirtual

--Creaci�n de la Tabla Tarjetas
CREATE TABLE Tarjetas(
IDTarjeta int NOT NULL IDENTITY(1,1),
Due�o VARCHAR(30) NOT NULL,
Banco VARCHAR(30) NOT NULL,
Emisor VARCHAR(30) NOT NULL,
NumeroTarjeta VARCHAR(30) MASKED WITH (FUNCTION = 'partial(0,"XXXX-XXXX-XXXX", 4)') NOT NULL,
CodigoCVV VARCHAR(30) NOT NULL,
FechaExpiracion VARCHAR(30) NOT NULL,
FotoBanco VARCHAR(30) NOT NULL,
FotoEmisor VARCHAR(30) NOT NULL

--Primary key
CONSTRAINT PKTarjetas PRIMARY KEY(IDTarjeta)
)

INSERT INTO Tarjetas(
			Due�o,
			Banco,
			Emisor,
			NumeroTarjeta,
			CodigoCVV,
			FechaExpiracion,
			FotoBanco,
			FotoEmisor)
VALUES
('Jose Ure�a','BNCR','Mastercard','5518980268905125','352','06/2024','/images/BNCR.jpg','/images/Mastercard.jpg')


ALTER TABLE Tarjetas ALTER COLUMN NumeroTarjeta ADD MASKED WITH (FUNCTION = 'partial(0,"XXXX-XXXX-XXXX", 4)');

SELECT * FROM Tarjetas

EXEC ('Select * From Tarjetas') AS USER='Usuario';
GO