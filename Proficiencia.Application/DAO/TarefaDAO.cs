using Proficiencia.Application.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Proficiencia.Application.DAO
{
    public class TarefaDAO : Connection
    {
        public void Insert(Tarefa tarefa)
        {
            try
            {
                using (var connection = new SqlConnection(base.ConnectionString))
                {
                    string query = $"INSERT INTO tarefa (id_usuario, descricao, conclusao) VALUES ({tarefa.Id_Usuario}, '{tarefa.Descricao}', '{tarefa.Conclusao}')";

                    connection.Open();
                    SqlCommand command = new SqlCommand(query, connection);
                    command.ExecuteNonQuery();                    
                }                               
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public List<Tarefa> ListarTodos()
        {
            try
            {
                using (var connection = new SqlConnection(base.ConnectionString))
                {
                    connection.Open();

                    string query = $"SELECT * FROM tarefa";

                    SqlCommand command = new SqlCommand(query, connection);

                    SqlDataReader dr = command.ExecuteReader();

                    List<Tarefa> listaTarefas = new List<Tarefa>();

                    while (dr.Read())
                    {
                        listaTarefas.Add(new Tarefa
                        {
                            Id = (int)dr[0],
                            Conclusao = dr[1].ToString(),
                            Descricao = dr[2].ToString()
                        });
                    }

                    return listaTarefas;
                }
                
            }
            catch (Exception)
            {
                throw;
            }
        }

        public Tarefa RecuperarPorId(int id)
        {
            try
            {
                using (var connection = new SqlConnection(base.ConnectionString))
                {
                    connection.Open();

                    string query = $"SELECT * FROM tarefa WHERE id = {id}";

                    SqlCommand command = new SqlCommand(query, connection);

                    SqlDataReader dr = command.ExecuteReader();

                    Tarefa tarefa = null;

                    while (dr.Read())
                    {
                        tarefa = new Tarefa
                        {
                            Id = (int)dr[0],
                            Conclusao = dr[1].ToString(),
                            Descricao = dr[2].ToString()
                        };
                    }

                    return tarefa;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        
    }
}
