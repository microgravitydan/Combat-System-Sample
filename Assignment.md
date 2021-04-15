# Combat System
Your task is to implement a simple combat system in a game.  Given 10 characters, each with a weapon, simulate the outcome of a battle.  Do not worry about flashy visuals or any of the other trimmings - focus on the logic and organization.  Maintainability is of paramount importance to us.

## Character characteristics
* Some health - how much damage they can take before dying.
* A weapon - an object that has characteristics as described below.

## Weapon characteristics
* An attack speed - this is the amount of time it takes for a weapon to do damage, once the character has chosen a target.
* Range - How far the weapon can reach
* Must spawn a “Bullet” object

## Bullet characteristics
* An amount of damage - how much health is removed from a character when hit.
* Speed - How fast the “bullet” travels

## Battle logic
* Each character chooses a target randomly.
* Each character attacks as often as possible.
* If a character dies, it should no longer be targetable.

## Requirements
* You must write the system in C# using Unity Engine 2020.3.0
* Your code should compile and run.
* Please note your assumptions, such as what external libraries are in use, or what other supporting systems exist.
* Please send an archive of your Unity Project (Completed in Unity 2020.3.0), and a final build along with any explanatory documentation to Anthony.Laurain@subvrsive.com to be reviewed
* You may also ask any clarifying questions you have at any time
* Take any creative liberties. But this is not about visual appearance, or “flashy” gameplay. Primitive unity objects are fine, as are free pre-rigged characters from the asset store (But not necessary)

## Plus-Ups (If there’s time)
* UI that says which player won at the end

## Final Touches
You don't need to implement these, but describe how you might implement the following:
* How would your code change if weapons had special effects, like the ability to make targets catch fire?
* How might this system be incorporated into a larger items and inventory system?

## Final Note:
Do NOT seek outside assistance on this problem. I am only interested in seeing how YOU problem solve and think. This is a preliminary screening exercise. Assistance will only hurt your chances, and waste both our time in the interview process. In future interviews, you will be asked to justify your code. As well as explain other areas of the Unity tech stack