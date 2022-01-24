using System;

namespace AspCrud.Requests
{
    public class CryptoViewModel : IEquatable<CryptoViewModel>
    {
        public uint Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public bool IsToken { get; set; }
        public bool Equals(CryptoViewModel? other)
        {
            return Id == other.Id && Name == other.Name && Price == other.Price && IsToken == other.IsToken;
        }
    }
}
