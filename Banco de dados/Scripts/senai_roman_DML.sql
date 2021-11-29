USE SENAI_ROMAN;
GO

INSERT INTO tema(nomeTema)
VALUES ('HQ'),('Gestão');
GO

INSERT INTO tipoUsuario(tituloTipoUsuario)
VALUES ('Administrador'),('Professor');
GO

INSERT INTO usuario(idTipoUsuario, email, senha)
VALUES (1,'saulo@gmail.com','C# melhor que python'),
       (1,'lucas@gmail.com','123'),
	   (2,'gustavo@gmail.com','1234'),
       (2,'medina@gmail.com','1234');
GO

INSERT INTO professor(idUsuario, nomeProfessor)
VALUES (1,'Saulo'),
       (2,'Lucas'),
	   (3, 'Gustavo'),
	   (4, 'Lucas Medina');
GO

INSERT INTO projeto(idProfessor, idTema, nomeProjeto, descricao)
VALUES (3, 2, 'Projeto de Controle de Estoque do Senai', 'Faz o controle de estoque do senai'),
       (4, 1, 'Projeto de Listagem de Personagens de series', 'Lista os personagens de series da netflix');
GO