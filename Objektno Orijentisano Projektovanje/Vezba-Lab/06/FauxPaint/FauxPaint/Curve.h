#ifndef CURVE_H
#define CURVE_H

#include <QPoint>
#include <QVector>
#include <QRgb>
#include <QPainter>

class Curve
{
public:
    Curve(quint8 width = 1, QColor color = qRgb(0,0,0));

public:
    void                addPoint(const QPoint& pt);
    bool                isValid();
    void                draw(QPainter& p);

    void                load(QDataStream& stream);
    void                store(QDataStream& stream);

private:
    quint8              m_width;
    QColor                m_color;
    QVector<QPoint>     m_points;
};

#endif // CURVE_H
