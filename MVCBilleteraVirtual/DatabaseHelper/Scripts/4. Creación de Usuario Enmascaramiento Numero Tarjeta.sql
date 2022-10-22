/*  I Parcial Programaci�n V
    Estudiante: Jose Ure�a Aguilar*/

--Creaci�n de Usuario para prueba de enmascaramiento de numero de tarjeta
CREATE USER Usuario without login;

--Asignacion de permisos al usuario
GRANT SELECT ON Tarjetas TO Usuario;

--Ejecuci�n de una consulta con el usuario creado
EXEC ('Select * From Tarjetas') AS USER='Usuario';
GO