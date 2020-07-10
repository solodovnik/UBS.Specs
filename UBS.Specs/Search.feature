Feature: Search
	In order to find the information I need
	As a user
	I want to enter search query and get search results

Scenario: Search by single word
	Given I'm on Home page
	When I perform search by search query career
	Then all highlighted text phrases in search result summaries equal to career

Scenario: Search by phrase in quotes
	Given I'm on Home page
	When I perform search by search query "career opportunity"
	Then all highlighted text phrases in search result summaries equal to career opportunity or career opportunities

Scenario: Not found results
	Given I'm on Home page
	When I perform search by search query ttttttt
	Then the message Ooops, we didn't find any results for ttttttt should be displayed
