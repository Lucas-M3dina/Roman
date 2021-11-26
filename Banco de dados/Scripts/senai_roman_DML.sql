USE ROMAN;
GO

INSERT INTO tema(nomeTema)
VALUES ('HQ'),('Gestão');
GO

INSERT INTO tipoUsuario(tituloTipoUsuario)
VALUES ('Administrador'),('Professor');
GO

INSERT INTO usuario(idTipoUsuario, email, senha)
VALUES (1,'saulo@gmail.com','C# melhor que python'),
       (1,'lucas@gmail.com','123');
GO

INSERT INTO professor(idUsuario, nomeProfessor)
VALUES (1,'Saulo'),
       (2,'Lucas');
GO

INSERT INTO projeto(idProfessor, idTema, nomeProjeto, descricao)
VALUES (1, 1, 'Projeto de Controle de Estoque', 'Lista os personagens da DC e Marvel'),
       (2, 2, 'Projeto de Listagem de Personagens', 'Faz o controle de estoque de uma loja');
GO