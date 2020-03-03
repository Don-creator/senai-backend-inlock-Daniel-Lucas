using Senai.InLock.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.InLock.WebApi.Repositories
{
    public class TipoUsuarioRepository
    {
        private string stringConexao = "Data Source=DEV201\\SQLEXPRESS; initial catalog=InLock_Games_Manha_Tarde; user Id=sa; pwd=sa@132";


        public void Atualizar(int id, TipoUsuarioDomain TipoUsuarioAtualizado)
        {

            using (SqlConnection con = new SqlConnection(stringConexao))
            {

                string queryUpdate = "UPDATE TiposUsuario SET Titulo = @TituloTipoUsuario WHERE IdTipoUsuario = @ID";

                using (SqlCommand cmd = new SqlCommand(queryUpdate, con))
                {

                    cmd.Parameters.AddWithValue("@ID", id);
                    cmd.Parameters.AddWithValue("@TituloTipoUsuario", TipoUsuarioAtualizado.Titulo);

                    con.Open();

                    cmd.ExecuteNonQuery();
                }
            }
        }


        public TipoUsuarioDomain BuscarPorId(int id)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string querySelectById = "SELECT IdTipoUsuario, Titulo FROM TituloTipoUsuario WHERE IdTipoUsuario = @ID";

                con.Open();

                SqlDataReader rdr;

                using (SqlCommand cmd = new SqlCommand(querySelectById, con))
                {

                    cmd.Parameters.AddWithValue("@ID", id);

                    rdr = cmd.ExecuteReader();

                    if (rdr.Read())
                    {

                        TipoUsuarioDomain tipoUsuario = new TipoUsuarioDomain
                        {

                            IdTipoUsuario = Convert.ToInt32(rdr["IdTipoUsuario"])
                            ,
                            Titulo = rdr["Titulo"].ToString()
                        };

                        return tipoUsuario;
                    }

                    return null;
                }
            }
        }


        public void Cadastrar(TipoUsuarioDomain novoTipoUsuario)
        {

            using (SqlConnection con = new SqlConnection(stringConexao))
            {

                string queryInsert = "INSERT INTO TituloTipoUsuario(Titulo) VALUES (@Titulo)";


                using (SqlCommand cmd = new SqlCommand(queryInsert, con))
                {
                    cmd.Parameters.AddWithValue("@Titulo", novoTipoUsuario.Titulo);

                    con.Open();


                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void Deletar(int id)
        {

            using (SqlConnection con = new SqlConnection(stringConexao))
            {

                string queryDelete = "DELETE FROM TituloTipoUsuario WHERE IdTipoUsuario = @ID";

                using (SqlCommand cmd = new SqlCommand(queryDelete, con))
                {

                    cmd.Parameters.AddWithValue("@ID", id);


                    con.Open();

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public List<TipoUsuarioDomain> Listar()
        {
            List<TipoUsuarioDomain> tiposUsuario = new List<TipoUsuarioDomain>();


            using (SqlConnection con = new SqlConnection(stringConexao))
            {

                string querySelectAll = "SELECT IdTipoUsuario, TituloTipoUsuario FROM TiposUsuario";

                con.Open();


                SqlDataReader rdr;


                using (SqlCommand cmd = new SqlCommand(querySelectAll, con))
                {
                    rdr = cmd.ExecuteReader();

                    while (rdr.Read())
                    {
                        TipoUsuarioDomain tipoUsuario = new TipoUsuarioDomain
                        {
                            IdTipoUsuario = Convert.ToInt32(rdr["IdTipoUsuario"])
                            ,
                            Titulo = rdr["Titulo"].ToString()
                        };

                        tiposUsuario.Add(tipoUsuario);
                    }
                }
            }

            return tiposUsuario;
        }
    }
}
