USE SENAI_ROMAN;
GO

-- Listar todas as entidades
SELECT  * FROM tema;
GO

SELECT  * FROM tipoUsuario;
GO

SELECT  * FROM usuario;
GO

SELECT  * FROM professor;
GO

SELECT  * FROM projeto;
GO

--Listar todos os projetos, sem id e mostrando todos os dados relacionados a ela
SELECT nomeProfessor 'Professor', nomeTema 'Tema', nomeProjeto 'Nome do Projeto', descricao 'Descrição'

FROM projeto 
INNER JOIN professor ON projeto.idProfessor = professor.idProfessor
INNER JOIN tema ON projeto.idTema = tema.idTema