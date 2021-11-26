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
            throw new NotImplementedException();
        }

        public Projeto BuscarPorId(int idProjeto)
        {
            throw new NotImplementedException();
        }

        public void Cadastrar(Projeto novoProjeto)
        {
            ctx.Projetos.Add(novoProjeto);

            ctx.SaveChanges();
        }

        public void Deletar(int idProjeto)
        {
            throw new NotImplementedException();
        }

        public List<Projeto> Listar()
        {
            throw new NotImplementedException();
        }

        public List<Projeto> ListarProjetosProfessor(int idProfessor)
        {
            return ctx.Projetos
            .Select(p => new Projeto()
            {
                IdProjeto = p.IdProjeto,
                NomeProjeto = p.NomeProjeto,
                Descricao = p.Descricao,

                IdTemaNavigation = new Tema
                {
                    IdTema = p.IdTemaNavigation.IdTema,
                    NomeTema = p.IdTemaNavigation.NomeTema
                },

                IdProfessorNavigation = new Professor()
                {
                    IdProfessor = p.IdProfessorNavigation.IdProfessor,
                    NomeProfessor = p.IdProfessorNavigation.NomeProfessor,

                    IdUsuarioNavigation = new Usuario()
                    {

                        IdUsuario = p.IdProfessorNavigation.IdUsuarioNavigation.IdUsuario,
                        Email = p.IdProfessorNavigation.IdUsuarioNavigation.Email,
                        
                        IdTipoUsuarioNavigation = new TipoUsuario()
                        {
                            IdTipoUsuario = p.IdProfessorNavigation.IdUsuarioNavigation.IdTipoUsuarioNavigation.IdTipoUsuario,
                            TituloTipoUsuario = p.IdProfessorNavigation.IdUsuarioNavigation.IdTipoUsuarioNavigation.TituloTipoUsuario,
                        }
                    }
                }
            })

            .Where(p => p.IdProfessorNavigation.IdProfessor == idProfessor)

            .OrderBy(p => p.IdProjeto)
            .ToList();
        }
    }
}
