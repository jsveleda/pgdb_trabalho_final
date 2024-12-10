using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calendário_do_RU
{
    public partial class RUCalendarLoginMenu : Form
    {
        public RUCalendarLoginMenu()
        {
            InitializeComponent();
        }

        private void RUCalendarLoginMenu_Load(object sender, EventArgs e)
        {
            // Set placeholders when the form loads
            SetPlaceholderText(txtUserCode, "user code");
            SetPlaceholderText(txtPassword, "password");

            // Attach event handlers for Leave and Enter
            txtUserCode.Enter += (s, args) => RemovePlaceholderText(txtUserCode, "user code");
            txtUserCode.Leave += (s, args) => SetPlaceholderText(txtUserCode, "user code");

            txtPassword.Enter += (s, args) => RemovePlaceholderText(txtPassword, "password");
            txtPassword.Leave += (s, args) => SetPlaceholderText(txtPassword, "password");
        }

        private void userIdInputField_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Verifica se o caractere não é um número nem uma tecla de controle (como Backspace)
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                // Se não for permitido, cancela o evento
                e.Handled = true;
            }
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            // Recupera o código do usuário e a senha
            if (int.TryParse(txtUserCode.Text, out int userCode)) // Certifique-se de que o código seja um número
            {
                string password = txtPassword.Text;

                UserLogin loginHandler = new UserLogin();
                if (loginHandler.Login(userCode, password, out bool isAdmin))
                {
                    // Exibe uma mensagem de boas-vindas
                    MessageBox.Show($"Bem-vindo, usuário {(isAdmin ? "administrador" : "comum")}!");

                    // Torna os botões visíveis apenas para administradores
                    //btnAdminPanel.Visible = isAdmin;

                    // Redireciona para a tela principal ou painel
                    HomeMenu homeMenu = new HomeMenu(isAdmin);
                    homeMenu.ShowDialog();
                }
                else
                {
                    MessageBox.Show("Código de usuário ou senha inválidos.");
                }
            }
            else
            {
                MessageBox.Show("Por favor, insira um código numérico válido.");
            }
        }

        // Method to set placeholders
        private void SetPlaceholderText(TextBox textBox, string placeholderText)
        {
            if (textBox.Text == "")
            {
                textBox.Text = placeholderText;
                textBox.ForeColor = Color.Gray;  // Set placeholder color
            }
        }

        // Method to remove placeholder text
        private void RemovePlaceholderText(TextBox textBox, string placeholderText)
        {
            if (textBox.Text == placeholderText)
            {
                textBox.Text = "";
                textBox.ForeColor = Color.Black;  // Reset text color to normal
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
