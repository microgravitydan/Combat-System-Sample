# Combat System Sample

Implement a simple combat system in a game.  Give 10 characters, each with a weapon, simulate the outcome of a battle.  Maintainability, logic, and organization are critical.

Full requirements are listed in Assigment.md

## Task List
* [ ] **10 Characters**
    * [X] **Health**
    * [ ] Name
    * [ ] Out of Combat
        * [ ] Scan for targets
            * [X] Add targets within range
            * [ ] Remove dead targets
            * [X] Remove self
        * [X] **Choose one valid target randomly**
        * [ ] Random movement
    * [ ] In Combat
        * [ ] Check if target still valid
        * [ ] Attack with weapon
        * [ ] Evasive movement
    * [X] **Dead**
    * [ ] Face and Nametags
* [ ] **Weapons**
    * [ ] **Attack Speed** (Warmup)
    * [ ] **Range**
    * [ ] **Spawn Bullet**
    * [ ] Blast effects
* [ ] **Bullets**
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