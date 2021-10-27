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


Now we want to see, if the customer is visited or not. If there is any data found in *CustomerVisitHistory* table. If customer is found in *CustomerVisitHistory* then the customer
is visited and only get the last visited date ohterwise show the customer is not visited. 

## Now we'll see, how to achive this goal by using LINQ in C#.
 ```csharp
   ar customerVisit = from c in customerList
                      join cv in customerVisitHisorys.AsQueryable() on c.Id equals cv.CustomerId into cvGroup
                      from cvHistory in cvGroup.OrderByDescending(cvr => cvr.Id).Take(1).DefaultIfEmpty()
                      select new CustomerVisitDetails
                      {
                          CustomerId = c.Id,
                          FullName = c.FirstName + " " + c.LastName,
                          IsCustomerVisited = cvHistory==null?"No": "Yes",
                          VisitDate = cvHistory==null?"": cvHistory.VisitDate
                      };
```
# Let's see the output of the query in follwoing table.
| Customer Id   | Full Name     | Is Visited | Visit Date |
| ------------- |:-------------:| ----------:| ----------:|
| 1             | Raju Ahmed    | Yes        | 2021-01-02 |
| 2             | Tahira Biswas | Yes        | 2021-01-04 |
| 3             | Shohag Mia    | Yes        | 2021-01-06 |
| 4             | Saiful Islam  | No         |            |


