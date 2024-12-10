using System;

namespace Calendário_do_RU
{
    using MySql.Data.MySqlClient;

    public class UserLogin
    {
        private const string ConnectionString = "Server=localhost;Database=RUCalendarDB;User ID=root;Password=0000;";

        public bool Login(int userCode, string password, out bool isAdmin)
        {
            isAdmin = false;  // Inicializa como não admin

            string query = "SELECT is_admin FROM users WHERE user_code = @userCode AND password_hash = SHA2(@password, 256)";

            using (MySqlConnection connection = new MySqlConnection(ConnectionString))
            {
                try
                {
                    connection.Open();
                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        // Adiciona os parâmetros para o código do usuário e a senha
                        command.Parameters.AddWithValue("@userCode", userCode);
                        command.Parameters.AddWithValue("@password", password);

                        using (MySqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                isAdmin = Convert.ToBoolean(reader["is_admin"]);
                                return true; // Login bem-sucedido
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Erro ao tentar fazer login: {ex.Message}");
                }
            }
            return false; // Login falhou
        }
    }
}