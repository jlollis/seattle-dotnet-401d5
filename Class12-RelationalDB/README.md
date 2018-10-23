![cf](http://i.imgur.com/7v5ASc8.png) Class 12
=====================================

## Learning Objectives
1. The student will practice creating a database schema
2. The student will see the different types of relationships in a database
3. The student will create a schema with primary keys, foreign keys, and composite keys

## Lecture Outline

 ## What is a Database

### Different Kinds of Databases
	1. Relational
		- SQL Server
	2. Non-Relational
		- SQLLite


### Relations
	1. 1:1
	2. Many:Many
	3. 1:Many
	4. Many:1

### Keys
	1. Primary Keys
	2. Foreign Keys
	3. Composite Keys (New!)


### Many-to-Many in a Schema

1. Join Tables
	- With Payload
	- Pure Join Tables (w/o Payload)
2. Composite keys

## Demo

This week, we will be building out a student enrollment system in class. 
Here is our problem domain:

You have been tasked to create a system for a new coding school in your neighborhood. While gathering requirements, you were able to learn how the school plans on managing their enrollment. Here is what you gathered: 

The coding school will gather information from each student. Their system requires the student's first name, last name and age. 
Each course that the coding school will offer has a Name, specific course code, and the price that the course will cost. 
You learned that each course **must** have a course code, and that course code must be unique to each course. 
Once a student has completed a course, their final grade and if they passed is captured in a single transcript. It is possible for a student to take multiple course and therefore have multiple transcripts. It is also safe to say that once a course is completed, the system will generate a transcript for every student that was present in the course. 

Using the information you received above, create a database schema that will accurately represent the data that will be held and accessed for this student enrollment system for the school. 

### Create a Database Schema

Together, In class, create a database schema given a problem domain

Identify: 
1. Primary Keys
2. Foreign Keys
3. Composite Keys
3. Join Tables
4. Navigation Properties
