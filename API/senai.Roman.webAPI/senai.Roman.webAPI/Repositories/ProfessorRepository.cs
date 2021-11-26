using Microsoft.EntityFrameworkCore;
using senai.Roman.webAPI.Contexts;
using senai.Roman.webAPI.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai.Roman.webAPI.Repositories
{
    public class ProfessorRepository
    {
        RomanContext ctx = new RomanContext();

        public void Atualizar(int idProfessor, Professor professorAtualizado)
        {
            Professor professorBuscado = BuscarPorId(idProfessor);

            if (professorAtualizado.NomeProfessor != null)
            {
                professorBuscado.NomeProfessor = professorAtualizado.NomeProfessor;
            }

            ctx.Professores.Update(professorBuscado);

            ctx.SaveChanges();
        }

        public Projeto BuscarPorId(int idProfessor)
        {
            return ctx.Projetos.Include(t => t.Temas).FirstOrDefault(p => p.idProfessor == idProfessor);
        }

        public void Cadastrar(Projeto novoProjeto)
        {
            ctx.Projetos.Add(novoProjeto);

            ctx.SaveChanges();
        }

        public void Deletar(int idProfessor)
        {
            Projeto projetoBuscado = BuscarPorId(idProfessor);

            ctx.Projetos.Remove(projetoBuscado);

            ctx.SaveChanges();
        }

        public List<Projeto> Listar()
        {
            return ctx.Projetos.Include(t => t.Temas).OrderBy(p => p.idProfessor).ToList();
        }
    }
}
