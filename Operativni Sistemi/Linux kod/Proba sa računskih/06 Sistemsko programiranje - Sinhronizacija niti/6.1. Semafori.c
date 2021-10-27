// S - semaforska promenljiva

P, Wait, Down...(S)
{
    if (S > 0)
        S--;
    else
    //Blokirati proces na semaforu
}

V, Signal, Up...(S)
{
    if (/*Postoji proces koji čeka na semaforu*/)
        // Aktivirati proces iz liste čekanja
        else S++;
}