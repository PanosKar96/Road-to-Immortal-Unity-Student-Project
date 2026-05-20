# Road to Immortal – Unity Student Project

## Overview

**Road to Immortal** is a small turn-based Unity game developed as a student project for a Unity course.

The project is based on an older browser-based prototype and was rebuilt in Unity using C# in order to practise scene management, UI logic, combat systems, audio handling, and basic game architecture.

The goal of the project was not only to create a playable game, but also to understand how different Unity systems work together in a structured way.

---

## Game Flow

The game follows a simple scene-based structure:

Start Scene → Character Selection → Map → Battle → Victory / Game Over

The player starts from the main menu, selects a hero, chooses the available level from the map, and enters a turn-based battle.

Depending on the result of the battle, the game progresses to the next level, a victory screen, or a game over screen.

---

## Main Features

- Start menu with Play and Options
- Character selection system
- Map-based level progression
- Turn-based battle system
- Attack and Special ability buttons
- Hero and enemy HP bars
- Critical hit logic
- Hero HP persistence between levels
- Different enemies per level
- Victory scenes after completed levels
- Final Victory and Game Over scenes
- Custom button interaction feedback
- Custom cursor
- Background music system
- Music volume slider and mute toggle
- Music settings saved between sessions
- Music continues across scene changes

---

## Technical Systems

### GameManager

The project uses a central `GameManager` to keep important data available across scenes.

It handles:

- selected hero data
- current level
- unlocked progress
- player HP persistence
- enemy data
- general game state

This helps avoid repeating the same logic in every scene.

---

### Battle System

The `BattleController` handles the main battle logic.

It manages:

- hero and enemy HP
- attack damage
- special ability usage
- critical hits
- win / lose checks
- scene transitions after battle

The battle system was built in a way that allows future expansion, such as adding more heroes, enemies, abilities, or random enemy effects.

---

### Audio System

The audio system uses a persistent music manager so that background music does not restart or stop when changing scenes.

The options menu allows the player to:

- lower or raise the background music volume
- mute or unmute the music
- keep sound effects separate from music settings

This was implemented to create a smoother and more complete gameplay experience.

---

## Screenshots

### Start Scene



### Options Menu

<img width="938" height="525" alt="Options Menu_1" src="https://github.com/user-attachments/assets/9722aa7c-a3b8-4013-bb04-945c242e7035" />

<img width="938" height="525" alt="Options Menu" src="https://github.com/user-attachments/assets/f6d1bec8-56e7-428c-ba42-5cd9bba43a1a" />



### Character Selection

<img width="942" height="519" alt="Character Selection" src="https://github.com/user-attachments/assets/f3319122-d959-47d7-876a-4cf7a0c2aaeb" />


### Map Scene

<img width="938" height="529" alt="Map Scene" src="https://github.com/user-attachments/assets/be4dfe62-09f3-47f5-ab64-5324325a4c1e" />


### Battle Scene

<img width="941" height="523" alt="Battle Scene" src="https://github.com/user-attachments/assets/3412e220-3997-4373-ac49-b592bc1498fd" />


### Victory Scene

<img width="945" height="532" alt="Victory Scene" src="https://github.com/user-attachments/assets/6c3b3ddb-7676-4843-8dc0-86bb6a0d6eaf" />


---

## How to Run

1. Download or clone the repository.
2. Open the project through Unity Hub.
3. Open the project using the correct Unity version.
4. Open the Start Scene.
5. Press Play inside Unity.

If a Windows build is provided, run the `.exe` file inside the build folder.

---

## Project Status

The project is currently in a playable state and includes the main gameplay loop.

Further improvements may include:

- more enemy abilities
- more polished animations
- additional UI effects
- more balancing for hero and enemy stats
- improved visual presentation

---

## Educational Purpose

This project was created as part of a Unity course and is intended for educational purposes.

It was developed to practise Unity, C#, UI systems, scene management, game logic, and audio management.

---

## Author

Panos K.

Unity Student Project  
2026
