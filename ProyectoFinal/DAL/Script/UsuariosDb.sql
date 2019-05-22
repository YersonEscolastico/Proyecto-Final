Create database UsuariosDb;

create table Usuarios(
UsuarioId int primary key identity,
Nombre varchar(30),
Email  varchar(30),
Usuarios varchar(30),
NivelUsuario varchar(30),
Clave varchar(30),
FechaIngreso DateTime
)