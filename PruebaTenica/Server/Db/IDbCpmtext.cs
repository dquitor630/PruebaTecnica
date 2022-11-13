namespace PruebaTenica.Server.Db
{
    public interface IDbContext
    {
        string DbId { get; }
    }

    public interface IDbContextTransient : IDbContext { }
    public interface IDbContextScoped : IDbContext { }
    public interface IDbContextSingleton : IDbContext { }
}
