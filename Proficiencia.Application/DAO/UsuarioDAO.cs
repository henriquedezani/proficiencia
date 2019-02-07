using Proficiencia.Application.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Proficiencia.Application.DAO
{
    public class UsuarioDAO : Connection
    {
        public Usuario Insert(Usuario usuario)
        {
            try
            {
                using (var connection = new SqlConnection(base.ConnectionString))
                {
                    connection.Open();
                    string query = $"INSERT INTO usuario (name, email, senha) VALUES ('{usuario.Nome}', '{usuario.Email}', '{usuario.Senha}')";

                    SqlCommand command = new SqlCommand(query, connection);
                    command.ExecuteNonQuery();

                    return usuario;
                }                               
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<Usuario> ListarTodos()
        {
            try
            {
                using (var connection = new SqlConnection(base.ConnectionString))
                {
                    connection.Open();

                    string query = $"SELECT * FROM usuario";

                    SqlCommand command = new SqlCommand(query, connection);

                    SqlDataReader dr = command.ExecuteReader();

                    List<Usuario> listaUsuario = new List<Usuario>();

                    while (dr.Read())
                    {
                        listaUsuario.Add(new Usuario
                        {
                            Id = (int)dr[0],
                            Nome = dr[1].ToString(),
                            Email = dr[2].ToString(),
                            Senha = dr[3].ToString()    
                        });
                    }

                    return listaUsuario;
                }

            }
            catch (Exception)
            {
                throw;
            }
        }

        public Usuario RecuperarPorId(int id)
        {
            try
            {
                using (var connection = new SqlConnection(base.ConnectionString))
                {
                    connection.Open();

                    string query = $"SELECT * FROM usuario WHERE id = {id}";

                    SqlCommand command = new SqlCommand(query, connection);

                    SqlDataReader dr = command.ExecuteReader();

                    Usuario usuario = null;

                    while (dr.Read())
                    {
                        usuario = new Usuario
                        {
                            Id = (int)dr[0],
                            Nome = dr[1].ToString(),
                            Email = dr[1].ToString(),
                            Senha = dr[2].ToString()
                        };
                    }

                    return usuario;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

    }
}
