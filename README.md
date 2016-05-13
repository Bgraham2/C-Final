# C-Final
C# .Net Final Project

This site is a simple library system. Users can create an account and login and check out books. Admins can update logins, create new admins, update book inventory, add or remove books, check for overdue books.

dbo files are create table files for the program. The usp files are stored producures used to insert, update, select, and detele data from the tables.

THe PVUtil folder container the webhelper class which veriies password strength. It aslo contains the pvutil class which ncan be used for module testing.
pvlogger is for logging but it is not implemented yet. Bcrypt contains the salt code used by pvencrypter to encrypt passwords.

PVtest folder contains the config file and codebehind for the module testing. Becasue testing was complete when turned in its not active anywhere.

The classes located in the PVService folder take the object passed to the its respective dao and verifies the there is data being passed in. If not it throws an application error.

The classes located in PVDomain takes input from the aspx pages and creates objects to be passed to the dao's.

The mapper classes ( inherit from the base mapper) in PVdata folder takes the objects sent to the dao's then validates the data and returns the validated object to the dao.
The baseDao set the connection for hte child dao's. The dao classes takes the ojbect from the mapper and then calls the correct stored procedure to insert, update, select, or delete data from the Database.


The final folder holds all the aspx pages and their corresponding codebehind.
The main page holds an about page, a register page, a login page, and a catalog page.
The register page allows user to create a login that has a string password check, the password is encrypted and stored in the DB. Admin logins are created in the Admin section, the DB holds a default admin login.
The login allows users to log in, regulars users are sent to the catalog page, admin users are sent the admin section.
The catalog page has a drop down box with all the books available for check out from the DB. The user selects the book and clicks checkout and the book is added to the datagrid that shows all checked out books and return dates.

If the login is an admin they can access the admin pages located in the Admin folder under the final folder.
The admin pages allow the the admins to remove or create or update admins, books, and user in the inventory. It also shows the admin books that are currently overdue.



