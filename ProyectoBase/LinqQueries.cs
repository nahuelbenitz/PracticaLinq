using System.Text.Json;
using static System.Net.Mime.MediaTypeNames;

namespace ProyectoBase
{
	public class LinqQueries
	{
		private List<Book> books = new List<Book>();
		public LinqQueries()
		{
			using (StreamReader reader = new StreamReader("books.json"))
			{
				string json = reader.ReadToEnd();
				this.books = JsonSerializer.Deserialize<List<Book>>(json, new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });


			}
		}

		public IEnumerable<Book> TodaLaColeccion()
		{
			return books;
		}

		public IEnumerable<Book> LibrosPost2000()
		{
			return books.Where(p => p.PublishedDate.Year > 2000);
		}

		public IEnumerable<Book> LibrosInAction250()
		{
			return books.Where(p => p.PageCount > 250 && p.Title.Contains("in Action"));
		}

		public bool TodosStatus()
		{
			return books.All(p => p.Status != string.Empty);
		}

		public bool Uno2005()
		{
			return books.Any(p => p.PublishedDate.Year == 2005);
		}

		public IEnumerable<Book> PertenecePython()
		{
			return books.Where(p => p.Categories.Contains("Python"));
		}

		public IEnumerable<Book> PerteneceJava()
		{
			return books.Where(p => p.Categories.Contains("Java")).OrderBy(p => p.Title);
		}

		public IEnumerable<Book> Pags450Ordenados()
		{
			return books.Where(p => p.PageCount > 450).OrderByDescending(p => p.PageCount);
		}

		public IEnumerable<Book> JavaRecientes()
		{
			return books.Where(p => p.Categories.Contains("Java")).OrderByDescending(p => p.PublishedDate).Take(3);

		}

		public IEnumerable<Book> Salteo400()
		{
			return books.Where(p => p.PageCount > 400).Skip(2).Take(2);
		}

		public IEnumerable<Book> TresLibros()
		{
			return books.Take(3).Select(p => new Book() { Title = p.Title, PageCount = p.PageCount });
		}

		public int Entre200y500()
		{
			return books.Count(p => p.PageCount > 200 && p.PageCount < 500);
		}

		public DateTime MenorFecha()
		{
			return books.Min(p => p.PublishedDate);
		}

		public int MayorPaginas()
		{
			return books.Max(p => p.PageCount);
		}

		public Book MenorCantidadPaginas()
		{
			return books.Where(p => p.PageCount > 0).MinBy(p => p.PageCount);
		}

		public Book MayorFecha()
		{
			return books.MaxBy(p => p.PublishedDate);
		}

		public int SumaPaginas()
		{
			return books.Where(p => p.PageCount >= 0 && p.PageCount <= 500).Sum(p => p.PageCount);
		}

		public string LibrosPost2015()
		{
			return books.Where(p => p.PublishedDate.Year > 2015).Aggregate("", (titulosLibros, next) =>
			{
				if (titulosLibros != string.Empty)
					titulosLibros += " - " + next.Title;
				else
					titulosLibros += next.Title;

				return titulosLibros;
			});
        }

		public double PromedioCaracteres()
		{
			return books.Average(p => p.Title.Length);
		}

		public IEnumerable<IGrouping<int, Book>> Post2000Agrupados()
		{
			return books.Where(p => p.PublishedDate.Year >= 2000).GroupBy(p => p.PublishedDate.Year);
		}

		public ILookup<char, Book> DiccionarioPorLetras()
		{
			return books.ToLookup(p => p.Title[0], p => p);
		}

		public IEnumerable<Book> Post2005Y500Pags()
		{
			var post2005 = books.Where(p => p.PublishedDate.Year >= 2005);
			var mas500 = books.Where(p => p.PageCount > 500);

			return mas500.Join(post2005, p => p.Title, x => x.Title, (p, x) => p);
		}
	}
}
