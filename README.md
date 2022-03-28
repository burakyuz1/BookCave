### BOOK CAVE 

BookCave is the graduation project of the education given within the scope of BilgeAdam Academy Boost [Burak](https://github.com/burakyuz1), [Aysegül](https://github.com/AysegulCelk), [Koray](https://github.com/Koray95) and [Ezgi](https://github.com/ezgiyildirim21).
The main purpose of the project is to develop an e-Commerce system with .Net Core 5.0 and Ms-SQL.


>Live Demo
[https://bookcave.burakyuz.com](https://bookcave.burakyuz.com)


> What the BookCave contributed to us?
* Constructing, understanding and applying Onion Architecture (Clean architecture)
* Using [Repository Design Pattern](https://www.gencayyildiz.com/blog/c-repository-design-patternrepository-tasarim-deseni/) and Specification Design pattern
* Adding and using Microsoft Identity Server
* Using EntityFramework Core
* Using Ms-Sql
* Deploying the project to the live environment
* Creating an effective design using JavaScript libraries

> What can you do in the BookCave?
* You can add the book to the cart and buy it.
* If you are logged in, you can comment on the book.
* You can see your past orders and comments.
* You can change your password and personal information.
* You can reach the book you want by filtering.
* If you are an admin user, you can add-delete-update books, categories, authors, publishers to the system.

> Used Technologies
* .Net Core 5.0
* MS-SQL
* Microsoft Identity Server
* EntityFramework Core
* Bootstrap 4 & 5
* JavaScript, jQuery
* FluentValidation
* DataTables, SweetAlert2, Toastr.js, FontAwesome, slickJS


### Usage Scenerio

* Please use **Package Manager Console** to enable migrations after cloning the project. (Don't forget to choose **BookCave.Persistence** as the default project and **BookCave.UI** as the startup project)
```
Update-Database -Context BookCaveDbContext
Update-Database -Context IdentityBookCaveDbContext
```

* One admin and user are ready when the project is standing up.

```
**ADMIN**
uid: admin@example.com
pwd: Ankara1.

**USER**
uid: user@example.com
pwd: Ankara1.
```

* If you are logged in with admin, you can access the admin panel from the account section. Otherwise, you cannot see the admin panel.
  
![image](https://raw.githubusercontent.com/burakyuz1/BookCave/master/main_page.png?token=GHSAT0AAAAAABSWMUWW6WO3DFZ4TCCSHEJSYSBZMVQ)


### Resources

* [eShopOnWeb](https://github.com/dotnet-architecture/eShopOnWeb)
* [DataTables](https://datatables.net/)
* [Admin Panel Template](http://webapplayers.com/inspinia_admin-v2.9.4/)
* [EntityFramework Core](https://www.entityframeworktutorial.net/efcore/entity-framework-core.aspx)
* [Sweet Alert 2](https://sweetalert2.github.io/)
* [Thanks to Yigit Haciefendioglu](https://www.linkedin.com/in/yi%C4%9Fit-hac%C4%B1efendio%C4%9Flu-323b1612/)

