# InfiniteStamina Mod for MIMESIS

Never run out of stamina again! Provides unlimited stamina for uninterrupted gameplay.

![Version](https://img.shields.io/badge/version-1.0.0-blue)
![Game](https://img.shields.io/badge/game-MIMESIS-purple)
![MelonLoader](https://img.shields.io/badge/MelonLoader-0.6.1+-green)
![Status](https://img.shields.io/badge/status-working-brightgreen)

## 📖 Description

This mod provides infinite stamina in MIMESIS, removing the need to wait for stamina regeneration. You can now run, jump, and perform actions continuously without stamina limitations.

**Default stamina:** Limited, depletes with actions  
**Modified stamina:** 10,000 (effectively unlimited)

### How It Works

The mod patches the stamina system at two key points:
1. **Stamina Reading:** `StatManager.GetCurrentStamina()` - Always returns maximum stamina
2. **Stamina Regeneration:** `StatManager.RegenerateStamina()` - Instantly restores to maximum

> ✨ **Features:**
> - Host-based mod affects ALL players in the session
> - Never run out of stamina during gameplay
> - No waiting for stamina to regenerate
> - Seamless integration with existing game mechanics
> - Does not affect other stats or gameplay elements

## 🎯 Who Needs This Mod?

### ✅ **ONLY THE HOST** needs to install this mod!

The mod patches **server-side stamina system** that affects all players in the session. When the host has the mod installed, ALL players in the lobby get infinite stamina.

**Installation:**
- **Host (lobby creator):** ✅ Must install mod
- **Joining players:** ❌ No mod needed

This makes it easy to play with friends - only the person hosting needs the mod, and everyone benefits from unlimited stamina!

---

## 🚀 Quick Start

```
1. Download InfiniteStamina.dll
2. Place in: <MIMESIS>/Mods/InfiniteStamina.dll
3. HOST creates lobby (mod installed)
4. Friends join (NO mod needed)
5. Everyone enjoys unlimited stamina! 🎉
```

**📌 Remember:** Only the HOST (lobby creator) needs the mod installed!

---

## ✨ Features

- ✅ Unlimited stamina (10,000 points) for ALL players
- ✅ Host-only installation required
- ✅ Instant stamina regeneration
- ✅ No waiting for stamina recovery
- ✅ No game file modifications required
- ✅ Easy to install and uninstall

## 📋 Requirements

- **MIMESIS** (Steam version)
- **[MelonLoader](https://github.com/LavaGang/MelonLoader/releases)** v0.6.1 or higher
- Windows OS
- .NET Framework 4.7.2 or higher

## 🔧 Installation

### Step 1: Install MelonLoader

1. Download the latest MelonLoader installer from [GitHub Releases](https://github.com/LavaGang/MelonLoader/releases)
2. Run the installer and select your MIMESIS installation folder:
   - Default Steam location: `C:\Program Files (x86)\Steam\steamapps\common\MIMESIS`
   - Or right-click MIMESIS in Steam → Manage → Browse local files
3. Click Install
4. Launch the game once to let MelonLoader initialize (game will close automatically)

### Step 2: Install the Mod

1. Download `InfiniteStamina.dll` from [Releases](../../releases)
2. Copy `InfiniteStamina.dll` to your MIMESIS Mods folder:
   ```
   <MIMESIS_Install_Folder>/Mods/InfiniteStamina.dll
   ```
3. Launch the game

### Verify Installation

Check if the mod loaded successfully:
1. Navigate to `<MIMESIS_Install_Folder>/MelonLoader/Latest.log`
2. Look for these lines:
   ```
   InfiniteStamina Mod v1.0.0 - Initializing...
   SUCCESS: All Harmony patches applied!
   Active patches:
     [1] GetCurrentStamina() - Prefix
     [2] RegenerateStamina() - Prefix
   ```

## 🎮 Usage

Once installed on the host, the mod works automatically for everyone:

1. **Host creates lobby** - All players get unlimited stamina
2. **Players join** - They automatically benefit from infinite stamina
3. **Play normally** - Everyone can run, jump, and perform actions without stamina depletion
4. **Check stamina bars** - All players show maximum stamina (10,000 points)
5. **Enjoy the game** - No one waits for stamina to regenerate!

## 🔍 How It Works

The mod uses [HarmonyX](https://github.com/BepInEx/HarmonyX) to patch server-side stamina methods:

### Active Patches (2 total)

1. **GetCurrentStamina()** - Prefix patch always returns 10,000 for all players
2. **RegenerateStamina()** - Prefix patch sets stamina to 10,000 for all players

### Technical Details

**Patch 1 - GetCurrentStamina():**
```csharp
// Original: Returns current stamina value (can be low)
// Patched: Always returns 10,000 (maximum stamina)
static bool Prefix(StatManager __instance, ref long __result)
{
    __result = 10000;  // Set stamina to maximum
    return false;      // Skip original method
}
```

**Patch 2 - RegenerateStamina():**
```csharp
// Original: Gradually regenerates stamina over time
// Patched: Instantly sets stamina to maximum
static bool Prefix(StatManager __instance, ref long delta)
{
    __instance.SetMutableStat(MutableStatType.Stamina, 10000);
    return false;  // Skip original regeneration logic
}
```

**Target Class:** 
- `StatManager` - Server-side stamina management system (affects all connected players)

## 🎮 Testing the Mod

### Expected Behavior

When the host has the mod installed:

1. **All players' stamina bars** stay at maximum (10,000 points)
2. **No stamina depletion** for anyone when running, jumping, or performing actions
3. **Instant "regeneration"** - everyone's stamina immediately returns to max if somehow depleted

### How to Test

1. **Host installs mod** and creates lobby
2. **Friends join** (no mod needed for them)
3. **All players perform stamina-consuming actions:**
   - Run continuously
   - Jump repeatedly
   - Use stamina-based abilities
4. **Check results:**
   - ✅ Success: ALL players' stamina stays at maximum
   - ❌ Failed: Players still have normal stamina depletion

### Verifying Installation

Check `MelonLoader/Latest.log` for:

```
InfiniteStamina Mod v1.0.0 - Initializing...
SUCCESS: All Harmony patches applied!
Active patches:
  [1] GetCurrentStamina() - Prefix
  [2] RegenerateStamina() - Prefix
```

If you see this, the mod is loaded correctly! ✅

## 🐛 Troubleshooting

### Mod doesn't load (0 Mods loaded)

**Check:**
```powershell
# Verify the file exists
Test-Path "<MIMESIS_Folder>/Mods/InfiniteStamina.dll"
```

**Solutions:**
- Ensure MelonLoader is properly installed
- Unblock the DLL: Right-click → Properties → Check "Unblock" → Apply
- Make sure the file is in the correct `Mods` folder
- Restart the game

### Harmony patch errors in log

If you see errors like:
```
HarmonyLib.HarmonyException: Patching exception in method...
```

**Possible causes:**
- Game was updated and StatManager class structure changed
- Conflict with another stamina-related mod
- Corrupted mod file

**Solutions:**
- Download the latest version of the mod
- Try disabling other mods temporarily
- Check the [Issues](../../issues) page

### Game crashes on startup

1. Remove the mod temporarily:
   ```powershell
   del "<MIMESIS_Folder>/Mods/InfiniteStamina.dll"
   ```
2. Check the last lines in `MelonLoader/Latest.log` before the crash
3. Report the issue with the log file

### Stamina still depletes normally

**Possible reasons:**
- Host doesn't have the mod installed (only host needs it!)
- Mod didn't load properly on host's game (check host's log)
- Game updated and changed stamina system
- Another mod is interfering with stamina patches

**Check the HOST's log** for messages like:
```
InfiniteStamina Mod v1.0.0 - Initializing...
SUCCESS: All Harmony patches applied!
```
If the host doesn't see this, the mod isn't loading correctly.

## 🏗️ Building from Source

### Prerequisites
- Visual Studio 2019+ or MSBuild
- .NET Framework 4.7.2 SDK

### Build Steps

1. Clone the repository:
   ```bash
   git clone https://github.com/ToxesFoxes/Mimesis-InfiniteStamina.git
   cd Mimesis-InfiniteStamina
   ```

2. Copy game assemblies to `Libs/` folder:
   ```
   Libs/
   ├── Assembly-CSharp.dll      (from MIMESIS_Data/Managed)
   ├── UnityEngine.dll
   ├── UnityEngine.CoreModule.dll
   ├── netstandard.dll
   ├── MelonLoader.dll          (from MelonLoader/net6)
   └── 0Harmony.dll
   ```

3. Build the project:
   ```powershell
   MSBuild.exe InfiniteStamina.csproj /p:Configuration=Release
   ```

4. Output will be in `bin/Release/netstandard2.1/InfiniteStamina.dll`

## 📝 Changelog

### Version 1.0.0 (Current) - Initial Release! �

**Features:**
- **[PATCH 1]** `GetCurrentStamina()` - Always returns 10,000 stamina for all players
  - **Function:** Intercepts server-side stamina reading calls
  - **Result:** Game always sees maximum stamina for everyone
  - **Impact:** No stamina depletion for any player in the session
- **[PATCH 2]** `RegenerateStamina()` - Instantly sets stamina to maximum for all players
  - **Function:** Replaces gradual regeneration with instant restore
  - **Result:** Everyone's stamina immediately returns to 10,000
  - **Impact:** No waiting for stamina recovery for anyone

**Technical Details:**
- Clean, simple code structure
- Error handling for stability
- Comprehensive logging for debugging
- Compatible with MelonLoader 0.6.1+
- **All Patches:** 2 total (both active and working)

**How it works:**
- Uses HarmonyX Prefix patches to intercept stamina methods
- Replaces return values without modifying original game code
- Maintains compatibility with other mods and game updates

## 🤝 Contributing

Contributions are welcome! Please:
1. Fork the repository
2. Create a feature branch
3. Make your changes
4. Test thoroughly
5. Submit a pull request

## ⚠️ Disclaimer

- This mod is not affiliated with or endorsed by the developers of MIMESIS
- Use at your own risk
- Gameplay modifications may affect game balance and experience
- The mod author is not responsible for any issues, bans, or data loss
- Always backup your save files before using mods
- Consider the impact on multiplayer fairness when playing with others

## 📄 License

This project is licensed under the MIT License - see the [LICENSE](LICENSE.md) file for details.

## 🙏 Credits

- **Harmony** - [Harmony Patching Library](https://github.com/pardeike/Harmony)
- **MelonLoader** - [MelonLoader Mod Loader](https://github.com/LavaGang/MelonLoader)
- **MIMESIS** - Game by ReLUGames
- **ToxesFoxes** - Mod development

## 📞 Support

- 🐛 [Report Issues](../../issues)
- 💬 [Discussions](../../discussions)
- 📧 Contact: toxes_foxes@outlook.com

---

**Enjoy unlimited stamina gameplay! 🎮**
