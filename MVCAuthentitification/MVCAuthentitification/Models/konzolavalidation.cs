using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVCAuthentitification.Models
{
    [MetadataType(typeof(KonzolaMetaData))]
    public partial class Konzola
    {
        public class KonzolaMetaData
        {
            [DisplayName("Model")]
            public string model { get; set; }
        }
    }
}