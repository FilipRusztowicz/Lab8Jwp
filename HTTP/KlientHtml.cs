namespace HTTP
{
    public class KlientHtml
    {
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
