using System;
using System.Collections;
using System.Windows.Forms;

namespace IEBus_Studio
{

    class RowComparer : System.Collections.IComparer
    {
        private static int sortOrderModifier = 1;

        public RowComparer(SortOrder sortOrder)
        {
            if (sortOrder == SortOrder.Descending)
            {
                sortOrderModifier = -1;
            }
            else if (sortOrder == SortOrder.Ascending)
            {
                sortOrderModifier = 1;
            }
        }

        public int Compare(object x, object y)
        {
            DataGridViewRow DataGridViewRow1 = (DataGridViewRow)x;
            DataGridViewRow DataGridViewRow2 = (DataGridViewRow)y;

            // Try to sort based on the Matches column.
            int CompareResult = System.String.Compare(
                DataGridViewRow1.Cells["matchesColumn"].Value.ToString(),
                DataGridViewRow2.Cells["matchesColumn"].Value.ToString());
            int C1 = System.Convert.ToInt32(DataGridViewRow1.Cells["matchesColumn"].Value.ToString());
            int C2 = System.Convert.ToInt32(DataGridViewRow2.Cells["matchesColumn"].Value.ToString());

            if (C1 > C2)
                CompareResult = 1;
            else if (C1 == C2)
                CompareResult = 0;
            else
                CompareResult = -1;
            // If the Matches are equal, sort based on the Pattern.
            if (CompareResult == 0)
            {
                CompareResult = System.String.Compare(
                    DataGridViewRow1.Cells["matchesColumn"].Value.ToString(),
                    DataGridViewRow2.Cells["matchesColumn"].Value.ToString());
            }
            return CompareResult * sortOrderModifier;
        }
    }
}
