using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Pong.Game.Interfaces
{
    public interface IPongCommand<T>
    {
        public void Invoke(T param);
    }
    public interface IPongCommand<U,T>
    {
        public void Invoke(U param,T param1);
    }
    public interface IPongCommand
    {
        public void Invoke();
    }
}


