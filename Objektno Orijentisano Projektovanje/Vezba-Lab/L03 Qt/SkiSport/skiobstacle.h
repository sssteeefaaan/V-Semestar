#ifndef SKIOBSTACLE_H
#define SKIOBSTACLE_H

#include <QImage>

enum ObstacleType{
    Snowman,
    XmasTree
};

class SkiObstacle
{
public:
    SkiObstacle(QPointF pos, QSizeF canvas, ObstacleType type = ObstacleType::XmasTree);
    SkiObstacle(const SkiObstacle& org);
    SkiObstacle& operator=(const SkiObstacle& org);
    virtual ~SkiObstacle();

private:
    QPointF pos;
    QSizeF dim;
    ObstacleType type;
    QList<QImage*> obst;
    void setObstacle(const QPointF&p, const QSizeF& d, ObstacleType type, const QList<QImage*> *list = nullptr);

public:
    void setImgs();
    void clrImgs();
    void resize(QSize dim);
    QPointF getPos() const;
    QSizeF getDim() const;
    QImage* getImg();
    bool moveUp(float dy);
};

#endif // SKIOBSTACLE_H
