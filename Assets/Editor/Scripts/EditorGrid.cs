using UnityEngine;

public class EditorGrid 
{
    private const float _leftPosition = -0.75f;
    private const float _upPosition = 1.72f;
    private const int _columnCount = 6;
    private const int _rowCount = 10;
    private const float _offsetDown = 0.2f;
    private const float _offsetRight = 0.3f;


    public Vector3 CheckPosition(Vector3 position)
    {
        
        float tempX = 0;
        float tempY = 0;
        float x = _leftPosition - _offsetRight / 2;
        float y = _upPosition + _offsetDown / 2;

        

        if (position.x > x && position.x < (x + _offsetRight * _columnCount) &&
            position.y < y && position.y > (y - _offsetDown * _rowCount ))
        {
            for (int i = 0; i < _columnCount; i++)
            {
                if (position.x > x && position.x < (x+ _offsetRight))
                {
                    tempX = x + _offsetRight / 2;
                    break;
                }
                else
                {
                    x += _offsetRight;
                }
            }
            for (int i = 0; i < _rowCount; i++)
            {
                if (position.y < y && position.y > (y - _offsetDown))
                {
                    tempY = y - _offsetDown / 2;
                    break;
                }
                else
                {
                    y -= _offsetDown;
                }
            }
            Debug.Log(" In Zone x = " + tempX + " y= " + tempY);
        }
        else
        {
            Debug.Log(" Out of play zone x = " + tempX + " y= " + tempY);
            
        }
        return new Vector3(tempX, tempY);
    }
}
