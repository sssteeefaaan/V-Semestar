#ifndef SKIVIEW_H
#define SKIVIEW_H

#include <QWidget>
#include "skigame.h"
#include <QTimer>
#include <QPainter>
#include <QKeyEvent>
#include <QMediaPlayer>

class SkiView : public QWidget
{
    Q_OBJECT
public:
    explicit SkiView(QWidget *parent = nullptr);
    virtual ~SkiView();

private:
    SkiGame* game;
    bool rez;
    QMediaPlayer* player;
    QTimer *clk;

private:
    void keyPressEvent(QKeyEvent *event);
    void paintEvent(QPaintEvent *event);
    void keyReleaseEvent(QKeyEvent *event);
    void resizeEvent(QResizeEvent *event);
    void start();
    void clear();
    void drawGE(QPainter& painter);

public slots:
    void tick();
    void end();
};

#endif // SKIVIEW_H
