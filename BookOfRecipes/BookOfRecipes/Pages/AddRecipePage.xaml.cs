using BookOfRecipes.Classes;
using Microsoft.Win32;
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
    /// Логика взаимодействия для AddRecipePage.xaml
    /// </summary>
    public partial class AddRecipePage : Page
    {
        SlotModel slotModel = null;
        string Photo;
        int counter = 1;
        public AddRecipePage()
        {
            InitializeComponent();
        }

        private void BtnAddImage_MouseDown(object sender, MouseButtonEventArgs e)
        {
            OpenFileDialog openDialog = new OpenFileDialog();
            openDialog.Filter = "Image files (*.BMP, *.JPG, *.GIF, *.TIF, *.PNG, *.ICO, *.EMF, *.WMF)|*.bmp;*.jpg;*.gif; *.tif; *.png; *.ico; *.emf; *.wmf";

            if (openDialog.ShowDialog() == true)
            {
                ImageOfrecipe.Source = new BitmapImage(new Uri(openDialog.FileName));
                Photo = ImageFromBase64.FrImage(openDialog.FileName);
            }
        }

        private void BtnDeleteingridient_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if(SPIng.Children.Count > 1)
            {
                SPIng.Children.RemoveAt(SPIng.Children.Count - 1);
            }
        }
        private void BtnAddingridient_MouseDown(object sender, MouseButtonEventArgs e)
        {
            SPIng.Children.Add(GenerateElement.IngridientSP(this));
        }

        private void BtnDeleteStep_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (SPStep.Children.Count > 1)
            {
                SPStep.Children.RemoveAt(SPStep.Children.Count - 1);
            }
        }

        private void BtnAddSrep_MouseDown(object sender, MouseButtonEventArgs e)
        {
            SPStep.Children.Add(GenerateElement.StepSP(this, SPStep.Children.Count + 1));
            MainSV.ScrollToBottom();
        }

        private void BtnSaveRecipe_MouseDown(object sender, MouseButtonEventArgs e)
        {
            try
            {
                List<IngridientModel> ingridientModels = new List<IngridientModel>();
                string stepsFormating = "";

                foreach (StackPanel item in SPIng.Children)
                {
                    var textBox1 = item.Children[0] as TextBox;
                    var comboBox1 = item.Children[1] as ComboBox;
                    var comboBoxItem = comboBox1.SelectionBoxItem.ToString();
                    var textBox2 = item.Children[2] as TextBox;
                    IngridientModel ingridient = new IngridientModel() { Name = textBox1.Text, Type = comboBoxItem, Weight = Convert.ToInt32(textBox2.Text) };
                    ingridientModels.Add(ingridient);
                }

                foreach (StackPanel item in SPStep.Children)
                {
                    var textBox = item.Children[1] as TextBox;
                    stepsFormating += "Шаг " + counter.ToString() + "\n" + textBox.Text + "\n\n";
                    counter++;
                }
                slotModel = new SlotModel()
                {
                    Photo = Photo,
                    Name = TBName.Text,
                    Description = TBDescription.Text,
                    Time = Convert.ToInt32(TBTime.Text),
                    Colories = Convert.ToInt32(TBColories.Text),
                    DateOfPublish = Convert.ToDateTime(DateTime.Now.ToString("D")),
                    NameOfAuthor = HelpClass.Name,
                    CookingSteps = stepsFormating,
                    Ingridients = ingridientModels,
                    Grade = 5
                };
                List<SlotModel> slots = new List<SlotModel>();
                slots = ModelsGlobal.slotModels;
                slots.Add(slotModel);
                ModelsGlobal.slotModels = slots;
                MessageBox.Show("Рецепт успешно добавлен", "", MessageBoxButton.OK);
            }
            catch (Exception)
            {
                MessageBox.Show("Праверьте данные в полях");
            }
        }

    }
}
