using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Logica.Library
{
    public class TextBoxEvent
    {

        public void TextKeyPress(KeyPressEventArgs e)
        {
            if (char.IsLetter(e.KeyChar)) { e.Handled = false; }//solo permite ingreso de texto
            else if (e.KeyChar == Convert.ToChar(Keys.Enter)) { e.Handled = true; }//no se permite salto de linea o Enter
            else if (char.IsControl(e.KeyChar)) { e.Handled = false; }//permite borrar
            else if (char.IsSeparator(e.KeyChar)){ e.Handled = false; }//no permite espacio
            else { e.Handled = true; }//caso contrario transmite el resultado a toda la clase
        }

        public void NumberKeyPress(KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar)) { e.Handled = false; }//solo permite ingreso de texto
            else if (e.KeyChar == Convert.ToChar(Keys.Enter)) { e.Handled = true; }//no se permite salto de linea o Enter
            else if (char.IsControl(e.KeyChar)) { e.Handled = false; }//permite borrar
            else if (char.IsSeparator(e.KeyChar)) { e.Handled = true; }//no permite espacio
            else { e.Handled = true; }//caso contrario transmite el resultado a toda la clase
        }
    }
}
