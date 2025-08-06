using UnityEditor;
using UnityEngine;

public class SceneEditor : EditorWindow
{
    private readonly EditorGrid _grid = new EditorGrid();
    private LevelEditor _levelEditor;
    private Transform _parent;

    public void SetLevelEditor (LevelEditor levelEditor, Transform parent)
    {
        _parent = parent;
        _levelEditor = levelEditor;
    }

    public void OnSceneGUI(SceneView sceneView)
    {
        Event current = Event.current;
        if (current.type == EventType.MouseDown && current.button == 0) // Ліва кнопка миші
        {
            // Отримуємо промінь Ray з камери редактора
            Ray ray = HandleUtility.GUIPointToWorldRay(current.mousePosition);

            // Обчислюємо точку пересічення Ray з площиною XY
            Plane plane = new Plane(Vector3.back, Vector3.zero);
            if (plane.Raycast(ray, out float distance))
            {
                Vector3 point = ray.GetPoint(distance);

                // Конвертація в сіткову позицію
                Vector3 position = _grid.CheckPosition(point);

                if (position != Vector3.zero && IsEmpty(position))
                {
                    GameObject game = PrefabUtility.InstantiatePrefab(_levelEditor.GetBlock().Prefub, _parent) as GameObject;
                    game.transform.position = position;

                    if (game.TryGetComponent(out BaseBlock baseBlock))
                    {
                        baseBlock.BlockData = _levelEditor.GetBlock();
                    }

                    if (game.TryGetComponent(out BlockScript block))
                    { 
                        block.SetData(_levelEditor.GetBlock() as ColoredBlock);
                    }
                }
            }
        }

        if (current.type == EventType.Layout)
        {
            HandleUtility.AddDefaultControl(GUIUtility.GetControlID(GetHashCode(), FocusType.Passive));
        }
    }


    private bool IsEmpty(Vector3 position)
    {
        Collider2D collider = Physics2D.OverlapCircle(position, 0.01f);
        return collider == null;
    }

}
