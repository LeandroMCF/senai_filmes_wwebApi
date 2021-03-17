using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_filmes_wwebApi.Domains
{
    /// <summary>
    ///  Classe que representa a entidade filmes
    /// </summary>
    public class FIlmeDomain
    {
        public int IdFIlme { get; set; }
        public int IdGenero { get; set; }
        public string Titulo { get; set; }
    }
}
