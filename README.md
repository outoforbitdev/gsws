# [GSWS v0.3.0-alpha.0](https://github.com/outoforbitdev/gsws/tree/0.3-alpha)
[View the Wiki here!](https://github.com/outoforbitdev/gsws/wiki)

A simulation of the Star Wars Galaxy. This project is being developed in Unity 2019.2.0. This is the same project that was under development in C++ and can now be found in [this repository](https://github.com/jaymirecki/gsws-deprecated).

# The Vision
The eventual goal of this project is to be able to simulate a variety of aspects of the Star Wars galaxy, including:

* Government Management. Think SimCity Lite. Adjusting taxes, passing measures, with every decision affecting the satisfaction of the citizens. Potential for rebellion if the citizens grow too unhappy. Overseeing the budget
* Politics. Elections for positions, with political ideology scaling and branches of government resulting in diverse activities in non user-controlled governments.
* Warfare. Because otherwise it's just Star. Warfare on the galactic scale, allowing the user to manage troop movements between star systems, with simulated battles when opposing forces converge on the same position. Initially, battles will be resolved with comparitive strength calculations, but will eventually be resolved with battle AI specific to each faction (and commander) and dependent on the battlefield.

The project is still in VERY early phases of development. The first feature that will be released is the galactic campaign

This is an ambitious project, but there are some cool features to look forward to:

* Succession: When a major character dies or exits office, they will be replaced by election or internal politics.
* Factions: Eventually, all the major factions will be represented, including some from the Legacy Era (Galactic Alliance, Imperial Remnant, CSA, Hapes, Mandalore, the Hutts, and the Confederation). Initial factions are the New Republic and Galactic Empire, and the campaign is set immediately after the Battle of Endor.

## Where We Are
We are currently in the earliest phases of development. The backend database system is under active development, to be followed by server-side logic for space battle simulations.

## Where We Are Going
[View the most up-to-date roadmap here.](https://github.com/outoforbitdev/gsws/wiki/Road-Map)
The following is a roadmap for the development of new features:

* <b>v0.3: Simulated Space Combat</b>
   * <b>Database</b>
   * Weapons
   * Ships
   * Fleets
   * Planets
   * Governments
   * Logging
   * Exception Handling
 * v0.4: Galactic Space Campaign
 * v0.5: Unit Production
 * v0.6: Simulated Ground Combat
 * v0.7: UI
 * v0.8: Music

## Developer Change Log
### v0.2.0-alpha.1
* UI for viewing orbiting fleets on map
### v0.2.0-alpha.0
* Home screen and main menu
* New game menu
* Main game screen
* Map
* Time advancement
### v0.1.1-alpha.4
* Encode and Decode Planet objects
* Graph created to store planets. Allows for lookup and distance calculations.
* PriorityQueue created to implement the graph.
### v0.1.1-alpha.3
* Added Planet class.
* Changed FactionInfo GetGovernment method to return the Gov object by reference.
* Allowed current classes to be saved to file for loading and saving games.
### v0.1.1-alpha.2
* Code style: file header comments, function contracts
* File organization added to README
### v0.1.1-alpha.1
* Initial implementation of government management
* Basic pressure calculations, without any affect on constituent happiness
* Menu system
* Console display system

# How to interact with the project
## Getting Started

Open the project in Unity

### Prerequisites

Unity 2019.2.0
Open the solution in Visual Studio to edit code.

## Built With

* [Microsoft .NET Framework](https://dotnet.microsoft.com/download/dotnet-framework-runtime/net472) - To compile and run on Windows
* [Unity](https://unity3d.com/get-unity/download)
* [Visual Studio](https://visualstudio.microsoft.com/) - The editor used

## Authors

* Jay Mirecki

## Acknowledgments

* Of course, the Star Wars Universe is the creation of George Lucas and owned by Disney
