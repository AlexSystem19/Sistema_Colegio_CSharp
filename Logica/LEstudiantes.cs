using Data;
using LinqToDB;
using Logica.Library;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Logica
{
    public class LEstudiantes : Librarys
    {
        private List<TextBox> listtextbox;
        private List<Label> listtextlabel;
        private PictureBox image;
        //private Librarys librarys;

        //metodo CONSTRUCTOR que recibe un paramaetro un objeto de tipo textbos de tipo lista de tipo estudiante
        public LEstudiantes(List<TextBox> listtextbox, List<Label> listtextlabel, object[] objetos)
        {
            this.listtextbox = listtextbox;
            this.listtextlabel = listtextlabel;
            //librarys = new Librarys();
            image = (PictureBox)objetos[0];
        }

        public void Registrar()
        {
            if (listtextbox[0].Text.Equals(""))
                {
                listtextlabel[0].Text = "El campo DNI es requerido";
                listtextlabel[0].ForeColor = Color.Red;
                listtextbox[0].Focus();
            }
            else
            {
                if (listtextbox[1].Text.Equals(""))
                {
                    listtextlabel[1].Text = "Indique su nombre";
                    listtextlabel[1].ForeColor = Color.Red;
                    listtextbox[1].Focus();
                }
                else
                {
                    if (listtextbox[2].Text.Equals(""))
                    {
                        listtextlabel[2].Text = "Indique su a";
                        listtextlabel[2].ForeColor = Color.Red;
                        listtextbox[2].Focus();
                    }
                    else
                    {
                        if (listtextbox[3].Text.Equals(""))
                        {
                            listtextlabel[3].Text = "Indique su m";
                            listtextlabel[3].ForeColor = Color.Red;
                            listtextbox[3].Focus();
                        }
                        else
                        {//validar formato de correo enviando un objeto al metodo que se esta usando
                            if(textboxevent.validarFormatoEmail(listtextbox[3].Text))
                            {
                                listtextlabel[3].Text = "mail valido";
                                listtextlabel[3].ForeColor = Color.Black;

                                var imagenarray = uploadImage.ImageToByte(image.Image);//Image con I en mayusc es una clase de sistema para decirle que es un valor te tipo IMAGEN como tal osea que lo TRANSFORME EN UNA IMAGEN COMO ES NO EN BINARIO NO EN EXA SI NO EN IMAGEN IMAGEN QUE LA TRATE COMO TAL entonces  se e pone .IMAGE asi como .TEXT o .true OSEA ES UNA EXTENSION DE image,
                                                                                                //a la image que es la local y toma esa propiedad entonces la pasamos a
                                                                                                //un imagetobyte el proceso requiere de una imagen para que sea pasado a un array que previamente pedia un metodo
                                                                                                //en esta caso la clase se crea con un byte y con un [] que rerpresenta el array
                                                                                                //entonces se le pasa un formato Imagetobyte de tipo IMAGEN = Image cual recibe el objeto del mismo nombre y se le asigna el formato byte en array
                                _Estudiante.Value(e => e.dni, listtextbox[0].Text)
                                                                    .Value(e => e.nombre, listtextbox[1].Text)
                                                                    .Value(e => e.apellido, listtextbox[2].Text)
                                                                    .Value(e => e.email, listtextbox[3].Text)
                                                                    .Value(e => e.image, imagenarray)
                                                                    .Insert();
                            }
                            else
                            {
                                listtextlabel[3].Text = "mail invalido";
                                listtextlabel[3].ForeColor = Color.Red;
                                listtextbox[3].Focus();
                            }

                        }
                    }
                }
            }

        }
    }
}
