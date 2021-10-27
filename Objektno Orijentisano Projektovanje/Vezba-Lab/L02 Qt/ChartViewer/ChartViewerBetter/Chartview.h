#ifndef CHARTVIEW_H
#define CHARTVIEW_H

#include <QWidget>
#include <QMouseEvent>
#include "mainwindow.h"

class ChartView : public QWidget
{
    Q_OBJECT
public:
    ChartView(QWidget* parent = nullptr);
    virtual     ~ChartView();

public slots:
    void        onChartDataChanged();

protected:
    void        mouseDoubleClickEvent(QMouseEvent* e);
    void        paintEvent(QPaintEvent* e);

public:
     ChartDoc*  m_chartDoc;

};

#endif // CHARTVIEW_H
