# CSVGenerator
### This is a simple C# CSV generator that i've made to a project, and i resolved to make this code public.
<br>
# Usage: <br>
* Clone this project.
* There's a simple Winforms application using the two main files: CSVGenerator and CSVColumnAttribute. They do all the "hard" work.
* Simply pass a type to the CSVGenerator and a list of objects of this type to method WriteContent and voilà.
* If u want to print a filter before the data (not so common, but anyway), you can use the method WriteHeader, passing a type and a single object of this type.
* All the presentation and format of values you do in the model, using the attribute CSVColumn. You can treat:
  * Header column text.
  * Format of the column.
  * Value if the column is null.
  * Order (of columns).
  * New line after print (column, used when you need to append a new line after print the filter value).

* Enclosure the CSVGenerator instance object in a using statement, to "automagic" dispose the object.

<br><br>
### "THE BEER-WARE LICENSE" (Revision 42):<br>
<crosscountrybrasil@gmail.com> wrote this file.  As long as you retain this notice you<br>
can do whatever you want with this stuff. If we meet some day, and you think<br>
this stuff is worth it, you can buy me a beer in return.   Luan Albineli
