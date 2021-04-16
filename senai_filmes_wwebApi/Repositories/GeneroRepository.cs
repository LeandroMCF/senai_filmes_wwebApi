using senai_filmes_wwebApi.Domains;
using senai_filmes_wwebApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace senai_filmes_wwebApi.Repositories
{
    /// <summary>
    /// Responsável pelo repositórios dos gêneros
    /// </summary>
    public class GeneroRepository : IGeneroRepository

    {   
        /// <summary>
        /// String de conexão com o banco de dados que recebe os parâmetros
        /// </summary>
        //private string conexao = "Data Source=DESKTOP-LFIP8ID; initial catalog=Filmes; integrated security=true; user Id=...; pwd=... <- autentificação pelo id e senha
        private string conexao = "Data Source=DESKTOP-LFIP8ID; initial catalog=Filmes; integrated security=true"; //<- autenticação pelo Windows

        public void AtualizarIdCorpo(GeneroDomain genero)
        {
            using (SqlConnection con = new SqlConnection(conexao))
            {
                string atualizando = "UPDATE Generos SET Nome = '@Nome' WHERE IdGenero = @id";


                using (SqlCommand cmd = new SqlCommand(atualizando, con))
                {
                    cmd.Parameters.AddWithValue("@Nome", genero.Nome);

                    cmd.Parameters.AddWithValue("@id", genero.IdGenero);

                    con.Open();

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void AtualizarIdUrl(int id, GeneroDomain genero)
        {
            using (SqlConnection con = new SqlConnection(conexao))
            {
                string atualizando = "UPDATE Generos SET Nome = '@Nome' WHERE IdGenero = @id";

                con.Open();

                using (SqlCommand cmd = new SqlCommand(atualizando, con))
                {
                    cmd.Parameters.AddWithValue("@Nome", genero.Nome);

                    cmd.Parameters.AddWithValue("@id", id);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public GeneroDomain BuscarPorId(int id)
        {
            using (SqlConnection con = new SqlConnection(conexao))
            {
                string buscar = "SELECT IdGenero, Nome FROM Generos WHERE IdGenero = @id";

                con.Open();

                SqlDataReader rdr;

                using (SqlCommand cmd = new SqlCommand(buscar, con))
                {
                    cmd.Parameters.AddWithValue("@id", id);

                    rdr = cmd.ExecuteReader();

                    if (rdr.Read())
                    {
                        GeneroDomain generoBuscando = new GeneroDomain
                        {
                            IdGenero = Convert.ToInt32(rdr[0]),

                            Nome = rdr[1].ToString()
                        };

                        return generoBuscando;

                    }

                    return null;

                }
            }
        }

        /// <summary>
        /// Cadastra um novo genero
        /// </summary>
        /// <param name="novoGenero">Objeto com as informações que serão cadastradas</param>
        public void Cadastrar(GeneroDomain novoGenero)
        {
            using (SqlConnection con = new SqlConnection(conexao))
            {
                string adicionando = "INSERT INTO Generos(Nome) VALUES(@Nome)";

                con.Open();

                using (SqlCommand cmd = new SqlCommand(adicionando, con))
                {
                    cmd.Parameters.AddWithValue("@Nome", novoGenero.Nome);

                    //Executa o adicionando 
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void Deletar(int id)
        {
            using (SqlConnection con = new SqlConnection(conexao))
            {
                string excluindo = "DELETE FROM Generos WHERE IdGenero = @id";

                con.Open();

                using (SqlCommand cmd = new SqlCommand(excluindo, con))
                {
                    cmd.Parameters.AddWithValue("@id", id);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        /// <summary>
        /// Lista todos os gêneros
        /// </summary>
        /// <returns>Uma lista de gêneros</returns>
        public List<GeneroDomain> ListarTodos()
        {
            //Lista onde será arrmazenado os dados
            List<GeneroDomain> listaGeneros = new List<GeneroDomain>();

            //Declarar a SqlConnection con passando a conexao como parametro
            using (SqlConnection con = new SqlConnection(conexao))
            {
                //Declara a instrução a ser executada
                string querySellectAll = "SELECT IdGenero, Nome From Generos";

                //Abre a conexão com o banco de dados
                con.Open();

                //Delacra o SqlReader rdr para percorrer a tabela do banco de dados
                SqlDataReader rdr;

                //Declara o SqlCommand cmd passando a query que será executada e a conexão como parametro
                using (SqlCommand cmd = new SqlCommand(querySellectAll, con))
                {
                    //executa a query e armazena os dados no rdr
                    rdr = cmd.ExecuteReader();

                    //enquanto houver linha para ler, o laço se repete
                    while (rdr.Read())
                    {
                        GeneroDomain genero = new GeneroDomain()
                        {
                            IdGenero = Convert.ToInt32(rdr[0]),
                            Nome = (rdr[1]).ToString()
                        };

                        listaGeneros.Add(genero);
                    }
                }
            }
            return listaGeneros;
        }
    }
}
