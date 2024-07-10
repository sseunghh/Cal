using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Calculator_Pro
{
    public class History
    {
        private List<string> historyList = new List<string>();
        public void AddHistory(string history)
        {
            if (historyList.Count >= 5)
            {
                historyList.RemoveAt(0);
            }
            historyList.Add(history);
        }
        public string AllHistory()
        {
            return string.Join("\n", historyList);
        }
    }
}