namespace Caluculator
{
    public partial class CalculatorForm : Form
    {
        private int indexInputTextBoxes = 0;

        public CalculatorForm()
        {
            InitializeComponent();

            // inputTextBoxes[0]
            // 
            inputTextBoxes[0] = new TextBox();
            inputTextBoxes[0].Font = new Font("Yu Gothic UI", 20F);
            inputTextBoxes[0].Location = new Point(12, 12);
            inputTextBoxes[0].Name = "inputTextBoxes[0]";
            inputTextBoxes[0].ReadOnly = true;
            inputTextBoxes[0].Size = new Size(362, 52);
            inputTextBoxes[0].TabIndex = 2;
            inputTextBoxes[0].TextAlign = HorizontalAlignment.Right;

            // 
            // inputTextBoxes[1]
            //
            inputTextBoxes[1] = new TextBox();
            inputTextBoxes[1].Font = new Font("Yu Gothic UI", 20F);
            inputTextBoxes[1].Location = new Point(12, 161);
            inputTextBoxes[1].Name = "inputTextBoxes[1]";
            inputTextBoxes[1].ReadOnly = true;
            inputTextBoxes[1].Size = new Size(362, 52);
            inputTextBoxes[1].TabIndex = 33;
            inputTextBoxes[1].TextAlign = HorizontalAlignment.Right;


            foreach (var tb in inputTextBoxes)
            {
                Controls.Add(tb);
            }
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

            SetButtonState(false);
        }

        private void SetButtonState( bool state)
        {
            addTextButton.Enabled = false;
            subtractTextButton.Enabled = false;
            multiplyTextButton.Enabled = false;
            divideTextButton.Enabled = false;
        }

        private void SetActiveState()
        {
            inputTextBoxes[indexInputTextBoxes].BackColor = Color.White;
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
