#include "Curve.h"

Curve::Curve(quint8 width, QColor color)
    :m_width(width),m_color(color){}

void Curve::addPoint(const QPoint& pt)
{ m_points.append(pt); }

bool Curve::isValid()
{ return (m_points.size() > 1); }

void Curve::draw(QPainter &p)
{
    QPen pen(m_color);
    pen.setWidth(m_width);
    pen.setCapStyle(Qt::RoundCap);
    pen.setJoinStyle(Qt::RoundJoin);

    p.setPen(pen);

    p.drawPolyline(m_points.data(), m_points.size());
}

void Curve::load(QDataStream &stream)
{ stream >> m_width >> m_color >> m_points; }

void Curve::store(QDataStream &stream)
{ stream << m_width << m_color << m_points; }
