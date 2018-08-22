# Requirements

## User story (requirement)

As a conference organizer
	I want to search for available speakers
	So that I may contact them about my conference

## Gherkin (test cases)

Given I am a conference organizer
	And Given a speaker in mind
	When I search for speakers by name
	Then I receive speakers with a matching first name

Given I am a conference organizer
	And Given a speaker in mind
	When I search for speakers by name
	Then I receive speakrs with a matching last name

Note: "matching" means starts-with

# Chapter 6

## Speakers (Epic)

### Feature
As user group organizer
	I want to see a listing of all speakers
	so that I can find speakers for my user group.

Given system contains speakers
	When viewing speaker catalog
	Then a listing of all speaker\ summaries is returned.

### Feature
As conference organizer
	I want to see details of a particular speaker
	so that I might view more information about them.

Given specified speaker exists
	When speaker selected
	Then speaker details are returned

Given specified speaker does not exists
	When speaker selected
	Then a friendly error message should be returned

### Communities (Epic)

### Feature
As a speaker
	I want to see a listing of all communities
	so that I can find potential user groups at which to speak

Given system contains communities
	When viewing community catalog
	Then a listing of all user groups is returned

### Feature
As a speaker
	I want to see details of a particular community
	so that I can learn more about the user group

Given community selected
	When specified community exists
	Then community details returned.

Given community selected
	When specified community does not exist
	Then a friendly error message should be returned

Given specified conference does not exists
	When conference selected
	Then a friendloy error message should be returned.

### Conferences (Epic)

### Feature
As a speaker
	I want to see a listing of all conferences
	so that I can find conferences at which to speak.

Given system contains conferences
	When viewing conference catalog
	Then a listing of all conferences is returned

### Feature
As a speaker
	I Want to see details of a particular conference
	so that I can learn more about the conference.

Given specified conference exists
	When conference selected
	Then conference detail returned.

Given specified conference does not exists
	When conference selected
	Then a friendly error message should be returned.