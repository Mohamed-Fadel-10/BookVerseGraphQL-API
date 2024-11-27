using BookVerseGraphQL.Data;
using BookVerseGraphQL.Models;
using BookVerseGraphQL.Repositories;
using Microsoft.EntityFrameworkCore;

namespace BookVerseGraphQL.GraphQL.Query
{
    [ExtendObjectType(OperationTypeNames.Query)]
    public class AuthorQuery
    {
        [UseFiltering]
        [UseSorting]
        public async Task<IQueryable<Author>> Authors([Service] IGenericRepository<Author> repository)
           => await  repository.GetAllAsync();

        [UseFiltering]
        [UseSorting]
        public async Task<Author?> AuthorById([Service] IGenericRepository<Author> repository, int id)
            => await repository.GetByIDAsync(id);
    }
}
