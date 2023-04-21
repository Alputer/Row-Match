# Row-Match 

## Possible Improvements

This project is far from being a final product, therefore all aspects of the project are open for improvement, especially UI and animations.
However, in the following section, I wanted to list the most critical features that I would implement if I further
continue developing this project.

<b> 1) Animation Between Levels Popup and Gameplay Screen: </b>

 In the current version, when a user clicks play button to play a specific level, new scene loads without any delay or animation which harms user experience.

<b> 2) Game End upon No Possible Match: </b>

I divide the board into subboards where each edge of any subboard is either end of the board or a matched row. If there is no possible match in those subboards, the game ends.
This approach works well in many cases, however it doesn't take into account how many moves left in the game. For example, there might be a match which can be achieved in 4 moves but user may 
have 2 moves left. In this case, the game doesn't end because my algorithm ignores that case. The algorithm can be improved to handle those situations. You can see the 
function location below: 

File: Scripts/MatchFinder

Function: public bool isTherePossibleMatch()

<b> 3) Code Conventions </b>

I used Visual Studio Code to write C#. I didn't use automated tools and stick to some general conventions while adding spaces, placing curly braces and
naming functions and variables. I should use editors which have better support for unity game development such as visual studio and use automated
tools to follow conventions and have better code readibility.

<b> 4) Code Architecture </b>

As the size of the project grows, adding new features become cumbersome and I appreciated its importance in this project. I need to implement a better architecture.
Sometimes I was confused whether I should have a manager object or handle specific cases inside other files.
For example in some places I used singleton but in others I did not. I cannot really say that my whole architecture is self-consistent.
Therefore, it is crucial to adopt a better code architecture to ease adding new features and maintaining the codebase.
