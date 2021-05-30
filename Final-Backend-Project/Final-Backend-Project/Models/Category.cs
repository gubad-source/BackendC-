using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace Final_Backend_Project.Models
{
    [Serializable]
    class Category:IEquatable<Category>
    {
        public int Id { get; set; }
        public string Purpose { get; set; }

        public bool Equals([AllowNull] Category other)
        {
            return (this.Id.Equals(other.Id) && this.Purpose.Equals(other.Purpose));
        }
        public override string ToString()
        {
            return $"Id:{Id} Purpose:{Purpose}";
        }
    }
}
