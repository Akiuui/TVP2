using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TvpDRugiProjekat2
{
    internal class Utils
    {
        public static bool KolonaPostoji(string kolona, DataGridView dgw)
        {
            foreach (DataGridViewColumn column in dgw.Columns)
            {
                if (column.Name == kolona)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
