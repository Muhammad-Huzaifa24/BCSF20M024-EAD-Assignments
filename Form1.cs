namespace MyCalculatorApp;

public partial class Form1 : Form
{

    private List<string> history = new();

    public Form1()
    {
        InitializeComponent();
        listBoxHistory.Items.Add("History");
    }

    private void DigitButton_Click(object sender, EventArgs e)
    {
        Button button = (Button)sender;
        inputTextBox.Text += button.Text;
    }

    private void OperatorButton_Click(object sender, EventArgs e)
    {
        Button button = (Button)sender;
        inputTextBox.Text += button.Text;
    }
    private void Form1_Load(object sender, EventArgs e)
    {

    }
    private void RemoveLastCharacter(object sender, EventArgs e)
    {
        if (inputTextBox.Text.Length > 0)
        {
            inputTextBox.Text = inputTextBox.Text.Substring(0, inputTextBox.Text.Length - 1);
        }
    }
    private void CalculateButton_Click(object sender, EventArgs e)
    {
        try
        {
            string equation = inputTextBox.Text;
            bool isCorrectFormat = StringSolver.IsInfixExpression(equation);
            if (isCorrectFormat)
            {
                object result = StringSolver.Evaluate(equation);

                // Add the result to the history
                string equationWithResult = $"{equation} = {result}";
                history.Add(equationWithResult);
                listBoxHistory.Items.Add(equationWithResult);
                listBoxHistory.Refresh();

                // Clear the input text box
                //inputTextBox.Clear();
            }
            else
            {
                MessageBox.Show("Error : Eqaution format is not correct", "Format error",MessageBoxButtons.OK, MessageBoxIcon.Error);
                
            }

        }
         catch (ArgumentException ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Invalid Equation Format");
            }
        catch (Exception ex)
        {
            MessageBox.Show($"Error: {ex.Message}", "Calculation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private void ClearButton_Click_1(object sender, EventArgs e)
    {
        inputTextBox.Text = string.Empty;
    }
}
