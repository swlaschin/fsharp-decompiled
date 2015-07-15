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
        public bool Equals(object obj, IEqualityComparer comp)
		{
			if (this == null)
			{
				return obj == null;
			}
			PaymentMethod paymentMethod = obj as PaymentMethod;
			if (paymentMethod == null)
			{
				return false;
			}
			int num = this.Tag;
            int num2 = paymentMethod.Tag;
			if (num != num2)
			{
				return false;
			}
			if (this is PaymentMethod.Check)
			{
				PaymentMethod.Check check = (PaymentMethod.Check)this;
				PaymentMethod.Check check2 = (PaymentMethod.Check)paymentMethod;
				CheckNumber item = check.item;
				CheckNumber item2 = check2.item;
				return item.Equals(item2, comp);
			}
			if (!(this is PaymentMethod.CreditCard))
			{
				return true;
			}
			PaymentMethod.CreditCard creditCard = (PaymentMethod.CreditCard)this;
			PaymentMethod.CreditCard creditCard2 = (PaymentMethod.CreditCard)paymentMethod;
			CardType item3 = creditCard.item1;
			CardType item4 = creditCard2.item1;
			if (item3.Equals(item4, comp))
			{
				CardNumber item5 = creditCard.item2;
				CardNumber item6 = creditCard2.item2;
				return item5.Equals(item6, comp);
			}
			return false;
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
			int num = this.Tag;
			int num2 = obj.Tag;
			if (num != num2)
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
                int num = this.Tag;
                int num2 = obj.Tag;
                if (num != num2)
                {
                    return num - num2;
                }
                if (this is PaymentMethod.Check)
                {
                    PaymentMethod.Check check = (PaymentMethod.Check)this;
                    PaymentMethod.Check check2 = (PaymentMethod.Check)obj;
                    IComparer genericComparer = LanguagePrimitives.GenericComparer;
                    CheckNumber item = check.item;
                    CheckNumber item2 = check2.item;
                    return item.CompareTo(item2, genericComparer);
                }
                if (!(this is PaymentMethod.CreditCard))
                {
                    return 0;
                }
                PaymentMethod.CreditCard creditCard = (PaymentMethod.CreditCard)this;
                PaymentMethod.CreditCard creditCard2 = (PaymentMethod.CreditCard)obj;
                IComparer genericComparer2 = LanguagePrimitives.GenericComparer;
                CardType item3 = creditCard.item1;
                CardType item4 = creditCard2.item1;
                int num3 = item3.CompareTo(item4, genericComparer2);
                if (num3 < 0)
                {
                    return num3;
                }
                if (num3 > 0)
                {
                    return num3;
                }
                IComparer genericComparer3 = LanguagePrimitives.GenericComparer;
                CardNumber item5 = creditCard.item2;
                CardNumber item6 = creditCard2.item2;
                return item5.CompareTo(item6, genericComparer3);
            }
            else
            {
                if (obj != null)
                {
                    return -1;
                }
                return 0;
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
            PaymentMethod paymentMethod = (PaymentMethod)obj;
            if (this != null)
            {
                if ((PaymentMethod)obj == null)
                {
                    return 1;
                }
                int num = this.Tag;
                PaymentMethod paymentMethod2 = paymentMethod;
                int num2 = paymentMethod2.Tag;
                if (num != num2)
                {
                    return num - num2;
                }
                if (this is PaymentMethod.Check)
                {
                    PaymentMethod.Check check = (PaymentMethod.Check)this;
                    PaymentMethod.Check check2 = (PaymentMethod.Check)paymentMethod;
                    CheckNumber item = check.item;
                    CheckNumber item2 = check2.item;
                    return item.CompareTo(item2, comp);
                }
                if (!(this is PaymentMethod.CreditCard))
                {
                    return 0;
                }
                PaymentMethod.CreditCard creditCard = (PaymentMethod.CreditCard)this;
                PaymentMethod.CreditCard creditCard2 = (PaymentMethod.CreditCard)paymentMethod;
                CardType item3 = creditCard.item1;
                CardType item4 = creditCard2.item1;
                int num3 = item3.CompareTo(item4, comp);
                if (num3 < 0)
                {
                    return num3;
                }
                if (num3 > 0)
                {
                    return num3;
                }
                CardNumber item5 = creditCard.item2;
                CardNumber item6 = creditCard2.item2;
                return item5.CompareTo(item6, comp);
            }
            else
            {
                if ((PaymentMethod)obj != null)
                {
                    return -1;
                }
                return 0;
            }
        }
	}
}
