using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace People
{
    public class Student : Person, IEquatable<Student>
    {
        private int _semester;
        public int Semester
        {
            get { return _semester; }
            set
            {
                if (value < 1 || value > 8)
                    throw new ArgumentOutOfRangeException(nameof(Semester));
                _semester = value;
            }
        }

        public Student()
        {

        }

        public Student(string name, string address, int semester, Genders gender)
            : base(name, address, gender)
        {
            _semester = semester;
        }

        public bool Equals(Student other)
        {
            if (other is null)
                return false;
            if (ReferenceEquals(this, other))
                return true;
            return base.Equals(other) && _semester == other._semester;
        }

        public override bool Equals(object obj)
        {
            if (obj is null)
                return false;
            if (ReferenceEquals(this, obj))
                return true;
            if (obj.GetType() != GetType()) return false;
            return Equals((Student)obj);
        }

        public override string ToString()
        {
            return $"Student: {Name} is a {Gender} in the {Semester} semester.";
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return (base.GetHashCode() * 397) ^ _semester;
            }
        }

        public static bool operator ==(Student left, Student right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(Student left, Student right)
        {
            return !Equals(left, right);
        }
    }
}
