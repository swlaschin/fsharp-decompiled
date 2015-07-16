using System;
using System.Collections;
using Microsoft.FSharp.Core;

namespace CsEquivalents.UnionTypeExamples
{

    /// <summary>
    ///  PaymentMethod is cash, check or card
    /// </summary>
    [Serializable]
    public abstract class PaymentMethod :
        IEquatable<PaymentMethod>,
        IStructuralEquatable,
        IComparable<PaymentMethod>,
        IComparable,
        IStructuralComparable
    {

        public static class Tags
        {
            public const int Cash = 0;
            public const int Check = 1;
            public const int CreditCard = 2;
        }

        /// <summary>
        ///  Private Subclass: Cash needs no extra information, so is represented by a singleton
        /// </summary>
        [Serializable]
        internal class _Cash : PaymentMethod
        {
            internal _Cash()
            {
            }
        }

        /// <summary>
        ///  Public Subclass: Check needs a CheckNumber 
        /// </summary>
        [Serializable]
        public class Check : PaymentMethod
        {
            internal readonly CheckNumber item;

            public CheckNumber Item
            {
                get
                {
                    return this.item;
                }
            }

            internal Check(CheckNumber item)
            {
                this.item = item;
            }
        }

        /// <summary>
        ///  Public Subclass: CreditCard needs a CardType and CardNumber 
        /// </summary>
        [Serializable]
        public class CreditCard : PaymentMethod
        {
            internal readonly CardType item1;
            internal readonly CardNumber item2;

            public CardType Item1
            {
                get
                {
                    return this.item1;
                }
            }

            public CardNumber Item2
            {
                get
                {
                    return this.item2;
                }
            }

            internal CreditCard(CardType item1, CardNumber item2)
            {
                this.item1 = item1;
                this.item2 = item2;
            }
        }

        /// <summary>
        ///  Implemented for all F# union types. Used in this case for equality and comparision
        /// </summary>
        public int Tag
        {
            get
            {
                return (!(this is PaymentMethod.CreditCard)) ? ((!(this is PaymentMethod.Check)) ? 0 : 1) : 2;
            }
        }

        // Cash has no extra data so can be implemented as singleton instance
        internal static readonly PaymentMethod _unique_Cash = new PaymentMethod._Cash();


        /// <summary>
        /// static public "constructor"
        /// (just gets the singleton)
        /// </summary>
        public static PaymentMethod Cash
        {
            get
            {
                return PaymentMethod._unique_Cash;
            }
        }

        public bool IsCash
        {
            get
            {
                return this is PaymentMethod._Cash;
            }
        }

        /// <summary>
        /// static public constructor 
        /// </summary>
        public static PaymentMethod NewCheck(CheckNumber item)
        {
            return new PaymentMethod.Check(item);
        }

        public bool IsCheck
        {
            get
            {
                return this is PaymentMethod.Check;
            }
        }

        /// <summary>
        /// static public constructor 
        /// </summary>
        public static PaymentMethod NewCreditCard(CardType item1, CardNumber item2)
        {
            return new PaymentMethod.CreditCard(item1, item2);
        }

        public bool IsCreditCard
        {
            get
            {
                return this is PaymentMethod.CreditCard;
            }
        }

        /// <summary>
        /// private constructor 
        /// </summary>
        internal PaymentMethod()
        {
        }

        /// <summary>
        ///  Needed for custom equality
        /// </summary>
        public int GetHashCode(IEqualityComparer comp)
        {
            if (this != null)
            {
                if (!(this is PaymentMethod._Cash))
                {
                    var offset = -1640531527;
                    if (this is PaymentMethod.Check)
                    {
                        PaymentMethod.Check check = (PaymentMethod.Check)this;
                        int num = 1;
                        return offset + (check.item.GetHashCode(comp) + ((num << 6) + (num >> 2)));
                    }
                    if (this is PaymentMethod.CreditCard)
                    {
                        PaymentMethod.CreditCard creditCard = (PaymentMethod.CreditCard)this;
                        int num = 2;
                        num = offset + (creditCard.item2.GetHashCode(comp) + ((num << 6) + (num >> 2)));
                        return offset + (creditCard.item1.GetHashCode(comp) + ((num << 6) + (num >> 2)));
                    }
                }
                PaymentMethod._Cash cash = (PaymentMethod._Cash)this;
                return 0;
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
        public bool Equals(PaymentMethod obj)
        {
            if (this == null)
            {
                return obj == null;
            }
            if (obj == null)
            {
                return false;
            }
            if (this.Tag != obj.Tag)
            {
                return false;
            }
            if (this is PaymentMethod.Check)
            {
                PaymentMethod.Check check = (PaymentMethod.Check)this;
                PaymentMethod.Check check2 = (PaymentMethod.Check)obj;
                return check.item.Equals(check2.item);
            }
            if (!(this is PaymentMethod.CreditCard))
            {
                return true;
            }
            PaymentMethod.CreditCard creditCard = (PaymentMethod.CreditCard)this;
            PaymentMethod.CreditCard creditCard2 = (PaymentMethod.CreditCard)obj;
            return creditCard.item1.Equals(creditCard2.item1) && creditCard.item2.Equals(creditCard2.item2);
        }

        /// <summary>
        ///  Implement custom equality
        /// </summary>
        public sealed override bool Equals(object obj)
        {
            PaymentMethod paymentMethod = obj as PaymentMethod;
            return paymentMethod != null && this.Equals(paymentMethod);
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
        public int CompareTo(PaymentMethod obj)
        {
            if (this != null)
            {
                if (obj == null)
                {
                    return 1;
                }
                int num = this.Tag.CompareTo(obj.Tag);
                if (num != 0)
                {
                    return num;
                }

                IComparer genericComparer = LanguagePrimitives.GenericComparer;

                // both same type now
                if (this is PaymentMethod.Check)
                {
                    PaymentMethod.Check check = (PaymentMethod.Check)this;
                    PaymentMethod.Check check2 = (PaymentMethod.Check)obj;
                    return check.item.CompareTo(check2.item, genericComparer);
                }

                if (!(this is PaymentMethod.CreditCard))
                {
                    return 0;
                }

                PaymentMethod.CreditCard creditCard = (PaymentMethod.CreditCard)this;
                PaymentMethod.CreditCard creditCard2 = (PaymentMethod.CreditCard)obj;
                num = creditCard.item1.CompareTo(creditCard2.item1, genericComparer);
                if (num != 0)
                {
                    return num;
                }
                return creditCard.item2.CompareTo(creditCard2.item2, genericComparer);
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
            return this.CompareTo((PaymentMethod)obj);
        }

        /// <summary>
        ///  Implement custom comparison
        /// </summary>
        public int CompareTo(object obj, IComparer comp)
        {
            // ignore the IComparer as a simplification -- the generated F# code is more complex
            return this.CompareTo((PaymentMethod)obj);
        }
    }
}
