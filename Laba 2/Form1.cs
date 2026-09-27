using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Net.Http;
using System.Windows.Forms;
using ClosedXML.Excel;

namespace Laba_2
{
  public partial class Form1 : Form
  {
    private HttpClient _httpClient;

    public Form1()
    {
      InitializeComponent();
      _httpClient = new HttpClient();
    }

    // ============ EXCEL ============
    private void загрузитьИзExcelToolStripMenuItem_Click(object sender, EventArgs e)
    {
      using (OpenFileDialog dialog = new OpenFileDialog())
      {
        dialog.Filter = "Excel Files|*.xlsx;*.xls";

        if (dialog.ShowDialog() != DialogResult.OK)
        {
          return;
        }

        try
        {
          LoadFromExcel(dialog.FileName);
          txtResults.Text = $"Данные загружены из {Path.GetFileName(dialog.FileName)}";
        }
        catch (Exception ex)
        {
          MessageBox.Show($"Ошибка загрузки Excel: {ex.Message}", "Ошибка",
                          MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
      }
    }

    private void LoadFromExcel(string filePath)
    {
      dgvData.Rows.Clear();

      using (XLWorkbook workbook = new XLWorkbook(filePath))
      {
        IXLWorksheet sheet = workbook.Worksheet(1);
        IXLRangeRows rows = sheet.RangeUsed().RowsUsed();

        foreach (IXLRangeRow row in rows)
        {
          string value = row.Cell(1).GetString();

          int number;
          if (int.TryParse(value, out number))
          {
            int rowIndex = dgvData.Rows.Add();
            dgvData.Rows[rowIndex].Cells["colValue"].Value = number;
          }
        }
      }
    }

    // ============ GOOGLE ============
    private async void загрузитьИзGoogleToolStripMenuItem_Click(object sender, EventArgs e)
    {
      string url = PromptForGoogleUrl();

      if (string.IsNullOrWhiteSpace(url))
      {
        return;
      }

      try
      {
        string csvUrl = ConvertToCsvUrl(url);
        string csvContent = await _httpClient.GetStringAsync(csvUrl);

        LoadFromCsvString(csvContent);
        txtResults.Text = "Данные загружены из Google.";
      }
      catch (Exception ex)
      {
        MessageBox.Show($"Ошибка загрузки Google: {ex.Message}", "Ошибка",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
      }
    }

    private string PromptForGoogleUrl()
    {
      using (Form prompt = new Form())
      {
        prompt.Width = 500;
        prompt.Height = 150;
        prompt.Text = "Google URL";

        Label label = new Label() { Left = 10, Top = 10, Width = 460, Text = "Вставьте ссылку на таблицу:" };
        TextBox textBox = new TextBox() { Left = 10, Top = 40, Width = 460 };
        Button okButton = new Button() { Text = "OK", Left = 400, Top = 70, DialogResult = DialogResult.OK };

        prompt.Controls.Add(label);
        prompt.Controls.Add(textBox);
        prompt.Controls.Add(okButton);
        prompt.AcceptButton = okButton;

        if (prompt.ShowDialog() == DialogResult.OK)
        {
          return textBox.Text;
        }

        return "";
      }
    }

    private string ConvertToCsvUrl(string url)
    {
      int dIndex = url.IndexOf("/d/");

      if (dIndex == -1)
      {
        throw new Exception("Неверная ссылка на Google.");
      }

      string afterD = url.Substring(dIndex + 3);
      int slashIndex = afterD.IndexOf('/');
      string docId = afterD.Substring(0, slashIndex);

      string gid = "0";
      int gidIndex = url.IndexOf("gid=");

      if (gidIndex != -1)
      {
        gid = url.Substring(gidIndex + 4);
        int ampIndex = gid.IndexOf('&');

        if (ampIndex != -1)
        {
          gid = gid.Substring(0, ampIndex);
        }
      }

      return $"https://docs.google.com/spreadsheets/d/{docId}/export?format=csv&gid={gid}";
    }

    private void LoadFromCsvString(string csv)
    {
      dgvData.Rows.Clear();

      string[] lines = csv.Split('\n');

      foreach (string line in lines)
      {
        string[] cells = line.Split(',');
        if (cells.Length == 0) continue;

        int number;
        if (int.TryParse(cells[0].Trim(), out number))
        {
          int rowIndex = dgvData.Rows.Add();
          dgvData.Rows[rowIndex].Cells["colValue"].Value = number;
        }
      }
    }

    // ============ РАСЧЁТ ============
    private void рассчитатьToolStripMenuItem_Click(object sender, EventArgs e)
    {
      int[] data = ReadDataFromGrid();

      if (data.Length == 0)
      {
        MessageBox.Show("Нет данных для сортировки.", "Ошибка",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
        return;
      }

      bool ascending = rbAscending.Checked;

      List<SortResult> results = new List<SortResult>();

      if (chkBubble.Checked)
        results.Add(RunAndMeasure("Пузырьковая", () => SortAlgorithms.BubbleSort(data, ascending)));

      if (chkInsertion.Checked)
        results.Add(RunAndMeasure("Вставками", () => SortAlgorithms.InsertionSort(data, ascending)));

      if (chkShaker.Checked)
        results.Add(RunAndMeasure("Шейкерная", () => SortAlgorithms.ShakerSort(data, ascending)));

      if (chkQuick.Checked)
        results.Add(RunAndMeasure("Быстрая", () => SortAlgorithms.QuickSort(data, ascending)));

      if (chkBogo.Checked)
        results.Add(RunAndMeasure("BOGO", () => SortAlgorithms.BogoSort(data, ascending)));

      if (results.Count == 0)
      {
        MessageBox.Show("Не выбран ни один алгоритм.", "Внимание",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
        return;
      }

      ShowResults(results);
    }

    private int[] ReadDataFromGrid()
    {
      List<int> numbers = new List<int>();

      foreach (DataGridViewRow row in dgvData.Rows)
      {
        if (row.Cells["colValue"].Value == null) continue;

        int number;
        if (int.TryParse(row.Cells["colValue"].Value.ToString(), out number))
        {
          numbers.Add(number);
        }
      }

      return numbers.ToArray();
    }

    private SortResult RunAndMeasure(string name, Func<int[]> sortFunc)
    {
      Stopwatch stopwatch = new Stopwatch();
      stopwatch.Start();

      int[] sorted = sortFunc();

      stopwatch.Stop();

      return new SortResult(name, sorted, stopwatch.ElapsedMilliseconds);
    }

    private void ShowResults(List<SortResult> results)
    {
      string output = "=== Результаты сортировки ===\r\n\r\n";

      long minTime = long.MaxValue;
      string fastestAlgorithm = "";

      foreach (SortResult r in results)
      {
        output += $"{r.AlgorithmName}: {r.ElapsedMilliseconds} мс\r\n";

        if (r.ElapsedMilliseconds < minTime)
        {
          minTime = r.ElapsedMilliseconds;
          fastestAlgorithm = r.AlgorithmName;
        }
      }

      output += $"\r\nБыстрейший алгоритм: {fastestAlgorithm} ({minTime} мс)";

      if (results.Count > 0)
      {
        dgvData.Rows.Clear();

        foreach (int value in results[0].SortedArray)
        {
          int rowIndex = dgvData.Rows.Add();
          dgvData.Rows[rowIndex].Cells["colValue"].Value = value;
        }
      }

      txtResults.Text = output;
    }

    // ============ ОЧИСТКА ============
    private void очиститьToolStripMenuItem_Click(object sender, EventArgs e)
    {
      dgvData.Rows.Clear();
      txtResults.Text = "";

      chkBubble.Checked = false;
      chkInsertion.Checked = false;
      chkShaker.Checked = false;
      chkQuick.Checked = false;
      chkBogo.Checked = false;
    }

    // ============ ГЕНЕРАЦИЯ ============
    private void сгенерироватьДанныеToolStripMenuItem_Click(object sender, EventArgs e)
    {
      Random random = new Random();

      dgvData.Rows.Clear();

      int rowCount = 1000;

      for (int i = 0; i < rowCount; i++)
      {
        int value = random.Next(1, 101);

        int rowIndex = dgvData.Rows.Add();
        dgvData.Rows[rowIndex].Cells["colValue"].Value = value;
      }

      txtResults.Text = $"Сгенерировано {rowCount} чисел.";
    }

    // ============ ВЫХОД ============
    private void выходToolStripMenuItem_Click(object sender, EventArgs e)
    {
      Application.Exit();
    }

    // ============ О ПРОГРАММЕ ============
    private void оПрограммеToolStripMenuItem_Click(object sender, EventArgs e)
    {
      MessageBox.Show("Лабораторная работа: Сортировки\r\n© 2026",
                      "О программе",
                      MessageBoxButtons.OK,
                      MessageBoxIcon.Information);
    }

    // ============ ЗАЩИТА: ТОЛЬКО ЦИФРЫ ============
    private void dgvData_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
    {
      if (dgvData.CurrentCell == null) return;
      if (dgvData.CurrentCell.ColumnIndex != dgvData.Columns["colValue"].Index) return;

      TextBox textBox = e.Control as TextBox;

      if (textBox != null)
      {
        textBox.KeyPress -= TextBox_KeyPress_OnlyDigits;
        textBox.KeyPress += TextBox_KeyPress_OnlyDigits;
      }
    }

    private void TextBox_KeyPress_OnlyDigits(object sender, KeyPressEventArgs e)
    {
      if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
      {
        e.Handled = true;
      }
    }

    private void dgvData_CellContentClick(object sender, DataGridViewCellEventArgs e)
    {
    }
  }
}