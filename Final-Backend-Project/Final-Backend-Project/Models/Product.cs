using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace Final_Backend_Project.Models
{
    [Serializable]
    class Product:IEquatable<Product>
    {
     
        public string Name { get; set; }
        public int Price { get; set; }
        public Category Category { get; set; }

        public bool Equals([AllowNull] Product other)
        {
            return (this.Name.Equals(other.Name) && this.Price.Equals(other.Price));
        }

        public override string ToString()
        {
            return $"{Name} is for {Price} dollar";
        }
    }
}
