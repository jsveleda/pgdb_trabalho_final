using System;
using System.Windows.Forms;

namespace Calendário_do_RU
{
    public partial class HomeMenu : Form
    {
        private string _title = "Cardápio do dia ";
        public HomeMenu(bool isAdmin)
        {
            InitializeComponent();

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

        private void firstDateTab_Click(object sender, EventArgs e)
        {
            txtTitle.Text = _title + firstDateTab.Text;
        }

        private void secondDateTab_Click(object sender, EventArgs e)
        {
            txtTitle.Text = _title + secondDateTab.Text;
        }

        private void thirdDateTab_Click(object sender, EventArgs e)
        {
            txtTitle.Text = _title + thirdDateTab.Text;
        }

        private void fourthDateTab_Click(object sender, EventArgs e)
        {
            txtTitle.Text = _title + fourthDateTab.Text;
        }

        private void fifthDateTab_Click(object sender, EventArgs e)
        {
            txtTitle.Text = _title + fifthDateTab.Text;
        }

        private void sixthDateTab_Click(object sender, EventArgs e)
        {
            txtTitle.Text = _title + sixthDateTab.Text;
        }
    }
}
