namespace MyCalculatorApp;

partial class Form1
{
    /// <summary>
    ///  Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    ///  Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null))
        {
            components.Dispose();
        }
        base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    ///  Required method for Designer support - do not modify
    ///  the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
        textBox1 = new TextBox();
        inputTextBox = new TextBox();
        button2 = new Button();
        button4 = new Button();
        button6 = new Button();
        button7 = new Button();
        DigitButton = new Button();
        button9 = new Button();
        button10 = new Button();
        button11 = new Button();
        button12 = new Button();
        button13 = new Button();
        button15 = new Button();
        button16 = new Button();
        button17 = new Button();
        CalculateButton = new Button();
        button19 = new Button();
        button3 = new Button();
        listBoxHistory = new ListBox();
        button1 = new Button();
        ClearButton = new Button();
        SuspendLayout();
        // 
        // textBox1
        // 
        textBox1.BackColor = SystemColors.ScrollBar;
        textBox1.BorderStyle = BorderStyle.FixedSingle;
        textBox1.Font = new Font("Segoe UI", 11F, FontStyle.Bold, GraphicsUnit.Point);
        textBox1.Location = new Point(12, 17);
        textBox1.Multiline = true;
        textBox1.Name = "textBox1";
        textBox1.ReadOnly = true;
        textBox1.Size = new Size(309, 31);
        textBox1.TabIndex = 0;
        textBox1.Text = "Last Equation";
        textBox1.TextAlign = HorizontalAlignment.Center;
        // 
        // inputTextBox
        // 
        inputTextBox.BorderStyle = BorderStyle.FixedSingle;
        inputTextBox.Font = new Font("Segoe UI", 20F, FontStyle.Regular, GraphicsUnit.Point);
        inputTextBox.Location = new Point(12, 48);
        inputTextBox.Multiline = true;
        inputTextBox.Name = "inputTextBox";
        inputTextBox.Size = new Size(309, 75);
        inputTextBox.TabIndex = 1;
        inputTextBox.TextAlign = HorizontalAlignment.Right;
        // 
        // button2
        // 
        button2.FlatStyle = FlatStyle.Flat;
        button2.Font = new Font("Segoe UI", 17F, FontStyle.Regular, GraphicsUnit.Point);
        button2.Location = new Point(167, 129);
        button2.Name = "button2";
        button2.Size = new Size(49, 49);
        button2.TabIndex = 5;
        button2.Text = "-";
        button2.UseVisualStyleBackColor = true;
        button2.Click += OperatorButton_Click;
        // 
        // button4
        // 
        button4.FlatStyle = FlatStyle.Flat;
        button4.Font = new Font("Segoe UI", 17F, FontStyle.Regular, GraphicsUnit.Point);
        button4.Location = new Point(219, 129);
        button4.Name = "button4";
        button4.Size = new Size(49, 49);
        button4.TabIndex = 8;
        button4.Text = "/";
        button4.UseVisualStyleBackColor = true;
        button4.Click += OperatorButton_Click;
        // 
        // button6
        // 
        button6.FlatStyle = FlatStyle.Flat;
        button6.Font = new Font("Segoe UI", 21F, FontStyle.Regular, GraphicsUnit.Point);
        button6.Location = new Point(271, 181);
        button6.Name = "button6";
        button6.Size = new Size(49, 49);
        button6.TabIndex = 11;
        button6.Text = "*";
        button6.UseVisualStyleBackColor = true;
        button6.Click += OperatorButton_Click;
        // 
        // button7
        // 
        button7.FlatStyle = FlatStyle.Flat;
        button7.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
        button7.Location = new Point(116, 181);
        button7.Name = "button7";
        button7.Size = new Size(49, 49);
        button7.TabIndex = 10;
        button7.Text = "7";
        button7.UseVisualStyleBackColor = true;
        button7.Click += DigitButton_Click;
        // 
        // DigitButton
        // 
        DigitButton.FlatStyle = FlatStyle.Flat;
        DigitButton.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
        DigitButton.Location = new Point(167, 181);
        DigitButton.Name = "DigitButton";
        DigitButton.Size = new Size(49, 49);
        DigitButton.TabIndex = 9;
        DigitButton.Text = "8";
        DigitButton.UseVisualStyleBackColor = true;
        DigitButton.Click += DigitButton_Click;
        // 
        // button9
        // 
        button9.FlatStyle = FlatStyle.Flat;
        button9.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
        button9.Location = new Point(219, 233);
        button9.Name = "button9";
        button9.Size = new Size(49, 49);
        button9.TabIndex = 16;
        button9.Text = "6";
        button9.UseVisualStyleBackColor = true;
        button9.Click += DigitButton_Click;
        // 
        // button10
        // 
        button10.BackColor = SystemColors.Window;
        button10.FlatStyle = FlatStyle.Flat;
        button10.Font = new Font("Segoe UI", 25F, FontStyle.Regular, GraphicsUnit.Point);
        button10.Location = new Point(271, 233);
        button10.Name = "button10";
        button10.Size = new Size(49, 103);
        button10.TabIndex = 15;
        button10.Text = "+";
        button10.UseVisualStyleBackColor = false;
        button10.Click += OperatorButton_Click;
        // 
        // button11
        // 
        button11.FlatStyle = FlatStyle.Flat;
        button11.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
        button11.Location = new Point(116, 233);
        button11.Name = "button11";
        button11.Size = new Size(49, 49);
        button11.TabIndex = 14;
        button11.Text = "4";
        button11.UseVisualStyleBackColor = true;
        button11.Click += DigitButton_Click;
        // 
        // button12
        // 
        button12.FlatStyle = FlatStyle.Flat;
        button12.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
        button12.Location = new Point(167, 233);
        button12.Name = "button12";
        button12.Size = new Size(49, 49);
        button12.TabIndex = 13;
        button12.Text = "5";
        button12.UseVisualStyleBackColor = true;
        button12.Click += DigitButton_Click;
        // 
        // button13
        // 
        button13.FlatStyle = FlatStyle.Flat;
        button13.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
        button13.Location = new Point(219, 285);
        button13.Name = "button13";
        button13.Size = new Size(49, 49);
        button13.TabIndex = 20;
        button13.Text = "3";
        button13.UseVisualStyleBackColor = true;
        button13.Click += DigitButton_Click;
        // 
        // button15
        // 
        button15.FlatStyle = FlatStyle.Flat;
        button15.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
        button15.Location = new Point(116, 285);
        button15.Name = "button15";
        button15.Size = new Size(49, 49);
        button15.TabIndex = 18;
        button15.Text = "1";
        button15.UseVisualStyleBackColor = true;
        button15.Click += DigitButton_Click;
        // 
        // button16
        // 
        button16.FlatStyle = FlatStyle.Flat;
        button16.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
        button16.Location = new Point(167, 285);
        button16.Name = "button16";
        button16.Size = new Size(49, 49);
        button16.TabIndex = 17;
        button16.Text = "2";
        button16.UseVisualStyleBackColor = true;
        button16.Click += DigitButton_Click;
        // 
        // button17
        // 
        button17.FlatStyle = FlatStyle.Flat;
        button17.Font = new Font("Segoe UI", 16F, FontStyle.Bold, GraphicsUnit.Point);
        button17.Location = new Point(219, 337);
        button17.Name = "button17";
        button17.Size = new Size(49, 49);
        button17.TabIndex = 24;
        button17.Text = ".";
        button17.TextAlign = ContentAlignment.BottomLeft;
        button17.UseVisualStyleBackColor = true;
        button17.Click += DigitButton_Click;
        // 
        // CalculateButton
        // 
        CalculateButton.BackColor = Color.MediumSeaGreen;
        CalculateButton.FlatStyle = FlatStyle.Popup;
        CalculateButton.Font = new Font("Segoe UI", 25F, FontStyle.Regular, GraphicsUnit.Point);
        CalculateButton.ForeColor = SystemColors.ControlLight;
        CalculateButton.ImageAlign = ContentAlignment.TopCenter;
        CalculateButton.Location = new Point(271, 337);
        CalculateButton.Name = "CalculateButton";
        CalculateButton.Size = new Size(49, 49);
        CalculateButton.TabIndex = 23;
        CalculateButton.Text = "=";
        CalculateButton.TextAlign = ContentAlignment.TopCenter;
        CalculateButton.UseVisualStyleBackColor = false;
        CalculateButton.Click += CalculateButton_Click;
        // 
        // button19
        // 
        button19.FlatStyle = FlatStyle.Flat;
        button19.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
        button19.Location = new Point(116, 337);
        button19.Name = "button19";
        button19.Size = new Size(100, 49);
        button19.TabIndex = 22;
        button19.Text = "0";
        button19.TextAlign = ContentAlignment.MiddleLeft;
        button19.UseVisualStyleBackColor = true;
        button19.Click += DigitButton_Click;
        // 
        // button3
        // 
        button3.FlatStyle = FlatStyle.Flat;
        button3.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
        button3.Location = new Point(219, 181);
        button3.Name = "button3";
        button3.Size = new Size(49, 49);
        button3.TabIndex = 25;
        button3.Text = "9";
        button3.UseVisualStyleBackColor = true;
        button3.Click += DigitButton_Click;
        // 
        // listBoxHistory
        // 
        listBoxHistory.BackColor = SystemColors.ScrollBar;
        listBoxHistory.BorderStyle = BorderStyle.FixedSingle;
        listBoxHistory.FormattingEnabled = true;
        listBoxHistory.HorizontalScrollbar = true;
        listBoxHistory.ItemHeight = 15;
        listBoxHistory.Location = new Point(12, 129);
        listBoxHistory.Name = "listBoxHistory";
        listBoxHistory.Size = new Size(98, 257);
        listBoxHistory.TabIndex = 1;
        // 
        // button1
        // 
        button1.BackColor = Color.Salmon;
        button1.FlatStyle = FlatStyle.Popup;
        button1.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point);
        button1.ForeColor = SystemColors.ControlLight;
        button1.Location = new Point(271, 129);
        button1.Name = "button1";
        button1.Size = new Size(49, 49);
        button1.TabIndex = 27;
        button1.Text = "del";
        button1.UseVisualStyleBackColor = false;
        button1.Click += RemoveLastCharacter;
        // 
        // ClearButton
        // 
        ClearButton.BackColor = SystemColors.ActiveCaptionText;
        ClearButton.FlatStyle = FlatStyle.Popup;
        ClearButton.Font = new Font("Segoe UI", 21F, FontStyle.Regular, GraphicsUnit.Point);
        ClearButton.ForeColor = SystemColors.Control;
        ClearButton.Location = new Point(116, 129);
        ClearButton.Name = "ClearButton";
        ClearButton.Size = new Size(49, 49);
        ClearButton.TabIndex = 28;
        ClearButton.Text = "C";
        ClearButton.UseVisualStyleBackColor = false;
        ClearButton.Click += ClearButton_Click_1;
        // 
        // Form1
        // 
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(335, 392);
        Controls.Add(ClearButton);
        Controls.Add(button1);
        Controls.Add(listBoxHistory);
        Controls.Add(button3);
        Controls.Add(button17);
        Controls.Add(CalculateButton);
        Controls.Add(button19);
        Controls.Add(button13);
        Controls.Add(button15);
        Controls.Add(button16);
        Controls.Add(button9);
        Controls.Add(button10);
        Controls.Add(button11);
        Controls.Add(button12);
        Controls.Add(button6);
        Controls.Add(button7);
        Controls.Add(DigitButton);
        Controls.Add(button4);
        Controls.Add(button2);
        Controls.Add(inputTextBox);
        Controls.Add(textBox1);
        MaximumSize = new Size(351, 431);
        MinimumSize = new Size(351, 431);
        Name = "Form1";
        Text = "The Calculator";
        Load += Form1_Load;
        ResumeLayout(false);
        PerformLayout();
    }

    #endregion

    private TextBox textBox1;
    private TextBox inputTextBox;
    private Button button2;
    private Button button4;
    private Button button6;
    private Button button7;
    private Button DigitButton;
    private Button button9;
    private Button button10;
    private Button button11;
    private Button button12;
    private Button button13;
    private Button button15;
    private Button button16;
    private Button button17;
    private Button CalculateButton;
    private Button button19;
    private Button button3;
    private ListBox listBoxHistory;
    private Button button1;
    private Button ClearButton;
}
