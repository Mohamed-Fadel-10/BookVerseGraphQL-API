using BookVerseGraphQL.Data;
using BookVerseGraphQL.GraphQL.Types;
using BookVerseGraphQL.Models;
using Microsoft.EntityFrameworkCore;

namespace BookVerseGraphQL.GraphQL.Mutation
{
    [ExtendObjectType(OperationTypeNames.Mutation)]
    public class AuthorMutation
    {

        [GraphQLDescription("Add New Author")]
        public async Task<Author> AddAuthor([Service]Context _context,AuthorType Author)
        {
            var author = new Author
            {
                Name = Author.Name
            };
            await _context.Authors.AddAsync(author);
            await _context.SaveChangesAsync();
            return author;
        }

        [GraphQLDescription("Update Author")]
        public async Task<Author?> UpdateAuthor([Service] Context _context,int id, AuthorType Author)
        {
            var existingAuthor = await _context.Authors.FindAsync(id);
            if (existingAuthor == null)
            {
                return null;
            }

            existingAuthor.Name = Author.Name;

            await _context.SaveChangesAsync();
            return existingAuthor;
        }

        [GraphQLDescription("Delete Author")]
        public async Task<bool> DeleteAuthor([Service] Context _context, int id)
        {
            var Author = await _context.Authors.FindAsync(id);
            if (Author == null)
            {
                return false;
            }

            _context.Authors.Remove(Author);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
