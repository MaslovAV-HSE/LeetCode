using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LC
{
    internal class Solutions
    {
        public static int MajorityElement(int[] nums)
        {
            Dictionary<int, int> numCount = new Dictionary<int, int>();
            for (int i = 0; i < nums.Length; i++)
            {
                if (numCount.ContainsKey(nums[i]))
                    numCount[nums[i]] += 1;
                else
                    numCount[nums[i]] = 1;
            }
            var maxvalue = numCount.Values.Max();
            foreach (var x in numCount)
            {
                if (x.Value == maxvalue)
                    return x.Key;
            }
            return -1;
        }

        public static int MaxProfit(int[] prices)
        {
            //Dictionary<int, int> max = new Dictionary<int, int>() { { 0, prices[0] } };
            //Dictionary<int, int> min = new Dictionary<int, int>() { { 0, prices[0] } };
            int max = 0;
            int min = prices[0];

            for (int i = 1; i < prices.Length; i++)
            {
                if (prices[i] < min)
                {
                    min = prices[i];
                }

                else if ((prices[i] - min) > max)
                {
                    max = prices[i] - min;
                }
            }
            return max;
        }
        public static int RomanToInt(string s)
        {
            Dictionary<char, int> roman = new Dictionary<char, int>() {
                {'I', 1},
                {'V', 5},
                {'X', 10},
                {'L', 50},
                {'C', 100},
                {'D', 500},
                {'M', 1000}
            };
            int sum = 0;
            for (int i = 0; i < s.Length; i++)
            {
                if (i < s.Length - 1)
                {
                    if ((s[i] == 'I' && (s[i + 1] == 'X' || s[i + 1] == 'V')) 
                        || (s[i] == 'X'  && (s[i + 1] == 'L' || s[i + 1] == 'C')) 
                        || (s[i] == 'C'  && (s[i + 1] == 'D' || s[i + 1] == 'M')))
                    {
                        sum += roman[s[i + 1]] - roman[s[i]];
                        i++;
                    }
                    else
                        sum += roman[s[i]];
                }
                else
                    sum += roman[s[i]];
            }
            return sum;
        }

        public static int LengthOfLastWord(string s)
        {
            var splitedSentence = s.Split().ToList();
            return splitedSentence.Last(w => !String.IsNullOrEmpty(w)).Length;
        }

        public static string LongestCommonPrefix(string[] strs)
        {
            var min = strs.Min();
            int i;
            for (i = 0; i < min.Length; i++)
                if (!strs.All(s => s.StartsWith(min.Substring(0, i + 1))))
                    return min.Substring(0, i);
            return min.Substring(0, i);

        }

        public static int StrStr(string haystack, string needle)
        {
            if (needle == haystack)
                return 0;
            //return haystack.IndexOf(needle);
            for(int i = 0; i < haystack.Length - needle.Length + 1; i++)
                if (haystack[i..(i + needle.Length)] == needle)
                    return i;
            
            return -1;
        }
    }
}
