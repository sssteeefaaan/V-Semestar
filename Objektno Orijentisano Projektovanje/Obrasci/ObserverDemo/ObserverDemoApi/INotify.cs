﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObserverDemoApi
{
    public interface INotify
    {
        void Notify(int valueToSend);
    }
}
