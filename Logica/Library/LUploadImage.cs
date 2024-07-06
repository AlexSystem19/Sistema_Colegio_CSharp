using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Logica.Library
{
    public class LUploadImage
    {
        private OpenFileDialog fd =  new OpenFileDialog(); // instancioamos una clase de OPEN DIALOG y almacenamos en una variable de nombre "fd"

        public void CargarImagen (PictureBox pictureBox)
        {
            pictureBox.WaitOnLoad = true;
            fd.Filter = "Imagenes|*.jpg;*.gif;*.png;*.bmp";
            fd.ShowDialog();
            if(fd.FileName != string.Empty)
            {
                pictureBox.ImageLocation = fd.FileName;
            }
        }
    }
}
