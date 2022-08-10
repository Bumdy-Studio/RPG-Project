---=== Character Test Environments ===---
By Marshall Ashdowne @ daarkzek@protonmail.com

Table Of Contents:
1. Setup Guide
2. Usage
3. Customizing Scene


1. Setup Guide

To use Character Test Environments you must first decide what you want to test
in the environments. If you are wanting to test objects, art, shaders or scripts
in the scene read 1.b, if you are also wanting to test using a custom player
object or custom camera read 1.a & 1.b

  1.a Removing the default camera
  To remove the default "spectator" camera that comes bundled in the scene and
  replace it with your own simply follow the instruction below.
  - Delete the Game Object in the Hierarchy named "DefaultCamera"

  2.a Adding custom scripts, art and models
  To add custom objects to the Character Test Environments scene simply drag
  them from your project window into the scene. Beware that some objects in the
  scene already have scripts attached which edit the scene by spawning objects
  which may interfere with scripts you add to the objects. To avoid this
  collision please add any scripts to new game objects and not existing
  game objects in the environment.

Once setup you can press play and start testing!

2. Usage

Once you have the scene up and running you can then test your characters
movement, lighting and collision as well as test particles, shaders and more
without having to build out a complicated test environment. To fully take
advantage of this test environment it is highly recommended to create your own
"arenas" to test specific parts of your game. For example if you were making a
parkour game you would want more things to jump between, things to hang on to and
much higher up arenas. You can create new "arenas" by following the guide below.

3. Customizing Scene

By default you can only test a few things in the test environment, but using
the assets provided you can add your own levels to suit your game and allow you
to test and develop everything in your game. You can do with by creating your
own "levels"

  3.a Creating your own level
  To create a level in the scene right click inside the "Hierarchy" window on
  the object named "Arena1" and click Duplicate. This will create a new level.
  Using the "Inspector" change the position on the Z axis to 0 to center it.
  You can then resize, move, rotate and duplicate the cubes inside to create
  any arena you want.

  3.b Changing the color of the cubes
  To change the color of the cubes, go into your folder view (usually at the
  bottom of the screen) and enter the folder
  "Character Test Environments/Scene 1/Materials". Make sure you are looking at
  the scene view of your game then drag the color you wish to apply, to the box
  and it will change color.
