using senai.Roman.webAPI.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai.Roman.webAPI.Interfaces
{
    /// <summary>
    /// Interface responsável pelo ProfessorRepository
    /// </summary>
    interface IProfessorRepository
    {
        /// <summary>
        /// Listar todas os Professores
        /// </summary>
        /// <returns>Lista de Professores</returns>
        List<Professor> Listar();

        /// <summary>
        /// Buscar Professor pelo ID
        /// </summary>
        /// <param name="idProfessor">ID do Professor que será buscado</param>
        /// <returns>Professor encontrada</returns>
        Professor BuscarPorId(int idProfessor);

        /// <summary>
        /// Cadastrar uma Professor
        /// </summary>
        /// <param name="novoProfessor">Objeto novoProfessor com as todas as informações</param>
        void Cadastrar(Professor novoProfessor);

        /// <summary>
        /// Atualizar os dados de um Professor
        /// </summary>
        /// <param name="idProfessor">ID do Professor que será atualizada</param>
        /// <param name="ProfessorAtualizado">Objeto ProfessorAtualizado com as novas informações</param>
        void Atualizar(int idProfessor, Professor ProfessorAtualizado);

        /// <summary>
        /// Deletar uma Professor
        /// </summary>
        /// <param name="idProfessor">ID do Professor que será deletado</param>
        void Deletar(int idProfessor);
    }
}
