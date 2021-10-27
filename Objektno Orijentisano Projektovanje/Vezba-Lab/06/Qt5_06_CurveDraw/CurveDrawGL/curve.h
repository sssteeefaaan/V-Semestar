#ifndef CURVE_H
#define CURVE_H

#include <QPoint>
#include <QVector>
#include <QRgb>
#include <QPainter>

class Curve
{
public:
    Curve(quint8 width = 1, QRgb color = qRgb(0, 0, 0));

// Methods
public:
	void			addPoint(const QPoint& pt);
	bool			isValid();
    void            draw(QPainter& p);	

	void			load(QDataStream& stream);
	void			store(QDataStream& stream);

// Attributes
private:
	quint8          m_width;
	QRgb            m_color;
	QVector<QPoint> m_points;
};

#endif // CURVE_H
