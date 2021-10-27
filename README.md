## Left Outer Join in LINQ

In this example we will learn how to get only one row from child table if multiple exists while all row, while need to get all parent row from parent table but it does 
not matter if child item exists or not for the corresponding parent data. Let's do it with an example. 

---
Suppose we've following two table/entity And data for these table.
1. CustomerInformation data

| Id            | FirstName     | LastName  |
| ------------- |:-------------:| -----:    |
| 1             | Raju          | Ahmed     |
| 2             | Tahira        | Biswas    |
| 3             | Shohag        | Mia       |
| 4             | Saiful        | Islam     |
 
2. CustomerVisitHistory Data

| Id            | CustomerId    | VisitDate  |
| ------------- |:-------------:| ----------:|
| 1             | 1             | 2021-01-01 |
| 2             | 1             | 2021-01-02 |
| 3             | 2             | 2021-01-03 |
| 4             | 2             | 2021-01-04 |
| 5             | 3             | 2021-01-03 |
| 6             | 3             | 2021-01-04 |
