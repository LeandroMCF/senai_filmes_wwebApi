using senai_filmes_wwebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_filmes_wwebApi.Interfaces
{
    interface IUsuarioRepository
    {
        UsuarioDomain Login(string email, string senha);
    }
}
