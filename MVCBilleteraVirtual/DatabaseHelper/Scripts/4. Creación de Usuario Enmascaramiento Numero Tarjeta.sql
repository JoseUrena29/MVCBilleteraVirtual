/*  I Parcial Programación V
    Estudiante: Jose Ureña Aguilar*/

--Creación de Usuario para prueba de enmascaramiento de numero de tarjeta
CREATE USER Usuario without login;

--Asignacion de permisos al usuario
GRANT SELECT ON Tarjetas TO Usuario;

--Ejecución de una consulta con el usuario creado
EXEC ('Select * From Tarjetas') AS USER='Usuario';
GO