#ifndef VIEW_H
#define VIEW_H

#include <QWidget>

#include <QPaintEvent>
#include <QMouseEvent>

#include "document.h"

class View : public QWidget
{
    Q_OBJECT
public:
    explicit View(QWidget *parent = 0);

signals:

public slots:

public:	
    Document doc;

	quint8	 width;
	QRgb	 color;

protected:
    void paintEvent(QPaintEvent* e);
    void mousePressEvent(QMouseEvent* e);
    void mouseMoveEvent(QMouseEvent* e);
    void mouseReleaseEvent(QMouseEvent* e);
};

#endif // VIEW_H
