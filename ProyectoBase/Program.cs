using ProyectoBase;

var queries = new LinqQueries();

//Toda la coleccion/
//ImprimirValores(queries.TodaLaColeccion());

//Mayores a 2000
//ImprimirValores(queries.LibrosPost2000());

//Mayores a 250pag y "in Action"
//ImprimirValores(queries.LibrosInAction250());

//Todos con status
//Console.WriteLine(queries.TodosStatus());

//Uno en 2005
//Console.WriteLine(queries.Uno2005());

//Pertenece a Python
//ImprimirValores(queries.PertenecePython());

//Pertenece a Java Ordenado
//ImprimirValores(queries.PerteneceJava());

//450 paginas descendente
//ImprimirValores(queries.Pags450Ordenados());

//Pertenece a Java 3 recientes
//ImprimirValores(queries.JavaRecientes());

//salteo y agarro
//ImprimirValores(queries.Salteo400());

//salteo y agarro
//ImprimirValores(queries.TresLibros());


//entre 200 y 500 paginas
//Console.WriteLine(queries.Entre200y500());

//menor fecha
//Console.WriteLine(queries.MenorFecha());

//mayor paginas
//Console.WriteLine(queries.MayorPaginas());

//libro menor cantidad de paginas
//var libroMenor = queries.MenorCantidadPaginas();
//Console.WriteLine(libroMenor.Title + " " + libroMenor.PageCount);

//libro mas reciente
//var libroMayor = queries.MayorFecha();
//Console.WriteLine(libroMayor.Title + " " + libroMayor.PublishedDate);

//suma de paginas
//Console.WriteLine(queries.SumaPaginas());

//titulos psot 2015
//Console.WriteLine(queries.LibrosPost2015());

//promedio caracteres
//Console.WriteLine(queries.PromedioCaracteres());

//post 2000 agrupados
//ImprimirGrupo(queries.Post2000Agrupados());

//diccionario libros segun letra
//var diccionarioLookup = queries.DiccionarioPorLetras();
//ImprimirDiccionario(diccionarioLookup, 'A');

//Join
ImprimirValores(queries.Post2005Y500Pags());

void ImprimirValores(IEnumerable<Book> books)
{
	Console.WriteLine("{0, -60} {1, 15} {2, 15}\n", "Titulo", "N. Paginas", "Fecha Publicacion");
    foreach (var item in books)
    {
        Console.WriteLine("{0, -60} {1, 15} {2, 15}", item.Title, item.PageCount, item.PublishedDate.ToShortDateString());
    }
}

void ImprimirGrupo(IEnumerable<IGrouping<int, Book>> ListadeLibros)
{
	foreach (var grupo in ListadeLibros)
	{
		Console.WriteLine("");
		Console.WriteLine($"Grupo: {grupo.Key}");
		Console.WriteLine("{0,-60} {1, 15} {2, 15}\n", "Titulo", "N. Paginas", "Fecha publicacion");
		foreach (var item in grupo)
		{
			Console.WriteLine("{0,-60} {1, 15} {2, 15}", item.Title, item.PageCount, item.PublishedDate.Date.ToShortDateString());
		}
	}
}

void ImprimirDiccionario(ILookup<char, Book> listBooks, char letter)
{
	char letterUpper = Char.ToUpper(letter);
	
	Console.WriteLine("{0, -60} {1, 15} {2, 15}\n", "Título", "Nro. Páginas", "Fecha de Publicación");
	foreach (var book in listBooks[letterUpper])
	{
		Console.WriteLine("{0, -60} {1, 15} {2, 15}", book.Title, book.PageCount, book.PublishedDate.ToShortDateString());
	}
	
}