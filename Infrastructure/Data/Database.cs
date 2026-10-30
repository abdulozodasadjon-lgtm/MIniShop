using System.Data.Common;
using Microsoft.VisualBasic;
using Npgsql;

namespace Infrastructure.Data;

public static class Database
{
    private static string connectionStrinng = "Host=localhost;Port=5432;Database=MiniShop;Username=postgres;Password=1234554321"; 
    public static NpgsqlConnection Connection()=>new NpgsqlConnection(connectionStrinng);
}
