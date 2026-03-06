
Indexes
1️. Indexes in EF Core are used to improve query performance, especially when searching frequently in specific columns like Email.
2. An index can be added in two ways: Data Annotations inside the model or Fluent API
3. An index can also be made Unique using .IsUnique() to prevent duplicate values.

Fluent API

<img width="712" height="188" alt="image" src="https://github.com/user-attachments/assets/f582cf02-3008-4c67-9afe-45f528e95a3d" />

Data Annotations

<img width="800" height="438" alt="image" src="https://github.com/user-attachments/assets/39b2ea20-5cd0-4b85-ba3a-2524c094ef00" />

.

EF Core supports inheritance, which allows a class to inherit properties from a base class; for example, Student and Teacher can inherit from a base class Person. EF Core stores inherited classes in the database using different mapping strategies, and the default strategy is TPH (Table Per Hierarchy). In TPH, all classes are stored in one table with a column called Discriminator, which tells EF Core whether the row represents a Student or a Teacher. Another strategy is TPT (Table Per Type) where each class has its own table, but this approach can be slower because it requires joins between tables. The third strategy is TPC (Table Per Concrete type) where each concrete class has its own complete table. By default, EF Core uses TPH unless the developer explicitly configures another strategy.
