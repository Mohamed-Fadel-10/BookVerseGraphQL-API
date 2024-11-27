using BookVerseGraphQL.Data;
using BookVerseGraphQL.Models;
using Microsoft.EntityFrameworkCore;

namespace BookVerseGraphQL.GraphQL.Query
{
    [ExtendObjectType(OperationTypeNames.Query)]
    public class BookQuery
    {
        [UseFiltering]
        [UseSorting]
        public IQueryable<Book> Books([Service] Context context)
            => context.Books;

        [UseFiltering]
        [UseSorting]
        public async Task<Book?> BookById([Service] Context context, int id)
            => await context.Books.FirstOrDefaultAsync(b => b.Id == id);
    }

}
