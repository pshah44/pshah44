Testing application using Swagger
1.	Download application from following repository
2.	Open downloaded solution using visual studio
3.	Run solution
4.	Web API will run in browser with you localhost port, now tweak URL to navigate to below
https://localhost:44391/swagger/index.html 
note here localhost port will be port open while running your application
5.	You will se all the method exposed by our api under "Task"
a. get
b. Post
c. get {id}
d. put 
e. delete
 
6.	Now click on get api > try it out >execute this will give you list of all the task availale
7.	Click on post api > try it out > in text area past following data and  > execute
{  
  "taskDescription": "My Swagger Unit Test Data",
  "taskStatus": "New"
}
Now make sure you get api to check if data is successfully inserted in to database.
8.	Click on put api >try it out> enter below data > enter id in id text box (i.e 1 for below example) > execute
{
  "taskID" : 1,
  "taskDescription": "My Swagger Updated Put Unit Test Data",
  "taskStatus": "New"
}
Now run get api as mentioned in step 6 above and check if data is updated
9.	Click on Delete api > try it out > enter id to be deleted (e.g. 1002) >execute
Run get requests as shown in step 6 and make sure record is deleted.


Notes: further I would like to use repository pattern to interact with dbcontext class and database and our tasks controller just interact with repository class for CRUD functionality


