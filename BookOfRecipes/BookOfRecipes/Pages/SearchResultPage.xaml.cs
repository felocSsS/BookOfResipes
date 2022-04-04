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
    /// Логика взаимодействия для SearchResultPage.xaml
    /// </summary>
    public partial class SearchResultPage : Page
    {
        public SearchResultPage(List<SlotModel> slots)
        {
            InitializeComponent();
            GenerateAllSlots(slots);
        }

        private void GenerateAllSlots(List<SlotModel> list)
        {
            foreach (var Recipe in list)
            {
                WP.Children.Add(GenerateElement.Slot(this, Recipe));
            }
        }

        private void Page_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            SortElementsInPanel.CalcWidthOfPanel(WP, e.NewSize.Width);
            SortElementsInPanel.SortElements(e.NewSize.Width, WP);
        }
    }
}
