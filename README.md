# PolytopiaTest

A prototype 3D adventure game in Unity: explore procedurally generated block worlds, gather resources and bring nature back to unlock the next world.

## Gameplay

- **Generated worlds.** Each world is a grid of cubes whose height and type (water, sand, grass, rock...) come from a Perlin-noise height map with a falloff map, decorated with trees, bushes, stones and sand. Worlds get bigger as you progress.
- **First world: gather.** Collect more than 20 stone, wood and sand and reach the hidden exit cube.
- **Second world: restore.** Place objects from your inventory to turn tiles green; a biodiversity counter tracks your progress, and once enough tiles are restored a fox appears.
- **Inventory.** Pick up and place objects with Space, open the inventory with Tab, switch between an overview camera and a third-person camera.
- Also includes an endless-terrain mesh experiment (`world_2_mesh` scene).

## Tech stack

Unity 2021.3, C#, TextMesh Pro. Third-party assets: Malbers Animations (fox), Zibra Liquids (water).

## Run it locally

1. Install Unity **2021.3.4f1**, clone the repo and open the folder with Unity Hub.
2. Open one of the scenes in `Assets/Scenes` (`world_0`, `world_1`, `world_2`) and press Play.

## Context

Personal project started in 2022 after following Sebastian Lague's procedural generation tutorial. The idea evolved from a strategy game inspired by *7 Wonders* and *Polytopia*, to a multiplayer hide-and-seek game, and finally to an adventure game where each world holds a challenge: a puzzle to solve, a trial to pass or an object to find. It remains a prototype, but it is where Marius built a solid command of Unity and C#.
