using senai_filmes_wwebApi.Domains;
using senai_filmes_wwebApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace senai_filmes_wwebApi.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private string conexao = "Data Source=DESKTOP-LFIP8ID; initial catalog=Filmes; integrated security=true";
        public UsuarioDomain Login(string email, string senha)
        {
            using (SqlConnection con = new SqlConnection(conexao))
            {
                string querySelect = "SELECT IdUsuario, Email, Senha, Permissoes FROM Usuarios WHERE Email = '" + email + "' AND Senha = '" + senha + "'";

                using (SqlCommand cmd = new SqlCommand(querySelect, con))
                {
                    con.Open();

                    SqlDataReader rdr = cmd.ExecuteReader();

                    if (rdr.Read())
                    {
                        UsuarioDomain usuario = new UsuarioDomain
                        {
                            IdUsuario = Convert.ToInt32(rdr["IdUsuario"]),
                            Email = rdr["Email"].ToString(),
                            Senha = rdr["Senha"].ToString(),
                            Permissao = rdr["Permissoes"].ToString(),
                        };

                        return usuario;
                    }

                    return null;
                }
            }
        }
    }
}
