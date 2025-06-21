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



## 3. INTRODUCTION 

### 3.1 NAMES OF THE GROUP MEMBERS

    Daniel Sama Clemente

### 3.2 SUMMARY OF THE DOCUMENT

This document shows all of the inform regarding on how OOP principles have been used to, create a program resembling a Train Station Simulation of trains arriving and docking. This program was built for the Practical Work 1 (Extraordinary) of the OOP (Object-Oriented Programming) subject. As stated before, the program simultes the management of arriving trains into a train station and docking them. 

## 4. DESCRIPTION




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