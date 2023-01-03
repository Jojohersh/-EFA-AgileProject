# EFA-AgileProject

Zachary Himes
Jordan Hershberger
DeJuan Colbert
Brody Hinton

ElevenFifty - Agile Project - User Stories and Acceptance Criteria

1.     “As a User, I need to be able to register a new account with a unique email address and password.”

		Returns true if a valid email address and user's name are provided.
		Returns false if either are missing or if email is not a valid email format.
		Returns false if the provided model is invalid.
	
2.     “As a User, I need to be able to access a Box containing a list of emails associated with my email address.”

		Returns true if UserId property in Box class has a matching user in DB.
		Returns false if UserId property in Box class returns void or does not match any users.

3.     “As a User, I need to be able to Create emails associated with my email address.”

		Returns true if email is added to DB and contains a matching foreign key ID with User’s Box.
		Returns false if email does not contain matching I.D.
		Returns false if email is not added to DB (such as db error).

4.     “As a User, I need to be able to Delete emails associated with my email address.”

		Returns true if a email is deleted.
		Returns false if emailId provided is invalid.
		Returns false if the email is not removed from the DB (such as a db error).

5.     “As a User, I need to be able to Delete my email account.”

		Returns true if a valid user is deleted.
		Returns false if userId provided is invalid.
      		Returns false if the user is not removed from the DB (such as a db error).
Stretch Goals:

   - Adding a JavaScript WebToken User Authentication
   - Adding Multiple User Inboxes / Folders for Email Sorting
   - Adding Labeling Functionality

Trello Workflow Board
https://trello.com/b/p24I5yE8/trello-agile-sprint-board-template

 - Workflow Board Contains tickets in various states of operation, colors denote contributors.
