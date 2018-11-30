CREATE TABLE usuarios (
	idusuario INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
	nombre VARCHAR(50) NULL DEFAULT NULL,
	appaterno VARCHAR(50) NULL DEFAULT NULL,
	apmaterno VARCHAR(50) NULL DEFAULT NULL,
	idusuarioregistro INT NULL DEFAULT NULL,
	horaregistro TIME NULL DEFAULT NULL,
	fecharegistro DATE NULL DEFAULT NULL,
	correo VARCHAR(100) NULL DEFAULT NULL,
	nick VARCHAR(45) NOT NULL,
	contrasena VARCHAR(45) NOT NULL
);

CREATE TABLE ingresos (
	idingreso INT NOT NULL identity(1,1) primary key,
	cantidad_inicial DECIMAL NULL,
	cantidad_actual DECIMAL NULL ,
	fecha DATE NOT NULL DEFAULT '0000-00-00'
);

CREATE TABLE gastos (
	idgasto INT PRIMARY KEY identity(1,1),
	nombre VARCHAR(100) NOT NULL,
	estatus INT NOT NULL,
	dia_corte INT NOT NULL,
	dia_limite_pago INT NOT NULL,
	fechaalta DATE NOT NULL,
	horaalta TIME NOT NULL,
	idusuario INT NOT NULL,
	total DECIMAL(16,2) NOT NULL
)


CREATE TABLE deudas (
	iddeuda INT NOT NULL,
	nombreDeuda TEXT NOT NULL,
	estatus TINYINT NOT NULL DEFAULT '1',
	dia_corte SMALLINT NULL DEFAULT NULL,
	dia_limite_pago INT NULL DEFAULT NULL,
	fechaalta DATE NOT NULL,
	horaalta TIME NOT NULL,
	idusuario INT NOT NULL,
	PRIMARY KEY (iddeuda),
	CONSTRAINT fk_Usuarios FOREIGN KEY (idusuario) REFERENCES usuarios (idusuario)
);

CREATE TABLE usuario_deudas (
	iddeuda INT NOT NULL,
	idusuario INT NOT NULL,
	PRIMARY KEY (iddeuda, idusuario),
	FOREIGN KEY (iddeuda) REFERENCES deudas (iddeuda),
	FOREIGN KEY (idusuario) REFERENCES usuarios (idusuario)
	-- FOREIGN KEY (dep) REFERENCES departamentos(dep) 
);


CREATE TABLE detalle_deuda (
	iddeuda INT NOT NULL,
	cantidad DECIMAL(16,2) NOT NULL DEFAULT '0.00',
	PRIMARY KEY (iddeuda),
	CONSTRAINT fk_deudadetalle FOREIGN KEY (iddeuda) REFERENCES deudas (iddeuda)
);

CREATE TABLE cargos_deudas (
	idcargo INT NOT NULL identity(1,1),
	iddeuda INT NULL DEFAULT '0',
	idusuario INT NOT NULL DEFAULT '0',
	cantidad DECIMAL(16,2) NULL DEFAULT '0.00',
	fechahoracargo datetime NULL DEFAULT  GETDATE(),
	PRIMARY KEY (idcargo),
	CONSTRAINT fk_cargodeuda FOREIGN KEY (iddeuda) REFERENCES deudas (iddeuda),
	CONSTRAINT fk_cargousuario FOREIGN KEY (idusuario) REFERENCES usuarios (idusuario)
);

CREATE TABLE abonos_deuda (
	idabono INT NOT NULL identity(1,1),
	iddeuda INT NOT NULL DEFAULT '0',
	idusuario INT NOT NULL DEFAULT '0',
	idingreso INT NULL DEFAULT NULL,
	cantidad DECIMAL(16,2) NOT NULL DEFAULT '0.00',
	fechahora datetime NOT NULL DEFAULT getdate(),
	PRIMARY KEY (idabono),
	CONSTRAINT fk_deudaabono FOREIGN KEY (iddeuda) REFERENCES deudas (iddeuda),
	CONSTRAINT fk_ingresoabono FOREIGN KEY (idingreso) REFERENCES ingresos (idingreso),
	CONSTRAINT fk_usuarioabono FOREIGN KEY (idusuario) REFERENCES usuarios (idusuario)
)