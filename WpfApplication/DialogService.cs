using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Interfaces;

namespace WpfApplication
{
    public class DialogService : IDialogService
    {
            public void PokazOkno(string html)
            {
                HtmlOkno okno = new HtmlOkno(html);
                okno.ShowDialog();
        }
    }
}
