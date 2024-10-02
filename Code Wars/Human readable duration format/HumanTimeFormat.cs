public class HumanTimeFormat
{
    public static string formatDuration(int seconds)
    {
        if (seconds <= 0)
        {
            return "now";
        }

        //Did need a bit of googling for these top two:
        int y = seconds / 31536000;               // 1 year = 31,536,000 seconds (365 days)
        int d = (seconds % 31536000) / 86400;      // 1 day = 86,400 seconds (24 hours)
        int h = (seconds % 86400) / 3600;
        int m = (seconds % 3600) / 60;
        int s = seconds % 60;

        //Ended up needing to create a list of strings to determine the wording, as String.IsNullOrEmpty approach was becoming too
        //complex.
        List<string> wording = new List<string>();

        //Determine whether we need the s or not...
        if (y > 0) wording.Add($"{y} year{(y > 1 ? "s" : "")}");
        if (d > 0) wording.Add($"{d} day{(d > 1 ? "s" : "")}");
        if (h > 0) wording.Add($"{h} hour{(h > 1 ? "s" : "")}");
        if (m > 0) wording.Add($"{m} minute{(m > 1 ? "s" : "")}");
        if (s > 0) wording.Add($"{s} second{(s > 1 ? "s" : "")}");

        if (wording.Count == 1)
        {
            return wording[0]; 
        }
        else
        {
            //Convert the wording objects into an array and join them with the comma, minus the last one which will need 'and'
            return string.Join(", ", wording.Take(wording.Count - 1)) +
                   " and " + wording.Last();
        }
    }
}