using PhoneVM.Controller;
using PhoneVM.Model;
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
using System.Windows.Shapes;

namespace PhoneVM
{
    /// <summary>
    /// Interaction logic for CalculatorWindow.xaml
    /// </summary>
    public partial class CalculatorWindow : Window
    {
        
        private string value = "0";
        private string execute = "";
        private string next_val = "";

        private Member member;

        private WindowProperties windowProperties;
        public CalculatorWindow()
        {
            InitializeComponent();
            windowProperties = new WindowProperties(this);
        }

        public void setMember(Member member)
        {
            this.member = member;
        }

        private void close(object sender, RoutedEventArgs e)
        {
            windowProperties.close_window(this.member);
        }
        private void minimise(object sender, RoutedEventArgs e)
        {
            windowProperties.minimise();
        }

        private void maximise(object sender, RoutedEventArgs e)
        {
            windowProperties.maximise();
        }
        private void CloseIconPressed(object sender, RoutedEventArgs e)
        {
            Environment.Exit(0);
        }

        private void calculate()
        {
            if (float.TryParse(next_val, out float num))
            {
                float val = 0;
                switch (execute)
                {
                    case "+":
                        val = float.Parse(value) + (num);
                        value = val.ToString();
                        break;
                    case "-":
                        val = float.Parse(value) - num;
                        value = val.ToString();
                        break;
                    case "*":
                        val = float.Parse(value) * num;
                        value = val.ToString();
                        break;
                    case "/":
                        if (num != 0)
                        {
                            val = float.Parse(value) / num;
                            value = val.ToString();
                        }
                        else
                            MessageBox.Show("Cannot divide by zero");
                        break;
                }
                Value.Content = value.ToString();
                next_val = "";  // Reset for next operation
            }
        }

        private void _equal(object sender, RoutedEventArgs args)
        {
            calculate();
        }

        private void AppendToNextVal(string num)
        {
            next_val += num;
            small_Value.Content += num;
            
            if (Value.Content.ToString() == "0")
            {
                value = num;
                Value.Content = value.ToString();
                small_Value.Content = value.ToString();
            }
            Value.Content = next_val;
        }

        private void _9(object sender, RoutedEventArgs args) => AppendToNextVal("9");
        private void _8(object sender, RoutedEventArgs args) => AppendToNextVal("8");
        private void _7(object sender, RoutedEventArgs args) => AppendToNextVal("7");
        private void _6(object sender, RoutedEventArgs args) => AppendToNextVal("6");
        private void _5(object sender, RoutedEventArgs args) => AppendToNextVal("5");
        private void _4(object sender, RoutedEventArgs args) => AppendToNextVal("4");
        private void _3(object sender, RoutedEventArgs args) => AppendToNextVal("3");
        private void _2(object sender, RoutedEventArgs args) => AppendToNextVal("2");
        private void _1(object sender, RoutedEventArgs args) => AppendToNextVal("1");
        private void _0(object sender, RoutedEventArgs args) => AppendToNextVal("0");
        private void _00(object sender, RoutedEventArgs args) => AppendToNextVal("00");

        private void _dot(object sender, RoutedEventArgs args)
        {
            if (!next_val.Contains("."))
            {
                next_val = ".";
                small_Value.Content += next_val;
            }
        }

        private void _plus(object sender, RoutedEventArgs args)
        {
            small_Value.Content += " + ";
            calculate();
            execute = "+";
        }

        private void _minus(object sender, RoutedEventArgs args)
        {
            small_Value.Content += " - ";
            calculate();
            execute = "-";
        }

        private void _times(object sender, RoutedEventArgs args)
        {
            small_Value.Content += " x ";
            calculate();
            execute = "*";
        }

        private void _devide(object sender, RoutedEventArgs args)
        {
            small_Value.Content += " / ";
            calculate();
            execute = "/";
        }

        private void ce(object sender, RoutedEventArgs args)
        {
            small_Value.Content = "";
            execute = "";
            next_val = "";
            value = "0";
            Value.Content = value;

        }
    }
}
