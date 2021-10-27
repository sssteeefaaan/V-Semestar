#include "skiobstacle.h"

SkiObstacle::SkiObstacle(QPointF p, QSizeF d, ObstacleType obs)
{ setObstacle(p, d, obs); }

SkiObstacle::SkiObstacle(const SkiObstacle& org)
{
    if(this!=&org)
        setObstacle(org.pos, org.dim, org.type, &org.obst);
}

SkiObstacle& SkiObstacle::operator=(const SkiObstacle& org)
{
    if(this!=&org){
        clrImgs();
        setObstacle(org.pos, org.dim, org.type, &org.obst);
    }
    return *this;
}

SkiObstacle::~SkiObstacle()
{ clrImgs(); }


void SkiObstacle::setObstacle(const QPointF&p, const QSizeF& d, ObstacleType t, const QList<QImage*> *list)
{
    pos = p;
    dim = d;
    type = t;

    if(list)
        foreach(QImage *i, *list)
            obst.append(new QImage(*i));
    else
        setImgs();
}

QImage* SkiObstacle::getImg()
{
    switch(type)
    {
    case ObstacleType::Snowman:
        return obst[0];
    case ObstacleType::XmasTree:
        return obst[1];
    /* lako dodavanje novih prepreka*/
    }
}

bool SkiObstacle::moveUp(float dy)
{
    float newY = pos.y() - dy;
    if(dim.height() + newY < 0)
        return false;
    pos.setY(newY);
    return true;
}

QPointF SkiObstacle::getPos() const
{ return pos; }

QSizeF SkiObstacle::getDim() const
{ return dim; }

void SkiObstacle::setImgs()
{
    obst.append(new QImage(":/Images/IMAGES/snowman.png"));
    obst.append(new QImage(":/Images/IMAGES/tree.png"));
}

void SkiObstacle::clrImgs()
{
    for(int i = 0; i< obst.size(); i++)
    {
        if(obst[i])
        { delete obst[i]; obst[i] = nullptr; }
    }
    obst.clear();
}

void SkiObstacle::resize(QSize canvas)
{
    dim = QSizeF(canvas.width()/10, canvas.height()/5);
    pos = QPointF(qrand() % (canvas.width()*9/10), canvas.height()*6/5 + 100 + qrand() % 500);
}
