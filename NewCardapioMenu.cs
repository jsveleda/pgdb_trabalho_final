using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calendário_do_RU
{
    public partial class NewCardapioMenu : Form
    {
        private bool currentUser;

        public NewCardapioMenu(bool currentUser)
        {
            InitializeComponent();
            this.currentUser = currentUser;
        }

        private void btnGoBack_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnSaveMenu_Click(object sender, EventArgs e)
        {
            // Verificar se o usuário logado é o "admin_user" e tem permissões para inserir
            if (!IsUserAdmin())
            {
                MessageBox.Show("Você não tem permissão para inserir cardápios. Apenas o admin_user pode realizar essa ação.", "Acesso Negado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Coletar os dados do formulário
            string mealDate = txtMealDate.Text; // Data da refeição
            string mealType = txtMealType.Text; // Tipo de refeição (Café da Manhã, Almoço, Jantar)

            // Ingredientes
            string ingredient1 = txtMealIngredients1.Text;
            string ingredient2 = txtMealIngredients2.Text;
            string ingredient3 = txtMealIngredients3.Text;
            string ingredient4 = txtMealIngredients4.Text;
            string ingredient5 = txtMealIngredients5.Text;

            // String de conexão com as credenciais do admin_user
            string connectionString = ConfigurationManager.ConnectionStrings["MySqlAdmConnectionString"].ConnectionString;

            try
            {
                using (var connection = new MySqlConnection(connectionString))
                {
                    connection.Open();

                    // 1. Inserir dados na tabela menus
                    string insertMenuQuery = "INSERT INTO menus (menu_date) VALUES (@menu_date);";
                    using (var command = new MySqlCommand(insertMenuQuery, connection))
                    {
                        command.Parameters.AddWithValue("@menu_date", mealDate);
                        command.ExecuteNonQuery();  // Executa a inserção
                    }

                    // 2. Obter o menu_id recém inserido
                    string getLastMenuIdQuery = "SELECT LAST_INSERT_ID();";
                    int menuId;
                    using (var command = new MySqlCommand(getLastMenuIdQuery, connection))
                    {
                        menuId = Convert.ToInt32(command.ExecuteScalar());
                    }

                    // 3. Inserir a refeição (meal) na tabela meals
                    string insertMealQuery = "INSERT INTO meals (menu_id, meal_type) VALUES (@menu_id, @meal_type);";
                    using (var command = new MySqlCommand(insertMealQuery, connection))
                    {
                        command.Parameters.AddWithValue("@menu_id", menuId);
                        command.Parameters.AddWithValue("@meal_type", mealType);
                        command.ExecuteNonQuery();  // Executa a inserção
                    }

                    // 4. Obter o meal_id recém inserido
                    string getLastMealIdQuery = "SELECT LAST_INSERT_ID();";
                    int mealId;
                    using (var command = new MySqlCommand(getLastMealIdQuery, connection))
                    {
                        mealId = Convert.ToInt32(command.ExecuteScalar());
                    }

                    // 5. Inserir os ingredientes na tabela ingredients
                    string insertIngredientQuery = "INSERT INTO ingredients (meal_id, ingredient_name) VALUES (@meal_id, @ingredient_name);";

                    // Array com os ingredientes
                    string[] ingredients = new string[] { ingredient1, ingredient2, ingredient3, ingredient4, ingredient5 };

                    // Inserir ingredientes, ignorando campos vazios
                    foreach (string ingredient in ingredients)
                    {
                        if (!string.IsNullOrWhiteSpace(ingredient))
                        {
                            using (var command = new MySqlCommand(insertIngredientQuery, connection))
                            {
                                command.Parameters.AddWithValue("@meal_id", mealId);
                                command.Parameters.AddWithValue("@ingredient_name", ingredient);
                                command.ExecuteNonQuery();  // Executa a inserção do ingrediente
                            }
                        }
                    }
                }

                MessageBox.Show("Cardápio inserido com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao inserir o cardápio: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool IsUserAdmin()
        {
            return currentUser;
        }

        private void NewCardapioMenu_Load(object sender, EventArgs e)
        {
            // Definir os placeholders para as TextBox
            SetPlaceholder(txtMealDate, "Data da Refeição (yyyy/MM/dd)");
            SetPlaceholder(txtMealType, "Tipo de Refeição (Café da Manhã, Almoço, Jantar)");
            SetPlaceholder(txtMealIngredients1, "Ingrediente 1");
            SetPlaceholder(txtMealIngredients2, "Ingrediente 2");
            SetPlaceholder(txtMealIngredients3, "Ingrediente 3");
            SetPlaceholder(txtMealIngredients4, "Ingrediente 4");
            SetPlaceholder(txtMealIngredients5, "Ingrediente 5");
        }

        private void SetPlaceholder(TextBox textBox, string placeholder)
        {
            textBox.Text = placeholder;
            textBox.ForeColor = System.Drawing.Color.Gray;

            textBox.Enter += (sender, e) =>
            {
                if (textBox.Text == placeholder)
                {
                    textBox.Text = "";
                    textBox.ForeColor = System.Drawing.Color.Black;
                }
            };

            textBox.Leave += (sender, e) =>
            {
                if (string.IsNullOrWhiteSpace(textBox.Text))
                {
                    textBox.Text = placeholder;
                    textBox.ForeColor = System.Drawing.Color.Gray;
                }
            };
        }
    }
}
