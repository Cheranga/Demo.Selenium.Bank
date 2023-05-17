# Demo Selenium Bank

## Create a unit test project
* Create an `XUnit` project,
  * `.NET6` and `C#10` have been used here.

## Install nuget packages
* Install `Selenium.WebDriver`. This include all the selenium functionality to be used in the tests.
* Install `SeleniumExtras.WaitHelpers`. This includes a lot of useful methods to be used when finding elements safely.
* Install `FluentAssertions`. This helps us to write clean and readable assertions in tests.

## TODO
* Use `Specflow`.
* Use `configuration` to target multiple environments.
* Add CI/CD pipeline.

## Features

### Login

* Successful login
```gherkin
Given 
  Browsed to the login page through "online banking login"
  and input valid user name
  and input valid password
  
When 
  The "Login" button is clicked
  
Then
  It must browse to the "MyAccount" page
```

* Unsuccessful login
```gherkin
Given 
  Browsed to the login page through "online banking login"
  and input a user name which is not in the system
  and input a password
  
When 
  The "Login" button is clicked
  
Then
  It must display a message that the login is unsuccessful
```

### My Account

* Applying for Gold Visa Card
```gherkin
Given 
  Browsed to the my account page
  and eligible to apply for a gold visa card
      
When 
  Clicked on the "apply" link
  and enter valid password
  and click on submit
      
Then
  It must display message that the visa card will be sent through mail
```

