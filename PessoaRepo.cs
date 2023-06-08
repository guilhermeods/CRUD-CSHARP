using System.Collections.Generic;
using System.Data.SQLite;

namespace TechoneDesafio
{
    //Classe para controlar as operaçoes que podem ser efetuadas no banco com a classe pessoa
    public class PessoaRepo
    {
        private SQLiteConnection connection;
        public PessoaRepo()
        {
            string connectionString = "Data Source=pessoas.db;Version=3;";

            connection = new SQLiteConnection(connectionString);
            connection.Open();

            string createTableQuery = "CREATE TABLE IF NOT EXISTS Pessoas (Id INTEGER PRIMARY KEY AUTOINCREMENT, Nome TEXT, Email TEXT, Tel TEXT)";
            SQLiteCommand createTableCommand = new SQLiteCommand(createTableQuery, connection);
            createTableCommand.ExecuteNonQuery();
        }

        public void CriarPessoa(Pessoa pessoa){
            string query = "INSERT INTO Pessoas (Nome,Email,Tel) VALUES (@Nome, @Email, @Tel)";
            SQLiteCommand comando = new SQLiteCommand(query, connection);
            comando.Parameters.AddWithValue("@Nome", pessoa.Nome);
            comando.Parameters.AddWithValue("@Email", pessoa.Email);
            comando.Parameters.AddWithValue("@Tel", pessoa.Tel);
            comando.ExecuteNonQuery();
        }


        public List<Pessoa> ListarPessoas(){
            List<Pessoa> pessoas = new List<Pessoa>();
            string query = "SELECT * FROM Pessoas";
            SQLiteCommand comando = new SQLiteCommand(query, connection);

            using (SQLiteDataReader reader = comando.ExecuteReader())
            {
                while(reader.Read())
                {
                    Pessoa pessoa = new Pessoa{
                        Id = Convert.ToInt32(reader["Id"]),
                        Nome = reader["Nome"].ToString(),
                        Email = reader["Email"].ToString(),
                        Tel = reader["Tel"].ToString()
                    };
                    pessoas.Add(pessoa);
                }
            }
            return pessoas;
        }
        public Pessoa? ObterPessoaPorId(int id)
        {
            string query = "SELECT * FROM Pessoas WHERE Id = @Id";
            SQLiteCommand comando = new SQLiteCommand(query, connection);
            comando.Parameters.AddWithValue("@Id", id);

            using (SQLiteDataReader reader = comando.ExecuteReader()){
                if(reader.Read()){
                    Pessoa pessoa = new Pessoa{
                        Id = Convert.ToInt32(reader["Id"]),
                        Nome = reader["Nome"].ToString(),
                        Email = reader["Email"].ToString(),
                        Tel = reader["Tel"].ToString()

                    };
                    return pessoa;
                }
                else
                    Console.WriteLine("ID invalido");
            }
            return null;
        }

        public void AtualizarPessoa(Pessoa pessoaz){
            string query = "UPDATE Pessoas SET Nome = @Nome, Email = @Email, Tel = @Tel WHERE Id = @Id";
            using(SQLiteCommand comando = new SQLiteCommand(query, connection)){
                comando.Parameters.AddWithValue("@Nome", pessoaz.Nome);
                comando.Parameters.AddWithValue("@Email", pessoaz.Email);
                comando.Parameters.AddWithValue("@Tel", pessoaz.Tel);
                comando.Parameters.AddWithValue("@Id", pessoaz.Id);
                int result = comando.ExecuteNonQuery();
                if(result>0){
                    Console.WriteLine("Sucesso na atualizaçao\n");
                }
                else 
                    Console.WriteLine("Falha Nenhuma mudacao foi realizada\n");
            }
            
        }
        public void ExcluirPessoa(int id){
            string query = "DELETE FROM Pessoas WHERE Id = @Id";
            SQLiteCommand comando = new SQLiteCommand(query, connection);
            comando.Parameters.AddWithValue("@Id", id);
            int result = comando.ExecuteNonQuery();
            if(result>0){
                    Console.WriteLine("Sucesso na atualizaçao\n");
                }
                else 
                    Console.WriteLine("Falha Nenhuma mudacao foi realizada\n");
        }


    }
}