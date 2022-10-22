/*  I Parcial Programación V
    Estudiante: Jose Ureña Aguilar*/

CREATE OR ALTER PROCEDURE spGetTarjetas

AS
BEGIN

EXEC ('Select * From Tarjetas') AS USER='Usuario';

END
GO