﻿namespace BookVerseGraphQL.GraphQL.Types
{
    public class BookType
    {
        public string? Title { get; set; } = string.Empty;
        public int? AuthorId { get; set; }
    }

}
