using BookVerseGraphQL.Data;
using BookVerseGraphQL.Models;
using BookVerseGraphQL.Repositories;
using Microsoft.EntityFrameworkCore;

namespace BookVerseGraphQL.GraphQL.Query
{
    [ExtendObjectType(OperationTypeNames.Query)]
    public class BookQuery
    {
        [UseFiltering]
        [UseSorting]
        public async Task<IQueryable<Book>> Books([Service] IGenericRepository<Book> repository)
            => await repository.GetAllAsync();
         
        [UseFiltering]
        [UseSorting]
        public async Task<Book?> BookById([Service] IGenericRepository<Book> repository, int id)
            => await repository.GetByIDAsync(id);
    }

}
