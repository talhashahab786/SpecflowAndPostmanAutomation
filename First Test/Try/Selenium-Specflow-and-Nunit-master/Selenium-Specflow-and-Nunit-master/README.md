# constantchanges

Repository for test and personal projects

This is a test peject project using Selenium WebDriver , NUNit and SpecFlow( ATDD freamework which is a Cucumber equivalent in .NET) . I am not done with implementing this completely like I want. Please scroll down to the bottom to see what I would like to do as next steps if I am given more time to work on this. 

Instructions to run the tests: 


After downloading the solution open it in a visual studio instance.(preferably Visual Studio Premium or higher)

Install the following plugins via Tools > Extensions and Updates(If not already installed) 

NUGet Package manager 
Specflow
NUnit Test Adapter

Download NUnit msi and install it (if not already present) 
http://github.com/nunit/nunitv2/releases/download/2.6.4/NUnit-2.6.4.msi


After the plugins are installed build the solution.

While building the packages required should be automatically downloaded and assocated with the test. 

PLease place a chromedriver.exe in the bin/debug folder of the compiled solution . Somehow having in the path was not working for this specific instance. 

Open Test Explorer in Visual Studio(Test>Windows>Test Explorer). 

The tests should show up . The tests are generated from the scenarios in the Login.Feature and Video.Feature files in the project. 

Instructions to run this from command line after the tests are generated :

1. From the command line go the directory where NUnit exe is installed  
For example it is "C:\Program Files (x86)\NUnit 2.6.4\bin\" on my system
Note: To avoid doing this step everytime you might want to add the path of Nunit-Console.exe to the environment variable . 

2. Execute 
nunit-console <path to dll of the project you built previously>

This should run all the tests. 


Here are the list of things I can immediately think of that needs improvement and I would most likely work on if its ok to continue working . 
- The test environment was acting a bit crazy yesterday(so some parts might not be robust as I could not do a test run). I dont know if that was intentional. I mught need to run through them a few more times . 
- Fix the chrome driver 
- Would like to implement the hover better- Its quick and dirty now
- Handle the underscore present or not string better in the FileName
- The last two steps of the video checking can be better
- I needed to break the scenarios better. The last step in the add videos scenario especially.
- Have checked for youtube videos only. So some part of code is checking if a  youtube video player is present. 



