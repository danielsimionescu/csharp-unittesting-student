using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace People
{
    public abstract class Person : IEquatable<Person>
    {
        private string _name;
        private string _address;

        public string Name
        {
            get { return _name; }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentOutOfRangeException(nameof(Name), value, "Name cannot be empty");
                }
                if (value.Length < 2)
                {
                    throw new ArgumentOutOfRangeException(nameof(Name), value, "Name is too short");
                }
                _name = value;
            }
        }

        public string Address
        {
            get { return _address; }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentOutOfRangeException(nameof(Address), value, "Address cannot be empty");
                }
                _address = value;
            }
        }

        public Genders Gender { get; set; }

        protected Person()
        {

        }

        protected Person(string name, string address, Genders gender)
        {
            _name = name;
            _address = address;
            Gender = gender;
        }

        public bool Equals(Person other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return string.Equals(_name, other._name) && string.Equals(_address, other._address) && Gender == other.Gender;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Person)obj);
        }

        public override int GetHashCode()
        {
            var hashCode = 723445745;
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Name);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Address);
            hashCode = hashCode * -1521134295 + Gender.GetHashCode();
            return hashCode;
        }

        public static bool operator ==(Person person1, Person person2)
        {
            return EqualityComparer<Person>.Default.Equals(person1, person2);
        }

        public static bool operator !=(Person person1, Person person2)
        {
            return !(person1 == person2);
        }
    }

    public enum Genders
    {
        Male = 1,
        Female = 2
    }
}
