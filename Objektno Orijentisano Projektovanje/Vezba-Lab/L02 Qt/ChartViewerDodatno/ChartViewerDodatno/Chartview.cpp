#include "Chartview.h"

ChartView::ChartView(QWidget *parent)
    :QWidget(parent), m_chartDoc(new ChartDoc(this))
{}

ChartView::~ChartView()
{ if(m_chartDoc)delete m_chartDoc; /* Nije u if-u */m_chartDoc = NULL; }

ChartDoc *ChartView::getDoc()
{ return m_chartDoc; }

void ChartView::mouseDoubleClickEvent(QMouseEvent* e)
{
    // Ukoliko se desio doubleClick i bilo je levo dugme miša, poziva se select funckija iz ChartDoc klase, mogla je i da se vrati bool vrednost
    // I ne šeta signalima iz klasa, ali odlučio sam se za ovo rešenje
    if(e->button()==Qt::LeftButton)
        m_chartDoc->select(e->pos(), this->width(), this->height());
}

// PiantEvent koji poziva draw funkciju koja iscrtava podatke svakim okidanjem ovog eventa
void ChartView::paintEvent(QPaintEvent* e)
{
    QPainter p(this);
    p.fillRect(rect(), Qt::white);
    m_chartDoc->draw(p, this->width(), this->height());
}

// Definicija slota
// Menja se modifikacija i iscrtava se chart
void ChartView::onChartDataChanged()
{ m_chartDoc->setMod(true); repaint(); }
