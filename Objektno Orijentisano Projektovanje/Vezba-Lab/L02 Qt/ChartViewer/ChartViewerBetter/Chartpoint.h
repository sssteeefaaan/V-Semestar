#ifndef CHARTPOINT_H
#define CHARTPOINT_H

#include <QString>
#include <QColor>
#include <QPainter>

class ChartPoint
{
public:
    explicit    ChartPoint(QString lab = "Empty", float val = 0, QColor col = qRgb(0, 0, 0));
    virtual     ~ChartPoint();

private:
    QString     label;
    float       value;
    QColor      color;


public:
    void        setPoint(QString lab, float val, QColor col);
    void        setColor(QColor col);
    void        savePoint(QString& str);
    QString     getLabel();
    QColor      getColor();
    float       getValue();

};

#endif // CHARTPOINT_H
