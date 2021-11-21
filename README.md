# UserService case (TO CANDIDATE)
Best candidate, welcome to the Airlift assessment. In this solution you will find a simple service, with two endpoints.
One for fetching a User, and one for saving a user. This service is moving from a proof-of-concept (POC) towards and MVP.
We need **your** help in preparing for this step.

### Assessment

We want you to spend 30-60 minutes on this case to do what you believe is best. We are going to assess you in these areas:
- Requirements - did you fulfill the requirements given to you from the product owner (written in the code inline)
- Code quality - how robust and clean code did you write
- Maintainability - how easily can your code be extended and changed (remember - this is a service moving from POC to MVP)
- Extensibility - how easily can we build on your solution to move towards the MVP.
- Testability - the level of your tests, and how extensive they are.

Do as much of it in code as possible. If you feel like you're running out of time, no worries, just write some comments
what you would like to do, and how you would do it.

### Scope

We obviously don't want you to overdo things. So these are some limitations of the scope:
1. The only files/folders you need to touch is:
   1. UserService.Test/
   2. UserService/Core/
   3. UserService/Startup.cs (only needed if you want to register more dependencies for dependency injection)
2. You **do not** need to think about the contract of the UserProcessor.
3. You do not have to think about integration testing/end-to-end testing.

### So - where do I start?
Everything starts from the UserService/Core/UserProcessor.cs. Here you will find two TODOs. Start there.

Then, think about the structure of the class - anything you would like to change in order to increase the software quality from the aspects above?

### Help me - I'm stuck!
No worries at all. Reach out to us and we'll get you going.

