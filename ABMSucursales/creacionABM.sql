CREATE database ABMSucursales
USE ABMSucursales

CREATE TABLE ResponsableSucursal (
	id_responsable int PRIMARY KEY,
	nombre_responsable varchar(20) NOT NULL,
	apellido_responsable varchar(20) NOT NULL,
	cargo_responsable varchar(20),
	email_responsable varchar(50) NOT NULL,
	telefono_responsable varchar(16) NOT NULL,
	horario_atencion_apertura time NOT NULL,
	horario_atencion_clausura time NOT NULL
)

CREATE TABLE Sucursal (
	id_sucursal int PRIMARY KEY,
	nombre_sucursal varchar(50) NOT NULL,
	direccion_sucursal text NOT NULL,
	telefono_sucursal varchar(16) NOT NULL,
	email_sucursal varchar(50) NOT NULL,
	area_sucursal varchar(50) NOT NULL,
	numero_empleados_sucursal int,
	horario_atencion_apertura time NOT NULL,
	horario_atencion_clausura time NOT NULL,
	observaciones text,
	id_responsable int foreign key references ResponsableSucursal(id_responsable)
)