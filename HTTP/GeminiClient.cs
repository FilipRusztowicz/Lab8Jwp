using Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace HTTP
{
    public class GeminiClient : ILLMClient
    {
        public string api;
        public string sciezkaLogu;
        public HttpClient klient;
        public GeminiClient(string api,string logSciezka)
        {
            this.api = api;
            sciezkaLogu = logSciezka;
            klient = new HttpClient();
        }

        public async Task<string> WyslijWiadomosc(string wiadomosc)
        {
            var url = $"https://generativelanguage.googleapis.com/v1beta/models/gemini-2.5-flash:generateContent?key={api}";

            
            var requestBody = new
            {
                contents = new[]
                {
                    new
                    {
                        parts = new[] { new { text = wiadomosc } }
                    }
                }
            };

            var jsonRequest = JsonSerializer.Serialize(requestBody);

            
            await ZapiszDoLoguAsync("WYSYŁANE ZAPYTANIE", jsonRequest);

            var content = new StringContent(jsonRequest, Encoding.UTF8, "application/json");
            var response = await klient.PostAsync(url, content);
            response.EnsureSuccessStatusCode();

           
            var jsonResponse = await response.Content.ReadAsStringAsync();

            
            await ZapiszDoLoguAsync("ODEBRANA ODPOWIEDŹ", jsonResponse);

           
            using var jsonDocument = JsonDocument.Parse(jsonResponse);
            var wygenerowanyTekst = jsonDocument.RootElement
                .GetProperty("candidates")[0]
                .GetProperty("content")
                .GetProperty("parts")[0]
                .GetProperty("text")
                .GetString();

            return wygenerowanyTekst;

        }

        private async Task ZapiszDoLoguAsync(string naglowek, string daneJson)
        {
            
            var wpis = $"[{DateTime.Now:yyyy-MM-dd HH:mm:ss}] --- {naglowek} ---\n{daneJson}\n\n";
            try
            {
                
                await File.AppendAllTextAsync(sciezkaLogu, wpis);
            }
            catch (Exception ex)
            {
                
                System.Diagnostics.Debug.WriteLine($"Błąd zapisu do pliku logu: {ex.Message}");
            }
        }
    }
}
