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

using calc.ClientSide;

namespace calc
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        private string calcMemoryExpression;
        
        public MainWindow()
        {
            this.calcMemoryExpression = "0";
            InitializeComponent();
        }

        private void ExpressionTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void ResultTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }



        private void LefBracket_ButtonClick(object sender, RoutedEventArgs e)
        {
            ExpressionTextBox.Text = ExpressionTextBox.Text + "(";   
        }

        private void RightBracket_ButtonClick(object sender, RoutedEventArgs e)
        {
            ExpressionTextBox.Text = ExpressionTextBox.Text + ")";
        }

        private void C_ButtonClick(object sender, RoutedEventArgs e)
        {
            ExpressionTextBox.Clear();
        }

        private void Backspace_ButtonClick(object sender, RoutedEventArgs e)
        {
            if (ExpressionTextBox.Text.Length > 0)
                ExpressionTextBox.Text = ExpressionTextBox.Text.Substring(0, ExpressionTextBox.Text.Length - 1);
        }

        private void _1_ButtonClick(object sender, RoutedEventArgs e)
        {
            ExpressionTextBox.Text = ExpressionTextBox.Text + "1";
        }

        private void _2_ButtonClick(object sender, RoutedEventArgs e)
        {
            ExpressionTextBox.Text = ExpressionTextBox.Text + "2";
        }

        private void _3_ButtonClick(object sender, RoutedEventArgs e)
        {
            ExpressionTextBox.Text = ExpressionTextBox.Text + "3";
        }

        private void _4_ButtonClick(object sender, RoutedEventArgs e)
        {
            ExpressionTextBox.Text = ExpressionTextBox.Text + "4";
        }

        private void _5_ButtonClick(object sender, RoutedEventArgs e)
        {
            ExpressionTextBox.Text = ExpressionTextBox.Text + "5";
        }

        private void _6_ButtonClick(object sender, RoutedEventArgs e)
        {
            ExpressionTextBox.Text = ExpressionTextBox.Text + "6";
        }

        private void _7_ButtonClick(object sender, RoutedEventArgs e)
        {
            ExpressionTextBox.Text = ExpressionTextBox.Text + "7";
        }

        private void _8_ButtonClick(object sender, RoutedEventArgs e)
        {
            ExpressionTextBox.Text = ExpressionTextBox.Text + "8";
        }

        private void _9_ButtonClick(object sender, RoutedEventArgs e)
        {
            ExpressionTextBox.Text = ExpressionTextBox.Text + "9";
        }


        private void Divide_ButtonClick(object sender, RoutedEventArgs e)
        {
            ExpressionTextBox.Text = ExpressionTextBox.Text + "/";
        }

        private void Multiply_ButtonClick(object sender, RoutedEventArgs e)
        {
            ExpressionTextBox.Text = ExpressionTextBox.Text + "*";
        }

        private void Substract_ButtonClick(object sender, RoutedEventArgs e)
        {
            ExpressionTextBox.Text = ExpressionTextBox.Text + "-";
        }

        private void PlusMinus_ButtonClick(object sender, RoutedEventArgs e)
        {
            if (ExpressionTextBox.Text.Length > 0)
                ExpressionTextBox.Text = "-(" + ExpressionTextBox.Text + ")";
        }

        private void _0_ButtonClick(object sender, RoutedEventArgs e)
        {
            ExpressionTextBox.Text = ExpressionTextBox.Text + "0";
        }

        private void Mod_ButtonClick(object sender, RoutedEventArgs e)
        {
            ExpressionTextBox.Text = ExpressionTextBox.Text + "mod";
        }

        private void Add_ButtonClick(object sender, RoutedEventArgs e)
        {
            ExpressionTextBox.Text = ExpressionTextBox.Text + "+";
        }

        private void MR_ButtonClick(object sender, RoutedEventArgs e)
        {
            ExpressionTextBox.Clear();
            ExpressionTextBox.Text = this.calcMemoryExpression;
        }

        private void MPlus_ButtonClick(object sender, RoutedEventArgs e)
        {
            if (ExpressionTextBox.Text.Length > 0) {
                this.calcMemoryExpression =   "(" + ExpressionTextBox.Text + "+" + this.calcMemoryExpression + ")";
                ExpressionTextBox.Clear();
            }
            
        }

        private void MC_ButtonClick(object sender, RoutedEventArgs e)
        {
            this.calcMemoryExpression = "0";
        }

        private void Result_ButtonClick(object sender, RoutedEventArgs e)
        {
            ResultTextBox.Text = CommonUtilities.ProcessResult(ExpressionTextBox.Text);
        }
    }
}
