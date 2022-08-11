using UnityEngine;

[System.Serializable]
public struct MyVector
{
    public float x;
    public float y;

    public MyVector(float x, float y)
    {
        this.x = x;
        this.y = y;
    }

    public static implicit operator Vector3(MyVector origin)
    {
        return new Vector3(
            origin.x, 
            origin.y,
            0
            );
    }

    public MyVector Lerp(MyVector b, float c)
    {
        return (this + (b - this) * c);
    }

    public void Draw(Color color)
    {
        Debug.DrawLine(Vector3.zero, new Vector3(x, y, 0), color, 0);
    }

    public void Draw(Color color, MyVector origen)
    {
        Debug.DrawLine(new Vector3(origen.x, origen.y, 0), new Vector3(x + origen.x, y + origen.y, 0), color);
    }

    public MyVector Sum(MyVector other)
    {
        return new MyVector(
            x + other.x,
            y + other.y
        );
    }

    public MyVector Sub(MyVector other)
    {
        return new MyVector(
            x - other.x,
            y- other.y
            );
    }

    public MyVector Scale(MyVector other)
    {
        return new MyVector(
            x * other.x, 
            y* other.y
            );  
    }

    public static MyVector operator +(MyVector a, MyVector b)
    {
        return a.Sum(b);
    }

    public static MyVector operator -(MyVector a, MyVector b)
    {
        return a.Sub(b);
    }

    public static MyVector operator * (MyVector a, float b)
    {
        return a.Scale(a);
    }

    public static MyVector operator * (float b, MyVector a)
    {
        return a.Scale(a);
    }

    /*public void Draw(Color color)
    {
        Debug.DrawLine(
            new Vector3(0, 0, 0),
            new Vector3(x, y, 0),
            color,
            0
        );
    }*/

}

/*public struct MyStructVector
{
    private float ox;
    private float oy;
}*/
