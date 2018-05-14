using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace People
{
    public class Teacher : Person, IEquatable<Teacher>
    {
        private int _salary;

        public int Salary
        {
            get { return _salary; }
            set
            {
                if (value < 0)
                    throw new ArgumentOutOfRangeException(
                        nameof(Salary),
                        value,
                        "Salary cannot below 0"
                        );
                _salary = value;
            }
        }

        public Teacher(string name, string address, Genders gender, int salary)
            : base(name, address, gender)
        {
            _salary = salary;
        }

        public bool Equals(Teacher other)
        {
            if (other is null)
                return false;
            if (ReferenceEquals(this, other))
                return true;
            return _salary == other._salary;
        }

        public override bool Equals(object obj)
        {
            if (obj is null)
                return false;
            if (ReferenceEquals(this, obj))
                return true;
            if (obj.GetType() != GetType())
                return false;
            return Equals((Teacher)obj);
        }

        public override string ToString()
        {
            return $"Teacher: {Name} is a {Gender} with a salary of {Salary}";
        }

        bool IEquatable<Teacher>.Equals(Teacher other)
        {
            return Equals(other);
        }
    }
}
