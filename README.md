## BookVerseGraphQL API Documentation

### Overview

The BookVerseGraphQL API allows you to manage a collection of books and their authors. It is built using GraphQL and HotChocolate, connected to a PostgreSQL database.

### Features

- Query all books or filter by author.
- Add, update, or delete books.
- Query all authors or filter by specific properties.
- Add, update, or delete authors.
- Flexible filtering and sorting with HotChocolate.

### Overview

The BookVerseGraphQL API allows you to manage a collection of books and their authors. It is built using GraphQL and HotChocolate, connected to a PostgreSQL database.

### Features

- Query all books or filter by author.
- Add, update, or delete books.
- Flexible filtering and sorting with HotChocolate.

---

### Query Examples

#### Fetch All Books and Authors

```graphql
query GetAllBooks {
  books {
    id
    title
    authorId
  }
}
```

**Explanation**:

- The `books` field maps to the `Books` method in the `BookQuery` class.
- The `id`, `title`, and `authorId` fields represent the properties of each `Book`.

---

#### Fetch a Book by ID

```graphql
query GetBookById {
  bookById(id: 1) {
    id
    title
    authorId
  }
}
```

**Explanation**:

- The `bookById` field maps to the `BookById` method.
- You pass the `id` argument to filter a specific book.

---

#### Fetch an Author by ID

```graphql
query GetAuthorById {
  authorById(id: 1) {
    id
    name
  }
}
```

**Explanation**:

- The `authorById` field maps to the `AuthorById` method in the `AuthorQuery` class.
- The `id` argument is used to specify which author to fetch.

```graphql
query GetBookById {
  bookById(id: 1) {
    id
    title
    authorId
  }
}
```

**Explanation**:

- The `bookById` field maps to the `BookById` method.
- You pass the `id` argument to filter a specific book.

---

#### Fetch Books with Filtering

```graphql
query GetBooksByAuthorId {
  books(where: { authorId: { eq: 1 } }) {
    id
    title
    authorId
  }
}
```

**Explanation**:

- The `where` argument uses HotChocolate's filtering capabilities.
- The filter `{ authorId: { eq: 1 } }` ensures only books with `authorId` equal to `1` are returned.

---

#### Sort Books by Title

```graphql
query GetBooksSortedByTitle {
  books(order: { title: ASC }) {
    id
    title
    authorId
  }
}
```

**Explanation**:

- The `order` argument uses HotChocolate's sorting capabilities.
- Sorting is applied to the `title` field in ascending (`ASC`) order.

---

#### Advanced Query: Combine Filtering and Sorting

```graphql
query GetFilteredAndSortedBooks {
  books(where: { authorId: { eq: 2 } }, order: { title: DESC }) {
    id
    title
    authorId
  }
}
```

**Explanation**:

- Combines filtering (`authorId: { eq: 2 }`) and sorting (`title: DESC`) to fetch books by a specific author and sort them in descending order.

---

### Mutation Examples

#### Add a New Book

```graphql
mutation AddNewBook {
  addBook(book: { title: "The Great Gatsby", authorId: 2 }) {
    id
    title
    authorId
  }
}
```

**Explanation**:

- The `addBook` mutation maps to the `AddBook` method in the `BookMutation` class.
- You pass a `book` object with `title` and `authorId` as input.
- The mutation returns the `id`, `title`, and `authorId` of the newly created book.

---

#### Update an Existing Book

```graphql
mutation UpdateExistingBook {
  updateBook(id: 1, book: { title: "Updated Title" }) {
    id
    title
    authorId
  }
}
```

**Explanation**:

- The `updateBook` mutation maps to the `UpdateBook` method in the `BookMutation` class.
- Only the `title` field is updated in this case. The `authorId` remains unchanged.
- The mutation returns the updated `Book` object.

---

#### Delete a Book

```graphql
mutation DeleteBookById {
  deleteBook(id: 1)
}
```

**Explanation**:

- The `deleteBook` mutation maps to the `DeleteBook` method in the `BookMutation` class.
- The mutation takes the `id` of the book to be deleted as input and returns a boolean value (`true` if the deletion was successful, otherwise `false`).

---

#### Add a New Author

```graphql
mutation AddNewAuthor {
  addAuthor(author: { name: "F. Scott Fitzgerald" }) {
    id
    name
  }
}
```

**Explanation**:

- The `addAuthor` mutation maps to the `AddAuthor` method in the `AuthorMutation` class.
- You pass an `author` object with the `name` as input.
- The mutation returns the `id` and `name` of the newly created author.

---

#### Update an Existing Author

```graphql
mutation UpdateExistingAuthor {
  updateAuthor(id: 1, author: { name: "Updated Name" }) {
    id
    name
  }
}
```

**Explanation**:

- The `updateAuthor` mutation maps to the `UpdateAuthor` method in the `AuthorMutation` class.
- Only the `name` field is updated in this case.
- The mutation returns the updated `Author` object.

---

#### Delete an Author

```graphql
mutation DeleteAuthorById {
  deleteAuthor(id: 1)
}
```

**Explanation**:

- The `deleteAuthor` mutation maps to the `DeleteAuthor` method in the `AuthorMutation` class.
- The mutation takes the `id` of the author to be deleted as input and returns a boolean value (`true` if the deletion was successful, otherwise `false`).

