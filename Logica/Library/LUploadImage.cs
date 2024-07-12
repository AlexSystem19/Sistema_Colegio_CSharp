using System;
using System.Collections.Generic;
using System.Drawing;
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

        //creamos un array  de tipo byte que recibe un tipo de formato imagetobyte y este con una clase abstrata para trabajar lo nombramos "picture box1"
        public byte[] ImageToByte(Image pictureBox1)
        {
            var converter = new ImageConverter(); //creamos una variable de un tipo especifico para convertir una imagen
            return (byte[])converter.ConvertTo(pictureBox1, typeof(byte[])); // retorna el valor declaro array aplicando la variable convirtiendola el cual recibe el argumento que se transforma en un formato de imagen de tipo array
        }
    }
}
