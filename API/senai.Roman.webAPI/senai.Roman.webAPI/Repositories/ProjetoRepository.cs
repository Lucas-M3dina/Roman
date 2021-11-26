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
    public class ProjetoRepository : IProjetoRepository
    {
        RomanContext ctx = new RomanContext();

        public void Atualizar(int idProjeto, Projeto projetoAtualizado)
        {
            Projeto projetoBuscado = BuscarPorId(idProjeto);

            if (projetoAtualizado.NomeProjeto != null)
            {
                projetoBuscado.NomeProjeto = projetoAtualizado.NomeProjeto;
            }

            if (projetoAtualizado.Descricao != null)
            {
                projetoBuscado.Descricao = projetoAtualizado.Descricao;
            }

            ctx.Projetos.Update(projetoBuscado);

            ctx.SaveChanges();
        }

        public Projeto BuscarPorId(int idProjeto)
        {
            return ctx.Projetos.Include(t => t.Temas).FirstOrDefault(p => p.IdProjeto == idProjeto);
        }

        public void Cadastrar(Projeto novoProjeto)
        {
            ctx.Projetos.Add(novoProjeto);

            ctx.SaveChanges();
        }

        public void Deletar(int idProjeto)
        {
            Projeto projetoBuscado = BuscarPorId(idProjeto);

            ctx.Projetos.Remove(projetoBuscado);

            ctx.SaveChanges();
        }

        public List<Projeto> Listar()
        {
            return ctx.Projetos.Include(t => t.Temas).OrderBy(p => p.IdProjeto).ToList();
        }
    }
}
