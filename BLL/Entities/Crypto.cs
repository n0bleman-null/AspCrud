using System;

namespace BLL.Entities
{
    public class Crypto
    {
        public uint Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public bool IsToken { get; set; }
    }
}
