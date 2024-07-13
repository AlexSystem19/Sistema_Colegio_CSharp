using Logica;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Platform_School_A6
{
    public partial class Form1 : Form
    {
        private LEstudiantes estudiante;//cremaos un objeto privado con las metodos y procedimientos de las otras clases que estan en una lista.
        public Form1()
        {
            InitializeComponent();

            //creamos una lista y añadimos columnas en base a objetos.
            var listtextbox = new List<TextBox>();
            listtextbox.Add(textboxDNI);
            listtextbox.Add(textboxNombre);
            listtextbox.Add(textboxApellido);
            listtextbox.Add(textboxEmail);
            var listtextlabel = new List<Label>();
            listtextlabel.Add(lbl_Dni);
            listtextlabel.Add(lbl_Nombre);
            listtextlabel.Add(lbl_Apellido);
            listtextlabel.Add(lbl_Mail);

            Object[] objetos = {pictureBoxImagen};

            estudiante = new LEstudiantes(listtextbox,listtextlabel, objetos);//la clase estudiante tiene un constructor que recibe 2 parametro con ese mismo nombre como tal e realaciona en un objeto "estudiante"

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void groupBox5_Enter(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            estudiante.uploadImage.CargarImagen(pictureBoxImagen);
        }

        private void textboxDNI_TextChanged(object sender, EventArgs e)
        {
            if(textboxDNI.Text.Equals(""))
            {
                lbl_Dni.ForeColor = Color.Red;
            }
            else
            {
                lbl_Dni.ForeColor = Color.GreenYellow;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void textboxDNI_KeyPress(object sender, KeyPressEventArgs e)
        {
            estudiante.textboxevent.NumberKeyPress(e);
        }

        private void textboxNombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            estudiante.textboxevent.TextKeyPress(e);
        }

        private void textboxApellido_KeyPress(object sender, KeyPressEventArgs e)
        {
            estudiante.textboxevent.TextKeyPress(e);
        }

        private void textboxEmail_KeyPress(object sender, KeyPressEventArgs e)
        {
           
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            estudiante.Registrar();
        }

        private void textboxNombre_TextChanged(object sender, EventArgs e)
        {
            if (textboxNombre.Text.Equals(""))
            {
                lbl_Nombre.ForeColor = Color.Red;
            }
            else
            {
                lbl_Nombre.ForeColor = Color.Black;
            }
        }

        private void textboxApellido_TextChanged(object sender, EventArgs e)
        {
            if (textboxApellido.Text.Equals(""))
            {
                lbl_Apellido.ForeColor = Color.Red;
            }
            else
            {
                lbl_Apellido.ForeColor = Color.Black;
            }
        }

        private void textboxEmail_TextChanged(object sender, EventArgs e)
        {
            if (textboxEmail.Text.Equals(""))
            {
                lbl_Mail.ForeColor = Color.Red;
            }
            else
            {
                lbl_Mail.ForeColor = Color.Black;
            }
        }
    }
}
