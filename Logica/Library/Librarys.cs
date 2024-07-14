using System;
using Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica.Library
{
    public class Librarys:Conexion
    {
        public LUploadImage uploadImage = new LUploadImage();
        public TextBoxEvent  textboxevent = new TextBoxEvent();
    }
}
//la clase es una especie de lista que permite usar las otras clases creando objetos (instanciandolos en objetos) para que esta clase sea la padre de otra que van a heredar la clase como tal herdad las otras sub clases que se declararon como objetos