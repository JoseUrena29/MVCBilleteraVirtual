/*  I Parcial Programaci�n V
    Estudiante: Jose Ure�a Aguilar*/

CREATE OR ALTER PROCEDURE spGetTarjetas

AS
BEGIN

EXEC ('Select * From Tarjetas') AS USER='Usuario';

END
GO