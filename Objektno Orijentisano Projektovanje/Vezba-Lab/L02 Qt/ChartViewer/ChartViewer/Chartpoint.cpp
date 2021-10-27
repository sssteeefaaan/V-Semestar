#include "Chartpoint.h"

ChartPoint::ChartPoint(QString lab, float val, QColor col)
{ setPoint(lab,val,col); }

ChartPoint::~ChartPoint()
{}

void ChartPoint::setPoint(QString lab, float val, QColor col)
{ label = lab; value = val; color = col; }

void ChartPoint::savePoint(QString &str)
{ str += label + "," + QString::number(value) + "," + color.name(); }

QString ChartPoint::getLabel()
{ return label; }

void ChartPoint::setColor(QColor col)
{ this->color = col; }

QColor ChartPoint::getColor()
{ return color; }

float ChartPoint::getValue()
{ return value; }
