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

namespace _2_Calc
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string leftValue = "";
        string rightValue = "";
        string operation = "";
        int tochkaR = new int();
        int tochkaL = new int();
        public MainWindow()
        {
            InitializeComponent();
        }

        private void ClickNumber(object sender, RoutedEventArgs e)
        {
            var btnText = (string)((Button)e.OriginalSource).Content;
            Moment.Text += btnText;
            if (operation == "")
            {
                leftValue += btnText;
            }
            else
            {
                rightValue += btnText;
            }
        
        }
        private void Click_Oper(object sender, RoutedEventArgs e)
        {
            if (Moment.Text.Length != 0)
            {
                var btnText = (string)((Button)e.OriginalSource).Content;
                if (operation.Length != 1)
                {
                    operation = btnText;
                    Moment.Text += btnText;
                }
            }
        }
        private void CE_Click(object sender, RoutedEventArgs e)
        {
            if (operation == "")
            {
                Moment.Text = "";
                leftValue = "";
                tochkaL = 0;
            }
            else
            {
                Moment.Text = "";
                rightValue = "";
                tochkaR = 0;
                Moment.Text +=leftValue;
                Moment.Text +=operation;
            }
        
        }
        private void C_Click(object sender, RoutedEventArgs e)
        {
            Moment.Text = "";
            leftValue = "";
            rightValue = "";
            operation = "";
            tochkaR = 0;
            tochkaL = 0;
        }
        private void ClickNaz(object sender, RoutedEventArgs e)
        {
            if (Moment.Text.Length != 0 )
            {
                if (operation != "" && rightValue.Length == 0)
                {
                    if (Moment.Text.Last() == operation.Last())
                    {
                        operation = "";
                        Moment.Text = Moment.Text.Remove(Moment.Text.Length - 1);
                    }
                }
                else if(Moment.Text.Last() == ',')
                {
                    if (rightValue.Length == 0)
                    {
                       tochkaL = 0;
                    }
                    tochkaR = 0;
                    Moment.Text = Moment.Text.Remove(Moment.Text.Length - 1);
                }
                else if (rightValue.Length > 0)
                {
                    rightValue = rightValue.Remove(rightValue.Length - 1);
                    Moment.Text = Moment.Text.Remove(Moment.Text.Length - 1);
                }
                else if (leftValue.Length != 0)
                {
                    leftValue = leftValue.Remove(leftValue.Length - 1);
                    Moment.Text = Moment.Text.Remove(Moment.Text.Length - 1);
                }
            }

        }
        private void TOCHKA(object sender, RoutedEventArgs e)
        {
            if (Moment.Text.Length != 0)
            {
                if (tochkaL==0 && rightValue.Length == 0)
                {
                    tochkaL++;
                    Moment.Text += ",";
                    leftValue += ",";
                }
                if (tochkaR == 0&&rightValue.Length>0)
                {
                    tochkaR++;
                    Moment.Text += ",";
                    rightValue += ",";
                }
            }
            else
            {
                tochkaR++;
                leftValue = Moment.Text = "0,";
            }
        }
        private void SS_Click(object sender, RoutedEventArgs e)
        {
            List<SolidColorBrush> brushes = new List<SolidColorBrush> { Brushes.Gray, Brushes.Firebrick, Brushes.Honeydew, Brushes.White, Brushes.Khaki, Brushes.PaleGoldenrod, Brushes.Green, Brushes.Red, Brushes.LightCyan, Brushes.CadetBlue, Brushes.Aqua, Brushes.LightCoral, Brushes.Violet, Brushes.Lime, Brushes.Cornsilk };
            Random rnd = new Random();
            SS.Background = brushes[rnd.Next(0, brushes.Count)];
            if (rightValue.Length>0)
            {
                if (rightValue.Last() != ',')
                {
                    float right;
                    float left;
                    float.TryParse(rightValue, out right);
                    float.TryParse(leftValue, out left);
                    if (operation == "/"&&right!=0)
                    {
                        Next.Text = Moment.Text;
                        leftValue = Moment.Text = Convert.ToString(left / right);
                        operation = "";
                        rightValue = "";
                        tochkaL = 0;
                        tochkaR = 0;
                    }
                    else if (operation == "*")
                    {
                        Next.Text = Moment.Text;
                        leftValue = Moment.Text = Convert.ToString(left * right);
                        operation = "";
                        rightValue = "";
                        tochkaL = 0;
                        tochkaR = 0;
                    }
                    else if (operation == "-")
                    {
                        Next.Text = Moment.Text;
                        leftValue = Moment.Text = Convert.ToString(left - right);
                        operation = "";
                        rightValue = "";
                        tochkaL = 0;
                        tochkaR = 0;
                    }
                    else if (operation == "+")
                    {
                        Next.Text = Moment.Text;
                        leftValue = Moment.Text = Convert.ToString(left + right);
                        operation = "";
                        rightValue = "";
                        tochkaL = 0;
                        tochkaR = 0;
                    }
                }
            }
        }
    }
}
