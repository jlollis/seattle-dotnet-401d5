![cf](http://i.imgur.com/7v5ASc8.png) Class 05
=====================================

## Learning Objectives
1. The student will understand and implement their own enums into their programs and classes.
2. The student will be able to identify and implement their own generic collection.

### Challenge

To add your linked list implemenation to your challenges, do the following:

```
In your Project, right click and select "Add" -> "Reference"

Select Browse

Find the .dll file of your implementation
1. Find your project
2. Select bin
3. Select Debug
4. Select netcoreapp2.0
5. Select your .dll file of your implementation

NOTE: Everytime you add to your implementation, you must rebuild your implemenation and re-add your dll to your challenge project. 
```


### Enums

1. What are enums?
   1. Enumeration types ("also called enums"), provide an 
   efficient way to define a set of named integral constants that may be assigned 
   to a variable. 

```csharp
enum Days 
{ 
    Sunday,
    Monday, 
    Tuesday, 
    Wednesday, 
    Thursday, 
    Friday, 
    Saturday 
};

 enum Months : byte 
 { 
     Jan, 
     Feb, 
     Mar, 
     Apr, 
     May, 
     Jun, 
     Jul, 
     Aug, 
     Sep, 
     Oct, 
     Nov, 
     Dec 
 }; 
   ```
 - Count starts at 0, if you do not specify a value. 
 - default type of enum is int, but you can specify alt with a :type (such as byte);

```csharp
Days today = Days.Monday;  
int dayNumber =(int)today;  
Console.WriteLine("{0} is day number #{1}.", today, dayNumber);  

Months thisMonth = Months.Dec;  
byte monthNumber = (byte)thisMonth;  
Console.WriteLine("{0} is month number #{1}.", thisMonth, monthNumber);  

// Output:  
// Monday is day number #1.  
// Dec is month number #11.  

```

- You can create and set your custom values

```csharp
enum MachineState
 {
   PowerOff = 0,
   Running = 5,
   Sleeping = 10,
   Hibernating = Sleeping + 5
  }
```

### Collections

There are two ways to create and manage a group of related objects
    1. Create an array of objects
    2. creating a collection of objects

####What is a collection?
1. Collections provide a more flexible way to work with groups of objects. Unlike arrays, 
   the group of objects you work with can grow and shrink dynamically as the needs of the application change. 
   For some collections, you can assign a key to any object that you put into the collection so that you can quickly 
   retrieve the object by using the key.
A collection is a class, so you must declare an instance of the class before you can add elements to that collection.

2. If your collection contains elements of only one data type, you can use a Generic. 

#### Generics

1. Creating a Generic List: 
```csharp 
	List<string> princesses = new List<string>();

    princesses.Add("Snow White");
    princesses.Add("Cinderella");
    princesses.Add("Aurora");
    princesses.Add("Repunzel");
    princesses.Add("Ariel");

    foreach(var princess in princesses)
    {
       Console.WriteLine($"Princess: {princess}");
    }


```



