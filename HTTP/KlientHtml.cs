using Interfaces;
using System.Text.RegularExpressions;

namespace HTTP
{
    public class KlientHtml : IKlientHtml
    {
        public async Task<string> PobierzDana()
        {
            string html = await PobierzStrone();
            //poprostu wyciąga tytuł strony 
            Match match = Regex.Match(html, @"<title>\s*(.+?)\s*</title>", RegexOptions.IgnoreCase);
           if(match.Success)
            {
                return match.Groups[1].Value;
            }

            return "Nie udało się znaleźć danej na stronie.";
        }

        public  async Task<string> PobierzStrone()
        {
            string url = "https://www.ekstraklasa.org/tabela/sezon"; 

            using (HttpClient client = new HttpClient())
            {
                try
                {
                    string html = await client.GetStringAsync(url);
                    Console.WriteLine(html);
                    return html;
                }
                catch (Exception ex)
                {
                    return $"Błąd: {ex.Message}";
                }
            }
        }
    }
}
