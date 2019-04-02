Took the approach of the Desktop app in order to be able to change the values on the fly
Separated the logic from the presentation so that this could also be implemented in ASP.Net or any other front end.

When in doubt, make it configurable

I did try to use the "&units=imperial" in the API URI but I was getting a 404 error each time.
Not sure what the problem is so that is why I converted the temperature in my code

I tried to use as few packages as I could. I didn't want too much being looked at "how does that work?!?"
Didn't get a chance to create the "loadFromFile" for the configuration piece but I think you can see where I was trying to go.

I wasn't sure about XUnit or NUnit so I went with NUnit since most people I know still use that. I was not sure the standard at your company.

I would like to add some mock service calls, correct the timer problem for the test and a few other things.

Now I am just adding stuff for fun... Adding a database interaction because... why not?