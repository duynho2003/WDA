using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Lab01.DAL
{

    public class BookDAO
    {
        private SqlConnection connection;
        private SqlDataAdapter dataAdapter;
        private SqlCommand command;
        private DataSet ds;
        Models.DatabaseContext db= new Models.DatabaseContext();
        public BookDAO()
        {
            this.connection = db.SetConnect();
        }
        public DataSet findAll()
        {
            string sql = "SELECT * FROM Book";
            dataAdapter = new SqlDataAdapter(sql, connection);
            ds=new DataSet();
            dataAdapter.Fill(ds,"Book");
            return ds;
        }
        public void saveBook(Models.Book newBook)
        {
            string query = "INSERT INTO Book VALUES (@title,@author,@edition,@price,@photo)";
            command = new SqlCommand(query,connection);
            command.Parameters.AddWithValue("@title", newBook.Title);
            command.Parameters.AddWithValue("@author", newBook.Author);
            command.Parameters.AddWithValue("@edition", newBook.Edition);
            command.Parameters.AddWithValue("@price", newBook.Price);
            command.Parameters.AddWithValue("@photo", newBook.Photo);
            dataAdapter = new SqlDataAdapter(command);
            ds= new DataSet();
            dataAdapter.Fill(ds,"Book");
        }
    }

}