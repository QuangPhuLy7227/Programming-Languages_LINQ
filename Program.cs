using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace ProgrammingLanguages
{
  class Program
  {
    static void Main()
    {
      List<Language> languages = File.ReadAllLines("./languages.tsv")
        .Skip(1)
        .Select(line => Language.FromTsv(line))
        .ToList();

      // foreach (var lang in languages) {
      //   Console.WriteLine(lang.Prettify());
      // }

      var basicInfo = languages.Select(x => $"{x.Year}, {x.Name}, {x.ChiefDeveloper}");
      var csharpLang = languages.Where(x => x.Name == "C#");
      foreach (var lang in csharpLang) {
        Console.WriteLine(lang.Prettify());
      }
      var microsoftLangs = languages.Where(x => x.ChiefDeveloper == "Microsoft");
      var lispLangs = languages.Where(x => x.Predecessors.Contains("Lisp"));
      // PrettyPrintAll(lispLangs);
      
      var scriptLangs = languages
        .Where(x => x.Name.Contains("Script"))
        .Select(x => x.Name);
      
      foreach (var lang in scriptLangs) {
        Console.WriteLine(lang);
      }

      Console.WriteLine(languages.Count);
      var nearMillenniumLangs = languages
        .Where(x => x.Year >= 1995 && x.Year <= 2005)
        .Select(x => $"{x.Name} was invented in {x.Year}");

      Console.WriteLine(nearMillenniumLangs.Count());
      // foreach (var lang in nearMillenniumLangs) {
      //   Console.WriteLine(lang);
      // }
    }

    public static void PrettyPrintAll(IEnumerable<Language> langs) {
      foreach (Language lang in langs) {
        Console.WriteLine(lang.Prettify());
      }
    }

    public static void PrintAll(IEnumerable<Object> sequence) {
      foreach (Object o in sequence) {
        Console.WriteLine(o);
      }
    }
  }
}
