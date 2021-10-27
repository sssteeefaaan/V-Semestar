#ifndef VIEW_H
#define VIEW_H

#include <QWidget>
#include <QPaintEvent>
#include <QMouseEvent>

#include "Document.h"

class View : public QWidget
{
    Q_OBJECT
public:
    explicit View(QWidget *parent = NULL);

signals:

public slots:

public:
    Document    doc;

    quint8      width;
    QColor      color;

protected:
    void paintEvent(QPaintEvent*e);
    void mousePressEvent(QMouseEvent *e);
    void mouseMoveEvent(QMouseEvent* e);
    void mouseReleaseEvent(QMouseEvent* e);
};

#endif // VIEW_H
