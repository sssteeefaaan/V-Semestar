#include "curve.h"

Curve::Curve(quint8 width /*= 1*/, QRgb color /*= qRgb(0, 0, 0)*/)
{
    m_width = width;
    m_color = color;
}

void Curve::addPoint(const QPoint& pt)
{
	m_points.append(pt);
}

bool Curve::isValid()
{
	return (m_points.size() > 1);
}

void Curve::draw(QPainter& p)
{
    QPen pen(QColor::fromRgba(m_color));
    pen.setWidth(m_width);
    pen.setCapStyle(Qt::RoundCap);
    pen.setJoinStyle(Qt::RoundJoin);

    p.setPen(pen);

    p.drawPolyline(m_points.data(), m_points.size());
}

void Curve::load(QDataStream& stream)
{
	stream >> m_width;
	stream >> m_color;
	stream >> m_points;
}

void Curve::store(QDataStream& stream)
{
	stream << m_width;
	stream << m_color;
	stream << m_points;
}
