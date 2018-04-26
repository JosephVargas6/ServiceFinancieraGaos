using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace FinancieraGaos.Entidad.Mantenimiento
{
    [DataContract]
    public class Bancos
    {
        [DataMember]
        public int codbanco { get; set; }

        [DataMember]
        public string banco { get; set; }

        [DataMember]
        public int estado { get; set; }

    }
}
