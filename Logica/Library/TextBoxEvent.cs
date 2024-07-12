using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.ComponentModel.DataAnnotations;//añadi por referencias

namespace Logica.Library
{
    //esta clase es la que se declara como objetos sus metodos deberian ser publicos para que se herede en todas las hijas.
    public class TextBoxEvent
    {
        //siguiente es un metodo que recibe un parametro de tipo "tecla presionada" , el keychar es igual a un abedecedario UNICODE considerar que una letra es un numero para este abc.
        public void TextKeyPress(KeyPressEventArgs e) //el key press es una clase de un USING forms de esta forma se usa la funcion que va a transformar a a la variable con esas caracteristicas KEYPRESS=tecla presionada en variable "e"
        {//if aninados que devuelven una condicion false/true
            if (char.IsLetter(e.KeyChar)) { e.Handled = false; }//si es un caracter alfabetico segun el abc unicode
            else if (e.KeyChar == Convert.ToChar(Keys.Enter)) { e.Handled = true; }//no se permite salto de linea o Enter
            else if (char.IsControl(e.KeyChar)) { e.Handled = false; }//permite borrar
            else if (char.IsSeparator(e.KeyChar)){ e.Handled = false; }//permite espacio
            else { e.Handled = true; }//caso contrario transmite el resultado a toda la clase no se cumple ninguno de los metodos
        }

        //procedimiento que recibe paramaetro de tipo keypress
        public void NumberKeyPress(KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar)) { e.Handled = false; }//solo permite ingreso de numeros
            else if (e.KeyChar == Convert.ToChar(Keys.Enter)) { e.Handled = true; }//no se permite salto de linea o Enter
            else if (char.IsLetter(e.KeyChar)) { e.Handled = true; } // no permite letras
            else if (char.IsControl(e.KeyChar)) { e.Handled = false; }//permite borrar
            else if (char.IsSeparator(e.KeyChar)) { e.Handled = true; }//permite espacio
            else { e.Handled = true; }//caso contrario transmite el resultado a toda la clase
        }

        //procedimiento para comprobar email que recibe un parametro
        public bool validarFormatoEmail(string mail)
        {
            return new EmailAddressAttribute().IsValid(mail);//el resultado es falso o verdadero
        }
    }
}
