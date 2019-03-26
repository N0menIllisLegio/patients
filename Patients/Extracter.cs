using System.IO;
using System.Text.RegularExpressions;

namespace Patients
{
    public class Extracter
    {
        
        private static string _rows;
        
        private static void ExtractValues()
        {
            string rowPatternWithDates =
                @"(?<surname>\w+)\,(?<name>\w+)\,(?<secname>(\w+| ))\,(?<place>((\w+| |\(|\))*))\,(?<dates>(\d{2}\.\d{2}\.\d{4}))(\r|)";
            Regex valueParser = new Regex(rowPatternWithDates);
            MatchCollection matches = valueParser.Matches(_rows);
            foreach (Match match in matches)
            {
                Data.PatientsInfo.Rows.Add(new object[]
                {
                    null, match.Groups["surname"].Value, match.Groups["name"].Value,
                    match.Groups["secname"].Value, match.Groups["place"].Value, match.Groups["dates"].Value
                });
            }
        }

        public static bool Extract(string dbFile)
        {
            if (File.Exists(dbFile))
            {
                _rows = File.ReadAllText(dbFile);
                ExtractValues();
                return true;
            }

            return false;
        }
    }
}
