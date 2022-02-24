namespace DUR.Api.Repo.Kool.Interfaces
{
    public interface IKoolUnitOfWorkFactory
    {
        IKoolUnitOfWork Create();
        IKoolUnitOfWork New();
    }
}
