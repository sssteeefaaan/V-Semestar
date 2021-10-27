#ifndef MYVIEW_H
#define MYVIEW_H

#include <QObject>
#include <QWidget>

class MyView : public QWidget
{
    Q_OBJECT
public:
    explicit MyView(QWidget *parent = nullptr);
    void paintEvent(QPaintEvent*);

    QImage img;
    int mx;
    int my;
    int tick;
    int rollqrand();
    int getRandomRoll();

signals:

public slots:

    void updateImage();

};

#endif // MYVIEW_H
