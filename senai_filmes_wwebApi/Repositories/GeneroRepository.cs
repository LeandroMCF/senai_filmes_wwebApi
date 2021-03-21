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
            throw new NotImplementedException();
        }

        public void AtualizarIdUrl(int id, GeneroDomain genero)
        {
            throw new NotImplementedException();
        }

        public GeneroDomain BuscarPorId(int id)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Cadastra um novo genero
        /// </summary>
        /// <param name="novoGenero">Objeto com as informações que serão cadastradas</param>
        public void Cadastrar(GeneroDomain novoGenero)
        {
            using (SqlConnection con = new SqlConnection(conexao))
            {
                string adicionando = "INSERT INTO Generos(Nome) VALUES ('" + novoGenero.Nome +  "')";

                con.Open();

                using (SqlCommand cmd = new SqlCommand(adicionando, con))
                {
                    //Executa o adicionando 
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void Deletar(int id)
        {
            using (SqlConnection con = new SqlConnection(conexao))
            {
                string excluindo = "DELETE FROM Generos WHERE IdGenero =" + id + "";

                con.Open();

                using (SqlCommand cmd = new SqlCommand(excluindo, con))
                {
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
