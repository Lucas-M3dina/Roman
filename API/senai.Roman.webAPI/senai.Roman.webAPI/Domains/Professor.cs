using System;
using System.Collections.Generic;

#nullable disable

namespace senai.Roman.webAPI.Domains
{
    public partial class Professor
    {
        public Professor()
        {
            Projetos = new HashSet<Projeto>();
        }

        public int IdProfessor { get; set; }
        public int? IdUsuario { get; set; }
        public string NomeProfessor { get; set; }

        public virtual Usuario IdUsuarioNavigation { get; set; }
        public virtual ICollection<Projeto> Projetos { get; set; }
    }
}
