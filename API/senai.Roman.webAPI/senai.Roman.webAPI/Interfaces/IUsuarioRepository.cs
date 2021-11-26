using senai.Roman.webAPI.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai.Roman.webAPI.Interfaces
{
    /// <summary>
    /// Interface responsável pelo UsuarioRepository
    /// </summary>
    interface IUsuarioRepository
    {
        /// <summary>
        /// Cadastrar um usuário
        /// </summary>
        /// <param name="novoUsuario">Objeto novoUsuario com as todas as informações</param>
        void Cadastrar(Usuario novoUsuario);

        Usuario Login(string email, string senha);
    }
}
