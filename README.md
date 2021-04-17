# Combat System Sample
Implement a simple combat system in a game. Given 10 characters, each with a weapon, simulate the outcome of a battle.  Maintainability, logic, and organization are critical.

Full requirements are listed in Assigment.md

## Technologies Used
* Development Environment
    * Unity 2020.3.0f1
    * VSCodium
    * macOS 11.2.2
* Dependencies
    * TextMeshPro 3.0.5

## Final Touches
Q: How would your code change if weapons had special effects, like the ability to make targets catch fire?

A: The Character's ReceiveDamage script could receive a string variable with a damage type (including a default). That could trigger an OnFire script. A bullet's OnTriggerEnter script would pass that variable, which would be public and assignable from Weapon which could be assignable from Character. That way you could have special bullets in a normal gun, a fancy fun that always fires special bullets, or the character could have a powerup to grant temporary special bullets.

Q: How might this system be incorporated into a larger items and inventory system?

A: The Character's prepareWeapon script almost has that capability already as it is assigned a weaponStarting to instantiate rather than starting with a weaponHeld. Right now if you try to assign a new weapon with prepareWeapon, it just says a character's hands are full. It could instead remove the weaponHeld and swap in the new weapon from inventory or the ground and the old weaponHeld could be assigned to an inventory or instantiated on the ground.

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

## Credits
Created by Dan Manley (dcmanley@protonmail.com)
