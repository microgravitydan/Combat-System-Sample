# Combat System Sample

Implement a simple combat system in a game.  Give 10 characters, each with a weapon, simulate the outcome of a battle.  Maintainability, logic, and organization are critical.

Full requirements are listed in Assigment.md

## Task List
* [ ] **10 Characters**
    * [X] **Health**
    * [ ] **Name**
    * [ ] Out of Combat
        * [X] Scan for targets
            * [X] Add targets within range
            * [X] Remove dead targets
            * [X] Remove self
        * [X] **Choose one valid target randomly**
            * [X] Enter combat
        * [ ] Random movement
    * [ ] In Combat
        * [X] Check if target still valid
            * [X] Exit combat
        * [ ] **Attack with weapon**
            * [ ] Aim
            * [ ] Fire
        * [ ] Evasive movement
    * [X] **Death**
        * [ ] Look dead
    * [ ] Face and Nametags
* [ ] **Weapons**
    * [X] Instantiate
    * [ ] **Attack Speed** (Warmup)
    * [ ] **Range**
    * [ ] **Spawn Bullet**
    * [ ] Blast effects
* [ ] **Bullets**
    * [ ] Instantiate
    * [ ] **Damage**
    * [ ] **Speed**
* [ ] UI
    * [ ] Win screen
        * [ ] Winning character
    * [ ] Combat Status
        * [ ] List Name, Health, Combat Status, and Target of each Character.

## Technologies Used
* Development Environment
    * Unity 2020.3.0f1
    * VSCodium
* Dependencies
    * TextMeshPro 3.0.5