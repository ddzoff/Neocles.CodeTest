# Neocles Backend Code Test 2019

## Scenario:
We outsourced a piece of work to a developer to call a weather API. However we weren't happy with the result so we ended the contract.

We don't want to throw the effort away though, it does work, after all. 

Now we need you to take a good look at the code, and improve it to meet our high standards. You should use it as a showcase to show your programming style, so go all out on the refactoring, if you think that is necessary. 

Nothing in the files that we sent you is holy! 

(Actually, one of our seniors wrote this code, but he did so on purpose. No developers were harmed during the making of this code test!)

## Exercises

### Exercise 1: Mandatory - Improve the existing Get method in the Weather Controller

 - The current code works, but the code is weak and also contains bad practices. Improve the quality of the code.
 - Improve the possibility of unit testing.
 - Instead of returning the json response from the weather API as a string, create models to return the output.

### Exercise 2: Optional - Create a HTTP POST method with the same functionality as the GET method

 - The three input arguments should be passed in as a model, which should be defined in the request body.
 - Include input validation in the model and write a custom validator if required.

### Exercise 3: Optional - Unit test

 - The code currently has no tests. If you feel it is valuable, add as much testing as you feel is necessary.
  
  
## Note:

The following values will return data from the weather API:

 - longitude: 10
 - latitude: 0
 - timestamp: 2016-11-23T01:04:00

## Evaluation Criteria

 We will review this code test with you later on, during which stage you can explain what you did, and probably more importantly, what you didn't do, and why. 

 - Expected time to spend: 2 hours 
   - The full exercise will most likely be too much for two hours, so it is not a problem if you can't finish everything in time. 
 - The first part is mandatory and the rest is optional. 
 - We prefer to see quality instead of quantity. So, please do not rush the test just to finish everything. 
 - You are free to spend more than 2 hours if you wish but we expect you to be honest about that! 
 
Good luck!
