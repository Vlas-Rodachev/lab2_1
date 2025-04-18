using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace lab2_1
{
    [Serializable]
    [XmlRoot("ToyCollection")]
    public class ToyCollection
    {
        [XmlArray("Toys")]
        [XmlArrayItem("Toy")]
        public List<Toy> Toys { get; set; } = new List<Toy>();
    }
}
