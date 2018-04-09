using System;
using System.Collections.Generic;
using System.Text;

namespace CustomEnumAttribute
{
    [Type("Enumeration", "Suit", "Provides suit constants for a Card class.")]
    public enum Suit
    {
        Clubs = 0,
        Diamonds = 13,
        Hearts = 26,
        Spades = 39
    }
}
