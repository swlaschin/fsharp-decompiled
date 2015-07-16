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
        internal string _FirstName;
        internal string _LastName;
        internal DateTime _DateOfBirth;

        /// <summary>
        /// Stores first name
        /// </summary>
        public string FirstName
        {
            get
            {
                return this._FirstName;
            }
        }

        /// <summary>
        /// Stores last name
        /// </summary>
        public string LastName
        {
            get
            {
                return this._LastName;
            }
        }

        /// <summary>
        /// Stores date of birth
        /// </summary>
        public DateTime DateOfBirth
        {
            get
            {
                return this._DateOfBirth;
            }
        }

        /// <summary>
        /// Constructor 
        /// </summary>
        public Person(string firstName, string lastName, DateTime dateOfBirth)
        {
            this._FirstName = firstName;
            this._LastName = lastName;
            this._DateOfBirth = dateOfBirth;
        }

        /// <summary>
        ///  FullName property
        /// </summary>
        public string FullName
        {
            get
            {
                return this._FirstName + " " + this._LastName;
            }
        }

        /// <summary>
        ///  IsBirthday method
        /// </summary>
        public bool IsBirthday()
        {
            return DateTime.Today.Month == this._DateOfBirth.Month && DateTime.Today.Day == this._DateOfBirth.Day;
        }

        /// <summary>
        ///  Needed for custom equality
        /// </summary>
        public int GetHashCode(IEqualityComparer comp)
        {
            if (this != null)
            {
                int num = 0;
                int offset = -1640531527;
                num = offset + (LanguagePrimitives.HashCompare.GenericHashWithComparerIntrinsic<DateTime>(comp, this._DateOfBirth) + ((num << 6) + (num >> 2)));
                string _lastName = this._LastName;
                num = offset + (((_lastName == null) ? 0 : _lastName.GetHashCode()) + ((num << 6) + (num >> 2)));
                string _firstName = this._FirstName;
                return offset + (((_firstName == null) ? 0 : _firstName.GetHashCode()) + ((num << 6) + (num >> 2)));
            }
            return 0;
        }

        /// <summary>
        ///  Needed for custom equality
        /// </summary>
        public sealed override int GetHashCode()
        {
            return this.GetHashCode(LanguagePrimitives.GenericEqualityComparer);
        }

        /// <summary>
        ///  Implement custom equality
        /// </summary>
        public bool Equals(Person obj)
        {
            if (this != null)
            {
                return obj != null
                    && string.Equals(this._FirstName, obj._FirstName)
                    && string.Equals(this._LastName, obj._LastName)
                    && LanguagePrimitives.HashCompare.GenericEqualityERIntrinsic<DateTime>(this._DateOfBirth, obj._DateOfBirth);
            }
            return obj == null;
        }

        /// <summary>
        ///  Implement custom equality
        /// </summary>
        public sealed override bool Equals(object obj)
        {
            Person person = obj as Person;
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
            if (this != null)
            {
                if (obj == null)
                {
                    return 1;
                }

                int num = string.CompareOrdinal(this._FirstName, obj._FirstName);
                if (num != 0)
                {
                    return num;
                }

                int num2 = string.CompareOrdinal(this._LastName, obj._LastName);
                if (num2 != 0)
                {
                    return num2;
                }
                
                return LanguagePrimitives.HashCompare.GenericComparisonWithComparerIntrinsic<DateTime>(LanguagePrimitives.GenericComparer, this._DateOfBirth, obj._DateOfBirth);
            }
            else
            {
                return obj != null ? -1 : 0;
            }
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

