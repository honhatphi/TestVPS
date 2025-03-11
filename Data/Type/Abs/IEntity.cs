namespace Trackify.Data.Type.Abs;

public interface IEntity
{
    int Id { get; }
    Guid ReferenceId { get; }
}