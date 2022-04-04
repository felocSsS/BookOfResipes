using BookOfRecipes.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace BookOfRecipes.Classes
{
    internal class GenerateElement
    {
        public static UIElement Slot(Page window, SlotModel info)
        {
            Border RootBorder = new Border()
            {
                Style = window.FindResource("RootBorder") as Style,
                Tag = info
            };

            Grid Container = new Grid()
            {
                Style = window.FindResource("Container") as Style
            };

            Image SlotImage = new Image()
            {
                Style = window.FindResource("SlotImage") as Style,
                Source = ImageFromBase64.FrBase64(info.Photo)
            };

            TextBlock NameOfAuthor = new TextBlock()
            {
                Style = window.FindResource("NameOfAuthor") as Style,
                Text = info.NameOfAuthor,
            };

            TextBlock Name = new TextBlock()
            {
                Style = window.FindResource("Name") as Style,
                Text= info.Name,
            };

            StackPanel StackPanelTime = new StackPanel()
            {
                Style = window.FindResource("StackPanelTime") as Style
            };

            Image ImageTime = new Image()
            {
                Style = window.FindResource("ImageTime") as Style
            };

            TextBlock TextTime = new TextBlock()
            {
                Style = window.FindResource("TextTime") as Style,
                Text = info.Time.ToString() + " минут"
            };

            StackPanel StackPanelGrade = new StackPanel()
            {
                Style = window.FindResource("StackPanelGrade") as Style
            };

            Image ImageGrade = new Image()
            {
                Style = window.FindResource("ImageGrade") as Style
            };

            TextBlock TextGrade = new TextBlock()
            {
                Style = window.FindResource("TextGrade") as Style,
                Text = info.Grade.ToString()
            };

            StackPanelTime.Children.Add(ImageTime);
            StackPanelTime.Children.Add(TextTime);

            StackPanelGrade.Children.Add(ImageGrade);
            StackPanelGrade.Children.Add(TextGrade);

            Container.Children.Add(SlotImage);
            Container.Children.Add(NameOfAuthor);
            Container.Children.Add(Name);
            Container.Children.Add(StackPanelTime);
            Container.Children.Add(StackPanelGrade);

            RootBorder.Child = Container;

            RootBorder.MouseDown += Border_MouseDown;

            return RootBorder;
        }

        private static void Border_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            Border border = sender as Border;
            FrameClass.Frm.Navigate(new RecipePage((SlotModel)border.Tag));
        }

        public static UIElement IngridientSP(Page window)
        {
            StackPanel RootStackPanel = new StackPanel()
            {
                Style = window.FindResource("StackPanelIng") as Style
            };

            TextBox TBName = new TextBox()
            {
                Style = window.FindResource("TBNameIng") as Style
            };

            ComboBox comboBox = new ComboBox()
            {
                Style = window.FindResource("RoundComboBox") as Style,
                ItemsSource = new List<string>()
                {
                    "г",
                    "мл",
                    "шт"
                },
                SelectedIndex = 0,
                Width = 100,
                FontSize = 18,
                Height = 35,
                Margin = new Thickness(15, 0, 0, 0)
            };

            TextBox TBNumber = new TextBox()
            {
                Style = window.FindResource("TBnumberIng") as Style
            };

            RootStackPanel.Children.Add(TBName);
            RootStackPanel.Children.Add(comboBox);
            RootStackPanel.Children.Add(TBNumber);


            return RootStackPanel;
        }

        public static UIElement StepSP(Page window, int index)
        {
            StackPanel RootStackPanel = new StackPanel()
            {
                Style = window.FindResource("StackPanelStep") as Style
            };

            TextBlock TBName = new TextBlock()
            {
                Style = window.FindResource("TBStep") as Style,
                Text = "Шаг " + index.ToString()
            };


            TextBox TBNumber = new TextBox()
            {
                Style = window.FindResource("TBoxStep") as Style
            };

            RootStackPanel.Children.Add(TBName);
            RootStackPanel.Children.Add(TBNumber);

            return RootStackPanel;
        }

    }
}
