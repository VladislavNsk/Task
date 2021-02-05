using System.Collections.Generic;
using System.IO;

using DocumentsStorage.Models;
using DocumentsStorage.Repositories;

namespace DocumentsStorage.Services
{
    public class DocumentService : IDocumentService
    {
        private readonly IDocumentRepository _repository;

        public DocumentService(IDocumentRepository repository)
        {
            _repository = repository;
        }

        public void Create(Document document, Stream inputStream, string path)
        {
            _repository.Create(document, inputStream, path);
        }

        public List<Document> GetDocuments(string userName)
        {
            return _repository.GetDocuments(userName);
        }
    }
}