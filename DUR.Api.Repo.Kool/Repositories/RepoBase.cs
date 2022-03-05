using DUR.Api.Repo.Kool.Interfaces;

namespace DUR.Api.Repo.Kool.Repositories;

public class RepoBase : IRepo
{
    protected IKoolApi _api;

    public RepoBase(IKoolApi api)
    {
        _api = api;
    }
}