using System;
using System.Windows;
using System.Windows.Controls;

namespace YourNamespace
{
    public partial class MainWindow : Window
    {
        private string currentInput = "0";
        private string previousInput;
        private string currentOperator;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Digit_Click(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            string digit = button.Content.ToString();
            AppendDigit(digit);
        }

        private void Operator_Click(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            string operatorSymbol = button.Content.ToString();
            HandleOperator(operatorSymbol);
        }

        private void Clear_Click(object sender, RoutedEventArgs e)
        {
            Clear();
        }

        private void ChangeSign_Click(object sender, RoutedEventArgs e)
        {
            ChangeSign();
        }

        private void Percentage_Click(object sender, RoutedEventArgs e)
        {
            CalculatePercentage();
        }

        private void Decimal_Click(object sender, RoutedEventArgs e)
        {
            AddDecimalPoint();
        }

        private void Equals_Click(object sender, RoutedEventArgs e)
        {
            CalculateResult();
        }

        private void AppendDigit(string digit)
        {
            if (currentInput == "0")
                currentInput = digit;
            else
                currentInput += digit;

            UpdateDisplay();
        }

        private void HandleOperator(string operatorSymbol)
        {
            currentOperator = operatorSymbol;
            previousInput = currentInput;
            currentInput = "0";
            UpdateDisplay();
        }

        private void Clear()
        {
            currentInput = "0";
            previousInput = null;
            currentOperator = null;
            UpdateDisplay();
        }

        private void ChangeSign()
        {
            double number = Convert.ToDouble(currentInput);
            number = -number;
            currentInput = number.ToString();
            UpdateDisplay();
        }

        private void CalculatePercentage()
        {
            double number = Convert.ToDouble(currentInput);
            number = number / 100;
            currentInput = number.ToString();
            UpdateDisplay();
        }

        private void AddDecimalPoint()
        {
            if (!currentInput.Contains(","))
            {
                currentInput += ",";
                UpdateDisplay();
            }
        }

        private void CalculateResult()
        {
            double previousNumber = Convert.ToDouble(previousInput);
            double currentNumber = Convert.ToDouble(currentInput);
            double result = 0;

            switch (currentOperator)
            {
                case "+":
                    result = previousNumber + currentNumber;
                    break;
                case "-":
                    result = previousNumber - currentNumber;
                    break;
                case "*":
                    result = previousNumber * currentNumber;
                    break;
                case "/":
                    if (currentNumber != 0)
                        result = previousNumber / currentNumber;
                    else
                        MessageBox.Show("Cannot divide by zero", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    break;
            }

            currentInput = result.ToString();
            previousInput = "0";
            currentOperator = null;
            UpdateDisplay();
        }

        private void UpdateDisplay()
        {
            txtDisplay.Text = currentInput;
        }
    }
}
