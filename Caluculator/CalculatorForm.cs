using Calculator.Command;
using System.Reflection.Emit;

namespace Caluculator
{
    public partial class CalculatorForm : Form
    {
        private int indexInputTextBoxes = 0;

        private OperationType operandType;

        enum OperationType
        {
            Addition,       // ‰ÁŽZ
            Subtraction,    // Œ¸ŽZ
            Multiplication, // æŽZ
            Division        // œŽZ
        }


        public CalculatorForm()
        {
            InitializeComponent();

            inputTextBoxes = new TextBox[2];

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
            inputTextBoxes[0].TextChanged += new EventHandler(TextBox_TextChanged0);


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
            inputTextBoxes[1].TextChanged += new EventHandler(TextBox_TextChanged1);


            foreach (var tb in inputTextBoxes)
            {
                Controls.Add(tb);
            }
        }


        private void TextBox_TextChanged0(object sender, EventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            SetButtonState(!string.IsNullOrEmpty(textBox.Text));
        }

        private void TextBox_TextChanged1(object sender, EventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            equallTextButton.Enabled = (!string.IsNullOrEmpty(textBox.Text));
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
            SetButtonVisible(true);

            equallTextButton.Enabled = false;
        }

        private void SetButtonState(bool state)
        {
            addTextButton.Enabled = state;
            subtractTextButton.Enabled = state;
            multiplyTextButton.Enabled = state;
            divideTextButton.Enabled = state;
        }
        private void SetButtonVisible(bool visible)
        {
            addTextButton.Visible = visible;
            subtractTextButton.Visible = visible;
            multiplyTextButton.Visible = visible;
            divideTextButton.Visible = visible;
        }

        private void SetInactiveState()
        {
            inputTextBoxes[indexInputTextBoxes].BackColor = SystemColors.Control;
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

        private void no2TextButton_Click(object sender, EventArgs e)
        {
            inputTextBoxes[indexInputTextBoxes].Text += "2";
        }

        private void no3TextButton_Click(object sender, EventArgs e)
        {
            inputTextBoxes[indexInputTextBoxes].Text += "3";
        }

        private void no4TextButton_Click(object sender, EventArgs e)
        {
            inputTextBoxes[indexInputTextBoxes].Text += "4";
        }

        private void no5TextButton_Click(object sender, EventArgs e)
        {
            inputTextBoxes[indexInputTextBoxes].Text += "5";
        }

        private void no6TextButton_Click(object sender, EventArgs e)
        {
            inputTextBoxes[indexInputTextBoxes].Text += "6";
        }

        private void no7TextButton_Click(object sender, EventArgs e)
        {
            inputTextBoxes[indexInputTextBoxes].Text += "7";
        }

        private void no8TextButton_Click(object sender, EventArgs e)
        {
            inputTextBoxes[indexInputTextBoxes].Text += "8";
        }

        private void no9TextButton_Click(object sender, EventArgs e)
        {
            inputTextBoxes[indexInputTextBoxes].Text += "9";
        }

        private void pmTextButton_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(inputTextBoxes[indexInputTextBoxes].Text))
            {
                return;
            }

            if (inputTextBoxes[indexInputTextBoxes].Text[0] == '-')
            {
                inputTextBoxes[indexInputTextBoxes].Text = inputTextBoxes[indexInputTextBoxes].Text.Remove(0, 1);
            }
            else
            {
                inputTextBoxes[indexInputTextBoxes].Text = inputTextBoxes[indexInputTextBoxes].Text.Insert(0, "-");
            }
        }

        private void clearTextButton_Click(object sender, EventArgs e)
        {
            inputTextBoxes[indexInputTextBoxes].Text = string.Empty;
        }

        private void allClearTextButton_Click(object sender, EventArgs e)
        {
            Set1stState();
        }

        private void dotTextButton_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(inputTextBoxes[indexInputTextBoxes].Text) == true)
            {
                inputTextBoxes[indexInputTextBoxes].Text = "0";
            }

            inputTextBoxes[indexInputTextBoxes].Text += ".";
        }

        private void Set2ndState(Calculator.TextButton textButton)
        {
            SetButtonState(false);
            SetButtonVisible(false);

            textButton.Visible = true;

            SetInactiveState();
            indexInputTextBoxes = 1;
            SetActiveState();
        }

        private void addTextButton_Click(object sender, EventArgs e)
        {
            operandType = OperationType.Addition;
            Set2ndState(addTextButton);
        }

        private void subtractTextButton_Click(object sender, EventArgs e)
        {
            operandType = OperationType.Subtraction;
            Set2ndState(subtractTextButton);
        }

        private void multiplyTextButton_Click(object sender, EventArgs e)
        {
            operandType = OperationType.Multiplication;
            Set2ndState(multiplyTextButton);
        }

        private void divideTextButton_Click(object sender, EventArgs e)
        {
            operandType = OperationType.Division;
            Set2ndState(divideTextButton);
        }

        private void equallTextButton_Click(object sender, EventArgs e)
        {
            equallTextButton.Enabled = false;
            SetInactiveState();

            Calculator.Command.Calculator calculator = new ();

            double a = double.Parse(inputTextBoxes[0].Text);
            double b = double.Parse(inputTextBoxes[1].Text);

            // ‰ÁŽZƒRƒ}ƒ“ƒh
            ICommand command = operandType switch
            {
                OperationType.Addition => new AddCommand(a, b),
                OperationType.Subtraction => new SubtractCommand(a, b),
                OperationType.Multiplication => new MultiplyCommand(a, b),
                OperationType.Division => new DivideCommand(a, b),
                _ => throw new InvalidOperationException()
            };


            outputTextBox.Text = calculator.ExecuteCommand(command).ToString();
            System.Diagnostics.Debug.WriteLine("ƒeƒXƒg: " + calculator.ExecuteCommand(command));
        }
    }
}
