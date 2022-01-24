using System;

namespace BLL.Entities
{
    public class Crypto : IEquatable<Crypto>
    {
        public uint Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public bool IsToken { get; set; }
        public bool Equals(Crypto? other)
            => other != null && Name == other.Name && Price == other.Price && IsToken == other.IsToken;
    }
}
