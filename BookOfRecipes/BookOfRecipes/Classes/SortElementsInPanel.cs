using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace BookOfRecipes.Classes
{
    internal class SortElementsInPanel
    {
        private static double PanelSize;
        /*public static int FinalQuantity; // финальное количество элементов*/

        public static void CalcWidthOfPanel(WrapPanel Panel, double PageWidth)
        {
            Panel.Width = PageWidth - 30;
            PanelSize = PageWidth - 30;
        }

        private static int CalcMargin(int DistanceBetweenElements, int WidthOfElem, int CoutnOfElements)
        {
            int PrimaryQuantity = (int)PanelSize / WidthOfElem; // первоначальное количество элементов в строке без учета маржина
            int WidthOfRowWithMargin = ((WidthOfElem * PrimaryQuantity) + (DistanceBetweenElements * (PrimaryQuantity + 1))); // длинна строки с учетом первоначального
                                                                                                                              // количества элементов и маржином между ними
            int FinalQuantity; // финальное количество элементов

            if (WidthOfRowWithMargin > PanelSize)
            {
                FinalQuantity = PrimaryQuantity - 1;
                int cheak = ((WidthOfElem * FinalQuantity) + (DistanceBetweenElements * (FinalQuantity + 1)));
                if (cheak > PanelSize)
                {
                    FinalQuantity -= 1;
                }
            }
            else
                FinalQuantity = PrimaryQuantity;


            if (FinalQuantity < CoutnOfElements)
            {
                if (WidthOfRowWithMargin > PanelSize)
                    return (int)((PanelSize - ((FinalQuantity - 1) * DistanceBetweenElements)) - (WidthOfElem * FinalQuantity)) / 2;
                else
                    return (int)((PanelSize - ((FinalQuantity - 1) * DistanceBetweenElements)) - (WidthOfElem * FinalQuantity)) / 2;
            }
            else
                return (int)((PanelSize - ((CoutnOfElements - 1) * DistanceBetweenElements)) - (WidthOfElem * CoutnOfElements)) / 2;
        }

        private static int GetFinalQuantity(int DistanceBetweenElements, int WidthOfElem, int CoutnOfElements)
        {
            int PrimaryQuantity = (int)PanelSize / WidthOfElem; // первоначальное количество элементов в строке без учета маржина
            int WidthOfRowWithMargin = ((WidthOfElem * PrimaryQuantity) + (DistanceBetweenElements * (PrimaryQuantity + 1))); // длинна строки с учетом первоначального
                                                                                                                              // количества элементов и маржином между ними
            int FinalQuantity; // финальное количество элементов

            if (WidthOfRowWithMargin > PanelSize)
            {
                FinalQuantity = PrimaryQuantity - 1;
                int cheak = ((WidthOfElem * FinalQuantity) + (DistanceBetweenElements * (FinalQuantity + 1)));
                if (cheak > PanelSize)
                {
                    FinalQuantity -= 1;
                }
            }
            else
                FinalQuantity = PrimaryQuantity;

            if (FinalQuantity > CoutnOfElements)
                return CoutnOfElements;
            else
                return FinalQuantity;
        }

        public static void SortElements(double WidthOfPage, WrapPanel wrapPanel)
        {
            int rowInNewrelease = 0;

            foreach (dynamic element in wrapPanel.Children)
            {
                if (wrapPanel.Children.IndexOf((Border)element) + 1 == (GetFinalQuantity(30, (int)element.Width, wrapPanel.Children.Count) * rowInNewrelease) + 1)
                {
                    element.Margin = new Thickness(CalcMargin(30, (int)element.Width, wrapPanel.Children.Count), 0, 30, 0);
                    rowInNewrelease++;
                }
                else
                    element.Margin = new Thickness(0, 0, 30, 0);
            }
        }
    }
}
