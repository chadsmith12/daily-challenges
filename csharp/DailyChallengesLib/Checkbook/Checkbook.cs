using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Linq;
using DailyChallengesLib.StringExtensions;
using System.Text;

namespace DailyChallengesLib.Checkbook
{
    public class Checkbook
    {
        private class CheckBookItem
        {
            public CheckBookItem(string checkLine)
            {
                ParseLine(checkLine);
            }

            public int CheckNumber { get; set; }
            public string Item { get; set; }
            public double Cost { get; set; }

            private void ParseLine(string checkLine)
            {
                var lineSplit = checkLine.Split(' ');
                CheckNumber = int.Parse(lineSplit[0]);
                Item = lineSplit[1];
                Cost = double.Parse(lineSplit[2]);
            }
        }

        private IEnumerable<CheckBookItem> _items;
        private double _beginningBalance;

        public Checkbook(string checkbook)
        {
            checkbook = checkbook.Trim();
            checkbook = Regex.Replace(checkbook, "[^A-Za-z0-9\\s\\.]/gmi", "");
            _items = ParseCheckBook(checkbook);
        }

        /// <summary>
        /// The average expenses of the checkbook.
        /// </summary>
        public double AverageExpenses
        {
            get
            {
                return _items.Average(x => x.Cost);
            }
        }

        /// <summary>
        /// The total expenses of the checkbook.
        /// </summary>
        public double TotalExpenses
        {
            get
            {
                return _items.Sum(x => x.Cost);
            }
        }

        /// <summary>
        /// Generates the report of the checkbook.
        /// </summary>
        /// <returns>The report generated as a string.</returns>
        public string GenerateReport()
        {
            var reportBuilder = new StringBuilder($"Original Balance: {_beginningBalance.ToString("F")}\n");

            foreach(var item in _items)
            {
                var newBalance = Math.Round(_beginningBalance - item.Cost, 2);
                reportBuilder.Append($"{item.CheckNumber} {item.Item} {newBalance}\n");
            }

            reportBuilder.Append($"Total Expenses {Math.Round(TotalExpenses, 2)}\n");
            reportBuilder.Append($"Average Expenses {Math.Round(TotalExpenses, 2)}");

            return reportBuilder.ToString();
        }

        private IEnumerable<CheckBookItem> ParseCheckBook(string checkbook)
        {
            var checkLines = checkbook.Split('\n').ToList();

            _beginningBalance = double.Parse(checkLines[0]);
            checkLines.Remove(checkLines[0]);

            return checkLines.Select(item => new CheckBookItem(item));
        }
    }
}
