namespace Laba_2
{
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
      menuStrip1 = new MenuStrip();
      файлToolStripMenuItem = new ToolStripMenuItem();
      загрузитьИзExcelToolStripMenuItem = new ToolStripMenuItem();
      загрузитьИзGoogleToolStripMenuItem = new ToolStripMenuItem();
      выходToolStripMenuItem = new ToolStripMenuItem();
      действияToolStripMenuItem = new ToolStripMenuItem();
      рассчитатьToolStripMenuItem = new ToolStripMenuItem();
      очиститьToolStripMenuItem = new ToolStripMenuItem();
      сгенерироватьДанныеToolStripMenuItem = new ToolStripMenuItem();
      справкаToolStripMenuItem = new ToolStripMenuItem();
      оПрограммеToolStripMenuItem = new ToolStripMenuItem();
      chkBubble = new CheckBox();
      chkInsertion = new CheckBox();
      chkShaker = new CheckBox();
      chkQuick = new CheckBox();
      chkBogo = new CheckBox();
      rbAscending = new RadioButton();
      rbDescending = new RadioButton();
      dgvData = new DataGridView();
      colValue = new DataGridViewTextBoxColumn();
      txtResults = new TextBox();
      lblCount = new Label();
      lblMin = new Label();
      lblMax = new Label();
      lblBogoLimit = new Label();
      txtCount = new TextBox();
      txtMin = new TextBox();
      txtMax = new TextBox();
      txtBogoLimit = new TextBox();
      menuStrip1.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)dgvData).BeginInit();
      SuspendLayout();
      // 
      // menuStrip1
      // 
      menuStrip1.Items.AddRange(new ToolStripItem[] { файлToolStripMenuItem, действияToolStripMenuItem, справкаToolStripMenuItem });
      menuStrip1.Location = new Point(0, 0);
      menuStrip1.Name = "menuStrip1";
      menuStrip1.Size = new Size(984, 24);
      menuStrip1.TabIndex = 0;
      menuStrip1.Text = "menuStrip1";
      // 
      // файлToolStripMenuItem
      // 
      файлToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { загрузитьИзExcelToolStripMenuItem, загрузитьИзGoogleToolStripMenuItem, выходToolStripMenuItem });
      файлToolStripMenuItem.Name = "файлToolStripMenuItem";
      файлToolStripMenuItem.Size = new Size(48, 20);
      файлToolStripMenuItem.Text = "Файл";
      // 
      // загрузитьИзExcelToolStripMenuItem
      // 
      загрузитьИзExcelToolStripMenuItem.Name = "загрузитьИзExcelToolStripMenuItem";
      загрузитьИзExcelToolStripMenuItem.Size = new Size(184, 22);
      загрузитьИзExcelToolStripMenuItem.Text = "Загрузить из Excel";
      загрузитьИзExcelToolStripMenuItem.Click += загрузитьИзExcelToolStripMenuItem_Click;
      // 
      // загрузитьИзGoogleToolStripMenuItem
      // 
      загрузитьИзGoogleToolStripMenuItem.Name = "загрузитьИзGoogleToolStripMenuItem";
      загрузитьИзGoogleToolStripMenuItem.Size = new Size(184, 22);
      загрузитьИзGoogleToolStripMenuItem.Text = "Загрузить из Google";
      загрузитьИзGoogleToolStripMenuItem.Click += загрузитьИзGoogleToolStripMenuItem_Click;
      // 
      // выходToolStripMenuItem
      // 
      выходToolStripMenuItem.Name = "выходToolStripMenuItem";
      выходToolStripMenuItem.Size = new Size(184, 22);
      выходToolStripMenuItem.Text = "Выход";
      выходToolStripMenuItem.Click += выходToolStripMenuItem_Click;
      // 
      // действияToolStripMenuItem
      // 
      действияToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { рассчитатьToolStripMenuItem, очиститьToolStripMenuItem, сгенерироватьДанныеToolStripMenuItem });
      действияToolStripMenuItem.Name = "действияToolStripMenuItem";
      действияToolStripMenuItem.Size = new Size(70, 20);
      действияToolStripMenuItem.Text = "Действия";
      // 
      // рассчитатьToolStripMenuItem
      // 
      рассчитатьToolStripMenuItem.Name = "рассчитатьToolStripMenuItem";
      рассчитатьToolStripMenuItem.Size = new Size(201, 22);
      рассчитатьToolStripMenuItem.Text = "Рассчитать";
      рассчитатьToolStripMenuItem.Click += рассчитатьToolStripMenuItem_Click;
      // 
      // очиститьToolStripMenuItem
      // 
      очиститьToolStripMenuItem.Name = "очиститьToolStripMenuItem";
      очиститьToolStripMenuItem.Size = new Size(201, 22);
      очиститьToolStripMenuItem.Text = "Очистить";
      очиститьToolStripMenuItem.Click += очиститьToolStripMenuItem_Click;
      // 
      // сгенерироватьДанныеToolStripMenuItem
      // 
      сгенерироватьДанныеToolStripMenuItem.Name = "сгенерироватьДанныеToolStripMenuItem";
      сгенерироватьДанныеToolStripMenuItem.Size = new Size(201, 22);
      сгенерироватьДанныеToolStripMenuItem.Text = "Сгенерировать данные";
      сгенерироватьДанныеToolStripMenuItem.Click += сгенерироватьДанныеToolStripMenuItem_Click;
      // 
      // справкаToolStripMenuItem
      // 
      справкаToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { оПрограммеToolStripMenuItem });
      справкаToolStripMenuItem.Name = "справкаToolStripMenuItem";
      справкаToolStripMenuItem.Size = new Size(65, 20);
      справкаToolStripMenuItem.Text = "Справка";
      // 
      // оПрограммеToolStripMenuItem
      // 
      оПрограммеToolStripMenuItem.Name = "оПрограммеToolStripMenuItem";
      оПрограммеToolStripMenuItem.Size = new Size(149, 22);
      оПрограммеToolStripMenuItem.Text = "О программе";
      оПрограммеToolStripMenuItem.Click += оПрограммеToolStripMenuItem_Click;
      // 
      // chkBubble
      // 
      chkBubble.AutoSize = true;
      chkBubble.Location = new Point(12, 72);
      chkBubble.Name = "chkBubble";
      chkBubble.Size = new Size(99, 19);
      chkBubble.TabIndex = 1;
      chkBubble.Text = "Пузырьковая";
      chkBubble.UseVisualStyleBackColor = true;
      // 
      // chkInsertion
      // 
      chkInsertion.AutoSize = true;
      chkInsertion.Location = new Point(12, 97);
      chkInsertion.Name = "chkInsertion";
      chkInsertion.Size = new Size(84, 19);
      chkInsertion.TabIndex = 2;
      chkInsertion.Text = "Вставками";
      chkInsertion.UseVisualStyleBackColor = true;
      // 
      // chkShaker
      // 
      chkShaker.AutoSize = true;
      chkShaker.Location = new Point(12, 122);
      chkShaker.Name = "chkShaker";
      chkShaker.Size = new Size(88, 19);
      chkShaker.TabIndex = 3;
      chkShaker.Text = "Шейкерная";
      chkShaker.UseVisualStyleBackColor = true;
      // 
      // chkQuick
      // 
      chkQuick.AutoSize = true;
      chkQuick.Location = new Point(193, 72);
      chkQuick.Name = "chkQuick";
      chkQuick.Size = new Size(72, 19);
      chkQuick.TabIndex = 4;
      chkQuick.Text = "Быстрая";
      chkQuick.UseVisualStyleBackColor = true;
      // 
      // chkBogo
      // 
      chkBogo.AutoSize = true;
      chkBogo.Location = new Point(193, 97);
      chkBogo.Name = "chkBogo";
      chkBogo.Size = new Size(59, 19);
      chkBogo.TabIndex = 5;
      chkBogo.Text = "BOGO";
      chkBogo.UseVisualStyleBackColor = true;
      // 
      // rbAscending
      // 
      rbAscending.AutoSize = true;
      rbAscending.Checked = true;
      rbAscending.Location = new Point(12, 177);
      rbAscending.Name = "rbAscending";
      rbAscending.Size = new Size(116, 19);
      rbAscending.TabIndex = 6;
      rbAscending.TabStop = true;
      rbAscending.Text = "По возрастанию";
      rbAscending.UseVisualStyleBackColor = true;
      // 
      // rbDescending
      // 
      rbDescending.AutoSize = true;
      rbDescending.Location = new Point(193, 177);
      rbDescending.Name = "rbDescending";
      rbDescending.Size = new Size(102, 19);
      rbDescending.TabIndex = 7;
      rbDescending.Text = "По убыванию";
      rbDescending.UseVisualStyleBackColor = true;
      // 
      // dgvData
      // 
      dgvData.AllowUserToDeleteRows = false;
      dgvData.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
      dgvData.Columns.AddRange(new DataGridViewColumn[] { colValue });
      dgvData.Location = new Point(12, 226);
      dgvData.Name = "dgvData";
      dgvData.RowHeadersVisible = false;
      dgvData.Size = new Size(450, 250);
      dgvData.TabIndex = 8;
      dgvData.CellContentClick += dgvData_CellContentClick;
      dgvData.EditingControlShowing += dgvData_EditingControlShowing;
      // 
      // colValue
      // 
      colValue.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
      colValue.HeaderText = "Число";
      colValue.Name = "colValue";
      // 
      // txtResults
      // 
      txtResults.Font = new Font("Consolas", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 204);
      txtResults.Location = new Point(490, 226);
      txtResults.Multiline = true;
      txtResults.Name = "txtResults";
      txtResults.ReadOnly = true;
      txtResults.ScrollBars = ScrollBars.Vertical;
      txtResults.Size = new Size(450, 250);
      txtResults.TabIndex = 9;
      // 
      // lblCount
      // 
      lblCount.AutoSize = true;
      lblCount.Location = new Point(371, 73);
      lblCount.Name = "lblCount";
      lblCount.Size = new Size(75, 15);
      lblCount.TabIndex = 10;
      lblCount.Text = "Количество:";
      // 
      // lblMin
      // 
      lblMin.AutoSize = true;
      lblMin.Location = new Point(371, 109);
      lblMin.Name = "lblMin";
      lblMin.Size = new Size(66, 15);
      lblMin.TabIndex = 11;
      lblMin.Text = "Минимум:";
      // 
      // lblMax
      // 
      lblMax.AutoSize = true;
      lblMax.Location = new Point(371, 145);
      lblMax.Name = "lblMax";
      lblMax.Size = new Size(70, 15);
      lblMax.TabIndex = 12;
      lblMax.Text = "Максимум:";
      // 
      // lblBogoLimit
      // 
      lblBogoLimit.AutoSize = true;
      lblBogoLimit.Location = new Point(565, 73);
      lblBogoLimit.Name = "lblBogoLimit";
      lblBogoLimit.Size = new Size(133, 15);
      lblBogoLimit.TabIndex = 13;
      lblBogoLimit.Text = "Макс. итераций BOGO:";
      // 
      // txtCount
      // 
      txtCount.Location = new Point(452, 65);
      txtCount.Name = "txtCount";
      txtCount.Size = new Size(100, 23);
      txtCount.TabIndex = 14;
      // 
      // txtMin
      // 
      txtMin.Location = new Point(452, 101);
      txtMin.Name = "txtMin";
      txtMin.Size = new Size(100, 23);
      txtMin.TabIndex = 15;
      // 
      // txtMax
      // 
      txtMax.Location = new Point(452, 137);
      txtMax.Name = "txtMax";
      txtMax.Size = new Size(100, 23);
      txtMax.TabIndex = 16;
      // 
      // txtBogoLimit
      // 
      txtBogoLimit.Location = new Point(704, 65);
      txtBogoLimit.Name = "txtBogoLimit";
      txtBogoLimit.Size = new Size(100, 23);
      txtBogoLimit.TabIndex = 17;
      // 
      // Form1
      // 
      AutoScaleDimensions = new SizeF(7F, 15F);
      AutoScaleMode = AutoScaleMode.Font;
      ClientSize = new Size(984, 661);
      Controls.Add(txtBogoLimit);
      Controls.Add(txtMax);
      Controls.Add(txtMin);
      Controls.Add(txtCount);
      Controls.Add(lblBogoLimit);
      Controls.Add(lblMax);
      Controls.Add(lblMin);
      Controls.Add(lblCount);
      Controls.Add(txtResults);
      Controls.Add(dgvData);
      Controls.Add(rbDescending);
      Controls.Add(rbAscending);
      Controls.Add(chkBogo);
      Controls.Add(chkQuick);
      Controls.Add(chkShaker);
      Controls.Add(chkInsertion);
      Controls.Add(chkBubble);
      Controls.Add(menuStrip1);
      MainMenuStrip = menuStrip1;
      Name = "Form1";
      Text = "Сортировки";
      menuStrip1.ResumeLayout(false);
      menuStrip1.PerformLayout();
      ((System.ComponentModel.ISupportInitialize)dgvData).EndInit();
      ResumeLayout(false);
      PerformLayout();
    }

    #endregion

    private MenuStrip menuStrip1;
    private ToolStripMenuItem файлToolStripMenuItem;
    private ToolStripMenuItem загрузитьИзExcelToolStripMenuItem;
    private ToolStripMenuItem действияToolStripMenuItem;
    private ToolStripMenuItem рассчитатьToolStripMenuItem;
    private ToolStripMenuItem справкаToolStripMenuItem;
    private ToolStripMenuItem оПрограммеToolStripMenuItem;
    private ToolStripMenuItem загрузитьИзGoogleToolStripMenuItem;
    private ToolStripMenuItem выходToolStripMenuItem;
    private ToolStripMenuItem очиститьToolStripMenuItem;
    private ToolStripMenuItem сгенерироватьДанныеToolStripMenuItem;
    private CheckBox chkBubble;
    private CheckBox chkInsertion;
    private CheckBox chkShaker;
    private CheckBox chkQuick;
    private CheckBox chkBogo;
    private RadioButton rbAscending;
    private RadioButton rbDescending;
    private DataGridView dgvData;
    private TextBox txtResults;
    private DataGridViewTextBoxColumn colValue;
    private Label lblCount;
    private Label lblMin;
    private Label lblMax;
    private Label lblBogoLimit;
    private TextBox txtCount;
    private TextBox txtMin;
    private TextBox txtMax;
    private TextBox txtBogoLimit;
  }
}
