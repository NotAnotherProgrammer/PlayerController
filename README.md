## Features

- **Player Movement**: Smooth 2D platformer controls with jumping and directional movement
- **Combat System**: Attack enemies with a weapon hitbox system
- **Health & Lives System**: Player has health points and multiple lives with respawn mechanics
- **Invincibility Frames**: Temporary invincibility after taking damage
- **Timer-Based Gameplay**: Race against time to complete objectives
- **HUD Display**: Real-time display of health, lives, and remaining time
- **Game State Management**: Centralized game manager handling win/lose conditions

## Project Structure

```
Assets/
├── My Scripts/
│   ├── PlayerHealth.cs          # Manages player health, lives, and damage
│   ├── PlayerController2D.cs    # Handles player movement and combat
│   ├── GameManager.cs           # Singleton game state manager
│   ├── EnemyBase.cs             # Base class for enemy behaviors
│   ├── WeaponHitbox.cs          # Player weapon collision detection
│   └── HUDController.cs         # UI display controller
├── Scenes/                      # Unity scene files
├── Settings/                    # Project settings
└── UniversalRenderPipelineGlobalSettings.asset
```

## Setup Instructions

1. **Prerequisites**:
   - Unity 2021.3 or later
   - Universal Render Pipeline (URP) installed

2. **Clone/Download**:
   - Open the project in Unity Hub

3. **Scene Setup**:
   - Open your main scene from `Assets/Scenes/`
   - Ensure the following GameObjects exist:
     - Player (with PlayerHealth and PlayerController2D components)
     - GameManager (persistent across scenes)
     - HUD Canvas (with HUDController component)
     - Enemies (inheriting from EnemyBase)

4. **Component Configuration**:

   **PlayerHealth**:
   - Set `maxHealth`, `lives`, `damagePerHit`
   - Assign `respawnPoint` Transform
   - Adjust `invincibleTime`

   **PlayerController2D**:
   - Configure movement speeds and jump force
   - Set up ground check (Transform and LayerMask)
   - Assign `weaponHitbox` reference
   - Set attack timing values

   **GameManager**:
   - Adjust `gameTime` for level duration
   - Place in scene (will persist across scenes)

   **WeaponHitbox**:
   - Attach to player's weapon GameObject
   - Set `damage` value
   - Ensure proper collider setup

   **HUDController**:
   - Assign references to UI TextMeshPro components
   - Link to PlayerHealth and ensure GameManager exists

   **EnemyBase**:
   - Set `contactDamage` for collision damage
   - Add movement and AI logic as needed

## Controls

- **Movement**: Arrow Keys or WASD
- **Jump**: Spacebar
- **Attack**: Left Shift

## Game Mechanics

### Health System
- Player starts with full health and multiple lives
- Taking damage reduces health; reaching 0 health costs a life
- Temporary invincibility prevents damage spam
- Losing all lives ends the game

### Combat
- Attack creates an active hitbox for a short duration
- Enemies take damage on contact with the weapon hitbox
- Enemies deal contact damage to the player

### Timer
- Game runs on a countdown timer
- Reaching 0 time triggers game over
- Timer displays in MM:SS format

### Win/Lose Conditions
- **Win**: Implement custom victory conditions (e.g., defeat all enemies, reach goal)
- **Lose**: Run out of lives or time

## Extending the Game

### Adding New Enemies
1. Create a new script inheriting from `EnemyBase`
2. Override methods as needed (movement, attack patterns)
3. Set unique `contactDamage` values

### Custom Weapons
1. Create new weapon scripts extending `WeaponHitbox`
2. Add special effects, damage types, or hit detection logic
3. Update `PlayerController2D` to use the new weapon

### Power-ups and Items
- Add collectible items that modify player stats
- Use events in `PlayerHealth` or `GameManager` for stat changes

### Level Design
- Create multiple scenes with different layouts
- Use `GameManager` to track progress between levels
- Implement checkpoints with respawn points

## Known Issues

- Ensure all referenced components are properly assigned in the Inspector
- Timer may need adjustment based on level difficulty
- Add proper win conditions based on your game design

## Contributing

When adding new features:
1. Follow the existing code structure and naming conventions
2. Add comments for complex logic
3. Test thoroughly in Unity before committing
4. Update this README if adding major features

## License

This project is created for educational purposes. Feel free to use and modify as needed.
