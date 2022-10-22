/*  I Parcial Programaci�n V
    Estudiante: Jose Ure�a Aguilar*/

CREATE OR ALTER PROCEDURE spAgregarTarjeta

	@Due�o VARCHAR(30),
	@Banco VARCHAR(30),
	@Emisor VARCHAR(30),
	@NumeroTarjeta VARCHAR(30),
	@CodigoCVV VARCHAR(30),
	@FechaExpiracion VARCHAR(30),
	@FotoBanco VARCHAR(30),
	@FotoEmisor VARCHAR(30)
AS
BEGIN

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
	(@Due�o,
	@Banco,
	@Emisor,
	@NumeroTarjeta,
	@CodigoCVV,
	@FechaExpiracion,
	@FotoBanco,
	@FotoEmisor)

END
GO