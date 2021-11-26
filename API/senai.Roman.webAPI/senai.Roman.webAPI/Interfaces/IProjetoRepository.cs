using senai.Roman.webAPI.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai.Roman.webAPI.Interfaces
{
    /// <summary>
    /// Interface responsável pelo ProjetoRepository
    /// </summary>
    interface IProjetoRepository
    {
        /// <summary>
        /// Listar todas os Projetos
        /// </summary>
        /// <returns>Lista de Projetos</returns>
        List<Projeto> Listar();

        /// <summary>
        /// Buscar Projeto pelo ID
        /// </summary>
        /// <param name="idProjeto">ID do Projeto que será buscado</param>
        /// <returns>Projeto encontrada</returns>
        Projeto BuscarPorId(int idProjeto);

        /// <summary>
        /// Cadastrar um Projeto
        /// </summary>
        /// <param name="novoProjeto">Objeto novoProjeto com as todas as informações</param>
        void Cadastrar(Projeto novoProjeto);

        /// <summary>
        /// Atualizar os dados de um Projeto
        /// </summary>
        /// <param name="idProjeto">ID do Projeto que será atualizada</param>
        /// <param name="projetoAtualizado">Objeto ProjetoAtualizado com as novas informações</param>
        void Atualizar(int idProjeto, Projeto projetoAtualizado);

        /// <summary>
        /// Deletar uma Projeto
        /// </summary>
        /// <param name="idProjeto">ID do Projeto que será deletado</param>
        void Deletar(int idProjeto);
    }
}
