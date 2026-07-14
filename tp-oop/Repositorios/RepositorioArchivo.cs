using System.Text;

namespace tp_oop.Repositorios;

public sealed class RepositorioArchivo<T> : IRepositorio<T>, IDisposable
{
    private readonly string _rutaArchivo;
    private readonly Func<string, T> _deserializador;
    private readonly Func<T, string> _serializador;
    private readonly Func<T, int> _selectorId;

    public RepositorioArchivo(
        string rutaArchivo,
        Func<string, T> deserializador,
        Func<T, string> serializador,
        Func<T, int> selectorId)
    {
        _rutaArchivo = rutaArchivo;
        _deserializador = deserializador;
        _serializador = serializador;
        _selectorId = selectorId;

        var directorio = Path.GetDirectoryName(_rutaArchivo);
        if (!string.IsNullOrWhiteSpace(directorio) && !Directory.Exists(directorio))
        {
            Directory.CreateDirectory(directorio);
        }

        if (!File.Exists(_rutaArchivo))
        {
            File.WriteAllText(_rutaArchivo, string.Empty, Encoding.UTF8);
        }
    }

    public void Agregar(T entidad)
    {
        var lineas = ObtenerLineas();
        lineas.Add(_serializador(entidad));
        GuardarLineas(lineas);
    }

    public IEnumerable<T> ObtenerTodos()
    {
        return ObtenerLineas()
            .Where(l => !string.IsNullOrWhiteSpace(l))
            .Select(_deserializador)
            .ToList();
    }

    public T? ObtenerPorId(int id)
    {
        return ObtenerTodos().FirstOrDefault(x => _selectorId(x) == id);
    }

    public void Actualizar(T entidad)
    {
        var elementos = ObtenerTodos().ToList();
        var indice = elementos.FindIndex(x => _selectorId(x) == _selectorId(entidad));

        if (indice >= 0)
        {
            elementos[indice] = entidad;
            GuardarLineas(elementos.Select(_serializador));
        }
    }

    public void Eliminar(int id)
    {
        var elementos = ObtenerTodos().Where(x => _selectorId(x) != id);
        GuardarLineas(elementos.Select(_serializador));
    }

    public void Dispose()
    {
        GC.SuppressFinalize(this);
    }

    private List<string> ObtenerLineas()
    {
        return File.ReadAllLines(_rutaArchivo, Encoding.UTF8).ToList();
    }

    private void GuardarLineas(IEnumerable<string> lineas)
    {
        File.WriteAllLines(_rutaArchivo, lineas, Encoding.UTF8);
    }
}
