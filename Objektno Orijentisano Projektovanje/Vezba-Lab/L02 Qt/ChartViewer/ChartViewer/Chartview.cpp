#include "Chartview.h"

ChartView::ChartView(QWidget *parent)
    :QWidget(parent), m_chartDoc(new ChartDoc(this))
{}

ChartView::~ChartView()
{ if(m_chartDoc)delete m_chartDoc; }

void ChartView::mouseDoubleClickEvent(QMouseEvent* e)
{
    if(e->button()==Qt::LeftButton)
        m_chartDoc->select(e->pos(), this->width(), this->height());

}

void ChartView::paintEvent(QPaintEvent* e)
{
    QPainter p(this);
    p.fillRect(rect(), Qt::white);
    m_chartDoc->draw(p, this->width(), this->height());
}

void ChartView::onChartDataChanged()
{ m_chartDoc->setMod(true); repaint(); }
