# Arkanoid-game (Unity)

## English

A classic 2D Arkanoid-style game built in Unity.  
The project focuses on convenient level creation in the editor (custom Level Editor),  
using ScriptableObjects for level/block data, simple progress saving, and basic audio support.

---

### Quick Overview

- Levels are created as **ScriptableObject** `GameLevel` (a list of `BlockObject` with positions and references to `BlockData`).
- Includes a **custom editor window** (Window → Level Editor) for quick level painting directly in the Scene view.
- Levels are loaded during gameplay from `Resources/Levels`.
- Progress (unlocked levels, high scores/stars) and audio settings are saved in `PlayerPrefs` (JSON).
- Main gameplay logic: `Ball`, `PlayerMove` (paddle), `BlockScript` (destruction, HP), power-ups, block generation from ScriptableObjects.

---

### Project Structure

Assets/
├─ Editor/ # Custom Level Editor
│ └─ Scripts/
│ ├─ LevelEditor.cs # EditorWindow — UI for creating/editing levels
│ ├─ SceneEditor.cs # Interaction with SceneView
│ ├─ SaveLevel.cs # Saving block positions into GameLevel
│ └─ EditorData.cs # SO with block type sets
├─ Scripts/
│ ├─ Ball/ # Ball logic
│ ├─ BlockAndUFO/ # Blocks, composite pattern, UFO
│ ├─ GameBonus/ # Power-ups / bonuses
│ ├─ Level/ # Level management / progress saving
│ ├─ Player/ # Paddle and input handling
│ ├─ UI/ # UI windows, buttons, loading, settings
│ ├─ AudioController.cs # Singleton for audio
│ └─ ...
├─ ScriptableObject/
│ ├─ BlockData.cs
│ ├─ ColoredBlock.cs
│ └─ GameLevel.cs
├─ Audio/ # SFX files

---

### How the Game Works

1. **Level Selection & Start** — the selected `LevelIndex` is stored in `PlayerPrefs`; the `GameLevel` is loaded from `Resources/Levels`.
2. **Block Generation** — `BlocksGeneratorScript` instantiates prefabs according to the `GameLevel` data.
3. **Ball Mechanics** — `BallMoveScript`, `BallColissions`, and `BallSpeedController` handle movement, bouncing, and speed changes.
4. **Blocks** — `BlockScript` implements HP and sprite changes; `ColoredBlock` stores color, sprites, and score value.
5. **Bonuses** — `BonusGenerator` spawns bonuses from `GameLevel.Bonuses` with a certain probability.
6. **Progress & Saving** — `LevelsData` stores progress as JSON in `PlayerPrefs` (`LevelsProgressing`).
7. **Audio** — `AudioController` manages music and SFX; settings are saved via `AudioState`.

---

### Level Editor

- Access: `Window → Level Editor`.
- Workflow:
  1. Assign `Parent` and `EditorData`.
  2. Select the `GameLevel` asset.
  3. **Create blocks** — place blocks in SceneView.
  4. **Save level** — save block positions and types into the SO.

---

### Key ScriptableObjects

- `BlockData` — prefab reference for a block.
- `ColoredBlock` — adds sprite list, color, score value.
- `GameLevel` — contains block list (`BlockObject`) and bonuses (`BonusAttach`).

---

### Progress Saving

- Progress is stored in `PlayerPrefs` under the key `'Save'` as JSON with `LevelsProgressing`.
- Selected level index is stored under the key `'Index'`.
- Audio settings — stored under the key `'Audio'`.

---

### How to Run

1. Clone the repository:
   ```bash
   git clone https://github.com/qwyz888/Arkanoid-game.git
Open in Unity (check version in ProjectSettings).

To edit levels — open Window → Level Editor.

To play — open the Menu scene and press Play.

Screenshots
<img width="410" height="890" alt="choose_menu" src="https://github.com/user-attachments/assets/63c37ced-1493-45b5-9cd8-811a6206660a" /> <img width="410" height="892" alt="menu" src="https://github.com/user-attachments/assets/ccc09e69-4af7-4077-bf7e-3d947d238d2f" /> <img width="409" height="891" alt="gameplay" src="https://github.com/user-attachments/assets/63e7615e-a499-4806-9da6-06af2e18f1dc" /> <img width="410" height="890" alt="settings_menu" src="https://github.com/user-attachments/assets/8183f416-42fe-4397-a6a5-41127430d5e0" />


License
MIT License — see LICENSE



# Arkanoid-game (Unity)

Класична 2D Arkanoid-стиль гра, реалізована на Unity. Проєкт зроблений з фокусом на зручність створення рівнів у редакторі (custom Level Editor), використання ScriptableObject-ів для даних рівнів/блоків, просте збереження прогресу й базову аудіо-підтримку.

---

## Швидкий огляд

- Рівні створюються як **ScriptableObject** `GameLevel` (список `BlockObject` із позиціями та посиланнями на `BlockData`).
- Є **кастомне вікно редактора** (Window → Level Editor) для швидкого малювання рівнів у сцені.
- Рівні під час гри підвантажуються з `Resources/Levels`.
- Прогрес (відкриті рівні, рекорд/зірки) та налаштування аудіо зберігаються в `PlayerPrefs` (JSON).
- Основна логіка: `Ball`, `PlayerMove` (платформа), `BlockScript` (руйнування, HP), бонуси, генерація блоків із SO.

---

## Структура проєкту

```
Assets/
├─ Editor/                     # Custom Level Editor
│  └─ Scripts/
│     ├─ LevelEditor.cs        # EditorWindow — UI для створення/редагування рівнів
│     ├─ SceneEditor.cs        # Робота з SceneView
│     ├─ SaveLevel.cs          # Логіка збереження розташування блоків у GameLevel
│     └─ EditorData.cs         # SO для набору типів блоків
├─ Scripts/
│  ├─ Ball/                    # Логіка м'яча
│  ├─ BlockAndUFO/              # Блоки, composite патерн, UFO
│  ├─ GameBonus/                # Power-ups / бонуси
│  ├─ Level/                    # Менеджмент рівнів / збереження прогресу
│  ├─ Player/                   # Платформа і ввід
│  ├─ UI/                       # UI вікна, кнопки, loading, settings
│  ├─ AudioController.cs        # Singleton для звуку
│  └─ ...
├─ ScriptableObject/
│  ├─ BlockData.cs
│  ├─ ColoredBlock.cs
│  └─ GameLevel.cs
├─ Audio/                       # SFX файли
```

---

## Як працює гра

1. **Вибір і запуск рівня** — індекс рівня (`LevelIndex`) зберігається в `PlayerPrefs`, завантаження `GameLevel` із `Resources/Levels`.
2. **Генерація блоків** — `BlocksGeneratorScript` інстанціює префаби згідно з даними в `GameLevel`.
3. **Механіка м'яча** — класи `BallMoveScript`, `BallColissions`, `BallSpeedController` керують рухом, відскоком і швидкістю.
4. **Блоки** — `BlockScript` реалізує HP і зміну спрайтів, `ColoredBlock` зберігає колір, спрайти, очки.
5. **Бонуси** — `BonusGenerator` спавнить бонуси з `GameLevel.Bonuses` з певним шансом.
6. **Прогрес та збереження** — `LevelsData` зберігає JSON у `PlayerPrefs` (`LevelsProgressing`).
7. **Аудіо** — `AudioController` керує музикою і SFX, налаштування зберігаються через `AudioState`.

---

## Level Editor

- Відкриття: `Window → Level Editor`.
- Робочий процес:
  1. Прив’язати `Parent` і `EditorData`.
  2. Вибрати `GameLevel` asset.
  3. **Create blocks** — розміщення блоків у SceneView.
  4. **Save level** — збереження позицій і типів блоків у SO.

---

## Ключові ScriptableObject-и

- `BlockData` — посилання на префаб блоку.
- `ColoredBlock` — додає список спрайтів, колір, очки.
- `GameLevel` — містить список блоків (`BlockObject`) і бонусів (`BonusAttach`).

---

## Збереження прогресу

- Прогрес зберігається у `PlayerPrefs` ключ `'Save'` як JSON з `LevelsProgressing`.
- Індекс вибраного рівня зберігається під ключем `'Index'`.
- Аудіо налаштування — ключ `'Audio'`.

---

## Як запустити

1. Клонувати репозиторій:
   ```bash
   git clone https://github.com/qwyz888/Arkanoid-game.git
   ```
2. Відкрити у Unity (версія див. `ProjectSettings`).
3. Для редагування рівнів — `Window → Level Editor`.
4. Для гри — відкрити сцену `Menu` і натиснути Play.

---
## Скриншоти гри 
<img width="410" height="890" alt="choose_menu" src="https://github.com/user-attachments/assets/63c37ced-1493-45b5-9cd8-811a6206660a" />
<img width="410" height="892" alt="menu" src="https://github.com/user-attachments/assets/ccc09e69-4af7-4077-bf7e-3d947d238d2f" />
<img width="409" height="891" alt="gameplay" src="https://github.com/user-attachments/assets/63e7615e-a499-4806-9da6-06af2e18f1dc" />
<img width="410" height="890" alt="settings_menu" src="https://github.com/user-attachments/assets/8183f416-42fe-4397-a6a5-41127430d5e0" />

![gameplay](https://github.com/user-attachments/assets/1b3a5eec-5ce2-4224-8848-95a302ca7bb7)
## Ліцензія

MIT License — див. [LICENSE](LICENSE)
