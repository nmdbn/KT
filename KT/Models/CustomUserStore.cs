using KT.Models;
using Microsoft.AspNetCore.Identity;

public class CustomUserStore : IUserStore<IdentityUser>, IUserPasswordStore<IdentityUser>
{
    private readonly Test1Context _context;

    public CustomUserStore(Test1Context context)
    {
        _context = context;
    }

    public Task<IdentityResult> CreateAsync(IdentityUser user, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task<IdentityResult> DeleteAsync(IdentityUser user, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task<IdentityUser> FindByIdAsync(string userId, CancellationToken cancellationToken)
    {
        var user = _context.SinhViens.FirstOrDefault(sv => sv.MaSv == userId);
        if (user != null)
        {
            return Task.FromResult(new IdentityUser { Id = user.MaSv, UserName = user.MaSv });
        }
        return Task.FromResult<IdentityUser>(null);
    }

    public Task<IdentityUser> FindByNameAsync(string normalizedUserName, CancellationToken cancellationToken)
    {
        var user = _context.SinhViens.FirstOrDefault(sv => sv.MaSv == normalizedUserName);
        if (user != null)
        {
            return Task.FromResult(new IdentityUser { UserName = user.MaSv });
        }
        return Task.FromResult<IdentityUser>(null);
    }

    public Task<string> GetNormalizedUserNameAsync(IdentityUser user, CancellationToken cancellationToken)
    {
        return Task.FromResult(user.UserName.ToUpper());
    }

    public Task<string> GetUserIdAsync(IdentityUser user, CancellationToken cancellationToken)
    {
        return Task.FromResult(user.Id);
    }

    public Task<string> GetUserNameAsync(IdentityUser user, CancellationToken cancellationToken)
    {
        return Task.FromResult(user.UserName);
    }

    public Task SetNormalizedUserNameAsync(IdentityUser user, string normalizedName, CancellationToken cancellationToken)
    {
        // Không cần triển khai nếu không sử dụng normalized user name
        return Task.CompletedTask;
    }

    public Task SetUserNameAsync(IdentityUser user, string userName, CancellationToken cancellationToken)
    {
        user.UserName = userName;
        return Task.CompletedTask;
    }

    public Task<IdentityResult> UpdateAsync(IdentityUser user, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task SetPasswordHashAsync(IdentityUser user, string passwordHash, CancellationToken cancellationToken)
    {
        // Không cần triển khai nếu không sử dụng mật khẩu
        return Task.CompletedTask;
    }

    public Task<string> GetPasswordHashAsync(IdentityUser user, CancellationToken cancellationToken)
    {
        // Không cần triển khai nếu không sử dụng mật khẩu
        return Task.FromResult<string>(null);
    }

    public Task<bool> HasPasswordAsync(IdentityUser user, CancellationToken cancellationToken)
    {
        return Task.FromResult(false);
    }

    public void Dispose()
    {
        _context.Dispose();
    }
}
