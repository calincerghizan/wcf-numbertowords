using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
using NumberToWord_Client.ServiceReference1;

namespace NumberToWord_Client
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private static readonly Regex Format = new Regex($"(?=^.{{0,12}}$)^[0-9]*(\\,[0-9]{{1,2}})?$");

        private static string MaximStr = "999999999,99";

        private static double Maxim = 999999999.99;

        private static string ErrorMessage =
            $"Please insert a number between {default(double)} and {MaximStr} with maximum two decimals and ',' as decimals separator";

        public MainWindow()
        {
            InitializeComponent();
        }

        /// <summary>
        /// The event triggered when Convert button is clicked
        /// </summary>
        /// <param name="sender">The sender object</param>
        /// <param name="e">The event arggs</param>
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (txtNumber.Text != string.Empty && Format.IsMatch(txtNumber.Text))
            {
                double.TryParse(txtNumber.Text.Replace(",", "."), out var result);
                if (result > Maxim)
                {
                    FormatTxtResultAsError(ErrorMessage);
                }
                else
                {
                    try
                    {
                        var converterServiceClient = new ConverterServiceClient();
                        var response = converterServiceClient.ConvertNumberToWords(result);
                        txtResult.Text = response;
                        FormatTxtResultAsCorrect();
                    }
                    catch (Exception exception)
                    {
                        FormatTxtResultAsError(exception.Message);
                    }
                }
            }
            else
            {
                FormatTxtResultAsError(ErrorMessage);
            }
        }

        private void FormatTxtResultAsError(string message)
        {
            txtResult.Text = message;
            txtResult.FontWeight = FontWeights.Bold;
            txtResult.Foreground = Brushes.Red;
        }

        private void FormatTxtResultAsCorrect()
        {
            txtResult.FontWeight = FontWeights.Normal;
            txtResult.Foreground = Brushes.Black;
        }
    }
}
