using Classlibrary_for_database;

namespace Bai9;

internal static class CuaHangDatabase
{
    private static readonly string ConnectionString =
        "Server=localhost,1433;Database=QLCuaHang;User Id=sa;Password=SqlServer@2026;TrustServerCertificate=True;";

    internal static readonly DatabaseHelper Helper = new(ConnectionString);
}
