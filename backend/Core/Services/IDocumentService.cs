using Core.DTOs;

namespace Core.Services;

public interface IDocumentService
{
    Task<Stream> GenerateCurriculaArchive(GenerateCurriculaDTO data);
    
    Task<IEnumerable<(string fileName, Stream content)>> GenerateCurricula(GenerateCurriculaDTO data);
}