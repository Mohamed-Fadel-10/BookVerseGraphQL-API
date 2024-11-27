using BookVerseGraphQL.Data;
using BookVerseGraphQL.GraphQL.Types;
using BookVerseGraphQL.Models;
using Microsoft.EntityFrameworkCore;

namespace BookVerseGraphQL.GraphQL.Mutation
{
    [ExtendObjectType(OperationTypeNames.Mutation)]
    public class BookMutation
    {
        [GraphQLDescription("Add a new book to the collection.")]
        public async Task<Book> AddBook([Service] Context context, BookType book)
        {
            var newBook = new Book
            {
                Title = book.Title,
                AuthorId = book.AuthorId,
            };

            await context.Books.AddAsync(newBook);
            await context.SaveChangesAsync();

            return newBook;
        }

        [GraphQLDescription("Update an existing book.")]
        public async Task<Book?> UpdateBook([Service] Context context, int id, BookType book)
        {
            var existingBook = await context.Books.FindAsync(id);
            if (existingBook == null)
            {
                return null;
            }

            existingBook.Title = book.Title;
            existingBook.AuthorId = book.AuthorId;

            await context.SaveChangesAsync();
            return existingBook;
        }

        [GraphQLDescription("Delete an existing book.")]
        public async Task<bool> DeleteBook([Service] Context context, int id)
        {
            var book = await context.Books.FindAsync(id);
            if (book == null)
            {
                return false;
            }

            context.Books.Remove(book);
            await context.SaveChangesAsync();
            return true;
        }
    }

}
