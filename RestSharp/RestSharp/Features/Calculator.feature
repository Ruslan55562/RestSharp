Feature: Arithmetic operations between numbers
Tests for multiplication, division, addition, subtraction, and extraction of the square root
using the [API] (http://api.mathjs.org/v4/)

@adittion
Scenario Outline: Add two numbers
Add two numbers using the mathjs API
	Given I have entered <First> into the searchfield
	And I have entered the <Action> into the searchfield
	And I have entered the <Second> number and <Precision> into the searchfield
	Then the result <Result> should be on the screen

	Examples:
		| First | Second | Action | Precision | Result |
		| 50    | 70     | '+'    | 3         | 120    |
		| 30    | 40     | '+'    | 3         | 70     |
		| 60    | 30     | '+'    | 3         | 90     |
		| 2.5   | 1.6    | '+'    | 3         | 4.1    |

@subtraction
Scenario Outline: Subtract two numbers
Subtract two numbers using the mathjs API
	Given I have entered <First> into the searchfield
	And I have entered the <Action> into the searchfield
	And I have entered the <Second> number and <Precision> into the searchfield
	Then the result <Result> should be on the screen

	Examples:
		| First | Second | Action | Precision | Result |
		| 70    | 50     | '-'    | 3         | 20     |
		| 40    | 30     | '-'    | 3         | 10     |
		| 60    | 30     | '-'    | 3         | 30     |
		| 4.2   | 3.5    | '-'    | 3         | 0.7    |

@multiplication
Scenario Outline: Multiplicate two numbers
Multiplicate two numbers using the mathjs API
	Given I have entered <First> into the searchfield
	And I have entered the <Action> into the searchfield
	And I have entered the <Second> number and <Precision> into the searchfield
	Then the result <Result> should be on the screen

	Examples:
		| First | Second | Action | Precision | Result |
		| 5     | 7      | '*'    | 3         | 35     |
		| 3     | 4      | '*'    | 3         | 12     |
		| 6     | 3      | '*'    | 3         | 18     |
		| 3.5   | 3.7    | '*'    | 3         | 13     |

@division
Scenario Outline: Divide two numbers
Divide two numbers using the mathjs API
	Given I have entered <First> into the searchfield
	And I have entered the <Action> into the searchfield
	And I have entered the <Second> number and <Precision> into the searchfield
	Then the result <Result> should be on the screen

	Examples:
		| First | Second | Action | Precision | Result |
		| 10    | 5      | '/'    | 3         | 2      |
		| 30    | 10     | '/'    | 3         | 3      |
		| 25    | 5      | '/'    | 3         | 5      |
		| 5.8   | 3.6    | '/'    | 3         | 1.61   |

@SquareRoot
Scenario Outline: Extraction of the square root
	Given I enter the  <Number> and <Precision> into the searchfield
	Then The square root of entered number = <Result>

	Examples:
		| Number | Precision | Result |
		| 9      | 3         | 3      |
		| 16     | 3         | 4      |
		| 24     | 3         | 4.9    |
		| 6.3    | 3         | 2.51   |