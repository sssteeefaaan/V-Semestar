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

    // Getter za ChartDoc*
    ChartDoc* getDoc();

    // Emituje se kad se desi promena na chart-u
public slots:
    void        onChartDataChanged();

    // Redefinisanje događaja
protected:
    void        mouseDoubleClickEvent(QMouseEvent* e);
    void        paintEvent(QPaintEvent* e);

    // Nisam uspeo da izvedem da ovo bude referenca na m_charDoc iz MainWindow-a,
    // Tako da ovo sadrži pokazivač na ChartDoc, kome MainWondow pristupa sa ui->centralWidget->m_chartDoc (s obzirom da je central widget promovisan na ChartView
    // E sad, da ne bih koristio setters & getters ponovo, postavio sam da ovo bude public u originalnom kodu(Što nije preporučljivo), ovde je to izmenjeno
private:
     ChartDoc*  m_chartDoc;

};

#endif // CHARTVIEW_H
