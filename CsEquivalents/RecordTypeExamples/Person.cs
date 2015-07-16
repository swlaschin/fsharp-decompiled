using System;
using System.Collections;
using Microsoft.FSharp.Core;

namespace CsEquivalents.RecordTypeExamples
{

    /// <summary>
    ///  Definition of a Person
    /// </summary>
    [Serializable]
    public sealed class Person :
        IEquatable<Person>,
        IStructuralEquatable,
        IComparable<Person>,
        IComparable,
        IStructuralComparable
    {
        /// <summary>
        /// Stores first name
        /// </summary>
        public string FirstName { get; internal set; }

        /// <summary>
        /// Stores last name
        /// </summary>
        public string LastName { get; internal set; }

        /// <summary>
        /// Stores date of birth
        /// </summary>
        public DateTime DateOfBirth { get; internal set; }

        /// <summary>
        /// Constructor 
        /// </summary>
        public Person(string firstName, string lastName, DateTime dateOfBirth)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.DateOfBirth = dateOfBirth;
        }

        /// <summary>
        ///  FullName property
        /// </summary>
        public string FullName
        {
            get
            {
                return this.FirstName + " " + this.LastName;
            }
        }

        /// <summary>
        ///  IsBirthday method
        /// </summary>
        public bool IsBirthday()
        {
            return DateTime.Today.Month == this.DateOfBirth.Month && DateTime.Today.Day == this.DateOfBirth.Day;
        }

        /// <summary>
        ///  Needed for custom equality
        /// </summary>
        public int GetHashCode(IEqualityComparer comp)
        {
            int num = 0;
            const int offset = -1640531527;
            num = offset +
                  (LanguagePrimitives.HashCompare.GenericHashWithComparerIntrinsic(comp, this.DateOfBirth) +
                   ((num << 6) + (num >> 2)));
            string lastName = this.LastName;
            num = offset + (((lastName == null) ? 0 : lastName.GetHashCode()) + ((num << 6) + (num >> 2)));
            string firstName = this.FirstName;
            return offset + (((firstName == null) ? 0 : firstName.GetHashCode()) + ((num << 6) + (num >> 2)));
        }

        /// <summary>
        ///  Needed for custom equality
        /// </summary>
        public override int GetHashCode()
        {
            return this.GetHashCode(LanguagePrimitives.GenericEqualityComparer);
        }

        /// <summary>
        ///  Implement custom equality
        /// </summary>
        public bool Equals(Person obj)
        {
            return obj != null
                   && string.Equals(this.FirstName, obj.FirstName)
                   && string.Equals(this.LastName, obj.LastName)
                   && LanguagePrimitives.HashCompare.GenericEqualityERIntrinsic(this.DateOfBirth, obj.DateOfBirth);
        }

        /// <summary>
        ///  Implement custom equality
        /// </summary>
        public override bool Equals(object obj)
        {
            var person = obj as Person;
            return person != null && this.Equals(person);
        }

        /// <summary>
        ///  Implement custom equality
        /// </summary>
        public bool Equals(object obj, IEqualityComparer comp)
        {
            // ignore the IEqualityComparer as a simplification -- the generated F# code is more complex
            return Equals(obj);
        }


        /// <summary>
        ///  Implement custom comparison
        /// </summary>
        public int CompareTo(Person obj)
        {
            if (obj == null)
            {
                return 1;
            }

            int num = string.CompareOrdinal(this.FirstName, obj.FirstName);
            if (num != 0)
            {
                return num;
            }

            int num2 = string.CompareOrdinal(this.LastName, obj.LastName);
            if (num2 != 0)
            {
                return num2;
            }

            return LanguagePrimitives.HashCompare.GenericComparisonWithComparerIntrinsic(
                    LanguagePrimitives.GenericComparer, this.DateOfBirth, obj.DateOfBirth);
        }

        /// <summary>
        ///  Implement custom comparison
        /// </summary>
        public int CompareTo(object obj)
        {
            return this.CompareTo((Person)obj);
        }

        /// <summary>
        ///  Implement custom comparison
        /// </summary>
        public int CompareTo(object obj, IComparer comp)
        {
            // ignore the IComparer as a simplification -- the generated F# code is more complex
            return this.CompareTo((Person)obj);
        }
    }

}

