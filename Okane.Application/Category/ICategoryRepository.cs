namespace Okane.Application.Category;
// Nuestra interfaz para desplegar nuestros metodos Add All y ById
public interface ICategoryRepository 
{
    Domain.Category Add(Domain.Category category);
    IEnumerable<Domain.Category> All();
    Domain.Category? ById(int id);
}