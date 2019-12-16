
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace Sup.Framework.Tools.Excel
{
    public class ExcelMetaData
    {
        public ExcelMetaData()
        {
            this.BackGroundColor = Color.White;
        }
        public int Row { get; set; }
        public Color? BackGroundColor { get; set; }
        public int IndentLevel { get; set; }
        public bool WrapText { get; set; } = false;
    }
}
