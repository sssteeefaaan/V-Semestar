
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public interface IObserver {
    void Update(ISubject s);
}