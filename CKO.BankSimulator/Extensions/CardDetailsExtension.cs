using CKO.BankSimulator.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CKO.BankSimulator.Extensions
{
    public static class CardDetailsExtension
    {
        public static string GetMaskedCardNumber(this string cardDetails, int beginClearCount, int endClearCount, char mask)
        {
            if(cardDetails == null)
                throw new NullReferenceException("Card Details are null");

            var cardData = cardDetails;
            if(cardData.Length < beginClearCount)
            {
                beginClearCount = cardData.Length;
            }

            var returnValue = new StringBuilder(cardData.Substring(0, beginClearCount));

            cardData = cardData.Substring(beginClearCount);

            if(cardData.Length <= endClearCount)
            {
                returnValue.Append(cardData);
            }
            else
            {
                returnValue.Append(string.Empty.PadRight(cardData.Length - endClearCount, mask));
                returnValue.Append(cardData.Substring(cardData.Length - endClearCount));
            }
            return returnValue.ToString();
        }
    }
}
