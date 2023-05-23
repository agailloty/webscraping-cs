using HtmlAgilityPack;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Linq;
using System.Text;
using System.Text.Encodings.Web;
using System.Text.Unicode;

public class Program
{
    private static void Main(string[] args)
    {
        List<IList<JobCard>> allJobs = new();

        var files = Directory.GetFiles("files");
        foreach (var file in files)
        {
            var doc = new HtmlDocument();
            doc.Load(file, Encoding.UTF8, false);

            allJobs.Add(ExtractJobInfo(doc));
        }

        var res = allJobs.SelectMany(job => job).ToList();

        File.WriteAllLines("jobs.csv", 
                res.Select(job => $"{job.Title},{job.Company},{job.Location},{job.Description}"));

        Persist("jobs.json", allJobs.SelectMany(job => job).ToList());
    }

    private static IList<JobCard> ExtractJobInfo(HtmlDocument doc)
    {
        var jobCards = doc.DocumentNode
        .SelectNodes("//div[starts-with(@class, 'job_seen_beacon')]");

        List<JobCard> jobInfos = new();

        foreach(var job in jobCards)
            jobInfos.Add(ExtractInfo(job));

        return jobInfos;
    }

    private static JobCard ExtractInfo(HtmlNode node)
    {
        string title = node.SelectSingleNode(".//span[starts-with(@id, 'jobTitle')]/text()").InnerText.Trim();
        string company = node.SelectSingleNode(".//span[@class='companyName']").InnerText.Trim();
        string location = node.SelectSingleNode(".//div[@class='companyLocation']").InnerText.Trim();
        string description = node.SelectSingleNode(".//div[@class='job-snippet']").InnerText.Trim();
        return new JobCard(title, company, location, description);
    }

    private static void Persist(string filepath, IList<JobCard> data) 
    {
        var encoder = JavaScriptEncoder.Create(UnicodeRanges.BasicLatin, UnicodeRanges.Latin1Supplement, UnicodeRanges.GeneralPunctuation);
        var options = new JsonSerializerOptions { WriteIndented = true, Encoder = encoder };
        string jsonString = JsonSerializer.Serialize(data, options);
        File.WriteAllText(filepath, jsonString);
    }
}

public record JobCard(string Title, string Company, string Location, string Description);
