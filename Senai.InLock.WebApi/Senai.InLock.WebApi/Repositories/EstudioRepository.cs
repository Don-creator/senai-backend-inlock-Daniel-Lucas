using Senai.InLock.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.InLock.WebApi.Repositories
{
    public class EstudioRepository
    {
        private string stringConexao = "Data Source=DEV201\\SQLEXPRESS; initial catalog=Filmes_tarde; user Id=sa; pwd=sa@132";


        public void AtualizarIdCorpo(EstudioDomain estudio)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string queryUpdate = "UPDATE Estudio SET NomeEstudio = @NomeEstudio WHERE IdEstudio = ID";

                using (SqlCommand cmd = new SqlCommand(queryUpdate, con))
                {
                    cmd.Parameters.AddWithValue("@ID", estudio.IdEstudio);
                    cmd.Parameters.AddWithValue("@NomeEstudio", estudio.NomeEstudio);

                    con.Open();

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void AtualizarIdUrl(int id, EstudioDomain estudio)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string queryUpdate = "UPDATE Estudio SET NomeEstudio = @NomeTitulo WHERE IdEstudio = @ID ";

                using (SqlCommand cmd = new SqlCommand(queryUpdate, con))
                {
                    cmd.Parameters.AddWithValue("@ID", id);
                    cmd.Parameters.AddWithValue("@NomeEstudio", estudio.NomeEstudio);

                    con.Open();

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public EstudioDomain BuscarPorId(int id)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string querySelectById = "SELECT IdEstudio, NomeEstudio FROM Estudio WHERE IdEstudio = @ID";

                con.Open();

                SqlDataReader rdr;

                using (SqlCommand cmd = new SqlCommand(querySelectById, con))
                {
                    cmd.Parameters.AddWithValue("@ID", id);

                    rdr = cmd.ExecuteReader();

                    if(rdr.Read())
                    {
                        EstudioDomain estudio = new EstudioDomain
                        {
                            IdEstudio = Convert.ToInt32(rdr["IdGenero"])

                            ,NomeEstudio = rdr["NomeEstudio"].ToString()
                        };

                        return estudio;

                    }
                    return null;
                }
            }
        }

        public void Cadastrar(EstudioDomain estudio)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string queryInsert = "INSERT INTO Estudio(NomeEstudio) VALUES (@NomeEstudio)";

                using (SqlCommand cmd = new SqlCommand(queryInsert, con))
                {
                    cmd.Parameters.AddWithValue("@NomeEstudio", estudio.NomeEstudio);

                    con.Open();

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void Deletar(int id)
        {
            string queryDelete = "DELETE FROM Estudio WHERE IdEstudio = @ID";

            using (SqlCommand cmd = new SqlCommand(queryDelete, con))
            {
                cmd.Parameters.AddWithValue("@ID", id);

                con.Open();

                cmd.ExecuteNonQuery();
            }
        }
    }

    public List<EstudioDomain> Listar()
    {
        List<EstudioDomain> estudios = new List<EstudioDomain>();

        using (SqlConnection con = new SqlConnection(stringConexao))
        {
            string querySelectAll = "SELECT IdEstudio, NomeEstudio FROM Estudio";

            con.Open();

            SqlDataReader rdr;


            using (SqlCommand cmd = new SqlCommand(querySelectAll, con))
            {
                rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    EstudioDomain estudio = new EstudioDomain
                    {
                        IdEstudio = Convert.ToInt32(rdr[0]),

                        NomeEstudio = rdr["NomeEstudio"].ToString()
                    };

                    estudios.Add(estudio);
                }
            }
        }
        return estudios;
    }
}
