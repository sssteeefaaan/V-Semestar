#include "view.h"

#include <QPainter>

View::View(QWidget *parent) :
    QWidget(parent)
{    
	width = 10;
	color = qRgba(255, 0, 0, 128);
}

void View::paintEvent(QPaintEvent* e)
{
    QPainter p(this);
    p.setRenderHint(QPainter::Antialiasing);
    p.fillRect(rect(), Qt::white);

    doc.draw(p);
}

void View::mousePressEvent(QMouseEvent* e)
{
	doc.startNewCurve(width, color);
	doc.addPointToCurve(e->pos());
}

void View::mouseMoveEvent(QMouseEvent* e)
{
    doc.addPointToCurve(e->pos());
    repaint();
}

void View::mouseReleaseEvent(QMouseEvent* e)
{
    doc.finishCurve();
}
