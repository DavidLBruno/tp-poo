namespace tp_oop.Repositorios;

public interface IRepositorio<T>
{
    void Agregar(T entidad);
    IEnumerable<T> ObtenerTodos();
    T? ObtenerPorId(int id);
    void Actualizar(T entidad);
    void Eliminar(int id);
}
