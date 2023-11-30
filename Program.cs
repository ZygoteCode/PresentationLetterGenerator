using iText.Html2pdf;
using System;
using System.IO;

namespace PresentationLetterGenerator
{
    internal class Program
    {
        static void Main()
        {
            string valoreAzienda = "", valoreRuolo = "", valoreData = "", nomeMese = DateTime.Now.ToString("MMMM");
            nomeMese = nomeMese.Substring(0, 1).ToUpper() + nomeMese.Substring(1).ToLower();
            Console.Write("Nome dell'azienda: ");
            valoreAzienda = Console.ReadLine();
            Console.Write("Ruolo da ricoprire: ");
            valoreRuolo = Console.ReadLine();
            valoreData = DateTime.Now.Day.ToString() + " " + nomeMese + " " + DateTime.Now.Year.ToString();
            string theHTML = File.ReadAllText("letter.html").Replace("VALORE_AZIENDA", valoreAzienda).Replace("VALORE_DATA", valoreData).Replace("VALORE_RUOLO", valoreRuolo);
            HtmlConverter.ConvertToPdf(theHTML, new FileStream(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\Lettera di presentazione.pdf", FileMode.Create, FileAccess.Write));
        }
    }
}
