#ifndef SKISANTA_H
#define SKISANTA_H

#include <QPointF>
#include <QSizeF>
#include <QImage>
#include <QQueue>
#include <QObject>

enum SantaType{
    Left,
    Str8,
    Right
};

class SkiSanta
{
public:
    SkiSanta(QPointF pos, QSizeF dim, SantaType type = SantaType::Str8);
    SkiSanta(const SkiSanta& org);
    SkiSanta& operator=(const SkiSanta& org);
    virtual ~SkiSanta();

private:
    QPointF pos;
    QSizeF dim;
    SantaType type;
    QList<QImage *> santa;
    void setSanta(const QPointF& p, const QSizeF& s, SantaType type, const QList<QImage*>* list=nullptr);

public:
    void move(float dx, int max); // true -> right, false -> left
    void setImgs();
    void clrImgs();
    QImage* getImg();
    QPointF getPos() const;
    void resize(QSize dim);
    QSizeF getDim() const;
    void steer(int dx = 0);
    QImage* swap(int i, int j);
};

#endif // SKISANTA_H
