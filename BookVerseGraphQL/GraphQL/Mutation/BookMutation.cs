using BookVerseGraphQL.Data;
using BookVerseGraphQL.GraphQL.Types;
using BookVerseGraphQL.Models;
using BookVerseGraphQL.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace BookVerseGraphQL.GraphQL.Mutation
{
    [ExtendObjectType(OperationTypeNames.Mutation)]
    public class BookMutation
    {
        [GraphQLDescription("Add a new book to the collection.")]
        public async Task<Book> AddBook([Service] IGenericRepository<Book> repository, BookType book)
        {
            var mutationAdd= await repository.AddAsync(new Book {
                Title=book.Title,
                AuthorId=(int)book.AuthorId
            });

            return new Book
            {
                Id=mutationAdd.Id,
                Title = mutationAdd.Title,
                AuthorId = (int)mutationAdd.AuthorId,
            };
        }

        [GraphQLDescription("Update an existing book.")]
        public async Task<Book?> UpdateBook([Service] IGenericRepository<Book> repository, int id,BookType book)
        {
            var mutationUpdate = await repository.UpdateAsync(new Book
            {
                Title = book.Title,
                AuthorId = (int)book.AuthorId
            },
              id);
            return new Book
            { 
                Id=mutationUpdate.Id,
                Title=mutationUpdate.Title,
                AuthorId= (int)mutationUpdate.AuthorId,
            };

        }

        [GraphQLDescription("Delete an existing book.")]
        public bool DeleteBook([Service] IGenericRepository<Book> repository, int id)
        {
            return  repository.Delete(id);

        }
    }

}
