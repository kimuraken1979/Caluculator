namespace Caluculator
{
    public partial class CalculatorForm : Form
    {
        private int indexInputTextBoxes = 0;

        public CalculatorForm()
        {
            InitializeComponent();
        }


        private void CalculatorForm_Load(object sender, EventArgs e)
        {
            Set1stState();
        }

        private void Set1stState()
        {
            SetInitState();

            indexInputTextBoxes = 0;
            SetActiveState();
        }

        private void SetInitState()
        {
            foreach (var tb in inputTextBoxes)
            {
                tb.Text = string.Empty;
                tb.BackColor = SystemColors.Control;
            }

            outputTextBox.Text = string.Empty;
            outputTextBox.BackColor = SystemColors.Control;
        }

        private void SetActiveState()
        {
            inputTextBoxes[indexInputTextBoxes].BackColor = Color.Wheat;
        }

        private void no0TextButton_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(inputTextBoxes[indexInputTextBoxes].Text) == false)
            {
                inputTextBoxes[indexInputTextBoxes].Text += "0";
            }
        }

        private void no1TextButton_Click(object sender, EventArgs e)
        {
            inputTextBoxes[indexInputTextBoxes].Text += "1";
        }
    }
}
