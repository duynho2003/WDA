using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Lab01
{
    public partial class BookManage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try 
            {
                getBooks();
            }
            catch (Exception)
            {
                throw;
            }
        }
        DAL.BookDAO dao = new DAL.BookDAO();
        private void getBooks()
        {
            GridView1.DataSource=dao.findAll();
            GridView1.DataBind();
        }

        protected void btnCreate_Click(object sender, EventArgs e)
        {
            try { 
                Models.Book book = new Models.Book();
                book.Title = txtTitle.Text;
                book.Author = txtAuthor.Text;
                book.Edition = int.Parse(txtEdition.Text);
                book.Price= decimal.Parse(txtPrice.Text);
                book.Photo = "Images/" + FileUpload1.FileName;
                dao.saveBook(book);
                Response.Write("<script>alert('Add book successful...')</script>");
                getBooks();
            } catch (Exception) {
                Response.Write("<script>alert('Error!!!')</script>");
            }
        }

        protected void txtTitle_TextChanged(object sender, EventArgs e)
        {

        }
    }
}