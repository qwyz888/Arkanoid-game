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
![gameplay](https://github.com/user-attachments/assets/1b3a5eec-5ce2-4224-8848-95a302ca7bb7)
<img width="409" height="891" alt="gameplay" src="https://github.com/user-attachments/assets/63e7615e-a499-4806-9da6-06af2e18f1dc" />
<img width="410" height="890" alt="settings_menu" src="https://github.com/user-attachments/assets/8183f416-42fe-4397-a6a5-41127430d5e0" />


## Ліцензія

MIT License — див. [LICENSE](LICENSE)
