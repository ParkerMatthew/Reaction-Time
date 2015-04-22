using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Arduino_Project
{
    public class LayoutRow
    {
        public int Index;
        public Button StartTimer;
        public MaskedTextBox Period, Begin, End;
        public CheckBox AutoCheckBox;

        public LayoutRow(int i){
            //constructor
            Index = i;
        }
        public void Set(Button st, MaskedTextBox per, MaskedTextBox beg, MaskedTextBox en, CheckBox auto = null){
            StartTimer = st;
            Period = per;
            Begin = beg;
            End = en;
            AutoCheckBox = auto;
        }
        public string GetInfoString()
        {
            string st = "Index = " + Index;
            st += "\nStartTimer = " + StartTimer.Text;
            st += "\nPeriod = " + Period.Text;
            st += "\nBegin = " + Begin.Text;
            st += "\nEnd = " + End.Text;
            st += "\nAutoCheckBox = ";
            if (AutoCheckBox != null)
                st += AutoCheckBox.Checked.ToString();
            else
                st += "null";
            return st;
        }

        
    }
}
