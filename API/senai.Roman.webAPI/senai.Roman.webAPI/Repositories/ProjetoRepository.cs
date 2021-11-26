using Microsoft.EntityFrameworkCore;
using senai.Roman.webAPI.Contexts;
using senai.Roman.webAPI.Domains;
using senai.Roman.webAPI.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai.Roman.webAPI.Repositories
{
    public class ProjetoRepository
    {
        RomanContext ctx = new RomanContext();

        

        

        public void Cadastrar(Projeto novoProjeto)
        {
            ctx.Projetos.Add(novoProjeto);

            ctx.SaveChanges();
        }

        

        
    }
}
