using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sort
{
    internal class Product : IComparable<Product>
    {
        private int _id;
        public int Id
        {
            get => _id;
            set
            {
                if (value <= 0)
                    throw new ArgumentException("Id cannot be <= 0");
                _id = value;
            }
        }

        private string _name;
        public string Name
        {
            get => _name;
            set => _name = value ?? throw new ArgumentNullException("Name cannot be null");
        }

        public Product(int id, string name)
        {
            Id = id;
            Name = name;
        }

        public int CompareTo(Product? other)
        {
            if (other == null)
                throw new ArgumentNullException("Cannot compare. Product is null");

            return _id.CompareTo(other._id);
        }

        public override string ToString()
        {
            return $"Id: {_id}\tName: {_name}";
        }
    }
}
