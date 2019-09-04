# [GSWS v0.2.0-alpha.0](https://github.com/jaymirecki/gsws)

A simulation of the Star Wars Galaxy. This project is being developed in Unity 2019.2.0. This is the same project that was under development in C++ and can now be found in [this repository](https://github.com/jaymirecki/gsws-deprecated).

# The Vision
The eventual goal of this project is to be able to simulate a variety of aspects of the Star Wars galaxy, including:

* Government Management. Think SimCity Lite. Adjusting taxes, passing measures, with every decision affecting the satisfaction of the citizens. Potential for rebellion if the citizens grow too unhappy. Overseeing the budget
* Politics. Elections for positions, with political ideology scaling and branches of government resulting in diverse activities in non user-controlled governments.
* Warfare. Because otherwise it's just Star. Warfare on the galactic scale, allowing the user to manage troop movements between star systems, with simulated battles when opposing forces converge on the same position. Initially, battles will be resolved with comparitive strength calculations, but will eventually be resolved with battle AI specific to each faction (and commander) and dependent on the battlefield.

The project is still in VERY early phases of development. The first feature that will be released is government management. Currently, population statistics are incorporated into the government operations, but will be factored out into a planet class to allow for multi-planet governments.

This is an ambitious project, but there are some cool features to look forward to:

* Succession: When a major character dies or exits office, they will be replaced by election or internal politics.
* Factions: Eventually, all the major factions will be represented, including some from the Legacy Era (Galactic Alliance, Imperial Remnant, CSA, Hapes, Mandalore, the Hutts, and the Confederation). Initial factions are the New Republic and Galactic Empire, and the campaign is set immediately after the Battle of Endor.

## Where We Are
We are currently in the earliest phases of development. Government management is the only feature under development. To facilitate better testing and reduce workload later, saving and loading from file will be implemented as other features are developed.

## Where We Are Going
The following is a roadmap for the development of new features:

* Government Management
* Galactic Map
    * Complete with planets, systems, sectors, and regions
* Representation of beings and vehicles
* Major Factions of the [New Republic Era](https://starwars.fandom.com/wiki/New_Republic_era), including but not limited to
    * New Republic
    * Galactic Empire/Dark Empire/Imperial Remnant
    * The Hutts
    * Empire of the Hand
* Quick battle simulation, akin to the Auto-Resolve feature from Empire at War
* Galactic Campaigns
* News

## User Change Log

## Developer Change Log
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
Open the folder in your favorite editor or IDE.

## Built With

* [Microsoft .NET Framework](https://dotnet.microsoft.com/download/dotnet-framework-runtime/net472) - To compile and run on Windows
* [Unity]()
* [Visual Studio Code](https://code.visualstudio.com/) - The editor used

## Authors

* Jarett (Jay) Mirecki

## Acknowledgments

* Of course, the Star Wars Universe is the creation of George Lucas and owned by Disney