using EBankAppSample.Models;

namespace EBankAppSample.Services
{
    public interface IDocumentService
    {
        public List<Document> GetAll();
        public Document GetById(int id);
        public int Add(Document document);
        public Document Update(Document document);
        public void Delete(Document document);
    }
}
