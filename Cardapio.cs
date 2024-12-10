using System.Windows.Forms;

namespace Calendário_do_RU
{
    public partial class Cardapio : UserControl
    {
        // Variáveis para armazenar os ingredientes das refeições
        public string[] BreakfastIngredients
        {
            get; set;
        }
        public string[] LunchIngredients
        {
            get; set;
        }
        public string[] DinnerIngredients
        {
            get; set;
        }

        public Cardapio()
        {
            InitializeComponent();

            // Inicializando os ingredientes com valores padrão
            BreakfastIngredients = new string[10];
            LunchIngredients = new string[10];
            DinnerIngredients = new string[10];

            // Adicionando títulos para as refeições
            labelBreakfast.Text = "Breakfast";
            labelLunch.Text = "Lunch";
            labelDinner.Text = "Dinner";

            // Adicionando os ingredientes ao ListBox
            listBoxBreakfast.Items.AddRange(BreakfastIngredients);
            listBoxLunch.Items.AddRange(LunchIngredients);
            listBoxDinner.Items.AddRange(DinnerIngredients);
        }

        // Método para atualizar os ingredientes de uma refeição
        public void UpdateIngredients(string[] breakfast, string[] lunch, string[] dinner)
        {
            BreakfastIngredients = breakfast;
            LunchIngredients = lunch;
            DinnerIngredients = dinner;

            listBoxBreakfast.Items.Clear();
            listBoxLunch.Items.Clear();
            listBoxDinner.Items.Clear();

            listBoxBreakfast.Items.AddRange(breakfast);
            listBoxLunch.Items.AddRange(lunch);
            listBoxDinner.Items.AddRange(dinner);
        }
    }

}
