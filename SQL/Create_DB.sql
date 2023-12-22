CREATE TABLE Books (
  book_id INT PRIMARY KEY,
  title VARCHAR(255),
  author VARCHAR(255),
  publisher VARCHAR(255),
  pages INT,
  genre VARCHAR(255),
  publication_year INT,
  cost_price DECIMAL(10, 2),
  sale_price DECIMAL(10, 2),
  continuation_of INT,
  FOREIGN KEY (continuation_of) REFERENCES Books(book_id)
);

CREATE TABLE BookCovers (
  cover_id INT PRIMARY KEY,
  book_id INT,
  cover_image VARBINARY(MAX),
  FOREIGN KEY (book_id) REFERENCES Books(book_id)
);