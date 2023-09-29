using System.Text;

namespace CalculatorNew
{
    public partial class Form1 : Form
    {
        private bool operatorEntered = false;
        public Form1()
        {
            InitializeComponent();
            Parsing();
            Panel1();
            Panel2();
        }
        public int buttonWidth = 48;
        public int buttonHeight = 48;
        public static int gap = 12;
        public int XPosition = gap;
        public int YPosition = gap;
        public StringBuilder buttonText1 = new();
        public StringBuilder buttonText2 = new();
        string operations = "+-*/=^";
        string numbers = "0123456789";

        private void Panel1()
        {
            for (int i = 0; i < numbers.Length; i++)
            {
                Button button = new Button();
                button.Name = i.ToString();
                button.Text = i.ToString();
                button.Size = new System.Drawing.Size(buttonWidth, buttonHeight);
                button.Location = new System.Drawing.Point(XPosition, YPosition);
                button.BackColor = Color.Yellow;
                button.Click += NumberClick;
                panel1.Controls.Add(button);
                XPosition += buttonWidth + gap;
                if ((i + 1) % 3 == 0)
                {
                    XPosition = gap;
                    YPosition += buttonHeight + gap;
                }
            }
        }
        private void Panel2()
        {
            Button but = new();
            XPosition = gap;
            YPosition = gap;
            for (int i = 0; i < operations.Length; i++)
            {
                Button button = new Button();
                button.Name = operations[i].ToString();
                button.Text = operations[i].ToString();
                button.Size = new System.Drawing.Size(buttonWidth, buttonHeight);
                button.Location = new System.Drawing.Point(XPosition, YPosition);
                button.Click += OperatorClick;
                panel2.Controls.Add(button);
                YPosition += buttonHeight + gap;
                if ((i + 1) % 4 == 0)
                {
                    YPosition = gap;
                    XPosition += buttonWidth + gap;
                }
            }
            but.Name = ".";
            but.Text = ".";
            but.Size = new System.Drawing.Size(buttonWidth, buttonHeight);
            but.Location = new System.Drawing.Point(XPosition, YPosition);
            but.Click += NumberClick;
            panel2.Controls.Add(but);

        }
        private void NumberClick(object sender, EventArgs e)
        {
            Button button = (Button)sender;

            if (operatorEntered)
            {
                buttonText2.Append(buttonText1);
                textBox2.Text = buttonText2.ToString();
                buttonText1.Clear();
                buttonText1.Append(button.Name);
                textBox1.Text = buttonText1.ToString();
                operatorEntered = false;
            }
            else if (button.Name == "." && textBox1.Text.Contains(".")) {
            }
            else
            {
                buttonText1.Append(button.Name);
                textBox1.Text = buttonText1.ToString();
            }
        }

        private void OperatorClick(object sender, EventArgs e)
        {
            Button button = (Button)sender;

            if (!operatorEntered && !string.IsNullOrEmpty(textBox1.Text))
            {
                buttonText2.Append(buttonText1);
                textBox2.Text = buttonText2.ToString();
                buttonText1.Clear();
                buttonText1.Append(button.Name);
                textBox1.Text = buttonText1.ToString();
                operatorEntered = true;
            }
            if (button.Name == "=" && textBox2.Text != String.Empty)
            {
                buttonText2.Append(buttonText1);
                textBox2.Text = buttonText2.ToString();
                textBox1.Clear();
                buttonText1.Clear();
                double result = CountLogic.Calculation(textBox2.Text);
                buttonText1.Append(result);
                textBox1.Text = buttonText1.ToString();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1 != null && textBox2 != null) {
                textBox1.Clear();
                textBox2.Clear();
                buttonText1.Clear();
                buttonText2.Clear();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != String.Empty) {
                string ButtonTextString = buttonText1.ToString();
                ButtonTextString = ButtonTextString.Substring(0, ButtonTextString.Length - 1);
                buttonText1.Clear();
                buttonText1.Append(ButtonTextString);
                textBox1.Text = buttonText1.ToString();
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.Size = new Size(533,589);
            this.MaximumSize = new Size(533,589);

        }

        private void Parsing() {
            try
            {
                double num = double.Parse("12.4");
            }
            catch (Exception ex)
            {
                operations = operations.Replace('.', ',');
            }
        }
    }
}