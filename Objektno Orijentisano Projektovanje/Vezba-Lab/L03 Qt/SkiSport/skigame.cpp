#include "skigame.h"
#include <QString>
#include <QDebug>
#include <QTimer>
#include <QMessageBox>
#include <QtMath>

SkiGame::SkiGame(QSize canvas, int ss, int oa, int mh, QObject* parent)
    :QObject(parent)
{ setGame(canvas, ss, oa, mh); }

SkiGame::SkiGame(const SkiGame& org)
    :QObject(org.parent())
{
    if(this!=&org)
        setGame(org.canvas, org.santaSpeed, org.obstacleAmount, org.mountainHeight, org.state, org.santa, &(org.obstacles));
}

SkiGame &SkiGame::operator=(const SkiGame &org)
{
    if(this!=&org)
    {
        clr();
        setGame(org.canvas, org.santaSpeed, org.obstacleAmount, org.mountainHeight, org.state, org.santa, &(org.obstacles));
    }
    return *this;
}

SkiGame::~SkiGame()
{ clr(); }

void SkiGame::clr()
{
    if(santa)
    { delete santa; santa = 0; }

    for(int i = 0; i < obstacles.length(); i++)
    {
        if(obstacles[i])
        {
            delete obstacles[i];
            obstacles[i] = 0;
        }
    }
    obstacles.clear();

    state = GameState::Paused;
}

void SkiGame::setGame(QSize canvas, int santaSpeed, int obstacleAmount, int mountainHeight, GameState state, SkiSanta *santa, const QList<SkiObstacle *> *obstacles)
{
    this->canvas = canvas;
    this->santaSpeed = santaSpeed;
    this->obstacleAmount = obstacleAmount;
    this->mountainHeight = mountainHeight;
    this->state = state;
    if(santa)
        this->santa = new SkiSanta(*santa);
    else
        this->santa = new SkiSanta(QPointF(canvas.width()*9/20, canvas.height()*2/5), QSizeF(canvas.width()/10, canvas.height()/5));
    if(obstacles)
        foreach(SkiObstacle* so, *obstacles)
            this->obstacles.append(new SkiObstacle(*so));
}

void SkiGame::start()
{ if(state != GameState::Playing) { state = GameState::Playing; QTimer::singleShot(1000, this, SLOT(secPassed())); }}

void SkiGame::tick()
{
    for(int i=0; i<obstacles.length() ; i++)
    {
        if(fabs(obstacles[i]->getPos().x() - santa->getPos().x()) < 10 && fabs(obstacles[i]->getPos().y() - santa->getPos().y()) < 10)
        { state = GameState::Lost; emit end(); return; }
        if(!obstacles[i]->moveUp(canvas.height()/(200 - santaSpeed)))
        {
            SkiObstacle *obs = obstacles[i];
            delete obs;
            obs = 0;
            obstacles.removeAt(i);
        }
    }
}

void SkiGame::moveSanta(bool dx)
{
    if(santa){
        santa->move(canvas.width()/((dx?1:-1)*(200 - santaSpeed)), canvas.width());
        santa->steer(dx?1:-1);
    }
}

void SkiGame::normSanta()
{ santa->steer(0); }

void SkiGame::draw(QPainter &paint)
{
    QFont font;
    if(santa)
        paint.drawImage(QRectF(santa->getPos(), santa->getPos() + QPointF(santa->getDim().width(),santa->getDim().height())), *santa->getImg());
    for(int i=0; i < obstacles.length(); i++)
        paint.drawImage(QRectF(obstacles[i]->getPos(), obstacles[i]->getPos() + QPointF(obstacles[i]->getDim().width(), obstacles[i]->getDim().height())), *obstacles[i]->getImg());

    font.setPointSizeF(canvas.width()/50);
    paint.setFont(font);
    paint.drawText(QPoint(10, (canvas.height()+canvas.width())/50), "Time remaining: " + QString::number(mountainHeight));
}

void SkiGame::setCanvas(QSize dim)
{
    canvas = dim;
    if(santa)
        santa->resize(dim);
    foreach(SkiObstacle* so, obstacles)
        so->resize(dim);
}

void SkiGame::addObs()
{
    if(obstacles.length() < obstacleAmount && state==GameState::Playing){
        QTimer::singleShot(15*(200-santaSpeed), this, SLOT(addObs()));
        obstacles.append(new SkiObstacle(QPointF(qrand()%(canvas.width()*9/10), canvas.height()*6/5 + 200), QSizeF(canvas.width()/10, canvas.height()/5), static_cast<ObstacleType>(qrand()%2)));
    }
}

void SkiGame::secPassed()
{
    if(state == GameState::Playing && mountainHeight-- == 0)
        { state=GameState::Won; emit end(); }
    else
        QTimer::singleShot(1000, this, SLOT(secPassed()));
    addObs();
}
