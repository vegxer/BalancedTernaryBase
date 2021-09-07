
namespace lab1
{
    partial class MainForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.inputTextbox = new System.Windows.Forms.TextBox();
            this.outputTextbox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.buttonToThreeBase = new System.Windows.Forms.Button();
            this.buttonToDecimalBase = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.действиеToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuConvert = new System.Windows.Forms.ToolStripMenuItem();
            this.menuArithAction = new System.Windows.Forms.ToolStripMenuItem();
            this.textBoxFirst = new System.Windows.Forms.TextBox();
            this.textBoxSecond = new System.Windows.Forms.TextBox();
            this.textBoxResult = new System.Windows.Forms.TextBox();
            this.labelEquality = new System.Windows.Forms.Label();
            this.comboBoxActions = new System.Windows.Forms.ComboBox();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // inputTextbox
            // 
            this.inputTextbox.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F);
            this.inputTextbox.Location = new System.Drawing.Point(13, 45);
            this.inputTextbox.MaxLength = 13;
            this.inputTextbox.Name = "inputTextbox";
            this.inputTextbox.Size = new System.Drawing.Size(180, 35);
            this.inputTextbox.TabIndex = 0;
            this.inputTextbox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.inputTextbox_KeyPress);
            // 
            // outputTextbox
            // 
            this.outputTextbox.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F);
            this.outputTextbox.Location = new System.Drawing.Point(479, 45);
            this.outputTextbox.MaxLength = 13;
            this.outputTextbox.Name = "outputTextbox";
            this.outputTextbox.ReadOnly = true;
            this.outputTextbox.Size = new System.Drawing.Size(180, 35);
            this.outputTextbox.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 35F);
            this.label1.Location = new System.Drawing.Point(193, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 54);
            this.label1.TabIndex = 2;
            this.label1.Text = "➧";
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 35F);
            this.label2.Location = new System.Drawing.Point(439, 34);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(34, 54);
            this.label2.TabIndex = 3;
            this.label2.Text = "➧";
            // 
            // buttonToThreeBase
            // 
            this.buttonToThreeBase.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.buttonToThreeBase.Location = new System.Drawing.Point(232, 38);
            this.buttonToThreeBase.Name = "buttonToThreeBase";
            this.buttonToThreeBase.Size = new System.Drawing.Size(210, 26);
            this.buttonToThreeBase.TabIndex = 4;
            this.buttonToThreeBase.Text = "В троичную уравновешенную";
            this.buttonToThreeBase.UseVisualStyleBackColor = true;
            this.buttonToThreeBase.Click += new System.EventHandler(this.buttonToThreeBase_Click);
            // 
            // buttonToDecimalBase
            // 
            this.buttonToDecimalBase.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.buttonToDecimalBase.Location = new System.Drawing.Point(232, 63);
            this.buttonToDecimalBase.Name = "buttonToDecimalBase";
            this.buttonToDecimalBase.Size = new System.Drawing.Size(210, 26);
            this.buttonToDecimalBase.TabIndex = 5;
            this.buttonToDecimalBase.Text = "В десятичную";
            this.buttonToDecimalBase.UseVisualStyleBackColor = true;
            this.buttonToDecimalBase.Click += new System.EventHandler(this.buttonToDecimalBase_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.SystemColors.ControlLight;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.действиеToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(764, 24);
            this.menuStrip1.TabIndex = 6;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // действиеToolStripMenuItem
            // 
            this.действиеToolStripMenuItem.BackColor = System.Drawing.Color.LightGray;
            this.действиеToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuConvert,
            this.menuArithAction});
            this.действиеToolStripMenuItem.Name = "действиеToolStripMenuItem";
            this.действиеToolStripMenuItem.Size = new System.Drawing.Size(83, 20);
            this.действиеToolStripMenuItem.Text = "Действие ▼";
            // 
            // menuConvert
            // 
            this.menuConvert.CheckOnClick = true;
            this.menuConvert.Name = "menuConvert";
            this.menuConvert.Size = new System.Drawing.Size(222, 22);
            this.menuConvert.Text = "Перевод";
            this.menuConvert.Click += new System.EventHandler(this.menuConvert_Click);
            // 
            // menuArithAction
            // 
            this.menuArithAction.CheckOnClick = true;
            this.menuArithAction.Name = "menuArithAction";
            this.menuArithAction.Size = new System.Drawing.Size(222, 22);
            this.menuArithAction.Text = "Арифметическое действие";
            this.menuArithAction.Click += new System.EventHandler(this.menuArithAction_Click);
            // 
            // textBoxFirst
            // 
            this.textBoxFirst.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F);
            this.textBoxFirst.Location = new System.Drawing.Point(11, 45);
            this.textBoxFirst.MaxLength = 15;
            this.textBoxFirst.Name = "textBoxFirst";
            this.textBoxFirst.Size = new System.Drawing.Size(213, 35);
            this.textBoxFirst.TabIndex = 7;
            this.textBoxFirst.TextChanged += new System.EventHandler(this.textBoxFirst_TextChanged);
            this.textBoxFirst.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxFirst_KeyPress);
            // 
            // textBoxSecond
            // 
            this.textBoxSecond.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F);
            this.textBoxSecond.Location = new System.Drawing.Point(285, 45);
            this.textBoxSecond.MaxLength = 15;
            this.textBoxSecond.Name = "textBoxSecond";
            this.textBoxSecond.Size = new System.Drawing.Size(213, 35);
            this.textBoxSecond.TabIndex = 8;
            this.textBoxSecond.TextChanged += new System.EventHandler(this.textBoxFirst_TextChanged);
            this.textBoxSecond.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxFirst_KeyPress);
            // 
            // textBoxResult
            // 
            this.textBoxResult.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F);
            this.textBoxResult.Location = new System.Drawing.Point(540, 45);
            this.textBoxResult.MaxLength = 15;
            this.textBoxResult.Name = "textBoxResult";
            this.textBoxResult.ReadOnly = true;
            this.textBoxResult.Size = new System.Drawing.Size(213, 35);
            this.textBoxResult.TabIndex = 9;
            // 
            // labelEquality
            // 
            this.labelEquality.AutoSize = true;
            this.labelEquality.Font = new System.Drawing.Font("Microsoft Sans Serif", 22F, System.Drawing.FontStyle.Bold);
            this.labelEquality.Location = new System.Drawing.Point(503, 44);
            this.labelEquality.Name = "labelEquality";
            this.labelEquality.Size = new System.Drawing.Size(33, 36);
            this.labelEquality.TabIndex = 10;
            this.labelEquality.Text = "=";
            // 
            // comboBoxActions
            // 
            this.comboBoxActions.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.comboBoxActions.FormattingEnabled = true;
            this.comboBoxActions.Items.AddRange(new object[] {
            "+",
            "—",
            "×"});
            this.comboBoxActions.Location = new System.Drawing.Point(230, 46);
            this.comboBoxActions.Name = "comboBoxActions";
            this.comboBoxActions.Size = new System.Drawing.Size(49, 33);
            this.comboBoxActions.TabIndex = 11;
            this.comboBoxActions.TextChanged += new System.EventHandler(this.textBoxFirst_TextChanged);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(764, 101);
            this.Controls.Add(this.comboBoxActions);
            this.Controls.Add(this.labelEquality);
            this.Controls.Add(this.textBoxResult);
            this.Controls.Add(this.textBoxSecond);
            this.Controls.Add(this.textBoxFirst);
            this.Controls.Add(this.buttonToDecimalBase);
            this.Controls.Add(this.buttonToThreeBase);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.outputTextbox);
            this.Controls.Add(this.inputTextbox);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Троичная уравновешенная система счисления";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox inputTextbox;
        private System.Windows.Forms.TextBox outputTextbox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button buttonToThreeBase;
        private System.Windows.Forms.Button buttonToDecimalBase;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem действиеToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem menuConvert;
        private System.Windows.Forms.ToolStripMenuItem menuArithAction;
        private System.Windows.Forms.TextBox textBoxFirst;
        private System.Windows.Forms.TextBox textBoxSecond;
        private System.Windows.Forms.TextBox textBoxResult;
        private System.Windows.Forms.Label labelEquality;
        private System.Windows.Forms.ComboBox comboBoxActions;
    }
}

