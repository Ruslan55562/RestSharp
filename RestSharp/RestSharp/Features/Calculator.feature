Feature: Arithmetic operations between numbers
Tests for multiplication, division, addition, subtraction, and extraction of the square root
using the [API] (http://api.mathjs.org/v4/)

@adittion
Scenario Outline: Add two numbers
Add two numbers using the mathjs API
	Given I have entered <First> into the searchfield
	And I have entered the <Action> into the searchfield
	And I have entered the <Second> number and <Precision> precision into the searchfield
	Then the result <Result> should be on the screen

	Examples:
		| First | Second | Action | Precision | Result |
		| 50    | 70     | '+'    | 0         | 120    |
		| 30    | 40     | '+'    | 1         | 70     |
		| 3.6   | 30     | '+'    | 3         | 33.6   |
		| 2.5   | 1.6    | '+'    | 4         | 4.1    |

@subtraction
Scenario Outline: Subtract two numbers
Subtract two numbers using the mathjs API
	Given I have entered <First> into the searchfield
	And I have entered the <Action> into the searchfield
	And I have entered the <Second> number and <Precision> precision into the searchfield
	Then the result <Result> should be on the screen

	Examples:
		| First | Second | Action | Precision | Result |
		| 70    | 50     | '-'    | 0         | 20     |
		| 40    | 30     | '-'    | 2         | 10     |
		| 60    | 33.3   | '-'    | 3         | 26.7   |
		| 4.2   | 3.5    | '-'    | 2         | 0.7    |

@multiplication
Scenario Outline: Multiplicate two numbers
Multiplicate two numbers using the mathjs API
	Given I have entered <First> into the searchfield
	And I have entered the <Action> into the searchfield
	And I have entered the <Second> number and <Precision> precision into the searchfield
	Then the result <Result> should be on the screen

	Examples:
		| First | Second | Action | Precision | Result |
		| 5     | 7      | '*'    | 2         | 35     |
		| 3     | 4      | '*'    | 2         | 12     |
		| 6     | 3.3    | '*'    | 3         | 19.8   |
		| 3.5   | 3.7    | '*'    | 4         | 12.95  |

@division
Scenario Outline: Divide two numbers
Divide two numbers using the mathjs API
	Given I have entered <First> into the searchfield
	And I have entered the <Action> into the searchfield
	And I have entered the <Second> number and <Precision> precision into the searchfield
	Then the result <Result> should be on the screen

	Examples:
		| First | Second | Action | Precision | Result |
		| 10    | 5      | '/'    | 0         | 2      |
		| 30    | 10     | '/'    | 3         | 3      |
		| 24    | 5      | '/'    | 2         | 4.8    |
		| 5.8   | 3.6    | '/'    | 4         | 1.611  |

@SquareRoot
Scenario Outline: Extraction of the square root
	Given I enter the  <Number> and <Precision> into the searchfield
	Then The square root of entered number = <Result>

	Examples:
		| Number | Precision | Result |
		| 9      | 0         | 3      |
		| 16     | 1         | 4      |
		| 24     | 3         | 4.9    |
		| 6.3    | 4         | 2.51   |