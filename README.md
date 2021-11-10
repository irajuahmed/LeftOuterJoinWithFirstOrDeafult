## Left Outer Join in LINQ

In this example we will learn how to get only one row from child table if multiple exists while all row, while need to get all parent row from parent table but it does 
not matter if child item exists or not for the corresponding parent data. Let's do it with an example. 

---
Suppose we've following two table/entity And data for these table.

<table>
<tr><th>1. CustomerInformation data</th><th>2. CustomerVisitHistory Data</th></tr>
<tr><td>

| Id            | FirstName     | LastName  |
| ------------- |:------------- |:----------|
| 1             | Raju          | Ahmed     |
| 2             | Tahira        | Biswas    |
| 3             | Shohag        | Mia       |
| 4             | Saiful        | Islam     |

</td><td>

| Id            | CustomerId    | VisitDate  |
| ------------- |:-------------:|:-----------|
| 1             | 1             | 2021-01-01 |
| 2             | 1             | 2021-01-02 |
| 3             | 2             | 2021-01-03 |
| 4             | 2             | 2021-01-04 |
| 5             | 3             | 2021-01-03 |
| 6             | 3             | 2021-01-04 |

</td></tr> </table>


Now we want to see, if the customer is visited or not. If there is any data found in *CustomerVisitHistory* table. If customer is found in *CustomerVisitHistory* then the customer
is visited and only get the last visited date ohterwise show the customer is not visited. 

## Now we'll see, how to achive this goal by using LINQ in C#.
 ```csharp
   var customerVisit = from c in customerList
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
| :------------ |:--------------|:----------:|:-----------|
| 1             | Raju Ahmed    | Yes        | 2021-01-02 |
| 2             | Tahira Biswas | Yes        | 2021-01-04 |
| 3             | Shohag Mia    | Yes        | 2021-01-06 |
| 4             | Saiful Islam  | No         |            |


<h3 align="left">Connect with me:</h3>
<p align="left">
<a href="https://linkedin.com/in/www.linkedin.com/in/raju-ahmed-263475126" target="blank"><img align="center" src="https://cdn.jsdelivr.net/npm/simple-icons@3.0.1/icons/linkedin.svg" alt="www.linkedin.com/in/raju-ahmed-263475126" height="30" width="40" /></a>
<a href="https://stackoverflow.com/users/5615778" target="blank"><img align="center" src="https://cdn.jsdelivr.net/npm/simple-icons@3.0.1/icons/stackoverflow.svg" alt="5615778" height="30" width="40" /></a>
</p>


<h3 align="left">Support Me:</h3>
<p><a href="https://www.buymeacoffee.com/https://www.buymeacoffee.com/mIUyB3X5P"> <img align="left" src="https://cdn.buymeacoffee.com/buttons/v2/default-yellow.png" height="50" width="210" alt="https://www.buymeacoffee.com/mIUyB3X5P" /></a></p><br><br>
