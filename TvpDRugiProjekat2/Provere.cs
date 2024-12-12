using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TvpDRugiProjekat2
{
    internal class Provere
    {
        private static ErrorProvider errorProvider = new ErrorProvider();
        private static void ProveraUnosaTxt(object sender, EventArgs e)
        {
            TextBox txt = (TextBox)sender;
            txt.Text = txt.Text.Trim();

            if (string.IsNullOrWhiteSpace(txt.Text))
            {
                errorProvider.SetError(txt, "Textbox ne sme biti prazan ili sadrzati praznine");
                txt.BorderStyle = BorderStyle.FixedSingle;
                txt.BackColor = Color.LightSalmon;
            }
            else
            {
                errorProvider.SetError(txt, "");
                txt.BorderStyle = BorderStyle.FixedSingle;
                txt.BackColor = SystemColors.Window;
                txt.ForeColor = SystemColors.ControlText;

            }
        }
        private static void ProveraUnosaBroja(object sender, EventArgs e)
        {
            TextBox txt = (TextBox)sender;
            txt.Text = txt.Text.Trim();

            if (!int.TryParse(txt.Text, out int vrednost))
            {
                errorProvider.SetError(txt, "Unutar tekstboksa sme da se unose samo brojevi");
                txt.BorderStyle = BorderStyle.FixedSingle;
                txt.BackColor = Color.LightBlue;
                txt.ForeColor = Color.Red;
            }
            else
            {
                errorProvider.SetError(txt, "");
                txt.BorderStyle = BorderStyle.FixedSingle;
                txt.BackColor = SystemColors.Window;
                txt.ForeColor = SystemColors.ControlText;

            }

        }
        public static void DodajProveruUnosa(Control.ControlCollection controls)
        {
            foreach (Control control in controls)
            {

                if (control is TextBox && (string)control.Tag == "ignore")
                    continue;

                if (control is TextBox && control.Tag == "br")
                    control.Validated += ProveraUnosaBroja;


                if (control is TextBox && control.Tag != "br")
                    control.Validated += ProveraUnosaTxt;



            }

        }
        public static bool DaLiPostojeGreske(Control.ControlCollection controls)
        {
            foreach (Control control in controls)
            {
                if (!string.IsNullOrEmpty(errorProvider.GetError(control)))
                    return true;

            }
            return false;
        }
    }
}
