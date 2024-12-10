using System;
using System.Windows.Forms;

namespace Calendário_do_RU
{
    public partial class HomeMenu : Form
    {
        private string _title = "Cardápio do dia ";
        private bool _isAdmin;

        public HomeMenu(bool isAdmin)
        {
            InitializeComponent();

            _isAdmin = isAdmin;
            btnAddMenu.Visible = isAdmin;
        }

        private void HomeMenu_Load(object sender, EventArgs e)
        {
            firstDateTab.Text = DateTime.Today.ToString("dd/MM");
            secondDateTab.Text = DateTime.Today.AddDays(1).ToString("dd/MM");
            thirdDateTab.Text = DateTime.Today.AddDays(2).ToString("dd/MM");
            fourthDateTab.Text = DateTime.Today.AddDays(3).ToString("dd/MM");
            fifthDateTab.Text = DateTime.Today.AddDays(4).ToString("dd/MM");
            sixthDateTab.Text = DateTime.Today.AddDays(5).ToString("dd/MM");
        }

        private void btnGoBack_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void InstantiateOnUC_Cardapio(DateTime dateTime)
        {

            UC_Cardapio cardapio = new UC_Cardapio
            {
                SelectedDate = dateTime, // Define a data
            };

            cardapio.LoadMenu(); // Carrega o cardápio do banco

            int x = (homeMenuPanel.Width - cardapio.Width) / 2;
            int y = (homeMenuPanel.Height - cardapio.Height) / 2;
            cardapio.Location = new System.Drawing.Point(x, y+60);

            homeMenuPanel.Controls.RemoveByKey("UC_Cardapio");

            homeMenuPanel.Controls.Add(cardapio);// Adiciona o controle ao formulário
            cardapio.BringToFront(); // Coloca o controle na frente
        }

        private void firstDateTab_Click(object sender, EventArgs e)
        {
            txtTitle.Text = _title + firstDateTab.Text;

            InstantiateOnUC_Cardapio(DateTime.Today);
        }

        private void secondDateTab_Click(object sender, EventArgs e)
        {
            txtTitle.Text = _title + secondDateTab.Text;

            InstantiateOnUC_Cardapio(DateTime.Today.AddDays(1));
        }

        private void thirdDateTab_Click(object sender, EventArgs e)
        {
            txtTitle.Text = _title + thirdDateTab.Text;

            InstantiateOnUC_Cardapio(DateTime.Today.AddDays(2));
        }

        private void fourthDateTab_Click(object sender, EventArgs e)
        {
            txtTitle.Text = _title + fourthDateTab.Text;

            InstantiateOnUC_Cardapio(DateTime.Today.AddDays(3));
        }

        private void fifthDateTab_Click(object sender, EventArgs e)
        {
            txtTitle.Text = _title + fifthDateTab.Text;

            InstantiateOnUC_Cardapio(DateTime.Today.AddDays(4));
        }

        private void sixthDateTab_Click(object sender, EventArgs e)
        {
            txtTitle.Text = _title + sixthDateTab.Text;

            InstantiateOnUC_Cardapio(DateTime.Today.AddDays(5));
        }

        private void btnAddMenu_Click(object sender, EventArgs e)
        {
            NewCardapioMenu newCardapioMenu = new NewCardapioMenu(_isAdmin);

            newCardapioMenu.ShowDialog();
        }
    }
}
