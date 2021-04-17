# Combat System Sample

Implement a simple combat system in a game.  Give 10 characters, each with a weapon, simulate the outcome of a battle.  Maintainability, logic, and organization are critical.

Full requirements are listed in Assigment.md

## Task List
* [X] **10 Characters**
    * [X] **Health**
    * [X] **Name**
        * Ash, Cas, Dev, Hal, Pat, Ray, Riv, Sal, Sam, Sky
    * [X] Out of Combat
        * [X] Scan for targets
            * [X] Add targets within range
            * [X] Remove dead targets
            * [X] Remove self
        * [X] **Choose one valid target randomly**
            * [X] Enter combat
        * [X] Random movement
    * [X] In Combat
        * [X] Check if target still valid
            * [X] Exit combat
            * [X] Check if dead
        * [X] **Attack with weapon**
            * [X] Aim
            * [X] Fire
        * [X] Evasive movement
    * [X] **Death**
        * [X] Look dead
    * [X] Face and Nametags
* [X] **Weapons**
    * [X] Instantiate
    * [X] **Attack Speed** (Warmup)
    * [X] **Range**
    * [X] **Spawn Bullet**
* [X] **Bullets**
    * [x] Instantiate
    * [X] **Damage**
    * [X] **Speed**
* [ ] UI
    * [X] Win screen
        * [X] Winning character
    * [X] Combat Status
        * [X] List Name, Health, Combat Status, and Target of each Character.

## Technologies Used
* Development Environment
    * Unity 2020.3.0f1
    * VSCodium
* Dependencies
    * TextMeshPro 3.0.5