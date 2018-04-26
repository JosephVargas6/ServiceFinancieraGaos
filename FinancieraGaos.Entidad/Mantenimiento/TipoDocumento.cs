using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace FinancieraGaos.Entidad.Mantenimiento
{

    [DataContract]
    public class TipoDocumento
    {
        [DataMember]
        public int codtipodocumento { get; set; }

        [DataMember]
        public string descripcion { get; set; }

        [DataMember]
        public string estado { get; set; }
    }
}
