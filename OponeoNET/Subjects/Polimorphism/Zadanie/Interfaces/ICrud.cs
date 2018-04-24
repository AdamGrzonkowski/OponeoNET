namespace OponeoNET.Subjects.Polimorphism.Zadanie.Interfaces
{
    /// <summary>
    /// Represents entities which have full Crud access.
    /// </summary>
    public interface ICrud<T> : IRead, IUpdate<T>, IDelete, ICreate
    {
    }
}
