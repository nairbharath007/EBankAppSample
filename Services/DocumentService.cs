using EBankAppSample.Models;
using EBankAppSample.Repository;

namespace EBankAppSample.Services
{
    public class DocumentService : IDocumentService
    {
        private readonly IRepository<Document> _documentRepository;
        public DocumentService(IRepository<Document> documentRepository)
        {
            _documentRepository = documentRepository;
        }
        public List<Document> GetAll()
        {
            var documentsQuery = _documentRepository.GetAll();
            return documentsQuery
                .Where(document => document.Customer.IsActive)
                .ToList();
        }

        public Document GetById(int id)
        {
            var documentQuery = _documentRepository.GetAll();
            var document = documentQuery
                .Where(document => document.DocumentId == id && document.Customer.IsActive)
                .FirstOrDefault();
            if (document != null) 
            {
                _documentRepository.Detach(document);
            }
            return document;
        }

        public int Add(Document document)
        {
            return _documentRepository.Add(document);
        }

        public Document Update(Document document)
        {
            return _documentRepository.Update(document);
        }
        public void Delete(Document document)
        {
            _documentRepository.Delete(document);
        }


    }
}
