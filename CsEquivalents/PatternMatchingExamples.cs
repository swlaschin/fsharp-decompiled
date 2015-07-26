using System;
using System.Collections;
using Microsoft.FSharp.Collections;
using Microsoft.FSharp.Core;

namespace CsEquivalents
{
    public static class PatternMatchingExamples
    {
        [Serializable]
        public sealed class Name :
            IEquatable<Name>,
            IStructuralEquatable,
            IComparable<Name>,
            IComparable,
            IStructuralComparable
        {
            public string First { get; internal set; }
            public string Last { get; internal set; }
            public Name(string first, string last)
            {
                First = first;
                Last = last;
            }

            public int GetHashCode(IEqualityComparer comp)
            {
                var num = 0;
                const int offset = -1640531527;
                num = offset + (((Last == null) ? 0 : Last.GetHashCode()) + ((num << 6) + (num >> 2)));
                return offset + (((First == null) ? 0 : First.GetHashCode()) + ((num << 6) + (num >> 2)));
            }

            public override int GetHashCode()
            {
                return GetHashCode(LanguagePrimitives.GenericEqualityComparer);
            }


            public bool Equals(Name obj)
            {
                return obj != null && string.Equals(First, obj.First) && string.Equals(Last, obj.Last);
            }

            public override bool Equals(object obj)
            {
                var name = obj as Name;
                return name != null && Equals(name);
            }

            public bool Equals(object obj, IEqualityComparer comp)
            {
                // ignore the IEqualityComparer as a simplification -- the generated F# code is more complex
                return Equals(obj);
            }

            public int CompareTo(Name obj)
            {
                if (obj == null)
                {
                    return 1;
                }
                var num = String.Compare(First, obj.First, StringComparison.Ordinal);
                return num != 0 ? num : String.Compare(Last, obj.Last, StringComparison.Ordinal);
            }

            public int CompareTo(object obj)
            {
                return CompareTo((Name)obj);
            }

            public int CompareTo(object obj, IComparer comp)
            {
                // ignore the IComparer as a simplification -- the generated F# code is more complex
                return CompareTo((Name)obj);
            }
        }

        public sealed class Person :
            IEquatable<Person>,
            IStructuralEquatable,
            IComparable<Person>,
            IComparable,
            IStructuralComparable
        {
            public Name Name { get; internal set; }

            public int Age { get; internal set; }

            public Person(Name name, int age)
            {
                Name = name;
                Age = age;
            }

            public int GetHashCode(IEqualityComparer comp)
            {
                int num = 0;
                const int offset = -1640531527;
                num = offset + (Age + ((num << 6) + (num >> 2)));
                return offset + (Name.GetHashCode(comp) + ((num << 6) + (num >> 2)));
            }

            public override int GetHashCode()
            {
                return GetHashCode(LanguagePrimitives.GenericEqualityComparer);
            }


            public bool Equals(Person obj)
            {
                return obj != null && Name.Equals(obj.Name) && Age == obj.Age;
            }

            public override bool Equals(object obj)
            {
                var person = obj as Person;
                return person != null && Equals(person);
            }

            public bool Equals(object obj, IEqualityComparer comp)
            {
                // ignore the IEqualityComparer as a simplification -- the generated F# code is more complex
                return Equals(obj);
            }

            public int CompareTo(Person obj)
            {
                if (obj == null)
                {
                    return 1;
                }

                var num = Name.CompareTo(obj.Name);
                if (num != 0)
                {
                    return num;
                }

                return Age.CompareTo(obj.Age);
            }

            public int CompareTo(object obj)
            {
                return CompareTo((Person)obj);
            }

            public int CompareTo(object obj, IComparer comp)
            {
                // ignore the IComparer as a simplification -- the generated F# code is more complex
                return CompareTo((Person)obj);
            }
        }


        [Serializable]
        public class Email :
            IEquatable<Email>,
            IStructuralEquatable,
            IComparable<Email>,
            IComparable,
            IStructuralComparable
        {
            public string Item { get; private set; }

            public static Email NewEmail(string item)
            {
                return new Email(item);
            }

            internal Email(string item)
            {
                Item = item;
            }

            public int GetHashCode(IEqualityComparer comp)
            {
                const int num = 0;
                const int offset = -1640531527;
                var text = Item;
                return offset + (((text == null) ? 0 : text.GetHashCode()) + ((num << 6) + (num >> 2)));
            }

            public sealed override int GetHashCode()
            {
                return GetHashCode(LanguagePrimitives.GenericEqualityComparer);
            }


            public bool Equals(Email obj)
            {
                return obj != null && string.Equals(Item, obj.Item);
            }

            public sealed override bool Equals(object obj)
            {
                var email = obj as Email;
                return email != null && Equals(email);
            }

            public bool Equals(object obj, IEqualityComparer comp)
            {
                // ignore the IEqualityComparer as a simplification -- the generated F# code is more complex
                return Equals(obj);
            }

            public int CompareTo(Email obj)
            {
                if (obj == null) return 1;
                return String.Compare(Item, obj.Item, StringComparison.Ordinal);
            }

            public int CompareTo(object obj)
            {
                return CompareTo((Email)obj);
            }

            public int CompareTo(object obj, IComparer comp)
            {
                // ignore the IComparer as a simplification -- the generated F# code is more complex
                return CompareTo((Email)obj);
            }
        }


        /// <summary>
        /// demonstrates some simple pattern matching
        /// </summary>
        public static string IntPatternMatching(int x)
        {
            switch (x)
            {
                case 1:
                    return "1";
                case 2:
                    return "2";
                case 3:
                    return "3";
                case 4:
                    return "4";
                default:
                    if (x % 2 == 0)
                    {
                        return "even";
                    }
                    return "other";
            }
        }

        /// <summary>
        /// demonstrates some nested pattern matching
        /// </summary>
        public static string NestedPatternMatching(Person person)
        {
            if (string.Equals(person.Name.First, "Jane"))
            {
                if (string.Equals(person.Name.Last, "Doe"))
                {
                    return "Jane Doe";
                }
                return "Jane something";
            }
            else
            {
                if (string.Equals(person.Name.Last, "Doe"))
                {
                    return "something Doe";
                }
                if (person.Age > 18)
                {
                    return "Adult";
                }
                return "other";
            }
        }

        /// <summary>
        /// demonstrates some in-parameter pattern matching
        /// </summary>
        public static Email LowercaseEmail(Email email)
        {
            var lower = email.Item.ToLowerInvariant();
            return Email.NewEmail(lower);
        }

        public static string ListTesting<T>(FSharpList<T> list)
        {
            // NOTE: This is a simplified version of the real generated code

            // test for empty
            var tail1 = list.TailOrNull;
            if (tail1 == null)
            {
                return ExtraTopLevelOperators.PrintFormatToString(
                    new PrintfFormat<string, Unit, string, string, Unit>("Empty list"));
            }

            // first element is valid
            var firstElem = list.HeadOrDefault;

            // test for one or more elements
            if (tail1.TailOrNull == null)
            {
                var print = ExtraTopLevelOperators.PrintFormatToString(
                    new PrintfFormat<FSharpFunc<T, string>, Unit, string, string, T>("One or more elements starting with  %A"));
                return print.Invoke(firstElem);
            }

            // second element is valid
            var secondElem = tail1.HeadOrDefault;

            // test for exactly two elements
            var tail2 = tail1.TailOrNull;
            if (tail2.TailOrNull == null)
            {
                var print2 = ExtraTopLevelOperators.PrintFormatToString(
                    new PrintfFormat<FSharpFunc<T, FSharpFunc<T, string>>, Unit, string, string, Tuple<T, T>>("Exactly two elements %A and %A"));
                return print2.Invoke(firstElem).Invoke(secondElem);
            }

            // test for two or more elements
            var print3 = ExtraTopLevelOperators.PrintFormatToString(
                new PrintfFormat<FSharpFunc<T, FSharpFunc<T, string>>, Unit, string, string, Tuple<T, T>>("Two or more elements starting with  %A and %A"));
            return print3.Invoke(firstElem).Invoke(secondElem);
        }

        public static string ListTestingCsIdiomatic<T>(FSharpList<T> list)
        {
            // NOTE: This is a more idiomatic C# version of the generated code

            // test for empty
            var tail1 = list.TailOrNull;
            if (tail1 == null)
            {
                return "Empty list";
            }

            // first element is valid
            var firstElem = list.HeadOrDefault;

            // test for one or more elements
            if (tail1.TailOrNull == null)
            {
                return string.Format("One or more elements starting with {0}", firstElem);
            }

            // second element is valid
            var secondElem = tail1.HeadOrDefault;

            // test for exactly two elements
            var tail2 = tail1.TailOrNull;
            if (tail2.TailOrNull == null)
            {
                return string.Format("Exactly two elements {0} and {1}", firstElem, secondElem);
            }

            // test for two or more elements
            return string.Format("Two or more elements starting with {0} and {1}", firstElem, secondElem);
        }

        public static string TypeTesting<T>(T obj)
        {
            // NOTE: This is a simplified version of the real generated code

            var str = obj as string;
            if (str != null)
            {
                var printString = ExtraTopLevelOperators.PrintFormatToString(
                    new PrintfFormat<FSharpFunc<string, string>, Unit, string, string, string>("Obj is string with value %s"));
                return printString.Invoke(str);
            }

            if (LanguagePrimitives.IntrinsicFunctions.TypeTestGeneric<int>(obj))
            {
                var i = (int)(obj as object);
                var printInt = ExtraTopLevelOperators.PrintFormatToString(
                    new PrintfFormat<FSharpFunc<int, string>, Unit, string, string, int>("Obj is int with value %i"));
                return printInt.Invoke(i);
            }

            var person = obj as Person;
            if (person != null)
            {
                var printPerson = ExtraTopLevelOperators.PrintFormatToString(
                    new PrintfFormat<FSharpFunc<string, FSharpFunc<string, string>>, Unit, string, string, Tuple<string, string>>("Obj is Person with name %s %s"));
                return printPerson.Invoke(person.Name.First).Invoke(person.Name.Last);
            }

            return ExtraTopLevelOperators.PrintFormatToString(
                new PrintfFormat<string, Unit, string, string, Unit>("Obj is something else"));
        }
    }
}
