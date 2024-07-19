<a id="readme-top"></a>
<br />
<div align="center">
  <h3 align="center">Simple Scriptable Object Database</h3>

  <p align="center">
    A simple way to create a database with global access and persistence, using ScriptableObjects
  </p>
</div>



<!-- TABLE OF CONTENTS -->
<details>
  <summary>Table of Contents</summary>
  <ol>
    <li>
      <a href="#about-the-project">About The Project</a>
      <ul>
        <li><a href="#built-with">Built With</a></li>
      </ul>
    </li>
    <li>
      <a href="#getting-started">Getting Started</a>
      <ul>
        <li><a href="#installation">Installation</a></li>
        <li><a href="#usage">Usage</a></li>
      </ul>
    </li>
    <li><a href="#contact">Contact</a></li>
  </ol>
</details>



<!-- ABOUT THE PROJECT -->
## About The Project

The `BaseDatabase<T>` class provides a generic implementation for managing a collection of items of type `T`, where `T` must implement `IDatabaseItem`. It offers methods to add, remove, and search for items in the database, ensuring unique IDs for each item. It also includes support for data integrity in the Unity editor and can be easily extended for different types of databases.

<p align="right">(<a href="#readme-top">back to top</a>)</p>



### Built With

* [![C#](https://custom-icon-badges.demolab.com/badge/C%23-%23239120.svg?logo=cshrp&logoColor=white)](#)
* [![Unity](https://img.shields.io/badge/Unity-%23000000.svg?logo=unity&logoColor=white)](#)

<p align="right"><a href="#readme-top">back to top</a></p>



<!-- GETTING STARTED -->
## Getting Started

To get a local copy up and running follow these simple example steps.

### Installation

1. Download or fork this project
2. Move the content to your Unity project _(if preferred, only the Scripts folder is necessary)_

<p align="right">(<a href="#readme-top">back to top</a>)</p>



<!-- USAGE EXAMPLES -->
## Usage



1. _Create the ScriptableObject that will be responsible for storing and providing global access to all created databases, by right-clicking on the desired folder in the Project tab window and choosing the option_ `Create > Database > Database Collection`
2. Create a new script that inherits from `BaseDatabase<T>`. Example:
   `PlayerProfileDatabase.cs`
   ```c#
   using UnityEngine;

   [CreateAssetMenu(menuName = "Database/Sample/Player Profile Database", fileName = "PlayerProfileDatabase")]
   public class PlayerProfileDatabase : BaseDatabase<PlayerProfile>
   {
   
   }
   ```
3. _Create an instance of the global variable by right-clicking on the desired folder in the Project tab window and choosing the option (in this example)_ `Create > Database > Sample > Player Profile Database`
4. _Give your new database a name, for example,_ `PlayerProfileDatabase`
5. Assign the new instance of the `PlayerProfileDatabase` to the `DatabaseCollection` ScriptableObject
6. _Now, to access the PlayerProfileDatabase, in any MonoBehaviour script, you can use the static call_
   ```c#
   DatabaseCollection.TryGet(out PlayerProfileDatabase playerProfileDatabase);
   ```

<p align="right">(<a href="#readme-top">back to top</a>)</p>



<!-- CONTACT -->
## Contact

LuizThiago - [@CodeLuiz](https://twitter.com/@CodeLuiz) - hello@luizthiago.com

Project Link: [https://github.com/LuizThiago/GlobalVariables](https://github.com/LuizThiago/GlobalVariables)

<p align="right">(<a href="#readme-top">back to top</a>)</p>
