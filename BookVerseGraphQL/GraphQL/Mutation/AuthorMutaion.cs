using BookVerseGraphQL.Data;
using BookVerseGraphQL.GraphQL.Types;
using BookVerseGraphQL.Models;
using BookVerseGraphQL.Repositories;
using Microsoft.EntityFrameworkCore;

namespace BookVerseGraphQL.GraphQL.Mutation
{
    [ExtendObjectType(OperationTypeNames.Mutation)]
    public class AuthorMutation
    {

        [GraphQLDescription("Add New Author")]
        public async Task<Author> AddAuthor([Service] IGenericRepository<Author> repository, AuthorType Author)
        {
          var mutationAdd =await  repository.AddAsync(new Author { Name=Author.Name});
            return mutationAdd;
        }

        [GraphQLDescription("Update Author")]
        public async Task<Author?> UpdateAuthor([Service] IGenericRepository<Author> repository, int id, AuthorType Author)
        {
            var mutationUpdated = await repository.UpdateAsync(new Author { Name = Author.Name },id);
            return mutationUpdated;
        }

        [GraphQLDescription("Delete Author")]
        public bool DeleteAuthor([Service] IGenericRepository<Author> repository, int id)
        {
            return repository.Delete(id);
        }
    }
}
