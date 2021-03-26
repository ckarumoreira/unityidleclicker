using System;
using System.Collections.Generic;
using System.Linq;

public static class AbbreviationUtility {

    private static readonly SortedDictionary<double, string> abbrevations = new SortedDictionary<double, string>
    {
            {1e3, "K" },
            {1e6, "M" },
            {1e9, "B" },
            {1e12, "T" },
            {1e15, "AA" },
            {1e18, "BB" },
            {1e21, "CC" },
            {1e24, "DD" },
            {1e27, "EE" },
            {1e30, "FF" },
            {1e33, "GG" },
            {1e36, "HH" },
            {1e39, "II" },
            {1e42, "JJ" },
            {1e45, "HH" },
            {1e48, "II" },
            {1e51, "JJ" },
            {1e54, "KK" },
            {1e57, "LL" },
            {1e60, "MM" },
            {1e63, "NN" },
            {1e66, "OO" },
            {1e69, "PP" },
            {1e72, "QQ" },
            {1e75, "RR" },
            {1e78, "SS" },
            {1e81, "TT" },
            {1e84, "UU" },
            {1e87, "VV" },
            {1e90, "WW" },
            {1e93, "XX" },
            {1e96, "YY" },
            {1e99, "ZZ" },
        };

    public static string AbbreviateNumber(double number) {
        for (int i = abbrevations.Count - 1; i >= 0; i--) {
            KeyValuePair<double, string> pair = abbrevations.ElementAt(i);
            if (Math.Abs(number) >= pair.Key) {
                string roundedNumber = (number / pair.Key).ToString("0.##");
                return $"{roundedNumber} {pair.Value}";
            }
        }
        return number.ToString();
    }
}