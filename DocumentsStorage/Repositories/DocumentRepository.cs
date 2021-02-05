using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;

using DocumentsStorage.Models;

namespace DocumentsStorage.Repositories
{
    public class DocumentRepository : IDocumentRepository
    {
        public void Create(Document document, Stream inputStream, string path)
        {
            using (var context = new UserContext())
            {
                using (var fileStream = new FileStream(path, FileMode.OpenOrCreate))
                {
                    inputStream.CopyTo(fileStream);
                    fileStream.Position = 0;
                    document.DocumentBytes = new byte[fileStream.Length];
                    fileStream.Read(document.DocumentBytes, 0, (int)fileStream.Length);
                }

                document.UserId = context.Users.FirstOrDefault(u => u.Login == document.Author).Id;
                document.FullName = path;
                object[] parameters =
                {
                    new SqlParameter("@Name", document.Name),
                    new SqlParameter("@Author", document.Author),
                    new SqlParameter("@Date", document.Date),
                    new SqlParameter("@Type", document.Type),
                    new SqlParameter("@UserId", document.UserId),
                    new SqlParameter("@DocumentBytes", document.DocumentBytes),
                    new SqlParameter("@FullName", document.FullName)
                };

                context.Database.ExecuteSqlCommand("exec dbo.Document_Insert @Name, @Author, @Date, @Type, @UserId, @DocumentBytes, @FullName", parameters);
                context.SaveChanges();
            }
        }

        public List<Document> GetDocuments(string userName)
        {
            List<Document> list;

            using (var context = new UserContext())
            {
                list = context.Documents.Where(d => d.Author == userName || d.Type == DocumentType.Внешний).ToList();
            }

            return list;
        }
    }
}