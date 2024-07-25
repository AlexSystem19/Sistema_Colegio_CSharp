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
        private string _accion = "insert";
        private DataGridView _dataGridView;
        private Bitmap _imagBitmap;

        private int _reg_por_pagina = 2;
        private int _num_por_pagina = 1;

        //private Librarys librarys;

        //metodo CONSTRUCTOR que recibe un paramaetro un objeto de tipo textbos de tipo lista de tipo estudiante
        public LEstudiantes(List<TextBox> listtextbox, List<Label> listtextlabel, object[] objetos)
        {
            this.listtextbox = listtextbox;
            this.listtextlabel = listtextlabel;
            //librarys = new Librarys();
            image = (PictureBox)objetos[0];
            _imagBitmap = (Bitmap)objetos[1];
            _dataGridView = (DataGridView)objetos[2];
            Restablecer();
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
                        listtextlabel[2].Text = "Indique su apellido";
                        listtextlabel[2].ForeColor = Color.Red;
                        listtextbox[2].Focus();
                    }
                    else
                    {
                        if (listtextbox[3].Text.Equals(""))
                        {
                            listtextlabel[3].Text = "Indique su mail";
                            listtextlabel[3].ForeColor = Color.Red;
                            listtextbox[3].Focus();
                        }
                        else
                        {
                            if(textboxevent.validarFormatoEmail(listtextbox[3].Text))//validar formato de correo enviando un objeto al metodo que se esta usando
                            {
                                var user = _Estudiante.Where(u => u.email.Equals(listtextbox[3].Text)).ToList();
                                if (user.Count.Equals(0))
                                {
                                    Save();
                                }
                                else
                                {
                                    listtextlabel[3].Text = "Email ya registrado";
                                    listtextlabel[3].ForeColor = Color.Red;
                                    listtextlabel[3].Focus();
                                }


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

        private void Save()
        {
            BeginTransactionAsync();
            try
            {
                var imagenarray = uploadImage.ImageToByte(image.Image);//Image con I en mayusc es una clase de sistema para decirle que es un valor te tipo IMAGEN como tal osea que lo TRANSFORME EN UNA IMAGEN COMO ES NO EN BINARIO NO EN EXA SI NO EN IMAGEN IMAGEN QUE LA TRATE COMO TAL entonces  se e pone .IMAGE asi como .TEXT o .true OSEA ES UNA EXTENSION DE image,
                                                                       //a la image que es la local y toma esa propiedad entonces la pasamos a
                                                                       //un imagetobyte el proceso requiere de una imagen para que sea pasado a un array que previamente pedia un metodo
                                                                       //en esta caso la clase se crea con un byte y con un [] que rerpresenta el array
                                                                       //entonces se le pasa un formato Imagetobyte de tipo IMAGEN = Image cual recibe el objeto del mismo nombre y se le asigna el formato byte en array
                switch(_accion)
                {
                    case "insert":
                        _Estudiante.Value(e => e.dni, listtextbox[0].Text)
                                    .Value(e => e.nombre, listtextbox[1].Text)
                                    .Value(e => e.apellido, listtextbox[2].Text)
                                    .Value(e => e.email, listtextbox[3].Text)
                                    .Value(e => e.image, imagenarray)
                                    .Insert();
                        break;
                    case "Actualizado":
                        _Estudiante.Where(u => u.id.Equals(_idEstudiante))
                            .Set(e => e.dni, listtextbox[0].Text)
                            .Set(e => e.nombre, listtextbox[1].Text)
                            .Set(e => e.apellido, listtextbox[2].Text)
                            .Set(e => e.email, listtextbox[3].Text)
                            .Set(e => e.image, imagenarray)
                            .Update();
                        break;

                }
                CommitTransaction();
                Restablecer();
            }
            catch (Exception)
            {
                RollbackTransaction();
            }
        }

        public void searchEstudiante(string campo)
        {
            List <Estudiante> query = new List<Estudiante> ();
            int inicio = (_num_por_pagina - 1) * _reg_por_pagina;
            if (campo.Equals(""))
            {
                query = _Estudiante.ToList ();
            }
            else
            {
                query = _Estudiante.Where(c=> c.dni.StartsWith(campo) ||
                c.nombre.StartsWith(campo)).ToList ();
            }

            if (query.Count > 0) 
            {
                _dataGridView.DataSource = query.Select(c => new
                {
                    c.id,
                    c.dni,
                    c.nombre,
                    c.apellido,
                    c.email,
                    c.image,
                }).ToList();
            }
            else
            {
                _dataGridView.DataSource = query.Select(c => new
                {
                    c.id,
                    c.dni,
                    c.nombre,
                    c.apellido,
                    c.email,
                    c.image,
                }).ToList();
            }
        }


        public void basicview()
        {
            List<Estudiante> query = new List<Estudiante> ();
            query = _Estudiante.ToList();
            _dataGridView.DataSource= query;
        }
        private int _idEstudiante = 0;
        public void Eliminar()
        {
            if (_idEstudiante.Equals(0))
            {
                MessageBox.Show("Seleccionar estudiante");
            }
            else
            {
                if(MessageBox.Show("estas seguro de eliminar estudiante?","Eliminar estudiante",
                    MessageBoxButtons.YesNo)==DialogResult.Yes)
                {
                    _Estudiante.Where(c => c.id.Equals(_idEstudiante)).Delete();
                    Restablecer();
                    basicview();
                }
            }
        }

        public void Restablecer()
        {
            listtextlabel[0].Text = "DNI";
            listtextlabel[1].Text = "Nombre";
            listtextlabel[2].Text = "Apellido";
            listtextlabel[3].Text = "Email";
            listtextlabel[0].ForeColor = Color.Gray;
            listtextlabel[1].ForeColor = Color.Gray;
            listtextlabel[2].ForeColor = Color.Gray;
            listtextlabel[3].ForeColor = Color.Gray;
            listtextbox[0].Text = "";
            listtextbox[1].Text = "";
            listtextbox[2].Text = "";
            listtextbox[3].Text = "";
            
        }
                   
        
        public void GetEstudiante()
        {
            _accion = "Actualizado";
            _idEstudiante = Convert.ToInt16(_dataGridView.CurrentRow.Cells[0].Value);
            listtextbox[0].Text = Convert.ToString(_dataGridView.CurrentRow.Cells[1].Value);
            listtextbox[1].Text = Convert.ToString(_dataGridView.CurrentRow.Cells[2].Value);
            listtextbox[2].Text = Convert.ToString(_dataGridView.CurrentRow.Cells[3].Value);
            listtextbox[3].Text = Convert.ToString(_dataGridView.CurrentRow.Cells[4].Value);
            try
            {
                byte[] arrayImage = (byte[])_dataGridView.CurrentRow.Cells[5].Value;
                image.Image = uploadImage.byteArrayToImage(arrayImage);
            }
             catch(Exception)
            {
                image.Image = _imagBitmap;
            }

        }
    }
}
