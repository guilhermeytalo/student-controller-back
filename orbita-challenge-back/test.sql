CREATE TABLE students (
  id SERIAL PRIMARY KEY,
  academic_register VARCHAR(10) UNIQUE NOT NULL,
  name VARCHAR(255) NOT NULL,
  email VARCHAR(255) NOT NULL,
  cpf VARCHAR(14) NOT NULL UNIQUE
);