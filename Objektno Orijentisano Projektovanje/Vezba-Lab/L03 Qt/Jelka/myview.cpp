#include "myview.h"
#include <QPainter>
#include <QImage>
#include <QTimer>

MyView::MyView(QWidget *parent) : QWidget(parent)
{
    // Prvih nekoliko tačaka se zapravo neće iscrtati u trouglu, jer će tražiti geometrijsku sredinu za (0,0) i (100,400),
    // ali kasnije će težiti ka tačkama unutar trougla
    mx=0;
    my=0;
    tick=0; // totalno nepotrebna promenljiva

    // Standardno iscrtavanje belog pravougaonika 500, 500 na centralWidget-u
    this->img = QPixmap(500, 500).toImage();
    QPainter pImg(&img);
    pImg.setBrush(Qt::white);
    pImg.drawRect(0,0,500,500);
    // Iscrtavanje stabla
    pImg.setBrush(QColor(205,133,63));
    pImg.drawRect(250-25,500-100,50,100);

    QTimer *timer = new QTimer(this);
    connect(timer, SIGNAL(timeout()), this, SLOT(updateImage()));
    timer->start(/*202*/0); //1. Izmena, nije neophodna, ali da ne bi čekali

}

void MyView::paintEvent(QPaintEvent *)
{    
    QPainter p(this);
    p.drawImage(0, 0, img);
}

int MyView::rollqrand() // Nepotrebna funkcija
{
    return tick%3;
}

int MyView::getRandomRoll()
{
    return /*roll*/qrand()%6; //2. Izmena,
    // da bi išlo nasumično kroz sve vrednosti iz niza i iscrtavalo Sierpinski-jev trougao
    // ograničen tačkama iz niza
    // qrand() je funkcija iz std biblioteke qt-a i za povratnu vrednost ima prirodan broj iz opsega int
    // %6 do ograničava na opseg [0-5], što su i mogući indeksi našeg niza tačaka
}

void MyView::updateImage()
{
    QPainter pImg(&img);
    QPoint pts[6]={{100, 400}, {400, 400}, {250, 50}, {100, 400}, {400, 400}, {250, 50}};
    /* T1 (100,400) krajnja donje leva tačka trougla*/
    /* T2 (400,400) krajnje donje desna tačka trougla*/
    /* T3 (250, 50) vrh trougla*/

    int roll=getRandomRoll();

    mx = (mx + pts[roll].x()) / 2;
    my = (my + pts[roll].y()) / 2;
    // Polako će težiti ka svim vrednostima unutar figure (trougla) ograničenim sa T1, T2 i T3

    pImg.setPen(QColor(0,200,0));
    pImg.drawPoint(mx,my);

    tick++;
    this->repaint();
}
