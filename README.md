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


## Ліцензія

MIT License — див. [LICENSE](LICENSE)
