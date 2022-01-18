using System;

namespace AspCrud.Models
{
    public class Crypto : IEquatable<Crypto>
    {
        public uint Id { get; set; } = 0;
        public string Name { get; set; }
        public double Price { get; set; }
        public bool IsToken { get; set; }
        public override int GetHashCode() => (int) Id;
        public bool Equals(Crypto? other)
        {
            if (other != null && this.Name == other.Name && this.Price == other.Price
                && this.IsToken == other.IsToken)
            {
                return true;
            }
            return false;
        }
        public override string ToString() => String.Join(" ", Id, Name);
    }
}
