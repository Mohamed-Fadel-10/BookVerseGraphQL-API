using BookVerseGraphQL.Data;
using BookVerseGraphQL.Models;
using Microsoft.EntityFrameworkCore;

namespace BookVerseGraphQL.GraphQL.Query
{
    [ExtendObjectType(OperationTypeNames.Query)]
    public class AuthorQuery
    {
        [UseFiltering]
        [UseSorting]
        public IQueryable<Author> Authors([Service] Context context)
           => context.Authors;

        [UseFiltering]
        [UseSorting]
        public async Task<Author?> AuthorById([Service] Context context, int id)
            => await context.Authors.FirstOrDefaultAsync(b => b.Id == id);
    }
}
