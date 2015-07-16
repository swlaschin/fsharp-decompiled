﻿using System;
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
        }

        /// <summary>
        ///  Public Subclass: Check needs a CheckNumber 
        /// </summary>
        [Serializable]
        public class Check : PaymentMethod
        {
            public CheckNumber Item { get; private set; }

            internal Check(CheckNumber item)
            {
                Item = item;
            }
        }

        /// <summary>
        ///  Public Subclass: CreditCard needs a CardType and CardNumber 
        /// </summary>
        [Serializable]
        public class CreditCard : PaymentMethod
        {
            public CardType Item1 { get; private set; }
            public CardNumber Item2 { get; private set; }

            internal CreditCard(CardType item1, CardNumber item2)
            {
                Item1 = item1;
                Item2 = item2;
            }
        }

        /// <summary>
        ///  Implemented for all F# union types. Used in this case for equality and comparision
        /// </summary>
        public int Tag
        {
            get
            {
                return (!(this is CreditCard)) ? ((!(this is Check)) ? 0 : 1) : 2;
            }
        }

        // Cash has no extra data so can be implemented as singleton instance
        internal static readonly PaymentMethod _unique_Cash = new _Cash();


        /// <summary>
        /// static public "constructor"
        /// (just gets the singleton)
        /// </summary>
        public static PaymentMethod Cash
        {
            get
            {
                return _unique_Cash;
            }
        }

        public bool IsCash
        {
            get
            {
                return this is _Cash;
            }
        }

        /// <summary>
        /// static public constructor 
        /// </summary>
        public static PaymentMethod NewCheck(CheckNumber item)
        {
            return new Check(item);
        }

        public bool IsCheck
        {
            get
            {
                return this is Check;
            }
        }

        /// <summary>
        /// static public constructor 
        /// </summary>
        public static PaymentMethod NewCreditCard(CardType item1, CardNumber item2)
        {
            return new CreditCard(item1, item2);
        }

        public bool IsCreditCard
        {
            get
            {
                return this is CreditCard;
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
            if (!(this is _Cash))
            {
                const int offset = -1640531527;
                if (this is Check)
                {
                    var check = (Check)this;
                    var num = 1;
                    return offset + (check.Item.GetHashCode(comp) + ((num << 6) + (num >> 2)));
                }
                if (this is CreditCard)
                {
                    var creditCard = (CreditCard)this;
                    var num = 2;
                    num = offset + (creditCard.Item2.GetHashCode(comp) + ((num << 6) + (num >> 2)));
                    return offset + (creditCard.Item1.GetHashCode(comp) + ((num << 6) + (num >> 2)));
                }
            }
            return 0;
        }

        /// <summary>
        ///  Needed for custom equality
        /// </summary>
        public sealed override int GetHashCode()
        {
            return GetHashCode(LanguagePrimitives.GenericEqualityComparer);
        }

        /// <summary>
        ///  Implement custom equality
        /// </summary>
        public bool Equals(PaymentMethod obj)
        {
            if (obj == null)
            {
                return false;
            }
            if (Tag != obj.Tag)
            {
                return false;
            }
            if (this is Check)
            {
                var check = (Check)this;
                var check2 = (Check)obj;
                return check.Item.Equals(check2.Item);
            }
            if (!(this is CreditCard))
            {
                return true;
            }
            var creditCard = (CreditCard)this;
            var creditCard2 = (CreditCard)obj;
            return creditCard.Item1.Equals(creditCard2.Item1) && creditCard.Item2.Equals(creditCard2.Item2);
        }

        /// <summary>
        ///  Implement custom equality
        /// </summary>
        public sealed override bool Equals(object obj)
        {
            var paymentMethod = obj as PaymentMethod;
            return paymentMethod != null && Equals(paymentMethod);
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
            if (obj == null)
            {
                return 1;
            }
            var num = Tag.CompareTo(obj.Tag);
            if (num != 0)
            {
                return num;
            }

            var genericComparer = LanguagePrimitives.GenericComparer;

            // both same type now
            if (this is Check)
            {
                var check = (Check) this;
                var check2 = (Check) obj;
                return check.Item.CompareTo(check2.Item, genericComparer);
            }

            if (!(this is CreditCard))
            {
                return 0;
            }

            var creditCard = (CreditCard) this;
            var creditCard2 = (CreditCard) obj;
            num = creditCard.Item1.CompareTo(creditCard2.Item1, genericComparer);
            if (num != 0)
            {
                return num;
            }
            return creditCard.Item2.CompareTo(creditCard2.Item2, genericComparer);
        }

        /// <summary>
        ///  Implement custom comparison
        /// </summary>
        public int CompareTo(object obj)
        {
            return CompareTo((PaymentMethod)obj);
        }

        /// <summary>
        ///  Implement custom comparison
        /// </summary>
        public int CompareTo(object obj, IComparer comp)
        {
            // ignore the IComparer as a simplification -- the generated F# code is more complex
            return CompareTo((PaymentMethod)obj);
        }
    }
}
