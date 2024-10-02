using Calculator.Command;
using System.Reflection.Emit;
using log4net;
using log4net.Config;
using Calculator;

namespace Caluculator
{
    public partial class CalculatorForm : Form
    {
        private int indexInputTextBoxes = 0;

        private OperationType operandType;

        private static readonly ILog log = LogManager.GetLogger(typeof(CalculatorForm));

        enum OperationType
        {
            Addition,       // 加算
            Subtraction,    // 減算
            Multiplication, // 乗算
            Division        // 除算
        }


        public CalculatorForm()
        {
            InitializeLogging();

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

        private void InitializeLogging()
        {
            // log4net の設定を適用
            XmlConfigurator.Configure();


            // この部分の実装について、以下の対応をお願いします。
            // Release時のログ出力がBOM付きという要件を満たしていないため、
            // ログをUTF-8 BOM付きで出力する修正を行ってください。


#if DEBUG
            // Debug時は出力ウィンドウへ
            log4net.Config.BasicConfigurator.Configure();
            log.Info("Debugモード: 出力ウィンドウにログを出力します。");
#else
            // Release時はファイルへ
            log4net.Config.BasicConfigurator.Configure();
            log.Info("Releaseモード: log.txtファイルにログを出力します。");
#endif
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
            clearTextButton.Enabled = true;
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


        private void noTextButton_Click(object sender)
        {
            ClickButtonLog(sender);
            if (indexInputTextBoxes > -1)
            {
                inputTextBoxes[indexInputTextBoxes].Text += ((TextButton)sender).Text;
            }
        }

        private void no0TextButton_Click(object sender, EventArgs e)
        {
            ClickButtonLog(sender);

            if( indexInputTextBoxes< 0)
            {
                return;
            }

            if (string.IsNullOrEmpty(inputTextBoxes[indexInputTextBoxes].Text) == false)
            {
                inputTextBoxes[indexInputTextBoxes].Text += ((TextButton)sender).Text;
            }
        }

        private void no1TextButton_Click(object sender, EventArgs e)
        {
            noTextButton_Click(sender);
        }

        private void no2TextButton_Click(object sender, EventArgs e)
        {
            noTextButton_Click(sender);
        }

        private void no3TextButton_Click(object sender, EventArgs e)
        {
            noTextButton_Click(sender);
        }

        private void no4TextButton_Click(object sender, EventArgs e)
        {
            noTextButton_Click(sender);
        }

        private void no5TextButton_Click(object sender, EventArgs e)
        {
            noTextButton_Click(sender);
        }

        private void no6TextButton_Click(object sender, EventArgs e)
        {
            noTextButton_Click(sender);
        }

        private void no7TextButton_Click(object sender, EventArgs e)
        {
            noTextButton_Click(sender);
        }

        private void no8TextButton_Click(object sender, EventArgs e)
        {
            noTextButton_Click(sender);
        }

        private void no9TextButton_Click(object sender, EventArgs e)
        {
            noTextButton_Click(sender);
        }

        private void pmTextButton_Click(object sender, EventArgs e)
        {
            ClickButtonLog(sender);

            if( indexInputTextBoxes < 0)
            {
                return;
            }

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
            ClickButtonLog(sender);

            if (indexInputTextBoxes < 0)
            {
                return;
            }

            inputTextBoxes[indexInputTextBoxes].Text = string.Empty;
        }

        private void allClearTextButton_Click(object sender, EventArgs e)
        {
            ClickButtonLog(sender);
            Set1stState();
        }

        private void dotTextButton_Click(object sender, EventArgs e)
        {
            ClickButtonLog(sender);

            if (indexInputTextBoxes < 0)
            {
                return;
            }

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
            ClickButtonLog(sender);
            operandType = OperationType.Addition;
            Set2ndState(addTextButton);
        }

        private void subtractTextButton_Click(object sender, EventArgs e)
        {
            ClickButtonLog(sender);
            operandType = OperationType.Subtraction;
            Set2ndState(subtractTextButton);
        }

        private void multiplyTextButton_Click(object sender, EventArgs e)
        {
            ClickButtonLog(sender);
            operandType = OperationType.Multiplication;
            Set2ndState(multiplyTextButton);
        }

        private void divideTextButton_Click(object sender, EventArgs e)
        {
            ClickButtonLog(sender);
            operandType = OperationType.Division;
            Set2ndState(divideTextButton);
        }

        private void equallTextButton_Click(object sender, EventArgs e)
        {
            ClickButtonLog(sender);

            clearTextButton.Enabled = false;
            equallTextButton.Enabled = false;
            SetInactiveState();
            indexInputTextBoxes = -1;

            Calculator.Command.Calculator calculator = new ();

            double a = double.Parse(inputTextBoxes[0].Text);
            double b = double.Parse(inputTextBoxes[1].Text);

            // 加算コマンド
            ICommand command = operandType switch
            {
                OperationType.Addition => new AddCommand(a, b),
                OperationType.Subtraction => new SubtractCommand(a, b),
                OperationType.Multiplication => new MultiplyCommand(a, b),
                OperationType.Division => new DivideCommand(a, b),
                _ => throw new InvalidOperationException()
            };

            outputTextBox.Text = calculator.ExecuteCommand(command).ToString();
            log.Info($"演算結果:{outputTextBox.Text}");
        }

        private void ClickButtonLog(object sender)
        {
            log.Info($"{((TextButton)sender).Text}ボタン押下");
        }
    }
}
