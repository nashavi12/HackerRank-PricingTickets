using System.Collections.Generic;
using System.IO;
using System.Linq;
using System;

class Solution
{
    //Input List = 4, 5, 9, 16, 2,10, 3
    //Possible Output = (2,3,4,5) , (9,10) , (16) :: Hence Max subsequent no. 4
    
    static int maxTickets(List<int> tickets)
    {
        var maxSubsequentCounter = 0;
        var orderedList = tickets.OrderBy(x => x).ToList();

        for (int i = 0; i < orderedList.Count; i++)
        {
            var currentSubsequentCounter = 1;
            for (int j = i + 1; j < orderedList.Count - 1; j++)
            {
                if (Math.Abs(orderedList[j] - orderedList[j - 1]) <= 1)
                    currentSubsequentCounter++;
                else
                    break;
            }

            if (currentSubsequentCounter > maxSubsequentCounter)
                maxSubsequentCounter = currentSubsequentCounter;
        }
        return maxSubsequentCounter;
    }

    static void Main(string[] args)
    {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        int ticketsCount = Convert.ToInt32(Console.ReadLine().Trim());

        List<int> tickets = new List<int>();

        for (int i = 0; i < ticketsCount; i++)
        {
            int ticketsItem = Convert.ToInt32(Console.ReadLine().Trim());
            tickets.Add(ticketsItem);
        }

        int res = maxTickets(tickets);

        textWriter.WriteLine(res);

        textWriter.Flush();
        textWriter.Close();
    }
}
