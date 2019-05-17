using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Business.Utils
{
    public class RegexUtils
    {
        public static string GetSheetNameFromSelectionString(string selectionString)
        {
            string sheetName = string.Empty;

            Regex regex = new Regex(@"^('[\w\s]+'|[\w\s]+)(![A-Z]+[0-9]+)?(:[A-Z]+[0-9]+)?", RegexOptions.Compiled);
            var matches = regex.Matches(selectionString);
            sheetName = matches[0].Groups[1].Value;
            sheetName = sheetName.Replace("'", "");

            return sheetName;
        }

        public static string GetSelectionNameFromSelectionString(string selectionString)
        {
            string selectionName = string.Empty;
            if (!selectionString.Contains("!")) { return string.Empty; }
            selectionName = selectionString.Substring(selectionString.LastIndexOf("!"));

            return selectionName;
        }
    }
}
