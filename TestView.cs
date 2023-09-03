using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Gui
{
  public partial class TestView : UserControl
  {
    private IEnumerable<string> _rowData = new string[0];
    public TestView()
    {
      InitializeComponent();
    }

    public static IEnumerable<string> GenerateRowData(int count)
    {
      for (int i = 0; i < count; i++)
        yield return $"Row {i}";
    }

    protected override void OnLoad(EventArgs e)
    {
      _rowData = GenerateRowData(30);
    }

    protected override void OnPaint(PaintEventArgs e)
    {
      Graphics g = e.Graphics;
      Rectangle rcRow = ClientRectangle;
      int rowHeight = Font.Height;
      rcRow.Height = rowHeight;

      foreach (string rowText in _rowData)
      {
        g.DrawString(rowText, Font, Brushes.Black, rcRow);
        rcRow.Y += rowHeight;
      }
    }
  }
}
