using System.Text;
using tp_oop.Excepciones;

namespace tp_oop.Repositorios;

public sealed class RepositorioArchivo<T> : IRepositorio<T>, IDisposable
{
    private readonly string _rutaArchivo;
    private readonly Func<string, T> _deserializador;
    private readonly Func<T, string> _serializador;
    private readonly Func<T, int> _selectorId;
    private bool _liberado;

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
        var resultado = new List<T>();
        var lineas = ObtenerLineas();

        for (int i = 0; i < lineas.Count; i++)
        {
            var linea = lineas[i];
            if (string.IsNullOrWhiteSpace(linea))
                continue;

            try
            {
                resultado.Add(_deserializador(linea));
            }
            catch (Exception ex)
            {
                throw new ArchivoDatosCorruptoException(
                    $"Línea {i + 1} inválida en '{_rutaArchivo}': \"{linea}\".", ex);
            }
        }

        return resultado;
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

    // Devuelve el próximo Id disponible (útil para altas).
    public int ProximoId()
    {
        var elementos = ObtenerTodos().ToList();
        return elementos.Count == 0 ? 1 : elementos.Max(_selectorId) + 1;
    }

    public void Dispose()
    {
        Liberar();
        GC.SuppressFinalize(this);
    }

    // Destructor de respaldo por si no se llamó a Dispose.
    ~RepositorioArchivo()
    {
        Liberar();
    }

    private void Liberar()
    {
        if (_liberado)
            return;

        // No hay handles abiertos de forma persistente (se usa File.* que abre y
        // cierra en cada operación), pero se deja el patrón determinístico completo.
        _liberado = true;
    }

    private List<string> ObtenerLineas()
    {
        using var lector = new StreamReader(_rutaArchivo, Encoding.UTF8);
        var lineas = new List<string>();
        string? linea;
        while ((linea = lector.ReadLine()) != null)
        {
            lineas.Add(linea);
        }

        return lineas;
    }

    private void GuardarLineas(IEnumerable<string> lineas)
    {
        using var escritor = new StreamWriter(_rutaArchivo, append: false, Encoding.UTF8);
        foreach (var linea in lineas)
        {
            escritor.WriteLine(linea);
        }
    }
}
