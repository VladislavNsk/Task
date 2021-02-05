using System.Collections.Generic;
using System.IO;

using DocumentsStorage.Models;

namespace DocumentsStorage.Services
{
    interface IDocumentService
    {
        void Create(Document document, Stream inputStream,  string path);

        List<Document> GetDocuments(string userName);
    }
}
