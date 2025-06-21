# oop_pw1_ext_2425

This repository is the base element for the development of Practice 1 for the extraordinary OOP exam session. 

## 1. COVER 

<div align="center">
    <img src="../files/readme_files/COVER.png" alt="README.md cover for the project" width="95%">
</div>

## 2. TABLE OF CONTENTS 

- [1. COVER](#1-cover)
- [2. TABLE OF CONTENTS](#2-table-of-contents)
- [3. INTRODUCTION](#3-introduction)
 - [3.1 NAMES OF THE GROUP MEMBERS](#31-names-of-the-group-members)
 - [3.2 SUMMARY OF THE DOCUMENT](#32-summary-of-the-document)
- [4. DESCRIPTION](#4-description) 
 - [4.1 PROPOSED SOLUTION](#41-proposed-solution)
 - [4.2 CLASS DIAGRAM](#42-class-diagram)
 - [4.3 DEVELIPMENT CONSIDERATIONS](#43-development-considerations)




## 3. INTRODUCTION 

### 3.1 NAMES OF THE GROUP MEMBERS

    Daniel Sama Clemente

### 3.2 SUMMARY OF THE DOCUMENT

This document shows all of the inform regarding on how OOP principles have been used to, create a program resembling a Train Station Simulation of trains arriving and docking. This program was built for the Practical Work 1 (Extraordinary) of the OOP (Object-Oriented Programming) subject. As stated before, the program simultes the management of arriving trains into a train station and docking them. 

## 4. DESCRIPTION

### 4.1 PROPOSED SOLUTION 

The program has been developed into 6 classes (including the Program class), in which each class does something specific. The classes in the program are as they follow: 

**PROGRAM**: This is the entry point of the program, in where the user is given the welcome message and where the user is also asked about how many platforms he wishes the platform to have. After this the station is instantiated with the specific amount of platforms the user has asked. Then the program is taken to the to a method in the Station class which displays a menu for the user. 

**STATION**: This is probably the most importnt class in the whole program, as it creates the list of Trains and Platforms. Tells the user which options to select, controls the inputs, loads the trains' data from a specific file; adds those trains list making sure data has been entered appropiately, making sure no ID is reapeted and also checking that at least the data of 15 trains is found, otherwise the trains are not loaded to the program. Futhermore, for each tick in the simulation, each train's arrival time is reduced by 15 minutes, shows the status of the trains and the platforms, and when a train is waiting it sends a request to the Platfrom class to start the docking of a train. The attributes used in this class are as follows: 

Train: List<Platform> platforms -> Creates the list of platfroms (number of them is given by the user).
Platform: List<Train> trains -> Creates the list of the trains (loaded from a specific file given by the user).

Compositions was used for both lists, in the context of platfroms, a platform can't exist if there is no station, the same can be argued vice-versa. It can also be argued that the station has no point in existing if there are no trains which use it. 

Other attributes are: 

int minutesPerTick = 15 -> Makes sure that each of the ticks represents 15 minutes. 
        
bool allTrainsDocked = false -> Controls when all trains have been docked to automatically stop the simulation.

**PLATFORM**: Ths class managed everything related to the platform, like assigning a train to a platfrom when the platform is free, calculating the ticks the train needs to fully dock, and well as changing the proper state of the platform when its freed or occupied. This class essentially takes and checks the request, from the Station class, to assign a train to a platform, if it is possible and communicates it back to the Station class. The attributes in this class are as follows: 

string id -> Defines the id of each platform.

enum PlatformStatus platformStatus -> Defines the state of the platform in each tick.

Train currentTrain -> Property, which assigns a train to a specific platform.

int dockingTime -> The amount of ticks neccesary for the docking process to finish.

**TRAIN**: This is an abstract class, it used the principle of abstraction as each of the trains loaded will have to be one of the subclasses (Freight or Passenger), in other words each train will only belong to a specific subclass, thus no general Train is created. This class also uses the principle of inheritance as it is the superclass of each train created. Furthermore this class uses polymorphism principles as there is a virtual method which prints the generic characteristics of each train and then overrides methods in the subclasses, it prints the base method and then the override method. The attributes in this class are as follows: 

string id -> Defines the train number 

TrainStatus trainStatus -> Defines the state of the train (EnRoute, Waiting, Docking, Docked).

int arrivalTime -> The arrival time, in other words, the time remaining until the train reached the station.

string type -> Shows the type of train (Passenger or Freight).

**FREIGHTTRAIN**: This is a subclass which inherits from the superclass of Train. It has the override method which prints the 2 extra attributes which only exist with Freight Trains. The attributes from the Superclass are passed down, the unique attributes for this class are as they follow: 

int maxWeight -> The maximum weight a specific freight train can carry. 

string freightType -> The type of goods a specific freight train is carrying.

**PASSENGERTRAIN**: This is a subclass which inherits from the superclass of Train. It has the override method which prints the 2 extra attributes which only exist with Passenger Trains. The attributes from the Superclass are passed down, the unique attributes for this class are as they follow: 

int numberOfCarriages -> The number of carriages a certain passenger train has. 

int capacity -> The amount of capacity a certain passenger train has. 

### 4.2 CLASS DIAGRAM 

<div align="center">
    <img src="../files/readme_files/CLASS_DIAGRAM.png" alt="README.md image showing the class diagram of the program" width="95%">
</div>

### 4.3 DEVELOPMENT CONSIDERATIONS

- The different consideration must be followed to develop the program: 

- The user input to the program how many platforms there may be in the station.

- The program must implement comprehensive input validation to handle errors. 

- The user also input to the program (through keyboard) the path to the file where the train data is to be loaded to the program. 

- The file must also have a minimum of 15 trains to be loaded. 

## 5. PROBLEMS & CHALLENGES



## TIMELINE OF DEVELOPMENT ##

### 12/06/2025 ###

Forked the repo from the base repo. 

Made the correspoding folder as stated. 

Added the correct files in their correspoding folder. 

### 13/06/2025 ### 

Created the files neccessary for each class. 

Added constructors and also their properties neccessary.

Added the syntax in the Program and Station class to print the menu. 

Added the selection menu to the Station class.

### 14/06/2025 ###

Added the method to allow the trains to be loaded from a file. 

### 18/06/2025 ###

Added in the constructor a ConsoleWriteLine to show the creation of each Platform by the console to the user. 

Corrected errors in the file loading. 

Added the virtual methods for printing the details of the platfroms and trains. 

Added partially the DisplayStatus method to show through the console the trains loaded from the file. ÇÇ

Added a method to make sure no duplicate ID's are loaded from the file. 

### 19/06/2025 ###

Implemented the GetStatus method in the platform, in order to fully print the status of the platform in the DisplayStatus method. 

Changed a variable name for more clarity. 

Added management for docking and futher related tasks to do with platforms in the platform class.

Fully implemented the AdvanceTick method. 

Added clarity for the code reading in the console in the Program class. 

Added a new method to manage the request of platforms, for arriving train and setting them to waiting or allowing them to process the request. 

Removed uneccessary code in the Platform class. 

Added a method to check when all the trains are docked and end the program. 

Fixed minimal erros in the program class. 

Added setters and getters as well as changed the atributes of each class(not applied to Program) to the maximum access modifier possible to enhance encapsulation. (Protected for attributes in Train Class, rest are private). 

Added exceptions to the Station and Platfrom class. 

Fixed some typos in the Program Class. 

Added comments on all classes. 

Made a change in the LoadTrainFromFile method in the Station class, to automatically load the trains from a file regardless if it has a header or not, without losing data of trains. 

Added the cover image to put on the README file. 

Made some changes into the behaviour of the program. 

Added the class Diagram Image. 