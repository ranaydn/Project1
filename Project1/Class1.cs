using System.Data.SqlClient;

namespace Project1
{
    class Class1
    {
        public static void InitializeDatabase()
        {
            using (SqlConnection conn = new SqlConnection("Server=RANASCOM\\SQLEXPRESS;Database=EmployeeDB;Integrated Security=True;"))
            {
                string query = @"IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='Users' AND xtype='U')
                BEGIN
                    CREATE TABLE Users (
                        UserID INT PRIMARY KEY IDENTITY(1,1),
                        Username VARCHAR(100) UNIQUE,
                        Password VARBINARY(255),
                        Role VARCHAR(50) DEFAULT 'User'
                    );
                END

                IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='Employees' AND xtype='U')
                BEGIN
                    CREATE TABLE Employees (
                        EmployeeID INT PRIMARY KEY IDENTITY(1,1),
                        Name VARCHAR(255) NOT NULL,
                        Position VARCHAR(255) NOT NULL,
                        Salary FLOAT NOT NULL
                    );
                END";

                SqlCommand cmd = new SqlCommand(query, conn);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }
    }
}


    
