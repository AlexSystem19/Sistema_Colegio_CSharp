﻿using Logica;
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
        private LEstudiantes estudiante = new LEstudiantes();
        public Form1()
        {
            InitializeComponent();
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
            estudiante.textboxevent.TextKeyPress(e);
        }
    }
}
