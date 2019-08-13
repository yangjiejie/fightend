using UnityEngine;
using System.Collections;
using System;

public class ObjectPool<T> where T : UnityEngine.Object, new()
{
    public T item;

    public Stack resStack = new Stack();

    public Action<object> onActive;
    public Action<object> onDeActive;
    public ObjectPool(Action<object> onActive = null, Action<object> onDeActive = null)
    {
        this.onActive = onActive;
        this.onDeActive = onDeActive;
    }
    // Use this for initialization
    public void Release(T t)
    {
        if (this.onDeActive != null)
        {
            this.onDeActive(t);
        }
        resStack.Push(t);
    }

    // Update is called once per frame
    public T Get()
    {
        T newobj = null;
        if (resStack.Count > 0)
        {
            newobj = resStack.Pop() as T;
        }
        else
        {
            newobj = new T();
        }
        if (this.onActive != null)
        {
            this.onActive(newobj);
        }
        return newobj;
    }
    public ClearAll()
    {

    }
}
