#include "skiview.h"
#include <QDebug>
#include <QString>
#include <QFont>
#include <QMessageBox>
#include <QMainWindow>
#include "skisportdialog.h"

SkiView::SkiView(QWidget *parent)
    : QWidget(parent)
{ start(); }

SkiView::~SkiView()
{ clear(); }

void SkiView::start()
{
    rez = false;
    SkiSportDialog dialog(this);
    if(dialog.exec() == QDialog::Accepted)
    {
        qsrand(time(NULL));
        int santaSpeed, obstacleAmount, mountainHeight;
        QString str="";
        dialog.getData(santaSpeed, obstacleAmount, mountainHeight, str);

        game = new SkiGame(this->size(), santaSpeed, obstacleAmount, mountainHeight);
        clk = new QTimer(this);
        player = new QMediaPlayer();

        QMediaContent med(QUrl((const QString)str));
        player->setMedia(med);
        player->play();

        connect(clk, SIGNAL(timeout()), this, SLOT(tick()));
        connect(game, SIGNAL(end()), this, SLOT(end()));

        game->start();
        clk->start(30);
    }
    else
    { game = NULL; clk = NULL; player = NULL; this->parentWidget()->close(); }
}

void SkiView::clear()
{
    if(clk)
    { delete clk; clk = 0; }
    if(player)
    { delete player; player = 0; }
    if(game)
    { delete game; game=0; }
}

void SkiView::drawGE(QPainter &painter)
{
    QString str;
    QColor col;
    QFont font;

    if(rez)
    {
        str = "GAME WON!";
        col.setNamedColor("#00FF00");
        painter.setBackground(QBrush(Qt::white, Qt::SolidPattern));
    }
    else
    {
        str = "GAME OVER!";
        col.setNamedColor("#FF0000");
        painter.setBackground(QBrush(Qt::black, Qt::SolidPattern));
    }

    font.setPixelSize(100);
    font.setBold(true);
    QPen pen = QPen(col, 100, Qt::SolidLine);

    painter.setPen(pen);
    painter.setFont(font);

    painter.drawText((this->width() - (str.length() + 3)*50)/2, (this->height() + 100)/2, str);
}

void SkiView::paintEvent(QPaintEvent *event)
{
    QPainter painter(this);
    painter.setBackground(QBrush(Qt::white, Qt::SolidPattern));
    if(game && game->state == GameState::Playing)
        game->draw(painter);
    else
        drawGE(painter);
}

void SkiView::resizeEvent(QResizeEvent *event)
{
    if(game && game->state != GameState::Paused)
        game->setCanvas(this->size());
    repaint();
}

void SkiView::keyPressEvent(QKeyEvent *event)
{
    if(game && game->state == GameState::Playing){
        switch(event->key())
        {
        case Qt::Key_Left:
            game->moveSanta(false);
            break;
        case Qt::Key_Right:
            game->moveSanta(true);
            break;
        }
    }

    QWidget::keyPressEvent(event);
}

void SkiView::keyReleaseEvent(QKeyEvent *event)
{
    switch(event->key())
    {
    case Qt::Key_Left:
    case Qt::Key_Right:
        if(game && game->state == GameState::Playing)
            QTimer::singleShot(1000, game, SLOT(normSanta()));
        break;
    default:
        QWidget::keyPressEvent(event);
    }
}

void SkiView::tick()
{
    if(game && game->state == GameState::Playing)
    {
        game->tick();
        repaint();
    }
}

void SkiView::end()
{
    rez = (game->state == GameState::Won);
    player->stop();
    clk->stop();
    clear();
    repaint();
    QMessageBox msg(QMessageBox::Information,"Game ended!", "Wanna play again?",  QMessageBox::Yes | QMessageBox::No);
    if(msg.exec()==QMessageBox::Yes)
        start();
    else
        this->parentWidget()->close();
}
