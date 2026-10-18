using System.Data;
using Microsoft.Data.SqlClient;

namespace Classlibrary_for_database;

// Lop DatabaseHelper duoc niem phong (sealed) de ngan chan ke thua, 
// dong vai tro la giao thuc giao tiep giua ung dung va SQL Server
public sealed class DatabaseHelper
{
    // Luu tru chuoi ket noi co so du lieu (Connection String)
    private readonly string _connectionString;

    // Khoi tao doi tuong voi dau vao la chuoi ket noi, kiem tra dieu kien bang khong duoc de rong
    public DatabaseHelper(string connectionString)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(connectionString);
        _connectionString = connectionString;
    }

    // Tao va tra ve mot doi tuong SqlConnection moi dua tren chuoi ket noi da cau hinh
    public SqlConnection CreateConnection()
    {
        return new SqlConnection(_connectionString);
    }




    // Kiem tra ket noi den co so du lieu bat dong bo va in trang thai, thong tin phien ban ra console
    public async Task<bool> TestConnectionAsync()
    {
        try
        {
            Console.WriteLine("Dang tien hanh kiem tra ket noi toi SQL Server...");

            // Khoi tao ket noi va mo bat dong bo
            await using SqlConnection connection = CreateConnection();
            await connection.OpenAsync();

            // Thuc thi cau lenh SQL nhe de lay thong tin phien ban, xac thuc ket noi hoat động thuc te
            var command = new SqlCommand("SELECT @@VERSION", connection);
            var sqlVersion = await command.ExecuteScalarAsync();

            Console.WriteLine("Ket noi co so du lieu thanh cong!");
            if (sqlVersion != null)
            {
                Console.WriteLine($"Thong tin phien ban SQL Server: {sqlVersion}");
            }

            return true;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Ket noi co so du lieu that bai! Chi tiet loi: {ex.Message}");
            return false;
        }
    }







    // Thuc thi truy van SELECT bat dong bo, truyen vao cau lenh SQL va danh sach tham so (dictionary)
    // Tra ve ket qua duoi dang bang du lieu DataTable
    public async Task<DataTable> GetDataTableAsync(string query, Dictionary<string, object?>? parameters = null)
    {
        // Khoi tao ket noi va dam bao tu dong giai phong tai nguyen bang await using
        await using SqlConnection connection = CreateConnection();

        // Mo ket noi toi co so du lieu bat dong bo
        await connection.OpenAsync();

        // Tao doi tuong SqlCommand tu cau lenh SQL va tham so truyen vao
        await using SqlCommand command = CreateCommand(connection, query, parameters);

        // Thuc thi truy van va lay luong doc du lieu SqlDataReader
        await using SqlDataReader reader = await command.ExecuteReaderAsync();

        var result = new DataTable();

        // Duyet qua cac cot trong ket va dinh nghia cau truc cot cho DataTable
        for (int i = 0; i < reader.FieldCount; i++)
        {
            result.Columns.Add(reader.GetName(i), reader.GetFieldType(i));
        }

        // Duyet bat dong bo tung dong du lieu doc duoc tu luong va them vao DataTable
        while (await reader.ReadAsync())
        {
            var values = new object[reader.FieldCount];
            reader.GetValues(values);
            result.Rows.Add(values);
        }

        // Tra ve ket qua la bang du lieu DataTable da duoc do day du lieu
        return result;
    }




    // Thuc thi cac cau lenh SQL ghi/sua du lieu (INSERT, UPDATE, DELETE) bat dong bo
    // Tra ve so luong dòng du lieu bi anh huong (int)
    public async Task<int> ExecuteNonQueryAsync(string query, Dictionary<string, object?>? parameters = null)
    {
        await using SqlConnection connection = CreateConnection();
        await connection.OpenAsync();

        // Khoi tao va thuc thi cau lenh khong tra ve tap ket qua
        await using SqlCommand command = CreateCommand(connection, query, parameters);
        return await command.ExecuteNonQueryAsync();
    }





    // Thuc thi truy van tra ve duy nhat 1 gia tri (nhu COUNT, SUM, MAX hoac lay 1 o) bat dong bo
    // Tra ve kieu object? (co the null)
    public async Task<object?> GetSingleValueAsync(string query, Dictionary<string, object?>? parameters = null)
    {
        await using SqlConnection connection = CreateConnection();
        await connection.OpenAsync();

        // Khoi tao va thuc thi cau lenh tra ve gia tri o dau tien cua dong dau tien
        await using SqlCommand command = CreateCommand(connection, query, parameters);
        return await command.ExecuteScalarAsync();
    }



    // Ham ho tro noi bo tao doi tuong SqlCommand va gan tham so chong loi SQL Injection
    private static SqlCommand CreateCommand(SqlConnection connection, string query, Dictionary<string, object?>? parameters)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(query);

        var command = new SqlCommand(query, connection);

        // Neu danh sach tham so truyen vao khong null, duyet qua tung cap Key-Value de add vao SqlCommand
        if (parameters is not null)
        {
            foreach ((string name, object? value) in parameters)
            {
                // Neu gia tri truyen vao la null thi chuyen thanh DBNull.Value trong SQL
                command.Parameters.AddWithValue(name, value ?? DBNull.Value);
            }
        }

        return command;
    }
}