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
    /// Логика взаимодействия для MianPage.xaml
    /// </summary>
    public partial class MianPage : Page
    {
        public MianPage()
        {
            InitializeComponent();

            GenerateAllSlots();
        }

        private void Page_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            SortElementsInPanel.CalcWidthOfPanel(WP, e.NewSize.Width);
            SortElementsInPanel.SortElements(e.NewSize.Width, WP);
        }

        private void GenerateAllSlots()
        {
            foreach (var Recipe in ModelsGlobal.slotModels)
            {
                WP.Children.Add(GenerateElement.Slot(this, Recipe));
            }
        }
    }
}
