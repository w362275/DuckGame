# Change Log
## 27/09/21
The duck now has a body!
![Screenshot (68)](https://user-images.githubusercontent.com/44437464/134911654-02299880-c8d7-4e4c-9534-2a370d5287dc.png)
In the initial projection for this month I set myself the goal of simply nailing down the basic movement and thinking through the ideas for the core mechanics. However, I soon grew tiresome of staring at cubes following me around for ages on end, and as such I was able to throw this together.

In doing so I also thought about the art direction for the game. The theme of the game lends itself to a naturally whimsical art style, so after much deliberation I decided to ~~go down the same route as most indie devs and~~ try some low-poly modelling out. I opened Blender and tried my hand at it, eventually coming up with this. All I needed to do was import the .fbx file into Unity, create a prefab with the model, then set up a couple of colliders and boom! All sorted!

With this in mind I also examined some other artistic techniques and ideated upon some shaders for use. Since the game takes place in a bathtub I knew I would have to do some water textures, so I scoured the internet for ideas and stumbled across a very helpful tutorial from Brackeys on how to make a water shader. You can see it [here](https://www.youtube.com/watch?v=Vg0L9aCRWPE&t=33s)! Not only that, I experimented with a shader graph to highlight the edges of certain objects. While it seemed to have a bit of issue on more complex models, it seems to work with simple objects and should be expanded upon.

So what is happening beyond the aesthetic? I am currently working on the script for reducing the player health, it shouldn't take long but it also means configuring when ducks attack (which coincidentally could be the name of a novel: When Ducks Attack). I hope to have the base code for it sorted within the next week, but I anticipate I will also have to make an attack manager to ensure that the player will not be constantly bombarded with a range of fowl-based projectiles.

###### TL;DR:
 - Added model for ducks
 - Experimented with shaders for water and edge detection
 - Currently iterating on other artistic choices
 - Working on duck offensive systems

Stay tuned and hopefully I'll have the duck attack system done soon!


## 22/09/21 (Introduction)
Hello there! My name is Alex and this is a personal project I have been working on for about a month now!

Obligatory backstory: one of my university professors was (and probably still is) obsessed with rubber ducks. He first introduced them to us as a method of helping us understand our programming in a better fashion by having an entity we could explain it to. The bare basis is that breaking the code down to its simplest form should be so simple that even a rubber duck would be able to understand it. So whenever anybody in our class won a quiz or did exceedingly well with some work, we earned a duck.

Unfortunately COVID-19 hit the world halfway through my second year of university and he couldn't give out any rubber ducks anymore. But the joke still lived on, and every time we got a chance we would reference the rubber ducks. It never ended through the rest of our time online, and since I ended uni I only thought it fitting to develop a project that utilised rubber ducks in some fashion. Which is what we have here: this amalgamation of rubber ducks and insanity!

The current state of the game is fairly barebones at the moment. The milestone that I set for the end of this month was to nail down the basic movement for the player and ducks scattered throughout the levels. So far there is a single level which will be used to test that all desired physics and mechanics of the game function as intended - more in-depth and structured levels will be developed following this period. With this in mind, the following criteria have been fulfilled:

 - Basic player movement
 - Basic duck movement
 - Spawning in new ducks
 - Weapon system
 - Duck health

Having achieved these goals, the game development process is entering a second stage of development that will shift to focus on the enemy's side of things. I have set the following goals for myself to achieve within the upcoming month of October:

 - Player health
 - Duck attacks (may find a mix of melee and ranged)
 - Duck varieties/different duck enemies
 - Status effects
 - Player death/respawning/restarting

Finally, the roadmap for future development. While I have not got absolutely everything set out in detail, the current plan for the game state beyond this point will look a little something like this:

 - Pick-ups/items
 - Other weapons
 - Level design
 - Difficulty scaling
 - Boss battles
 - Endgame events/bosses
 - Music(?)

I will be uploading a demo to Itch.io once the game has entered a suitable state for testing. Until then, please do feel free to browse through the scripts that I have inserted into the repository, and do let me know if you have any feedback or suggestions!
