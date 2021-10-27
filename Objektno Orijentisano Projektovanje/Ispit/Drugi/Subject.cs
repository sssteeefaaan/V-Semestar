
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
public interface ISubject
{
    void Subscribe(IObserver Obs);

    void Unsubscribe(IObserver Obs);

    void NotifyAll();

    Podaci getData();
}