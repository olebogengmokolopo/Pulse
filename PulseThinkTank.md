# PULSE 
## Terminology
__Production__: The client’s database server to be monitored.
__Microservice__: Service that sits on the client server querying the production database.
__Pulse Database__: Central database that stores client’s performance data.
__App Server__: Web server that will serve a user with a web page displaying data from the Pulse Database. Also receives data from the Microservice to store in the Pulse Database.


## Thoughts and concepts
Reporting on historical data using app server (eg. CPU over time)
* Widgets set the window for reporting (eg. 1,2 or 4hrs)
* Microservice config set the data retrieval interval
Inactivity alerts (eg. alert if no data received for 2 intervals)
