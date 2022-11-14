using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVCAuthentitification.Models
{
    [MetadataType(typeof(IgricaMetaData))]

    public partial class Igrica
    {
        public class IgricaMetaData
        { 
        [DisplayName("Naziv igrice")]
        public string naziv { get; set; }
        [DisplayName("Opis igrice")]
        public string opis { get; set; }
    }
}
}
