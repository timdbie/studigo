using StudiGO.Core.Interfaces;

namespace StudiGO.Core.Services;

public class AuthService
{
    private readonly IMySqlRepository _mySqlRepository;

    public AuthService(IMySqlRepository mySqlRepository)
    {
        _mySqlRepository = mySqlRepository;
    }
}