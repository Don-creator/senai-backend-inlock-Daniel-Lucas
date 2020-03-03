using Senai.InLock.WebApi.Domains;
using Senai.InLock.WebApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;


namespace Senai.InLock.WebApi.Repositories
{
    public class JogosRepository : IJogosRepository
    {
        private string stringConexao = "Data Source=DEV201\\SQLEXPRESS; initial catalog=InLock_Games_Manha_Tarde; user Id=sa; pwd=sa@132";

        public void Atualizar(int id, JogosDomain jogo)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string queryUpdate = "UPDATE Jogos SET NomeJogo = @NomeJogo WHERE IdJogo = ID";

                using (SqlCommand cmd = new SqlCommand(queryUpdate, con))
                {
                    cmd.Parameters.AddWithValue("@ID", jogo.IdJogo);
                    cmd.Parameters.AddWithValue("@NomeEstudio", jogo.NomeJogo);

                    con.Open();

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void AtualizarIdCorpo(JogosDomain jogo)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string queryUpdate = "UPDATE Jogos SET NomeJogo = @NomeJogo WHERE IdJogo = ID";

                using (SqlCommand cmd = new SqlCommand(queryUpdate, con))
                {
                    cmd.Parameters.AddWithValue("@ID", jogo.IdJogo);
                    cmd.Parameters.AddWithValue("@NomeJogo", jogo.NomeJogo);

                    con.Open();

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void AtualizarIdUrl(int id, JogosDomain jogo)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string queryUpdate = "UPDATE Jogos SET  NomeJogo,Descricao,DataLancamento,IdEstudio,Valor = @NomeJogo,@Descricao,@DataLancamento,@IdEstudio,@Valor WHERE IdJogo = @ID ";

                using (SqlCommand cmd = new SqlCommand(queryUpdate, con))
                {
                    cmd.Parameters.AddWithValue("@ID", id);
                    cmd.Parameters.AddWithValue("@NomeJogo", jogo.NomeJogo);
                    cmd.Parameters.AddWithValue("@Descricao", jogo.Descricao);
                    cmd.Parameters.AddWithValue("@DataLancamento", jogo.DataLancamento);
                    cmd.Parameters.AddWithValue("@IdEstudio", jogo.IdEstudio);
                    cmd.Parameters.AddWithValue("@Valor", jogo.Valor);

                    con.Open();

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public JogosDomain BuscarPorId(int id)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string querySelectById = "SELECT IdJogo, NomeJogo,Descricao,DataLancamento,IdEstudio,Valor FROM Jogos WHERE IdJogo = @ID";

                con.Open();

                SqlDataReader rdr;

                using (SqlCommand cmd = new SqlCommand(querySelectById, con))
                {
                    cmd.Parameters.AddWithValue("@ID", id);

                    rdr = cmd.ExecuteReader();

                    if (rdr.Read())
                    {
                        JogosDomain jogo = new JogosDomain
                        {
                            IdJogo = Convert.ToInt32(rdr[0]),

                            NomeJogo = rdr["NomeJogo"].ToString(),

                            Descricao = rdr["Descricao"].ToString(),

                            DataLancamento = Convert.ToDateTime(rdr["DataLancamento"]),

                            IdEstudio = Convert.ToInt32(rdr[0]),

                            Valor = rdr["Valor"].ToString(),
                        };

                        return jogo;

                    }
                    return null;
                }
            }
        }

        public List<JogosDomain> BuscarPorTitulo(string busca)
        {
            throw new NotImplementedException();
        }

        public void Cadastrar(JogosDomain jogo)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string queryInsert = "INSERT INTO Jogos(NomeJogo,Descricao,DataLancamento,IdEstudio,Valor) VALUES (@NomeJogo,@Descricao,@DataLancamento,@IdEstudio,@Valor)";

                using (SqlCommand cmd = new SqlCommand(queryInsert, con))
                {
                    cmd.Parameters.AddWithValue("@NomeJogo", jogo.NomeJogo);
                    cmd.Parameters.AddWithValue("@Descricao", jogo.Descricao);
                    cmd.Parameters.AddWithValue("@DataLancamento", jogo.DataLancamento);
                    cmd.Parameters.AddWithValue("@IdEstudio", jogo.IdEstudio);
                    cmd.Parameters.AddWithValue("@Valor", jogo.Valor);


                    con.Open();

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void Deletar(int id)
        {
            string queryDelete = "DELETE FROM Jogos WHERE IdJogo = @ID";

            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                using (SqlCommand cmd = new SqlCommand(queryDelete, con))
                {
                    cmd.Parameters.AddWithValue("@ID", id);

                    con.Open();

                    cmd.ExecuteNonQuery();
                }
            }
        }
        public List<JogosDomain> Listar()
        {
            List<JogosDomain> jogo = new List<JogosDomain>();

            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string querySelectAll = "SELECT IdJogo, NomeJogo,Descricao,DataLancamento,IdEstudio,Valor FROM Jogos";

                con.Open();

                SqlDataReader rdr;


                using (SqlCommand cmd = new SqlCommand(querySelectAll, con))
                {
                    rdr = cmd.ExecuteReader();

                    while (rdr.Read())
                    {
                        JogosDomain jogos = new JogosDomain
                        {
                            IdJogo = Convert.ToInt32(rdr[0]),
                            
                            NomeJogo = rdr["NomeJogo"].ToString(),

                            Descricao = rdr["Descricao"].ToString(),

                            DataLancamento =Convert.ToDateTime(rdr["DataLancamento"]),

                            IdEstudio = Convert.ToInt32(rdr[0]),

                            Valor = rdr["Valor"].ToString(),
                        };

                        jogo.Add(jogos);
                    }
                }
            }
            return jogo;
        }
    }
}

