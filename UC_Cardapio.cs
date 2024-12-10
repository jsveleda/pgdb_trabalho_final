using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;

namespace Calendário_do_RU
{
    public partial class UC_Cardapio : UserControl
    {
        public DateTime SelectedDate
        {
            get; set;
        } // Data do cardápio

        public UC_Cardapio()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Carrega os dados do cardápio do banco de dados com base na data selecionada.
        /// </summary>
        public void LoadMenu()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["MySqlRegConnectionString"].ConnectionString;

            try
            {
                using (var connection = new MySqlConnection(connectionString))
                {
                    connection.Open();

                    // Consulta para obter as refeições e ingredientes
                    string query = @"
                    SELECT ml.meal_type, i.ingredient_name
                    FROM menus m
                    JOIN meals ml ON m.menu_id = ml.menu_id
                    JOIN ingredients i ON ml.meal_id = i.meal_id
                    WHERE m.menu_date = @menu_date
                    ORDER BY ml.meal_type, i.ingredient_name";

                    using (var command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@menu_date", SelectedDate.ToString("yyyy-MM-dd"));

                        using (var reader = command.ExecuteReader())
                        {
                            Dictionary<string, List<string>> meals = new Dictionary<string, List<string>>
                        {
                            { "Café da manhã", new List<string>() },
                            { "Almoço", new List<string>() },
                            { "Jantar", new List<string>() }
                        };

                            while (reader.Read())
                            {
                                string mealType = reader["meal_type"].ToString();
                                string ingredientName = reader["ingredient_name"].ToString();

                                if (meals.ContainsKey(mealType))
                                {
                                    meals[mealType].Add(ingredientName);
                                }
                            }

                            // Atualizando os ListBoxes
                            listBoxBreakfast.Items.Clear();
                            listBoxLunch.Items.Clear();
                            listBoxDinner.Items.Clear();

                            listBoxBreakfast.Items.AddRange(meals["Café da manhã"].ToArray());
                            listBoxLunch.Items.AddRange(meals["Almoço"].ToArray());
                            listBoxDinner.Items.AddRange(meals["Jantar"].ToArray());
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading menu: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
