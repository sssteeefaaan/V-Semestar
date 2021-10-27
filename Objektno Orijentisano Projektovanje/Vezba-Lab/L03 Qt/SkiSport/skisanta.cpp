#include "skisanta.h"
#include <QTimer>

SkiSanta::SkiSanta(QPointF pos, QSizeF dim, SantaType type)
{ setSanta(pos, dim, type); }

SkiSanta::SkiSanta(const SkiSanta&org)
{
    if(this!=&org)
        setSanta(org.pos, org.dim, org.type, &org.santa);
}

SkiSanta& SkiSanta::operator=(const SkiSanta& org)
{
    if(this!=&org)
    {
        clrImgs();
        setSanta(org.pos, org.dim, org.type, &org.santa);
    }
    return *this;
}

SkiSanta::~SkiSanta()
{ clrImgs(); }

void SkiSanta::setSanta(const QPointF &p, const QSizeF &s, SantaType type, const QList<QImage *> *list)
{
    pos = p;
    dim = s;
    this->type = type;

    if(list)
        for(int i=0; i<list->size(); i++)
            this->santa.append(new QImage(*((*list)[i])));
    else
        setImgs();
}

QSizeF SkiSanta::getDim() const
{ return dim; }

void SkiSanta::steer(int dx)
{
    if(dx == 0)
        type = SantaType::Str8;
    else
        if(dx < 0)
            type = SantaType::Left;
        else
            type = SantaType::Right;
}

QPointF SkiSanta::getPos() const
{ return pos; }

void SkiSanta::resize(QSize canvas)
{
    dim = QSizeF(canvas.width()/10, canvas.height()/5);
    pos = QPointF(canvas.width()*9/20, canvas.height()*2/5);
}

void SkiSanta::move(float dx, int max)
{
    float x = pos.x() + dx;
    if(x > max - dim.width())
        pos.setX(max - dim.width());
    else
        pos.setX(x >= 0 ? x : 0);
}

void SkiSanta::setImgs()
{
    santa.append(new QImage(":/Images/IMAGES/santa-left1.png"));
    santa.append(new QImage(":/Images/IMAGES/santa-left2.png"));

    santa.append(new QImage(":/Images/IMAGES/santa1.png"));
    santa.append(new QImage(":/Images/IMAGES/santa2.png"));

    santa.append(new QImage(":/Images/IMAGES/santa-right1.png"));
    santa.append(new QImage(":/Images/IMAGES/santa-right2.png"));
}

void SkiSanta::clrImgs()
{
    foreach(QImage* img, santa){
        if(img)
        { delete img; img = 0; }
    }
    santa.clear();
}

QImage* SkiSanta::getImg()
{
    switch (type) {
    case SantaType::Left:
        return swap(0,1);
    case SantaType::Str8:
        return swap(2,3);
    case SantaType::Right:
        return swap(4,5);
    }
}

QImage* SkiSanta::swap(int i, int j)
{
    QImage* temp = santa[i];
    santa[i] = santa[j];
    santa[j] = temp;

    return temp;
}
