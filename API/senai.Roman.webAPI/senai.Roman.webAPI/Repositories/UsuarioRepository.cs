using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using senai.Roman.webAPI.Contexts;
using senai.Roman.webAPI.Domains;
using senai.Roman.webAPI.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace senai.Roman.webAPI.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        RomanContext ctx = new RomanContext();

        public void Cadastrar(Usuario novoUsuario)
        {
            ctx.Usuarios.Add(novoUsuario);

            ctx.SaveChanges();
        }

        public Usuario Login(string email, string senha)
        {
            return ctx.Usuarios.Include(tu => tu.IdTipoUsuarioNavigation).FirstOrDefault(tu => tu.Email == email && tu.Senha == senha);
        }
    }
}
