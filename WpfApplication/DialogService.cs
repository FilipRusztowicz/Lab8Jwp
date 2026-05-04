using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Interfaces;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace WpfApplication
{
    public class DialogService : IDialogService
    {
        public void PokazAi(object model)
        {
            AIWindow aiokno = new AIWindow();
            aiokno.DataContext = model;
            aiokno.Show();
        }

        public void PokazOkno(string html)
            {
                HtmlOkno okno = new HtmlOkno(html);
                okno.ShowDialog();
        }
    }
}
