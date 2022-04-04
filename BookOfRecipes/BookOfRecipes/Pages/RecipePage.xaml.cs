using BookOfRecipes.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace BookOfRecipes.Pages
{
    /// <summary>
    /// Логика взаимодействия для RecipePage.xaml
    /// </summary>
    public partial class RecipePage : Page
    {
        SlotModel slot;
        int Number = 1;
        public RecipePage(object slotModel)
        {
            InitializeComponent();
            var info = (SlotModel)slotModel;
            slot = info;
            TBAuthor.Text = "Автор: " + info.NameOfAuthor;
            TBColories.Text = "Количество калорий: " + info.Colories.ToString();
            TBDecsription.Text = info.Description;
            TBGrade.Text = info.Grade.ToString();
            TBName.Text = info.Name;
            TBSteps.Text = info.CookingSteps;
            TBtime.Text = "Время приготовления: " + info.Time.ToString() + " минут"; 
            TBIngridients.Text = FormIngridietnsText(1);
            MainImage.Source = ImageFromBase64.FrBase64(info.Photo);
        }

        private string FormIngridietnsText(int number)
        {
            string text = "";

            foreach(var ingridient in slot.Ingridients)
            {
                text += ingridient.Name + " " + ingridient.Weight * number + ingridient.Type + "\n";
            }
            
            return text;
        }

        private void BtnAdd_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Number += 1;
            TBNumber.Text = Number.ToString();
            TBIngridients.Text = FormIngridietnsText(Number);
        }

        private void BtnRemove_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if ((Number - 1) >= 1)
            {
                Number -= 1;
                TBNumber.Text = Number.ToString();
                TBIngridients.Text = FormIngridietnsText(Number);
            }

        }

        private void BtnCopyrecipe_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Clipboard.SetText(FormIngridietnsText(Number));
        }

        private void BtnMakeOrder_MouseDown(object sender, MouseButtonEventArgs e)
        {
            MessageBox.Show("переход в приложение пятерочка");
        }
    }
}
