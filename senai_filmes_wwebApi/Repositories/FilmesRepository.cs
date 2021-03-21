using senai_filmes_wwebApi.Domains;
using senai_filmes_wwebApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace senai_filmes_wwebApi.Repositories
{
    public class FilmesRepository : IFilmeRepository
    {
        private string conexao = "Data Source=DESKTOP-LFIP8ID; initial catalog=Filmes; integrated security=true";

        public void AtualizarIdCorpo(FIlmeDomain filme)
        {
            throw new NotImplementedException();
        }

        public void AtualizarIdUrl(int id, FIlmeDomain filme)
        {
            throw new NotImplementedException();
        }

        public FIlmeDomain BuscarPorId(int id)
        {
            throw new NotImplementedException();
        }

        public void Cadastrar(FIlmeDomain novoFilme)
        {
            using (SqlConnection con = new SqlConnection(conexao))
            {
                string cadastrar = "INSERT INTO Filmes(Titulo) VALUES ('" + novoFilme.Titulo + "')";

                con.Open();

                using (SqlCommand cmd = new SqlCommand(cadastrar, con))
                {
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void Deletar(int id)
        {
            using (SqlConnection con = new SqlConnection(conexao))
            {
                string excluindo = "DELETE FROM Filmes WHERE IdFilmes =" + id + "";

                con.Open();

                using (SqlCommand cmd = new SqlCommand(excluindo, con))
                {
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public List<FIlmeDomain> ListarTodos()
        {
            List<FIlmeDomain> listaFilme = new List<FIlmeDomain>();

            using (SqlConnection con = new SqlConnection(conexao))
            {
                string comando = "SELECT IdFilme, Titulo FROM Filmes";

                con.Open();

                SqlDataReader rdr;

                using (SqlCommand cmd = new SqlCommand(comando, con))
                {
                    rdr = cmd.ExecuteReader();

                    while (rdr.Read())
                    {
                        FIlmeDomain filme = new FIlmeDomain()
                        {
                            IdFIlme = Convert.ToInt32(rdr[0]),
                            Titulo = (rdr[1]).ToString()
                        };

                        listaFilme.Add(filme);
                    }
                }
            }
            return listaFilme;
        }
    }
}
